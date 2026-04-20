using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.InferSchema;

namespace Bem.Services;

/// <summary>
/// Infer JSON Schemas from uploaded documents using AI.
///
/// <para>Upload a file (PDF, image, spreadsheet, email, etc.) and receive a general-purpose
/// JSON Schema that captures the document's structure. The inferred schema can be
/// used directly as the `outputSchema` when creating Extract functions.</para>
///
/// <para>The schema is designed to be broadly applicable to documents of the same
/// type, not just the specific file uploaded.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInferSchemaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInferSchemaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInferSchemaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Analyze a file and infer a JSON Schema from its contents.**
    ///
    /// <para>Accepts a file via multipart form upload and uses Gemini to analyze the
    /// document, returning a description of its contents, an inferred JSON Schema
    /// capturing all extractable fields, and document classification metadata.</para>
    ///
    /// <para>The returned schema is designed to be reusable across many similar
    /// documents of the same type, not just the specific file uploaded. It can be used
    /// directly as the `outputSchema` when creating a Transform function.</para>
    ///
    /// <para>The endpoint also detects whether the file contains multiple bundled
    /// documents and classifies the content nature (textual, visual, audio, video, or
    /// mixed).</para>
    ///
    /// <para>## Supported file types</para>
    ///
    /// <para>PDF, PNG, JPEG, HEIC, HEIF, WebP, CSV, XLS, XLSX, DOCX, JSON, HTML, XML,
    /// EML, plain text, WAV, MP3, M4A, MP4.</para>
    ///
    /// <para>## File size limit</para>
    ///
    /// <para>Maximum file size is **20 MB**.</para>
    ///
    /// <para>## Examples</para>
    ///
    /// <para>Using curl: ```bash curl -X POST https://api.bem.ai/v3/infer-schema \   -H
    /// "x-api-key: YOUR_API_KEY" \   -F "file=@invoice.pdf" ```</para>
    ///
    /// <para>Using the Bem CLI: ```bash bem infer-schema create --file @invoice.pdf ```</para>
    /// </summary>
    Task<InferSchemaCreateResponse> Create(
        InferSchemaCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInferSchemaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInferSchemaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInferSchemaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/infer-schema</c>, but is otherwise the
    /// same as <see cref="IInferSchemaService.Create(InferSchemaCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InferSchemaCreateResponse>> Create(
        InferSchemaCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
