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
[JsonConverter(typeof(JsonModelConverter<ScoreCancelResponse, ScoreCancelResponseFromRaw>))]
public sealed record class ScoreCancelResponse : JsonModel
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
    public required ScoreCancelResponseMatchConfig MatchConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ScoreCancelResponseMatchConfig>("matchConfig");
        }
        init { this._rawData.Set("matchConfig", value); }
    }

    /// <summary>
    /// Per-pair results. `fieldResults` appears once a pair has been compared.
    /// </summary>
    public required IReadOnlyList<ScoreCancelResponsePerPair> PerPair
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ScoreCancelResponsePerPair>>(
                "perPair"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ScoreCancelResponsePerPair>>(
                "perPair",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Counts across all pairs.
    /// </summary>
    public required ScoreCancelResponseProgress Progress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ScoreCancelResponseProgress>("progress");
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
    public required ApiEnum<string, ScoreCancelResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ScoreCancelResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Aggregate accuracy metrics.
    /// </summary>
    public ScoreCancelResponseAggregate? Aggregate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ScoreCancelResponseAggregate>("aggregate");
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

    public ScoreCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreCancelResponse(ScoreCancelResponse scoreCancelResponse)
        : base(scoreCancelResponse) { }
#pragma warning restore CS8618

    public ScoreCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreCancelResponseFromRaw.FromRawUnchecked"/>
    public static ScoreCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreCancelResponseFromRaw : IFromRawJson<ScoreCancelResponse>
{
    /// <inheritdoc/>
    public ScoreCancelResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ScoreCancelResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparator configuration. All fields optional; conservative defaults.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ScoreCancelResponseMatchConfig,
        ScoreCancelResponseMatchConfigFromRaw
    >)
)]
public sealed record class ScoreCancelResponseMatchConfig : JsonModel
{
    /// <summary>
    /// P0 supports only `by-index`.
    /// </summary>
    public ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch>? ArrayMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch>
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
    public ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch>? StringMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch>
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

    public ScoreCancelResponseMatchConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreCancelResponseMatchConfig(
        ScoreCancelResponseMatchConfig scoreCancelResponseMatchConfig
    )
        : base(scoreCancelResponseMatchConfig) { }
#pragma warning restore CS8618

    public ScoreCancelResponseMatchConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreCancelResponseMatchConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreCancelResponseMatchConfigFromRaw.FromRawUnchecked"/>
    public static ScoreCancelResponseMatchConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreCancelResponseMatchConfigFromRaw : IFromRawJson<ScoreCancelResponseMatchConfig>
{
    /// <inheritdoc/>
    public ScoreCancelResponseMatchConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScoreCancelResponseMatchConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// P0 supports only `by-index`.
/// </summary>
[JsonConverter(typeof(ScoreCancelResponseMatchConfigArrayMatchConverter))]
public enum ScoreCancelResponseMatchConfigArrayMatch
{
    ByIndex,
}

sealed class ScoreCancelResponseMatchConfigArrayMatchConverter
    : JsonConverter<ScoreCancelResponseMatchConfigArrayMatch>
{
    public override ScoreCancelResponseMatchConfigArrayMatch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "by-index" => ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
            _ => (ScoreCancelResponseMatchConfigArrayMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScoreCancelResponseMatchConfigArrayMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScoreCancelResponseMatchConfigArrayMatch.ByIndex => "by-index",
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
[JsonConverter(typeof(ScoreCancelResponseMatchConfigStringMatchConverter))]
public enum ScoreCancelResponseMatchConfigStringMatch
{
    Exact,
    Fuzzy,
}

sealed class ScoreCancelResponseMatchConfigStringMatchConverter
    : JsonConverter<ScoreCancelResponseMatchConfigStringMatch>
{
    public override ScoreCancelResponseMatchConfigStringMatch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "exact" => ScoreCancelResponseMatchConfigStringMatch.Exact,
            "fuzzy" => ScoreCancelResponseMatchConfigStringMatch.Fuzzy,
            _ => (ScoreCancelResponseMatchConfigStringMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScoreCancelResponseMatchConfigStringMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScoreCancelResponseMatchConfigStringMatch.Exact => "exact",
                ScoreCancelResponseMatchConfigStringMatch.Fuzzy => "fuzzy",
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
[JsonConverter(
    typeof(JsonModelConverter<ScoreCancelResponsePerPair, ScoreCancelResponsePerPairFromRaw>)
)]
public sealed record class ScoreCancelResponsePerPair : JsonModel
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
    public required ApiEnum<string, ScoreCancelResponsePerPairStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ScoreCancelResponsePerPairStatus>>(
                "status"
            );
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
    public IReadOnlyList<ScoreCancelResponsePerPairFieldResult>? FieldResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ScoreCancelResponsePerPairFieldResult>
            >("fieldResults");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ScoreCancelResponsePerPairFieldResult>?>(
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

    public ScoreCancelResponsePerPair() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreCancelResponsePerPair(ScoreCancelResponsePerPair scoreCancelResponsePerPair)
        : base(scoreCancelResponsePerPair) { }
#pragma warning restore CS8618

    public ScoreCancelResponsePerPair(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreCancelResponsePerPair(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreCancelResponsePerPairFromRaw.FromRawUnchecked"/>
    public static ScoreCancelResponsePerPair FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreCancelResponsePerPairFromRaw : IFromRawJson<ScoreCancelResponsePerPair>
{
    /// <inheritdoc/>
    public ScoreCancelResponsePerPair FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScoreCancelResponsePerPair.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-pair status.
/// </summary>
[JsonConverter(typeof(ScoreCancelResponsePerPairStatusConverter))]
public enum ScoreCancelResponsePerPairStatus
{
    Pending,
    Running,
    Completed,
    Failed,
}

sealed class ScoreCancelResponsePerPairStatusConverter
    : JsonConverter<ScoreCancelResponsePerPairStatus>
{
    public override ScoreCancelResponsePerPairStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => ScoreCancelResponsePerPairStatus.Pending,
            "running" => ScoreCancelResponsePerPairStatus.Running,
            "completed" => ScoreCancelResponsePerPairStatus.Completed,
            "failed" => ScoreCancelResponsePerPairStatus.Failed,
            _ => (ScoreCancelResponsePerPairStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScoreCancelResponsePerPairStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScoreCancelResponsePerPairStatus.Pending => "pending",
                ScoreCancelResponsePerPairStatus.Running => "running",
                ScoreCancelResponsePerPairStatus.Completed => "completed",
                ScoreCancelResponsePerPairStatus.Failed => "failed",
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
[JsonConverter(
    typeof(JsonModelConverter<
        ScoreCancelResponsePerPairFieldResult,
        ScoreCancelResponsePerPairFieldResultFromRaw
    >)
)]
public sealed record class ScoreCancelResponsePerPairFieldResult : JsonModel
{
    /// <summary>
    /// Classification: - `exact`: both present and deep-equal - `within_tolerance`:
    /// both numbers, within configured tolerance - `fuzzy_match`: both strings,
    /// Levenshtein ratio above threshold - `miss`: expected present, actual absent
    /// or different - `extra`: actual present, expected absent
    /// </summary>
    public required ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch> Match
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch>
            >("match");
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

    public ScoreCancelResponsePerPairFieldResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreCancelResponsePerPairFieldResult(
        ScoreCancelResponsePerPairFieldResult scoreCancelResponsePerPairFieldResult
    )
        : base(scoreCancelResponsePerPairFieldResult) { }
#pragma warning restore CS8618

    public ScoreCancelResponsePerPairFieldResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreCancelResponsePerPairFieldResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreCancelResponsePerPairFieldResultFromRaw.FromRawUnchecked"/>
    public static ScoreCancelResponsePerPairFieldResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreCancelResponsePerPairFieldResultFromRaw
    : IFromRawJson<ScoreCancelResponsePerPairFieldResult>
{
    /// <inheritdoc/>
    public ScoreCancelResponsePerPairFieldResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScoreCancelResponsePerPairFieldResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Classification: - `exact`: both present and deep-equal - `within_tolerance`: both
/// numbers, within configured tolerance - `fuzzy_match`: both strings, Levenshtein
/// ratio above threshold - `miss`: expected present, actual absent or different
/// - `extra`: actual present, expected absent
/// </summary>
[JsonConverter(typeof(ScoreCancelResponsePerPairFieldResultMatchConverter))]
public enum ScoreCancelResponsePerPairFieldResultMatch
{
    Exact,
    WithinTolerance,
    FuzzyMatch,
    Miss,
    Extra,
}

sealed class ScoreCancelResponsePerPairFieldResultMatchConverter
    : JsonConverter<ScoreCancelResponsePerPairFieldResultMatch>
{
    public override ScoreCancelResponsePerPairFieldResultMatch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "exact" => ScoreCancelResponsePerPairFieldResultMatch.Exact,
            "within_tolerance" => ScoreCancelResponsePerPairFieldResultMatch.WithinTolerance,
            "fuzzy_match" => ScoreCancelResponsePerPairFieldResultMatch.FuzzyMatch,
            "miss" => ScoreCancelResponsePerPairFieldResultMatch.Miss,
            "extra" => ScoreCancelResponsePerPairFieldResultMatch.Extra,
            _ => (ScoreCancelResponsePerPairFieldResultMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScoreCancelResponsePerPairFieldResultMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScoreCancelResponsePerPairFieldResultMatch.Exact => "exact",
                ScoreCancelResponsePerPairFieldResultMatch.WithinTolerance => "within_tolerance",
                ScoreCancelResponsePerPairFieldResultMatch.FuzzyMatch => "fuzzy_match",
                ScoreCancelResponsePerPairFieldResultMatch.Miss => "miss",
                ScoreCancelResponsePerPairFieldResultMatch.Extra => "extra",
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
[JsonConverter(
    typeof(JsonModelConverter<ScoreCancelResponseProgress, ScoreCancelResponseProgressFromRaw>)
)]
public sealed record class ScoreCancelResponseProgress : JsonModel
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

    public ScoreCancelResponseProgress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreCancelResponseProgress(ScoreCancelResponseProgress scoreCancelResponseProgress)
        : base(scoreCancelResponseProgress) { }
#pragma warning restore CS8618

    public ScoreCancelResponseProgress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreCancelResponseProgress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreCancelResponseProgressFromRaw.FromRawUnchecked"/>
    public static ScoreCancelResponseProgress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreCancelResponseProgressFromRaw : IFromRawJson<ScoreCancelResponseProgress>
{
    /// <inheritdoc/>
    public ScoreCancelResponseProgress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScoreCancelResponseProgress.FromRawUnchecked(rawData);
}

/// <summary>
/// Status values for an eval-score run.
/// </summary>
[JsonConverter(typeof(ScoreCancelResponseStatusConverter))]
public enum ScoreCancelResponseStatus
{
    Pending,
    Initializing,
    Running,
    Completed,
    Error,
    Cancelled,
}

sealed class ScoreCancelResponseStatusConverter : JsonConverter<ScoreCancelResponseStatus>
{
    public override ScoreCancelResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => ScoreCancelResponseStatus.Pending,
            "initializing" => ScoreCancelResponseStatus.Initializing,
            "running" => ScoreCancelResponseStatus.Running,
            "completed" => ScoreCancelResponseStatus.Completed,
            "error" => ScoreCancelResponseStatus.Error,
            "cancelled" => ScoreCancelResponseStatus.Cancelled,
            _ => (ScoreCancelResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScoreCancelResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScoreCancelResponseStatus.Pending => "pending",
                ScoreCancelResponseStatus.Initializing => "initializing",
                ScoreCancelResponseStatus.Running => "running",
                ScoreCancelResponseStatus.Completed => "completed",
                ScoreCancelResponseStatus.Error => "error",
                ScoreCancelResponseStatus.Cancelled => "cancelled",
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
[JsonConverter(
    typeof(JsonModelConverter<ScoreCancelResponseAggregate, ScoreCancelResponseAggregateFromRaw>)
)]
public sealed record class ScoreCancelResponseAggregate : JsonModel
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

    public ScoreCancelResponseAggregate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreCancelResponseAggregate(ScoreCancelResponseAggregate scoreCancelResponseAggregate)
        : base(scoreCancelResponseAggregate) { }
#pragma warning restore CS8618

    public ScoreCancelResponseAggregate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreCancelResponseAggregate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreCancelResponseAggregateFromRaw.FromRawUnchecked"/>
    public static ScoreCancelResponseAggregate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreCancelResponseAggregateFromRaw : IFromRawJson<ScoreCancelResponseAggregate>
{
    /// <inheritdoc/>
    public ScoreCancelResponseAggregate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScoreCancelResponseAggregate.FromRawUnchecked(rawData);
}
