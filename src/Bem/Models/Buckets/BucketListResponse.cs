using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Buckets;

/// <summary>
/// Response body for listing buckets.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BucketListResponse, BucketListResponseFromRaw>))]
public sealed record class BucketListResponse : JsonModel
{
    public required IReadOnlyList<BucketV3> Buckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BucketV3>>("buckets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BucketV3>>(
                "buckets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total number of buckets matching the query, ignoring pagination.
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
        foreach (var item in this.Buckets)
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public BucketListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketListResponse(BucketListResponse bucketListResponse)
        : base(bucketListResponse) { }
#pragma warning restore CS8618

    public BucketListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BucketListResponseFromRaw.FromRawUnchecked"/>
    public static BucketListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BucketListResponseFromRaw : IFromRawJson<BucketListResponse>
{
    /// <inheritdoc/>
    public BucketListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BucketListResponse.FromRawUnchecked(rawData);
}
