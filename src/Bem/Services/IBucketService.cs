using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Buckets;

namespace Bem.Services;

/// <summary>
/// Buckets are named partitions of the knowledge graph within an account+environment.
/// Entities, mentions, and relations are scoped to a bucket so a single account+environment
/// can host multiple isolated graphs — for example one per data source or workspace.
///
/// <para>Every account+environment has exactly one **default** bucket, used by unscoped
/// flows. The default bucket can be renamed but never deleted.</para>
///
/// <para>Use these endpoints to create, list, fetch, rename, and delete buckets:</para>
///
/// <para>- **`POST /v3/buckets`** creates a non-default bucket. - **`GET /v3/buckets`**
/// lists buckets with cursor pagination   (`startingAfter` / `endingBefore` over
/// `bucketID`). - **`PATCH /v3/buckets/{bucketID}`** updates `name` and/or `description`.
/// - **`DELETE /v3/buckets/{bucketID}`** soft-deletes a bucket. A non-empty   bucket
/// is rejected with `409 Conflict` unless `?cascade=true` is   passed; the default
/// bucket can never be deleted.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBucketService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBucketServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBucketService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Bucket
    /// </summary>
    Task<BucketV3> Create(
        BucketCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a Bucket
    /// </summary>
    Task<BucketV3> Retrieve(
        BucketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BucketRetrieveParams, CancellationToken)"/>
    Task<BucketV3> Retrieve(
        string bucketID,
        BucketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Bucket
    /// </summary>
    Task<BucketV3> Update(
        BucketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BucketUpdateParams, CancellationToken)"/>
    Task<BucketV3> Update(
        string bucketID,
        BucketUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Buckets
    /// </summary>
    Task<BucketListResponse> List(
        BucketListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Bucket
    /// </summary>
    Task Delete(BucketDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(BucketDeleteParams, CancellationToken)"/>
    Task Delete(
        string bucketID,
        BucketDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBucketService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBucketServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBucketServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/buckets</c>, but is otherwise the
    /// same as <see cref="IBucketService.Create(BucketCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BucketV3>> Create(
        BucketCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/buckets/{bucketID}</c>, but is otherwise the
    /// same as <see cref="IBucketService.Retrieve(BucketRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BucketV3>> Retrieve(
        BucketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BucketRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BucketV3>> Retrieve(
        string bucketID,
        BucketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/buckets/{bucketID}</c>, but is otherwise the
    /// same as <see cref="IBucketService.Update(BucketUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BucketV3>> Update(
        BucketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BucketUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BucketV3>> Update(
        string bucketID,
        BucketUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/buckets</c>, but is otherwise the
    /// same as <see cref="IBucketService.List(BucketListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BucketListResponse>> List(
        BucketListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/buckets/{bucketID}</c>, but is otherwise the
    /// same as <see cref="IBucketService.Delete(BucketDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        BucketDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BucketDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string bucketID,
        BucketDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
