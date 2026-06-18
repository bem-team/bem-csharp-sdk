using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.KnowledgeGraph;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class KnowledgeGraphService : IKnowledgeGraphService
{
    readonly Lazy<IKnowledgeGraphServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IKnowledgeGraphServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IKnowledgeGraphService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new KnowledgeGraphService(this._client.WithOptions(modifier));
    }

    public KnowledgeGraphService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new KnowledgeGraphServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<KnowledgeGraphRetrieveResponse> Retrieve(
        KnowledgeGraphRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class KnowledgeGraphServiceWithRawResponse : IKnowledgeGraphServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IKnowledgeGraphServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new KnowledgeGraphServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public KnowledgeGraphServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KnowledgeGraphRetrieveResponse>> Retrieve(
        KnowledgeGraphRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<KnowledgeGraphRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var knowledgeGraph = await response
                    .Deserialize<KnowledgeGraphRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    knowledgeGraph.Validate();
                }
                return knowledgeGraph;
            }
        );
    }
}
