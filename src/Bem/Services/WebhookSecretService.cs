using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.WebhookSecret;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class WebhookSecretService : IWebhookSecretService
{
    readonly Lazy<IWebhookSecretServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookSecretServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IWebhookSecretService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookSecretService(this._client.WithOptions(modifier));
    }

    public WebhookSecretService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new WebhookSecretServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<WebhookSecretCreateResponse> Create(
        WebhookSecretCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WebhookSecretRetrieveResponse> Retrieve(
        WebhookSecretRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Revoke(
        WebhookSecretRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Revoke(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WebhookSecretServiceWithRawResponse : IWebhookSecretServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookSecretServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WebhookSecretServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookSecretServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookSecretCreateResponse>> Create(
        WebhookSecretCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookSecretCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookSecret = await response
                    .Deserialize<WebhookSecretCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookSecret.Validate();
                }
                return webhookSecret;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookSecretRetrieveResponse>> Retrieve(
        WebhookSecretRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookSecretRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookSecret = await response
                    .Deserialize<WebhookSecretRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookSecret.Validate();
                }
                return webhookSecret;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Revoke(
        WebhookSecretRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookSecretRevokeParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
