using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Views;

/// <summary>
/// An aggregation definition for a view
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ViewAggregation, ViewAggregationFromRaw>))]
public sealed record class ViewAggregation : JsonModel
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
    /// How to display the aggregation results
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
        this.DisplayType?.Validate();
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
/// How to display the aggregation results
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
