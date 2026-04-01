using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Functions;
using Bem.Models.Functions.Copy;

namespace Bem.Services.Functions;

/// <inheritdoc/>
public sealed class CopyService : ICopyService
{
    readonly Lazy<ICopyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICopyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public ICopyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CopyService(this._client.WithOptions(modifier));
    }

    public CopyService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CopyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FunctionResponse> Create(
        CopyCreateParams parameters,
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
public sealed class CopyServiceWithRawResponse : ICopyServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICopyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CopyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CopyServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionResponse>> Create(
        CopyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CopyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var functionResponse = await response
                    .Deserialize<FunctionResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    functionResponse.Validate();
                }
                return functionResponse;
            }
        );
    }
}
