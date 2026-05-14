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
[JsonConverter(typeof(JsonModelConverter<ViewUpdateResponse, ViewUpdateResponseFromRaw>))]
public sealed record class ViewUpdateResponse : JsonModel
{
    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<ViewUpdateResponseAggregation> Aggregations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewUpdateResponseAggregation>>(
                "aggregations"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewUpdateResponseAggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<ViewUpdateResponseColumn> Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewUpdateResponseColumn>>(
                "columns"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewUpdateResponseColumn>>(
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
    public required IReadOnlyList<ViewUpdateResponseFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewUpdateResponseFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewUpdateResponseFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<ViewUpdateResponseFunction> Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewUpdateResponseFunction>>(
                "functions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewUpdateResponseFunction>>(
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
    public ApiEnum<string, ViewUpdateResponseDisplayType>? DisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ViewUpdateResponseDisplayType>>(
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

    public ViewUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateResponse(ViewUpdateResponse viewUpdateResponse)
        : base(viewUpdateResponse) { }
#pragma warning restore CS8618

    public ViewUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ViewUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateResponseFromRaw : IFromRawJson<ViewUpdateResponse>
{
    /// <inheritdoc/>
    public ViewUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ViewUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An aggregation definition for a view
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ViewUpdateResponseAggregation, ViewUpdateResponseAggregationFromRaw>)
)]
public sealed record class ViewUpdateResponseAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function to apply to a view column
    /// </summary>
    public required ApiEnum<string, ViewUpdateResponseAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewUpdateResponseAggregationFunction>
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

    public ViewUpdateResponseAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateResponseAggregation(
        ViewUpdateResponseAggregation viewUpdateResponseAggregation
    )
        : base(viewUpdateResponseAggregation) { }
#pragma warning restore CS8618

    public ViewUpdateResponseAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateResponseAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateResponseAggregationFromRaw.FromRawUnchecked"/>
    public static ViewUpdateResponseAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateResponseAggregationFromRaw : IFromRawJson<ViewUpdateResponseAggregation>
{
    /// <inheritdoc/>
    public ViewUpdateResponseAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewUpdateResponseAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewUpdateResponseAggregationFunctionConverter))]
public enum ViewUpdateResponseAggregationFunction
{
    Count,
    CountDistinct,
    Sum,
    Average,
    Min,
    Max,
}

sealed class ViewUpdateResponseAggregationFunctionConverter
    : JsonConverter<ViewUpdateResponseAggregationFunction>
{
    public override ViewUpdateResponseAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => ViewUpdateResponseAggregationFunction.Count,
            "count_distinct" => ViewUpdateResponseAggregationFunction.CountDistinct,
            "sum" => ViewUpdateResponseAggregationFunction.Sum,
            "average" => ViewUpdateResponseAggregationFunction.Average,
            "min" => ViewUpdateResponseAggregationFunction.Min,
            "max" => ViewUpdateResponseAggregationFunction.Max,
            _ => (ViewUpdateResponseAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewUpdateResponseAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewUpdateResponseAggregationFunction.Count => "count",
                ViewUpdateResponseAggregationFunction.CountDistinct => "count_distinct",
                ViewUpdateResponseAggregationFunction.Sum => "sum",
                ViewUpdateResponseAggregationFunction.Average => "average",
                ViewUpdateResponseAggregationFunction.Min => "min",
                ViewUpdateResponseAggregationFunction.Max => "max",
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
    typeof(JsonModelConverter<ViewUpdateResponseColumn, ViewUpdateResponseColumnFromRaw>)
)]
public sealed record class ViewUpdateResponseColumn : JsonModel
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

    public ViewUpdateResponseColumn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateResponseColumn(ViewUpdateResponseColumn viewUpdateResponseColumn)
        : base(viewUpdateResponseColumn) { }
#pragma warning restore CS8618

    public ViewUpdateResponseColumn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateResponseColumn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateResponseColumnFromRaw.FromRawUnchecked"/>
    public static ViewUpdateResponseColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateResponseColumnFromRaw : IFromRawJson<ViewUpdateResponseColumn>
{
    /// <inheritdoc/>
    public ViewUpdateResponseColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewUpdateResponseColumn.FromRawUnchecked(rawData);
}

/// <summary>
/// A filter to apply to a view column
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ViewUpdateResponseFilter, ViewUpdateResponseFilterFromRaw>)
)]
public sealed record class ViewUpdateResponseFilter : JsonModel
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
    public required ApiEnum<string, ViewUpdateResponseFilterFilterType> FilterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewUpdateResponseFilterFilterType>
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

    public ViewUpdateResponseFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateResponseFilter(ViewUpdateResponseFilter viewUpdateResponseFilter)
        : base(viewUpdateResponseFilter) { }
#pragma warning restore CS8618

    public ViewUpdateResponseFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateResponseFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateResponseFilterFromRaw.FromRawUnchecked"/>
    public static ViewUpdateResponseFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateResponseFilterFromRaw : IFromRawJson<ViewUpdateResponseFilter>
{
    /// <inheritdoc/>
    public ViewUpdateResponseFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewUpdateResponseFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of filter to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewUpdateResponseFilterFilterTypeConverter))]
public enum ViewUpdateResponseFilterFilterType
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

sealed class ViewUpdateResponseFilterFilterTypeConverter
    : JsonConverter<ViewUpdateResponseFilterFilterType>
{
    public override ViewUpdateResponseFilterFilterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals_string" => ViewUpdateResponseFilterFilterType.EqualsString,
            "equals_number" => ViewUpdateResponseFilterFilterType.EqualsNumber,
            "less_than_number" => ViewUpdateResponseFilterFilterType.LessThanNumber,
            "less_than_equal_number" => ViewUpdateResponseFilterFilterType.LessThanEqualNumber,
            "greater_than_number" => ViewUpdateResponseFilterFilterType.GreaterThanNumber,
            "greater_than_equal_number" =>
                ViewUpdateResponseFilterFilterType.GreaterThanEqualNumber,
            "is_null" => ViewUpdateResponseFilterFilterType.IsNull,
            "is_not_null" => ViewUpdateResponseFilterFilterType.IsNotNull,
            _ => (ViewUpdateResponseFilterFilterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewUpdateResponseFilterFilterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewUpdateResponseFilterFilterType.EqualsString => "equals_string",
                ViewUpdateResponseFilterFilterType.EqualsNumber => "equals_number",
                ViewUpdateResponseFilterFilterType.LessThanNumber => "less_than_number",
                ViewUpdateResponseFilterFilterType.LessThanEqualNumber => "less_than_equal_number",
                ViewUpdateResponseFilterFilterType.GreaterThanNumber => "greater_than_number",
                ViewUpdateResponseFilterFilterType.GreaterThanEqualNumber =>
                    "greater_than_equal_number",
                ViewUpdateResponseFilterFilterType.IsNull => "is_null",
                ViewUpdateResponseFilterFilterType.IsNotNull => "is_not_null",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ViewUpdateResponseFunction, ViewUpdateResponseFunctionFromRaw>)
)]
public sealed record class ViewUpdateResponseFunction : JsonModel
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

    public ViewUpdateResponseFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateResponseFunction(ViewUpdateResponseFunction viewUpdateResponseFunction)
        : base(viewUpdateResponseFunction) { }
#pragma warning restore CS8618

    public ViewUpdateResponseFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateResponseFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateResponseFunctionFromRaw.FromRawUnchecked"/>
    public static ViewUpdateResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateResponseFunctionFromRaw : IFromRawJson<ViewUpdateResponseFunction>
{
    /// <inheritdoc/>
    public ViewUpdateResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewUpdateResponseFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// Display type of the view
/// </summary>
[JsonConverter(typeof(ViewUpdateResponseDisplayTypeConverter))]
public enum ViewUpdateResponseDisplayType
{
    Table,
    BarChart,
    PieChart,
}

sealed class ViewUpdateResponseDisplayTypeConverter : JsonConverter<ViewUpdateResponseDisplayType>
{
    public override ViewUpdateResponseDisplayType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "table" => ViewUpdateResponseDisplayType.Table,
            "bar_chart" => ViewUpdateResponseDisplayType.BarChart,
            "pie_chart" => ViewUpdateResponseDisplayType.PieChart,
            _ => (ViewUpdateResponseDisplayType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewUpdateResponseDisplayType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewUpdateResponseDisplayType.Table => "table",
                ViewUpdateResponseDisplayType.BarChart => "bar_chart",
                ViewUpdateResponseDisplayType.PieChart => "pie_chart",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
