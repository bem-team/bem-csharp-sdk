using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class ErrorService : IErrorService
{
    readonly Lazy<IErrorServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IErrorServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IErrorService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ErrorService(this._client.WithOptions(modifier));
    }

    public ErrorService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ErrorServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ErrorRetrieveResponse> Retrieve(
        ErrorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ErrorRetrieveResponse> Retrieve(
        string eventID,
        ErrorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ErrorListPage> List(
        ErrorListParams? parameters = null,
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
public sealed class ErrorServiceWithRawResponse : IErrorServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IErrorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ErrorServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ErrorServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ErrorRetrieveResponse>> Retrieve(
        ErrorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new BemInvalidDataException("'parameters.EventID' cannot be null");
        }

        HttpRequest<ErrorRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var error = await response
                    .Deserialize<ErrorRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    error.Validate();
                }
                return error;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ErrorRetrieveResponse>> Retrieve(
        string eventID,
        ErrorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ErrorListPage>> List(
        ErrorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ErrorListParams> request = new()
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
                    .Deserialize<ErrorListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ErrorListPage(this, parameters, page);
            }
        );
    }
}
