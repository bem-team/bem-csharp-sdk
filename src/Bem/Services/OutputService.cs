using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Outputs;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class OutputService : IOutputService
{
    readonly Lazy<IOutputServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOutputServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IOutputService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OutputService(this._client.WithOptions(modifier));
    }

    public OutputService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OutputServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<OutputRetrieveResponse> Retrieve(
        OutputRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OutputRetrieveResponse> Retrieve(
        string eventID,
        OutputRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OutputListPage> List(
        OutputListParams? parameters = null,
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
public sealed class OutputServiceWithRawResponse : IOutputServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOutputServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OutputServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OutputServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OutputRetrieveResponse>> Retrieve(
        OutputRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new BemInvalidDataException("'parameters.EventID' cannot be null");
        }

        HttpRequest<OutputRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var output = await response
                    .Deserialize<OutputRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    output.Validate();
                }
                return output;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OutputRetrieveResponse>> Retrieve(
        string eventID,
        OutputRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OutputListPage>> List(
        OutputListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OutputListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<OutputListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new OutputListPage(this, parameters, page);
            }
        );
    }
}
