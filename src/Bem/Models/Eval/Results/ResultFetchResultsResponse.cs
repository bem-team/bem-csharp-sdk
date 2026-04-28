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
    typeof(JsonModelConverter<ResultFetchResultsResponse, ResultFetchResultsResponseFromRaw>)
)]
public sealed record class ResultFetchResultsResponse : JsonModel
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
    public IReadOnlyList<Failed>? Failed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Failed>>("failed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Failed>?>(
                "failed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Transformations whose evaluation is still running.
    /// </summary>
    public IReadOnlyList<Pending>? Pending
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Pending>>("pending");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Pending>?>(
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

    public ResultFetchResultsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResultFetchResultsResponse(ResultFetchResultsResponse resultFetchResultsResponse)
        : base(resultFetchResultsResponse) { }
#pragma warning restore CS8618

    public ResultFetchResultsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultFetchResultsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFetchResultsResponseFromRaw.FromRawUnchecked"/>
    public static ResultFetchResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResultFetchResultsResponse(JsonElement results)
        : this()
    {
        this.Results = results;
    }
}

class ResultFetchResultsResponseFromRaw : IFromRawJson<ResultFetchResultsResponse>
{
    /// <inheritdoc/>
    public ResultFetchResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResultFetchResultsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A transformation whose evaluation failed or was not found.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Failed, FailedFromRaw>))]
public sealed record class Failed : JsonModel
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

    public Failed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Failed(Failed failed)
        : base(failed) { }
#pragma warning restore CS8618

    public Failed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Failed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FailedFromRaw.FromRawUnchecked"/>
    public static Failed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FailedFromRaw : IFromRawJson<Failed>
{
    /// <inheritdoc/>
    public Failed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Failed.FromRawUnchecked(rawData);
}

/// <summary>
/// A transformation whose evaluation is still running.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pending, PendingFromRaw>))]
public sealed record class Pending : JsonModel
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

    public Pending() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pending(Pending pending)
        : base(pending) { }
#pragma warning restore CS8618

    public Pending(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pending(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PendingFromRaw.FromRawUnchecked"/>
    public static Pending FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PendingFromRaw : IFromRawJson<Pending>
{
    /// <inheritdoc/>
    public Pending FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pending.FromRawUnchecked(rawData);
}
