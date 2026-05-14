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
/// **Update a view. Updates create a new version.**
///
/// <para>The previous version remains addressable and immutable. The new configuration
/// is fully replacing — pass the complete view body, not a patch. The version number
/// is auto-incremented.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ViewUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ViewID { get; init; }

    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<ViewUpdateParamsAggregation> Aggregations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ViewUpdateParamsAggregation>>(
                "aggregations"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewUpdateParamsAggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<ViewUpdateParamsColumn> Columns
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ViewUpdateParamsColumn>>(
                "columns"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewUpdateParamsColumn>>(
                "columns",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of filters applied to the view
    /// </summary>
    public required IReadOnlyList<ViewUpdateParamsFilter> Filters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ViewUpdateParamsFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewUpdateParamsFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<ViewUpdateParamsFunction> Functions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ViewUpdateParamsFunction>>(
                "functions"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ViewUpdateParamsFunction>>(
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

    public ViewUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateParams(ViewUpdateParams viewUpdateParams)
        : base(viewUpdateParams)
    {
        this.ViewID = viewUpdateParams.ViewID;

        this._rawBodyData = new(viewUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ViewUpdateParams(
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
    ViewUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string viewID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ViewID = viewID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ViewUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string viewID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            viewID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ViewID"] = JsonSerializer.SerializeToElement(this.ViewID),
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

    public virtual bool Equals(ViewUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ViewID?.Equals(other.ViewID) ?? other.ViewID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v3/views/{0}", this.ViewID)
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
    typeof(JsonModelConverter<ViewUpdateParamsAggregation, ViewUpdateParamsAggregationFromRaw>)
)]
public sealed record class ViewUpdateParamsAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function to apply to a view column
    /// </summary>
    public required ApiEnum<string, ViewUpdateParamsAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ViewUpdateParamsAggregationFunction>
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

    public ViewUpdateParamsAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateParamsAggregation(ViewUpdateParamsAggregation viewUpdateParamsAggregation)
        : base(viewUpdateParamsAggregation) { }
#pragma warning restore CS8618

    public ViewUpdateParamsAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateParamsAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateParamsAggregationFromRaw.FromRawUnchecked"/>
    public static ViewUpdateParamsAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateParamsAggregationFromRaw : IFromRawJson<ViewUpdateParamsAggregation>
{
    /// <inheritdoc/>
    public ViewUpdateParamsAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewUpdateParamsAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewUpdateParamsAggregationFunctionConverter))]
public enum ViewUpdateParamsAggregationFunction
{
    Count,
    CountDistinct,
    Sum,
    Average,
    Min,
    Max,
}

sealed class ViewUpdateParamsAggregationFunctionConverter
    : JsonConverter<ViewUpdateParamsAggregationFunction>
{
    public override ViewUpdateParamsAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => ViewUpdateParamsAggregationFunction.Count,
            "count_distinct" => ViewUpdateParamsAggregationFunction.CountDistinct,
            "sum" => ViewUpdateParamsAggregationFunction.Sum,
            "average" => ViewUpdateParamsAggregationFunction.Average,
            "min" => ViewUpdateParamsAggregationFunction.Min,
            "max" => ViewUpdateParamsAggregationFunction.Max,
            _ => (ViewUpdateParamsAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewUpdateParamsAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewUpdateParamsAggregationFunction.Count => "count",
                ViewUpdateParamsAggregationFunction.CountDistinct => "count_distinct",
                ViewUpdateParamsAggregationFunction.Sum => "sum",
                ViewUpdateParamsAggregationFunction.Average => "average",
                ViewUpdateParamsAggregationFunction.Min => "min",
                ViewUpdateParamsAggregationFunction.Max => "max",
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
[JsonConverter(typeof(JsonModelConverter<ViewUpdateParamsColumn, ViewUpdateParamsColumnFromRaw>))]
public sealed record class ViewUpdateParamsColumn : JsonModel
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

    public ViewUpdateParamsColumn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateParamsColumn(ViewUpdateParamsColumn viewUpdateParamsColumn)
        : base(viewUpdateParamsColumn) { }
#pragma warning restore CS8618

    public ViewUpdateParamsColumn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateParamsColumn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateParamsColumnFromRaw.FromRawUnchecked"/>
    public static ViewUpdateParamsColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateParamsColumnFromRaw : IFromRawJson<ViewUpdateParamsColumn>
{
    /// <inheritdoc/>
    public ViewUpdateParamsColumn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewUpdateParamsColumn.FromRawUnchecked(rawData);
}

/// <summary>
/// A filter to apply to a view column
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ViewUpdateParamsFilter, ViewUpdateParamsFilterFromRaw>))]
public sealed record class ViewUpdateParamsFilter : JsonModel
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
    public required ApiEnum<string, ViewUpdateParamsFilterFilterType> FilterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ViewUpdateParamsFilterFilterType>>(
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

    public ViewUpdateParamsFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateParamsFilter(ViewUpdateParamsFilter viewUpdateParamsFilter)
        : base(viewUpdateParamsFilter) { }
#pragma warning restore CS8618

    public ViewUpdateParamsFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateParamsFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateParamsFilterFromRaw.FromRawUnchecked"/>
    public static ViewUpdateParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateParamsFilterFromRaw : IFromRawJson<ViewUpdateParamsFilter>
{
    /// <inheritdoc/>
    public ViewUpdateParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewUpdateParamsFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of filter to apply to a view column
/// </summary>
[JsonConverter(typeof(ViewUpdateParamsFilterFilterTypeConverter))]
public enum ViewUpdateParamsFilterFilterType
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

sealed class ViewUpdateParamsFilterFilterTypeConverter
    : JsonConverter<ViewUpdateParamsFilterFilterType>
{
    public override ViewUpdateParamsFilterFilterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals_string" => ViewUpdateParamsFilterFilterType.EqualsString,
            "equals_number" => ViewUpdateParamsFilterFilterType.EqualsNumber,
            "less_than_number" => ViewUpdateParamsFilterFilterType.LessThanNumber,
            "less_than_equal_number" => ViewUpdateParamsFilterFilterType.LessThanEqualNumber,
            "greater_than_number" => ViewUpdateParamsFilterFilterType.GreaterThanNumber,
            "greater_than_equal_number" => ViewUpdateParamsFilterFilterType.GreaterThanEqualNumber,
            "is_null" => ViewUpdateParamsFilterFilterType.IsNull,
            "is_not_null" => ViewUpdateParamsFilterFilterType.IsNotNull,
            _ => (ViewUpdateParamsFilterFilterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewUpdateParamsFilterFilterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewUpdateParamsFilterFilterType.EqualsString => "equals_string",
                ViewUpdateParamsFilterFilterType.EqualsNumber => "equals_number",
                ViewUpdateParamsFilterFilterType.LessThanNumber => "less_than_number",
                ViewUpdateParamsFilterFilterType.LessThanEqualNumber => "less_than_equal_number",
                ViewUpdateParamsFilterFilterType.GreaterThanNumber => "greater_than_number",
                ViewUpdateParamsFilterFilterType.GreaterThanEqualNumber =>
                    "greater_than_equal_number",
                ViewUpdateParamsFilterFilterType.IsNull => "is_null",
                ViewUpdateParamsFilterFilterType.IsNotNull => "is_not_null",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ViewUpdateParamsFunction, ViewUpdateParamsFunctionFromRaw>)
)]
public sealed record class ViewUpdateParamsFunction : JsonModel
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

    public ViewUpdateParamsFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewUpdateParamsFunction(ViewUpdateParamsFunction viewUpdateParamsFunction)
        : base(viewUpdateParamsFunction) { }
#pragma warning restore CS8618

    public ViewUpdateParamsFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewUpdateParamsFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewUpdateParamsFunctionFromRaw.FromRawUnchecked"/>
    public static ViewUpdateParamsFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewUpdateParamsFunctionFromRaw : IFromRawJson<ViewUpdateParamsFunction>
{
    /// <inheritdoc/>
    public ViewUpdateParamsFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewUpdateParamsFunction.FromRawUnchecked(rawData);
}
