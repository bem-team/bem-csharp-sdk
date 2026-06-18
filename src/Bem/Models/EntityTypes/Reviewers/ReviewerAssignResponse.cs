using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.EntityTypes.Reviewers;

/// <summary>
/// A reviewer assignment links a user to an entity type they are responsible for
/// reviewing. The assignment is scoped to an account+environment and is unique per
/// (entity type, user).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReviewerAssignResponse, ReviewerAssignResponseFromRaw>))]
public sealed record class ReviewerAssignResponse : JsonModel
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

    public ReviewerAssignResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReviewerAssignResponse(ReviewerAssignResponse reviewerAssignResponse)
        : base(reviewerAssignResponse) { }
#pragma warning restore CS8618

    public ReviewerAssignResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReviewerAssignResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReviewerAssignResponseFromRaw.FromRawUnchecked"/>
    public static ReviewerAssignResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReviewerAssignResponseFromRaw : IFromRawJson<ReviewerAssignResponse>
{
    /// <inheritdoc/>
    public ReviewerAssignResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReviewerAssignResponse.FromRawUnchecked(rawData);
}
