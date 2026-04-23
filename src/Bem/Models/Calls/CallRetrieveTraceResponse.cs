using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Models.Calls;

/// <summary>
/// Response from `GET /v3/calls/{callID}/trace`.
///
/// <para>Contains the full execution DAG as flat arrays of function calls and events.
/// Reconstruct the graph using `FunctionCallResponseBase.sourceEventID` (the event
/// that spawned each function call) and each event's `functionCallID` (the function
/// call that emitted it).</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CallRetrieveTraceResponse, CallRetrieveTraceResponseFromRaw>)
)]
public sealed record class CallRetrieveTraceResponse : JsonModel
{
    /// <summary>
    /// Error message if trace retrieval failed.
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
    /// Full execution DAG of a call as flat arrays. Reconstruct the graph using FunctionCallResponseBase.sourceEventID
    /// and each event's functionCallID.
    /// </summary>
    public Trace? Trace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Trace>("trace");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trace", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        this.Trace?.Validate();
    }

    public CallRetrieveTraceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveTraceResponse(CallRetrieveTraceResponse callRetrieveTraceResponse)
        : base(callRetrieveTraceResponse) { }
#pragma warning restore CS8618

    public CallRetrieveTraceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveTraceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallRetrieveTraceResponseFromRaw.FromRawUnchecked"/>
    public static CallRetrieveTraceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallRetrieveTraceResponseFromRaw : IFromRawJson<CallRetrieveTraceResponse>
{
    /// <inheritdoc/>
    public CallRetrieveTraceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CallRetrieveTraceResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Full execution DAG of a call as flat arrays. Reconstruct the graph using FunctionCallResponseBase.sourceEventID
/// and each event's functionCallID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Trace, TraceFromRaw>))]
public sealed record class Trace : JsonModel
{
    /// <summary>
    /// All events emitted within this call, polymorphic by eventType.
    /// </summary>
    public required IReadOnlyList<JsonElement> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// All function calls executed within this call.
    /// </summary>
    public required IReadOnlyList<FunctionCall> FunctionCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FunctionCall>>("functionCalls");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FunctionCall>>(
                "functionCalls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Events;
        foreach (var item in this.FunctionCalls)
        {
            item.Validate();
        }
    }

    public Trace() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Trace(Trace trace)
        : base(trace) { }
#pragma warning restore CS8618

    public Trace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TraceFromRaw.FromRawUnchecked"/>
    public static Trace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TraceFromRaw : IFromRawJson<Trace>
{
    /// <inheritdoc/>
    public Trace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trace.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FunctionCall, FunctionCallFromRaw>))]
public sealed record class FunctionCall : JsonModel
{
    /// <summary>
    /// Unique identifier for this function call
    /// </summary>
    public required string FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionCallID");
        }
        init { this._rawData.Set("functionCallID", value); }
    }

    /// <summary>
    /// ID of the function that was called
    /// </summary>
    public required string FunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionID");
        }
        init { this._rawData.Set("functionID", value); }
    }

    /// <summary>
    /// Name of the function that was called
    /// </summary>
    public required string FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionName");
        }
        init { this._rawData.Set("functionName", value); }
    }

    /// <summary>
    /// User-provided reference ID for tracking
    /// </summary>
    public required string ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("referenceID");
        }
        init { this._rawData.Set("referenceID", value); }
    }

    /// <summary>
    /// The date and time this function call started.
    /// </summary>
    public required DateTimeOffset StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("startedAt");
        }
        init { this._rawData.Set("startedAt", value); }
    }

    /// <summary>
    /// The status of the action.
    /// </summary>
    public required ApiEnum<string, FunctionCallStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FunctionCallStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The type of the function.
    /// </summary>
    public required ApiEnum<string, FunctionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FunctionType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Array of activity steps for this function call
    /// </summary>
    public IReadOnlyList<Activity>? Activity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Activity>>("activity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Activity>?>(
                "activity",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The date and time this function call finished. Absent while still running.
    /// </summary>
    public DateTimeOffset? FinishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("finishedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("finishedAt", value);
        }
    }

    /// <summary>
    /// Version number of the function
    /// </summary>
    public long? FunctionVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionVersionNum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionVersionNum", value);
        }
    }

    /// <summary>
    /// The labelled outlet on the upstream node that routed execution to this call.
    /// Absent for root calls, unlabelled edges, and pre-migration rows.
    /// </summary>
    public string? IncomingDestinationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("incomingDestinationName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("incomingDestinationName", value);
        }
    }

    /// <summary>
    /// Array of all file inputs with their S3 URLs
    /// </summary>
    public IReadOnlyList<FunctionCallInput>? Inputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FunctionCallInput>>("inputs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FunctionCallInput>?>(
                "inputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Input type for single file input (set when there's exactly one file input)
    /// </summary>
    public string? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inputType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inputType", value);
        }
    }

    /// <summary>
    /// Presigned S3 URL for single file input (set when there's exactly one file input)
    /// </summary>
    public string? S3Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3URL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3URL", value);
        }
    }

    /// <summary>
    /// ID of the event that spawned this function call (for DAG reconstruction).
    /// Nil for the root function call.
    /// </summary>
    public string? SourceEventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceEventID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceEventID", value);
        }
    }

    /// <summary>
    /// ID of the function call that spawned this function call (for DAG reconstruction)
    /// </summary>
    public string? SourceFunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceFunctionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceFunctionCallID", value);
        }
    }

    /// <summary>
    /// ID of the workflow call this function call belongs to (top-level execution context)
    /// </summary>
    public string? WorkflowCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflowCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowCallID", value);
        }
    }

    /// <summary>
    /// Name of the workflow DAG call-site node this function call is executing.
    /// Absent for non-workflow calls and pre-migration rows.
    /// </summary>
    public string? WorkflowNodeName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflowNodeName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowNodeName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionCallID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.ReferenceID;
        _ = this.StartedAt;
        this.Status.Validate();
        this.Type.Validate();
        foreach (var item in this.Activity ?? [])
        {
            item.Validate();
        }
        _ = this.FinishedAt;
        _ = this.FunctionVersionNum;
        _ = this.IncomingDestinationName;
        foreach (var item in this.Inputs ?? [])
        {
            item.Validate();
        }
        _ = this.InputType;
        _ = this.S3Url;
        _ = this.SourceEventID;
        _ = this.SourceFunctionCallID;
        _ = this.WorkflowCallID;
        _ = this.WorkflowNodeName;
    }

    public FunctionCall() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionCall(FunctionCall functionCall)
        : base(functionCall) { }
#pragma warning restore CS8618

    public FunctionCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionCallFromRaw.FromRawUnchecked"/>
    public static FunctionCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionCallFromRaw : IFromRawJson<FunctionCall>
{
    /// <inheritdoc/>
    public FunctionCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionCall.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the action.
/// </summary>
[JsonConverter(typeof(FunctionCallStatusConverter))]
public enum FunctionCallStatus
{
    Pending,
    Running,
    Completed,
    Failed,
}

sealed class FunctionCallStatusConverter : JsonConverter<FunctionCallStatus>
{
    public override FunctionCallStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => FunctionCallStatus.Pending,
            "running" => FunctionCallStatus.Running,
            "completed" => FunctionCallStatus.Completed,
            "failed" => FunctionCallStatus.Failed,
            _ => (FunctionCallStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionCallStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionCallStatus.Pending => "pending",
                FunctionCallStatus.Running => "running",
                FunctionCallStatus.Completed => "completed",
                FunctionCallStatus.Failed => "failed",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Activity, ActivityFromRaw>))]
public sealed record class Activity : JsonModel
{
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayName", value);
        }
    }

    public ApiEnum<string, ActivityStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ActivityStatus>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayName;
        this.Status?.Validate();
    }

    public Activity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Activity(Activity activity)
        : base(activity) { }
#pragma warning restore CS8618

    public Activity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Activity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityFromRaw.FromRawUnchecked"/>
    public static Activity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityFromRaw : IFromRawJson<Activity>
{
    /// <inheritdoc/>
    public Activity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Activity.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActivityStatusConverter))]
public enum ActivityStatus
{
    Pending,
    Running,
    Completed,
    Failed,
}

sealed class ActivityStatusConverter : JsonConverter<ActivityStatus>
{
    public override ActivityStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => ActivityStatus.Pending,
            "running" => ActivityStatus.Running,
            "completed" => ActivityStatus.Completed,
            "failed" => ActivityStatus.Failed,
            _ => (ActivityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivityStatus.Pending => "pending",
                ActivityStatus.Running => "running",
                ActivityStatus.Completed => "completed",
                ActivityStatus.Failed => "failed",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<FunctionCallInput, FunctionCallInputFromRaw>))]
public sealed record class FunctionCallInput : JsonModel
{
    /// <summary>
    /// Input type of the file
    /// </summary>
    public string? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inputType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inputType", value);
        }
    }

    /// <summary>
    /// Item reference ID for batch inputs
    /// </summary>
    public string? ItemReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("itemReferenceID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemReferenceID", value);
        }
    }

    /// <summary>
    /// Presigned S3 URL for the file input
    /// </summary>
    public string? S3Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3URL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3URL", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputType;
        _ = this.ItemReferenceID;
        _ = this.S3Url;
    }

    public FunctionCallInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionCallInput(FunctionCallInput functionCallInput)
        : base(functionCallInput) { }
#pragma warning restore CS8618

    public FunctionCallInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionCallInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionCallInputFromRaw.FromRawUnchecked"/>
    public static FunctionCallInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionCallInputFromRaw : IFromRawJson<FunctionCallInput>
{
    /// <inheritdoc/>
    public FunctionCallInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionCallInput.FromRawUnchecked(rawData);
}
