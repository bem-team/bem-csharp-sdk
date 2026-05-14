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
    public FunctionEstimateReviewRequirementsResponseMetrics? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionEstimateReviewRequirementsResponseMetrics>(
                "metrics"
            );
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
    public AccuracyAboveThreshold? AccuracyAboveThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccuracyAboveThreshold>("accuracyAboveThreshold");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accuracyAboveThreshold", value);
        }
    }

    /// <summary>
    /// False Discovery Rate confidence intervals by confidence level. Keys are confidence
    /// levels as strings ("90", "95", "99"). Values contain statistical confidence intervals.
    /// </summary>
    public FalseDiscoveryRate? FalseDiscoveryRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FalseDiscoveryRate>("falseDiscoveryRate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("falseDiscoveryRate", value);
        }
    }

    /// <summary>
    /// False Positive Rate confidence intervals by confidence level. Keys are confidence
    /// levels as strings ("90", "95", "99"). Values contain statistical confidence intervals.
    /// </summary>
    public FalsePositiveRate? FalsePositiveRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FalsePositiveRate>("falsePositiveRate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("falsePositiveRate", value);
        }
    }

    /// <summary>
    /// Precision confidence intervals by confidence level. Keys are confidence levels
    /// as strings ("90", "95", "99"). Values contain statistical confidence intervals.
    /// </summary>
    public ThresholdMatrixPrecision? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThresholdMatrixPrecision>("precision");
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
    /// Recall confidence intervals by confidence level. Keys are confidence levels
    /// as strings ("90", "95", "99"). Values contain statistical confidence intervals.
    /// </summary>
    public ThresholdMatrixRecall? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThresholdMatrixRecall>("recall");
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
        _ = this.Fn;
        _ = this.Fp;
        _ = this.Threshold;
        _ = this.Tn;
        _ = this.Tp;
        this.AccuracyAboveThreshold?.Validate();
        this.FalseDiscoveryRate?.Validate();
        this.FalsePositiveRate?.Validate();
        this.Precision?.Validate();
        this.Recall?.Validate();
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

/// <summary>
/// Accuracy confidence intervals for samples above threshold, by confidence level.
/// Keys are confidence levels as strings ("90", "95", "99"). Values contain statistical
/// confidence intervals.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccuracyAboveThreshold, AccuracyAboveThresholdFromRaw>))]
public sealed record class AccuracyAboveThreshold : JsonModel
{
    /// <summary>
    /// Confidence interval for a rate/proportion using Wald (normal approximation)
    /// method by default.
    ///
    /// <para>Wald confidence intervals use the normal approximation to the binomial
    /// distribution. For extreme rates or small sample sizes, Wilson confidence
    /// intervals may be more appropriate.</para>
    /// </summary>
    public V95? A95
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V95>("95");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("95", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.A95?.Validate();
    }

    public AccuracyAboveThreshold() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccuracyAboveThreshold(AccuracyAboveThreshold accuracyAboveThreshold)
        : base(accuracyAboveThreshold) { }
#pragma warning restore CS8618

    public AccuracyAboveThreshold(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccuracyAboveThreshold(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccuracyAboveThresholdFromRaw.FromRawUnchecked"/>
    public static AccuracyAboveThreshold FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccuracyAboveThresholdFromRaw : IFromRawJson<AccuracyAboveThreshold>
{
    /// <inheritdoc/>
    public AccuracyAboveThreshold FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccuracyAboveThreshold.FromRawUnchecked(rawData);
}

/// <summary>
/// Confidence interval for a rate/proportion using Wald (normal approximation) method
/// by default.
///
/// <para>Wald confidence intervals use the normal approximation to the binomial
/// distribution. For extreme rates or small sample sizes, Wilson confidence intervals
/// may be more appropriate.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<V95, V95FromRaw>))]
public sealed record class V95 : JsonModel
{
    /// <summary>
    /// Current number of samples/observations available
    /// </summary>
    public required long CurrentSample
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("currentSample");
        }
        init { this._rawData.Set("currentSample", value); }
    }

    /// <summary>
    /// Minimum number of samples needed for reliable confidence interval calculation
    /// </summary>
    public required long SampleNeeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sampleNeeded");
        }
        init { this._rawData.Set("sampleNeeded", value); }
    }

    /// <summary>
    /// Lower bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiLower
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciLower");
        }
        init { this._rawData.Set("ciLower", value); }
    }

    /// <summary>
    /// Upper bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiUpper
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciUpper");
        }
        init { this._rawData.Set("ciUpper", value); }
    }

    /// <summary>
    /// Point estimate (observed rate) at the center of the interval (null if insufficient
    /// sample size)
    /// </summary>
    public float? Mid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("mid");
        }
        init { this._rawData.Set("mid", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrentSample;
        _ = this.SampleNeeded;
        _ = this.CiLower;
        _ = this.CiUpper;
        _ = this.Mid;
    }

    public V95() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V95(V95 v95)
        : base(v95) { }
#pragma warning restore CS8618

    public V95(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V95(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V95FromRaw.FromRawUnchecked"/>
    public static V95 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V95FromRaw : IFromRawJson<V95>
{
    /// <inheritdoc/>
    public V95 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V95.FromRawUnchecked(rawData);
}

/// <summary>
/// False Discovery Rate confidence intervals by confidence level. Keys are confidence
/// levels as strings ("90", "95", "99"). Values contain statistical confidence intervals.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FalseDiscoveryRate, FalseDiscoveryRateFromRaw>))]
public sealed record class FalseDiscoveryRate : JsonModel
{
    /// <summary>
    /// Confidence interval for a rate/proportion using Wald (normal approximation)
    /// method by default.
    ///
    /// <para>Wald confidence intervals use the normal approximation to the binomial
    /// distribution. For extreme rates or small sample sizes, Wilson confidence
    /// intervals may be more appropriate.</para>
    /// </summary>
    public FalseDiscoveryRateV95? F95
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FalseDiscoveryRateV95>("95");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("95", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.F95?.Validate();
    }

    public FalseDiscoveryRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FalseDiscoveryRate(FalseDiscoveryRate falseDiscoveryRate)
        : base(falseDiscoveryRate) { }
#pragma warning restore CS8618

    public FalseDiscoveryRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FalseDiscoveryRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FalseDiscoveryRateFromRaw.FromRawUnchecked"/>
    public static FalseDiscoveryRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FalseDiscoveryRateFromRaw : IFromRawJson<FalseDiscoveryRate>
{
    /// <inheritdoc/>
    public FalseDiscoveryRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FalseDiscoveryRate.FromRawUnchecked(rawData);
}

/// <summary>
/// Confidence interval for a rate/proportion using Wald (normal approximation) method
/// by default.
///
/// <para>Wald confidence intervals use the normal approximation to the binomial
/// distribution. For extreme rates or small sample sizes, Wilson confidence intervals
/// may be more appropriate.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FalseDiscoveryRateV95, FalseDiscoveryRateV95FromRaw>))]
public sealed record class FalseDiscoveryRateV95 : JsonModel
{
    /// <summary>
    /// Current number of samples/observations available
    /// </summary>
    public required long CurrentSample
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("currentSample");
        }
        init { this._rawData.Set("currentSample", value); }
    }

    /// <summary>
    /// Minimum number of samples needed for reliable confidence interval calculation
    /// </summary>
    public required long SampleNeeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sampleNeeded");
        }
        init { this._rawData.Set("sampleNeeded", value); }
    }

    /// <summary>
    /// Lower bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiLower
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciLower");
        }
        init { this._rawData.Set("ciLower", value); }
    }

    /// <summary>
    /// Upper bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiUpper
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciUpper");
        }
        init { this._rawData.Set("ciUpper", value); }
    }

    /// <summary>
    /// Point estimate (observed rate) at the center of the interval (null if insufficient
    /// sample size)
    /// </summary>
    public float? Mid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("mid");
        }
        init { this._rawData.Set("mid", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrentSample;
        _ = this.SampleNeeded;
        _ = this.CiLower;
        _ = this.CiUpper;
        _ = this.Mid;
    }

    public FalseDiscoveryRateV95() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FalseDiscoveryRateV95(FalseDiscoveryRateV95 falseDiscoveryRateV95)
        : base(falseDiscoveryRateV95) { }
#pragma warning restore CS8618

    public FalseDiscoveryRateV95(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FalseDiscoveryRateV95(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FalseDiscoveryRateV95FromRaw.FromRawUnchecked"/>
    public static FalseDiscoveryRateV95 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FalseDiscoveryRateV95FromRaw : IFromRawJson<FalseDiscoveryRateV95>
{
    /// <inheritdoc/>
    public FalseDiscoveryRateV95 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FalseDiscoveryRateV95.FromRawUnchecked(rawData);
}

/// <summary>
/// False Positive Rate confidence intervals by confidence level. Keys are confidence
/// levels as strings ("90", "95", "99"). Values contain statistical confidence intervals.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FalsePositiveRate, FalsePositiveRateFromRaw>))]
public sealed record class FalsePositiveRate : JsonModel
{
    /// <summary>
    /// Confidence interval for a rate/proportion using Wald (normal approximation)
    /// method by default.
    ///
    /// <para>Wald confidence intervals use the normal approximation to the binomial
    /// distribution. For extreme rates or small sample sizes, Wilson confidence
    /// intervals may be more appropriate.</para>
    /// </summary>
    public FalsePositiveRateV95? F95
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FalsePositiveRateV95>("95");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("95", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.F95?.Validate();
    }

    public FalsePositiveRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FalsePositiveRate(FalsePositiveRate falsePositiveRate)
        : base(falsePositiveRate) { }
#pragma warning restore CS8618

    public FalsePositiveRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FalsePositiveRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FalsePositiveRateFromRaw.FromRawUnchecked"/>
    public static FalsePositiveRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FalsePositiveRateFromRaw : IFromRawJson<FalsePositiveRate>
{
    /// <inheritdoc/>
    public FalsePositiveRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FalsePositiveRate.FromRawUnchecked(rawData);
}

/// <summary>
/// Confidence interval for a rate/proportion using Wald (normal approximation) method
/// by default.
///
/// <para>Wald confidence intervals use the normal approximation to the binomial
/// distribution. For extreme rates or small sample sizes, Wilson confidence intervals
/// may be more appropriate.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FalsePositiveRateV95, FalsePositiveRateV95FromRaw>))]
public sealed record class FalsePositiveRateV95 : JsonModel
{
    /// <summary>
    /// Current number of samples/observations available
    /// </summary>
    public required long CurrentSample
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("currentSample");
        }
        init { this._rawData.Set("currentSample", value); }
    }

    /// <summary>
    /// Minimum number of samples needed for reliable confidence interval calculation
    /// </summary>
    public required long SampleNeeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sampleNeeded");
        }
        init { this._rawData.Set("sampleNeeded", value); }
    }

    /// <summary>
    /// Lower bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiLower
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciLower");
        }
        init { this._rawData.Set("ciLower", value); }
    }

    /// <summary>
    /// Upper bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiUpper
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciUpper");
        }
        init { this._rawData.Set("ciUpper", value); }
    }

    /// <summary>
    /// Point estimate (observed rate) at the center of the interval (null if insufficient
    /// sample size)
    /// </summary>
    public float? Mid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("mid");
        }
        init { this._rawData.Set("mid", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrentSample;
        _ = this.SampleNeeded;
        _ = this.CiLower;
        _ = this.CiUpper;
        _ = this.Mid;
    }

    public FalsePositiveRateV95() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FalsePositiveRateV95(FalsePositiveRateV95 falsePositiveRateV95)
        : base(falsePositiveRateV95) { }
#pragma warning restore CS8618

    public FalsePositiveRateV95(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FalsePositiveRateV95(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FalsePositiveRateV95FromRaw.FromRawUnchecked"/>
    public static FalsePositiveRateV95 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FalsePositiveRateV95FromRaw : IFromRawJson<FalsePositiveRateV95>
{
    /// <inheritdoc/>
    public FalsePositiveRateV95 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FalsePositiveRateV95.FromRawUnchecked(rawData);
}

/// <summary>
/// Precision confidence intervals by confidence level. Keys are confidence levels
/// as strings ("90", "95", "99"). Values contain statistical confidence intervals.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ThresholdMatrixPrecision, ThresholdMatrixPrecisionFromRaw>)
)]
public sealed record class ThresholdMatrixPrecision : JsonModel
{
    /// <summary>
    /// Confidence interval for a rate/proportion using Wald (normal approximation)
    /// method by default.
    ///
    /// <para>Wald confidence intervals use the normal approximation to the binomial
    /// distribution. For extreme rates or small sample sizes, Wilson confidence
    /// intervals may be more appropriate.</para>
    /// </summary>
    public ThresholdMatrixPrecisionV95? P95
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThresholdMatrixPrecisionV95>("95");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("95", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.P95?.Validate();
    }

    public ThresholdMatrixPrecision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThresholdMatrixPrecision(ThresholdMatrixPrecision thresholdMatrixPrecision)
        : base(thresholdMatrixPrecision) { }
#pragma warning restore CS8618

    public ThresholdMatrixPrecision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdMatrixPrecision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThresholdMatrixPrecisionFromRaw.FromRawUnchecked"/>
    public static ThresholdMatrixPrecision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThresholdMatrixPrecisionFromRaw : IFromRawJson<ThresholdMatrixPrecision>
{
    /// <inheritdoc/>
    public ThresholdMatrixPrecision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThresholdMatrixPrecision.FromRawUnchecked(rawData);
}

/// <summary>
/// Confidence interval for a rate/proportion using Wald (normal approximation) method
/// by default.
///
/// <para>Wald confidence intervals use the normal approximation to the binomial
/// distribution. For extreme rates or small sample sizes, Wilson confidence intervals
/// may be more appropriate.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ThresholdMatrixPrecisionV95, ThresholdMatrixPrecisionV95FromRaw>)
)]
public sealed record class ThresholdMatrixPrecisionV95 : JsonModel
{
    /// <summary>
    /// Current number of samples/observations available
    /// </summary>
    public required long CurrentSample
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("currentSample");
        }
        init { this._rawData.Set("currentSample", value); }
    }

    /// <summary>
    /// Minimum number of samples needed for reliable confidence interval calculation
    /// </summary>
    public required long SampleNeeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sampleNeeded");
        }
        init { this._rawData.Set("sampleNeeded", value); }
    }

    /// <summary>
    /// Lower bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiLower
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciLower");
        }
        init { this._rawData.Set("ciLower", value); }
    }

    /// <summary>
    /// Upper bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiUpper
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciUpper");
        }
        init { this._rawData.Set("ciUpper", value); }
    }

    /// <summary>
    /// Point estimate (observed rate) at the center of the interval (null if insufficient
    /// sample size)
    /// </summary>
    public float? Mid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("mid");
        }
        init { this._rawData.Set("mid", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrentSample;
        _ = this.SampleNeeded;
        _ = this.CiLower;
        _ = this.CiUpper;
        _ = this.Mid;
    }

    public ThresholdMatrixPrecisionV95() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThresholdMatrixPrecisionV95(ThresholdMatrixPrecisionV95 thresholdMatrixPrecisionV95)
        : base(thresholdMatrixPrecisionV95) { }
#pragma warning restore CS8618

    public ThresholdMatrixPrecisionV95(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdMatrixPrecisionV95(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThresholdMatrixPrecisionV95FromRaw.FromRawUnchecked"/>
    public static ThresholdMatrixPrecisionV95 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThresholdMatrixPrecisionV95FromRaw : IFromRawJson<ThresholdMatrixPrecisionV95>
{
    /// <inheritdoc/>
    public ThresholdMatrixPrecisionV95 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThresholdMatrixPrecisionV95.FromRawUnchecked(rawData);
}

/// <summary>
/// Recall confidence intervals by confidence level. Keys are confidence levels as
/// strings ("90", "95", "99"). Values contain statistical confidence intervals.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThresholdMatrixRecall, ThresholdMatrixRecallFromRaw>))]
public sealed record class ThresholdMatrixRecall : JsonModel
{
    /// <summary>
    /// Confidence interval for a rate/proportion using Wald (normal approximation)
    /// method by default.
    ///
    /// <para>Wald confidence intervals use the normal approximation to the binomial
    /// distribution. For extreme rates or small sample sizes, Wilson confidence
    /// intervals may be more appropriate.</para>
    /// </summary>
    public ThresholdMatrixRecallV95? R95
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThresholdMatrixRecallV95>("95");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("95", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.R95?.Validate();
    }

    public ThresholdMatrixRecall() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThresholdMatrixRecall(ThresholdMatrixRecall thresholdMatrixRecall)
        : base(thresholdMatrixRecall) { }
#pragma warning restore CS8618

    public ThresholdMatrixRecall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdMatrixRecall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThresholdMatrixRecallFromRaw.FromRawUnchecked"/>
    public static ThresholdMatrixRecall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThresholdMatrixRecallFromRaw : IFromRawJson<ThresholdMatrixRecall>
{
    /// <inheritdoc/>
    public ThresholdMatrixRecall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThresholdMatrixRecall.FromRawUnchecked(rawData);
}

/// <summary>
/// Confidence interval for a rate/proportion using Wald (normal approximation) method
/// by default.
///
/// <para>Wald confidence intervals use the normal approximation to the binomial
/// distribution. For extreme rates or small sample sizes, Wilson confidence intervals
/// may be more appropriate.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ThresholdMatrixRecallV95, ThresholdMatrixRecallV95FromRaw>)
)]
public sealed record class ThresholdMatrixRecallV95 : JsonModel
{
    /// <summary>
    /// Current number of samples/observations available
    /// </summary>
    public required long CurrentSample
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("currentSample");
        }
        init { this._rawData.Set("currentSample", value); }
    }

    /// <summary>
    /// Minimum number of samples needed for reliable confidence interval calculation
    /// </summary>
    public required long SampleNeeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sampleNeeded");
        }
        init { this._rawData.Set("sampleNeeded", value); }
    }

    /// <summary>
    /// Lower bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiLower
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciLower");
        }
        init { this._rawData.Set("ciLower", value); }
    }

    /// <summary>
    /// Upper bound of the confidence interval (null if insufficient sample size)
    /// </summary>
    public float? CiUpper
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("ciUpper");
        }
        init { this._rawData.Set("ciUpper", value); }
    }

    /// <summary>
    /// Point estimate (observed rate) at the center of the interval (null if insufficient
    /// sample size)
    /// </summary>
    public float? Mid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("mid");
        }
        init { this._rawData.Set("mid", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrentSample;
        _ = this.SampleNeeded;
        _ = this.CiLower;
        _ = this.CiUpper;
        _ = this.Mid;
    }

    public ThresholdMatrixRecallV95() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThresholdMatrixRecallV95(ThresholdMatrixRecallV95 thresholdMatrixRecallV95)
        : base(thresholdMatrixRecallV95) { }
#pragma warning restore CS8618

    public ThresholdMatrixRecallV95(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdMatrixRecallV95(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThresholdMatrixRecallV95FromRaw.FromRawUnchecked"/>
    public static ThresholdMatrixRecallV95 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThresholdMatrixRecallV95FromRaw : IFromRawJson<ThresholdMatrixRecallV95>
{
    /// <inheritdoc/>
    public ThresholdMatrixRecallV95 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThresholdMatrixRecallV95.FromRawUnchecked(rawData);
}

/// <summary>
/// Detailed performance metrics and analysis
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionEstimateReviewRequirementsResponseMetrics,
        FunctionEstimateReviewRequirementsResponseMetricsFromRaw
    >)
)]
public sealed record class FunctionEstimateReviewRequirementsResponseMetrics : JsonModel
{
    /// <summary>
    /// Comprehensive performance metrics
    /// </summary>
    public FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics? AggregateMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics>(
                "aggregateMetrics"
            );
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
    public IReadOnlyList<FunctionEstimateReviewRequirementsResponseMetricsFieldMetric>? FieldMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FunctionEstimateReviewRequirementsResponseMetricsFieldMetric>
            >("fieldMetrics");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FunctionEstimateReviewRequirementsResponseMetricsFieldMetric>?>(
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

    public FunctionEstimateReviewRequirementsResponseMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionEstimateReviewRequirementsResponseMetrics(
        FunctionEstimateReviewRequirementsResponseMetrics functionEstimateReviewRequirementsResponseMetrics
    )
        : base(functionEstimateReviewRequirementsResponseMetrics) { }
#pragma warning restore CS8618

    public FunctionEstimateReviewRequirementsResponseMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionEstimateReviewRequirementsResponseMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionEstimateReviewRequirementsResponseMetricsFromRaw.FromRawUnchecked"/>
    public static FunctionEstimateReviewRequirementsResponseMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionEstimateReviewRequirementsResponseMetricsFromRaw
    : IFromRawJson<FunctionEstimateReviewRequirementsResponseMetrics>
{
    /// <inheritdoc/>
    public FunctionEstimateReviewRequirementsResponseMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionEstimateReviewRequirementsResponseMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// Comprehensive performance metrics
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics,
        FunctionEstimateReviewRequirementsResponseMetricsAggregateMetricsFromRaw
    >)
)]
public sealed record class FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics
    : JsonModel
{
    /// <summary>
    /// Overall accuracy
    /// </summary>
    public float? Accuracy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("accuracy");
        }
        init { this._rawData.Set("accuracy", value); }
    }

    /// <summary>
    /// F1 Score (harmonic mean of precision and recall)
    /// </summary>
    public float? F1Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("f1Score");
        }
        init { this._rawData.Set("f1Score", value); }
    }

    /// <summary>
    /// False Negatives
    /// </summary>
    public long? Fn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fn", value);
        }
    }

    /// <summary>
    /// False Positives
    /// </summary>
    public long? Fp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fp", value);
        }
    }

    /// <summary>
    /// Precision (TP / (TP + FP))
    /// </summary>
    public float? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("precision");
        }
        init { this._rawData.Set("precision", value); }
    }

    /// <summary>
    /// Recall (TP / (TP + FN))
    /// </summary>
    public float? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("recall");
        }
        init { this._rawData.Set("recall", value); }
    }

    /// <summary>
    /// True Negatives
    /// </summary>
    public long? Tn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("tn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tn", value);
        }
    }

    /// <summary>
    /// True Positives
    /// </summary>
    public long? Tp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("tp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Accuracy;
        _ = this.F1Score;
        _ = this.Fn;
        _ = this.Fp;
        _ = this.Precision;
        _ = this.Recall;
        _ = this.Tn;
        _ = this.Tp;
    }

    public FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics(
        FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics functionEstimateReviewRequirementsResponseMetricsAggregateMetrics
    )
        : base(functionEstimateReviewRequirementsResponseMetricsAggregateMetrics) { }
#pragma warning restore CS8618

    public FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionEstimateReviewRequirementsResponseMetricsAggregateMetricsFromRaw.FromRawUnchecked"/>
    public static FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionEstimateReviewRequirementsResponseMetricsAggregateMetricsFromRaw
    : IFromRawJson<FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics>
{
    /// <inheritdoc/>
    public FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        FunctionEstimateReviewRequirementsResponseMetricsAggregateMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// Enhanced field metrics with comprehensive analytics
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionEstimateReviewRequirementsResponseMetricsFieldMetric,
        FunctionEstimateReviewRequirementsResponseMetricsFieldMetricFromRaw
    >)
)]
public sealed record class FunctionEstimateReviewRequirementsResponseMetricsFieldMetric : JsonModel
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
    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics>(
                "metrics"
            );
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

    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetric(
        FunctionEstimateReviewRequirementsResponseMetricsFieldMetric functionEstimateReviewRequirementsResponseMetricsFieldMetric
    )
        : base(functionEstimateReviewRequirementsResponseMetricsFieldMetric) { }
#pragma warning restore CS8618

    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetric(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionEstimateReviewRequirementsResponseMetricsFieldMetric(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionEstimateReviewRequirementsResponseMetricsFieldMetricFromRaw.FromRawUnchecked"/>
    public static FunctionEstimateReviewRequirementsResponseMetricsFieldMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetric(string fieldPath)
        : this()
    {
        this.FieldPath = fieldPath;
    }
}

class FunctionEstimateReviewRequirementsResponseMetricsFieldMetricFromRaw
    : IFromRawJson<FunctionEstimateReviewRequirementsResponseMetricsFieldMetric>
{
    /// <inheritdoc/>
    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionEstimateReviewRequirementsResponseMetricsFieldMetric.FromRawUnchecked(rawData);
}

/// <summary>
/// Comprehensive performance metrics
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics,
        FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetricsFromRaw
    >)
)]
public sealed record class FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics
    : JsonModel
{
    /// <summary>
    /// Overall accuracy
    /// </summary>
    public float? Accuracy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("accuracy");
        }
        init { this._rawData.Set("accuracy", value); }
    }

    /// <summary>
    /// F1 Score (harmonic mean of precision and recall)
    /// </summary>
    public float? F1Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("f1Score");
        }
        init { this._rawData.Set("f1Score", value); }
    }

    /// <summary>
    /// False Negatives
    /// </summary>
    public long? Fn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fn", value);
        }
    }

    /// <summary>
    /// False Positives
    /// </summary>
    public long? Fp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fp", value);
        }
    }

    /// <summary>
    /// Precision (TP / (TP + FP))
    /// </summary>
    public float? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("precision");
        }
        init { this._rawData.Set("precision", value); }
    }

    /// <summary>
    /// Recall (TP / (TP + FN))
    /// </summary>
    public float? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("recall");
        }
        init { this._rawData.Set("recall", value); }
    }

    /// <summary>
    /// True Negatives
    /// </summary>
    public long? Tn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("tn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tn", value);
        }
    }

    /// <summary>
    /// True Positives
    /// </summary>
    public long? Tp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("tp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Accuracy;
        _ = this.F1Score;
        _ = this.Fn;
        _ = this.Fp;
        _ = this.Precision;
        _ = this.Recall;
        _ = this.Tn;
        _ = this.Tp;
    }

    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics(
        FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics functionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics
    )
        : base(functionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics) { }
#pragma warning restore CS8618

    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetricsFromRaw.FromRawUnchecked"/>
    public static FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetricsFromRaw
    : IFromRawJson<FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics>
{
    /// <inheritdoc/>
    public FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        FunctionEstimateReviewRequirementsResponseMetricsFieldMetricMetrics.FromRawUnchecked(
            rawData
        );
}
