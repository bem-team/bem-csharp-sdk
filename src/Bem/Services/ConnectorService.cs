using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Connectors;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class ConnectorService : IConnectorService
{
    readonly Lazy<IConnectorServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConnectorServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IConnectorService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConnectorService(this._client.WithOptions(modifier));
    }

    public ConnectorService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ConnectorServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Connector> Create(
        ConnectorCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConnectorListResponse> List(
        ConnectorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<string> Delete(
        ConnectorDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<string> Delete(
        string connectorID,
        ConnectorDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ConnectorID = connectorID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ConnectorServiceWithRawResponse : IConnectorServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConnectorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConnectorServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConnectorServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Connector>> Create(
        ConnectorCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ConnectorCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var connector = await response.Deserialize<Connector>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    connector.Validate();
                }
                return connector;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConnectorListResponse>> List(
        ConnectorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConnectorListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var connectors = await response
                    .Deserialize<ConnectorListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    connectors.Validate();
                }
                return connectors;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> Delete(
        ConnectorDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectorID == null)
        {
            throw new BemInvalidDataException("'parameters.ConnectorID' cannot be null");
        }

        HttpRequest<ConnectorDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<string>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<string>> Delete(
        string connectorID,
        ConnectorDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ConnectorID = connectorID }, cancellationToken);
    }
}
