using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Views;

namespace Bem.Services;

/// <summary>
/// Views are tabular projections over the `transformations` your functions produce
/// — a saved query that turns raw extracted JSON into a filterable, paginatable,
/// aggregatable table.
///
/// <para>## Anatomy</para>
///
/// <para>A view declares: - One or more **functions** to read from (by `functionID`
/// or `functionName`). - A list of **columns**, each pinned to a `valueSchemaPath`
/// (a JSON   Pointer into the function's output schema). - Optional **filters**
/// (string equality, numeric comparators,   null-checks) and **aggregations** (`count`,
/// `count_distinct`,   `sum`, `average`, `min`, `max`).</para>
///
/// <para>Views are versioned: every update produces a new version, and the previous
/// version remains immutable and addressable. Function types that produce transformations
/// with an output schema — `extract`, `transform`, `analyze`, `join` — are all queryable
/// through views; `extract` works uniformly across vision and OCR inputs.</para>
///
/// <para>## Reading data</para>
///
/// <para>- **`POST /v3/views/table-data`** — paginated rows of column values.   Each
/// row reports the underlying event's `eventID` (the   externally-stable KSUID used
/// everywhere else in V3) plus the   projected column values. - **`POST /v3/views/aggregation-data`**
/// — group-by-able aggregate   values across the same query surface.</para>
///
/// <para>Both endpoints take a `timeWindow` to bound the transformation set and require
/// at least one `function` to read from.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IViewService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IViewServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IViewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Create a view.**
    ///
    /// <para>A view is a tabular projection over the `transformations` produced by one
    /// or more functions. Each column declares a `valueSchemaPath` — a JSON Pointer
    /// path into the function's output schema — and the view can additionally carry
    /// filters and aggregations.</para>
    ///
    /// <para>Supported for every function type that produces correctable
    /// transformations and an output schema: `extract`, `transform`, `analyze`, `join`.
    /// Extract works on both vision (PDF/PNG/JPEG/HEIC/HEIF/WebP) and OCR-routed inputs
    /// — the resulting rows surface through views uniformly.</para>
    ///
    /// <para>The new view is created at `versionNum: 1`. Subsequent updates produce new
    /// versions; the version-1 configuration remains addressable.</para>
    /// </summary>
    Task<ViewCreateResponse> Create(
        ViewCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Retrieve a view by ID.**
    ///
    /// <para>Returns the view's current version. To inspect a historical version, fetch
    /// the list of versions on the View object and re-request with the desired version
    /// pinned (versions are immutable once created).</para>
    /// </summary>
    Task<ViewRetrieveResponse> Retrieve(
        ViewRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ViewRetrieveParams, CancellationToken)"/>
    Task<ViewRetrieveResponse> Retrieve(
        string viewID,
        ViewRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Update a view. Updates create a new version.**
    ///
    /// <para>The previous version remains addressable and immutable. The new
    /// configuration is fully replacing — pass the complete view body, not a patch. The
    /// version number is auto-incremented.</para>
    /// </summary>
    Task<ViewUpdateResponse> Update(
        ViewUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ViewUpdateParams, CancellationToken)"/>
    Task<ViewUpdateResponse> Update(
        string viewID,
        ViewUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **List views in the current environment, optionally filtered by the functions
    /// they read from.**
    ///
    /// <para>Views are tabular projections over `transformations` rows: each view names
    /// one or more functions and a list of columns (JSON-pointer paths into
    /// `extractedJson`), and produces a uniform table that can be filtered, paginated,
    /// and aggregated.</para>
    ///
    /// <para>Filters AND together when combined. Pagination is cursor-based on
    /// `viewID`; default limit is 50, maximum 100.</para>
    /// </summary>
    Task<ViewListResponse> List(
        ViewListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Delete a view and every one of its versions.**
    ///
    /// <para>Permanent. Any cached data-table or aggregation result clients have
    /// fetched remains valid, but subsequent calls to `POST /v3/views/table-data` or
    /// `POST /v3/views/aggregation-data` for this view will fail.</para>
    /// </summary>
    Task Delete(ViewDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ViewDeleteParams, CancellationToken)"/>
    Task Delete(
        string viewID,
        ViewDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Generate aggregation results for a view.**
    ///
    /// <para>Executes each aggregation declared on the view against the
    /// `transformations` rows produced by the named functions inside the supplied
    /// `timeWindow`, applying the view's filters. Supported aggregation functions:
    /// `count`, `count_distinct`, `sum`, `average`, `min`, `max`. Grouped aggregations
    /// return up to 200 groups per aggregation; non-grouped aggregations return a
    /// single group with an empty `groupName`.</para>
    ///
    /// <para>As with table-data, the `functions` field is required.</para>
    /// </summary>
    Task<ViewGenerateAggregationDataResponse> GenerateAggregationData(
        ViewGenerateAggregationDataParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Generate paginated table data for a view.**
    ///
    /// <para>Executes the view's query against `transformations` rows produced by the
    /// named functions inside the supplied `timeWindow`, applies the view's filters,
    /// and returns matching rows. Each row reports the event `eventID`
    /// (externally-stable KSUID) plus the projected column values.</para>
    ///
    /// <para>The `functions` field is required — at least one `functionID` or
    /// `functionName` must be supplied. `limit` defaults to 50 with a maximum of 200;
    /// `offset` is zero-based. The response's `totalCount` reflects the match count
    /// before pagination, so paging can be driven off it.</para>
    /// </summary>
    Task<ViewGenerateTableDataResponse> GenerateTableData(
        ViewGenerateTableDataParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IViewService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IViewServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IViewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/views</c>, but is otherwise the
    /// same as <see cref="IViewService.Create(ViewCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ViewCreateResponse>> Create(
        ViewCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/views/{view_id}</c>, but is otherwise the
    /// same as <see cref="IViewService.Retrieve(ViewRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ViewRetrieveResponse>> Retrieve(
        ViewRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ViewRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ViewRetrieveResponse>> Retrieve(
        string viewID,
        ViewRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v3/views/{view_id}</c>, but is otherwise the
    /// same as <see cref="IViewService.Update(ViewUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ViewUpdateResponse>> Update(
        ViewUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ViewUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ViewUpdateResponse>> Update(
        string viewID,
        ViewUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/views</c>, but is otherwise the
    /// same as <see cref="IViewService.List(ViewListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ViewListResponse>> List(
        ViewListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/views/{view_id}</c>, but is otherwise the
    /// same as <see cref="IViewService.Delete(ViewDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ViewDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ViewDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string viewID,
        ViewDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/views/aggregation-data</c>, but is otherwise the
    /// same as <see cref="IViewService.GenerateAggregationData(ViewGenerateAggregationDataParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ViewGenerateAggregationDataResponse>> GenerateAggregationData(
        ViewGenerateAggregationDataParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/views/table-data</c>, but is otherwise the
    /// same as <see cref="IViewService.GenerateTableData(ViewGenerateTableDataParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ViewGenerateTableDataResponse>> GenerateTableData(
        ViewGenerateTableDataParams parameters,
        CancellationToken cancellationToken = default
    );
}
