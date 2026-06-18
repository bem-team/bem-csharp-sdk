using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Users;

/// <summary>
/// Response body for the reverse lookup of a user's reviewer assignments.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserListReviewerAssignmentsResponse,
        UserListReviewerAssignmentsResponseFromRaw
    >)
)]
public sealed record class UserListReviewerAssignmentsResponse : JsonModel
{
    public required IReadOnlyList<Assignment> Assignments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Assignment>>("assignments");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Assignment>>(
                "assignments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Assignments)
        {
            item.Validate();
        }
    }

    public UserListReviewerAssignmentsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListReviewerAssignmentsResponse(
        UserListReviewerAssignmentsResponse userListReviewerAssignmentsResponse
    )
        : base(userListReviewerAssignmentsResponse) { }
#pragma warning restore CS8618

    public UserListReviewerAssignmentsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListReviewerAssignmentsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListReviewerAssignmentsResponseFromRaw.FromRawUnchecked"/>
    public static UserListReviewerAssignmentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserListReviewerAssignmentsResponse(IReadOnlyList<Assignment> assignments)
        : this()
    {
        this.Assignments = assignments;
    }
}

class UserListReviewerAssignmentsResponseFromRaw : IFromRawJson<UserListReviewerAssignmentsResponse>
{
    /// <inheritdoc/>
    public UserListReviewerAssignmentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserListReviewerAssignmentsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One entity type a user reviews, as returned by the reverse-lookup endpoint. The
/// type is exposed via its public ID plus its name and description.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Assignment, AssignmentFromRaw>))]
public sealed record class Assignment : JsonModel
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
    /// The entity type's description.
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
    /// The entity type's human-facing name.
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
    /// Public ID (`ety_...`) of the entity type the user reviews.
    /// </summary>
    public required string TypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("typeID");
        }
        init { this._rawData.Set("typeID", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.TypeID;
    }

    public Assignment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Assignment(Assignment assignment)
        : base(assignment) { }
#pragma warning restore CS8618

    public Assignment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Assignment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssignmentFromRaw.FromRawUnchecked"/>
    public static Assignment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AssignmentFromRaw : IFromRawJson<Assignment>
{
    /// <inheritdoc/>
    public Assignment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Assignment.FromRawUnchecked(rawData);
}
