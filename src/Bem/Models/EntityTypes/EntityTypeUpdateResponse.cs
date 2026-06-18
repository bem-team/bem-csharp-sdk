using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.EntityTypes;

/// <summary>
/// An EntityType is a customer-defined type in the knowledge-graph taxonomy, scoped
/// to an account+environment. Types may be organised into hierarchies via `parentTypeID`,
/// and may carry per-type structured attribute metadata in `attributeSchema` (for
/// example `{"unit": "mg", "range": [0, 100]}`).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityTypeUpdateResponse, EntityTypeUpdateResponseFromRaw>)
)]
public sealed record class EntityTypeUpdateResponse : JsonModel
{
    /// <summary>
    /// Creation timestamp (RFC 3339).
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Optional human-facing note about the type.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Human-facing type name. Unique within an account+environment, and immutable
    /// once set.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Public ID (`ety_...`) of the parent type, or an empty string when the type
    /// is top-level.
    /// </summary>
    public required string ParentTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("parentTypeID");
        }
        init { this._rawData.Set("parentTypeID", value); }
    }

    /// <summary>
    /// Stable public identifier for the entity type (`ety_...`).
    /// </summary>
    public required string TypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("typeID");
        }
        init { this._rawData.Set("typeID", value); }
    }

    /// <summary>
    /// Last-update timestamp (RFC 3339).
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Optional per-type structured attribute metadata.
    /// </summary>
    public JsonElement? AttributeSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("attributeSchema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("attributeSchema", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.ParentTypeID;
        _ = this.TypeID;
        _ = this.UpdatedAt;
        _ = this.AttributeSchema;
    }

    public EntityTypeUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTypeUpdateResponse(EntityTypeUpdateResponse entityTypeUpdateResponse)
        : base(entityTypeUpdateResponse) { }
#pragma warning restore CS8618

    public EntityTypeUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTypeUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTypeUpdateResponseFromRaw.FromRawUnchecked"/>
    public static EntityTypeUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTypeUpdateResponseFromRaw : IFromRawJson<EntityTypeUpdateResponse>
{
    /// <inheritdoc/>
    public EntityTypeUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTypeUpdateResponse.FromRawUnchecked(rawData);
}
