using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Collections.Items;

namespace Bem.Services.Collections;

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
public interface IItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a Collection
    /// </summary>
    Task<ItemRetrieveResponse> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing items in a Collection
    /// </summary>
    Task<ItemUpdateResponse> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an item from a Collection
    /// </summary>
    Task Delete(ItemDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new items to a Collection
    /// </summary>
    Task<ItemAddResponse> Add(
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/collections/items</c>, but is otherwise the
    /// same as <see cref="IItemService.Retrieve(ItemRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ItemRetrieveResponse>> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v3/collections/items</c>, but is otherwise the
    /// same as <see cref="IItemService.Update(ItemUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ItemUpdateResponse>> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/collections/items</c>, but is otherwise the
    /// same as <see cref="IItemService.Delete(ItemDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/collections/items</c>, but is otherwise the
    /// same as <see cref="IItemService.Add(ItemAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ItemAddResponse>> Add(
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    );
}
