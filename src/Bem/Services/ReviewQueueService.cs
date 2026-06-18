using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.ReviewQueue;

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

    /// <inheritdoc/>
    public async Task<ReviewQueueListResponse> List(
        ReviewQueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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

    /// <inheritdoc/>
    public async Task<HttpResponse<ReviewQueueListResponse>> List(
        ReviewQueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReviewQueueListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var reviewQueues = await response
                    .Deserialize<ReviewQueueListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    reviewQueues.Validate();
                }
                return reviewQueues;
            }
        );
    }
}
