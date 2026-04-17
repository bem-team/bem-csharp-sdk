using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows.Versions;

[JsonConverter(typeof(JsonModelConverter<VersionRetrieveResponse, VersionRetrieveResponseFromRaw>))]
public sealed record class VersionRetrieveResponse : JsonModel
{
    /// <summary>
    /// Error message if the workflow version retrieval failed.
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// V3 read representation of a workflow version.
    /// </summary>
    public Workflow? Workflow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Workflow>("workflow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflow", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        this.Workflow?.Validate();
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
}

class VersionRetrieveResponseFromRaw : IFromRawJson<VersionRetrieveResponse>
{
    /// <inheritdoc/>
    public VersionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionRetrieveResponse.FromRawUnchecked(rawData);
}
