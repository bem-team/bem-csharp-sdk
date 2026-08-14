using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// Per-version configuration for a Render function.
///
/// <para>Render emits a `.docx` from schema-typed JSON by composing the JSON into
/// a `.docx` template. The template document is stored server-side; this response
/// exposes only the contract derived from it. Schema validation runs internally
/// in the ML service against the bundled core schema; no customer-supplied schema
/// rides this surface.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RenderConfig, RenderConfigFromRaw>))]
public sealed record class RenderConfig : JsonModel
{
    /// <summary>
    /// The uploaded template: its filename, a short-lived presigned download URL,
    /// and the placeholder/style contract derived from it. Absent on configs created
    /// before template capture existed.
    /// </summary>
    public Template? Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Template>("template");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Template?.Validate();
    }

    public RenderConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RenderConfig(RenderConfig renderConfig)
        : base(renderConfig) { }
#pragma warning restore CS8618

    public RenderConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RenderConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RenderConfigFromRaw.FromRawUnchecked"/>
    public static RenderConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RenderConfigFromRaw : IFromRawJson<RenderConfig>
{
    /// <inheritdoc/>
    public RenderConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RenderConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The uploaded template: its filename, a short-lived presigned download URL, and
/// the placeholder/style contract derived from it. Absent on configs created before
/// template capture existed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Template, TemplateFromRaw>))]
public sealed record class Template : JsonModel
{
    /// <summary>
    /// Short-lived presigned URL to download the stored `.docx`. The private storage
    /// location is never exposed.
    /// </summary>
    public string? DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("downloadURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("downloadURL", value);
        }
    }

    /// <summary>
    /// Supported list kinds (`decimal`, `bullet`) the template's `numbering.xml`
    /// defines an `abstractNum` for. Empty means the template can hold no list,
    /// so any list primitive will fail at render.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ListKind>>? ListKinds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, ListKind>>>(
                "listKinds"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, ListKind>>?>(
                "listKinds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Original filename of the uploaded template (e.g. `contract.docx`), echoed
    /// back for display. Absent on templates uploaded before the filename was captured.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The placeholder contract a Render template declares, grouped by how each placeholder
    /// is filled. Derived from the template at create/update time by scanning its
    /// `docxtpl` tags; not user-supplied.
    ///
    /// <para>- `stringKeys`: bare string placeholders (`{{ key }}`) filled with
    /// a single value. - `blockKeys`: wrapped-primitive placeholders (`{{p key }}`)
    /// — bind one core primitive (paragraph, table, image, or list). The placeholder's
    /// own paragraph dissolves and is replaced by the rendered subdocument's blocks,
    /// rather than substituting text inline.</para>
    /// </summary>
    public Placeholders? Placeholders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Placeholders>("placeholders");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("placeholders", value);
        }
    }

    /// <summary>
    /// Paragraph/character style IDs the uploaded template defines and the rendered
    /// output can reference. Derived from the template's `styles.xml` at create/update time.
    /// </summary>
    public IReadOnlyList<string>? StyleIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("styleIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "styleIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Style IDs whose type is table — the styles a `table` primitive's required
    /// `styleId` can name. Empty means the template defines no table style, so any
    /// table primitive will fail at render.
    /// </summary>
    public IReadOnlyList<string>? TableStyleIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tableStyleIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tableStyleIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadUrl;
        foreach (var item in this.ListKinds ?? [])
        {
            item.Validate();
        }
        _ = this.Name;
        this.Placeholders?.Validate();
        _ = this.StyleIds;
        _ = this.TableStyleIds;
    }

    public Template() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Template(Template template)
        : base(template) { }
#pragma warning restore CS8618

    public Template(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Template(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateFromRaw.FromRawUnchecked"/>
    public static Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateFromRaw : IFromRawJson<Template>
{
    /// <inheritdoc/>
    public Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Template.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ListKindConverter))]
public enum ListKind
{
    Decimal,
    Bullet,
}

sealed class ListKindConverter : JsonConverter<ListKind>
{
    public override ListKind Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "decimal" => ListKind.Decimal,
            "bullet" => ListKind.Bullet,
            _ => (ListKind)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, ListKind value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ListKind.Decimal => "decimal",
                ListKind.Bullet => "bullet",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The placeholder contract a Render template declares, grouped by how each placeholder
/// is filled. Derived from the template at create/update time by scanning its `docxtpl`
/// tags; not user-supplied.
///
/// <para>- `stringKeys`: bare string placeholders (`{{ key }}`) filled with a single
/// value. - `blockKeys`: wrapped-primitive placeholders (`{{p key }}`) — bind one
/// core primitive (paragraph, table, image, or list). The placeholder's own paragraph
/// dissolves and is replaced by the rendered subdocument's blocks, rather than substituting
/// text inline.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Placeholders, PlaceholdersFromRaw>))]
public sealed record class Placeholders : JsonModel
{
    public required IReadOnlyList<string> BlockKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("blockKeys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "blockKeys",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<string> StringKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("stringKeys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "stringKeys",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BlockKeys;
        _ = this.StringKeys;
    }

    public Placeholders() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Placeholders(Placeholders placeholders)
        : base(placeholders) { }
#pragma warning restore CS8618

    public Placeholders(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Placeholders(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaceholdersFromRaw.FromRawUnchecked"/>
    public static Placeholders FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaceholdersFromRaw : IFromRawJson<Placeholders>
{
    /// <inheritdoc/>
    public Placeholders FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Placeholders.FromRawUnchecked(rawData);
}
