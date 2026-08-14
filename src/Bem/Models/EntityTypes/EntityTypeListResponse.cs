using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.EntityTypes;

/// <summary>
/// Response body for listing entity types.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityTypeListResponse, EntityTypeListResponseFromRaw>))]
public sealed record class EntityTypeListResponse : JsonModel
{
    public required IReadOnlyList<EntityType> EntityTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntityType>>("entityTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityType>>(
                "entityTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total number of entity types matching the query, ignoring pagination.
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalCount");
        }
        init { this._rawData.Set("totalCount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.EntityTypes)
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public EntityTypeListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTypeListResponse(EntityTypeListResponse entityTypeListResponse)
        : base(entityTypeListResponse) { }
#pragma warning restore CS8618

    public EntityTypeListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTypeListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTypeListResponseFromRaw.FromRawUnchecked"/>
    public static EntityTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTypeListResponseFromRaw : IFromRawJson<EntityTypeListResponse>
{
    /// <inheritdoc/>
    public EntityTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTypeListResponse.FromRawUnchecked(rawData);
}
