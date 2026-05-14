using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Functions.Regression;

namespace Bem.Services.Functions;

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
public interface IRegressionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRegressionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegressionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Copy baseline corrections onto regression transformations.**
    ///
    /// <para>Looks up regression transformations created against the comparison version
    /// (`isRegression: true`, `correctedJSON IS NULL`), finds the matching baseline
    /// transformation by `referenceID`, and copies the baseline's `correctedJSON` onto
    /// the regression row via the same code path used by `POST
    /// /v3/events/{eventID}/feedback`. The applied corrections are immediately scored
    /// against the regression output, populating the confusion-matrix metrics used by
    /// `function-review` and `function-version-compare`.</para>
    ///
    /// <para>Works for every function type that produces correctable transformations,
    /// including `extract` on both the vision and OCR paths. (Previously the vision
    /// path silently dropped `is_regression` during the original regression run, so no
    /// rows matched the predicate — that has been fixed.)</para>
    ///
    /// <para>Returns counts plus the list of **event KSUIDs** whose underlying
    /// regression transformation received a correction. Errors (e.g. baseline
    /// transformation missing for a given `referenceID`) are returned per-row in the
    /// `errors` map, keyed by event KSUID, rather than aborting the whole call.</para>
    /// </summary>
    Task<RegressionApplyCorrectionsResponse> ApplyCorrections(
        RegressionApplyCorrectionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Kick off a regression run between two versions of a function.**
    ///
    /// <para>Replays a sample of corrected historical inputs against the comparison
    /// version, producing fresh transformations marked `isRegression: true`. Each new
    /// run returns the workflow `callID`s you can monitor via `GET /v3/calls/{callID}`.</para>
    ///
    /// <para>Supported for every function type that produces correctable
    /// transformations: `extract`, `transform`, `analyze`, `join`. For `extract`
    /// specifically, the regression sample is dispatched through the same OCR vs.
    /// vision path used at original call time (PDF, PNG, JPEG, HEIC, HEIF, WebP go
    /// through the vision worker; everything else goes through OCR → transform).</para>
    ///
    /// <para>The comparison version must share a schema-compatible output shape with
    /// the baseline; structural differences are reported as a 400 with the offending
    /// field-level diffs.</para>
    ///
    /// <para>## Typical flow</para>
    ///
    /// <para>1. `POST /v3/functions/regression` — queues calls, returns `{
    /// originalReferenceID, callID }` per sample. 2. Wait (poll `GET
    /// /v3/calls/{callID}` or subscribe to webhooks). 3. `POST
    /// /v3/functions/regression/corrections` to copy baseline corrections onto the new
    /// regression transformations. 4. `POST /v3/functions/compare` to compare baseline
    /// vs comparison metrics for the regression dataset.</para>
    /// </summary>
    Task<RegressionRunResponse> Run(
        RegressionRunParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRegressionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRegressionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegressionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/functions/regression/corrections</c>, but is otherwise the
    /// same as <see cref="IRegressionService.ApplyCorrections(RegressionApplyCorrectionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RegressionApplyCorrectionsResponse>> ApplyCorrections(
        RegressionApplyCorrectionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/functions/regression</c>, but is otherwise the
    /// same as <see cref="IRegressionService.Run(RegressionRunParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RegressionRunResponse>> Run(
        RegressionRunParams parameters,
        CancellationToken cancellationToken = default
    );
}
