using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Entities;

/// <summary>
/// An entity record, including its curation status and assigned type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityUpdateResponse, EntityUpdateResponseFromRaw>))]
public sealed record class EntityUpdateResponse : JsonModel
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
    /// Creation timestamp.
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
    /// Public ID (`ent_...`).
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
    /// Total mentions across parsed documents.
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
    /// Curation lifecycle state.
    /// </summary>
    public required ApiEnum<string, EntityUpdateResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityUpdateResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Distinct surface forms resolved to this entity.
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
    /// The entity's effective type name (assigned type if set, else inferred).
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
    /// Last-update timestamp.
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
    /// Free-form description.
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
    /// `ety_...` public ID of the assigned type, when one is set.
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
    /// When the entity was approved/rejected. Present only once validated.
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
    /// `usr_...` public ID of the validating user (dashboard transitions only).
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
        this.Status.Validate();
        _ = this.SurfaceForms;
        _ = this.Type;
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.TypeID;
        _ = this.ValidatedAt;
        _ = this.ValidatedByUserID;
    }

    public EntityUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateResponse(EntityUpdateResponse entityUpdateResponse)
        : base(entityUpdateResponse) { }
#pragma warning restore CS8618

    public EntityUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateResponseFromRaw.FromRawUnchecked"/>
    public static EntityUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateResponseFromRaw : IFromRawJson<EntityUpdateResponse>
{
    /// <inheritdoc/>
    public EntityUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Curation lifecycle state.
/// </summary>
[JsonConverter(typeof(EntityUpdateResponseStatusConverter))]
public enum EntityUpdateResponseStatus
{
    Extracted,
    Proposed,
    Approved,
    Rejected,
}

sealed class EntityUpdateResponseStatusConverter : JsonConverter<EntityUpdateResponseStatus>
{
    public override EntityUpdateResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "extracted" => EntityUpdateResponseStatus.Extracted,
            "proposed" => EntityUpdateResponseStatus.Proposed,
            "approved" => EntityUpdateResponseStatus.Approved,
            "rejected" => EntityUpdateResponseStatus.Rejected,
            _ => (EntityUpdateResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateResponseStatus.Extracted => "extracted",
                EntityUpdateResponseStatus.Proposed => "proposed",
                EntityUpdateResponseStatus.Approved => "approved",
                EntityUpdateResponseStatus.Rejected => "rejected",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
