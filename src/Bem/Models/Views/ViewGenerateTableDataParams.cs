using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Views;

/// <summary>
/// **Generate paginated table data for a view.**
///
/// <para>Executes the view's query against `transformations` rows produced by the
/// named functions inside the supplied `timeWindow`, applies the view's filters,
/// and returns matching rows. Each row reports the event `eventID` (externally-stable
/// KSUID) plus the projected column values.</para>
///
/// <para>The `functions` field is required — at least one `functionID` or `functionName`
/// must be supplied. `limit` defaults to 50 with a maximum of 200; `offset` is zero-based.
/// The response's `totalCount` reflects the match count before pagination, so paging
/// can be driven off it.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ViewGenerateTableDataParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<ViewGenerateTableDataParamsAggregation> Aggregations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ViewGenerateTableDataParamsAggregation>
            >("aggregations");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewGenerateTableDataParamsAggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<ViewGenerateTableDataParamsColumn> Columns
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ViewGenerateTableDataParamsColumn>
            >("columns");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewGenerateTableDataParamsColumn>>(
                "columns",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of filters applied to the view
    /// </summary>
    public required IReadOnlyList<ViewGenerateTableDataParamsFilter> Filters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ViewGenerateTableDataParamsFilter>
            >("filters");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewGenerateTableDataParamsFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<ViewGenerateTableDataParamsFunction> Functions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ViewGenerateTableDataParamsFunction>
            >("functions");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewGenerateTableDataParamsFunction>>(
                "functions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Name of the view
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Time window for filtering transformations in a view
    /// </summary>
    public required ViewGenerateTableDataParamsTimeWindow TimeWindow
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ViewGenerateTableDataParamsTimeWindow>(
                "timeWindow"
            );
        }
        init { this._rawBodyData.Set("timeWindow", value); }
    }

    /// <summary>
    /// Maximum number of rows to return (default: 50, max: 200)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("limit");
        }
        init { this._rawBodyData.Set("limit", value); }
    }

    /// <summary>
    /// Number of rows to skip for pagination
    /// </summary>
    public long? Offset
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("offset");
        }
        init { this._rawBodyData.Set("offset", value); }
    }

    public ViewGenerateTableDataParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateTableDataParams(ViewGenerateTableDataParams viewGenerateTableDataParams)
        : base(viewGenerateTableDataParams)
    {
        this._rawBodyData = new(viewGenerateTableDataParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ViewGenerateTableDataParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateTableDataParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ViewGenerateTableDataParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ViewGenerateTableDataParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/views/table-data")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// An aggregation definition for a view
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ViewGenerateTableDataParamsAggregation,
        ViewGenerateTableDataParamsAggregationFromRaw
    >)
)]
public sealed record class ViewGenerateTableDataParamsAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function to apply to a view column
    /// </summary>
    public required ApiEnum<string, ViewGenerateTableDataParamsAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewGenerateTableDataParamsAggregationFunction>
            >("function");
        }
        init { this._rawData.Set("function", value); }
    }

    /// <summary>
    /// Name of the aggregation
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Name of the column to aggregate (required for count_distinct, sum, average,
    /// min, max functions)
    /// </summary>
    public string? AggregateColumnName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("aggregateColumnName");
        }
        init { this._rawData.Set("aggregateColumnName", value); }
    }

    /// <summary>
    /// Name of the column to group by (optional, for grouped aggregations)
    /// </summary>
    public string? GroupByColumnName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("groupByColumnName");
        }
        init { this._rawData.Set("groupByColumnName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
        _ = this.Name;
        _ = this.AggregateColumnName;
        _ = this.GroupByColumnName;
    }

    public ViewGenerateTableDataParamsAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateTableDataParamsAggregation(
        ViewGenerateTableDataParamsAggregation viewGenerateTableDataParamsAggregation
    )
        : base(viewGenerateTableDataParamsAggregation) { }
#pragma warning restore CS8618

    public ViewGenerateTableDataParamsAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateTableDataParamsAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateTableDataParamsAggregationFromRaw.FromRawUnchecked"/>
    public static ViewGenerateTableDataParamsAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateTableDataParamsAggregationFromRaw
    : IFromRawJson<ViewGenerateTableDataParamsAggregation>
{
    /// <inheritdoc/>
    public ViewGenerateTableDataParamsAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateTableDataParamsAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewGenerateTableDataParamsAggregationFunctionConverter))]
public enum ViewGenerateTableDataParamsAggregationFunction
{
    Count,
    CountDistinct,
    Sum,
    Average,
    Min,
    Max,
}

sealed class ViewGenerateTableDataParamsAggregationFunctionConverter
    : JsonConverter<ViewGenerateTableDataParamsAggregationFunction>
{
    public override ViewGenerateTableDataParamsAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => ViewGenerateTableDataParamsAggregationFunction.Count,
            "count_distinct" => ViewGenerateTableDataParamsAggregationFunction.CountDistinct,
            "sum" => ViewGenerateTableDataParamsAggregationFunction.Sum,
            "average" => ViewGenerateTableDataParamsAggregationFunction.Average,
            "min" => ViewGenerateTableDataParamsAggregationFunction.Min,
            "max" => ViewGenerateTableDataParamsAggregationFunction.Max,
            _ => (ViewGenerateTableDataParamsAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewGenerateTableDataParamsAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewGenerateTableDataParamsAggregationFunction.Count => "count",
                ViewGenerateTableDataParamsAggregationFunction.CountDistinct => "count_distinct",
                ViewGenerateTableDataParamsAggregationFunction.Sum => "sum",
                ViewGenerateTableDataParamsAggregationFunction.Average => "average",
                ViewGenerateTableDataParamsAggregationFunction.Min => "min",
                ViewGenerateTableDataParamsAggregationFunction.Max => "max",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A column definition in a view
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ViewGenerateTableDataParamsColumn,
        ViewGenerateTableDataParamsColumnFromRaw
    >)
)]
public sealed record class ViewGenerateTableDataParamsColumn : JsonModel
{
    /// <summary>
    /// Order in which this column should be displayed (0-based index)
    /// </summary>
    public required long DisplayOrderIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("displayOrderIndex");
        }
        init { this._rawData.Set("displayOrderIndex", value); }
    }

    /// <summary>
    /// Name of the column
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// JSON path to the value in the transformation output schema (e.g., ["invoiceDetails", "invoiceNumber"])
    /// </summary>
    public required IReadOnlyList<string> ValueSchemaPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("valueSchemaPath");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "valueSchemaPath",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayOrderIndex;
        _ = this.Name;
        _ = this.ValueSchemaPath;
    }

    public ViewGenerateTableDataParamsColumn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateTableDataParamsColumn(
        ViewGenerateTableDataParamsColumn viewGenerateTableDataParamsColumn
    )
        : base(viewGenerateTableDataParamsColumn) { }
#pragma warning restore CS8618

    public ViewGenerateTableDataParamsColumn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateTableDataParamsColumn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateTableDataParamsColumnFromRaw.FromRawUnchecked"/>
    public static ViewGenerateTableDataParamsColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateTableDataParamsColumnFromRaw : IFromRawJson<ViewGenerateTableDataParamsColumn>
{
    /// <inheritdoc/>
    public ViewGenerateTableDataParamsColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateTableDataParamsColumn.FromRawUnchecked(rawData);
}

/// <summary>
/// A filter to apply to a view column
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ViewGenerateTableDataParamsFilter,
        ViewGenerateTableDataParamsFilterFromRaw
    >)
)]
public sealed record class ViewGenerateTableDataParamsFilter : JsonModel
{
    /// <summary>
    /// Name of the column to filter on
    /// </summary>
    public required string ColumnName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("columnName");
        }
        init { this._rawData.Set("columnName", value); }
    }

    /// <summary>
    /// Type of filter to apply to a view column
    /// </summary>
    public required ApiEnum<string, ViewGenerateTableDataParamsFilterFilterType> FilterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewGenerateTableDataParamsFilterFilterType>
            >("filterType");
        }
        init { this._rawData.Set("filterType", value); }
    }

    /// <summary>
    /// Numeric value for the filter (required for number filter types)
    /// </summary>
    public float? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// String value for the filter (required for string filter types)
    /// </summary>
    public string? String
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("string");
        }
        init { this._rawData.Set("string", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ColumnName;
        this.FilterType.Validate();
        _ = this.Number;
        _ = this.String;
    }

    public ViewGenerateTableDataParamsFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateTableDataParamsFilter(
        ViewGenerateTableDataParamsFilter viewGenerateTableDataParamsFilter
    )
        : base(viewGenerateTableDataParamsFilter) { }
#pragma warning restore CS8618

    public ViewGenerateTableDataParamsFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateTableDataParamsFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateTableDataParamsFilterFromRaw.FromRawUnchecked"/>
    public static ViewGenerateTableDataParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateTableDataParamsFilterFromRaw : IFromRawJson<ViewGenerateTableDataParamsFilter>
{
    /// <inheritdoc/>
    public ViewGenerateTableDataParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateTableDataParamsFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of filter to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewGenerateTableDataParamsFilterFilterTypeConverter))]
public enum ViewGenerateTableDataParamsFilterFilterType
{
    EqualsString,
    EqualsNumber,
    LessThanNumber,
    LessThanEqualNumber,
    GreaterThanNumber,
    GreaterThanEqualNumber,
    IsNull,
    IsNotNull,
}

sealed class ViewGenerateTableDataParamsFilterFilterTypeConverter
    : JsonConverter<ViewGenerateTableDataParamsFilterFilterType>
{
    public override ViewGenerateTableDataParamsFilterFilterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals_string" => ViewGenerateTableDataParamsFilterFilterType.EqualsString,
            "equals_number" => ViewGenerateTableDataParamsFilterFilterType.EqualsNumber,
            "less_than_number" => ViewGenerateTableDataParamsFilterFilterType.LessThanNumber,
            "less_than_equal_number" =>
                ViewGenerateTableDataParamsFilterFilterType.LessThanEqualNumber,
            "greater_than_number" => ViewGenerateTableDataParamsFilterFilterType.GreaterThanNumber,
            "greater_than_equal_number" =>
                ViewGenerateTableDataParamsFilterFilterType.GreaterThanEqualNumber,
            "is_null" => ViewGenerateTableDataParamsFilterFilterType.IsNull,
            "is_not_null" => ViewGenerateTableDataParamsFilterFilterType.IsNotNull,
            _ => (ViewGenerateTableDataParamsFilterFilterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewGenerateTableDataParamsFilterFilterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewGenerateTableDataParamsFilterFilterType.EqualsString => "equals_string",
                ViewGenerateTableDataParamsFilterFilterType.EqualsNumber => "equals_number",
                ViewGenerateTableDataParamsFilterFilterType.LessThanNumber => "less_than_number",
                ViewGenerateTableDataParamsFilterFilterType.LessThanEqualNumber =>
                    "less_than_equal_number",
                ViewGenerateTableDataParamsFilterFilterType.GreaterThanNumber =>
                    "greater_than_number",
                ViewGenerateTableDataParamsFilterFilterType.GreaterThanEqualNumber =>
                    "greater_than_equal_number",
                ViewGenerateTableDataParamsFilterFilterType.IsNull => "is_null",
                ViewGenerateTableDataParamsFilterFilterType.IsNotNull => "is_not_null",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ViewGenerateTableDataParamsFunction,
        ViewGenerateTableDataParamsFunctionFromRaw
    >)
)]
public sealed record class ViewGenerateTableDataParamsFunction : JsonModel
{
    /// <summary>
    /// Unique identifier of function. Provide either id or name, not both.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis. Provide either
    /// id or name, not both.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public ViewGenerateTableDataParamsFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateTableDataParamsFunction(
        ViewGenerateTableDataParamsFunction viewGenerateTableDataParamsFunction
    )
        : base(viewGenerateTableDataParamsFunction) { }
#pragma warning restore CS8618

    public ViewGenerateTableDataParamsFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateTableDataParamsFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateTableDataParamsFunctionFromRaw.FromRawUnchecked"/>
    public static ViewGenerateTableDataParamsFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateTableDataParamsFunctionFromRaw : IFromRawJson<ViewGenerateTableDataParamsFunction>
{
    /// <inheritdoc/>
    public ViewGenerateTableDataParamsFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateTableDataParamsFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// Time window for filtering transformations in a view
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ViewGenerateTableDataParamsTimeWindow,
        ViewGenerateTableDataParamsTimeWindowFromRaw
    >)
)]
public sealed record class ViewGenerateTableDataParamsTimeWindow : JsonModel
{
    /// <summary>
    /// End of the time window in ISO 8601 (RFC 3339) format in UTC
    /// </summary>
    public required DateTimeOffset End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("end");
        }
        init { this._rawData.Set("end", value); }
    }

    /// <summary>
    /// Start of the time window in ISO 8601 (RFC 3339) format in UTC
    /// </summary>
    public required DateTimeOffset Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
    }

    public ViewGenerateTableDataParamsTimeWindow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateTableDataParamsTimeWindow(
        ViewGenerateTableDataParamsTimeWindow viewGenerateTableDataParamsTimeWindow
    )
        : base(viewGenerateTableDataParamsTimeWindow) { }
#pragma warning restore CS8618

    public ViewGenerateTableDataParamsTimeWindow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateTableDataParamsTimeWindow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateTableDataParamsTimeWindowFromRaw.FromRawUnchecked"/>
    public static ViewGenerateTableDataParamsTimeWindow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateTableDataParamsTimeWindowFromRaw
    : IFromRawJson<ViewGenerateTableDataParamsTimeWindow>
{
    /// <inheritdoc/>
    public ViewGenerateTableDataParamsTimeWindow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateTableDataParamsTimeWindow.FromRawUnchecked(rawData);
}
