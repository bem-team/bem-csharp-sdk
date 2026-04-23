using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Events;

namespace Bem.Services;

/// <summary>
/// Submit training corrections for `extract`, `classify`, and `join` events.
///
/// <para>Feedback is event-centric — each correction is attached to an event by
/// its `eventID`, and the server resolves the correct underlying storage (extract/join
/// transformations or classify route events) from the event's function type.</para>
///
/// <para>Split and enrich function types do not support feedback.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Submit a correction for an event.**
    ///
    /// <para>Accepts training corrections for `extract`, `classify`, and `join` events.
    /// For extract/join events, `correction` is a JSON object matching the function's
    /// output schema. For classify events, `correction` is a JSON string matching one
    /// of the function version's declared classifications.</para>
    ///
    /// <para>Submitting feedback again for the same event overwrites the previous
    /// correction.</para>
    ///
    /// <para>Unsupported function types (split, enrich) return `400`.</para>
    /// </summary>
    Task<EventSubmitFeedbackResponse> SubmitFeedback(
        EventSubmitFeedbackParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SubmitFeedback(EventSubmitFeedbackParams, CancellationToken)"/>
    Task<EventSubmitFeedbackResponse> SubmitFeedback(
        string eventID,
        EventSubmitFeedbackParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/events/{eventID}/feedback</c>, but is otherwise the
    /// same as <see cref="IEventService.SubmitFeedback(EventSubmitFeedbackParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventSubmitFeedbackResponse>> SubmitFeedback(
        EventSubmitFeedbackParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SubmitFeedback(EventSubmitFeedbackParams, CancellationToken)"/>
    Task<HttpResponse<EventSubmitFeedbackResponse>> SubmitFeedback(
        string eventID,
        EventSubmitFeedbackParams parameters,
        CancellationToken cancellationToken = default
    );
}
