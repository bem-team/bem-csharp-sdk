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
[JsonConverter(typeof(JsonModelConverter<ViewCreateResponse, ViewCreateResponseFromRaw>))]
public sealed record class ViewCreateResponse : JsonModel
{
    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<ViewCreateResponseAggregation> Aggregations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewCreateResponseAggregation>>(
                "aggregations"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewCreateResponseAggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<ViewCreateResponseColumn> Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewCreateResponseColumn>>(
                "columns"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewCreateResponseColumn>>(
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
    public required IReadOnlyList<ViewCreateResponseFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewCreateResponseFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewCreateResponseFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<ViewCreateResponseFunction> Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewCreateResponseFunction>>(
                "functions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewCreateResponseFunction>>(
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
    public ApiEnum<string, DisplayType>? DisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DisplayType>>("displayType");
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

    public ViewCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewCreateResponse(ViewCreateResponse viewCreateResponse)
        : base(viewCreateResponse) { }
#pragma warning restore CS8618

    public ViewCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewCreateResponseFromRaw.FromRawUnchecked"/>
    public static ViewCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewCreateResponseFromRaw : IFromRawJson<ViewCreateResponse>
{
    /// <inheritdoc/>
    public ViewCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ViewCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An aggregation definition for a view
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ViewCreateResponseAggregation, ViewCreateResponseAggregationFromRaw>)
)]
public sealed record class ViewCreateResponseAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function to apply to a view column
    /// </summary>
    public required ApiEnum<string, ViewCreateResponseAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewCreateResponseAggregationFunction>
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

    public ViewCreateResponseAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewCreateResponseAggregation(
        ViewCreateResponseAggregation viewCreateResponseAggregation
    )
        : base(viewCreateResponseAggregation) { }
#pragma warning restore CS8618

    public ViewCreateResponseAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewCreateResponseAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewCreateResponseAggregationFromRaw.FromRawUnchecked"/>
    public static ViewCreateResponseAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewCreateResponseAggregationFromRaw : IFromRawJson<ViewCreateResponseAggregation>
{
    /// <inheritdoc/>
    public ViewCreateResponseAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewCreateResponseAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewCreateResponseAggregationFunctionConverter))]
public enum ViewCreateResponseAggregationFunction
{
    Count,
    CountDistinct,
    Sum,
    Average,
    Min,
    Max,
}

sealed class ViewCreateResponseAggregationFunctionConverter
    : JsonConverter<ViewCreateResponseAggregationFunction>
{
    public override ViewCreateResponseAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => ViewCreateResponseAggregationFunction.Count,
            "count_distinct" => ViewCreateResponseAggregationFunction.CountDistinct,
            "sum" => ViewCreateResponseAggregationFunction.Sum,
            "average" => ViewCreateResponseAggregationFunction.Average,
            "min" => ViewCreateResponseAggregationFunction.Min,
            "max" => ViewCreateResponseAggregationFunction.Max,
            _ => (ViewCreateResponseAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewCreateResponseAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewCreateResponseAggregationFunction.Count => "count",
                ViewCreateResponseAggregationFunction.CountDistinct => "count_distinct",
                ViewCreateResponseAggregationFunction.Sum => "sum",
                ViewCreateResponseAggregationFunction.Average => "average",
                ViewCreateResponseAggregationFunction.Min => "min",
                ViewCreateResponseAggregationFunction.Max => "max",
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
    typeof(JsonModelConverter<ViewCreateResponseColumn, ViewCreateResponseColumnFromRaw>)
)]
public sealed record class ViewCreateResponseColumn : JsonModel
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

    public ViewCreateResponseColumn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewCreateResponseColumn(ViewCreateResponseColumn viewCreateResponseColumn)
        : base(viewCreateResponseColumn) { }
#pragma warning restore CS8618

    public ViewCreateResponseColumn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewCreateResponseColumn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewCreateResponseColumnFromRaw.FromRawUnchecked"/>
    public static ViewCreateResponseColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewCreateResponseColumnFromRaw : IFromRawJson<ViewCreateResponseColumn>
{
    /// <inheritdoc/>
    public ViewCreateResponseColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewCreateResponseColumn.FromRawUnchecked(rawData);
}

/// <summary>
/// A filter to apply to a view column
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ViewCreateResponseFilter, ViewCreateResponseFilterFromRaw>)
)]
public sealed record class ViewCreateResponseFilter : JsonModel
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
    public required ApiEnum<string, ViewCreateResponseFilterFilterType> FilterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewCreateResponseFilterFilterType>
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

    public ViewCreateResponseFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewCreateResponseFilter(ViewCreateResponseFilter viewCreateResponseFilter)
        : base(viewCreateResponseFilter) { }
#pragma warning restore CS8618

    public ViewCreateResponseFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewCreateResponseFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewCreateResponseFilterFromRaw.FromRawUnchecked"/>
    public static ViewCreateResponseFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewCreateResponseFilterFromRaw : IFromRawJson<ViewCreateResponseFilter>
{
    /// <inheritdoc/>
    public ViewCreateResponseFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewCreateResponseFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of filter to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewCreateResponseFilterFilterTypeConverter))]
public enum ViewCreateResponseFilterFilterType
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

sealed class ViewCreateResponseFilterFilterTypeConverter
    : JsonConverter<ViewCreateResponseFilterFilterType>
{
    public override ViewCreateResponseFilterFilterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals_string" => ViewCreateResponseFilterFilterType.EqualsString,
            "equals_number" => ViewCreateResponseFilterFilterType.EqualsNumber,
            "less_than_number" => ViewCreateResponseFilterFilterType.LessThanNumber,
            "less_than_equal_number" => ViewCreateResponseFilterFilterType.LessThanEqualNumber,
            "greater_than_number" => ViewCreateResponseFilterFilterType.GreaterThanNumber,
            "greater_than_equal_number" =>
                ViewCreateResponseFilterFilterType.GreaterThanEqualNumber,
            "is_null" => ViewCreateResponseFilterFilterType.IsNull,
            "is_not_null" => ViewCreateResponseFilterFilterType.IsNotNull,
            _ => (ViewCreateResponseFilterFilterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewCreateResponseFilterFilterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewCreateResponseFilterFilterType.EqualsString => "equals_string",
                ViewCreateResponseFilterFilterType.EqualsNumber => "equals_number",
                ViewCreateResponseFilterFilterType.LessThanNumber => "less_than_number",
                ViewCreateResponseFilterFilterType.LessThanEqualNumber => "less_than_equal_number",
                ViewCreateResponseFilterFilterType.GreaterThanNumber => "greater_than_number",
                ViewCreateResponseFilterFilterType.GreaterThanEqualNumber =>
                    "greater_than_equal_number",
                ViewCreateResponseFilterFilterType.IsNull => "is_null",
                ViewCreateResponseFilterFilterType.IsNotNull => "is_not_null",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ViewCreateResponseFunction, ViewCreateResponseFunctionFromRaw>)
)]
public sealed record class ViewCreateResponseFunction : JsonModel
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

    public ViewCreateResponseFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewCreateResponseFunction(ViewCreateResponseFunction viewCreateResponseFunction)
        : base(viewCreateResponseFunction) { }
#pragma warning restore CS8618

    public ViewCreateResponseFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewCreateResponseFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewCreateResponseFunctionFromRaw.FromRawUnchecked"/>
    public static ViewCreateResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewCreateResponseFunctionFromRaw : IFromRawJson<ViewCreateResponseFunction>
{
    /// <inheritdoc/>
    public ViewCreateResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewCreateResponseFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// Display type of the view
/// </summary>
[JsonConverter(typeof(DisplayTypeConverter))]
public enum DisplayType
{
    Table,
    BarChart,
    PieChart,
}

sealed class DisplayTypeConverter : JsonConverter<DisplayType>
{
    public override DisplayType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "table" => DisplayType.Table,
            "bar_chart" => DisplayType.BarChart,
            "pie_chart" => DisplayType.PieChart,
            _ => (DisplayType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisplayType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisplayType.Table => "table",
                DisplayType.BarChart => "bar_chart",
                DisplayType.PieChart => "pie_chart",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
