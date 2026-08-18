using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Collections;

/// <summary>
/// Response for listing collections
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CollectionListPageResponse, CollectionListPageResponseFromRaw>)
)]
public sealed record class CollectionListPageResponse : JsonModel
{
    /// <summary>
    /// List of collections
    /// </summary>
    public required IReadOnlyList<CollectionListResponse> Collections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CollectionListResponse>>(
                "collections"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CollectionListResponse>>(
                "collections",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of collections per page
    /// </summary>
    public required long Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// Current page number
    /// </summary>
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// Total number of collections
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

    /// <summary>
    /// Total number of pages
    /// </summary>
    public required long TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalPages");
        }
        init { this._rawData.Set("totalPages", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Collections)
        {
            item.Validate();
        }
        _ = this.Limit;
        _ = this.Page;
        _ = this.TotalCount;
        _ = this.TotalPages;
    }

    public CollectionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionListPageResponse(CollectionListPageResponse collectionListPageResponse)
        : base(collectionListPageResponse) { }
#pragma warning restore CS8618

    public CollectionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CollectionListPageResponseFromRaw.FromRawUnchecked"/>
    public static CollectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CollectionListPageResponseFromRaw : IFromRawJson<CollectionListPageResponse>
{
    /// <inheritdoc/>
    public CollectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CollectionListPageResponse.FromRawUnchecked(rawData);
}
