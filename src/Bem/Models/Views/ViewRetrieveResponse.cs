using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Views;

/// <summary>
/// A view is a table visualization of transformations that allows customers to have
/// insight into their transformations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ViewRetrieveResponse, ViewRetrieveResponseFromRaw>))]
public sealed record class ViewRetrieveResponse : JsonModel
{
    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<ViewRetrieveResponseAggregation> Aggregations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewRetrieveResponseAggregation>>(
                "aggregations"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewRetrieveResponseAggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<ViewRetrieveResponseColumn> Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewRetrieveResponseColumn>>(
                "columns"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewRetrieveResponseColumn>>(
                "columns",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Current version number of the view
    /// </summary>
    public required long CurrentVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("currentVersionNum");
        }
        init { this._rawData.Set("currentVersionNum", value); }
    }

    /// <summary>
    /// List of filters applied to the view
    /// </summary>
    public required IReadOnlyList<ViewRetrieveResponseFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewRetrieveResponseFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewRetrieveResponseFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<ViewRetrieveResponseFunction> Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewRetrieveResponseFunction>>(
                "functions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewRetrieveResponseFunction>>(
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Unique identifier of the view
    /// </summary>
    public required string ViewID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("viewID");
        }
        init { this._rawData.Set("viewID", value); }
    }

    /// <summary>
    /// Description of the view
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Display type of the view
    /// </summary>
    public ApiEnum<string, ViewRetrieveResponseDisplayType>? DisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ViewRetrieveResponseDisplayType>>(
                "displayType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Aggregations)
        {
            item.Validate();
        }
        foreach (var item in this.Columns)
        {
            item.Validate();
        }
        _ = this.CurrentVersionNum;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        foreach (var item in this.Functions)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.ViewID;
        _ = this.Description;
        this.DisplayType?.Validate();
    }

    public ViewRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewRetrieveResponse(ViewRetrieveResponse viewRetrieveResponse)
        : base(viewRetrieveResponse) { }
#pragma warning restore CS8618

    public ViewRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ViewRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewRetrieveResponseFromRaw : IFromRawJson<ViewRetrieveResponse>
{
    /// <inheritdoc/>
    public ViewRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An aggregation definition for a view
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ViewRetrieveResponseAggregation,
        ViewRetrieveResponseAggregationFromRaw
    >)
)]
public sealed record class ViewRetrieveResponseAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function to apply to a view column
    /// </summary>
    public required ApiEnum<string, ViewRetrieveResponseAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewRetrieveResponseAggregationFunction>
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

    public ViewRetrieveResponseAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewRetrieveResponseAggregation(
        ViewRetrieveResponseAggregation viewRetrieveResponseAggregation
    )
        : base(viewRetrieveResponseAggregation) { }
#pragma warning restore CS8618

    public ViewRetrieveResponseAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponseAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewRetrieveResponseAggregationFromRaw.FromRawUnchecked"/>
    public static ViewRetrieveResponseAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewRetrieveResponseAggregationFromRaw : IFromRawJson<ViewRetrieveResponseAggregation>
{
    /// <inheritdoc/>
    public ViewRetrieveResponseAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewRetrieveResponseAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewRetrieveResponseAggregationFunctionConverter))]
public enum ViewRetrieveResponseAggregationFunction
{
    Count,
    CountDistinct,
    Sum,
    Average,
    Min,
    Max,
}

sealed class ViewRetrieveResponseAggregationFunctionConverter
    : JsonConverter<ViewRetrieveResponseAggregationFunction>
{
    public override ViewRetrieveResponseAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => ViewRetrieveResponseAggregationFunction.Count,
            "count_distinct" => ViewRetrieveResponseAggregationFunction.CountDistinct,
            "sum" => ViewRetrieveResponseAggregationFunction.Sum,
            "average" => ViewRetrieveResponseAggregationFunction.Average,
            "min" => ViewRetrieveResponseAggregationFunction.Min,
            "max" => ViewRetrieveResponseAggregationFunction.Max,
            _ => (ViewRetrieveResponseAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewRetrieveResponseAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewRetrieveResponseAggregationFunction.Count => "count",
                ViewRetrieveResponseAggregationFunction.CountDistinct => "count_distinct",
                ViewRetrieveResponseAggregationFunction.Sum => "sum",
                ViewRetrieveResponseAggregationFunction.Average => "average",
                ViewRetrieveResponseAggregationFunction.Min => "min",
                ViewRetrieveResponseAggregationFunction.Max => "max",
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
    typeof(JsonModelConverter<ViewRetrieveResponseColumn, ViewRetrieveResponseColumnFromRaw>)
)]
public sealed record class ViewRetrieveResponseColumn : JsonModel
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

    public ViewRetrieveResponseColumn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewRetrieveResponseColumn(ViewRetrieveResponseColumn viewRetrieveResponseColumn)
        : base(viewRetrieveResponseColumn) { }
#pragma warning restore CS8618

    public ViewRetrieveResponseColumn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponseColumn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewRetrieveResponseColumnFromRaw.FromRawUnchecked"/>
    public static ViewRetrieveResponseColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewRetrieveResponseColumnFromRaw : IFromRawJson<ViewRetrieveResponseColumn>
{
    /// <inheritdoc/>
    public ViewRetrieveResponseColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewRetrieveResponseColumn.FromRawUnchecked(rawData);
}

/// <summary>
/// A filter to apply to a view column
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ViewRetrieveResponseFilter, ViewRetrieveResponseFilterFromRaw>)
)]
public sealed record class ViewRetrieveResponseFilter : JsonModel
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
    public required ApiEnum<string, ViewRetrieveResponseFilterFilterType> FilterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewRetrieveResponseFilterFilterType>
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

    public ViewRetrieveResponseFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewRetrieveResponseFilter(ViewRetrieveResponseFilter viewRetrieveResponseFilter)
        : base(viewRetrieveResponseFilter) { }
#pragma warning restore CS8618

    public ViewRetrieveResponseFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponseFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewRetrieveResponseFilterFromRaw.FromRawUnchecked"/>
    public static ViewRetrieveResponseFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewRetrieveResponseFilterFromRaw : IFromRawJson<ViewRetrieveResponseFilter>
{
    /// <inheritdoc/>
    public ViewRetrieveResponseFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewRetrieveResponseFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of filter to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewRetrieveResponseFilterFilterTypeConverter))]
public enum ViewRetrieveResponseFilterFilterType
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

sealed class ViewRetrieveResponseFilterFilterTypeConverter
    : JsonConverter<ViewRetrieveResponseFilterFilterType>
{
    public override ViewRetrieveResponseFilterFilterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals_string" => ViewRetrieveResponseFilterFilterType.EqualsString,
            "equals_number" => ViewRetrieveResponseFilterFilterType.EqualsNumber,
            "less_than_number" => ViewRetrieveResponseFilterFilterType.LessThanNumber,
            "less_than_equal_number" => ViewRetrieveResponseFilterFilterType.LessThanEqualNumber,
            "greater_than_number" => ViewRetrieveResponseFilterFilterType.GreaterThanNumber,
            "greater_than_equal_number" =>
                ViewRetrieveResponseFilterFilterType.GreaterThanEqualNumber,
            "is_null" => ViewRetrieveResponseFilterFilterType.IsNull,
            "is_not_null" => ViewRetrieveResponseFilterFilterType.IsNotNull,
            _ => (ViewRetrieveResponseFilterFilterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewRetrieveResponseFilterFilterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewRetrieveResponseFilterFilterType.EqualsString => "equals_string",
                ViewRetrieveResponseFilterFilterType.EqualsNumber => "equals_number",
                ViewRetrieveResponseFilterFilterType.LessThanNumber => "less_than_number",
                ViewRetrieveResponseFilterFilterType.LessThanEqualNumber =>
                    "less_than_equal_number",
                ViewRetrieveResponseFilterFilterType.GreaterThanNumber => "greater_than_number",
                ViewRetrieveResponseFilterFilterType.GreaterThanEqualNumber =>
                    "greater_than_equal_number",
                ViewRetrieveResponseFilterFilterType.IsNull => "is_null",
                ViewRetrieveResponseFilterFilterType.IsNotNull => "is_not_null",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ViewRetrieveResponseFunction, ViewRetrieveResponseFunctionFromRaw>)
)]
public sealed record class ViewRetrieveResponseFunction : JsonModel
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

    public ViewRetrieveResponseFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewRetrieveResponseFunction(ViewRetrieveResponseFunction viewRetrieveResponseFunction)
        : base(viewRetrieveResponseFunction) { }
#pragma warning restore CS8618

    public ViewRetrieveResponseFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponseFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewRetrieveResponseFunctionFromRaw.FromRawUnchecked"/>
    public static ViewRetrieveResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewRetrieveResponseFunctionFromRaw : IFromRawJson<ViewRetrieveResponseFunction>
{
    /// <inheritdoc/>
    public ViewRetrieveResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewRetrieveResponseFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// Display type of the view
/// </summary>
[JsonConverter(typeof(ViewRetrieveResponseDisplayTypeConverter))]
public enum ViewRetrieveResponseDisplayType
{
    Table,
    BarChart,
    PieChart,
}

sealed class ViewRetrieveResponseDisplayTypeConverter
    : JsonConverter<ViewRetrieveResponseDisplayType>
{
    public override ViewRetrieveResponseDisplayType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "table" => ViewRetrieveResponseDisplayType.Table,
            "bar_chart" => ViewRetrieveResponseDisplayType.BarChart,
            "pie_chart" => ViewRetrieveResponseDisplayType.PieChart,
            _ => (ViewRetrieveResponseDisplayType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewRetrieveResponseDisplayType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewRetrieveResponseDisplayType.Table => "table",
                ViewRetrieveResponseDisplayType.BarChart => "bar_chart",
                ViewRetrieveResponseDisplayType.PieChart => "pie_chart",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
