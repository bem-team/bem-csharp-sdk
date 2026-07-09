using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Buckets;

/// <summary>
/// A Bucket is a named partition of the knowledge graph within an account+environment.
/// Entities, mentions, and relations are scoped to a bucket so a single account+environment
/// can host multiple isolated graphs.
///
/// <para>Every account+environment has exactly one default bucket. The default bucket
/// can be renamed but never deleted.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BucketV3, BucketV3FromRaw>))]
public sealed record class BucketV3 : JsonModel
{
    /// <summary>
    /// Stable public identifier for the bucket (`bkt_...`).
    /// </summary>
    public required string BucketID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucketID");
        }
        init { this._rawData.Set("bucketID", value); }
    }

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
    /// Optional human-facing note about the bucket.
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
    /// Whether this is the account+environment's default bucket.
    /// </summary>
    public required bool IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isDefault");
        }
        init { this._rawData.Set("isDefault", value); }
    }

    /// <summary>
    /// Human-facing bucket name. Unique within an account+environment.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BucketID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.IsDefault;
        _ = this.Name;
        _ = this.UpdatedAt;
    }

    public BucketV3() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketV3(BucketV3 bucketV3)
        : base(bucketV3) { }
#pragma warning restore CS8618

    public BucketV3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketV3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BucketV3FromRaw.FromRawUnchecked"/>
    public static BucketV3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BucketV3FromRaw : IFromRawJson<BucketV3>
{
    /// <inheritdoc/>
    public BucketV3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BucketV3.FromRawUnchecked(rawData);
}
