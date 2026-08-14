using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.KnowledgeGraph;

namespace Bem.Services;

/// <summary>
/// Read the cross-document knowledge graph — the canonical entities and the directed
/// relations between them that the Parse pipeline populates when `linkAcrossDocuments`
/// is enabled.
///
/// <para>- **`GET /v3/entities/{id}/relations`** returns the inbound and outbound
///   edges incident to one entity, split by direction. Supports   `direction`, an
/// exact `relationType` filter, and cursor pagination over   edges. A merged-away
/// entity id transparently resolves to its surviving   canonical entity. - **`GET
/// /v3/knowledge-graph`** returns the graph as `{ nodes, edges }`,   paginating
/// over edges. The `nodes` for a page are the distinct endpoint   entities of that
/// page's edges (both endpoints of every edge are   included). Filter with `type[]`,
/// `since`, and `search`; an edge is   returned only when both of its endpoints survive
/// the entity filters.</para>
///
/// <para>Both endpoints take an optional `bucket` (`bkt_...`) to scope the read to
/// a single bucket; omit it for the unscoped account+environment view.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IKnowledgeGraphService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IKnowledgeGraphServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKnowledgeGraphService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve the Knowledge Graph
    /// </summary>
    Task<KnowledgeGraphRetrieveResponse> Retrieve(
        KnowledgeGraphRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IKnowledgeGraphService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IKnowledgeGraphServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKnowledgeGraphServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/knowledge-graph</c>, but is otherwise the
    /// same as <see cref="IKnowledgeGraphService.Retrieve(KnowledgeGraphRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KnowledgeGraphRetrieveResponse>> Retrieve(
        KnowledgeGraphRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
