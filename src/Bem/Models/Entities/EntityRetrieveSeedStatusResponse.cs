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
/// `GET /v3/entities/seed/{id}` response.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityRetrieveSeedStatusResponse,
        EntityRetrieveSeedStatusResponseFromRaw
    >)
)]
public sealed record class EntityRetrieveSeedStatusResponse : JsonModel
{
    /// <summary>
    /// Rows that created a new entity.
    /// </summary>
    public required int CreatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("createdCount");
        }
        init { this._rawData.Set("createdCount", value); }
    }

    /// <summary>
    /// Rows merged into an existing entity.
    /// </summary>
    public required int MergedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("mergedCount");
        }
        init { this._rawData.Set("mergedCount", value); }
    }

    /// <summary>
    /// Rows rejected.
    /// </summary>
    public required int RejectedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("rejectedCount");
        }
        init { this._rawData.Set("rejectedCount", value); }
    }

    /// <summary>
    /// Public ID (`esj_...`) of the seed job.
    /// </summary>
    public required string SeedJobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("seedJobID");
        }
        init { this._rawData.Set("seedJobID", value); }
    }

    /// <summary>
    /// Lifecycle state.
    /// </summary>
    public required ApiEnum<string, EntityRetrieveSeedStatusResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityRetrieveSeedStatusResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Total rows in the submitted batch.
    /// </summary>
    public required int TotalRows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("totalRows");
        }
        init { this._rawData.Set("totalRows", value); }
    }

    /// <summary>
    /// Terminal error message when `status` is `failed`.
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Per-row outcomes. Present only once `status` is `completed`.
    /// </summary>
    public IReadOnlyList<EntityRetrieveSeedStatusResponseResult>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<EntityRetrieveSeedStatusResponseResult>
            >("results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EntityRetrieveSeedStatusResponseResult>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedCount;
        _ = this.MergedCount;
        _ = this.RejectedCount;
        _ = this.SeedJobID;
        this.Status.Validate();
        _ = this.TotalRows;
        _ = this.Error;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
    }

    public EntityRetrieveSeedStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityRetrieveSeedStatusResponse(
        EntityRetrieveSeedStatusResponse entityRetrieveSeedStatusResponse
    )
        : base(entityRetrieveSeedStatusResponse) { }
#pragma warning restore CS8618

    public EntityRetrieveSeedStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityRetrieveSeedStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityRetrieveSeedStatusResponseFromRaw.FromRawUnchecked"/>
    public static EntityRetrieveSeedStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityRetrieveSeedStatusResponseFromRaw : IFromRawJson<EntityRetrieveSeedStatusResponse>
{
    /// <inheritdoc/>
    public EntityRetrieveSeedStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityRetrieveSeedStatusResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Lifecycle state.
/// </summary>
[JsonConverter(typeof(EntityRetrieveSeedStatusResponseStatusConverter))]
public enum EntityRetrieveSeedStatusResponseStatus
{
    Pending,
    Processing,
    Completed,
    Failed,
}

sealed class EntityRetrieveSeedStatusResponseStatusConverter
    : JsonConverter<EntityRetrieveSeedStatusResponseStatus>
{
    public override EntityRetrieveSeedStatusResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => EntityRetrieveSeedStatusResponseStatus.Pending,
            "processing" => EntityRetrieveSeedStatusResponseStatus.Processing,
            "completed" => EntityRetrieveSeedStatusResponseStatus.Completed,
            "failed" => EntityRetrieveSeedStatusResponseStatus.Failed,
            _ => (EntityRetrieveSeedStatusResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityRetrieveSeedStatusResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityRetrieveSeedStatusResponseStatus.Pending => "pending",
                EntityRetrieveSeedStatusResponseStatus.Processing => "processing",
                EntityRetrieveSeedStatusResponseStatus.Completed => "completed",
                EntityRetrieveSeedStatusResponseStatus.Failed => "failed",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The outcome of seeding one row.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityRetrieveSeedStatusResponseResult,
        EntityRetrieveSeedStatusResponseResultFromRaw
    >)
)]
public sealed record class EntityRetrieveSeedStatusResponseResult : JsonModel
{
    /// <summary>
    /// The canonical name from the input row.
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
    /// What happened to this row: `created` (new entity), `merged-with` (matched
    /// an existing entity), or `rejected` (see `reason`).
    /// </summary>
    public required ApiEnum<string, EntityRetrieveSeedStatusResponseResultOutcome> Outcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityRetrieveSeedStatusResponseResultOutcome>
            >("outcome");
        }
        init { this._rawData.Set("outcome", value); }
    }

    /// <summary>
    /// Public ID (`ent_...`) of the created or merged entity. Absent when rejected.
    /// </summary>
    public string? EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entityID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entityID", value);
        }
    }

    /// <summary>
    /// Human-readable explanation when `outcome` is `rejected`.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Canonical;
        this.Outcome.Validate();
        _ = this.EntityID;
        _ = this.Reason;
    }

    public EntityRetrieveSeedStatusResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityRetrieveSeedStatusResponseResult(
        EntityRetrieveSeedStatusResponseResult entityRetrieveSeedStatusResponseResult
    )
        : base(entityRetrieveSeedStatusResponseResult) { }
#pragma warning restore CS8618

    public EntityRetrieveSeedStatusResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityRetrieveSeedStatusResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityRetrieveSeedStatusResponseResultFromRaw.FromRawUnchecked"/>
    public static EntityRetrieveSeedStatusResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityRetrieveSeedStatusResponseResultFromRaw
    : IFromRawJson<EntityRetrieveSeedStatusResponseResult>
{
    /// <inheritdoc/>
    public EntityRetrieveSeedStatusResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityRetrieveSeedStatusResponseResult.FromRawUnchecked(rawData);
}

/// <summary>
/// What happened to this row: `created` (new entity), `merged-with` (matched an existing
/// entity), or `rejected` (see `reason`).
/// </summary>
[JsonConverter(typeof(EntityRetrieveSeedStatusResponseResultOutcomeConverter))]
public enum EntityRetrieveSeedStatusResponseResultOutcome
{
    Created,
    MergedWith,
    Rejected,
}

sealed class EntityRetrieveSeedStatusResponseResultOutcomeConverter
    : JsonConverter<EntityRetrieveSeedStatusResponseResultOutcome>
{
    public override EntityRetrieveSeedStatusResponseResultOutcome Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => EntityRetrieveSeedStatusResponseResultOutcome.Created,
            "merged-with" => EntityRetrieveSeedStatusResponseResultOutcome.MergedWith,
            "rejected" => EntityRetrieveSeedStatusResponseResultOutcome.Rejected,
            _ => (EntityRetrieveSeedStatusResponseResultOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityRetrieveSeedStatusResponseResultOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityRetrieveSeedStatusResponseResultOutcome.Created => "created",
                EntityRetrieveSeedStatusResponseResultOutcome.MergedWith => "merged-with",
                EntityRetrieveSeedStatusResponseResultOutcome.Rejected => "rejected",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
