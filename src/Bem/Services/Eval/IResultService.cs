using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Eval.Results;

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
public interface IResultService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IResultServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IResultService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Fetch evaluation results for a batch of events.**
    ///
    /// <para>Pass either `eventIDs` (preferred — the externally-stable V3 identifier)
    /// or `transformationIDs` as a comma-separated query parameter. Exactly one of the
    /// two must be provided. Up to 100 IDs per request.</para>
    ///
    /// <para>For each requested ID the response reports one of three states: a
    /// completed `result`, still-`pending`, or `failed`. Results, pending, and failed
    /// entries are all keyed by event KSUID regardless of which input form was used.</para>
    /// </summary>
    Task<EvaluationResults> RetrieveResults(
        ResultRetrieveResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IResultService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IResultServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IResultServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/eval/results</c>, but is otherwise the
    /// same as <see cref="IResultService.RetrieveResults(ResultRetrieveResultsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EvaluationResults>> RetrieveResults(
        ResultRetrieveResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
