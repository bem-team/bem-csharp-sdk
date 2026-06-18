using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Eval.Score;

/// <summary>
/// Returned by `POST /v3/eval/score`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ScoreCreateResponse, ScoreCreateResponseFromRaw>))]
public sealed record class ScoreCreateResponse : JsonModel
{
    /// <summary>
    /// Run identifier. Use with `GET /v3/eval/score/{scoreRunID}`.
    /// </summary>
    public required string ScoreRunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("scoreRunID");
        }
        init { this._rawData.Set("scoreRunID", value); }
    }

    /// <summary>
    /// Status values for an eval-score run.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ScoreRunID;
        this.Status.Validate();
    }

    public ScoreCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScoreCreateResponse(ScoreCreateResponse scoreCreateResponse)
        : base(scoreCreateResponse) { }
#pragma warning restore CS8618

    public ScoreCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScoreCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScoreCreateResponseFromRaw.FromRawUnchecked"/>
    public static ScoreCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScoreCreateResponseFromRaw : IFromRawJson<ScoreCreateResponse>
{
    /// <inheritdoc/>
    public ScoreCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ScoreCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Status values for an eval-score run.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Initializing,
    Running,
    Completed,
    Error,
    Cancelled,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "initializing" => Status.Initializing,
            "running" => Status.Running,
            "completed" => Status.Completed,
            "error" => Status.Error,
            "cancelled" => Status.Cancelled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Initializing => "initializing",
                Status.Running => "running",
                Status.Completed => "completed",
                Status.Error => "error",
                Status.Cancelled => "cancelled",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
