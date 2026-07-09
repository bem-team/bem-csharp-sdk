using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.EntityTypes.Reviewers;

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

    /// <inheritdoc/>
    public async Task<ReviewerListResponse> List(
        ReviewerListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ReviewerListResponse> List(
        string typeID,
        ReviewerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { TypeID = typeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Reviewer> Assign(
        ReviewerAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Assign(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Reviewer> Assign(
        string typeID,
        ReviewerAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Assign(parameters with { TypeID = typeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Remove(
        ReviewerRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Remove(
        string userID,
        ReviewerRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Remove(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
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

    /// <inheritdoc/>
    public async Task<HttpResponse<ReviewerListResponse>> List(
        ReviewerListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TypeID == null)
        {
            throw new BemInvalidDataException("'parameters.TypeID' cannot be null");
        }

        HttpRequest<ReviewerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var reviewers = await response
                    .Deserialize<ReviewerListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    reviewers.Validate();
                }
                return reviewers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ReviewerListResponse>> List(
        string typeID,
        ReviewerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { TypeID = typeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Reviewer>> Assign(
        ReviewerAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TypeID == null)
        {
            throw new BemInvalidDataException("'parameters.TypeID' cannot be null");
        }

        HttpRequest<ReviewerAssignParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var reviewer = await response.Deserialize<Reviewer>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    reviewer.Validate();
                }
                return reviewer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Reviewer>> Assign(
        string typeID,
        ReviewerAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Assign(parameters with { TypeID = typeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        ReviewerRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new BemInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ReviewerRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        string userID,
        ReviewerRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { UserID = userID }, cancellationToken);
    }
}
