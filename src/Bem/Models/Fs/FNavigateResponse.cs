using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Fs;

/// <summary>
/// Uniform response shape returned for every `op`. `data` is op-specific JSON (a
/// list, an object, or a string), but the wrapper is constant so a client only learns
/// one parse path.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FNavigateResponse, FNavigateResponseFromRaw>))]
public sealed record class FNavigateResponse : JsonModel
{
    /// <summary>
    /// Op-specific payload. See per-op shapes below.
    /// </summary>
    public required JsonElement Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Operations exposed by `POST /v3/fs`.
    ///
    /// <para>The verbs and their flag names mirror Unix tools so an LLM agent's existing
    /// vocabulary maps directly:</para>
    ///
    /// <para>- `ls` — list parsed documents - `cat` — read one parsed doc (optionally
    /// sliced by range / projected by select) - `grep` — substring or regex search
    /// across parse outputs - `head` — first N sections of one doc - `stat` — metadata
    /// only (page count, section count, parsed at, ...) - `find` — list canonical
    /// entities (cross-doc memory) - `open` — entity + mentions - `xref` — entity
    /// → sections across docs that mention it</para>
    ///
    /// <para>Doc-level ops (ls, cat, grep, head, stat) work on every parsed document,
    /// regardless of how the parse function was configured.</para>
    ///
    /// <para>Memory-level ops (find, open, xref) operate on the global entities
    /// table which is only populated when the parse function had `linkAcrossDocuments:
    /// true`. On environments with no memory-linked docs they return empty data
    /// with a hint pointing at the toggle.</para>
    /// </summary>
    public required ApiEnum<string, FNavigateResponseOp> Op
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FNavigateResponseOp>>("op");
        }
        init { this._rawData.Set("op", value); }
    }

    /// <summary>
    /// Set for ops that return a count rather than a list (`grep` with `countOnly=true`)
    /// or as a sanity check on lists.
    /// </summary>
    public long? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    /// <summary>
    /// True when more pages exist for cursor-paginated ops.
    /// </summary>
    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasMore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasMore", value);
        }
    }

    /// <summary>
    /// Optional human-readable note. Surfaced on memory-level ops (`find` / `open`
    /// / `xref`) when the corpus has no memory-linked docs, pointing users at the
    /// `linkAcrossDocuments` toggle on the parse function.
    /// </summary>
    public string? Hint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hint", value);
        }
    }

    /// <summary>
    /// Cursor to pass as `cursor` in the next request to fetch the next page. Empty
    /// when `hasMore=false`.
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.Op.Validate();
        _ = this.Count;
        _ = this.HasMore;
        _ = this.Hint;
        _ = this.NextCursor;
    }

    public FNavigateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FNavigateResponse(FNavigateResponse fNavigateResponse)
        : base(fNavigateResponse) { }
#pragma warning restore CS8618

    public FNavigateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FNavigateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FNavigateResponseFromRaw.FromRawUnchecked"/>
    public static FNavigateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FNavigateResponseFromRaw : IFromRawJson<FNavigateResponse>
{
    /// <inheritdoc/>
    public FNavigateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FNavigateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Operations exposed by `POST /v3/fs`.
///
/// <para>The verbs and their flag names mirror Unix tools so an LLM agent's existing
/// vocabulary maps directly:</para>
///
/// <para>- `ls` — list parsed documents - `cat` — read one parsed doc (optionally
/// sliced by range / projected by select) - `grep` — substring or regex search across
/// parse outputs - `head` — first N sections of one doc - `stat` — metadata only
/// (page count, section count, parsed at, ...) - `find` — list canonical entities
/// (cross-doc memory) - `open` — entity + mentions - `xref` — entity → sections
/// across docs that mention it</para>
///
/// <para>Doc-level ops (ls, cat, grep, head, stat) work on every parsed document,
/// regardless of how the parse function was configured.</para>
///
/// <para>Memory-level ops (find, open, xref) operate on the global entities table
/// which is only populated when the parse function had `linkAcrossDocuments: true`.
/// On environments with no memory-linked docs they return empty data with a hint
/// pointing at the toggle.</para>
/// </summary>
[JsonConverter(typeof(FNavigateResponseOpConverter))]
public enum FNavigateResponseOp
{
    Ls,
    Find,
    Open,
    Cat,
    Grep,
    Xref,
    Stat,
    Head,
}

sealed class FNavigateResponseOpConverter : JsonConverter<FNavigateResponseOp>
{
    public override FNavigateResponseOp Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ls" => FNavigateResponseOp.Ls,
            "find" => FNavigateResponseOp.Find,
            "open" => FNavigateResponseOp.Open,
            "cat" => FNavigateResponseOp.Cat,
            "grep" => FNavigateResponseOp.Grep,
            "xref" => FNavigateResponseOp.Xref,
            "stat" => FNavigateResponseOp.Stat,
            "head" => FNavigateResponseOp.Head,
            _ => (FNavigateResponseOp)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FNavigateResponseOp value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FNavigateResponseOp.Ls => "ls",
                FNavigateResponseOp.Find => "find",
                FNavigateResponseOp.Open => "open",
                FNavigateResponseOp.Cat => "cat",
                FNavigateResponseOp.Grep => "grep",
                FNavigateResponseOp.Xref => "xref",
                FNavigateResponseOp.Stat => "stat",
                FNavigateResponseOp.Head => "head",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
