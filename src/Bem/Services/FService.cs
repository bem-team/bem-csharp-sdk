using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Fs;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class FService : IFService
{
    readonly Lazy<IFServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IFService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FService(this._client.WithOptions(modifier));
    }

    public FService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FNavigateResponse> Navigate(
        FNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Navigate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FServiceWithRawResponse : IFServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FNavigateResponse>> Navigate(
        FNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FNavigateParams> request = new()
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
                    .Deserialize<FNavigateResponse>(token)
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
