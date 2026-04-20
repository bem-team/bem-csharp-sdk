using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions.Versions;

/// <summary>
/// Single-function-version response wrapper used by V3 endpoints.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VersionRetrieveResponse, VersionRetrieveResponseFromRaw>))]
public sealed record class VersionRetrieveResponse : JsonModel
{
    /// <summary>
    /// V3 read-side union for function versions. Same shape as the shared `FunctionVersion`
    /// union but with `classify` in place of `route`.
    /// </summary>
    public required FunctionVersion Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionVersion>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
    }

    public VersionRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionRetrieveResponse(VersionRetrieveResponse versionRetrieveResponse)
        : base(versionRetrieveResponse) { }
#pragma warning restore CS8618

    public VersionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static VersionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VersionRetrieveResponse(FunctionVersion function)
        : this()
    {
        this.Function = function;
    }
}

class VersionRetrieveResponseFromRaw : IFromRawJson<VersionRetrieveResponse>
{
    /// <inheritdoc/>
    public VersionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionRetrieveResponse.FromRawUnchecked(rawData);
}
