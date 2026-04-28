using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;
using Bem.Models.Outputs;

namespace Bem.Models.Calls;

/// <summary>
/// A workflow call returned by the V3 API.
///
/// <para>Compared to the V2 `Call` model: - Terminal outputs are split into `outputs`
/// (non-error events) and `errors` (error events) - `callType` and function-scoped
/// fields are removed — V3 calls are always workflow calls - The deprecated `functionCalls`
/// field is removed (use `GET /v3/calls/{callID}/trace`) - `url` and `traceUrl` hint
/// fields are included for resource discovery</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Call, CallFromRaw>))]
public sealed record class Call : JsonModel
{
    /// <summary>
    /// Unique identifier of the call.
    /// </summary>
    public required string CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("callID");
        }
        init { this._rawData.Set("callID", value); }
    }

    /// <summary>
    /// The date and time the call was created.
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
    /// Terminal error events of this call. Workflow calls are not atomic — `errors`
    /// and `outputs` may both be non-empty if some enclosed function calls succeeded
    /// and others failed.
    ///
    /// <para>Retrieve individual errors via `GET /v3/errors/{eventID}`.</para>
    /// </summary>
    public required IReadOnlyList<ErrorEvent> Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ErrorEvent>>("errors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ErrorEvent>>(
                "errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Terminal non-error outputs of this call: primary events (non-split-collection)
    /// that did not trigger any downstream function calls. Workflow calls are not
    /// atomic — `outputs` and `errors` may both be non-empty if some enclosed function
    /// calls succeeded and others failed.
    ///
    /// <para>Each element is a polymorphic event object; inspect `eventType` to
    /// determine the type. Retrieve individual outputs via `GET /v3/outputs/{eventID}`.</para>
    /// </summary>
    public required IReadOnlyList<Event> Outputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Event>>("outputs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Event>>(
                "outputs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Hint URL for the full execution trace: `GET /v3/calls/{callID}/trace`.
    /// </summary>
    public required string TraceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("traceUrl");
        }
        init { this._rawData.Set("traceUrl", value); }
    }

    /// <summary>
    /// Hint URL for retrieving this call: `GET /v3/calls/{callID}`.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Your reference ID for this call, propagated from the original request.
    /// </summary>
    public string? CallReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callReferenceID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callReferenceID", value);
        }
    }

    /// <summary>
    /// The date and time the call finished. Only set once status is `completed` or `failed`.
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
    /// Input to the main function call.
    /// </summary>
    public global::Bem.Models.Calls.Input? Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Bem.Models.Calls.Input>("input");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("input", value);
        }
    }

    /// <summary>
    /// Status of call.
    /// </summary>
    public ApiEnum<string, CallStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallStatus>>("status");
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

    /// <summary>
    /// Unique identifier of the workflow.
    /// </summary>
    public string? WorkflowID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflowID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowID", value);
        }
    }

    /// <summary>
    /// Name of the workflow.
    /// </summary>
    public string? WorkflowName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflowName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowName", value);
        }
    }

    /// <summary>
    /// Version number of the workflow.
    /// </summary>
    public long? WorkflowVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("workflowVersionNum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowVersionNum", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallID;
        _ = this.CreatedAt;
        foreach (var item in this.Errors)
        {
            item.Validate();
        }
        foreach (var item in this.Outputs)
        {
            item.Validate();
        }
        _ = this.TraceUrl;
        _ = this.Url;
        _ = this.CallReferenceID;
        _ = this.FinishedAt;
        this.Input?.Validate();
        this.Status?.Validate();
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public Call() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Call(Call call)
        : base(call) { }
#pragma warning restore CS8618

    public Call(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Call(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallFromRaw.FromRawUnchecked"/>
    public static Call FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallFromRaw : IFromRawJson<Call>
{
    /// <inheritdoc/>
    public Call FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Call.FromRawUnchecked(rawData);
}

/// <summary>
/// Input to the main function call.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Bem.Models.Calls.Input,
        global::Bem.Models.Calls.InputFromRaw
    >)
)]
public sealed record class Input : JsonModel
{
    public BatchFiles? BatchFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchFiles>("batchFiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("batchFiles", value);
        }
    }

    public SingleFile? SingleFile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SingleFile>("singleFile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("singleFile", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BatchFiles?.Validate();
        this.SingleFile?.Validate();
    }

    public Input() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Input(global::Bem.Models.Calls.Input input)
        : base(input) { }
#pragma warning restore CS8618

    public Input(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Input(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Bem.Models.Calls.InputFromRaw.FromRawUnchecked"/>
    public static global::Bem.Models.Calls.Input FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputFromRaw : IFromRawJson<global::Bem.Models.Calls.Input>
{
    /// <inheritdoc/>
    public global::Bem.Models.Calls.Input FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Bem.Models.Calls.Input.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BatchFiles, BatchFilesFromRaw>))]
public sealed record class BatchFiles : JsonModel
{
    public IReadOnlyList<BatchFilesInput>? Inputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BatchFilesInput>>("inputs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BatchFilesInput>?>(
                "inputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Inputs ?? [])
        {
            item.Validate();
        }
    }

    public BatchFiles() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchFiles(BatchFiles batchFiles)
        : base(batchFiles) { }
#pragma warning restore CS8618

    public BatchFiles(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchFiles(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchFilesFromRaw.FromRawUnchecked"/>
    public static BatchFiles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchFilesFromRaw : IFromRawJson<BatchFiles>
{
    /// <inheritdoc/>
    public BatchFiles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchFiles.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BatchFilesInput, BatchFilesInputFromRaw>))]
public sealed record class BatchFilesInput : JsonModel
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
    /// Item reference ID
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
    /// Presigned S3 URL for the file
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

    public BatchFilesInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchFilesInput(BatchFilesInput batchFilesInput)
        : base(batchFilesInput) { }
#pragma warning restore CS8618

    public BatchFilesInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchFilesInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchFilesInputFromRaw.FromRawUnchecked"/>
    public static BatchFilesInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchFilesInputFromRaw : IFromRawJson<BatchFilesInput>
{
    /// <inheritdoc/>
    public BatchFilesInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchFilesInput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SingleFile, SingleFileFromRaw>))]
public sealed record class SingleFile : JsonModel
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
    /// Presigned S3 URL for the file
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
        _ = this.S3Url;
    }

    public SingleFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SingleFile(SingleFile singleFile)
        : base(singleFile) { }
#pragma warning restore CS8618

    public SingleFile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SingleFile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SingleFileFromRaw.FromRawUnchecked"/>
    public static SingleFile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SingleFileFromRaw : IFromRawJson<SingleFile>
{
    /// <inheritdoc/>
    public SingleFile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SingleFile.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of call.
/// </summary>
[JsonConverter(typeof(CallStatusConverter))]
public enum CallStatus
{
    Pending,
    Running,
    Completed,
    Failed,
}

sealed class CallStatusConverter : JsonConverter<CallStatus>
{
    public override CallStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => CallStatus.Pending,
            "running" => CallStatus.Running,
            "completed" => CallStatus.Completed,
            "failed" => CallStatus.Failed,
            _ => (CallStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CallStatus.Pending => "pending",
                CallStatus.Running => "running",
                CallStatus.Completed => "completed",
                CallStatus.Failed => "failed",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
