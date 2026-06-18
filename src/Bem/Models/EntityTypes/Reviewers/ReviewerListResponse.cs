using System;
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

/// <summary>
/// A reviewer assignment links a user to an entity type they are responsible for
/// reviewing. The assignment is scoped to an account+environment and is unique per
/// (entity type, user).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Reviewer, ReviewerFromRaw>))]
public sealed record class Reviewer : JsonModel
{
    /// <summary>
    /// When the assignment was created (RFC 3339).
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
    /// The assigned user's email.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Stable public identifier for the assignment (`etr_...`).
    /// </summary>
    public required string ReviewerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reviewerID");
        }
        init { this._rawData.Set("reviewerID", value); }
    }

    /// <summary>
    /// The assigned user's account role (for example `operator`, `admin`).
    /// </summary>
    public required string Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Public identifier of the assigned user (`usr_...`).
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userID");
        }
        init { this._rawData.Set("userID", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Email;
        _ = this.ReviewerID;
        _ = this.Role;
        _ = this.UserID;
    }

    public Reviewer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Reviewer(Reviewer reviewer)
        : base(reviewer) { }
#pragma warning restore CS8618

    public Reviewer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Reviewer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReviewerFromRaw.FromRawUnchecked"/>
    public static Reviewer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReviewerFromRaw : IFromRawJson<Reviewer>
{
    /// <inheritdoc/>
    public Reviewer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Reviewer.FromRawUnchecked(rawData);
}
