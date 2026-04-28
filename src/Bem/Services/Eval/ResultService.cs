using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Eval.Results;

namespace Bem.Services.Eval;

/// <inheritdoc/>
public sealed class ResultService : IResultService
{
    readonly Lazy<IResultServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IResultServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IResultService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ResultService(this._client.WithOptions(modifier));
    }

    public ResultService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ResultServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ResultFetchResultsResponse> FetchResults(
        ResultFetchResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FetchResults(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ResultRetrieveResultsResponse> RetrieveResults(
        ResultRetrieveResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveResults(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ResultServiceWithRawResponse : IResultServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IResultServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ResultServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ResultServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ResultFetchResultsResponse>> FetchResults(
        ResultFetchResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ResultFetchResultsParams> request = new()
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
                    .Deserialize<ResultFetchResultsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ResultRetrieveResultsResponse>> RetrieveResults(
        ResultRetrieveResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ResultRetrieveResultsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ResultRetrieveResultsResponse>(token)
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
