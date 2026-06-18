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
/// `200` response for a synchronously processed (small) batch.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityBulkCreateResponse, EntityBulkCreateResponseFromRaw>)
)]
public sealed record class EntityBulkCreateResponse : JsonModel
{
    /// <summary>
    /// Per-row outcomes, in request order.
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-outcome tally across a batch.
    /// </summary>
    public required Summary Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Summary>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
        this.Summary.Validate();
    }

    public EntityBulkCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBulkCreateResponse(EntityBulkCreateResponse entityBulkCreateResponse)
        : base(entityBulkCreateResponse) { }
#pragma warning restore CS8618

    public EntityBulkCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBulkCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityBulkCreateResponseFromRaw.FromRawUnchecked"/>
    public static EntityBulkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityBulkCreateResponseFromRaw : IFromRawJson<EntityBulkCreateResponse>
{
    /// <inheritdoc/>
    public EntityBulkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityBulkCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The outcome of seeding one row.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
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
    public required ApiEnum<string, Outcome> Outcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Outcome>>("outcome");
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

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// What happened to this row: `created` (new entity), `merged-with` (matched an existing
/// entity), or `rejected` (see `reason`).
/// </summary>
[JsonConverter(typeof(OutcomeConverter))]
public enum Outcome
{
    Created,
    MergedWith,
    Rejected,
}

sealed class OutcomeConverter : JsonConverter<Outcome>
{
    public override Outcome Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => Outcome.Created,
            "merged-with" => Outcome.MergedWith,
            "rejected" => Outcome.Rejected,
            _ => (Outcome)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Outcome value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Outcome.Created => "created",
                Outcome.MergedWith => "merged-with",
                Outcome.Rejected => "rejected",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Per-outcome tally across a batch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Summary, SummaryFromRaw>))]
public sealed record class Summary : JsonModel
{
    /// <summary>
    /// Number of rows that created a new entity.
    /// </summary>
    public required int Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// Number of rows merged into an existing entity.
    /// </summary>
    public required int Merged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("merged");
        }
        init { this._rawData.Set("merged", value); }
    }

    /// <summary>
    /// Number of rows rejected.
    /// </summary>
    public required int Rejected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("rejected");
        }
        init { this._rawData.Set("rejected", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Created;
        _ = this.Merged;
        _ = this.Rejected;
    }

    public Summary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Summary(Summary summary)
        : base(summary) { }
#pragma warning restore CS8618

    public Summary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Summary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SummaryFromRaw.FromRawUnchecked"/>
    public static Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SummaryFromRaw : IFromRawJson<Summary>
{
    /// <inheritdoc/>
    public Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Summary.FromRawUnchecked(rawData);
}
