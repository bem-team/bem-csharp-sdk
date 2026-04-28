using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Eval.Results;

namespace Bem.Services.Eval;

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
    /// **Fetch evaluation results for a batch of transformations (POST).**
    ///
    /// <para>For each requested transformation ID the response reports one of three
    /// states: a completed `result`, still-`pending`, or `failed`. The POST variant
    /// accepts the ID list in the request body; use the `GET` variant with query
    /// parameters for simpler clients.</para>
    /// </summary>
    Task<ResultFetchResultsResponse> FetchResults(
        ResultFetchResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Fetch evaluation results for a batch of transformations.**
    ///
    /// <para>Identical behavior to the POST variant; accepts transformation IDs as a
    /// comma-separated `transformationIDs` query parameter. Limited to 100 IDs per
    /// request.</para>
    /// </summary>
    Task<ResultRetrieveResultsResponse> RetrieveResults(
        ResultRetrieveResultsParams parameters,
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
    /// Returns a raw HTTP response for <c>post /v3/eval/results</c>, but is otherwise the
    /// same as <see cref="IResultService.FetchResults(ResultFetchResultsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ResultFetchResultsResponse>> FetchResults(
        ResultFetchResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/eval/results</c>, but is otherwise the
    /// same as <see cref="IResultService.RetrieveResults(ResultRetrieveResultsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ResultRetrieveResultsResponse>> RetrieveResults(
        ResultRetrieveResultsParams parameters,
        CancellationToken cancellationToken = default
    );
}
