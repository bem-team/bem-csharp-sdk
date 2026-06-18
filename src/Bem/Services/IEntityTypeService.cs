using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.EntityTypes;
using Bem.Services.EntityTypes;

namespace Bem.Services;

/// <summary>
/// Entity Types are the customer-defined taxonomy for the knowledge graph, scoped
/// to an account+environment. Each type has a unique, immutable name and can be
/// organised into hierarchies via `parentTypeID`. A type may carry per-type structured
/// attribute metadata in `attributeSchema` (for example `{"unit": "mg", "range":
/// [0, 100]}`).
///
/// <para>Use these endpoints to create, list, fetch, update, and delete entity types:</para>
///
/// <para>- **`POST /v3/entity-types`** creates a type, optionally under a parent.
/// - **`GET /v3/entity-types`** lists types with cursor pagination   (`startingAfter`
/// / `endingBefore` over `typeID`) and an optional   `parentTypeId` filter for direct
/// children. - **`PATCH /v3/entity-types/{typeID}`** updates `description`,   `parentTypeID`,
/// and/or `attributeSchema`. The `name` is immutable. - **`DELETE /v3/entity-types/{typeID}`**
/// soft-deletes a type. The request   is rejected with `409 Conflict` while any
/// live entity is assigned to   the type or any live child type points at it.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEntityTypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEntityTypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IReviewerService Reviewers { get; }

    /// <summary>
    /// Create an Entity Type
    /// </summary>
    Task<EntityTypeCreateResponse> Create(
        EntityTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an Entity Type
    /// </summary>
    Task<EntityTypeRetrieveResponse> Retrieve(
        EntityTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntityTypeRetrieveParams, CancellationToken)"/>
    Task<EntityTypeRetrieveResponse> Retrieve(
        string typeID,
        EntityTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an Entity Type
    /// </summary>
    Task<EntityTypeUpdateResponse> Update(
        EntityTypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntityTypeUpdateParams, CancellationToken)"/>
    Task<EntityTypeUpdateResponse> Update(
        string typeID,
        EntityTypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Entity Types
    /// </summary>
    Task<EntityTypeListResponse> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an Entity Type
    /// </summary>
    Task Delete(EntityTypeDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(EntityTypeDeleteParams, CancellationToken)"/>
    Task Delete(
        string typeID,
        EntityTypeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEntityTypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEntityTypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IReviewerServiceWithRawResponse Reviewers { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/entity-types</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.Create(EntityTypeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeCreateResponse>> Create(
        EntityTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/entity-types/{typeID}</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.Retrieve(EntityTypeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeRetrieveResponse>> Retrieve(
        EntityTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntityTypeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EntityTypeRetrieveResponse>> Retrieve(
        string typeID,
        EntityTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/entity-types/{typeID}</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.Update(EntityTypeUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeUpdateResponse>> Update(
        EntityTypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntityTypeUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EntityTypeUpdateResponse>> Update(
        string typeID,
        EntityTypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/entity-types</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.List(EntityTypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeListResponse>> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/entity-types/{typeID}</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.Delete(EntityTypeDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        EntityTypeDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EntityTypeDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string typeID,
        EntityTypeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
