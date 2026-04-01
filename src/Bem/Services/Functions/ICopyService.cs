using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Functions;
using Bem.Models.Functions.Copy;

namespace Bem.Services.Functions;

/// <summary>
/// Functions are the core building blocks of data transformation in Bem. Each function
/// type serves a specific purpose:
///
/// <para>- **Transform**: Extract structured JSON data from unstructured documents
/// (PDFs, emails, images) - **Analyze**: Perform visual analysis on documents to
/// extract layout-aware information - **Route**: Direct data to different processing
/// paths based on conditions - **Split**: Break multi-page documents into individual
/// pages for parallel processing - **Join**: Combine outputs from multiple function
/// calls into a single result - **Payload Shaping**: Transform and restructure data
/// using JMESPath expressions - **Enrich**: Enhance data with semantic search against collections</para>
///
/// <para>Use these endpoints to create, update, list, and manage your functions.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICopyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICopyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICopyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Copy a Function
    /// </summary>
    Task<FunctionResponse> Create(
        CopyCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICopyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICopyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICopyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/functions/copy</c>, but is otherwise the
    /// same as <see cref="ICopyService.Create(CopyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionResponse>> Create(
        CopyCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
