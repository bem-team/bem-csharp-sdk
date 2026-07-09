using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Comparison of metrics between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MetricsComparison, MetricsComparisonFromRaw>))]
public sealed record class MetricsComparison : JsonModel
{
    /// <summary>
    /// Comparison of a single metric between two versions
    /// </summary>
    public MetricComparison? Accuracy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricComparison>("accuracy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accuracy", value);
        }
    }

    /// <summary>
    /// Comparison of a single metric between two versions
    /// </summary>
    public MetricComparison? F1Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricComparison>("f1Score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("f1Score", value);
        }
    }

    /// <summary>
    /// Comparison of a single metric between two versions
    /// </summary>
    public MetricComparison? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricComparison>("precision");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("precision", value);
        }
    }

    /// <summary>
    /// Comparison of a single metric between two versions
    /// </summary>
    public MetricComparison? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricComparison>("recall");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recall", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Accuracy?.Validate();
        this.F1Score?.Validate();
        this.Precision?.Validate();
        this.Recall?.Validate();
    }

    public MetricsComparison() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetricsComparison(MetricsComparison metricsComparison)
        : base(metricsComparison) { }
#pragma warning restore CS8618

    public MetricsComparison(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricsComparison(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricsComparisonFromRaw.FromRawUnchecked"/>
    public static MetricsComparison FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricsComparisonFromRaw : IFromRawJson<MetricsComparison>
{
    /// <inheritdoc/>
    public MetricsComparison FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetricsComparison.FromRawUnchecked(rawData);
}
