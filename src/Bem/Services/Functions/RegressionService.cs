using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Functions.Regression;

namespace Bem.Services.Functions;

/// <inheritdoc/>
public sealed class RegressionService : IRegressionService
{
    readonly Lazy<IRegressionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRegressionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IRegressionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RegressionService(this._client.WithOptions(modifier));
    }

    public RegressionService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RegressionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RegressionApplyCorrectionsResponse> ApplyCorrections(
        RegressionApplyCorrectionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ApplyCorrections(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RegressionRunResponse> Run(
        RegressionRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Run(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RegressionServiceWithRawResponse : IRegressionServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRegressionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RegressionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RegressionServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegressionApplyCorrectionsResponse>> ApplyCorrections(
        RegressionApplyCorrectionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RegressionApplyCorrectionsParams> request = new()
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
                    .Deserialize<RegressionApplyCorrectionsResponse>(token)
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
    public async Task<HttpResponse<RegressionRunResponse>> Run(
        RegressionRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RegressionRunParams> request = new()
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
                    .Deserialize<RegressionRunResponse>(token)
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
