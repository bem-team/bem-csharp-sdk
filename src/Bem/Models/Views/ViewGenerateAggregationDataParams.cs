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
/// **Generate aggregation results for a view.**
///
/// <para>Executes each aggregation declared on the view against the `transformations`
/// rows produced by the named functions inside the supplied `timeWindow`, applying
/// the view's filters. Supported aggregation functions: `count`, `count_distinct`,
/// `sum`, `average`, `min`, `max`. Grouped aggregations return up to 200 groups
/// per aggregation; non-grouped aggregations return a single group with an empty `groupName`.</para>
///
/// <para>As with table-data, the `functions` field is required.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ViewGenerateAggregationDataParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<ViewGenerateAggregationDataParamsAggregation> Aggregations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ViewGenerateAggregationDataParamsAggregation>
            >("aggregations");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewGenerateAggregationDataParamsAggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<ViewGenerateAggregationDataParamsColumn> Columns
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ViewGenerateAggregationDataParamsColumn>
            >("columns");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewGenerateAggregationDataParamsColumn>>(
                "columns",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of filters applied to the view
    /// </summary>
    public required IReadOnlyList<ViewGenerateAggregationDataParamsFilter> Filters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ViewGenerateAggregationDataParamsFilter>
            >("filters");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewGenerateAggregationDataParamsFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<ViewGenerateAggregationDataParamsFunction> Functions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ViewGenerateAggregationDataParamsFunction>
            >("functions");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewGenerateAggregationDataParamsFunction>>(
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
    public required TimeWindow TimeWindow
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<TimeWindow>("timeWindow");
        }
        init { this._rawBodyData.Set("timeWindow", value); }
    }

    public ViewGenerateAggregationDataParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateAggregationDataParams(
        ViewGenerateAggregationDataParams viewGenerateAggregationDataParams
    )
        : base(viewGenerateAggregationDataParams)
    {
        this._rawBodyData = new(viewGenerateAggregationDataParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ViewGenerateAggregationDataParams(
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
    ViewGenerateAggregationDataParams(
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
    public static ViewGenerateAggregationDataParams FromRawUnchecked(
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

    public virtual bool Equals(ViewGenerateAggregationDataParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v3/views/aggregation-data"
        )
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
        ViewGenerateAggregationDataParamsAggregation,
        ViewGenerateAggregationDataParamsAggregationFromRaw
    >)
)]
public sealed record class ViewGenerateAggregationDataParamsAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function to apply to a view column
    /// </summary>
    public required ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction>
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

    public ViewGenerateAggregationDataParamsAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateAggregationDataParamsAggregation(
        ViewGenerateAggregationDataParamsAggregation viewGenerateAggregationDataParamsAggregation
    )
        : base(viewGenerateAggregationDataParamsAggregation) { }
#pragma warning restore CS8618

    public ViewGenerateAggregationDataParamsAggregation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateAggregationDataParamsAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateAggregationDataParamsAggregationFromRaw.FromRawUnchecked"/>
    public static ViewGenerateAggregationDataParamsAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateAggregationDataParamsAggregationFromRaw
    : IFromRawJson<ViewGenerateAggregationDataParamsAggregation>
{
    /// <inheritdoc/>
    public ViewGenerateAggregationDataParamsAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateAggregationDataParamsAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewGenerateAggregationDataParamsAggregationFunctionConverter))]
public enum ViewGenerateAggregationDataParamsAggregationFunction
{
    Count,
    CountDistinct,
    Sum,
    Average,
    Min,
    Max,
}

sealed class ViewGenerateAggregationDataParamsAggregationFunctionConverter
    : JsonConverter<ViewGenerateAggregationDataParamsAggregationFunction>
{
    public override ViewGenerateAggregationDataParamsAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => ViewGenerateAggregationDataParamsAggregationFunction.Count,
            "count_distinct" => ViewGenerateAggregationDataParamsAggregationFunction.CountDistinct,
            "sum" => ViewGenerateAggregationDataParamsAggregationFunction.Sum,
            "average" => ViewGenerateAggregationDataParamsAggregationFunction.Average,
            "min" => ViewGenerateAggregationDataParamsAggregationFunction.Min,
            "max" => ViewGenerateAggregationDataParamsAggregationFunction.Max,
            _ => (ViewGenerateAggregationDataParamsAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewGenerateAggregationDataParamsAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewGenerateAggregationDataParamsAggregationFunction.Count => "count",
                ViewGenerateAggregationDataParamsAggregationFunction.CountDistinct =>
                    "count_distinct",
                ViewGenerateAggregationDataParamsAggregationFunction.Sum => "sum",
                ViewGenerateAggregationDataParamsAggregationFunction.Average => "average",
                ViewGenerateAggregationDataParamsAggregationFunction.Min => "min",
                ViewGenerateAggregationDataParamsAggregationFunction.Max => "max",
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
        ViewGenerateAggregationDataParamsColumn,
        ViewGenerateAggregationDataParamsColumnFromRaw
    >)
)]
public sealed record class ViewGenerateAggregationDataParamsColumn : JsonModel
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

    public ViewGenerateAggregationDataParamsColumn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateAggregationDataParamsColumn(
        ViewGenerateAggregationDataParamsColumn viewGenerateAggregationDataParamsColumn
    )
        : base(viewGenerateAggregationDataParamsColumn) { }
#pragma warning restore CS8618

    public ViewGenerateAggregationDataParamsColumn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateAggregationDataParamsColumn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateAggregationDataParamsColumnFromRaw.FromRawUnchecked"/>
    public static ViewGenerateAggregationDataParamsColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateAggregationDataParamsColumnFromRaw
    : IFromRawJson<ViewGenerateAggregationDataParamsColumn>
{
    /// <inheritdoc/>
    public ViewGenerateAggregationDataParamsColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateAggregationDataParamsColumn.FromRawUnchecked(rawData);
}

/// <summary>
/// A filter to apply to a view column
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ViewGenerateAggregationDataParamsFilter,
        ViewGenerateAggregationDataParamsFilterFromRaw
    >)
)]
public sealed record class ViewGenerateAggregationDataParamsFilter : JsonModel
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
    public required ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType> FilterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType>
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

    public ViewGenerateAggregationDataParamsFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateAggregationDataParamsFilter(
        ViewGenerateAggregationDataParamsFilter viewGenerateAggregationDataParamsFilter
    )
        : base(viewGenerateAggregationDataParamsFilter) { }
#pragma warning restore CS8618

    public ViewGenerateAggregationDataParamsFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateAggregationDataParamsFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateAggregationDataParamsFilterFromRaw.FromRawUnchecked"/>
    public static ViewGenerateAggregationDataParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateAggregationDataParamsFilterFromRaw
    : IFromRawJson<ViewGenerateAggregationDataParamsFilter>
{
    /// <inheritdoc/>
    public ViewGenerateAggregationDataParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateAggregationDataParamsFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of filter to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewGenerateAggregationDataParamsFilterFilterTypeConverter))]
public enum ViewGenerateAggregationDataParamsFilterFilterType
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

sealed class ViewGenerateAggregationDataParamsFilterFilterTypeConverter
    : JsonConverter<ViewGenerateAggregationDataParamsFilterFilterType>
{
    public override ViewGenerateAggregationDataParamsFilterFilterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals_string" => ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
            "equals_number" => ViewGenerateAggregationDataParamsFilterFilterType.EqualsNumber,
            "less_than_number" => ViewGenerateAggregationDataParamsFilterFilterType.LessThanNumber,
            "less_than_equal_number" =>
                ViewGenerateAggregationDataParamsFilterFilterType.LessThanEqualNumber,
            "greater_than_number" =>
                ViewGenerateAggregationDataParamsFilterFilterType.GreaterThanNumber,
            "greater_than_equal_number" =>
                ViewGenerateAggregationDataParamsFilterFilterType.GreaterThanEqualNumber,
            "is_null" => ViewGenerateAggregationDataParamsFilterFilterType.IsNull,
            "is_not_null" => ViewGenerateAggregationDataParamsFilterFilterType.IsNotNull,
            _ => (ViewGenerateAggregationDataParamsFilterFilterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewGenerateAggregationDataParamsFilterFilterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewGenerateAggregationDataParamsFilterFilterType.EqualsString => "equals_string",
                ViewGenerateAggregationDataParamsFilterFilterType.EqualsNumber => "equals_number",
                ViewGenerateAggregationDataParamsFilterFilterType.LessThanNumber =>
                    "less_than_number",
                ViewGenerateAggregationDataParamsFilterFilterType.LessThanEqualNumber =>
                    "less_than_equal_number",
                ViewGenerateAggregationDataParamsFilterFilterType.GreaterThanNumber =>
                    "greater_than_number",
                ViewGenerateAggregationDataParamsFilterFilterType.GreaterThanEqualNumber =>
                    "greater_than_equal_number",
                ViewGenerateAggregationDataParamsFilterFilterType.IsNull => "is_null",
                ViewGenerateAggregationDataParamsFilterFilterType.IsNotNull => "is_not_null",
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
        ViewGenerateAggregationDataParamsFunction,
        ViewGenerateAggregationDataParamsFunctionFromRaw
    >)
)]
public sealed record class ViewGenerateAggregationDataParamsFunction : JsonModel
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

    public ViewGenerateAggregationDataParamsFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateAggregationDataParamsFunction(
        ViewGenerateAggregationDataParamsFunction viewGenerateAggregationDataParamsFunction
    )
        : base(viewGenerateAggregationDataParamsFunction) { }
#pragma warning restore CS8618

    public ViewGenerateAggregationDataParamsFunction(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateAggregationDataParamsFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateAggregationDataParamsFunctionFromRaw.FromRawUnchecked"/>
    public static ViewGenerateAggregationDataParamsFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateAggregationDataParamsFunctionFromRaw
    : IFromRawJson<ViewGenerateAggregationDataParamsFunction>
{
    /// <inheritdoc/>
    public ViewGenerateAggregationDataParamsFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateAggregationDataParamsFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// Time window for filtering transformations in a view
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TimeWindow, TimeWindowFromRaw>))]
public sealed record class TimeWindow : JsonModel
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

    public TimeWindow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TimeWindow(TimeWindow timeWindow)
        : base(timeWindow) { }
#pragma warning restore CS8618

    public TimeWindow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeWindow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeWindowFromRaw.FromRawUnchecked"/>
    public static TimeWindow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeWindowFromRaw : IFromRawJson<TimeWindow>
{
    /// <inheritdoc/>
    public TimeWindow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TimeWindow.FromRawUnchecked(rawData);
}
