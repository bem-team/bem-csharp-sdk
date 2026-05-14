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
/// **Create a view.**
///
/// <para>A view is a tabular projection over the `transformations` produced by one
/// or more functions. Each column declares a `valueSchemaPath` — a JSON Pointer
/// path into the function's output schema — and the view can additionally carry filters
/// and aggregations.</para>
///
/// <para>Supported for every function type that produces correctable transformations
/// and an output schema: `extract`, `transform`, `analyze`, `join`. Extract works
/// on both vision (PDF/PNG/JPEG/HEIC/HEIF/WebP) and OCR-routed inputs — the resulting
/// rows surface through views uniformly.</para>
///
/// <para>The new view is created at `versionNum: 1`. Subsequent updates produce new
/// versions; the version-1 configuration remains addressable.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ViewCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<Aggregation> Aggregations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Aggregation>>("aggregations");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Aggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<Column> Columns
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Column>>("columns");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Column>>(
                "columns",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of filters applied to the view
    /// </summary>
    public required IReadOnlyList<Filter> Filters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Filter>>("filters");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Filter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<ViewCreateParamsFunction> Functions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ViewCreateParamsFunction>>(
                "functions"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewCreateParamsFunction>>(
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

    public ViewCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewCreateParams(ViewCreateParams viewCreateParams)
        : base(viewCreateParams)
    {
        this._rawBodyData = new(viewCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ViewCreateParams(
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
    ViewCreateParams(
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
    public static ViewCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ViewCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/views")
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
[JsonConverter(typeof(JsonModelConverter<Aggregation, AggregationFromRaw>))]
public sealed record class Aggregation : JsonModel
{
    /// <summary>
    /// Aggregation function to apply to a view column
    /// </summary>
    public required ApiEnum<string, Function> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Function>>("function");
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

    public Aggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Aggregation(Aggregation aggregation)
        : base(aggregation) { }
#pragma warning restore CS8618

    public Aggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Aggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AggregationFromRaw.FromRawUnchecked"/>
    public static Aggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AggregationFromRaw : IFromRawJson<Aggregation>
{
    /// <inheritdoc/>
    public Aggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Aggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function to apply to a view column
/// </summary>
[JsonConverter(typeof(FunctionConverter))]
public enum Function
{
    Count,
    CountDistinct,
    Sum,
    Average,
    Min,
    Max,
}

sealed class FunctionConverter : JsonConverter<Function>
{
    public override Function Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => Function.Count,
            "count_distinct" => Function.CountDistinct,
            "sum" => Function.Sum,
            "average" => Function.Average,
            "min" => Function.Min,
            "max" => Function.Max,
            _ => (Function)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Function value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Function.Count => "count",
                Function.CountDistinct => "count_distinct",
                Function.Sum => "sum",
                Function.Average => "average",
                Function.Min => "min",
                Function.Max => "max",
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
[JsonConverter(typeof(JsonModelConverter<Column, ColumnFromRaw>))]
public sealed record class Column : JsonModel
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

    public Column() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Column(Column column)
        : base(column) { }
#pragma warning restore CS8618

    public Column(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Column(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ColumnFromRaw.FromRawUnchecked"/>
    public static Column FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ColumnFromRaw : IFromRawJson<Column>
{
    /// <inheritdoc/>
    public Column FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Column.FromRawUnchecked(rawData);
}

/// <summary>
/// A filter to apply to a view column
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
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
    public required ApiEnum<string, FilterType> FilterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FilterType>>("filterType");
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

    public Filter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter(Filter filter)
        : base(filter) { }
#pragma warning restore CS8618

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of filter to apply to a view column
/// </summary>
[JsonConverter(typeof(FilterTypeConverter))]
public enum FilterType
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

sealed class FilterTypeConverter : JsonConverter<FilterType>
{
    public override FilterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals_string" => FilterType.EqualsString,
            "equals_number" => FilterType.EqualsNumber,
            "less_than_number" => FilterType.LessThanNumber,
            "less_than_equal_number" => FilterType.LessThanEqualNumber,
            "greater_than_number" => FilterType.GreaterThanNumber,
            "greater_than_equal_number" => FilterType.GreaterThanEqualNumber,
            "is_null" => FilterType.IsNull,
            "is_not_null" => FilterType.IsNotNull,
            _ => (FilterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FilterType.EqualsString => "equals_string",
                FilterType.EqualsNumber => "equals_number",
                FilterType.LessThanNumber => "less_than_number",
                FilterType.LessThanEqualNumber => "less_than_equal_number",
                FilterType.GreaterThanNumber => "greater_than_number",
                FilterType.GreaterThanEqualNumber => "greater_than_equal_number",
                FilterType.IsNull => "is_null",
                FilterType.IsNotNull => "is_not_null",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ViewCreateParamsFunction, ViewCreateParamsFunctionFromRaw>)
)]
public sealed record class ViewCreateParamsFunction : JsonModel
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

    public ViewCreateParamsFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewCreateParamsFunction(ViewCreateParamsFunction viewCreateParamsFunction)
        : base(viewCreateParamsFunction) { }
#pragma warning restore CS8618

    public ViewCreateParamsFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewCreateParamsFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewCreateParamsFunctionFromRaw.FromRawUnchecked"/>
    public static ViewCreateParamsFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewCreateParamsFunctionFromRaw : IFromRawJson<ViewCreateParamsFunction>
{
    /// <inheritdoc/>
    public ViewCreateParamsFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewCreateParamsFunction.FromRawUnchecked(rawData);
}
