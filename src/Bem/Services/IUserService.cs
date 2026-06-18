using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Users;

namespace Bem.Services;

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
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List a User's Reviewer Assignments
    /// </summary>
    Task<UserListReviewerAssignmentsResponse> ListReviewerAssignments(
        UserListReviewerAssignmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListReviewerAssignments(UserListReviewerAssignmentsParams, CancellationToken)"/>
    Task<UserListReviewerAssignmentsResponse> ListReviewerAssignments(
        string userID,
        UserListReviewerAssignmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/users/{userID}/reviewer-assignments</c>, but is otherwise the
    /// same as <see cref="IUserService.ListReviewerAssignments(UserListReviewerAssignmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserListReviewerAssignmentsResponse>> ListReviewerAssignments(
        UserListReviewerAssignmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListReviewerAssignments(UserListReviewerAssignmentsParams, CancellationToken)"/>
    Task<HttpResponse<UserListReviewerAssignmentsResponse>> ListReviewerAssignments(
        string userID,
        UserListReviewerAssignmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
