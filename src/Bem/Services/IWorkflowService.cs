using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Calls;
using Bem.Models.Workflows;
using Bem.Services.Workflows;

namespace Bem.Services;

/// <summary>
/// Workflows orchestrate one or more functions into a directed acyclic graph (DAG)
/// for document processing.
///
/// <para>Use these endpoints to create, update, list, and manage workflows, and to
/// invoke them with file input via `POST /v3/workflows/{workflowName}/call`.</para>
///
/// <para>The call endpoint accepts files as either multipart form data or JSON with
/// base64-encoded content. In the Bem CLI, use `@path/to/file` inside JSON values
/// to automatically read and encode files:</para>
///
/// <para>``` bem workflows call --workflow-name my-workflow \   --input.single-file
/// '{"inputContent": "@file.pdf", "inputType": "pdf"}' \   --wait ```</para>
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
    /// **Invoke a workflow.**
    ///
    /// <para>Submit the input file as either a multipart form request or a JSON request
    /// with base64-encoded file content. The workflow name is derived from the URL
    /// path.</para>
    ///
    /// <para>## Input Formats</para>
    ///
    /// <para>- **Multipart form** (`multipart/form-data`): attach the file directly via
    /// the `file` or `files` fields. Set `wait` in the form body to control synchronous
    /// behaviour. - **JSON** (`application/json`): base64-encode the file content and
    /// set it in `input.singleFile.inputContent` or
    /// `input.batchFiles.inputs[*].inputContent`. Pass `wait=true` as a query parameter
    /// to control synchronous behaviour.</para>
    ///
    /// <para>## Synchronous vs Asynchronous</para>
    ///
    /// <para>By default the call is created asynchronously and this endpoint returns
    /// `202 Accepted` immediately with a `pending` call object. Set `wait` to `true` to
    /// block until the call completes (up to 30 seconds):</para>
    ///
    /// <para>- On success: returns `200 OK` with the completed call, `outputs`
    /// populated - On failure: returns `500 Internal Server Error` with the call and an
    /// `error` message - On timeout: returns `202 Accepted` with the still-running call</para>
    ///
    /// <para>## Tracking</para>
    ///
    /// <para>Poll `GET /v3/calls/{callID}` to check status, or configure a webhook
    /// subscription to receive events when the call finishes.</para>
    ///
    /// <para>## CLI Usage</para>
    ///
    /// <para>Use `@path/to/file` inside JSON string values to embed file contents
    /// automatically. Binary files (PDF, images, audio) are base64-encoded; text files
    /// are embedded as strings.</para>
    ///
    /// <para>Single file (synchronous): ```bash bem workflows call \   --workflow-name
    /// my-workflow \   --input.single-file '{"inputContent": "@invoice.pdf",
    /// "inputType": "pdf"}' \   --wait ```</para>
    ///
    /// <para>Single file (asynchronous, returns callID immediately): ```bash bem
    /// workflows call \   --workflow-name my-workflow \   --input.single-file
    /// '{"inputContent": "@invoice.pdf", "inputType": "pdf"}' ```</para>
    ///
    /// <para>Batch files: ```bash bem workflows call \   --workflow-name my-workflow \
    ///   --input.batch-files '{"inputs": [{"inputContent": "@a.pdf", "inputType":
    /// "pdf"}, {"inputContent": "@b.png", "inputType": "png"}]}' ```</para>
    ///
    /// <para>Alternative: pass the full `--input` flag as JSON: ```bash bem workflows
    /// call \   --workflow-name my-workflow \   --input '{"singleFile":
    /// {"inputContent": "@invoice.pdf", "inputType": "pdf"}}' \   --wait ```</para>
    ///
    /// <para>**Important:** `--wait` is a boolean flag. Use `--wait` or `--wait=true`.
    /// Do **not** use `--wait true` (with a space) — the `true` will be parsed as an
    /// unexpected positional argument.</para>
    ///
    /// <para>Supported `inputType` values: csv, docx, email, heic, heif, html, jpeg,
    /// json, m4a, mp3, pdf, png, text, wav, webp, xls, xlsx, xml.</para>
    /// </summary>
    Task<CallGetResponse> Call(
        WorkflowCallParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Call(WorkflowCallParams, CancellationToken)"/>
    Task<CallGetResponse> Call(
        string workflowName,
        WorkflowCallParams parameters,
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
        WorkflowCallParams parameters,
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
