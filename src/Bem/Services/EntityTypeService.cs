using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.EntityTypes;
using Bem.Services.EntityTypes;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class EntityTypeService : IEntityTypeService
{
    readonly Lazy<IEntityTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEntityTypeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IEntityTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntityTypeService(this._client.WithOptions(modifier));
    }

    public EntityTypeService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EntityTypeServiceWithRawResponse(client.WithRawResponse));
        _reviewers = new(() => new ReviewerService(client));
    }

    readonly Lazy<IReviewerService> _reviewers;
    public IReviewerService Reviewers
    {
        get { return _reviewers.Value; }
    }

    /// <inheritdoc/>
    public async Task<EntityTypeCreateResponse> Create(
        EntityTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityTypeRetrieveResponse> Retrieve(
        EntityTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityTypeRetrieveResponse> Retrieve(
        string typeID,
        EntityTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TypeID = typeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntityTypeUpdateResponse> Update(
        EntityTypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityTypeUpdateResponse> Update(
        string typeID,
        EntityTypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { TypeID = typeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntityTypeListResponse> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        EntityTypeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string typeID,
        EntityTypeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { TypeID = typeID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EntityTypeServiceWithRawResponse : IEntityTypeServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEntityTypeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EntityTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EntityTypeServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;

        _reviewers = new(() => new ReviewerServiceWithRawResponse(client));
    }

    readonly Lazy<IReviewerServiceWithRawResponse> _reviewers;
    public IReviewerServiceWithRawResponse Reviewers
    {
        get { return _reviewers.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityTypeCreateResponse>> Create(
        EntityTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EntityTypeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityType = await response
                    .Deserialize<EntityTypeCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityType.Validate();
                }
                return entityType;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityTypeRetrieveResponse>> Retrieve(
        EntityTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TypeID == null)
        {
            throw new BemInvalidDataException("'parameters.TypeID' cannot be null");
        }

        HttpRequest<EntityTypeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityType = await response
                    .Deserialize<EntityTypeRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityType.Validate();
                }
                return entityType;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntityTypeRetrieveResponse>> Retrieve(
        string typeID,
        EntityTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TypeID = typeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityTypeUpdateResponse>> Update(
        EntityTypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TypeID == null)
        {
            throw new BemInvalidDataException("'parameters.TypeID' cannot be null");
        }

        HttpRequest<EntityTypeUpdateParams> request = new()
        {
            Method = BemClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityType = await response
                    .Deserialize<EntityTypeUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityType.Validate();
                }
                return entityType;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntityTypeUpdateResponse>> Update(
        string typeID,
        EntityTypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { TypeID = typeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityTypeListResponse>> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EntityTypeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityTypes = await response
                    .Deserialize<EntityTypeListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityTypes.Validate();
                }
                return entityTypes;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EntityTypeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TypeID == null)
        {
            throw new BemInvalidDataException("'parameters.TypeID' cannot be null");
        }

        HttpRequest<EntityTypeDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string typeID,
        EntityTypeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { TypeID = typeID }, cancellationToken);
    }
}
