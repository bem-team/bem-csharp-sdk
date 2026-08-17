using System;
using Bem.Core;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class ReviewQueueService : IReviewQueueService
{
    readonly Lazy<IReviewQueueServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReviewQueueServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IReviewQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewQueueService(this._client.WithOptions(modifier));
    }

    public ReviewQueueService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ReviewQueueServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class ReviewQueueServiceWithRawResponse : IReviewQueueServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReviewQueueServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReviewQueueServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReviewQueueServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }
}
