using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.InferSchema;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class InferSchemaService : IInferSchemaService
{
    readonly Lazy<IInferSchemaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInferSchemaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IInferSchemaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InferSchemaService(this._client.WithOptions(modifier));
    }

    public InferSchemaService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InferSchemaServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<InferSchemaCreateResponse> Create(
        InferSchemaCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InferSchemaServiceWithRawResponse : IInferSchemaServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInferSchemaServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InferSchemaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InferSchemaServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InferSchemaCreateResponse>> Create(
        InferSchemaCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InferSchemaCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inferSchema = await response
                    .Deserialize<InferSchemaCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inferSchema.Validate();
                }
                return inferSchema;
            }
        );
    }
}
