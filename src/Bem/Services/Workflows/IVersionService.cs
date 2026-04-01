using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Workflows.Versions;

namespace Bem.Services.Workflows;

/// <summary>
/// Workflow operations
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
    /// Get a Workflow Version
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
    /// List Workflow Versions
    /// </summary>
    Task<VersionListPage> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<VersionListPage> List(
        string workflowName,
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
    /// Returns a raw HTTP response for <c>get /v3/workflows/{workflowName}/versions/{versionNum}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /v3/workflows/{workflowName}/versions</c>, but is otherwise the
    /// same as <see cref="IVersionService.List(VersionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionListPage>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<HttpResponse<VersionListPage>> List(
        string workflowName,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
