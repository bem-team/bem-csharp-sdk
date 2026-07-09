using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.EntityTypes.Reviewers;

/// <summary>
/// Response body for listing the reviewers of an entity type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReviewerListResponse, ReviewerListResponseFromRaw>))]
public sealed record class ReviewerListResponse : JsonModel
{
    public required IReadOnlyList<Reviewer> Reviewers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Reviewer>>("reviewers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Reviewer>>(
                "reviewers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Reviewers)
        {
            item.Validate();
        }
    }

    public ReviewerListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReviewerListResponse(ReviewerListResponse reviewerListResponse)
        : base(reviewerListResponse) { }
#pragma warning restore CS8618

    public ReviewerListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReviewerListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReviewerListResponseFromRaw.FromRawUnchecked"/>
    public static ReviewerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReviewerListResponse(IReadOnlyList<Reviewer> reviewers)
        : this()
    {
        this.Reviewers = reviewers;
    }
}

class ReviewerListResponseFromRaw : IFromRawJson<ReviewerListResponse>
{
    /// <inheritdoc/>
    public ReviewerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReviewerListResponse.FromRawUnchecked(rawData);
}
