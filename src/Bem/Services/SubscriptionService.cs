using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Subscriptions;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class SubscriptionService : ISubscriptionService
{
    readonly Lazy<ISubscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    public SubscriptionService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SubscriptionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionV3> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionV3> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionV3> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionV3> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionV3> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<SubscriptionV3>> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string subscriptionID,
        SubscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { SubscriptionID = subscriptionID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SubscriptionServiceWithRawResponse : ISubscriptionServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubscriptionServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionV3>> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscriptionV3 = await response
                    .Deserialize<SubscriptionV3>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscriptionV3.Validate();
                }
                return subscriptionV3;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionV3>> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new BemInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

        HttpRequest<SubscriptionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscriptionV3 = await response
                    .Deserialize<SubscriptionV3>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscriptionV3.Validate();
                }
                return subscriptionV3;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionV3>> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionV3>> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new BemInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

        HttpRequest<SubscriptionUpdateParams> request = new()
        {
            Method = BemClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscriptionV3 = await response
                    .Deserialize<SubscriptionV3>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscriptionV3.Validate();
                }
                return subscriptionV3;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionV3>> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<SubscriptionV3>>> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscriptionV3s = await response
                    .Deserialize<List<SubscriptionV3>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in subscriptionV3s)
                    {
                        item.Validate();
                    }
                }
                return subscriptionV3s;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new BemInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

        HttpRequest<SubscriptionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string subscriptionID,
        SubscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }
}
