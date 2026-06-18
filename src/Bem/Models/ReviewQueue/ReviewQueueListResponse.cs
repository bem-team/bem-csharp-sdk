using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.ReviewQueue;

/// <summary>
/// `GET /v3/review-queue` response. Cursor-paginated by `entityID` ascending.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReviewQueueListResponse, ReviewQueueListResponseFromRaw>))]
public sealed record class ReviewQueueListResponse : JsonModel
{
    /// <summary>
    /// The page of entities awaiting curation.
    /// </summary>
    public required IReadOnlyList<Entity> Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Entity>>("entities");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Entity>>(
                "entities",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether more rows exist beyond this page.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    /// <summary>
    /// Opaque cursor to pass as `?cursor=` for the next page. Empty when `hasMore`
    /// is false.
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Entities)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public ReviewQueueListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReviewQueueListResponse(ReviewQueueListResponse reviewQueueListResponse)
        : base(reviewQueueListResponse) { }
#pragma warning restore CS8618

    public ReviewQueueListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReviewQueueListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReviewQueueListResponseFromRaw.FromRawUnchecked"/>
    public static ReviewQueueListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReviewQueueListResponseFromRaw : IFromRawJson<ReviewQueueListResponse>
{
    /// <inheritdoc/>
    public ReviewQueueListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReviewQueueListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One row of the review queue: an entity plus a small preview of its mentions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Entity, EntityFromRaw>))]
public sealed record class Entity : JsonModel
{
    /// <summary>
    /// The canonical (longest / most descriptive) surface form.
    /// </summary>
    public required string Canonical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canonical");
        }
        init { this._rawData.Set("canonical", value); }
    }

    /// <summary>
    /// When the entity was created.
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
    /// Public ID (`ent_...`) of the entity.
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entityID");
        }
        init { this._rawData.Set("entityID", value); }
    }

    /// <summary>
    /// Total mentions across all parsed documents.
    /// </summary>
    public required int MentionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("mentionCount");
        }
        init { this._rawData.Set("mentionCount", value); }
    }

    /// <summary>
    /// A capped preview (up to 2) of the entity's first mentions, ordered by page
    /// then time, so a reviewer can triage without opening each entity.
    /// </summary>
    public required IReadOnlyList<PreviewMention> PreviewMentions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PreviewMention>>(
                "previewMentions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PreviewMention>>(
                "previewMentions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Curation lifecycle state: `extracted`, `proposed`, `approved`, `rejected`.
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Distinct surface forms that have resolved to this entity.
    /// </summary>
    public required IReadOnlyList<string> SurfaceForms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("surfaceForms");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "surfaceForms",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The effective type name (assigned override if set, else bem-inferred).
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// When the entity was last updated.
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

    /// <summary>
    /// Free-form description of the entity, when present.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Public ID (`ety_...`) of the customer-assigned type, when one is set.
    /// </summary>
    public string? TypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("typeID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("typeID", value);
        }
    }

    /// <summary>
    /// When a human approved/rejected the entity. Omitted while un-validated.
    /// </summary>
    public DateTimeOffset? ValidatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("validatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("validatedAt", value);
        }
    }

    /// <summary>
    /// Public ID (`usr_...`) of the user who validated the entity, when known.
    /// </summary>
    public string? ValidatedByUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("validatedByUserID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("validatedByUserID", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Canonical;
        _ = this.CreatedAt;
        _ = this.EntityID;
        _ = this.MentionCount;
        foreach (var item in this.PreviewMentions)
        {
            item.Validate();
        }
        _ = this.Status;
        _ = this.SurfaceForms;
        _ = this.Type;
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.TypeID;
        _ = this.ValidatedAt;
        _ = this.ValidatedByUserID;
    }

    public Entity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entity(Entity entity)
        : base(entity) { }
#pragma warning restore CS8618

    public Entity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityFromRaw.FromRawUnchecked"/>
    public static Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityFromRaw : IFromRawJson<Entity>
{
    /// <inheritdoc/>
    public Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entity.FromRawUnchecked(rawData);
}

/// <summary>
/// A single per-document occurrence of an entity, used in review-queue previews.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PreviewMention, PreviewMentionFromRaw>))]
public sealed record class PreviewMention : JsonModel
{
    /// <summary>
    /// When this mention was recorded.
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
    /// Public ID (`ent_...`) of the entity this mention resolves to.
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entityID");
        }
        init { this._rawData.Set("entityID", value); }
    }

    /// <summary>
    /// Public ID (`emn_...`) of this mention.
    /// </summary>
    public required string MentionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mentionID");
        }
        init { this._rawData.Set("mentionID", value); }
    }

    /// <summary>
    /// 1-indexed page number within the source document.
    /// </summary>
    public required int Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// The user-provided document handle this mention came from.
    /// </summary>
    public required string ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("referenceID");
        }
        init { this._rawData.Set("referenceID", value); }
    }

    /// <summary>
    /// The exact surface string Parse extracted on the page.
    /// </summary>
    public required string Surface
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("surface");
        }
        init { this._rawData.Set("surface", value); }
    }

    /// <summary>
    /// The parse-emitted section label this mention sat under, when present.
    /// </summary>
    public string? SectionLabel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sectionLabel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sectionLabel", value);
        }
    }

    /// <summary>
    /// Public ID of the parse transformation that produced this mention, when known.
    /// </summary>
    public string? TransformationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transformationID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transformationID", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.EntityID;
        _ = this.MentionID;
        _ = this.Page;
        _ = this.ReferenceID;
        _ = this.Surface;
        _ = this.SectionLabel;
        _ = this.TransformationID;
    }

    public PreviewMention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviewMention(PreviewMention previewMention)
        : base(previewMention) { }
#pragma warning restore CS8618

    public PreviewMention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviewMention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewMentionFromRaw.FromRawUnchecked"/>
    public static PreviewMention FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreviewMentionFromRaw : IFromRawJson<PreviewMention>
{
    /// <inheritdoc/>
    public PreviewMention FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PreviewMention.FromRawUnchecked(rawData);
}
