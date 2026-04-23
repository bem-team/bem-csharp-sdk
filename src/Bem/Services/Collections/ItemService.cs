using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Collections.Items;

namespace Bem.Services.Collections;

/// <inheritdoc/>
public sealed class ItemService : IItemService
{
    readonly Lazy<IItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    public ItemService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ItemServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ItemRetrieveResponse> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ItemUpdateResponse> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(ItemDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ItemAddResponse> Add(
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ItemServiceWithRawResponse : IItemServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ItemServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ItemRetrieveResponse>> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ItemRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var item = await response
                    .Deserialize<ItemRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    item.Validate();
                }
                return item;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ItemUpdateResponse>> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ItemUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var item = await response
                    .Deserialize<ItemUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    item.Validate();
                }
                return item;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ItemDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ItemAddResponse>> Add(
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ItemAddParams> request = new()
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
                    .Deserialize<ItemAddResponse>(token)
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
