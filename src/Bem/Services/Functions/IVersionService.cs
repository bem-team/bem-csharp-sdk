using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Functions.Versions;

namespace Bem.Services.Functions;

/// <summary>
/// Functions are the core building blocks of data transformation in Bem. Each function
/// type serves a specific purpose:
///
/// <para>- **Extract**: Extract structured JSON data from unstructured documents
/// (PDFs, emails, images, spreadsheets), with optional layout-aware bounding-box
/// extraction - **Route**: Direct data to different processing paths based on conditions
/// - **Split**: Break multi-page documents into individual pages for parallel processing
/// - **Join**: Combine outputs from multiple function calls into a single result
/// - **Payload Shaping**: Transform and restructure data using JMESPath expressions
/// - **Enrich**: Enhance data with semantic search against collections - **Send**:
/// Deliver workflow outputs to downstream destinations</para>
///
/// <para>Use these endpoints to create, update, list, and manage your functions.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVersionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVersionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a Function Version
    /// </summary>
    Task<VersionRetrieveResponse> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<VersionRetrieveResponse> Retrieve(
        long versionNum,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Function Versions
    /// </summary>
    Task<VersionListResponse> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<VersionListResponse> List(
        string functionName,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVersionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVersionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/functions/{functionName}/versions/{versionNum}</c>, but is otherwise the
    /// same as <see cref="IVersionService.Retrieve(VersionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionRetrieveResponse>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VersionRetrieveResponse>> Retrieve(
        long versionNum,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/functions/{functionName}/versions</c>, but is otherwise the
    /// same as <see cref="IVersionService.List(VersionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionListResponse>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<HttpResponse<VersionListResponse>> List(
        string functionName,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
