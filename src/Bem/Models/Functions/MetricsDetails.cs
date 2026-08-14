using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Detailed performance metrics and analysis
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MetricsDetails, MetricsDetailsFromRaw>))]
public sealed record class MetricsDetails : JsonModel
{
    /// <summary>
    /// Comprehensive performance metrics
    /// </summary>
    public Metrics? AggregateMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metrics>("aggregateMetrics");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aggregateMetrics", value);
        }
    }

    /// <summary>
    /// Enhanced field metrics with comprehensive analytics
    /// </summary>
    public IReadOnlyList<FieldMetric>? FieldMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FieldMetric>>("fieldMetrics");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FieldMetric>?>(
                "fieldMetrics",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Area Under the Precision-Recall Curve
    /// </summary>
    public float? PrecisionRecallAuc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("precisionRecallAuc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("precisionRecallAuc", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AggregateMetrics?.Validate();
        foreach (var item in this.FieldMetrics ?? [])
        {
            item.Validate();
        }
        _ = this.PrecisionRecallAuc;
    }

    public MetricsDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetricsDetails(MetricsDetails metricsDetails)
        : base(metricsDetails) { }
#pragma warning restore CS8618

    public MetricsDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricsDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricsDetailsFromRaw.FromRawUnchecked"/>
    public static MetricsDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricsDetailsFromRaw : IFromRawJson<MetricsDetails>
{
    /// <inheritdoc/>
    public MetricsDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetricsDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// Enhanced field metrics with comprehensive analytics
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FieldMetric, FieldMetricFromRaw>))]
public sealed record class FieldMetric : JsonModel
{
    /// <summary>
    /// JSON path to the field
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

    /// <summary>
    /// Comprehensive performance metrics
    /// </summary>
    public Metrics? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metrics>("metrics");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metrics", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FieldPath;
        this.Metrics?.Validate();
    }

    public FieldMetric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FieldMetric(FieldMetric fieldMetric)
        : base(fieldMetric) { }
#pragma warning restore CS8618

    public FieldMetric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FieldMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FieldMetricFromRaw.FromRawUnchecked"/>
    public static FieldMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FieldMetric(string fieldPath)
        : this()
    {
        this.FieldPath = fieldPath;
    }
}

class FieldMetricFromRaw : IFromRawJson<FieldMetric>
{
    /// <inheritdoc/>
    public FieldMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FieldMetric.FromRawUnchecked(rawData);
}
