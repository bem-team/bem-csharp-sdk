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
[JsonConverter(typeof(JsonModelConverter<BucketListPageResponse, BucketListPageResponseFromRaw>))]
public sealed record class BucketListPageResponse : JsonModel
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

    public BucketListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketListPageResponse(BucketListPageResponse bucketListPageResponse)
        : base(bucketListPageResponse) { }
#pragma warning restore CS8618

    public BucketListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BucketListPageResponseFromRaw.FromRawUnchecked"/>
    public static BucketListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BucketListPageResponseFromRaw : IFromRawJson<BucketListPageResponse>
{
    /// <inheritdoc/>
    public BucketListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BucketListPageResponse.FromRawUnchecked(rawData);
}
