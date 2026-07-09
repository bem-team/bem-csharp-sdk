using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Confidence interval for a rate/proportion using Wald (normal approximation) method
/// by default.
///
/// <para>Wald confidence intervals use the normal approximation to the binomial
/// distribution. For extreme rates or small sample sizes, Wilson confidence intervals
/// may be more appropriate.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RateConfidenceInterval, RateConfidenceIntervalFromRaw>))]
public sealed record class RateConfidenceInterval : JsonModel
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

    public RateConfidenceInterval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateConfidenceInterval(RateConfidenceInterval rateConfidenceInterval)
        : base(rateConfidenceInterval) { }
#pragma warning restore CS8618

    public RateConfidenceInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateConfidenceInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateConfidenceIntervalFromRaw.FromRawUnchecked"/>
    public static RateConfidenceInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateConfidenceIntervalFromRaw : IFromRawJson<RateConfidenceInterval>
{
    /// <inheritdoc/>
    public RateConfidenceInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RateConfidenceInterval.FromRawUnchecked(rawData);
}
