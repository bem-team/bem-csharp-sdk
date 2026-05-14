using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Eval;
using Bem.Services.Eval;

namespace Bem.Services;

/// <summary>
/// Monitor, evaluate, and iterate on the quality of every function in your environment.
/// Function Accuracy bundles two complementary loops:
///
/// <para>## Evaluations (`/v3/eval`)</para>
///
/// <para>Trigger and retrieve per-transformation evaluations. Evaluations run asynchronously
/// and score each transformation's output against the function's schema for confidence,
/// per-field hallucination detection, and relevance. Supported for `extract`, `transform`,
/// `analyze`, and `join` events.</para>
///
/// <para>1. **Trigger** — `POST /v3/eval` queues jobs for a batch of transformation
/// IDs. 2. **Poll** — `GET /v3/eval/results` returns the current state of each
///   requested ID, partitioned into `results`, `pending`, and `failed`.    Accepts
/// either `eventIDs` (preferred) or `transformationIDs` as a    comma-separated query
/// parameter, and always keys the response by    event KSUID.</para>
///
/// <para>Up to 100 IDs may be submitted per request.</para>
///
/// <para>## Metrics, review, regression (`/v3/functions/{metrics,review,regression,compare}`)</para>
///
/// <para>Roll evaluation results and user corrections up into actionable function-level signal:</para>
///
/// <para>- **`GET /v3/functions/metrics`** — aggregate accuracy, precision,   recall,
/// F1, and confusion-matrix counts per function. - **`POST /v3/functions/review`**
/// — sample-size estimation,   confidence-bucketed distribution, PR-AUC, and per-threshold
///   confidence intervals (Wald or Wilson) for picking review cutoffs. - **`POST
/// /v3/functions/regression`** — replay corrected historical   inputs against a
/// new function version, producing a labeled   regression dataset. - **`POST /v3/functions/regression/corrections`**
/// — propagate   baseline corrections onto the regression dataset so it can be
/// scored. - **`POST /v3/functions/compare`** — compute aggregate and   field-level
/// lift between any two versions, optionally scoped to   the regression dataset.</para>
///
/// <para>All five endpoints support `extract` end-to-end on both the vision and OCR
/// paths, alongside the legacy `transform` / `analyze` / `join` types.</para>
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
    /// and per-transformation errors. Poll `GET /v3/eval/results` to retrieve results
    /// once evaluations complete.</para>
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
