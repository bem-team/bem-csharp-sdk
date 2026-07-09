using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Cross-cutting toggles for Parse functions. Mirrors the `extraConfig` surface on
/// Extract / Join — separated from `parseConfig` so the per-call Parse output shape
/// stays distinct from operator-level execution flags.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ParseExtraFunctionConfig, ParseExtraFunctionConfigFromRaw>)
)]
public sealed record class ParseExtraFunctionConfig : JsonModel
{
    /// <summary>
    /// When true, return per-section and per-entity-mention coordinates in the parse
    /// event's `fieldBoundingBoxes` map (same shape as Extract: JSON Pointer key
    /// → array of `{page, left, top, width, height}` with coordinates normalized
    /// to [0, 1]). Keys are `/sections/{N}` and `/entities/{N}/occurrences/{M}` into
    /// the parse output. Only applies to the open-ended discovery path (no `schema`)
    /// and to vision input types. Bedrock-backed parse functions silently return
    /// an empty map (no native bbox support). Defaults to false.
    /// </summary>
    public bool? EnableBoundingBoxes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enableBoundingBoxes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enableBoundingBoxes", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EnableBoundingBoxes;
    }

    public ParseExtraFunctionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParseExtraFunctionConfig(ParseExtraFunctionConfig parseExtraFunctionConfig)
        : base(parseExtraFunctionConfig) { }
#pragma warning restore CS8618

    public ParseExtraFunctionConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParseExtraFunctionConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParseExtraFunctionConfigFromRaw.FromRawUnchecked"/>
    public static ParseExtraFunctionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParseExtraFunctionConfigFromRaw : IFromRawJson<ParseExtraFunctionConfig>
{
    /// <inheritdoc/>
    public ParseExtraFunctionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParseExtraFunctionConfig.FromRawUnchecked(rawData);
}
