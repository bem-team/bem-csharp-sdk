using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Entities;

/// <summary>
/// Response body for `GET /v3/entities/{id}/relations`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityRetrieveRelationsResponse,
        EntityRetrieveRelationsResponseFromRaw
    >)
)]
public sealed record class EntityRetrieveRelationsResponse : JsonModel
{
    /// <summary>
    /// Edges pointing at the queried entity.
    /// </summary>
    public required IReadOnlyList<Inbound> Inbound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Inbound>>("inbound");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Inbound>>(
                "inbound",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Edges pointing away from the queried entity.
    /// </summary>
    public required IReadOnlyList<Outbound> Outbound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Outbound>>("outbound");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Outbound>>(
                "outbound",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page of edges, or absent on the last page. Pass
    /// it back as `cursor`.
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Inbound)
        {
            item.Validate();
        }
        foreach (var item in this.Outbound)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public EntityRetrieveRelationsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityRetrieveRelationsResponse(
        EntityRetrieveRelationsResponse entityRetrieveRelationsResponse
    )
        : base(entityRetrieveRelationsResponse) { }
#pragma warning restore CS8618

    public EntityRetrieveRelationsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityRetrieveRelationsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityRetrieveRelationsResponseFromRaw.FromRawUnchecked"/>
    public static EntityRetrieveRelationsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityRetrieveRelationsResponseFromRaw : IFromRawJson<EntityRetrieveRelationsResponse>
{
    /// <inheritdoc/>
    public EntityRetrieveRelationsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityRetrieveRelationsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One edge pointing AT the queried entity (some other entity is the source).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Inbound, InboundFromRaw>))]
public sealed record class Inbound : JsonModel
{
    /// <summary>
    /// First-seen timestamp of the edge (RFC 3339).
    /// </summary>
    public required DateTimeOffset FirstSeenAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("firstSeenAt");
        }
        init { this._rawData.Set("firstSeenAt", value); }
    }

    /// <summary>
    /// How many times this edge has been observed across parsed documents.
    /// </summary>
    public required int MentionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("mentionCount");
        }
        init { this._rawData.Set("mentionCount", value); }
    }

    /// <summary>
    /// Free-form relation label (e.g. `author_of`, `affiliated_with`).
    /// </summary>
    public required string RelationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("relationType");
        }
        init { this._rawData.Set("relationType", value); }
    }

    /// <summary>
    /// The entity at the tail of the edge.
    /// </summary>
    public required RelatedEntity SourceEntity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RelatedEntity>("sourceEntity");
        }
        init { this._rawData.Set("sourceEntity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstSeenAt;
        _ = this.MentionCount;
        _ = this.RelationType;
        this.SourceEntity.Validate();
    }

    public Inbound() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Inbound(Inbound inbound)
        : base(inbound) { }
#pragma warning restore CS8618

    public Inbound(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Inbound(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundFromRaw.FromRawUnchecked"/>
    public static Inbound FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundFromRaw : IFromRawJson<Inbound>
{
    /// <inheritdoc/>
    public Inbound FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Inbound.FromRawUnchecked(rawData);
}

/// <summary>
/// One edge pointing AWAY from the queried entity (it is the source).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Outbound, OutboundFromRaw>))]
public sealed record class Outbound : JsonModel
{
    /// <summary>
    /// First-seen timestamp of the edge (RFC 3339).
    /// </summary>
    public required DateTimeOffset FirstSeenAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("firstSeenAt");
        }
        init { this._rawData.Set("firstSeenAt", value); }
    }

    /// <summary>
    /// How many times this edge has been observed across parsed documents.
    /// </summary>
    public required int MentionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("mentionCount");
        }
        init { this._rawData.Set("mentionCount", value); }
    }

    /// <summary>
    /// Free-form relation label (e.g. `author_of`, `affiliated_with`).
    /// </summary>
    public required string RelationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("relationType");
        }
        init { this._rawData.Set("relationType", value); }
    }

    /// <summary>
    /// The entity at the head of the edge.
    /// </summary>
    public required RelatedEntity TargetEntity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RelatedEntity>("targetEntity");
        }
        init { this._rawData.Set("targetEntity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstSeenAt;
        _ = this.MentionCount;
        _ = this.RelationType;
        this.TargetEntity.Validate();
    }

    public Outbound() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Outbound(Outbound outbound)
        : base(outbound) { }
#pragma warning restore CS8618

    public Outbound(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Outbound(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutboundFromRaw.FromRawUnchecked"/>
    public static Outbound FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutboundFromRaw : IFromRawJson<Outbound>
{
    /// <inheritdoc/>
    public Outbound FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Outbound.FromRawUnchecked(rawData);
}
