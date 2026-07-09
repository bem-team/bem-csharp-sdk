using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

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
