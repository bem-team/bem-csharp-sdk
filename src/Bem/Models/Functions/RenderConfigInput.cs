using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Request-side render configuration. Carries the template document as base64-encoded
/// `.docx` bytes: the server validates them, stores the template, and derives the
/// placeholder/style-id contract at create/update time, so clients never submit
/// `placeholders` or `styleIds`. The response shape (`RenderConfig`) returns the
/// derived contract.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RenderConfigInput, RenderConfigInputFromRaw>))]
public sealed record class RenderConfigInput : JsonModel
{
    public required RenderConfigInputTemplate Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RenderConfigInputTemplate>("template");
        }
        init { this._rawData.Set("template", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Template.Validate();
    }

    public RenderConfigInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RenderConfigInput(RenderConfigInput renderConfigInput)
        : base(renderConfigInput) { }
#pragma warning restore CS8618

    public RenderConfigInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RenderConfigInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RenderConfigInputFromRaw.FromRawUnchecked"/>
    public static RenderConfigInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RenderConfigInput(RenderConfigInputTemplate template)
        : this()
    {
        this.Template = template;
    }
}

class RenderConfigInputFromRaw : IFromRawJson<RenderConfigInput>
{
    /// <inheritdoc/>
    public RenderConfigInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RenderConfigInput.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<RenderConfigInputTemplate, RenderConfigInputTemplateFromRaw>)
)]
public sealed record class RenderConfigInputTemplate : JsonModel
{
    /// <summary>
    /// Base64-encoded `.docx` bytes. In the Bem CLI, use `@path/to/file` to embed
    /// it automatically.
    /// </summary>
    public required string Base64
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("base64");
        }
        init { this._rawData.Set("base64", value); }
    }

    /// <summary>
    /// Original upload filename (e.g. `contract.docx`), stored for display only.
    /// Does not affect where the template is stored.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Base64;
        _ = this.Name;
    }

    public RenderConfigInputTemplate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RenderConfigInputTemplate(RenderConfigInputTemplate renderConfigInputTemplate)
        : base(renderConfigInputTemplate) { }
#pragma warning restore CS8618

    public RenderConfigInputTemplate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RenderConfigInputTemplate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RenderConfigInputTemplateFromRaw.FromRawUnchecked"/>
    public static RenderConfigInputTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RenderConfigInputTemplate(string base64)
        : this()
    {
        this.Base64 = base64;
    }
}

class RenderConfigInputTemplateFromRaw : IFromRawJson<RenderConfigInputTemplate>
{
    /// <inheritdoc/>
    public RenderConfigInputTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RenderConfigInputTemplate.FromRawUnchecked(rawData);
}
