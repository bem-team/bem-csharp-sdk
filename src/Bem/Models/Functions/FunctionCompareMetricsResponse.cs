using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// **Response containing metrics comparison between two function versions**
///
/// <para>Shows absolute differences, lift percentages, and field-level changes.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionCompareMetricsResponse,
        FunctionCompareMetricsResponseFromRaw
    >)
)]
public sealed record class FunctionCompareMetricsResponse : JsonModel
{
    /// <summary>
    /// Baseline version number used for comparison
    /// </summary>
    public required long BaselineVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("baselineVersionNum");
        }
        init { this._rawData.Set("baselineVersionNum", value); }
    }

    /// <summary>
    /// Comparison version number
    /// </summary>
    public required long ComparisonVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("comparisonVersionNum");
        }
        init { this._rawData.Set("comparisonVersionNum", value); }
    }

    /// <summary>
    /// Name of the compared function
    /// </summary>
    public required string FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionName");
        }
        init { this._rawData.Set("functionName", value); }
    }

    /// <summary>
    /// Comparison of metrics between two versions
    /// </summary>
    public MetricsComparison? AggregateComparison
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricsComparison>("aggregateComparison");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aggregateComparison", value);
        }
    }

    /// <summary>
    /// Detailed performance metrics and analysis
    /// </summary>
    public MetricsDetails? BaselineMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricsDetails>("baselineMetrics");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baselineMetrics", value);
        }
    }

    /// <summary>
    /// Number of transformations used to calculate baseline metrics
    /// </summary>
    public long? BaselineTransformationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("baselineTransformationCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baselineTransformationCount", value);
        }
    }

    /// <summary>
    /// Detailed performance metrics and analysis
    /// </summary>
    public MetricsDetails? ComparisonMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricsDetails>("comparisonMetrics");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("comparisonMetrics", value);
        }
    }

    /// <summary>
    /// Number of transformations used to calculate comparison metrics
    /// </summary>
    public long? ComparisonTransformationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("comparisonTransformationCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("comparisonTransformationCount", value);
        }
    }

    /// <summary>
    /// **Field-level metrics that changed significantly**
    ///
    /// <para>Only includes fields where metrics changed by more than 1%.</para>
    /// </summary>
    public IReadOnlyList<FieldMetricsChange>? FieldMetricsChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FieldMetricsChange>>(
                "fieldMetricsChanges"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FieldMetricsChange>?>(
                "fieldMetricsChanges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional message with additional details
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BaselineVersionNum;
        _ = this.ComparisonVersionNum;
        _ = this.FunctionName;
        this.AggregateComparison?.Validate();
        this.BaselineMetrics?.Validate();
        _ = this.BaselineTransformationCount;
        this.ComparisonMetrics?.Validate();
        _ = this.ComparisonTransformationCount;
        foreach (var item in this.FieldMetricsChanges ?? [])
        {
            item.Validate();
        }
        _ = this.Message;
    }

    public FunctionCompareMetricsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionCompareMetricsResponse(
        FunctionCompareMetricsResponse functionCompareMetricsResponse
    )
        : base(functionCompareMetricsResponse) { }
#pragma warning restore CS8618

    public FunctionCompareMetricsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionCompareMetricsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionCompareMetricsResponseFromRaw.FromRawUnchecked"/>
    public static FunctionCompareMetricsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionCompareMetricsResponseFromRaw : IFromRawJson<FunctionCompareMetricsResponse>
{
    /// <inheritdoc/>
    public FunctionCompareMetricsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionCompareMetricsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of field-level metrics
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FieldMetricsChange, FieldMetricsChangeFromRaw>))]
public sealed record class FieldMetricsChange : JsonModel
{
    /// <summary>
    /// Comparison of metrics between two versions
    /// </summary>
    public required MetricsComparison Comparison
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MetricsComparison>("comparison");
        }
        init { this._rawData.Set("comparison", value); }
    }

    /// <summary>
    /// JSON pointer path to the field
    /// </summary>
    public required string FieldPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fieldPath");
        }
        init { this._rawData.Set("fieldPath", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Comparison.Validate();
        _ = this.FieldPath;
    }

    public FieldMetricsChange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FieldMetricsChange(FieldMetricsChange fieldMetricsChange)
        : base(fieldMetricsChange) { }
#pragma warning restore CS8618

    public FieldMetricsChange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FieldMetricsChange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FieldMetricsChangeFromRaw.FromRawUnchecked"/>
    public static FieldMetricsChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FieldMetricsChangeFromRaw : IFromRawJson<FieldMetricsChange>
{
    /// <inheritdoc/>
    public FieldMetricsChange FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FieldMetricsChange.FromRawUnchecked(rawData);
}
