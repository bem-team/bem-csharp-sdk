using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Collections;
using Bem.Services.Collections;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class CollectionService : ICollectionService
{
    readonly Lazy<ICollectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICollectionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public ICollectionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CollectionService(this._client.WithOptions(modifier));
    }

    public CollectionService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CollectionServiceWithRawResponse(client.WithRawResponse));
        _items = new(() => new ItemService(client));
    }

    readonly Lazy<IItemService> _items;
    public IItemService Items
    {
        get { return _items.Value; }
    }

    /// <inheritdoc/>
    public async Task<CollectionCreateResponse> Create(
        CollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CollectionListResponse> List(
        CollectionListParams? parameters = null,
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
        CollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CollectionCountTokensResponse> CountTokens(
        CollectionCountTokensParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CountTokens(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CollectionServiceWithRawResponse : ICollectionServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICollectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CollectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CollectionServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;

        _items = new(() => new ItemServiceWithRawResponse(client));
    }

    readonly Lazy<IItemServiceWithRawResponse> _items;
    public IItemServiceWithRawResponse Items
    {
        get { return _items.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionCreateResponse>> Create(
        CollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CollectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var collection = await response
                    .Deserialize<CollectionCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    collection.Validate();
                }
                return collection;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionListResponse>> List(
        CollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CollectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var collections = await response
                    .Deserialize<CollectionListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    collections.Validate();
                }
                return collections;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CollectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionCountTokensResponse>> CountTokens(
        CollectionCountTokensParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CollectionCountTokensParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<CollectionCountTokensResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
