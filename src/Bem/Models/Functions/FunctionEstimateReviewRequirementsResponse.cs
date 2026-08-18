using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Response containing review requirements estimate
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionEstimateReviewRequirementsResponse,
        FunctionEstimateReviewRequirementsResponseFromRaw
    >)
)]
public sealed record class FunctionEstimateReviewRequirementsResponse : JsonModel
{
    /// <summary>
    /// Detailed review requirements estimate
    /// </summary>
    public required Estimate Estimate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Estimate>("estimate");
        }
        init { this._rawData.Set("estimate", value); }
    }

    /// <summary>
    /// Name of the analyzed function
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
    /// Version number of the function that was analyzed
    /// </summary>
    public required long FunctionVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("functionVersionNum");
        }
        init { this._rawData.Set("functionVersionNum", value); }
    }

    /// <summary>
    /// Detailed performance metrics and analysis
    /// </summary>
    public MetricsDetails? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricsDetails>("metrics");
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
        this.Estimate.Validate();
        _ = this.FunctionName;
        _ = this.FunctionVersionNum;
        this.Metrics?.Validate();
    }

    public FunctionEstimateReviewRequirementsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionEstimateReviewRequirementsResponse(
        FunctionEstimateReviewRequirementsResponse functionEstimateReviewRequirementsResponse
    )
        : base(functionEstimateReviewRequirementsResponse) { }
#pragma warning restore CS8618

    public FunctionEstimateReviewRequirementsResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionEstimateReviewRequirementsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionEstimateReviewRequirementsResponseFromRaw.FromRawUnchecked"/>
    public static FunctionEstimateReviewRequirementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionEstimateReviewRequirementsResponseFromRaw
    : IFromRawJson<FunctionEstimateReviewRequirementsResponse>
{
    /// <inheritdoc/>
    public FunctionEstimateReviewRequirementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionEstimateReviewRequirementsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Detailed review requirements estimate
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Estimate, EstimateFromRaw>))]
public sealed record class Estimate : JsonModel
{
    /// <summary>
    /// Distribution of confidence levels
    /// </summary>
    public required ConfidenceDistribution ConfidenceDistribution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConfidenceDistribution>("confidenceDistribution");
        }
        init { this._rawData.Set("confidenceDistribution", value); }
    }

    /// <summary>
    /// Number of transformations already labeled
    /// </summary>
    public required long LabeledTransformations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("labeledTransformations");
        }
        init { this._rawData.Set("labeledTransformations", value); }
    }

    /// <summary>
    /// Number of transformations without evaluation data
    /// </summary>
    public required long MissingEvaluations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("missingEvaluations");
        }
        init { this._rawData.Set("missingEvaluations", value); }
    }

    /// <summary>
    /// Statistical analysis across confidence thresholds
    /// </summary>
    public required IReadOnlyList<ThresholdMatrix> ThresholdMatrix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ThresholdMatrix>>(
                "thresholdMatrix"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ThresholdMatrix>>(
                "thresholdMatrix",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total number of transformations analyzed
    /// </summary>
    public required long TotalTransformations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalTransformations");
        }
        init { this._rawData.Set("totalTransformations", value); }
    }

    /// <summary>
    /// Number of transformations not yet labeled
    /// </summary>
    public required long UnlabeledTransformations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("unlabeledTransformations");
        }
        init { this._rawData.Set("unlabeledTransformations", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ConfidenceDistribution.Validate();
        _ = this.LabeledTransformations;
        _ = this.MissingEvaluations;
        foreach (var item in this.ThresholdMatrix)
        {
            item.Validate();
        }
        _ = this.TotalTransformations;
        _ = this.UnlabeledTransformations;
    }

    public Estimate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Estimate(Estimate estimate)
        : base(estimate) { }
#pragma warning restore CS8618

    public Estimate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Estimate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EstimateFromRaw.FromRawUnchecked"/>
    public static Estimate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EstimateFromRaw : IFromRawJson<Estimate>
{
    /// <inheritdoc/>
    public Estimate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Estimate.FromRawUnchecked(rawData);
}

/// <summary>
/// Distribution of confidence levels
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConfidenceDistribution, ConfidenceDistributionFromRaw>))]
public sealed record class ConfidenceDistribution : JsonModel
{
    public long? High
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("high");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("high", value);
        }
    }

    public long? Low
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("low");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("low", value);
        }
    }

    public long? Medium
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("medium");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("medium", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.High;
        _ = this.Low;
        _ = this.Medium;
    }

    public ConfidenceDistribution() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfidenceDistribution(ConfidenceDistribution confidenceDistribution)
        : base(confidenceDistribution) { }
#pragma warning restore CS8618

    public ConfidenceDistribution(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfidenceDistribution(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfidenceDistributionFromRaw.FromRawUnchecked"/>
    public static ConfidenceDistribution FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfidenceDistributionFromRaw : IFromRawJson<ConfidenceDistribution>
{
    /// <inheritdoc/>
    public ConfidenceDistribution FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConfidenceDistribution.FromRawUnchecked(rawData);
}

/// <summary>
/// Results for a specific confidence threshold analysis
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThresholdMatrix, ThresholdMatrixFromRaw>))]
public sealed record class ThresholdMatrix : JsonModel
{
    /// <summary>
    /// False Negatives
    /// </summary>
    public required long Fn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fn");
        }
        init { this._rawData.Set("fn", value); }
    }

    /// <summary>
    /// False Positives
    /// </summary>
    public required long Fp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fp");
        }
        init { this._rawData.Set("fp", value); }
    }

    /// <summary>
    /// Confidence threshold value
    /// </summary>
    public required float Threshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>("threshold");
        }
        init { this._rawData.Set("threshold", value); }
    }

    /// <summary>
    /// True Negatives
    /// </summary>
    public required long Tn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tn");
        }
        init { this._rawData.Set("tn", value); }
    }

    /// <summary>
    /// True Positives
    /// </summary>
    public required long Tp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tp");
        }
        init { this._rawData.Set("tp", value); }
    }

    /// <summary>
    /// Accuracy confidence intervals for samples above threshold, by confidence level.
    /// Keys are confidence levels as strings ("90", "95", "99"). Values contain statistical
    /// confidence intervals.
    /// </summary>
    public IReadOnlyDictionary<string, RateConfidenceInterval>? AccuracyAboveThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, RateConfidenceInterval>>(
                "accuracyAboveThreshold"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, RateConfidenceInterval>?>(
                "accuracyAboveThreshold",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// False Discovery Rate confidence intervals by confidence level. Keys are confidence
    /// levels as strings ("90", "95", "99"). Values contain statistical confidence intervals.
    /// </summary>
    public IReadOnlyDictionary<string, RateConfidenceInterval>? FalseDiscoveryRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, RateConfidenceInterval>>(
                "falseDiscoveryRate"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, RateConfidenceInterval>?>(
                "falseDiscoveryRate",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// False Positive Rate confidence intervals by confidence level. Keys are confidence
    /// levels as strings ("90", "95", "99"). Values contain statistical confidence intervals.
    /// </summary>
    public IReadOnlyDictionary<string, RateConfidenceInterval>? FalsePositiveRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, RateConfidenceInterval>>(
                "falsePositiveRate"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, RateConfidenceInterval>?>(
                "falsePositiveRate",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Precision confidence intervals by confidence level. Keys are confidence levels
    /// as strings ("90", "95", "99"). Values contain statistical confidence intervals.
    /// </summary>
    public IReadOnlyDictionary<string, RateConfidenceInterval>? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, RateConfidenceInterval>>(
                "precision"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, RateConfidenceInterval>?>(
                "precision",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Recall confidence intervals by confidence level. Keys are confidence levels
    /// as strings ("90", "95", "99"). Values contain statistical confidence intervals.
    /// </summary>
    public IReadOnlyDictionary<string, RateConfidenceInterval>? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, RateConfidenceInterval>>(
                "recall"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, RateConfidenceInterval>?>(
                "recall",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Fn;
        _ = this.Fp;
        _ = this.Threshold;
        _ = this.Tn;
        _ = this.Tp;
        if (this.AccuracyAboveThreshold != null)
        {
            foreach (var item in this.AccuracyAboveThreshold.Values)
            {
                item.Validate();
            }
        }
        if (this.FalseDiscoveryRate != null)
        {
            foreach (var item in this.FalseDiscoveryRate.Values)
            {
                item.Validate();
            }
        }
        if (this.FalsePositiveRate != null)
        {
            foreach (var item in this.FalsePositiveRate.Values)
            {
                item.Validate();
            }
        }
        if (this.Precision != null)
        {
            foreach (var item in this.Precision.Values)
            {
                item.Validate();
            }
        }
        if (this.Recall != null)
        {
            foreach (var item in this.Recall.Values)
            {
                item.Validate();
            }
        }
    }

    public ThresholdMatrix() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThresholdMatrix(ThresholdMatrix thresholdMatrix)
        : base(thresholdMatrix) { }
#pragma warning restore CS8618

    public ThresholdMatrix(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdMatrix(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThresholdMatrixFromRaw.FromRawUnchecked"/>
    public static ThresholdMatrix FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThresholdMatrixFromRaw : IFromRawJson<ThresholdMatrix>
{
    /// <inheritdoc/>
    public ThresholdMatrix FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThresholdMatrix.FromRawUnchecked(rawData);
}
