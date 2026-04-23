using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Collections;
using Bem.Services.Collections;

namespace Bem.Services;

/// <summary>
/// Collections are named groups of embedded items used by Enrich functions for semantic search.
///
/// <para>Each collection is referenced by a `collectionName`, which supports dot
/// notation for hierarchical paths (e.g. `customers.premium.vip`). Names must contain
/// only letters, digits, underscores, and dots, and each segment must start with
/// a letter or underscore.</para>
///
/// <para>## Items</para>
///
/// <para>Items carry either a string or a JSON object in their `data` field. When
/// items are added or updated, their `data` is embedded asynchronously — `POST /v3/collections/items`
/// and `PUT /v3/collections/items` return immediately with a `pending` status and
/// an `eventID` that can be correlated with webhook notifications once processing completes.</para>
///
/// <para>## Listing and hierarchy</para>
///
/// <para>Use `GET /v3/collections` with `parentCollectionName` to list collections
/// under a path, or `collectionNameSearch` for a case-insensitive substring match.
/// `GET /v3/collections/items` retrieves a specific collection's items; pass `includeSubcollections=true`
/// to fold in items from all descendant collections.</para>
///
/// <para>## Token counting</para>
///
/// <para>Use `POST /v3/collections/token-count` to check whether texts fit within
/// the embedding model's 8,192-token-per-text limit before submitting them for embedding.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICollectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICollectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICollectionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemService Items { get; }

    /// <summary>
    /// Create a Collection
    /// </summary>
    Task<CollectionCreateResponse> Create(
        CollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Collections
    /// </summary>
    Task<CollectionListResponse> List(
        CollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Collection
    /// </summary>
    Task Delete(CollectionDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Count the number of tokens in the provided texts using the BGE M3 tokenizer.
    /// This is useful for checking if texts will fit within the embedding model's token
    /// limit (8,192 tokens per text) before sending them for embedding.
    /// </summary>
    Task<CollectionCountTokensResponse> CountTokens(
        CollectionCountTokensParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICollectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICollectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICollectionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemServiceWithRawResponse Items { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/collections</c>, but is otherwise the
    /// same as <see cref="ICollectionService.Create(CollectionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CollectionCreateResponse>> Create(
        CollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/collections</c>, but is otherwise the
    /// same as <see cref="ICollectionService.List(CollectionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CollectionListResponse>> List(
        CollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/collections</c>, but is otherwise the
    /// same as <see cref="ICollectionService.Delete(CollectionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/collections/token-count</c>, but is otherwise the
    /// same as <see cref="ICollectionService.CountTokens(CollectionCountTokensParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CollectionCountTokensResponse>> CountTokens(
        CollectionCountTokensParams parameters,
        CancellationToken cancellationToken = default
    );
}
