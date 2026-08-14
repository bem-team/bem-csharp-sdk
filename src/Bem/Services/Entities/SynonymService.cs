using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities.Synonyms;

namespace Bem.Services.Entities;

/// <inheritdoc/>
public sealed class SynonymService : ISynonymService
{
    readonly Lazy<ISynonymServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISynonymServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public ISynonymService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SynonymService(this._client.WithOptions(modifier));
    }

    public SynonymService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SynonymServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SynonymAddResponse> Add(
        SynonymAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SynonymAddResponse> Add(
        string id,
        SynonymAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Remove(
        SynonymRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Remove(
        string synonymID,
        SynonymRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Remove(parameters with { SynonymID = synonymID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SynonymServiceWithRawResponse : ISynonymServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISynonymServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SynonymServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SynonymServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SynonymAddResponse>> Add(
        SynonymAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new BemInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SynonymAddParams> request = new()
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
                    .Deserialize<SynonymAddResponse>(token)
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
    public Task<HttpResponse<SynonymAddResponse>> Add(
        string id,
        SynonymAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        SynonymRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SynonymID == null)
        {
            throw new BemInvalidDataException("'parameters.SynonymID' cannot be null");
        }

        HttpRequest<SynonymRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        string synonymID,
        SynonymRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { SynonymID = synonymID }, cancellationToken);
    }
}
