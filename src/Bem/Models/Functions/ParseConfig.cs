using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Per-version configuration for a Parse function.
///
/// <para>Parse renders document pages (PDF, image) via vision LLM and emits structured
/// JSON. The two toggles below independently control entity extraction (a per-call
/// output concern) and cross-document memory linking (an environment-wide concern).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParseConfig, ParseConfigFromRaw>))]
public sealed record class ParseConfig : JsonModel
{
    /// <summary>
    /// When true, extract named entities (people, organizations, products, studies,
    /// identifiers, etc.) and the relationships between them, and dedupe by canonical
    /// name within the document. When false, only `sections[]` is extracted; `entities[]`
    /// and `relationships[]` come back empty in the parse output. Defaults to true.
    /// </summary>
    public bool? ExtractEntities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("extractEntities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extractEntities", value);
        }
    }

    /// <summary>
    /// When true, link this document's entities to entities seen in earlier documents
    /// in this environment, building one canonical record per real-world thing across
    /// the corpus. Visible in the Memory tab and queryable via `POST /v3/fs` (op=find
    /// / open / xref). Doesn't change this call's parse output. Requires `extractEntities=true`.
    /// Defaults to true.
    /// </summary>
    public bool? LinkAcrossDocuments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("linkAcrossDocuments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("linkAcrossDocuments", value);
        }
    }

    /// <summary>
    /// Optional JSONSchema. When provided, each chunk performs schema-guided extraction.
    /// When absent, chunks perform open-ended discovery and return sections, entities,
    /// and relationships per the discovery schema.
    /// </summary>
    public JsonElement? Schema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("schema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("schema", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExtractEntities;
        _ = this.LinkAcrossDocuments;
        _ = this.Schema;
    }

    public ParseConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParseConfig(ParseConfig parseConfig)
        : base(parseConfig) { }
#pragma warning restore CS8618

    public ParseConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParseConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParseConfigFromRaw.FromRawUnchecked"/>
    public static ParseConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParseConfigFromRaw : IFromRawJson<ParseConfig>
{
    /// <inheritdoc/>
    public ParseConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ParseConfig.FromRawUnchecked(rawData);
}
