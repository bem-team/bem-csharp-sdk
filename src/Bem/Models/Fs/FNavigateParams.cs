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
using Bem.Exceptions;

namespace Bem.Models.Fs;

/// <summary>
/// **Navigate parsed documents and the cross-doc memory store via Unix-shell verbs.**
///
/// <para>`POST /v3/fs` is a single op-driven endpoint that lets an LLM agent (or
/// any programmatic client) walk a corpus the way it would walk a filesystem — `ls`
/// to list, `cat` to read, `grep` to search, `head` for a quick peek, `stat` for
/// metadata, and `find` / `open` / `xref` for the cross-doc entity memory layer.</para>
///
/// <para>The body always carries an `op` field; other fields apply per op. The response
/// envelope is uniform: `{op, data, hasMore?, nextCursor?, count?, hint?}`.</para>
///
/// <para>## Doc-level ops (work on every parsed document)</para>
///
/// <para>- `ls`: list parsed documents with `pageCount`, `sectionCount`, `entityCount`,
/// and a short `previewEntities` array. - `cat`: read one doc's full parse JSON,
/// optionally sliced by `range` (page / pageRange / sectionTypes) or projected by
/// `select` (dotted paths like `["sections.label", "sections.page"]`). - `head`:
/// first N sections of one doc. - `grep`: substring or regex search across recent
/// parse outputs. `scope` restricts to `sections` / `entities` / `relationships`.
/// `path` scopes to one doc. `countOnly: true` returns only the hit count. - `stat`:
/// metadata only — page/section/entity counts, timestamps.</para>
///
/// <para>## Memory-level ops (require `linkAcrossDocuments: true` on the parse function)</para>
///
/// <para>- `find`: list canonical entities, filterable by `type`, `search`, `since`.
/// Returns an empty list with a `hint` when no docs have been memory-linked. - `open`:
/// fetch one entity plus its mentions across docs. - `xref`: for one entity, return
/// the actual sections (with content) across docs that mention it. The "where exactly
/// is X discussed" loop in one round trip.</para>
///
/// <para>## Pagination</para>
///
/// <para>List ops (`ls`, `find`) paginate by cursor: pass the last item's `nextCursor`
/// from a previous response to fetch the next page; `hasMore: false` signals the
/// last page. Same idiom as `/v3/calls` and `/v3/outputs`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FNavigateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
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
    public required ApiEnum<string, Op> Op
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Op>>("op");
        }
        init { this._rawBodyData.Set("op", value); }
    }

    /// <summary>
    /// When true, return only the hit count without snippet payload. Cheaper than
    /// fetching matches when the agent only wants a yes/no.
    /// </summary>
    public bool? CountOnly
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("countOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("countOnly", value);
        }
    }

    /// <summary>
    /// Pagination cursor. Pass the last item's ID from a previous response (`nextCursor`)
    /// to fetch the next page.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Filter options for `op=ls` and `op=find`.
    /// </summary>
    public Filter? Filter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Filter>("filter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("filter", value);
        }
    }

    /// <summary>
    /// When true (default), substring/regex matching is case-insensitive.
    /// </summary>
    public bool? IgnoreCase
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("ignoreCase");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("ignoreCase", value);
        }
    }

    /// <summary>
    /// Maximum results to return. Defaults vary per op (25–50).
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("limit", value);
        }
    }

    /// <summary>
    /// First-N count for `op=head`. Defaults to 10.
    /// </summary>
    public long? N
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("n");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("n", value);
        }
    }

    /// <summary>
    /// Identifier for ops that operate on a single resource: - cat / head / stat:
    /// a parsed document, by `referenceID` or `transformationID`. - open / xref
    /// / stat: an entity, by `entityID`.
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("path", value);
        }
    }

    /// <summary>
    /// Substring or regex pattern for `op=grep`.
    /// </summary>
    public string? Pattern
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("pattern");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("pattern", value);
        }
    }

    /// <summary>
    /// Slice the parse output along page or section dimensions. Used with `op=cat`.
    /// </summary>
    public global::Bem.Models.Fs.Range? Range
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<global::Bem.Models.Fs.Range>("range");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("range", value);
        }
    }

    /// <summary>
    /// When true, `pattern` is interpreted as a Go regex. Default false.
    /// </summary>
    public bool? Regex
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("regex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("regex", value);
        }
    }

    /// <summary>
    /// Restricts grep to one part of the parse output. One of `"sections"`, `"entities"`,
    /// `"relationships"`, `"all"` (default).
    /// </summary>
    public string? Scope
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("scope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("scope", value);
        }
    }

    /// <summary>
    /// Project the parse output to specific dotted paths (e.g. `["sections.label",
    /// "sections.page"]`), letting an agent map a doc's structure cheaply before
    /// reading content. Used with `op=cat`.
    /// </summary>
    public IReadOnlyList<string>? Select
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("select");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "select",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public FNavigateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FNavigateParams(FNavigateParams fNavigateParams)
        : base(fNavigateParams)
    {
        this._rawBodyData = new(fNavigateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FNavigateParams(
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
    FNavigateParams(
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
    public static FNavigateParams FromRawUnchecked(
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

    public virtual bool Equals(FNavigateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/fs")
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
[JsonConverter(typeof(OpConverter))]
public enum Op
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

sealed class OpConverter : JsonConverter<Op>
{
    public override Op Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ls" => Op.Ls,
            "find" => Op.Find,
            "open" => Op.Open,
            "cat" => Op.Cat,
            "grep" => Op.Grep,
            "xref" => Op.Xref,
            "stat" => Op.Stat,
            "head" => Op.Head,
            _ => (Op)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Op value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Op.Ls => "ls",
                Op.Find => "find",
                Op.Open => "open",
                Op.Cat => "cat",
                Op.Grep => "grep",
                Op.Xref => "xref",
                Op.Stat => "stat",
                Op.Head => "head",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter options for `op=ls` and `op=find`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Match a parsed doc's source function name exactly.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// Substring match on canonical name (entities) or `referenceID` (parsed docs). Case-insensitive.
    /// </summary>
    public string? Search
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("search");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("search", value);
        }
    }

    /// <summary>
    /// Restrict to resources created at or after this timestamp.
    /// </summary>
    public DateTimeOffset? Since
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("since");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("since", value);
        }
    }

    /// <summary>
    /// Match an entity's `type` field exactly (e.g. `"drug"`, `"study"`).
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionName;
        _ = this.Search;
        _ = this.Since;
        _ = this.Type;
    }

    public Filter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter(Filter filter)
        : base(filter) { }
#pragma warning restore CS8618

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Slice the parse output along page or section dimensions. Used with `op=cat`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<global::Bem.Models.Fs.Range, RangeFromRaw>))]
public sealed record class Range : JsonModel
{
    /// <summary>
    /// Restrict sections to one page (1-indexed).
    /// </summary>
    public long? Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// Restrict sections to an inclusive page range. Two-element array of `[from,
    /// to]` (both 1-indexed).
    /// </summary>
    public IReadOnlyList<long>? PageRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("pageRange");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "pageRange",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Keep only sections whose `type` matches one of these (e.g. `["table", "list"]`).
    /// </summary>
    public IReadOnlyList<string>? SectionTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("sectionTypes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "sectionTypes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        _ = this.PageRange;
        _ = this.SectionTypes;
    }

    public Range() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Range(global::Bem.Models.Fs.Range range)
        : base(range) { }
#pragma warning restore CS8618

    public Range(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Range(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RangeFromRaw.FromRawUnchecked"/>
    public static global::Bem.Models.Fs.Range FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RangeFromRaw : IFromRawJson<global::Bem.Models.Fs.Range>
{
    /// <inheritdoc/>
    public global::Bem.Models.Fs.Range FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Bem.Models.Fs.Range.FromRawUnchecked(rawData);
}
