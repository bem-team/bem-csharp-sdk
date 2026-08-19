using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Entities;

/// <summary>
/// `200` response for a synchronously processed (small) batch.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityBulkCreateResponse, EntityBulkCreateResponseFromRaw>)
)]
public sealed record class EntityBulkCreateResponse : JsonModel
{
    /// <summary>
    /// Per-row outcomes, in request order.
    /// </summary>
    public required IReadOnlyList<SeedRowResult> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SeedRowResult>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SeedRowResult>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Aggregate counts.
    /// </summary>
    public required Summary Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Summary>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
        this.Summary.Validate();
    }

    public EntityBulkCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBulkCreateResponse(EntityBulkCreateResponse entityBulkCreateResponse)
        : base(entityBulkCreateResponse) { }
#pragma warning restore CS8618

    public EntityBulkCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBulkCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityBulkCreateResponseFromRaw.FromRawUnchecked"/>
    public static EntityBulkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityBulkCreateResponseFromRaw : IFromRawJson<EntityBulkCreateResponse>
{
    /// <inheritdoc/>
    public EntityBulkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityBulkCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregate counts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Summary, SummaryFromRaw>))]
public sealed record class Summary : JsonModel
{
    /// <summary>
    /// Number of rows that created a new entity.
    /// </summary>
    public required int Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// Number of rows merged into an existing entity.
    /// </summary>
    public required int Merged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("merged");
        }
        init { this._rawData.Set("merged", value); }
    }

    /// <summary>
    /// Number of rows rejected.
    /// </summary>
    public required int Rejected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("rejected");
        }
        init { this._rawData.Set("rejected", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Created;
        _ = this.Merged;
        _ = this.Rejected;
    }

    public Summary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Summary(Summary summary)
        : base(summary) { }
#pragma warning restore CS8618

    public Summary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Summary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SummaryFromRaw.FromRawUnchecked"/>
    public static Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SummaryFromRaw : IFromRawJson<Summary>
{
    /// <inheritdoc/>
    public Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Summary.FromRawUnchecked(rawData);
}
