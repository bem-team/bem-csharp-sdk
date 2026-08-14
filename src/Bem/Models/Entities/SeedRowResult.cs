using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Entities;

/// <summary>
/// The outcome of seeding one row.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SeedRowResult, SeedRowResultFromRaw>))]
public sealed record class SeedRowResult : JsonModel
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

    public SeedRowResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SeedRowResult(SeedRowResult seedRowResult)
        : base(seedRowResult) { }
#pragma warning restore CS8618

    public SeedRowResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SeedRowResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SeedRowResultFromRaw.FromRawUnchecked"/>
    public static SeedRowResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SeedRowResultFromRaw : IFromRawJson<SeedRowResult>
{
    /// <inheritdoc/>
    public SeedRowResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SeedRowResult.FromRawUnchecked(rawData);
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
