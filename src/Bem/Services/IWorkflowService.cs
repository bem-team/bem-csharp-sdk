using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Calls;
using Bem.Models.Workflows;
using Bem.Services.Workflows;

namespace Bem.Services;

/// <summary>
/// Workflow operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWorkflowService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWorkflowServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkflowService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionService Versions { get; }

    /// <summary>
    /// Create a Workflow
    /// </summary>
    Task<WorkflowCreateResponse> Create(
        WorkflowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a Workflow
    /// </summary>
    Task<WorkflowRetrieveResponse> Retrieve(
        WorkflowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkflowRetrieveParams, CancellationToken)"/>
    Task<WorkflowRetrieveResponse> Retrieve(
        string workflowName,
        WorkflowRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Workflow
    /// </summary>
    Task<WorkflowUpdateResponse> Update(
        WorkflowUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WorkflowUpdateParams, CancellationToken)"/>
    Task<WorkflowUpdateResponse> Update(
        string workflowName,
        WorkflowUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Workflows
    /// </summary>
    Task<WorkflowListPage> List(
        WorkflowListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Workflow
    /// </summary>
    Task Delete(WorkflowDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(WorkflowDeleteParams, CancellationToken)"/>
    Task Delete(
        string workflowName,
        WorkflowDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Invoke a workflow by submitting a multipart form request.**
    ///
    /// <para>Workflows can only be called via multipart form in V3. Submit the input
    /// file along with an optional reference ID for tracking.</para>
    ///
    /// <para>## Synchronous vs Asynchronous</para>
    ///
    /// <para>By default the call is created asynchronously and this endpoint returns
    /// `202 Accepted` immediately with a `pending` call object. Set the `wait` field to
    /// `true` to block until the call completes (up to 30 seconds):</para>
    ///
    /// <para>- On success: returns `200 OK` with the completed call, `outputs`
    /// populated - On failure: returns `500 Internal Server Error` with the call and an
    /// `error` message - On timeout: returns `202 Accepted` with the still-running call</para>
    ///
    /// <para>## Tracking</para>
    ///
    /// <para>Poll `GET /v3/calls/{callID}` to check status, or configure a webhook
    /// subscription to receive events when the call finishes.</para>
    /// </summary>
    Task<CallGetResponse> Call(
        WorkflowCallParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Call(WorkflowCallParams, CancellationToken)"/>
    Task<CallGetResponse> Call(
        string workflowName,
        WorkflowCallParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Copy a Workflow
    /// </summary>
    Task<WorkflowCopyResponse> Copy(
        WorkflowCopyParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWorkflowService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWorkflowServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkflowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionServiceWithRawResponse Versions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/workflows</c>, but is otherwise the
    /// same as <see cref="IWorkflowService.Create(WorkflowCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkflowCreateResponse>> Create(
        WorkflowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/workflows/{workflowName}</c>, but is otherwise the
    /// same as <see cref="IWorkflowService.Retrieve(WorkflowRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkflowRetrieveResponse>> Retrieve(
        WorkflowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkflowRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WorkflowRetrieveResponse>> Retrieve(
        string workflowName,
        WorkflowRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/workflows/{workflowName}</c>, but is otherwise the
    /// same as <see cref="IWorkflowService.Update(WorkflowUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkflowUpdateResponse>> Update(
        WorkflowUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WorkflowUpdateParams, CancellationToken)"/>
    Task<HttpResponse<WorkflowUpdateResponse>> Update(
        string workflowName,
        WorkflowUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/workflows</c>, but is otherwise the
    /// same as <see cref="IWorkflowService.List(WorkflowListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkflowListPage>> List(
        WorkflowListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/workflows/{workflowName}</c>, but is otherwise the
    /// same as <see cref="IWorkflowService.Delete(WorkflowDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        WorkflowDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WorkflowDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string workflowName,
        WorkflowDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/workflows/{workflowName}/call</c>, but is otherwise the
    /// same as <see cref="IWorkflowService.Call(WorkflowCallParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CallGetResponse>> Call(
        WorkflowCallParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Call(WorkflowCallParams, CancellationToken)"/>
    Task<HttpResponse<CallGetResponse>> Call(
        string workflowName,
        WorkflowCallParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/workflows/copy</c>, but is otherwise the
    /// same as <see cref="IWorkflowService.Copy(WorkflowCopyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkflowCopyResponse>> Copy(
        WorkflowCopyParams parameters,
        CancellationToken cancellationToken = default
    );
}
