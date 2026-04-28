using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Eval.Results;

/// <summary>
/// Batched response containing the evaluation state for every requested transformation
/// ID, partitioned into completed `results`, still-running `pending`, and terminal
/// `failed` groups.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ResultRetrieveResultsResponse, ResultRetrieveResultsResponseFromRaw>)
)]
public sealed record class ResultRetrieveResultsResponse : JsonModel
{
    /// <summary>
    /// Completed evaluation results, keyed by transformation ID.
    ///
    /// <para>A transformation appears here only if its evaluation completed successfully.
    /// Still-running evaluations appear in `pending`; failed evaluations appear
    /// in `failed`.</para>
    /// </summary>
    public required JsonElement Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("results");
        }
        init { this._rawData.Set("results", value); }
    }

    /// <summary>
    /// Reserved map of transformation ID to error message for validation failures
    /// on the request itself. Populated only in edge cases.
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

    /// <summary>
    /// Transformations whose evaluation failed or was not found.
    /// </summary>
    public IReadOnlyList<ResultRetrieveResultsResponseFailed>? Failed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ResultRetrieveResultsResponseFailed>
            >("failed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ResultRetrieveResultsResponseFailed>?>(
                "failed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Transformations whose evaluation is still running.
    /// </summary>
    public IReadOnlyList<ResultRetrieveResultsResponsePending>? Pending
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ResultRetrieveResultsResponsePending>
            >("pending");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ResultRetrieveResultsResponsePending>?>(
                "pending",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Results;
        _ = this.Errors;
        foreach (var item in this.Failed ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Pending ?? [])
        {
            item.Validate();
        }
    }

    public ResultRetrieveResultsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResultRetrieveResultsResponse(
        ResultRetrieveResultsResponse resultRetrieveResultsResponse
    )
        : base(resultRetrieveResultsResponse) { }
#pragma warning restore CS8618

    public ResultRetrieveResultsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultRetrieveResultsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultRetrieveResultsResponseFromRaw.FromRawUnchecked"/>
    public static ResultRetrieveResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResultRetrieveResultsResponse(JsonElement results)
        : this()
    {
        this.Results = results;
    }
}

class ResultRetrieveResultsResponseFromRaw : IFromRawJson<ResultRetrieveResultsResponse>
{
    /// <inheritdoc/>
    public ResultRetrieveResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResultRetrieveResultsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A transformation whose evaluation failed or was not found.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ResultRetrieveResultsResponseFailed,
        ResultRetrieveResultsResponseFailedFromRaw
    >)
)]
public sealed record class ResultRetrieveResultsResponseFailed : JsonModel
{
    /// <summary>
    /// Server timestamp associated with the failure.
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
    /// Human-readable failure reason.
    /// </summary>
    public required string ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("errorMessage");
        }
        init { this._rawData.Set("errorMessage", value); }
    }

    public required string TransformationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transformationId");
        }
        init { this._rawData.Set("transformationId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        _ = this.TransformationID;
    }

    public ResultRetrieveResultsResponseFailed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResultRetrieveResultsResponseFailed(
        ResultRetrieveResultsResponseFailed resultRetrieveResultsResponseFailed
    )
        : base(resultRetrieveResultsResponseFailed) { }
#pragma warning restore CS8618

    public ResultRetrieveResultsResponseFailed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultRetrieveResultsResponseFailed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultRetrieveResultsResponseFailedFromRaw.FromRawUnchecked"/>
    public static ResultRetrieveResultsResponseFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultRetrieveResultsResponseFailedFromRaw : IFromRawJson<ResultRetrieveResultsResponseFailed>
{
    /// <inheritdoc/>
    public ResultRetrieveResultsResponseFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResultRetrieveResultsResponseFailed.FromRawUnchecked(rawData);
}

/// <summary>
/// A transformation whose evaluation is still running.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ResultRetrieveResultsResponsePending,
        ResultRetrieveResultsResponsePendingFromRaw
    >)
)]
public sealed record class ResultRetrieveResultsResponsePending : JsonModel
{
    /// <summary>
    /// Server timestamp when the evaluation was queued.
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

    public required string TransformationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transformationId");
        }
        init { this._rawData.Set("transformationId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.TransformationID;
    }

    public ResultRetrieveResultsResponsePending() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResultRetrieveResultsResponsePending(
        ResultRetrieveResultsResponsePending resultRetrieveResultsResponsePending
    )
        : base(resultRetrieveResultsResponsePending) { }
#pragma warning restore CS8618

    public ResultRetrieveResultsResponsePending(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultRetrieveResultsResponsePending(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultRetrieveResultsResponsePendingFromRaw.FromRawUnchecked"/>
    public static ResultRetrieveResultsResponsePending FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultRetrieveResultsResponsePendingFromRaw
    : IFromRawJson<ResultRetrieveResultsResponsePending>
{
    /// <inheritdoc/>
    public ResultRetrieveResultsResponsePending FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResultRetrieveResultsResponsePending.FromRawUnchecked(rawData);
}
