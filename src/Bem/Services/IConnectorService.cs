using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Connectors;

namespace Bem.Services;

/// <summary>
/// Connectors are integrations that trigger a Bem workflow from an external system.
///
/// <para>A connector binds an inbound source — currently Box or a Paragon-managed
/// integration such as Google Drive — to a specific workflow (by `workflowName`
/// or `workflowID`). When the source observes a new file, Bem invokes the bound workflow
/// against that file.</para>
///
/// <para>Use these endpoints to create, list, and remove connectors. The fields used
/// at create time depend on the connector `type`: Box connectors require Box credentials
/// and a folder to watch, while Paragon connectors carry a `paragonIntegration`
/// identifier and an integration-specific `paragonConfiguration` object (for example,
/// `{ "folderId": "..." }` for Google Drive).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IConnectorService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConnectorServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConnectorService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Connector
    /// </summary>
    Task<Connector> Create(
        ConnectorCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Connectors
    /// </summary>
    Task<ConnectorListResponse> List(
        ConnectorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Connector
    /// </summary>
    Task<string> Delete(
        ConnectorDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ConnectorDeleteParams, CancellationToken)"/>
    Task<string> Delete(
        string connectorID,
        ConnectorDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IConnectorService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConnectorServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConnectorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/connectors</c>, but is otherwise the
    /// same as <see cref="IConnectorService.Create(ConnectorCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Connector>> Create(
        ConnectorCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/connectors</c>, but is otherwise the
    /// same as <see cref="IConnectorService.List(ConnectorListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConnectorListResponse>> List(
        ConnectorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/connectors/{connectorID}</c>, but is otherwise the
    /// same as <see cref="IConnectorService.Delete(ConnectorDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<string>> Delete(
        ConnectorDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ConnectorDeleteParams, CancellationToken)"/>
    Task<HttpResponse<string>> Delete(
        string connectorID,
        ConnectorDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
