using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.EntityTypes.Reviewers;

namespace Bem.Services.EntityTypes;

/// <summary>
/// Reviewer assignments link users to the entity types they are responsible for
/// reviewing, scoped to an account+environment. These are dashboard-only endpoints:
/// an assignment needs a user identity, which only the dashboard (JWT) surface carries.
///
/// <para>- **`POST /v3/entity-types/{typeID}/reviewers`** assigns a user as a
/// reviewer of the type. The assignment is idempotent: re-assigning an   existing
/// reviewer returns the existing assignment. Requires the `admin`   role. - **`GET
/// /v3/entity-types/{typeID}/reviewers`** lists the users assigned   to review the
/// type, with each user's email and role. Requires the   `operator` role. - **`DELETE
/// /v3/entity-types/{typeID}/reviewers/{userID}`** removes an   assignment. Requires
/// the `admin` role. - **`GET /v3/users/{userID}/reviewer-assignments`** is the
/// reverse lookup:   the entity types a user reviews. A user may read their own
/// assignments;   reading another user's assignments requires the `admin` role.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IReviewerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReviewerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List Reviewers
    /// </summary>
    Task<ReviewerListResponse> List(
        ReviewerListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ReviewerListParams, CancellationToken)"/>
    Task<ReviewerListResponse> List(
        string typeID,
        ReviewerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign a Reviewer
    /// </summary>
    Task<Reviewer> Assign(
        ReviewerAssignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Assign(ReviewerAssignParams, CancellationToken)"/>
    Task<Reviewer> Assign(
        string typeID,
        ReviewerAssignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a Reviewer
    /// </summary>
    Task Remove(ReviewerRemoveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Remove(ReviewerRemoveParams, CancellationToken)"/>
    Task Remove(
        string userID,
        ReviewerRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IReviewerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReviewerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/entity-types/{typeID}/reviewers</c>, but is otherwise the
    /// same as <see cref="IReviewerService.List(ReviewerListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReviewerListResponse>> List(
        ReviewerListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ReviewerListParams, CancellationToken)"/>
    Task<HttpResponse<ReviewerListResponse>> List(
        string typeID,
        ReviewerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/entity-types/{typeID}/reviewers</c>, but is otherwise the
    /// same as <see cref="IReviewerService.Assign(ReviewerAssignParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Reviewer>> Assign(
        ReviewerAssignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Assign(ReviewerAssignParams, CancellationToken)"/>
    Task<HttpResponse<Reviewer>> Assign(
        string typeID,
        ReviewerAssignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/entity-types/{typeID}/reviewers/{userID}</c>, but is otherwise the
    /// same as <see cref="IReviewerService.Remove(ReviewerRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        ReviewerRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(ReviewerRemoveParams, CancellationToken)"/>
    Task<HttpResponse> Remove(
        string userID,
        ReviewerRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
