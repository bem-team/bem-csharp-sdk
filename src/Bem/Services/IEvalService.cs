using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Eval;
using Bem.Services.Eval;

namespace Bem.Services;

/// <summary>
/// Trigger and retrieve evaluations for completed transformations.
///
/// <para>Evaluations run asynchronously and score each transformation's output against
/// the function's schema for confidence, per-field hallucination detection, and
/// relevance. Evaluations are supported for `extract`, `transform`, `analyze`, and
/// `join` events.</para>
///
/// <para>## Lifecycle</para>
///
/// <para>1. **Trigger** — `POST /v3/eval` queues jobs for a batch of transformation
/// IDs    and returns immediately with `queued` / `skipped` counts plus per-ID errors.
/// 2. **Poll** — `POST /v3/eval/results` (body) or `GET /v3/eval/results` (query)
///    returns the current state of each requested transformation, partitioned
/// into `results` (completed), `pending` (still running), and `failed`    (terminal
/// failures or unknown transformation IDs).</para>
///
/// <para>Up to 100 transformation IDs may be submitted per request.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEvalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEvalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEvalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IResultService Results { get; }

    /// <summary>
    /// **Queue evaluation jobs for a batch of transformations.**
    ///
    /// <para>Evaluations run asynchronously and score each transformation's output
    /// against the function's schema for confidence, hallucination detection, and
    /// relevance. Transformations must belong to events of a supported type: `extract`,
    /// `transform`, `analyze`, or `join`.</para>
    ///
    /// <para>Returns immediately with a summary of queued vs. skipped transformations
    /// and per-transformation errors. Poll `POST /v3/eval/results` or `GET
    /// /v3/eval/results` to retrieve results once evaluations complete.</para>
    /// </summary>
    Task<EvalTriggerEvaluationResponse> TriggerEvaluation(
        EvalTriggerEvaluationParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEvalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEvalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEvalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IResultServiceWithRawResponse Results { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/eval</c>, but is otherwise the
    /// same as <see cref="IEvalService.TriggerEvaluation(EvalTriggerEvaluationParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EvalTriggerEvaluationResponse>> TriggerEvaluation(
        EvalTriggerEvaluationParams parameters,
        CancellationToken cancellationToken = default
    );
}
