using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.ReviewQueue;

/// <summary>
/// **List entities awaiting curation, for a human reviewer's queue.**
///
/// <para>Returns a cursor-paginated set of entities scoped to your account+environment
/// (and optional `bucket`), each carrying a small preview of its first mentions
/// so a reviewer can triage without opening every entity. All filters AND together.</para>
///
/// <para>- **`status`** (repeatable) restricts to the given lifecycle states. Omitting
/// it defaults to the pre-terminal states `extracted` and `proposed`. - **`type`**
/// (repeatable, `ety_...` IDs) matches the entity's *effective* type: an entity matches
/// when its assigned type is one of these IDs, or it has no assigned type and its
/// bem-inferred type name matches one of them. - **`assignedTo`** (`me` or a `usr_...`
/// ID) restricts to entities whose effective type the given user reviews. `me` resolves
/// to the calling user. - **`since`** (RFC3339) restricts to entities created at
/// or after the time.</para>
///
/// <para>Pagination is cursor-based on `entityID` ascending; default limit is 50,
/// maximum 200.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReviewQueueListParams : ParamsBase
{
    /// <summary>
    /// `me` or a `usr_...` ID — restrict to entities whose effective type that user reviews.
    /// </summary>
    public string? AssignedTo
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("assignedTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("assignedTo", value);
        }
    }

    /// <summary>
    /// Optional bucket public ID (`bkt_...`) to scope to. Omit for all buckets.
    /// </summary>
    public string? Bucket
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("bucket");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("bucket", value);
        }
    }

    /// <summary>
    /// Cursor — an `entityID` defining your place in the list.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    public int? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// RFC3339 timestamp — restrict to entities created at or after this time.
    /// </summary>
    public string? Since
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("since");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("since", value);
        }
    }

    /// <summary>
    /// Restrict to these lifecycle states. Defaults to `extracted` + `proposed`.
    /// </summary>
    public IReadOnlyList<string>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Restrict to entities whose effective type is one of these `ety_...` IDs.
    /// </summary>
    public IReadOnlyList<string>? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "type",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ReviewQueueListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReviewQueueListParams(ReviewQueueListParams reviewQueueListParams)
        : base(reviewQueueListParams) { }
#pragma warning restore CS8618

    public ReviewQueueListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReviewQueueListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ReviewQueueListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ReviewQueueListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/review-queue")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
