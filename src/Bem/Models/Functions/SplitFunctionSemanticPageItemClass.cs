using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

[JsonConverter(
    typeof(JsonModelConverter<
        SplitFunctionSemanticPageItemClass,
        SplitFunctionSemanticPageItemClassFromRaw
    >)
)]
public sealed record class SplitFunctionSemanticPageItemClass : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// The unique ID of the function you want to use for this item class.
    /// </summary>
    public string? NextFunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextFunctionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextFunctionID", value);
        }
    }

    /// <summary>
    /// The unique name of the function you want to use for this item class.
    /// </summary>
    public string? NextFunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextFunctionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextFunctionName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.NextFunctionID;
        _ = this.NextFunctionName;
    }

    public SplitFunctionSemanticPageItemClass() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitFunctionSemanticPageItemClass(
        SplitFunctionSemanticPageItemClass splitFunctionSemanticPageItemClass
    )
        : base(splitFunctionSemanticPageItemClass) { }
#pragma warning restore CS8618

    public SplitFunctionSemanticPageItemClass(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitFunctionSemanticPageItemClass(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitFunctionSemanticPageItemClassFromRaw.FromRawUnchecked"/>
    public static SplitFunctionSemanticPageItemClass FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SplitFunctionSemanticPageItemClass(string name)
        : this()
    {
        this.Name = name;
    }
}

class SplitFunctionSemanticPageItemClassFromRaw : IFromRawJson<SplitFunctionSemanticPageItemClass>
{
    /// <inheritdoc/>
    public SplitFunctionSemanticPageItemClass FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitFunctionSemanticPageItemClass.FromRawUnchecked(rawData);
}
