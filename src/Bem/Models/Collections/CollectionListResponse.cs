using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Collections;

/// <summary>
/// Collection metadata without items
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CollectionListResponse, CollectionListResponseFromRaw>))]
public sealed record class CollectionListResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the collection
    /// </summary>
    public required string CollectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collectionID");
        }
        init { this._rawData.Set("collectionID", value); }
    }

    /// <summary>
    /// The collection name/path. Only letters, digits, underscores, and dots are allowed.
    /// </summary>
    public required string CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collectionName");
        }
        init { this._rawData.Set("collectionName", value); }
    }

    /// <summary>
    /// When the collection was created
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
    /// Number of items in the collection
    /// </summary>
    public required long ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("itemCount");
        }
        init { this._rawData.Set("itemCount", value); }
    }

    /// <summary>
    /// When the collection was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CollectionID;
        _ = this.CollectionName;
        _ = this.CreatedAt;
        _ = this.ItemCount;
        _ = this.UpdatedAt;
    }

    public CollectionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionListResponse(CollectionListResponse collectionListResponse)
        : base(collectionListResponse) { }
#pragma warning restore CS8618

    public CollectionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CollectionListResponseFromRaw.FromRawUnchecked"/>
    public static CollectionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CollectionListResponseFromRaw : IFromRawJson<CollectionListResponse>
{
    /// <inheritdoc/>
    public CollectionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CollectionListResponse.FromRawUnchecked(rawData);
}
