using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Eval.Score;

/// <summary>
/// **Get the status and per-pair results of a score run.**
///
/// <para>The comparison happens here, not in the run: the function's output is compared
/// against the expected value on every read, under the configuration supplied below.
/// Re-reading the same run with different settings returns different metrics and
/// costs nothing — no model calls are repeated.</para>
///
/// <para>Comparison is exact and takes no configuration: a value matches the expected
/// one or it is a miss. It is still redone on every read, so the numbers reflect
/// the stored data as it is now.</para>
///
/// <para>Returns `aggregate` once `status` reaches `completed` or `error`. `perPair`
/// is populated incrementally — each pair's `fieldResults` appears as its underlying
/// function call terminates.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ScoreRetrieveParams : ParamsBase
{
    public string? ScoreRunID { get; init; }

    public ScoreRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreRetrieveParams(ScoreRetrieveParams scoreRetrieveParams)
        : base(scoreRetrieveParams)
    {
        this.ScoreRunID = scoreRetrieveParams.ScoreRunID;
    }
#pragma warning restore CS8618

    public ScoreRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string scoreRunID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ScoreRunID = scoreRunID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ScoreRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string scoreRunID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            scoreRunID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ScoreRunID"] = JsonSerializer.SerializeToElement(this.ScoreRunID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ScoreRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ScoreRunID?.Equals(other.ScoreRunID) ?? other.ScoreRunID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/eval/score/{0}", this.ScoreRunID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
