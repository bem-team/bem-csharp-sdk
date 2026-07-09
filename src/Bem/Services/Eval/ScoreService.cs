using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Eval.Score;

namespace Bem.Services.Eval;

/// <inheritdoc/>
public sealed class ScoreService : IScoreService
{
    readonly Lazy<IScoreServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IScoreServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IScoreService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ScoreService(this._client.WithOptions(modifier));
    }

    public ScoreService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ScoreServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ScoreCreateResponse> Create(
        ScoreCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EvalScoreRun> Retrieve(
        ScoreRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EvalScoreRun> Retrieve(
        string scoreRunID,
        ScoreRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ScoreRunID = scoreRunID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EvalScoreRun> Cancel(
        ScoreCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EvalScoreRun> Cancel(
        string scoreRunID,
        ScoreCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ScoreRunID = scoreRunID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ScoreServiceWithRawResponse : IScoreServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IScoreServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ScoreServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ScoreServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ScoreCreateResponse>> Create(
        ScoreCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ScoreCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var score = await response
                    .Deserialize<ScoreCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    score.Validate();
                }
                return score;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EvalScoreRun>> Retrieve(
        ScoreRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ScoreRunID == null)
        {
            throw new BemInvalidDataException("'parameters.ScoreRunID' cannot be null");
        }

        HttpRequest<ScoreRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var evalScoreRun = await response
                    .Deserialize<EvalScoreRun>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    evalScoreRun.Validate();
                }
                return evalScoreRun;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EvalScoreRun>> Retrieve(
        string scoreRunID,
        ScoreRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ScoreRunID = scoreRunID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EvalScoreRun>> Cancel(
        ScoreCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ScoreRunID == null)
        {
            throw new BemInvalidDataException("'parameters.ScoreRunID' cannot be null");
        }

        HttpRequest<ScoreCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var evalScoreRun = await response
                    .Deserialize<EvalScoreRun>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    evalScoreRun.Validate();
                }
                return evalScoreRun;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EvalScoreRun>> Cancel(
        string scoreRunID,
        ScoreCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ScoreRunID = scoreRunID }, cancellationToken);
    }
}
