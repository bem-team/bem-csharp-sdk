using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;
using Bem.Services.Entities;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class EntityService : IEntityService
{
    readonly Lazy<IEntityServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEntityServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IEntityService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntityService(this._client.WithOptions(modifier));
    }

    public EntityService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EntityServiceWithRawResponse(client.WithRawResponse));
        _synonyms = new(() => new SynonymService(client));
    }

    readonly Lazy<ISynonymService> _synonyms;
    public ISynonymService Synonyms
    {
        get { return _synonyms.Value; }
    }

    /// <inheritdoc/>
    public async Task<EntityUpdateResponse> Update(
        EntityUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityUpdateResponse> Update(
        string id,
        EntityUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntityBulkCreateResponse> BulkCreate(
        EntityBulkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.BulkCreate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityBulkValidateResponse> BulkValidate(
        EntityBulkValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.BulkValidate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityRetrieveRelationsResponse> RetrieveRelations(
        EntityRetrieveRelationsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveRelations(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityRetrieveRelationsResponse> RetrieveRelations(
        string id,
        EntityRetrieveRelationsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRelations(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntityRetrieveSeedStatusResponse> RetrieveSeedStatus(
        EntityRetrieveSeedStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveSeedStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityRetrieveSeedStatusResponse> RetrieveSeedStatus(
        string id,
        EntityRetrieveSeedStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSeedStatus(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EntityServiceWithRawResponse : IEntityServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEntityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntityServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EntityServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;

        _synonyms = new(() => new SynonymServiceWithRawResponse(client));
    }

    readonly Lazy<ISynonymServiceWithRawResponse> _synonyms;
    public ISynonymServiceWithRawResponse Synonyms
    {
        get { return _synonyms.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityUpdateResponse>> Update(
        EntityUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new BemInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntityUpdateParams> request = new()
        {
            Method = BemClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entity = await response
                    .Deserialize<EntityUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entity.Validate();
                }
                return entity;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntityUpdateResponse>> Update(
        string id,
        EntityUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityBulkCreateResponse>> BulkCreate(
        EntityBulkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EntityBulkCreateParams> request = new()
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
                    .Deserialize<EntityBulkCreateResponse>(token)
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
    public async Task<HttpResponse<EntityBulkValidateResponse>> BulkValidate(
        EntityBulkValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EntityBulkValidateParams> request = new()
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
                    .Deserialize<EntityBulkValidateResponse>(token)
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
    public async Task<HttpResponse<EntityRetrieveRelationsResponse>> RetrieveRelations(
        EntityRetrieveRelationsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new BemInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntityRetrieveRelationsParams> request = new()
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
                    .Deserialize<EntityRetrieveRelationsResponse>(token)
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
    public Task<HttpResponse<EntityRetrieveRelationsResponse>> RetrieveRelations(
        string id,
        EntityRetrieveRelationsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRelations(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityRetrieveSeedStatusResponse>> RetrieveSeedStatus(
        EntityRetrieveSeedStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new BemInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntityRetrieveSeedStatusParams> request = new()
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
                    .Deserialize<EntityRetrieveSeedStatusResponse>(token)
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
    public Task<HttpResponse<EntityRetrieveSeedStatusResponse>> RetrieveSeedStatus(
        string id,
        EntityRetrieveSeedStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSeedStatus(parameters with { ID = id }, cancellationToken);
    }
}
