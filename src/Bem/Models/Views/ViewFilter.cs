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
