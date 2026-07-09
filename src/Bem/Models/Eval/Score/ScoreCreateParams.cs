using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Eval.Score;

/// <summary>
/// **Score a function against a list of (input, expected) pairs.**
///
/// <para>Submits a batch of `(input, expected)` pairs, runs the named function over
/// each input, and returns per-pair + aggregate accuracy metrics comparing the function's
/// actual output to the provided expected JSON.</para>
///
/// <para>Scoring runs asynchronously. The response carries a `scoreRunID`; poll `GET
/// /v3/eval/score/{scoreRunID}` until `status` is one of `completed`, `error`, or `cancelled`.</para>
///
/// <para>`matchConfig` controls comparator behavior: - `numericTolerance`: relative
/// tolerance for numeric fields (0 = exact) - `stringMatch`: `exact` (default) or
/// `fuzzy` (Levenshtein ratio) - `arrayMatch`: `by-index` (default; only mode in
/// P0) - `ignorePaths`: JSON Pointer paths to skip, supports `*` wildcards</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ScoreCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of the function to score. Must be of type extract, transform, or analyze.
    /// </summary>
    public required string FunctionName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("functionName");
        }
        init { this._rawBodyData.Set("functionName", value); }
    }

    /// <summary>
    /// Up to 1000 pairs per request.
    /// </summary>
    public required IReadOnlyList<Pair> Pairs
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Pair>>("pairs");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Pair>>(
                "pairs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional version number to score against. P0: only the function's current
    /// version is accepted; passing a different version returns 422.
    /// </summary>
    public long? FunctionVersionNum
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("functionVersionNum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("functionVersionNum", value);
        }
    }

    /// <summary>
    /// Comparator configuration. All fields optional; conservative defaults.
    /// </summary>
    public EvalMatchConfig? MatchConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EvalMatchConfig>("matchConfig");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("matchConfig", value);
        }
    }

    public ScoreCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreCreateParams(ScoreCreateParams scoreCreateParams)
        : base(scoreCreateParams)
    {
        this._rawBodyData = new(scoreCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ScoreCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ScoreCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ScoreCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/eval/score")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// One `(input, expected)` pair.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pair, PairFromRaw>))]
public sealed record class Pair : JsonModel
{
    /// <summary>
    /// Expected output for this input, as a JSON value. The comparator walks `expected
    /// ∪ actual` and produces a per-leaf classification.
    /// </summary>
    public required JsonElement Expected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("expected");
        }
        init { this._rawData.Set("expected", value); }
    }

    /// <summary>
    /// A single file input with base64-encoded content.
    ///
    /// <para>When using the Bem CLI, use `@path/to/file` in the `inputContent` field
    /// to automatically read and base64-encode the file: `--input.single-file '{"inputContent":
    /// "@file.pdf", "inputType": "pdf"}' --wait`</para>
    /// </summary>
    public required FileInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FileInput>("input");
        }
        init { this._rawData.Set("input", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Expected;
        this.Input.Validate();
    }

    public Pair() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pair(Pair pair)
        : base(pair) { }
#pragma warning restore CS8618

    public Pair(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pair(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PairFromRaw.FromRawUnchecked"/>
    public static Pair FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PairFromRaw : IFromRawJson<Pair>
{
    /// <inheritdoc/>
    public Pair FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pair.FromRawUnchecked(rawData);
}
