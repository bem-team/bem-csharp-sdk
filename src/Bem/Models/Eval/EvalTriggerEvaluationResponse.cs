using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Eval;

/// <summary>
/// Summary of the trigger call. Evaluations run asynchronously; use `POST /v3/eval/results`
/// or `GET /v3/eval/results` to poll for results.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EvalTriggerEvaluationResponse, EvalTriggerEvaluationResponseFromRaw>)
)]
public sealed record class EvalTriggerEvaluationResponse : JsonModel
{
    /// <summary>
    /// Number of evaluation jobs newly queued.
    /// </summary>
    public required long Queued
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("queued");
        }
        init { this._rawData.Set("queued", value); }
    }

    /// <summary>
    /// Number of transformations skipped because an evaluation job was already pending
    /// or already completed for them.
    /// </summary>
    public required long Skipped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skipped");
        }
        init { this._rawData.Set("skipped", value); }
    }

    /// <summary>
    /// Map of transformation ID to human-readable error message for any transformations
    /// that could not be queued (e.g. not found, unsupported event type).
    /// </summary>
    public JsonElement? Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("errors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errors", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Queued;
        _ = this.Skipped;
        _ = this.Errors;
    }

    public EvalTriggerEvaluationResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EvalTriggerEvaluationResponse(
        EvalTriggerEvaluationResponse evalTriggerEvaluationResponse
    )
        : base(evalTriggerEvaluationResponse) { }
#pragma warning restore CS8618

    public EvalTriggerEvaluationResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EvalTriggerEvaluationResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EvalTriggerEvaluationResponseFromRaw.FromRawUnchecked"/>
    public static EvalTriggerEvaluationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EvalTriggerEvaluationResponseFromRaw : IFromRawJson<EvalTriggerEvaluationResponse>
{
    /// <inheritdoc/>
    public EvalTriggerEvaluationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EvalTriggerEvaluationResponse.FromRawUnchecked(rawData);
}
