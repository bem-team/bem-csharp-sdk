using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Outputs;

namespace Bem.Services;

/// <summary>
/// Retrieve terminal non-error output events from workflow calls.
///
/// <para>Outputs are events produced by successful terminal function steps — steps
/// that completed without errors and did not spawn further downstream function calls.
/// A single workflow call may produce multiple outputs (e.g. from a split-then-transform pipeline).</para>
///
/// <para>Outputs and errors from the same call are not mutually exclusive: a partially-completed
/// workflow may have both.</para>
///
/// <para>Use `GET /v3/outputs` to list outputs across calls, or `GET /v3/outputs/{eventID}`
/// to retrieve a specific output. To get outputs scoped to a single call, filter
/// by `callIDs`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IOutputService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOutputServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOutputService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Retrieve a single output event by ID.**
    ///
    /// <para>Fetches any non-error event by its `eventID`. Returns `404` if the event
    /// does not exist or if it is an error event (use `GET /v3/errors/{eventID}` for
    /// those).</para>
    /// </summary>
    Task<OutputRetrieveResponse> Retrieve(
        OutputRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OutputRetrieveParams, CancellationToken)"/>
    Task<OutputRetrieveResponse> Retrieve(
        string eventID,
        OutputRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **List terminal non-error output events.**
    ///
    /// <para>Returns events that represent successful terminal outputs — primary events
    /// (non-split-collection) that did not trigger any downstream function calls. Error
    /// events are excluded; use `GET /v3/errors` to retrieve those.</para>
    ///
    /// <para>## Intermediate Events</para>
    ///
    /// <para>By default, intermediate events (those that spawned a downstream function
    /// call in a multi-step workflow) are excluded. Pass `includeIntermediate=true` to
    /// include them.</para>
    ///
    /// <para>## Filtering</para>
    ///
    /// <para>Filter by call, workflow, function, or reference ID. Multiple filters are
    /// ANDed together.</para>
    /// </summary>
    Task<OutputListPage> List(
        OutputListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOutputService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOutputServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOutputServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/outputs/{eventID}</c>, but is otherwise the
    /// same as <see cref="IOutputService.Retrieve(OutputRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OutputRetrieveResponse>> Retrieve(
        OutputRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OutputRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OutputRetrieveResponse>> Retrieve(
        string eventID,
        OutputRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/outputs</c>, but is otherwise the
    /// same as <see cref="IOutputService.List(OutputListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OutputListPage>> List(
        OutputListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
