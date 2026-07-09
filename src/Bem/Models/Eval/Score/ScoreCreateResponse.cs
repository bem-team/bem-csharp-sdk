using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

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
    public required ApiEnum<string, EvalScoreRunStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EvalScoreRunStatus>>("status");
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
