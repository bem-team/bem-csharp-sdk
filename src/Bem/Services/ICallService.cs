using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Calls;

namespace Bem.Services;

/// <summary>
/// The Calls API provides a unified interface for invoking both **Workflows** and **Functions**.
///
/// <para>Use this API when you want to: - Execute a complete workflow that chains
/// multiple functions together - Call a single function directly without defining
/// a workflow - Submit batch requests with multiple inputs in a single API call -
/// Track execution status using call reference IDs</para>
///
/// <para>**Key Difference**: Calls vs Function Calls - **Calls API** (`/v3/calls`):
/// High-level API for invoking workflows or functions by name/ID. Supports batch
/// processing and workflow orchestration. - **Function Calls API** (`/v3/functions/{functionName}/call`):
/// Direct function invocation with function-type-specific arguments. Better for
/// granular control over individual function calls.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICallService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Retrieve a workflow call by ID.**
    ///
    /// <para>Returns the full call object including status, workflow details, terminal
    /// outputs, and terminal errors. `outputs` and `errors` are both populated once the
    /// call finishes — they are not mutually exclusive (a partially-completed workflow
    /// may have both).</para>
    ///
    /// <para>## Status</para>
    ///
    /// <para>| Status | Description | |--------|-------------| | `pending` | Queued,
    /// not yet started | | `running` | Currently executing | | `completed` | All
    /// enclosed function calls finished without errors | | `failed` | One or more
    /// enclosed function calls produced an error event |</para>
    ///
    /// <para>Poll this endpoint or configure a webhook subscription to detect
    /// completion.</para>
    /// </summary>
    Task<CallGetResponse> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<CallGetResponse> Retrieve(
        string callID,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **List workflow calls with filtering and pagination.**
    ///
    /// <para>Returns calls created via `POST /v3/workflows/{workflowName}/call`.</para>
    ///
    /// <para>## Filtering</para>
    ///
    /// <para>- `callIDs`: Specific call identifiers - `referenceIDs`: Your custom
    /// reference IDs - `workflowIDs` / `workflowNames`: Filter by workflow</para>
    ///
    /// <para>## Pagination</para>
    ///
    /// <para>Use `startingAfter` and `endingBefore` cursors with a default limit of 50.</para>
    /// </summary>
    Task<CallListPage> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICallService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/calls/{callID}</c>, but is otherwise the
    /// same as <see cref="ICallService.Retrieve(CallRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CallGetResponse>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CallGetResponse>> Retrieve(
        string callID,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/calls</c>, but is otherwise the
    /// same as <see cref="ICallService.List(CallListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CallListPage>> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
