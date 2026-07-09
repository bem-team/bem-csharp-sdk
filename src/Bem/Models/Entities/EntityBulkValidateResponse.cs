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
/// `200` response for `POST /v3/entities/bulk-validate`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityBulkValidateResponse, EntityBulkValidateResponseFromRaw>)
)]
public sealed record class EntityBulkValidateResponse : JsonModel
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
    /// Per-outcome tally across a bulk-validate batch.
    /// </summary>
    public required EntityBulkValidateResponseSummary Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityBulkValidateResponseSummary>("summary");
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

    public EntityBulkValidateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBulkValidateResponse(EntityBulkValidateResponse entityBulkValidateResponse)
        : base(entityBulkValidateResponse) { }
#pragma warning restore CS8618

    public EntityBulkValidateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBulkValidateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityBulkValidateResponseFromRaw.FromRawUnchecked"/>
    public static EntityBulkValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityBulkValidateResponseFromRaw : IFromRawJson<EntityBulkValidateResponse>
{
    /// <inheritdoc/>
    public EntityBulkValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityBulkValidateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The outcome of validating one row.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// The `ent_...` ID from the request.
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
    /// `validated` (transition applied), `skipped` (not found or not authorized),
    /// or `rejected-row` (the transition itself was illegal, e.g. already terminal).
    /// </summary>
    public required ApiEnum<string, ResultOutcome> Outcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ResultOutcome>>("outcome");
        }
        init { this._rawData.Set("outcome", value); }
    }

    /// <summary>
    /// Explanation for a `skipped` or `rejected-row` outcome.
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
        _ = this.EntityID;
        this.Outcome.Validate();
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
/// `validated` (transition applied), `skipped` (not found or not authorized), or
/// `rejected-row` (the transition itself was illegal, e.g. already terminal).
/// </summary>
[JsonConverter(typeof(ResultOutcomeConverter))]
public enum ResultOutcome
{
    Validated,
    Skipped,
    RejectedRow,
}

sealed class ResultOutcomeConverter : JsonConverter<ResultOutcome>
{
    public override ResultOutcome Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "validated" => ResultOutcome.Validated,
            "skipped" => ResultOutcome.Skipped,
            "rejected-row" => ResultOutcome.RejectedRow,
            _ => (ResultOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResultOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResultOutcome.Validated => "validated",
                ResultOutcome.Skipped => "skipped",
                ResultOutcome.RejectedRow => "rejected-row",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Per-outcome tally across a bulk-validate batch.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityBulkValidateResponseSummary,
        EntityBulkValidateResponseSummaryFromRaw
    >)
)]
public sealed record class EntityBulkValidateResponseSummary : JsonModel
{
    /// <summary>
    /// Rows whose transition was illegal.
    /// </summary>
    public required int RejectedRow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("rejectedRow");
        }
        init { this._rawData.Set("rejectedRow", value); }
    }

    /// <summary>
    /// Rows skipped (not found / not authorized).
    /// </summary>
    public required int Skipped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("skipped");
        }
        init { this._rawData.Set("skipped", value); }
    }

    /// <summary>
    /// Rows whose transition was applied.
    /// </summary>
    public required int Validated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("validated");
        }
        init { this._rawData.Set("validated", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RejectedRow;
        _ = this.Skipped;
        _ = this.Validated;
    }

    public EntityBulkValidateResponseSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBulkValidateResponseSummary(
        EntityBulkValidateResponseSummary entityBulkValidateResponseSummary
    )
        : base(entityBulkValidateResponseSummary) { }
#pragma warning restore CS8618

    public EntityBulkValidateResponseSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBulkValidateResponseSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityBulkValidateResponseSummaryFromRaw.FromRawUnchecked"/>
    public static EntityBulkValidateResponseSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityBulkValidateResponseSummaryFromRaw : IFromRawJson<EntityBulkValidateResponseSummary>
{
    /// <inheritdoc/>
    public EntityBulkValidateResponseSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityBulkValidateResponseSummary.FromRawUnchecked(rawData);
}
