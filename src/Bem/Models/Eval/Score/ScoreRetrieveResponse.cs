using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Eval.Score;

/// <summary>
/// Full status payload returned by `GET /v3/eval/score/{scoreRunID}`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ScoreRetrieveResponse, ScoreRetrieveResponseFromRaw>))]
public sealed record class ScoreRetrieveResponse : JsonModel
{
    public required string FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionName");
        }
        init { this._rawData.Set("functionName", value); }
    }

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
    /// Comparator configuration. All fields optional; conservative defaults.
    /// </summary>
    public required ScoreRetrieveResponseMatchConfig MatchConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ScoreRetrieveResponseMatchConfig>("matchConfig");
        }
        init { this._rawData.Set("matchConfig", value); }
    }

    /// <summary>
    /// Per-pair results. `fieldResults` appears once a pair has been compared.
    /// </summary>
    public required IReadOnlyList<PerPair> PerPair
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PerPair>>("perPair");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PerPair>>(
                "perPair",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Counts across all pairs.
    /// </summary>
    public required global::Bem.Models.Eval.Score.Progress Progress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Bem.Models.Eval.Score.Progress>(
                "progress"
            );
        }
        init { this._rawData.Set("progress", value); }
    }

    public required string ScoreRunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("scoreRunID");
        }
        init { this._rawData.Set("scoreRunID", value); }
    }

    /// <summary>
    /// Status values for an eval-score run.
    /// </summary>
    public required ApiEnum<string, ScoreRetrieveResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ScoreRetrieveResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Aggregate accuracy metrics.
    /// </summary>
    public Aggregate? Aggregate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Aggregate>("aggregate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aggregate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionName;
        _ = this.FunctionVersionNum;
        this.MatchConfig.Validate();
        foreach (var item in this.PerPair)
        {
            item.Validate();
        }
        this.Progress.Validate();
        _ = this.ScoreRunID;
        this.Status.Validate();
        this.Aggregate?.Validate();
    }

    public ScoreRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreRetrieveResponse(ScoreRetrieveResponse scoreRetrieveResponse)
        : base(scoreRetrieveResponse) { }
#pragma warning restore CS8618

    public ScoreRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ScoreRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreRetrieveResponseFromRaw : IFromRawJson<ScoreRetrieveResponse>
{
    /// <inheritdoc/>
    public ScoreRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScoreRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparator configuration. All fields optional; conservative defaults.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ScoreRetrieveResponseMatchConfig,
        ScoreRetrieveResponseMatchConfigFromRaw
    >)
)]
public sealed record class ScoreRetrieveResponseMatchConfig : JsonModel
{
    /// <summary>
    /// P0 supports only `by-index`.
    /// </summary>
    public ApiEnum<string, ScoreRetrieveResponseMatchConfigArrayMatch>? ArrayMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ScoreRetrieveResponseMatchConfigArrayMatch>
            >("arrayMatch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("arrayMatch", value);
        }
    }

    /// <summary>
    /// Levenshtein-ratio threshold used when `stringMatch == "fuzzy"`. Range `[0,
    /// 1]`. Default `0.85`.
    /// </summary>
    public double? FuzzyThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fuzzyThreshold");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fuzzyThreshold", value);
        }
    }

    /// <summary>
    /// JSON Pointer paths to skip during comparison. The asterisk character matches
    /// arbitrary object keys / array indices.
    ///
    /// <para>Example values: /metadata, /lineItems with asterisk segment, etc.</para>
    /// </summary>
    public IReadOnlyList<string>? IgnorePaths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("ignorePaths");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "ignorePaths",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Relative tolerance for numeric fields. `0` (default) means exact equality;
    /// `0.01` means ±1%.
    /// </summary>
    public double? NumericTolerance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("numericTolerance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numericTolerance", value);
        }
    }

    /// <summary>
    /// `exact` (default) or `fuzzy`.
    /// </summary>
    public ApiEnum<string, ScoreRetrieveResponseMatchConfigStringMatch>? StringMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ScoreRetrieveResponseMatchConfigStringMatch>
            >("stringMatch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stringMatch", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ArrayMatch?.Validate();
        _ = this.FuzzyThreshold;
        _ = this.IgnorePaths;
        _ = this.NumericTolerance;
        this.StringMatch?.Validate();
    }

    public ScoreRetrieveResponseMatchConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreRetrieveResponseMatchConfig(
        ScoreRetrieveResponseMatchConfig scoreRetrieveResponseMatchConfig
    )
        : base(scoreRetrieveResponseMatchConfig) { }
#pragma warning restore CS8618

    public ScoreRetrieveResponseMatchConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreRetrieveResponseMatchConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreRetrieveResponseMatchConfigFromRaw.FromRawUnchecked"/>
    public static ScoreRetrieveResponseMatchConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreRetrieveResponseMatchConfigFromRaw : IFromRawJson<ScoreRetrieveResponseMatchConfig>
{
    /// <inheritdoc/>
    public ScoreRetrieveResponseMatchConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScoreRetrieveResponseMatchConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// P0 supports only `by-index`.
/// </summary>
[JsonConverter(typeof(ScoreRetrieveResponseMatchConfigArrayMatchConverter))]
public enum ScoreRetrieveResponseMatchConfigArrayMatch
{
    ByIndex,
}

sealed class ScoreRetrieveResponseMatchConfigArrayMatchConverter
    : JsonConverter<ScoreRetrieveResponseMatchConfigArrayMatch>
{
    public override ScoreRetrieveResponseMatchConfigArrayMatch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "by-index" => ScoreRetrieveResponseMatchConfigArrayMatch.ByIndex,
            _ => (ScoreRetrieveResponseMatchConfigArrayMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScoreRetrieveResponseMatchConfigArrayMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScoreRetrieveResponseMatchConfigArrayMatch.ByIndex => "by-index",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// `exact` (default) or `fuzzy`.
/// </summary>
[JsonConverter(typeof(ScoreRetrieveResponseMatchConfigStringMatchConverter))]
public enum ScoreRetrieveResponseMatchConfigStringMatch
{
    Exact,
    Fuzzy,
}

sealed class ScoreRetrieveResponseMatchConfigStringMatchConverter
    : JsonConverter<ScoreRetrieveResponseMatchConfigStringMatch>
{
    public override ScoreRetrieveResponseMatchConfigStringMatch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "exact" => ScoreRetrieveResponseMatchConfigStringMatch.Exact,
            "fuzzy" => ScoreRetrieveResponseMatchConfigStringMatch.Fuzzy,
            _ => (ScoreRetrieveResponseMatchConfigStringMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScoreRetrieveResponseMatchConfigStringMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScoreRetrieveResponseMatchConfigStringMatch.Exact => "exact",
                ScoreRetrieveResponseMatchConfigStringMatch.Fuzzy => "fuzzy",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Per-pair result.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PerPair, PerPairFromRaw>))]
public sealed record class PerPair : JsonModel
{
    public required long PairIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pairIndex");
        }
        init { this._rawData.Set("pairIndex", value); }
    }

    /// <summary>
    /// Per-pair status.
    /// </summary>
    public required ApiEnum<string, PerPairStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PerPairStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The function call that produced the actual output, if any.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Error message if the underlying function call failed.
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errorMessage", value);
        }
    }

    /// <summary>
    /// Per-leaf comparator output. Present only after the pair has been compared.
    /// </summary>
    public IReadOnlyList<FieldResult>? FieldResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FieldResult>>("fieldResults");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FieldResult>?>(
                "fieldResults",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PairIndex;
        this.Status.Validate();
        _ = this.CallID;
        _ = this.ErrorMessage;
        foreach (var item in this.FieldResults ?? [])
        {
            item.Validate();
        }
    }

    public PerPair() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PerPair(PerPair perPair)
        : base(perPair) { }
#pragma warning restore CS8618

    public PerPair(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PerPair(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PerPairFromRaw.FromRawUnchecked"/>
    public static PerPair FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PerPairFromRaw : IFromRawJson<PerPair>
{
    /// <inheritdoc/>
    public PerPair FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PerPair.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-pair status.
/// </summary>
[JsonConverter(typeof(PerPairStatusConverter))]
public enum PerPairStatus
{
    Pending,
    Running,
    Completed,
    Failed,
}

sealed class PerPairStatusConverter : JsonConverter<PerPairStatus>
{
    public override PerPairStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => PerPairStatus.Pending,
            "running" => PerPairStatus.Running,
            "completed" => PerPairStatus.Completed,
            "failed" => PerPairStatus.Failed,
            _ => (PerPairStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PerPairStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PerPairStatus.Pending => "pending",
                PerPairStatus.Running => "running",
                PerPairStatus.Completed => "completed",
                PerPairStatus.Failed => "failed",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// One leaf in `expected ∪ actual`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FieldResult, FieldResultFromRaw>))]
public sealed record class FieldResult : JsonModel
{
    /// <summary>
    /// Classification: - `exact`: both present and deep-equal - `within_tolerance`:
    /// both numbers, within configured tolerance - `fuzzy_match`: both strings,
    /// Levenshtein ratio above threshold - `miss`: expected present, actual absent
    /// or different - `extra`: actual present, expected absent
    /// </summary>
    public required ApiEnum<string, Match> Match
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Match>>("match");
        }
        init { this._rawData.Set("match", value); }
    }

    /// <summary>
    /// JSON Pointer to the leaf.
    /// </summary>
    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public JsonElement? Actual
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("actual");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("actual", value);
        }
    }

    /// <summary>
    /// Populated for numeric comparisons; `actual - expected`.
    /// </summary>
    public double? Delta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("delta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delta", value);
        }
    }

    public JsonElement? Expected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("expected");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expected", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Match.Validate();
        _ = this.Path;
        _ = this.Actual;
        _ = this.Delta;
        _ = this.Expected;
    }

    public FieldResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FieldResult(FieldResult fieldResult)
        : base(fieldResult) { }
#pragma warning restore CS8618

    public FieldResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FieldResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FieldResultFromRaw.FromRawUnchecked"/>
    public static FieldResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FieldResultFromRaw : IFromRawJson<FieldResult>
{
    /// <inheritdoc/>
    public FieldResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FieldResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Classification: - `exact`: both present and deep-equal - `within_tolerance`: both
/// numbers, within configured tolerance - `fuzzy_match`: both strings, Levenshtein
/// ratio above threshold - `miss`: expected present, actual absent or different
/// - `extra`: actual present, expected absent
/// </summary>
[JsonConverter(typeof(MatchConverter))]
public enum Match
{
    Exact,
    WithinTolerance,
    FuzzyMatch,
    Miss,
    Extra,
}

sealed class MatchConverter : JsonConverter<Match>
{
    public override Match Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "exact" => Match.Exact,
            "within_tolerance" => Match.WithinTolerance,
            "fuzzy_match" => Match.FuzzyMatch,
            "miss" => Match.Miss,
            "extra" => Match.Extra,
            _ => (Match)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Match value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Match.Exact => "exact",
                Match.WithinTolerance => "within_tolerance",
                Match.FuzzyMatch => "fuzzy_match",
                Match.Miss => "miss",
                Match.Extra => "extra",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Counts across all pairs.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<global::Bem.Models.Eval.Score.Progress, ProgressFromRaw>))]
public sealed record class Progress : JsonModel
{
    public required long Completed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("completed");
        }
        init { this._rawData.Set("completed", value); }
    }

    public required long Failed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("failed");
        }
        init { this._rawData.Set("failed", value); }
    }

    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Completed;
        _ = this.Failed;
        _ = this.Total;
    }

    public Progress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Progress(global::Bem.Models.Eval.Score.Progress progress)
        : base(progress) { }
#pragma warning restore CS8618

    public Progress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Progress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProgressFromRaw.FromRawUnchecked"/>
    public static global::Bem.Models.Eval.Score.Progress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProgressFromRaw : IFromRawJson<global::Bem.Models.Eval.Score.Progress>
{
    /// <inheritdoc/>
    public global::Bem.Models.Eval.Score.Progress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Bem.Models.Eval.Score.Progress.FromRawUnchecked(rawData);
}

/// <summary>
/// Status values for an eval-score run.
/// </summary>
[JsonConverter(typeof(ScoreRetrieveResponseStatusConverter))]
public enum ScoreRetrieveResponseStatus
{
    Pending,
    Initializing,
    Running,
    Completed,
    Error,
    Cancelled,
}

sealed class ScoreRetrieveResponseStatusConverter : JsonConverter<ScoreRetrieveResponseStatus>
{
    public override ScoreRetrieveResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => ScoreRetrieveResponseStatus.Pending,
            "initializing" => ScoreRetrieveResponseStatus.Initializing,
            "running" => ScoreRetrieveResponseStatus.Running,
            "completed" => ScoreRetrieveResponseStatus.Completed,
            "error" => ScoreRetrieveResponseStatus.Error,
            "cancelled" => ScoreRetrieveResponseStatus.Cancelled,
            _ => (ScoreRetrieveResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScoreRetrieveResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScoreRetrieveResponseStatus.Pending => "pending",
                ScoreRetrieveResponseStatus.Initializing => "initializing",
                ScoreRetrieveResponseStatus.Running => "running",
                ScoreRetrieveResponseStatus.Completed => "completed",
                ScoreRetrieveResponseStatus.Error => "error",
                ScoreRetrieveResponseStatus.Cancelled => "cancelled",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Aggregate accuracy metrics.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Aggregate, AggregateFromRaw>))]
public sealed record class Aggregate : JsonModel
{
    public required long ExactMatches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("exactMatches");
        }
        init { this._rawData.Set("exactMatches", value); }
    }

    public required long Extras
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("extras");
        }
        init { this._rawData.Set("extras", value); }
    }

    public required double F1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("f1");
        }
        init { this._rawData.Set("f1", value); }
    }

    public required long FuzzyMatches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fuzzyMatches");
        }
        init { this._rawData.Set("fuzzyMatches", value); }
    }

    public required long Misses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("misses");
        }
        init { this._rawData.Set("misses", value); }
    }

    public required double Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("precision");
        }
        init { this._rawData.Set("precision", value); }
    }

    public required double Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("recall");
        }
        init { this._rawData.Set("recall", value); }
    }

    public required long TotalFieldsActual
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalFieldsActual");
        }
        init { this._rawData.Set("totalFieldsActual", value); }
    }

    public required long TotalFieldsExpected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalFieldsExpected");
        }
        init { this._rawData.Set("totalFieldsExpected", value); }
    }

    public required long WithinTolerance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("withinTolerance");
        }
        init { this._rawData.Set("withinTolerance", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExactMatches;
        _ = this.Extras;
        _ = this.F1;
        _ = this.FuzzyMatches;
        _ = this.Misses;
        _ = this.Precision;
        _ = this.Recall;
        _ = this.TotalFieldsActual;
        _ = this.TotalFieldsExpected;
        _ = this.WithinTolerance;
    }

    public Aggregate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Aggregate(Aggregate aggregate)
        : base(aggregate) { }
#pragma warning restore CS8618

    public Aggregate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Aggregate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AggregateFromRaw.FromRawUnchecked"/>
    public static Aggregate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AggregateFromRaw : IFromRawJson<Aggregate>
{
    /// <inheritdoc/>
    public Aggregate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Aggregate.FromRawUnchecked(rawData);
}
