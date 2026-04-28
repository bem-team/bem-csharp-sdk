using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Eval;
using Bem.Services.Eval;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class EvalService : IEvalService
{
    readonly Lazy<IEvalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEvalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IEvalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EvalService(this._client.WithOptions(modifier));
    }

    public EvalService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EvalServiceWithRawResponse(client.WithRawResponse));
        _results = new(() => new ResultService(client));
    }

    readonly Lazy<IResultService> _results;
    public IResultService Results
    {
        get { return _results.Value; }
    }

    /// <inheritdoc/>
    public async Task<EvalTriggerEvaluationResponse> TriggerEvaluation(
        EvalTriggerEvaluationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TriggerEvaluation(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EvalServiceWithRawResponse : IEvalServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEvalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EvalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EvalServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;

        _results = new(() => new ResultServiceWithRawResponse(client));
    }

    readonly Lazy<IResultServiceWithRawResponse> _results;
    public IResultServiceWithRawResponse Results
    {
        get { return _results.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EvalTriggerEvaluationResponse>> TriggerEvaluation(
        EvalTriggerEvaluationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EvalTriggerEvaluationParams> request = new()
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
                    .Deserialize<EvalTriggerEvaluationResponse>(token)
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
