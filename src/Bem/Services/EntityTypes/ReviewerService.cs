using System;
using Bem.Core;

namespace Bem.Services.EntityTypes;

/// <inheritdoc/>
public sealed class ReviewerService : IReviewerService
{
    readonly Lazy<IReviewerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReviewerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IReviewerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewerService(this._client.WithOptions(modifier));
    }

    public ReviewerService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ReviewerServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class ReviewerServiceWithRawResponse : IReviewerServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReviewerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReviewerServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }
}
