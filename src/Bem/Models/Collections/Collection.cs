using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Collections;

/// <summary>
/// Collection details
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Collection, CollectionFromRaw>))]
public sealed record class Collection : JsonModel
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
    /// List of items in the collection (when fetching collection details)
    /// </summary>
    public IReadOnlyList<CollectionItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CollectionItem>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CollectionItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of items per page
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("limit", value);
        }
    }

    /// <summary>
    /// Current page number
    /// </summary>
    public long? Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// Total number of pages
    /// </summary>
    public long? TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalPages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalPages", value);
        }
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
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Limit;
        _ = this.Page;
        _ = this.TotalPages;
        _ = this.UpdatedAt;
    }

    public Collection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Collection(Collection collection)
        : base(collection) { }
#pragma warning restore CS8618

    public Collection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Collection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CollectionFromRaw.FromRawUnchecked"/>
    public static Collection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CollectionFromRaw : IFromRawJson<Collection>
{
    /// <inheritdoc/>
    public Collection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Collection.FromRawUnchecked(rawData);
}
