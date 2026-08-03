using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Models.Outputs;

namespace Bem.Models.Eval.Score;

/// <summary>
/// A single file input with base64-encoded content.
///
/// <para>When using the Bem CLI, use `@path/to/file` in the `inputContent` field
/// to automatically read and base64-encode the file: `--input.single-file '{"inputContent":
/// "@file.pdf", "inputType": "pdf"}' --wait`</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileInput, FileInputFromRaw>))]
public sealed record class FileInput : JsonModel
{
    /// <summary>
    /// Base64-encoded file content. In the Bem CLI, use `@path/to/file` to embed
    /// file contents automatically.
    /// </summary>
    public required string InputContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inputContent");
        }
        init { this._rawData.Set("inputContent", value); }
    }

    /// <summary>
    /// The input type of the content you're sending for transformation.
    ///
    /// <para>`jfif` is accepted as an alias for `jpeg` — JFIF is the same format
    /// under a different extension — and is normalized to `jpeg`, so responses and
    /// webhooks report `jpeg` for a JFIF upload. The undeclared alias `jpg` behaves
    /// the same way.</para>
    /// </summary>
    public required ApiEnum<string, InputType> InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InputType>>("inputType");
        }
        init { this._rawData.Set("inputType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputContent;
        this.InputType.Validate();
    }

    public FileInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileInput(FileInput fileInput)
        : base(fileInput) { }
#pragma warning restore CS8618

    public FileInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileInputFromRaw.FromRawUnchecked"/>
    public static FileInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileInputFromRaw : IFromRawJson<FileInput>
{
    /// <inheritdoc/>
    public FileInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileInput.FromRawUnchecked(rawData);
}
