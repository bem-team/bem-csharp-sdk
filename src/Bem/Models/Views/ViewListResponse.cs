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
/// Response containing a list of views
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ViewListResponse, ViewListResponseFromRaw>))]
public sealed record class ViewListResponse : JsonModel
{
    /// <summary>
    /// Total number of views matching the query
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalCount");
        }
        init { this._rawData.Set("totalCount", value); }
    }

    /// <summary>
    /// Array of views
    /// </summary>
    public required IReadOnlyList<View> Views
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<View>>("views");
        }
        init
        {
            this._rawData.Set<ImmutableArray<View>>(
                "views",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TotalCount;
        foreach (var item in this.Views)
        {
            item.Validate();
        }
    }

    public ViewListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewListResponse(ViewListResponse viewListResponse)
        : base(viewListResponse) { }
#pragma warning restore CS8618

    public ViewListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewListResponseFromRaw.FromRawUnchecked"/>
    public static ViewListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewListResponseFromRaw : IFromRawJson<ViewListResponse>
{
    /// <inheritdoc/>
    public ViewListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ViewListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A view is a table visualization of transformations that allows customers to have
/// insight into their transformations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<View, ViewFromRaw>))]
public sealed record class View : JsonModel
{
    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<ViewAggregation> Aggregations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewAggregation>>("aggregations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewAggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<ViewColumn> Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewColumn>>("columns");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewColumn>>(
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
    public required IReadOnlyList<ViewFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<ViewFunction> Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewFunction>>("functions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewFunction>>(
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
    public ApiEnum<string, ViewDisplayType>? DisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ViewDisplayType>>("displayType");
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

    public View() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public View(View view)
        : base(view) { }
#pragma warning restore CS8618

    public View(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    View(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewFromRaw.FromRawUnchecked"/>
    public static View FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewFromRaw : IFromRawJson<View>
{
    /// <inheritdoc/>
    public View FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        View.FromRawUnchecked(rawData);
}

/// <summary>
/// An aggregation definition for a view
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ViewAggregation, ViewAggregationFromRaw>))]
public sealed record class ViewAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function to apply to a view column
    /// </summary>
    public required ApiEnum<string, ViewAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ViewAggregationFunction>>(
                "function"
            );
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

    public ViewAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewAggregation(ViewAggregation viewAggregation)
        : base(viewAggregation) { }
#pragma warning restore CS8618

    public ViewAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewAggregationFromRaw.FromRawUnchecked"/>
    public static ViewAggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewAggregationFromRaw : IFromRawJson<ViewAggregation>
{
    /// <inheritdoc/>
    public ViewAggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ViewAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewAggregationFunctionConverter))]
public enum ViewAggregationFunction
{
    Count,
    CountDistinct,
    Sum,
    Average,
    Min,
    Max,
}

sealed class ViewAggregationFunctionConverter : JsonConverter<ViewAggregationFunction>
{
    public override ViewAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => ViewAggregationFunction.Count,
            "count_distinct" => ViewAggregationFunction.CountDistinct,
            "sum" => ViewAggregationFunction.Sum,
            "average" => ViewAggregationFunction.Average,
            "min" => ViewAggregationFunction.Min,
            "max" => ViewAggregationFunction.Max,
            _ => (ViewAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewAggregationFunction.Count => "count",
                ViewAggregationFunction.CountDistinct => "count_distinct",
                ViewAggregationFunction.Sum => "sum",
                ViewAggregationFunction.Average => "average",
                ViewAggregationFunction.Min => "min",
                ViewAggregationFunction.Max => "max",
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
[JsonConverter(typeof(JsonModelConverter<ViewColumn, ViewColumnFromRaw>))]
public sealed record class ViewColumn : JsonModel
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

    public ViewColumn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewColumn(ViewColumn viewColumn)
        : base(viewColumn) { }
#pragma warning restore CS8618

    public ViewColumn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewColumn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewColumnFromRaw.FromRawUnchecked"/>
    public static ViewColumn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewColumnFromRaw : IFromRawJson<ViewColumn>
{
    /// <inheritdoc/>
    public ViewColumn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ViewColumn.FromRawUnchecked(rawData);
}

/// <summary>
/// A filter to apply to a view column
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ViewFilter, ViewFilterFromRaw>))]
public sealed record class ViewFilter : JsonModel
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
    public required ApiEnum<string, ViewFilterFilterType> FilterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ViewFilterFilterType>>(
                "filterType"
            );
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

    public ViewFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewFilter(ViewFilter viewFilter)
        : base(viewFilter) { }
#pragma warning restore CS8618

    public ViewFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewFilterFromRaw.FromRawUnchecked"/>
    public static ViewFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewFilterFromRaw : IFromRawJson<ViewFilter>
{
    /// <inheritdoc/>
    public ViewFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ViewFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of filter to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewFilterFilterTypeConverter))]
public enum ViewFilterFilterType
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

sealed class ViewFilterFilterTypeConverter : JsonConverter<ViewFilterFilterType>
{
    public override ViewFilterFilterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals_string" => ViewFilterFilterType.EqualsString,
            "equals_number" => ViewFilterFilterType.EqualsNumber,
            "less_than_number" => ViewFilterFilterType.LessThanNumber,
            "less_than_equal_number" => ViewFilterFilterType.LessThanEqualNumber,
            "greater_than_number" => ViewFilterFilterType.GreaterThanNumber,
            "greater_than_equal_number" => ViewFilterFilterType.GreaterThanEqualNumber,
            "is_null" => ViewFilterFilterType.IsNull,
            "is_not_null" => ViewFilterFilterType.IsNotNull,
            _ => (ViewFilterFilterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewFilterFilterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewFilterFilterType.EqualsString => "equals_string",
                ViewFilterFilterType.EqualsNumber => "equals_number",
                ViewFilterFilterType.LessThanNumber => "less_than_number",
                ViewFilterFilterType.LessThanEqualNumber => "less_than_equal_number",
                ViewFilterFilterType.GreaterThanNumber => "greater_than_number",
                ViewFilterFilterType.GreaterThanEqualNumber => "greater_than_equal_number",
                ViewFilterFilterType.IsNull => "is_null",
                ViewFilterFilterType.IsNotNull => "is_not_null",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ViewFunction, ViewFunctionFromRaw>))]
public sealed record class ViewFunction : JsonModel
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

    public ViewFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewFunction(ViewFunction viewFunction)
        : base(viewFunction) { }
#pragma warning restore CS8618

    public ViewFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewFunctionFromRaw.FromRawUnchecked"/>
    public static ViewFunction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewFunctionFromRaw : IFromRawJson<ViewFunction>
{
    /// <inheritdoc/>
    public ViewFunction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ViewFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// Display type of the view
/// </summary>
[JsonConverter(typeof(ViewDisplayTypeConverter))]
public enum ViewDisplayType
{
    Table,
    BarChart,
    PieChart,
}

sealed class ViewDisplayTypeConverter : JsonConverter<ViewDisplayType>
{
    public override ViewDisplayType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "table" => ViewDisplayType.Table,
            "bar_chart" => ViewDisplayType.BarChart,
            "pie_chart" => ViewDisplayType.PieChart,
            _ => (ViewDisplayType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewDisplayType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewDisplayType.Table => "table",
                ViewDisplayType.BarChart => "bar_chart",
                ViewDisplayType.PieChart => "pie_chart",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
