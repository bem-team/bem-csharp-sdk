using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MetricComparison, MetricComparisonFromRaw>))]
public sealed record class MetricComparison : JsonModel
{
    /// <summary>
    /// Value in baseline version (null if not available)
    /// </summary>
    public double? BaselineValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("baselineValue");
        }
        init { this._rawData.Set("baselineValue", value); }
    }

    /// <summary>
    /// Value in comparison version (null if not available)
    /// </summary>
    public double? ComparisonValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("comparisonValue");
        }
        init { this._rawData.Set("comparisonValue", value); }
    }

    /// <summary>
    /// Absolute difference (comparisonValue - baselineValue)
    /// </summary>
    public double? Difference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("difference");
        }
        init { this._rawData.Set("difference", value); }
    }

    /// <summary>
    /// **Percentage change from baseline to comparison**
    ///
    /// <para>Formula: ((comparisonValue - baselineValue) / baselineValue) * 100</para>
    ///
    /// <para>- Positive values indicate improvement - Negative values indicate regression</para>
    /// </summary>
    public double? LiftPercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("liftPercent");
        }
        init { this._rawData.Set("liftPercent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BaselineValue;
        _ = this.ComparisonValue;
        _ = this.Difference;
        _ = this.LiftPercent;
    }

    public MetricComparison() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetricComparison(MetricComparison metricComparison)
        : base(metricComparison) { }
#pragma warning restore CS8618

    public MetricComparison(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricComparison(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricComparisonFromRaw.FromRawUnchecked"/>
    public static MetricComparison FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricComparisonFromRaw : IFromRawJson<MetricComparison>
{
    /// <inheritdoc/>
    public MetricComparison FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetricComparison.FromRawUnchecked(rawData);
}
