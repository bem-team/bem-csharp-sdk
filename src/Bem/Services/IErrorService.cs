using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Errors;

namespace Bem.Services;

/// <summary>
/// Retrieve terminal error events from workflow calls.
///
/// <para>Errors are events produced by function steps that failed during processing.
/// A single workflow call may produce multiple error events if several steps fail independently.</para>
///
/// <para>Errors and outputs from the same call are not mutually exclusive: a partially-completed
/// workflow may have both.</para>
///
/// <para>Use `GET /v3/errors` to list errors across calls, or `GET /v3/errors/{eventID}`
/// to retrieve a specific error. To get errors scoped to a single call, filter by `callIDs`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IErrorService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IErrorServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IErrorService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Retrieve a single error event by ID.**
    ///
    /// <para>Returns `404` if the event does not exist or if it is not an error event
    /// (use `GET /v3/outputs/{eventID}` for non-error events).</para>
    /// </summary>
    Task<ErrorRetrieveResponse> Retrieve(
        ErrorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ErrorRetrieveParams, CancellationToken)"/>
    Task<ErrorRetrieveResponse> Retrieve(
        string eventID,
        ErrorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **List terminal error events.**
    ///
    /// <para>Returns error events produced by failed function calls within workflow
    /// executions. Non-error output events are excluded; use `GET /v3/outputs` to
    /// retrieve those.</para>
    ///
    /// <para>## Filtering</para>
    ///
    /// <para>Filter by call, workflow, function, or reference ID. Multiple filters are
    /// ANDed together.</para>
    /// </summary>
    Task<ErrorListPage> List(
        ErrorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IErrorService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IErrorServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IErrorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/errors/{eventID}</c>, but is otherwise the
    /// same as <see cref="IErrorService.Retrieve(ErrorRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ErrorRetrieveResponse>> Retrieve(
        ErrorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ErrorRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ErrorRetrieveResponse>> Retrieve(
        string eventID,
        ErrorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/errors</c>, but is otherwise the
    /// same as <see cref="IErrorService.List(ErrorListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ErrorListPage>> List(
        ErrorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
