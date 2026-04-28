using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Functions;
using Bem.Services.Functions;

namespace Bem.Services;

/// <summary>
/// Functions are the core building blocks of data transformation in Bem. Each function
/// type serves a specific purpose:
///
/// <para>- **Extract**: Extract structured JSON data from unstructured documents
/// (PDFs, emails, images, spreadsheets), with optional layout-aware bounding-box
/// extraction - **Route**: Direct data to different processing paths based on conditions
/// - **Split**: Break multi-page documents into individual pages for parallel processing
/// - **Join**: Combine outputs from multiple function calls into a single result
/// - **Payload Shaping**: Transform and restructure data using JMESPath expressions
/// - **Enrich**: Enhance data with semantic search against collections - **Send**:
/// Deliver workflow outputs to downstream destinations</para>
///
/// <para>Use these endpoints to create, update, list, and manage your functions.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFunctionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFunctionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFunctionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICopyService Copy { get; }

    IVersionService Versions { get; }

    /// <summary>
    /// **Create a function.**
    ///
    /// <para>The function type (`extract`, `classify`, `split`, `join`, `enrich`, or
    /// `payload_shaping`) determines which configuration fields are required — see
    /// [Function types overview](/guide/function-types/overview) for the per-type
    /// contract.</para>
    ///
    /// <para>The response contains both `functionID` and `functionName`. Either is a
    /// stable handle you can use elsewhere; most workflows reference functions by
    /// `functionName` because it's human-readable.</para>
    ///
    /// <para>## Naming rules</para>
    ///
    /// <para>- `functionName` must be unique per environment. - Allowed characters:
    /// letters, digits, hyphens, and underscores. - Names cannot be reused after
    /// deletion within the same environment for at least the retention window of the
    /// previous record.</para>
    ///
    /// <para>The new function is created at `versionNum: 1`. Subsequent `PATCH
    /// /v3/functions/{functionName}` calls produce new versions — the version-1
    /// configuration remains immutable and addressable.</para>
    /// </summary>
    Task<FunctionResponse> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Retrieve a function's current version by name.**
    ///
    /// <para>Returns the function record with its `currentVersionNum` and the
    /// configuration of that version. To inspect a historical version, use `GET
    /// /v3/functions/{functionName}/versions/{versionNum}`.</para>
    /// </summary>
    Task<FunctionResponse> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FunctionRetrieveParams, CancellationToken)"/>
    Task<FunctionResponse> Retrieve(
        string functionName,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Update a function. Updates create a new version.**
    ///
    /// <para>The previous version remains addressable and immutable. Workflow nodes
    /// that pinned the function with a `versionNum` continue to use the pinned version;
    /// nodes that reference the function by name with no version automatically pick up
    /// the new version on their next call.</para>
    ///
    /// <para>## What you can change</para>
    ///
    /// <para>Any field allowed by the function's type. Most commonly: `outputSchema`
    /// (for `extract`/`join`), `classifications` (for `classify`), `displayName`, and
    /// `tags`.</para>
    ///
    /// <para>## Versioning behaviour</para>
    ///
    /// <para>- Each successful update increments `currentVersionNum` by 1. -
    /// `displayName`, `tags`, and `functionName` updates also create a new version, so
    /// the version history is a complete record of every change. - To revert, fetch the
    /// previous version and re-submit its configuration as a new update — versions
    /// themselves are immutable.</para>
    /// </summary>
    Task<FunctionResponse> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FunctionUpdateParams, CancellationToken)"/>
    Task<FunctionResponse> Update(
        string pathFunctionName,
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **List functions in the current environment.**
    ///
    /// <para>Returns each function's current version. Combine filters freely — they AND
    /// together.</para>
    ///
    /// <para>## Filtering</para>
    ///
    /// <para>- `functionIDs` / `functionNames`: exact-match identity filters. -
    /// `displayName`: case-insensitive substring match. - `types`: one or more of
    /// `extract`, `classify`, `split`, `join`, `enrich`, `payload_shaping`. Legacy
    /// `transform`, `analyze`, `route`, and `send` types remain readable via this
    /// filter. - `tags`: returns functions tagged with any of the supplied tags. -
    /// `workflowIDs` / `workflowNames`: returns only functions referenced by the named
    /// workflows. Useful for "what functions does this workflow depend on?" lookups.</para>
    ///
    /// <para>## Pagination</para>
    ///
    /// <para>Cursor-based with `startingAfter` and `endingBefore` (functionIDs).
    /// Default limit 50, maximum 100.</para>
    /// </summary>
    Task<FunctionListPage> List(
        FunctionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Delete a function and every one of its versions.**
    ///
    /// <para>Permanent. Running and queued calls that reference this function continue
    /// to completion against the version they captured at call time, but no new calls
    /// can target it.</para>
    ///
    /// <para>## Before deleting</para>
    ///
    /// <para>Workflow nodes that reference this function will fail at call time after
    /// deletion. List workflows that reference it first:</para>
    ///
    /// <para>``` GET /v3/workflows?functionNames=my-function ```</para>
    ///
    /// <para>Update or remove those workflows, or create a replacement function and
    /// re-point the workflow nodes, before deleting.</para>
    /// </summary>
    Task Delete(FunctionDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(FunctionDeleteParams, CancellationToken)"/>
    Task Delete(
        string functionName,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFunctionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFunctionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFunctionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICopyServiceWithRawResponse Copy { get; }

    IVersionServiceWithRawResponse Versions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/functions</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Create(FunctionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionResponse>> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/functions/{functionName}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Retrieve(FunctionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionResponse>> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FunctionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FunctionResponse>> Retrieve(
        string functionName,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/functions/{functionName}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Update(FunctionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionResponse>> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FunctionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FunctionResponse>> Update(
        string pathFunctionName,
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/functions</c>, but is otherwise the
    /// same as <see cref="IFunctionService.List(FunctionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionListPage>> List(
        FunctionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/functions/{functionName}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Delete(FunctionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        FunctionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FunctionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string functionName,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
