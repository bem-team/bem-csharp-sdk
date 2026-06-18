using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.ReviewQueue;

namespace Bem.Services;

/// <summary>
/// The reviewer-facing read surface for entity curation, available on the dashboard
/// (JWT) only.
///
/// <para>- **`GET /v3/review-queue`** returns a cursor-paginated set of entities
///   awaiting curation, scoped to your account+environment (and optional   `bucket`).
/// Each row is a full entity plus a small preview (up to 2) of   its first mentions,
/// so a reviewer can triage without opening every   entity.</para>
///
/// <para>Filters AND together. `status` (repeatable) defaults to the pre-terminal
/// states `extracted` + `proposed` when omitted. `type` (repeatable `ety_…` IDs)
/// matches the entity's *effective* type — its assigned type id, or, for entities
/// with no assigned type, its bem-inferred type name. `assignedTo` (`me` or a `usr_…`
/// ID) restricts to entities whose effective type the user reviews. `since` (RFC3339)
/// filters by creation time. Pagination is cursor-based on `entityID` ascending;
/// default limit 50, maximum 200.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IReviewQueueService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReviewQueueServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **List entities awaiting curation, for a human reviewer's queue.**
    ///
    /// <para>Returns a cursor-paginated set of entities scoped to your
    /// account+environment (and optional `bucket`), each carrying a small preview of
    /// its first mentions so a reviewer can triage without opening every entity. All
    /// filters AND together.</para>
    ///
    /// <para>- **`status`** (repeatable) restricts to the given lifecycle states.
    /// Omitting it defaults to the pre-terminal states `extracted` and `proposed`. -
    /// **`type`** (repeatable, `ety_...` IDs) matches the entity's *effective* type: an
    /// entity matches when its assigned type is one of these IDs, or it has no assigned
    /// type and its bem-inferred type name matches one of them. - **`assignedTo`**
    /// (`me` or a `usr_...` ID) restricts to entities whose effective type the given
    /// user reviews. `me` resolves to the calling user. - **`since`** (RFC3339)
    /// restricts to entities created at or after the time.</para>
    ///
    /// <para>Pagination is cursor-based on `entityID` ascending; default limit is 50,
    /// maximum 200.</para>
    /// </summary>
    Task<ReviewQueueListResponse> List(
        ReviewQueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IReviewQueueService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReviewQueueServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewQueueServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/review-queue</c>, but is otherwise the
    /// same as <see cref="IReviewQueueService.List(ReviewQueueListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReviewQueueListResponse>> List(
        ReviewQueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
