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
///
/// <para>Scoring takes no configuration: a value matches the expected one or it
/// is a miss. The comparison is still recomputed on every read from the stored JSON,
/// so the numbers reflect the data as it is now rather than as it was when the run executed.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EvalScoreRun, EvalScoreRunFromRaw>))]
public sealed record class EvalScoreRun : JsonModel
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
    /// Per-pair results. `fieldResults` appears once a pair has an output to compare.
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
    public required ApiEnum<string, EvalScoreRunStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EvalScoreRunStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Populated once `status` is `completed` or `error`.
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
        foreach (var item in this.PerPair)
        {
            item.Validate();
        }
        this.Progress.Validate();
        _ = this.ScoreRunID;
        this.Status.Validate();
        this.Aggregate?.Validate();
    }

    public EvalScoreRun() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EvalScoreRun(EvalScoreRun evalScoreRun)
        : base(evalScoreRun) { }
#pragma warning restore CS8618

    public EvalScoreRun(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EvalScoreRun(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EvalScoreRunFromRaw.FromRawUnchecked"/>
    public static EvalScoreRun FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EvalScoreRunFromRaw : IFromRawJson<EvalScoreRun>
{
    /// <inheritdoc/>
    public EvalScoreRun FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EvalScoreRun.FromRawUnchecked(rawData);
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
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Running,
    Completed,
    Failed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "running" => Status.Running,
            "completed" => Status.Completed,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Running => "running",
                Status.Completed => "completed",
                Status.Failed => "failed",
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
    /// Classification, in the same vocabulary the model-comparison endpoint reports.
    /// Comparison is exact — a value matches or it does not: - `match`: both present
    /// and deep-equal - `mismatch`: both present, different - `missing`: expected
    /// present, actual absent - `extra`: actual present, expected absent
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
    /// Populated for every non-identical numeric pair; `actual - expected`. Reported
    /// as evidence only — numbers have no threshold, so a delta tells you how far
    /// off a value was without ever excusing it.
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

    /// <summary>
    /// Populated for every non-identical string pair; the Levenshtein ratio in `[0,
    /// 1]`. Reported as evidence: it says how close a wrong value was, which never
    /// makes it right.
    /// </summary>
    public double? Similarity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("similarity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("similarity", value);
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
        _ = this.Similarity;
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
/// Classification, in the same vocabulary the model-comparison endpoint reports.
/// Comparison is exact — a value matches or it does not: - `match`: both present
/// and deep-equal - `mismatch`: both present, different - `missing`: expected present,
/// actual absent - `extra`: actual present, expected absent
/// </summary>
[JsonConverter(typeof(MatchConverter))]
public enum Match
{
    Match1,
    Mismatch,
    Missing,
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
            "match" => Match.Match1,
            "mismatch" => Match.Mismatch,
            "missing" => Match.Missing,
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
                Match.Match1 => "match",
                Match.Mismatch => "mismatch",
                Match.Missing => "missing",
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
/// Populated once `status` is `completed` or `error`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Aggregate, AggregateFromRaw>))]
public sealed record class Aggregate : JsonModel
{
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

    public required long Matches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("matches");
        }
        init { this._rawData.Set("matches", value); }
    }

    public required long Mismatches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("mismatches");
        }
        init { this._rawData.Set("mismatches", value); }
    }

    public required long Missing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("missing");
        }
        init { this._rawData.Set("missing", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Extras;
        _ = this.F1;
        _ = this.Matches;
        _ = this.Mismatches;
        _ = this.Missing;
        _ = this.Precision;
        _ = this.Recall;
        _ = this.TotalFieldsActual;
        _ = this.TotalFieldsExpected;
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
