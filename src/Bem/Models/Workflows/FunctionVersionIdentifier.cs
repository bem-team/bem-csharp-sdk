using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

[JsonConverter(
    typeof(JsonModelConverter<FunctionVersionIdentifier, FunctionVersionIdentifierFromRaw>)
)]
public sealed record class FunctionVersionIdentifier : JsonModel
{
    /// <summary>
    /// Unique identifier of function. Provide either id or name, not both.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis. Provide either
    /// id or name, not both.
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
    /// Version number of function.
    /// </summary>
    public long? VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("versionNum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("versionNum", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.VersionNum;
    }

    public FunctionVersionIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionVersionIdentifier(FunctionVersionIdentifier functionVersionIdentifier)
        : base(functionVersionIdentifier) { }
#pragma warning restore CS8618

    public FunctionVersionIdentifier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionVersionIdentifier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionVersionIdentifierFromRaw.FromRawUnchecked"/>
    public static FunctionVersionIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionVersionIdentifierFromRaw : IFromRawJson<FunctionVersionIdentifier>
{
    /// <inheritdoc/>
    public FunctionVersionIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionVersionIdentifier.FromRawUnchecked(rawData);
}
