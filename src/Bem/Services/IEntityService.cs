using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Entities;
using Bem.Services.Entities;

namespace Bem.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEntityService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEntityServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISynonymService Synonyms { get; }

    /// <summary>
    /// Update Entity
    /// </summary>
    Task<EntityUpdateResponse> Update(
        EntityUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntityUpdateParams, CancellationToken)"/>
    Task<EntityUpdateResponse> Update(
        string id,
        EntityUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Bulk Seed Entities
    /// </summary>
    Task<EntityBulkCreateResponse> BulkCreate(
        EntityBulkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Bulk Validate Entities
    /// </summary>
    Task<EntityBulkValidateResponse> BulkValidate(
        EntityBulkValidateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an Entity's Relations
    /// </summary>
    Task<EntityRetrieveRelationsResponse> RetrieveRelations(
        EntityRetrieveRelationsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveRelations(EntityRetrieveRelationsParams, CancellationToken)"/>
    Task<EntityRetrieveRelationsResponse> RetrieveRelations(
        string id,
        EntityRetrieveRelationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Seed Job Status
    /// </summary>
    Task<EntityRetrieveSeedStatusResponse> RetrieveSeedStatus(
        EntityRetrieveSeedStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveSeedStatus(EntityRetrieveSeedStatusParams, CancellationToken)"/>
    Task<EntityRetrieveSeedStatusResponse> RetrieveSeedStatus(
        string id,
        EntityRetrieveSeedStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEntityService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEntityServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISynonymServiceWithRawResponse Synonyms { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/entities/{id}</c>, but is otherwise the
    /// same as <see cref="IEntityService.Update(EntityUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityUpdateResponse>> Update(
        EntityUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntityUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EntityUpdateResponse>> Update(
        string id,
        EntityUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/entities/bulk</c>, but is otherwise the
    /// same as <see cref="IEntityService.BulkCreate(EntityBulkCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityBulkCreateResponse>> BulkCreate(
        EntityBulkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/entities/bulk-validate</c>, but is otherwise the
    /// same as <see cref="IEntityService.BulkValidate(EntityBulkValidateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityBulkValidateResponse>> BulkValidate(
        EntityBulkValidateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/entities/{id}/relations</c>, but is otherwise the
    /// same as <see cref="IEntityService.RetrieveRelations(EntityRetrieveRelationsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityRetrieveRelationsResponse>> RetrieveRelations(
        EntityRetrieveRelationsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveRelations(EntityRetrieveRelationsParams, CancellationToken)"/>
    Task<HttpResponse<EntityRetrieveRelationsResponse>> RetrieveRelations(
        string id,
        EntityRetrieveRelationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/entities/seed/{id}</c>, but is otherwise the
    /// same as <see cref="IEntityService.RetrieveSeedStatus(EntityRetrieveSeedStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityRetrieveSeedStatusResponse>> RetrieveSeedStatus(
        EntityRetrieveSeedStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveSeedStatus(EntityRetrieveSeedStatusParams, CancellationToken)"/>
    Task<HttpResponse<EntityRetrieveSeedStatusResponse>> RetrieveSeedStatus(
        string id,
        EntityRetrieveSeedStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
