using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Buckets;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class BucketService : IBucketService
{
    readonly Lazy<IBucketServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBucketServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IBucketService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BucketService(this._client.WithOptions(modifier));
    }

    public BucketService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BucketServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BucketV3> Create(
        BucketCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BucketV3> Retrieve(
        BucketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BucketV3> Retrieve(
        string bucketID,
        BucketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BucketID = bucketID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BucketV3> Update(
        BucketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BucketV3> Update(
        string bucketID,
        BucketUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { BucketID = bucketID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BucketListResponse> List(
        BucketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(BucketDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string bucketID,
        BucketDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { BucketID = bucketID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BucketServiceWithRawResponse : IBucketServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBucketServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BucketServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BucketServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BucketV3>> Create(
        BucketCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BucketCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bucketV3 = await response.Deserialize<BucketV3>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bucketV3.Validate();
                }
                return bucketV3;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BucketV3>> Retrieve(
        BucketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketID == null)
        {
            throw new BemInvalidDataException("'parameters.BucketID' cannot be null");
        }

        HttpRequest<BucketRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bucketV3 = await response.Deserialize<BucketV3>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bucketV3.Validate();
                }
                return bucketV3;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BucketV3>> Retrieve(
        string bucketID,
        BucketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BucketID = bucketID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BucketV3>> Update(
        BucketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketID == null)
        {
            throw new BemInvalidDataException("'parameters.BucketID' cannot be null");
        }

        HttpRequest<BucketUpdateParams> request = new()
        {
            Method = BemClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bucketV3 = await response.Deserialize<BucketV3>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bucketV3.Validate();
                }
                return bucketV3;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BucketV3>> Update(
        string bucketID,
        BucketUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { BucketID = bucketID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BucketListResponse>> List(
        BucketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BucketListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var buckets = await response
                    .Deserialize<BucketListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    buckets.Validate();
                }
                return buckets;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BucketDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketID == null)
        {
            throw new BemInvalidDataException("'parameters.BucketID' cannot be null");
        }

        HttpRequest<BucketDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string bucketID,
        BucketDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { BucketID = bucketID }, cancellationToken);
    }
}
