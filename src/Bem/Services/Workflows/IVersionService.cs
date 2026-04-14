using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Workflows.Versions;

namespace Bem.Services.Workflows;

/// <summary>
/// Workflows orchestrate one or more functions into a directed acyclic graph (DAG)
/// for document processing.
///
/// <para>Use these endpoints to create, update, list, and manage workflows, and to
/// invoke them with file input via `POST /v3/workflows/{workflowName}/call`.</para>
///
/// <para>The call endpoint accepts files as either multipart form data or JSON with
/// base64-encoded content. In the Bem CLI, use `@path/to/file` inside JSON values
/// to automatically read and encode files:</para>
///
/// <para>``` bem workflows call --workflow-name my-workflow \   --input.single-file
/// '{"inputContent": "@file.pdf", "inputType": "pdf"}' \   --wait ```</para>
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
