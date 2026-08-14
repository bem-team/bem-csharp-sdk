using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Eval.Score;

namespace Bem.Services.Eval;

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
public interface IScoreService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IScoreServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IScoreService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Score a function against a list of (input, expected) pairs.**
    ///
    /// <para>Submits a batch of `(input, expected)` pairs, runs the named function over
    /// each input, and returns per-pair + aggregate accuracy metrics comparing the
    /// function's actual output to the provided expected JSON.</para>
    ///
    /// <para>Scoring runs asynchronously. The response carries a `scoreRunID`; poll
    /// `GET /v3/eval/score/{scoreRunID}` until `status` is one of `completed`, `error`,
    /// or `cancelled`.</para>
    ///
    /// <para>This request says only *what to extract*. How the output is compared
    /// against the expected value happens on the GET, recomputed from stored JSON each
    /// time.</para>
    /// </summary>
    Task<ScoreCreateResponse> Create(
        ScoreCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Get the status and per-pair results of a score run.**
    ///
    /// <para>The comparison happens here, not in the run: the function's output is
    /// compared against the expected value on every read, under the configuration
    /// supplied below. Re-reading the same run with different settings returns
    /// different metrics and costs nothing — no model calls are repeated.</para>
    ///
    /// <para>Comparison is exact and takes no configuration: a value matches the
    /// expected one or it is a miss. It is still redone on every read, so the numbers
    /// reflect the stored data as it is now.</para>
    ///
    /// <para>Returns `aggregate` once `status` reaches `completed` or `error`.
    /// `perPair` is populated incrementally — each pair's `fieldResults` appears as its
    /// underlying function call terminates.</para>
    /// </summary>
    Task<EvalScoreRun> Retrieve(
        ScoreRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ScoreRetrieveParams, CancellationToken)"/>
    Task<EvalScoreRun> Retrieve(
        string scoreRunID,
        ScoreRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Cancel an in-flight score run.**
    ///
    /// <para>Transitions the run to `cancelled`. Function calls already in flight are
    /// allowed to finish (best-effort cancellation via the job queue); results from
    /// completed pairs may still appear in subsequent GETs.</para>
    /// </summary>
    Task<EvalScoreRun> Cancel(
        ScoreCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ScoreCancelParams, CancellationToken)"/>
    Task<EvalScoreRun> Cancel(
        string scoreRunID,
        ScoreCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IScoreService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IScoreServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IScoreServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/eval/score</c>, but is otherwise the
    /// same as <see cref="IScoreService.Create(ScoreCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ScoreCreateResponse>> Create(
        ScoreCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/eval/score/{scoreRunID}</c>, but is otherwise the
    /// same as <see cref="IScoreService.Retrieve(ScoreRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EvalScoreRun>> Retrieve(
        ScoreRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ScoreRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EvalScoreRun>> Retrieve(
        string scoreRunID,
        ScoreRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/eval/score/{scoreRunID}/cancel</c>, but is otherwise the
    /// same as <see cref="IScoreService.Cancel(ScoreCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EvalScoreRun>> Cancel(
        ScoreCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ScoreCancelParams, CancellationToken)"/>
    Task<HttpResponse<EvalScoreRun>> Cancel(
        string scoreRunID,
        ScoreCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
