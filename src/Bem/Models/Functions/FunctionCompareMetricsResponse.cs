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
    public AggregateComparison? AggregateComparison
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AggregateComparison>("aggregateComparison");
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
    public BaselineMetrics? BaselineMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BaselineMetrics>("baselineMetrics");
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
    public ComparisonMetrics? ComparisonMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComparisonMetrics>("comparisonMetrics");
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
/// Comparison of metrics between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AggregateComparison, AggregateComparisonFromRaw>))]
public sealed record class AggregateComparison : JsonModel
{
    /// <summary>
    /// Comparison of a single metric between two versions
    /// </summary>
    public Accuracy? Accuracy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Accuracy>("accuracy");
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
    public F1Score? F1Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<F1Score>("f1Score");
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
    public Precision? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Precision>("precision");
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
    public Recall? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Recall>("recall");
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

    public AggregateComparison() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AggregateComparison(AggregateComparison aggregateComparison)
        : base(aggregateComparison) { }
#pragma warning restore CS8618

    public AggregateComparison(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AggregateComparison(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AggregateComparisonFromRaw.FromRawUnchecked"/>
    public static AggregateComparison FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AggregateComparisonFromRaw : IFromRawJson<AggregateComparison>
{
    /// <inheritdoc/>
    public AggregateComparison FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AggregateComparison.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Accuracy, AccuracyFromRaw>))]
public sealed record class Accuracy : JsonModel
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

    public Accuracy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Accuracy(Accuracy accuracy)
        : base(accuracy) { }
#pragma warning restore CS8618

    public Accuracy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Accuracy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccuracyFromRaw.FromRawUnchecked"/>
    public static Accuracy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccuracyFromRaw : IFromRawJson<Accuracy>
{
    /// <inheritdoc/>
    public Accuracy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Accuracy.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<F1Score, F1ScoreFromRaw>))]
public sealed record class F1Score : JsonModel
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

    public F1Score() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public F1Score(F1Score f1Score)
        : base(f1Score) { }
#pragma warning restore CS8618

    public F1Score(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    F1Score(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="F1ScoreFromRaw.FromRawUnchecked"/>
    public static F1Score FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class F1ScoreFromRaw : IFromRawJson<F1Score>
{
    /// <inheritdoc/>
    public F1Score FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        F1Score.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Precision, PrecisionFromRaw>))]
public sealed record class Precision : JsonModel
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

    public Precision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Precision(Precision precision)
        : base(precision) { }
#pragma warning restore CS8618

    public Precision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Precision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrecisionFromRaw.FromRawUnchecked"/>
    public static Precision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrecisionFromRaw : IFromRawJson<Precision>
{
    /// <inheritdoc/>
    public Precision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Precision.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Recall, RecallFromRaw>))]
public sealed record class Recall : JsonModel
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

    public Recall() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Recall(Recall recall)
        : base(recall) { }
#pragma warning restore CS8618

    public Recall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Recall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecallFromRaw.FromRawUnchecked"/>
    public static Recall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecallFromRaw : IFromRawJson<Recall>
{
    /// <inheritdoc/>
    public Recall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Recall.FromRawUnchecked(rawData);
}

/// <summary>
/// Detailed performance metrics and analysis
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BaselineMetrics, BaselineMetricsFromRaw>))]
public sealed record class BaselineMetrics : JsonModel
{
    /// <summary>
    /// Comprehensive performance metrics
    /// </summary>
    public AggregateMetrics? AggregateMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AggregateMetrics>("aggregateMetrics");
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

    public BaselineMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BaselineMetrics(BaselineMetrics baselineMetrics)
        : base(baselineMetrics) { }
#pragma warning restore CS8618

    public BaselineMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BaselineMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BaselineMetricsFromRaw.FromRawUnchecked"/>
    public static BaselineMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BaselineMetricsFromRaw : IFromRawJson<BaselineMetrics>
{
    /// <inheritdoc/>
    public BaselineMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BaselineMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// Comprehensive performance metrics
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AggregateMetrics, AggregateMetricsFromRaw>))]
public sealed record class AggregateMetrics : JsonModel
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

    public AggregateMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AggregateMetrics(AggregateMetrics aggregateMetrics)
        : base(aggregateMetrics) { }
#pragma warning restore CS8618

    public AggregateMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AggregateMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AggregateMetricsFromRaw.FromRawUnchecked"/>
    public static AggregateMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AggregateMetricsFromRaw : IFromRawJson<AggregateMetrics>
{
    /// <inheritdoc/>
    public AggregateMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AggregateMetrics.FromRawUnchecked(rawData);
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

/// <summary>
/// Comprehensive performance metrics
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metrics, MetricsFromRaw>))]
public sealed record class Metrics : JsonModel
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

    public Metrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metrics(Metrics metrics)
        : base(metrics) { }
#pragma warning restore CS8618

    public Metrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricsFromRaw.FromRawUnchecked"/>
    public static Metrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricsFromRaw : IFromRawJson<Metrics>
{
    /// <inheritdoc/>
    public Metrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metrics.FromRawUnchecked(rawData);
}

/// <summary>
/// Detailed performance metrics and analysis
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComparisonMetrics, ComparisonMetricsFromRaw>))]
public sealed record class ComparisonMetrics : JsonModel
{
    /// <summary>
    /// Comprehensive performance metrics
    /// </summary>
    public ComparisonMetricsAggregateMetrics? AggregateMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComparisonMetricsAggregateMetrics>(
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
    public IReadOnlyList<ComparisonMetricsFieldMetric>? FieldMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ComparisonMetricsFieldMetric>>(
                "fieldMetrics"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ComparisonMetricsFieldMetric>?>(
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

    public ComparisonMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonMetrics(ComparisonMetrics comparisonMetrics)
        : base(comparisonMetrics) { }
#pragma warning restore CS8618

    public ComparisonMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonMetricsFromRaw.FromRawUnchecked"/>
    public static ComparisonMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComparisonMetricsFromRaw : IFromRawJson<ComparisonMetrics>
{
    /// <inheritdoc/>
    public ComparisonMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComparisonMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// Comprehensive performance metrics
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ComparisonMetricsAggregateMetrics,
        ComparisonMetricsAggregateMetricsFromRaw
    >)
)]
public sealed record class ComparisonMetricsAggregateMetrics : JsonModel
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

    public ComparisonMetricsAggregateMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonMetricsAggregateMetrics(
        ComparisonMetricsAggregateMetrics comparisonMetricsAggregateMetrics
    )
        : base(comparisonMetricsAggregateMetrics) { }
#pragma warning restore CS8618

    public ComparisonMetricsAggregateMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonMetricsAggregateMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonMetricsAggregateMetricsFromRaw.FromRawUnchecked"/>
    public static ComparisonMetricsAggregateMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComparisonMetricsAggregateMetricsFromRaw : IFromRawJson<ComparisonMetricsAggregateMetrics>
{
    /// <inheritdoc/>
    public ComparisonMetricsAggregateMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComparisonMetricsAggregateMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// Enhanced field metrics with comprehensive analytics
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ComparisonMetricsFieldMetric, ComparisonMetricsFieldMetricFromRaw>)
)]
public sealed record class ComparisonMetricsFieldMetric : JsonModel
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
    public ComparisonMetricsFieldMetricMetrics? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComparisonMetricsFieldMetricMetrics>("metrics");
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

    public ComparisonMetricsFieldMetric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonMetricsFieldMetric(ComparisonMetricsFieldMetric comparisonMetricsFieldMetric)
        : base(comparisonMetricsFieldMetric) { }
#pragma warning restore CS8618

    public ComparisonMetricsFieldMetric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonMetricsFieldMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonMetricsFieldMetricFromRaw.FromRawUnchecked"/>
    public static ComparisonMetricsFieldMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ComparisonMetricsFieldMetric(string fieldPath)
        : this()
    {
        this.FieldPath = fieldPath;
    }
}

class ComparisonMetricsFieldMetricFromRaw : IFromRawJson<ComparisonMetricsFieldMetric>
{
    /// <inheritdoc/>
    public ComparisonMetricsFieldMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComparisonMetricsFieldMetric.FromRawUnchecked(rawData);
}

/// <summary>
/// Comprehensive performance metrics
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ComparisonMetricsFieldMetricMetrics,
        ComparisonMetricsFieldMetricMetricsFromRaw
    >)
)]
public sealed record class ComparisonMetricsFieldMetricMetrics : JsonModel
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

    public ComparisonMetricsFieldMetricMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonMetricsFieldMetricMetrics(
        ComparisonMetricsFieldMetricMetrics comparisonMetricsFieldMetricMetrics
    )
        : base(comparisonMetricsFieldMetricMetrics) { }
#pragma warning restore CS8618

    public ComparisonMetricsFieldMetricMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonMetricsFieldMetricMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonMetricsFieldMetricMetricsFromRaw.FromRawUnchecked"/>
    public static ComparisonMetricsFieldMetricMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComparisonMetricsFieldMetricMetricsFromRaw : IFromRawJson<ComparisonMetricsFieldMetricMetrics>
{
    /// <inheritdoc/>
    public ComparisonMetricsFieldMetricMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComparisonMetricsFieldMetricMetrics.FromRawUnchecked(rawData);
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
    public required Comparison Comparison
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Comparison>("comparison");
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

/// <summary>
/// Comparison of metrics between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Comparison, ComparisonFromRaw>))]
public sealed record class Comparison : JsonModel
{
    /// <summary>
    /// Comparison of a single metric between two versions
    /// </summary>
    public ComparisonAccuracy? Accuracy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComparisonAccuracy>("accuracy");
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
    public ComparisonF1Score? F1Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComparisonF1Score>("f1Score");
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
    public ComparisonPrecision? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComparisonPrecision>("precision");
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
    public ComparisonRecall? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComparisonRecall>("recall");
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

    public Comparison() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Comparison(Comparison comparison)
        : base(comparison) { }
#pragma warning restore CS8618

    public Comparison(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Comparison(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonFromRaw.FromRawUnchecked"/>
    public static Comparison FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComparisonFromRaw : IFromRawJson<Comparison>
{
    /// <inheritdoc/>
    public Comparison FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Comparison.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComparisonAccuracy, ComparisonAccuracyFromRaw>))]
public sealed record class ComparisonAccuracy : JsonModel
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

    public ComparisonAccuracy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonAccuracy(ComparisonAccuracy comparisonAccuracy)
        : base(comparisonAccuracy) { }
#pragma warning restore CS8618

    public ComparisonAccuracy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonAccuracy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonAccuracyFromRaw.FromRawUnchecked"/>
    public static ComparisonAccuracy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComparisonAccuracyFromRaw : IFromRawJson<ComparisonAccuracy>
{
    /// <inheritdoc/>
    public ComparisonAccuracy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComparisonAccuracy.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComparisonF1Score, ComparisonF1ScoreFromRaw>))]
public sealed record class ComparisonF1Score : JsonModel
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

    public ComparisonF1Score() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonF1Score(ComparisonF1Score comparisonF1Score)
        : base(comparisonF1Score) { }
#pragma warning restore CS8618

    public ComparisonF1Score(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonF1Score(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonF1ScoreFromRaw.FromRawUnchecked"/>
    public static ComparisonF1Score FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComparisonF1ScoreFromRaw : IFromRawJson<ComparisonF1Score>
{
    /// <inheritdoc/>
    public ComparisonF1Score FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComparisonF1Score.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComparisonPrecision, ComparisonPrecisionFromRaw>))]
public sealed record class ComparisonPrecision : JsonModel
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

    public ComparisonPrecision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonPrecision(ComparisonPrecision comparisonPrecision)
        : base(comparisonPrecision) { }
#pragma warning restore CS8618

    public ComparisonPrecision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonPrecision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonPrecisionFromRaw.FromRawUnchecked"/>
    public static ComparisonPrecision FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComparisonPrecisionFromRaw : IFromRawJson<ComparisonPrecision>
{
    /// <inheritdoc/>
    public ComparisonPrecision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComparisonPrecision.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison of a single metric between two versions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComparisonRecall, ComparisonRecallFromRaw>))]
public sealed record class ComparisonRecall : JsonModel
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

    public ComparisonRecall() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComparisonRecall(ComparisonRecall comparisonRecall)
        : base(comparisonRecall) { }
#pragma warning restore CS8618

    public ComparisonRecall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComparisonRecall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComparisonRecallFromRaw.FromRawUnchecked"/>
    public static ComparisonRecall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComparisonRecallFromRaw : IFromRawJson<ComparisonRecall>
{
    /// <inheritdoc/>
    public ComparisonRecall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComparisonRecall.FromRawUnchecked(rawData);
}
