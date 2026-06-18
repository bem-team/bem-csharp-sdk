using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Entities.Synonyms;

namespace Bem.Services.Entities;

/// <summary>
/// Manage the human-readable surface forms (synonyms) attached to a canonical entity.
/// Synonyms feed the matcher's exact-match path, so adding the right synonyms improves
/// cross-document entity resolution.
///
/// <para>- **`POST /v3/entities/{id}/synonyms`** attaches a `customer_defined`
///  synonym. If the same normalized form already exists as an `extracted`   synonym,
/// it is upgraded to `customer_defined` (so the matcher weights it   higher); an
/// existing customer/SME synonym is returned unchanged. - **`DELETE /v3/entities/{id}/synonyms/{synonymID}`**
/// soft-deletes a   synonym. Only `customer_defined` and `sme_approved` synonyms
/// are   deletable; `extracted` synonyms are resolver-owned and the request is
/// rejected with `409 Conflict`.</para>
///
/// <para>A merged-away entity id transparently resolves to its surviving canonical
/// entity, so a synonym added to a stale id lands on the entity that persists.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISynonymService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISynonymServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISynonymService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a Synonym to an Entity
    /// </summary>
    Task<SynonymAddResponse> Add(
        SynonymAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(SynonymAddParams, CancellationToken)"/>
    Task<SynonymAddResponse> Add(
        string id,
        SynonymAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a Synonym from an Entity
    /// </summary>
    Task Remove(SynonymRemoveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Remove(SynonymRemoveParams, CancellationToken)"/>
    Task Remove(
        string synonymID,
        SynonymRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISynonymService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISynonymServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISynonymServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/entities/{id}/synonyms</c>, but is otherwise the
    /// same as <see cref="ISynonymService.Add(SynonymAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SynonymAddResponse>> Add(
        SynonymAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(SynonymAddParams, CancellationToken)"/>
    Task<HttpResponse<SynonymAddResponse>> Add(
        string id,
        SynonymAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/entities/{id}/synonyms/{synonymID}</c>, but is otherwise the
    /// same as <see cref="ISynonymService.Remove(SynonymRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        SynonymRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(SynonymRemoveParams, CancellationToken)"/>
    Task<HttpResponse> Remove(
        string synonymID,
        SynonymRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
