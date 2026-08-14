using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Entities;

/// <summary>
/// A compact view of an entity sitting on the far end of a relation edge — the stable
/// public id, the canonical name, and the effective type. The full entity is fetched
/// separately via the entity detail / File System endpoints.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RelatedEntity, RelatedEntityFromRaw>))]
public sealed record class RelatedEntity : JsonModel
{
    /// <summary>
    /// Stable public identifier for the entity (`ent_...`).
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Canonical (most descriptive) surface form of the entity.
    /// </summary>
    public required string Canonical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canonical");
        }
        init { this._rawData.Set("canonical", value); }
    }

    /// <summary>
    /// Hops from the queried entity. This endpoint returns direct relations, so this
    /// is 1 (a self-loop's far end is the queried entity itself, 0).
    /// </summary>
    public required int Depth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("depth");
        }
        init { this._rawData.Set("depth", value); }
    }

    /// <summary>
    /// Effective entity type.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Canonical;
        _ = this.Depth;
        _ = this.Type;
    }

    public RelatedEntity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RelatedEntity(RelatedEntity relatedEntity)
        : base(relatedEntity) { }
#pragma warning restore CS8618

    public RelatedEntity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RelatedEntity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RelatedEntityFromRaw.FromRawUnchecked"/>
    public static RelatedEntity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RelatedEntityFromRaw : IFromRawJson<RelatedEntity>
{
    /// <inheritdoc/>
    public RelatedEntity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RelatedEntity.FromRawUnchecked(rawData);
}
