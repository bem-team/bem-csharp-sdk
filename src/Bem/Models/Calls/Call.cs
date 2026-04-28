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
using Outputs = Bem.Models.Outputs;

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
    public required IReadOnlyList<Output> Outputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Output>>("outputs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Output>>(
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
    public CallInput? Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallInput>("input");
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
/// V3 read-side event union. Superset of the shared `Event` union: it contains every
/// shared variant verbatim (backward compatible) and adds the V3-only `extract` and
/// `classify` variants.
/// </summary>
[JsonConverter(typeof(OutputConverter))]
public record class Output : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string EventID
    {
        get
        {
            return Match(
                transform: (x) => x.EventID,
                extract: (x) => x.EventID,
                route: (x) => x.EventID,
                classify: (x) => x.EventID,
                splitCollection: (x) => x.EventID,
                splitItem: (x) => x.EventID,
                errorEvent: (x) => x.EventID,
                join: (x) => x.EventID,
                enrich: (x) => x.EventID,
                collectionProcessing: (x) => x.EventID,
                send: (x) => x.EventID
            );
        }
    }

    public string? FunctionID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.FunctionID,
                extract: (x) => x.FunctionID,
                route: (x) => x.FunctionID,
                classify: (x) => x.FunctionID,
                splitCollection: (x) => x.FunctionID,
                splitItem: (x) => x.FunctionID,
                errorEvent: (x) => x.FunctionID,
                join: (x) => x.FunctionID,
                enrich: (x) => x.FunctionID,
                collectionProcessing: (_) => null,
                send: (x) => x.FunctionID
            );
        }
    }

    public string? FunctionName
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.FunctionName,
                extract: (x) => x.FunctionName,
                route: (x) => x.FunctionName,
                classify: (x) => x.FunctionName,
                splitCollection: (x) => x.FunctionName,
                splitItem: (x) => x.FunctionName,
                errorEvent: (x) => x.FunctionName,
                join: (x) => x.FunctionName,
                enrich: (x) => x.FunctionName,
                collectionProcessing: (_) => null,
                send: (x) => x.FunctionName
            );
        }
    }

    public long? ItemCount
    {
        get
        {
            return Match<long?>(
                transform: (x) => x.ItemCount,
                extract: (x) => x.ItemCount,
                route: (_) => null,
                classify: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                errorEvent: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                collectionProcessing: (_) => null,
                send: (_) => null
            );
        }
    }

    public long? ItemOffset
    {
        get
        {
            return Match<long?>(
                transform: (x) => x.ItemOffset,
                extract: (x) => x.ItemOffset,
                route: (_) => null,
                classify: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                errorEvent: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                collectionProcessing: (_) => null,
                send: (_) => null
            );
        }
    }

    public string ReferenceID
    {
        get
        {
            return Match(
                transform: (x) => x.ReferenceID,
                extract: (x) => x.ReferenceID,
                route: (x) => x.ReferenceID,
                classify: (x) => x.ReferenceID,
                splitCollection: (x) => x.ReferenceID,
                splitItem: (x) => x.ReferenceID,
                errorEvent: (x) => x.ReferenceID,
                join: (x) => x.ReferenceID,
                enrich: (x) => x.ReferenceID,
                collectionProcessing: (x) => x.ReferenceID,
                send: (x) => x.ReferenceID
            );
        }
    }

    public JsonElement? TransformedContent
    {
        get
        {
            return Match<JsonElement?>(
                transform: (x) => x.TransformedContent,
                extract: (x) => x.TransformedContent,
                route: (_) => null,
                classify: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                errorEvent: (_) => null,
                join: (x) => x.TransformedContent,
                enrich: (_) => null,
                collectionProcessing: (_) => null,
                send: (_) => null
            );
        }
    }

    public float? AvgConfidence
    {
        get
        {
            return Match<float?>(
                transform: (x) => x.AvgConfidence,
                extract: (x) => x.AvgConfidence,
                route: (_) => null,
                classify: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                errorEvent: (_) => null,
                join: (x) => x.AvgConfidence,
                enrich: (_) => null,
                collectionProcessing: (_) => null,
                send: (_) => null
            );
        }
    }

    public string? CallID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.CallID,
                extract: (x) => x.CallID,
                route: (x) => x.CallID,
                classify: (x) => x.CallID,
                splitCollection: (x) => x.CallID,
                splitItem: (x) => x.CallID,
                errorEvent: (x) => x.CallID,
                join: (x) => x.CallID,
                enrich: (x) => x.CallID,
                collectionProcessing: (_) => null,
                send: (x) => x.CallID
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            return Match<DateTimeOffset?>(
                transform: (x) => x.CreatedAt,
                extract: (x) => x.CreatedAt,
                route: (x) => x.CreatedAt,
                classify: (x) => x.CreatedAt,
                splitCollection: (x) => x.CreatedAt,
                splitItem: (x) => x.CreatedAt,
                errorEvent: (x) => x.CreatedAt,
                join: (x) => x.CreatedAt,
                enrich: (x) => x.CreatedAt,
                collectionProcessing: (x) => x.CreatedAt,
                send: (x) => x.CreatedAt
            );
        }
    }

    public JsonElement? FieldConfidences
    {
        get
        {
            return Match<JsonElement?>(
                transform: (x) => x.FieldConfidences,
                extract: (x) => x.FieldConfidences,
                route: (_) => null,
                classify: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                errorEvent: (_) => null,
                join: (x) => x.FieldConfidences,
                enrich: (_) => null,
                collectionProcessing: (_) => null,
                send: (_) => null
            );
        }
    }

    public string? FunctionCallID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.FunctionCallID,
                extract: (x) => x.FunctionCallID,
                route: (x) => x.FunctionCallID,
                classify: (x) => x.FunctionCallID,
                splitCollection: (x) => x.FunctionCallID,
                splitItem: (x) => x.FunctionCallID,
                errorEvent: (x) => x.FunctionCallID,
                join: (x) => x.FunctionCallID,
                enrich: (x) => x.FunctionCallID,
                collectionProcessing: (_) => null,
                send: (x) => x.FunctionCallID
            );
        }
    }

    public long? FunctionCallTryNumber
    {
        get
        {
            return Match<long?>(
                transform: (x) => x.FunctionCallTryNumber,
                extract: (x) => x.FunctionCallTryNumber,
                route: (x) => x.FunctionCallTryNumber,
                classify: (x) => x.FunctionCallTryNumber,
                splitCollection: (x) => x.FunctionCallTryNumber,
                splitItem: (x) => x.FunctionCallTryNumber,
                errorEvent: (x) => x.FunctionCallTryNumber,
                join: (x) => x.FunctionCallTryNumber,
                enrich: (x) => x.FunctionCallTryNumber,
                collectionProcessing: (x) => x.FunctionCallTryNumber,
                send: (x) => x.FunctionCallTryNumber
            );
        }
    }

    public long? FunctionVersionNum
    {
        get
        {
            return Match<long?>(
                transform: (x) => x.FunctionVersionNum,
                extract: (x) => x.FunctionVersionNum,
                route: (x) => x.FunctionVersionNum,
                classify: (x) => x.FunctionVersionNum,
                splitCollection: (x) => x.FunctionVersionNum,
                splitItem: (x) => x.FunctionVersionNum,
                errorEvent: (x) => x.FunctionVersionNum,
                join: (x) => x.FunctionVersionNum,
                enrich: (x) => x.FunctionVersionNum,
                collectionProcessing: (_) => null,
                send: (x) => x.FunctionVersionNum
            );
        }
    }

    public InboundEmailEvent? InboundEmail
    {
        get
        {
            return Match<InboundEmailEvent?>(
                transform: (x) => x.InboundEmail,
                extract: (x) => x.InboundEmail,
                route: (x) => x.InboundEmail,
                classify: (x) => x.InboundEmail,
                splitCollection: (x) => x.InboundEmail,
                splitItem: (x) => x.InboundEmail,
                errorEvent: (x) => x.InboundEmail,
                join: (x) => x.InboundEmail,
                enrich: (x) => x.InboundEmail,
                collectionProcessing: (x) => x.InboundEmail,
                send: (x) => x.InboundEmail
            );
        }
    }

    public string? S3Url
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.S3Url,
                extract: (x) => x.S3Url,
                route: (x) => x.S3Url,
                classify: (x) => x.S3Url,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                errorEvent: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                collectionProcessing: (_) => null,
                send: (_) => null
            );
        }
    }

    public string? TransformationID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.TransformationID,
                extract: (x) => x.TransformationID,
                route: (_) => null,
                classify: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                errorEvent: (_) => null,
                join: (x) => x.TransformationID,
                enrich: (_) => null,
                collectionProcessing: (_) => null,
                send: (_) => null
            );
        }
    }

    public string? WorkflowID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.WorkflowID,
                extract: (x) => x.WorkflowID,
                route: (x) => x.WorkflowID,
                classify: (x) => x.WorkflowID,
                splitCollection: (x) => x.WorkflowID,
                splitItem: (x) => x.WorkflowID,
                errorEvent: (x) => x.WorkflowID,
                join: (x) => x.WorkflowID,
                enrich: (x) => x.WorkflowID,
                collectionProcessing: (_) => null,
                send: (x) => x.WorkflowID
            );
        }
    }

    public string? WorkflowName
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.WorkflowName,
                extract: (x) => x.WorkflowName,
                route: (x) => x.WorkflowName,
                classify: (x) => x.WorkflowName,
                splitCollection: (x) => x.WorkflowName,
                splitItem: (x) => x.WorkflowName,
                errorEvent: (x) => x.WorkflowName,
                join: (x) => x.WorkflowName,
                enrich: (x) => x.WorkflowName,
                collectionProcessing: (_) => null,
                send: (x) => x.WorkflowName
            );
        }
    }

    public long? WorkflowVersionNum
    {
        get
        {
            return Match<long?>(
                transform: (x) => x.WorkflowVersionNum,
                extract: (x) => x.WorkflowVersionNum,
                route: (x) => x.WorkflowVersionNum,
                classify: (x) => x.WorkflowVersionNum,
                splitCollection: (x) => x.WorkflowVersionNum,
                splitItem: (x) => x.WorkflowVersionNum,
                errorEvent: (x) => x.WorkflowVersionNum,
                join: (x) => x.WorkflowVersionNum,
                enrich: (x) => x.WorkflowVersionNum,
                collectionProcessing: (_) => null,
                send: (x) => x.WorkflowVersionNum
            );
        }
    }

    public string? Choice
    {
        get
        {
            return Match<string?>(
                transform: (_) => null,
                extract: (_) => null,
                route: (x) => x.Choice,
                classify: (x) => x.Choice,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                errorEvent: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                collectionProcessing: (_) => null,
                send: (_) => null
            );
        }
    }

    public Output(Transform value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(Extract value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(Route value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(Classify value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(SplitCollection value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(SplitItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(ErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(Join value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(Enrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(CollectionProcessing value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(Send value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Output(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Transform"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTransform(out var value)) {
    ///     // `value` is of type `Transform`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTransform([NotNullWhen(true)] out Transform? value)
    {
        value = this.Value as Transform;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Extract"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtract(out var value)) {
    ///     // `value` is of type `Extract`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtract([NotNullWhen(true)] out Extract? value)
    {
        value = this.Value as Extract;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Route"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRoute(out var value)) {
    ///     // `value` is of type `Route`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRoute([NotNullWhen(true)] out Route? value)
    {
        value = this.Value as Route;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Classify"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClassify(out var value)) {
    ///     // `value` is of type `Classify`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClassify([NotNullWhen(true)] out Classify? value)
    {
        value = this.Value as Classify;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SplitCollection"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplitCollection(out var value)) {
    ///     // `value` is of type `SplitCollection`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplitCollection([NotNullWhen(true)] out SplitCollection? value)
    {
        value = this.Value as SplitCollection;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SplitItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplitItem(out var value)) {
    ///     // `value` is of type `SplitItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplitItem([NotNullWhen(true)] out SplitItem? value)
    {
        value = this.Value as SplitItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ErrorEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickErrorEvent(out var value)) {
    ///     // `value` is of type `ErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickErrorEvent([NotNullWhen(true)] out ErrorEvent? value)
    {
        value = this.Value as ErrorEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Join"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJoin(out var value)) {
    ///     // `value` is of type `Join`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJoin([NotNullWhen(true)] out Join? value)
    {
        value = this.Value as Join;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Enrich"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrich(out var value)) {
    ///     // `value` is of type `Enrich`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrich([NotNullWhen(true)] out Enrich? value)
    {
        value = this.Value as Enrich;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CollectionProcessing"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCollectionProcessing(out var value)) {
    ///     // `value` is of type `CollectionProcessing`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCollectionProcessing([NotNullWhen(true)] out CollectionProcessing? value)
    {
        value = this.Value as CollectionProcessing;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Send"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `Send`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out Send? value)
    {
        value = this.Value as Send;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Transform value) =&gt; {...},
    ///     (Extract value) =&gt; {...},
    ///     (Route value) =&gt; {...},
    ///     (Classify value) =&gt; {...},
    ///     (SplitCollection value) =&gt; {...},
    ///     (SplitItem value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...},
    ///     (Join value) =&gt; {...},
    ///     (Enrich value) =&gt; {...},
    ///     (CollectionProcessing value) =&gt; {...},
    ///     (Send value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Transform> transform,
        Action<Extract> extract,
        Action<Route> route,
        Action<Classify> classify,
        Action<SplitCollection> splitCollection,
        Action<SplitItem> splitItem,
        Action<ErrorEvent> errorEvent,
        Action<Join> join,
        Action<Enrich> enrich,
        Action<CollectionProcessing> collectionProcessing,
        Action<Send> send
    )
    {
        switch (this.Value)
        {
            case Transform value:
                transform(value);
                break;
            case Extract value:
                extract(value);
                break;
            case Route value:
                route(value);
                break;
            case Classify value:
                classify(value);
                break;
            case SplitCollection value:
                splitCollection(value);
                break;
            case SplitItem value:
                splitItem(value);
                break;
            case ErrorEvent value:
                errorEvent(value);
                break;
            case Join value:
                join(value);
                break;
            case Enrich value:
                enrich(value);
                break;
            case CollectionProcessing value:
                collectionProcessing(value);
                break;
            case Send value:
                send(value);
                break;
            default:
                throw new BemInvalidDataException("Data did not match any variant of Output");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Transform value) =&gt; {...},
    ///     (Extract value) =&gt; {...},
    ///     (Route value) =&gt; {...},
    ///     (Classify value) =&gt; {...},
    ///     (SplitCollection value) =&gt; {...},
    ///     (SplitItem value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...},
    ///     (Join value) =&gt; {...},
    ///     (Enrich value) =&gt; {...},
    ///     (CollectionProcessing value) =&gt; {...},
    ///     (Send value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Transform, T> transform,
        Func<Extract, T> extract,
        Func<Route, T> route,
        Func<Classify, T> classify,
        Func<SplitCollection, T> splitCollection,
        Func<SplitItem, T> splitItem,
        Func<ErrorEvent, T> errorEvent,
        Func<Join, T> join,
        Func<Enrich, T> enrich,
        Func<CollectionProcessing, T> collectionProcessing,
        Func<Send, T> send
    )
    {
        return this.Value switch
        {
            Transform value => transform(value),
            Extract value => extract(value),
            Route value => route(value),
            Classify value => classify(value),
            SplitCollection value => splitCollection(value),
            SplitItem value => splitItem(value),
            ErrorEvent value => errorEvent(value),
            Join value => join(value),
            Enrich value => enrich(value),
            CollectionProcessing value => collectionProcessing(value),
            Send value => send(value),
            _ => throw new BemInvalidDataException("Data did not match any variant of Output"),
        };
    }

    public static implicit operator Output(Transform value) => new(value);

    public static implicit operator Output(Extract value) => new(value);

    public static implicit operator Output(Route value) => new(value);

    public static implicit operator Output(Classify value) => new(value);

    public static implicit operator Output(SplitCollection value) => new(value);

    public static implicit operator Output(SplitItem value) => new(value);

    public static implicit operator Output(ErrorEvent value) => new(value);

    public static implicit operator Output(Join value) => new(value);

    public static implicit operator Output(Enrich value) => new(value);

    public static implicit operator Output(CollectionProcessing value) => new(value);

    public static implicit operator Output(Send value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new BemInvalidDataException("Data did not match any variant of Output");
        }
        this.Switch(
            (transform) => transform.Validate(),
            (extract) => extract.Validate(),
            (route) => route.Validate(),
            (classify) => classify.Validate(),
            (splitCollection) => splitCollection.Validate(),
            (splitItem) => splitItem.Validate(),
            (errorEvent) => errorEvent.Validate(),
            (join) => join.Validate(),
            (enrich) => enrich.Validate(),
            (collectionProcessing) => collectionProcessing.Validate(),
            (send) => send.Validate()
        );
    }

    public virtual bool Equals(Output? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Transform _ => 0,
            Extract _ => 1,
            Route _ => 2,
            Classify _ => 3,
            SplitCollection _ => 4,
            SplitItem _ => 5,
            ErrorEvent _ => 6,
            Join _ => 7,
            Enrich _ => 8,
            CollectionProcessing _ => 9,
            Send _ => 10,
            _ => -1,
        };
    }
}

sealed class OutputConverter : JsonConverter<Output>
{
    public override Output? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? eventType;
        try
        {
            eventType = element.GetProperty("eventType").GetString();
        }
        catch
        {
            eventType = null;
        }

        switch (eventType)
        {
            case "transform":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Transform>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "extract":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Extract>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "route":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Route>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "classify":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Classify>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "split_collection":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SplitCollection>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "split_item":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SplitItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ErrorEvent>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "join":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Join>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "enrich":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Enrich>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "collection_processing":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CollectionProcessing>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "send":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Send>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Output(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Output value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Transform, TransformFromRaw>))]
public sealed record class Transform : JsonModel
{
    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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
    /// The number of items that were transformed. Used for batch transformations
    /// to indicate how many items were transformed.
    /// </summary>
    public required long ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("itemCount");
        }
        init { this._rawData.Set("itemCount", value); }
    }

    /// <summary>
    /// The offset of the first item that was transformed. Used for batch transformations
    /// to indicate which item in the batch this event corresponds to.
    /// </summary>
    public required long ItemOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("itemOffset");
        }
        init { this._rawData.Set("itemOffset", value); }
    }

    /// <summary>
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// The transformed content of the input. The structure of this object is defined
    /// by the function configuration.
    /// </summary>
    public required JsonElement TransformedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("transformedContent");
        }
        init { this._rawData.Set("transformedContent", value); }
    }

    /// <summary>
    /// Average confidence score across all extracted fields, in the range [0, 1].
    /// </summary>
    public float? AvgConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("avgConfidence");
        }
        init { this._rawData.Set("avgConfidence", value); }
    }

    /// <summary>
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Corrected feedback provided for fine-tuning purposes.
    /// </summary>
    public CorrectedContent? CorrectedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CorrectedContent>("correctedContent");
        }
        init { this._rawData.Set("correctedContent", value); }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public ApiEnum<string, global::Bem.Models.Calls.EventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Bem.Models.Calls.EventType>
            >("eventType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Per-field confidence scores. A JSON object mapping RFC 6901 JSON Pointer paths
    /// (e.g. `"/invoiceNumber"`) to float values in the range [0, 1] indicating the
    /// model's confidence in each extracted field value.
    /// </summary>
    public JsonElement? FieldConfidences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("fieldConfidences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fieldConfidences", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    /// <summary>
    /// Array of transformation inputs with their types and S3 URLs.
    /// </summary>
    public IReadOnlyList<Input>? Inputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Input>>("inputs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Input>?>(
                "inputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The input type of the content you're sending for transformation.
    /// </summary>
    public ApiEnum<string, InputType>? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InputType>>("inputType");
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
    /// List of properties that were invalid in the input.
    /// </summary>
    public IReadOnlyList<string>? InvalidProperties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("invalidProperties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "invalidProperties",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates whether this transformation was created as part of a regression test.
    /// </summary>
    public bool? IsRegression
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isRegression");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isRegression", value);
        }
    }

    /// <summary>
    /// Last timestamp indicating when the transform was published via webhook and
    /// received a non-200 response. Set to `null` on a subsequent retry if the webhook
    /// service receives a 200 response.
    /// </summary>
    public string? LastPublishErrorAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastPublishErrorAt");
        }
        init { this._rawData.Set("lastPublishErrorAt", value); }
    }

    public global::Bem.Models.Calls.Metadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Bem.Models.Calls.Metadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Accuracy, precision, recall, and F1 score when corrected JSON is provided.
    /// </summary>
    public Metrics? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metrics>("metrics");
        }
        init { this._rawData.Set("metrics", value); }
    }

    /// <summary>
    /// Indicates whether array order matters when comparing corrected JSON with
    /// extracted JSON.
    /// </summary>
    public bool? OrderMatching
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("orderMatching");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("orderMatching", value);
        }
    }

    /// <summary>
    /// ID of pipeline that transformed the original input data.
    /// </summary>
    public string? PipelineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pipelineID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pipelineID", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the transform was published via webhook and received
    /// a successful 200 response. Value is `null` if the transformation hasn't been sent.
    /// </summary>
    public DateTimeOffset? PublishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("publishedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("publishedAt", value);
        }
    }

    /// <summary>
    /// Presigned S3 URL for the input content uploaded to S3.
    /// </summary>
    public string? S3Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3URL");
        }
        init { this._rawData.Set("s3URL", value); }
    }

    /// <summary>
    /// Unique ID for each transformation output generated by bem following Segment's
    /// KSUID conventions.
    /// </summary>
    public string? TransformationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transformationID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transformationID", value);
        }
    }

    /// <summary>
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.ItemCount;
        _ = this.ItemOffset;
        _ = this.ReferenceID;
        _ = this.TransformedContent;
        _ = this.AvgConfidence;
        _ = this.CallID;
        this.CorrectedContent?.Validate();
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.FieldConfidences;
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.InboundEmail?.Validate();
        foreach (var item in this.Inputs ?? [])
        {
            item.Validate();
        }
        this.InputType?.Validate();
        _ = this.InvalidProperties;
        _ = this.IsRegression;
        _ = this.LastPublishErrorAt;
        this.Metadata?.Validate();
        this.Metrics?.Validate();
        _ = this.OrderMatching;
        _ = this.PipelineID;
        _ = this.PublishedAt;
        _ = this.S3Url;
        _ = this.TransformationID;
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public Transform() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transform(Transform transform)
        : base(transform) { }
#pragma warning restore CS8618

    public Transform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransformFromRaw.FromRawUnchecked"/>
    public static Transform FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransformFromRaw : IFromRawJson<Transform>
{
    /// <inheritdoc/>
    public Transform FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transform.FromRawUnchecked(rawData);
}

/// <summary>
/// Corrected feedback provided for fine-tuning purposes.
/// </summary>
[JsonConverter(typeof(CorrectedContentConverter))]
public record class CorrectedContent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CorrectedContent(CorrectedContentOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CorrectedContent(IReadOnlyList<JsonElement> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public CorrectedContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CorrectedContent(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CorrectedContent(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CorrectedContent(JsonElement element)
    {
        this._element = element;
        this.Value = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CorrectedContentOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCorrectedContentOutput(out var value)) {
    ///     // `value` is of type `CorrectedContentOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCorrectedContentOutput([NotNullWhen(true)] out CorrectedContentOutput? value)
    {
        value = this.Value as CorrectedContentOutput;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JsonElement"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElement(out var value)) {
    ///     // `value` is of type `JsonElement`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElement([NotNullWhen(true)] out JsonElement? value)
    {
        value = this.Value as JsonElement?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements([NotNullWhen(true)] out IReadOnlyList<JsonElement>? value)
    {
        value = this.Value as IReadOnlyList<JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (CorrectedContentOutput value) =&gt; {...},
    ///     (JsonElement value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<CorrectedContentOutput> correctedContentOutput,
        Action<JsonElement> jsonElement,
        Action<IReadOnlyList<JsonElement>> jsonElements,
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case CorrectedContentOutput value:
                correctedContentOutput(value);
                break;
            case JsonElement value:
                jsonElement(value);
                break;
            case IReadOnlyList<JsonElement> value:
                jsonElements(value);
                break;
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of CorrectedContent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (CorrectedContentOutput value) =&gt; {...},
    ///     (JsonElement value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<CorrectedContentOutput, T> correctedContentOutput,
        Func<JsonElement, T> jsonElement,
        Func<IReadOnlyList<JsonElement>, T> jsonElements,
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            CorrectedContentOutput value => correctedContentOutput(value),
            JsonElement value => jsonElement(value),
            IReadOnlyList<JsonElement> value => jsonElements(value),
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of CorrectedContent"
            ),
        };
    }

    public static implicit operator CorrectedContent(CorrectedContentOutput value) => new(value);

    public static implicit operator CorrectedContent(JsonElement value) => new(value);

    public static implicit operator CorrectedContent(List<JsonElement> value) =>
        new((IReadOnlyList<JsonElement>)value);

    public static implicit operator CorrectedContent(string value) => new(value);

    public static implicit operator CorrectedContent(double value) => new(value);

    public static implicit operator CorrectedContent(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new BemInvalidDataException("Data did not match any variant of CorrectedContent");
        }
        this.Switch(
            (correctedContentOutput) => correctedContentOutput.Validate(),
            (_) => { },
            (_) => { },
            (_) => { },
            (_) => { },
            (_) => { }
        );
    }

    public virtual bool Equals(CorrectedContent? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            CorrectedContentOutput _ => 0,
            JsonElement _ => 1,
            IReadOnlyList<JsonElement> _ => 2,
            string _ => 3,
            double _ => 4,
            bool _ => 5,
            _ => -1,
        };
    }
}

sealed class CorrectedContentConverter : JsonConverter<CorrectedContent?>
{
    public override CorrectedContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CorrectedContentOutput>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<JsonElement>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<JsonElement>(element, options));
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CorrectedContent? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<CorrectedContentOutput, CorrectedContentOutputFromRaw>))]
public sealed record class CorrectedContentOutput : JsonModel
{
    public IReadOnlyList<Outputs::AnyType?>? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Outputs::AnyType?>>("output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Outputs::AnyType?>?>(
                "output",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Output ?? [])
        {
            item?.Validate();
        }
    }

    public CorrectedContentOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CorrectedContentOutput(CorrectedContentOutput correctedContentOutput)
        : base(correctedContentOutput) { }
#pragma warning restore CS8618

    public CorrectedContentOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CorrectedContentOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CorrectedContentOutputFromRaw.FromRawUnchecked"/>
    public static CorrectedContentOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CorrectedContentOutputFromRaw : IFromRawJson<CorrectedContentOutput>
{
    /// <inheritdoc/>
    public CorrectedContentOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CorrectedContentOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Bem.Models.Calls.EventTypeConverter))]
public enum EventType
{
    Transform,
}

sealed class EventTypeConverter : JsonConverter<global::Bem.Models.Calls.EventType>
{
    public override global::Bem.Models.Calls.EventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transform" => global::Bem.Models.Calls.EventType.Transform,
            _ => (global::Bem.Models.Calls.EventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Bem.Models.Calls.EventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Bem.Models.Calls.EventType.Transform => "transform",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Input, InputFromRaw>))]
public sealed record class Input : JsonModel
{
    public string? InputContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inputContent");
        }
        init { this._rawData.Set("inputContent", value); }
    }

    public string? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inputType");
        }
        init { this._rawData.Set("inputType", value); }
    }

    public JsonElement? JsonInputContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("jsonInputContent");
        }
        init { this._rawData.Set("jsonInputContent", value); }
    }

    public string? S3Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3URL");
        }
        init { this._rawData.Set("s3URL", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputContent;
        _ = this.InputType;
        _ = this.JsonInputContent;
        _ = this.S3Url;
    }

    public Input() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Input(Input input)
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

    /// <inheritdoc cref="InputFromRaw.FromRawUnchecked"/>
    public static Input FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputFromRaw : IFromRawJson<Input>
{
    /// <inheritdoc/>
    public Input FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Input.FromRawUnchecked(rawData);
}

/// <summary>
/// The input type of the content you're sending for transformation.
/// </summary>
[JsonConverter(typeof(InputTypeConverter))]
public enum InputType
{
    Csv,
    Docx,
    Email,
    Heic,
    Html,
    Jpeg,
    Json,
    Heif,
    M4a,
    Mp3,
    Pdf,
    Png,
    Text,
    Wav,
    Webp,
    Xls,
    Xlsx,
    Xml,
}

sealed class InputTypeConverter : JsonConverter<InputType>
{
    public override InputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => InputType.Csv,
            "docx" => InputType.Docx,
            "email" => InputType.Email,
            "heic" => InputType.Heic,
            "html" => InputType.Html,
            "jpeg" => InputType.Jpeg,
            "json" => InputType.Json,
            "heif" => InputType.Heif,
            "m4a" => InputType.M4a,
            "mp3" => InputType.Mp3,
            "pdf" => InputType.Pdf,
            "png" => InputType.Png,
            "text" => InputType.Text,
            "wav" => InputType.Wav,
            "webp" => InputType.Webp,
            "xls" => InputType.Xls,
            "xlsx" => InputType.Xlsx,
            "xml" => InputType.Xml,
            _ => (InputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InputType.Csv => "csv",
                InputType.Docx => "docx",
                InputType.Email => "email",
                InputType.Heic => "heic",
                InputType.Html => "html",
                InputType.Jpeg => "jpeg",
                InputType.Json => "json",
                InputType.Heif => "heif",
                InputType.M4a => "m4a",
                InputType.Mp3 => "mp3",
                InputType.Pdf => "pdf",
                InputType.Png => "png",
                InputType.Text => "text",
                InputType.Wav => "wav",
                InputType.Webp => "webp",
                InputType.Xls => "xls",
                InputType.Xlsx => "xlsx",
                InputType.Xml => "xml",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Bem.Models.Calls.Metadata,
        global::Bem.Models.Calls.MetadataFromRaw
    >)
)]
public sealed record class Metadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metadata(global::Bem.Models.Calls.Metadata metadata)
        : base(metadata) { }
#pragma warning restore CS8618

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Bem.Models.Calls.MetadataFromRaw.FromRawUnchecked"/>
    public static global::Bem.Models.Calls.Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<global::Bem.Models.Calls.Metadata>
{
    /// <inheritdoc/>
    public global::Bem.Models.Calls.Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Bem.Models.Calls.Metadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Accuracy, precision, recall, and F1 score when corrected JSON is provided.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metrics, MetricsFromRaw>))]
public sealed record class Metrics : JsonModel
{
    public IReadOnlyList<Difference>? Differences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Difference>>("differences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Difference>?>(
                "differences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MetricsMetrics? MetricsValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetricsMetrics>("metrics");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metrics", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Differences ?? [])
        {
            item.Validate();
        }
        this.MetricsValue?.Validate();
    }

    public Metrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metrics(Metrics metrics)
        : base(metrics) { }
#pragma warning restore CS8618

    public Metrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricsFromRaw.FromRawUnchecked"/>
    public static Metrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricsFromRaw : IFromRawJson<Metrics>
{
    /// <inheritdoc/>
    public Metrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metrics.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Difference, DifferenceFromRaw>))]
public sealed record class Difference : JsonModel
{
    public string? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    public JsonElement? CorrectedVal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("correctedVal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("correctedVal", value);
        }
    }

    public JsonElement? ExtractedVal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("extractedVal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extractedVal", value);
        }
    }

    public string? JsonPointer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("jsonPointer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("jsonPointer", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Category;
        _ = this.CorrectedVal;
        _ = this.ExtractedVal;
        _ = this.JsonPointer;
    }

    public Difference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Difference(Difference difference)
        : base(difference) { }
#pragma warning restore CS8618

    public Difference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Difference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DifferenceFromRaw.FromRawUnchecked"/>
    public static Difference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DifferenceFromRaw : IFromRawJson<Difference>
{
    /// <inheritdoc/>
    public Difference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Difference.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MetricsMetrics, MetricsMetricsFromRaw>))]
public sealed record class MetricsMetrics : JsonModel
{
    public double? Accuracy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("accuracy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accuracy", value);
        }
    }

    public double? F1Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("f1Score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("f1Score", value);
        }
    }

    public double? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("precision");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("precision", value);
        }
    }

    public double? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("recall");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recall", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Accuracy;
        _ = this.F1Score;
        _ = this.Precision;
        _ = this.Recall;
    }

    public MetricsMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetricsMetrics(MetricsMetrics metricsMetrics)
        : base(metricsMetrics) { }
#pragma warning restore CS8618

    public MetricsMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricsMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricsMetricsFromRaw.FromRawUnchecked"/>
    public static MetricsMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricsMetricsFromRaw : IFromRawJson<MetricsMetrics>
{
    /// <inheritdoc/>
    public MetricsMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetricsMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 event variants that do not exist in the shared `Event` union.
///
/// <para>`ExtractEvent` and `ClassifyEvent` are emitted only by V3-era function types
/// (`extract` and `classify`). The shared `Event` union in `specs/events/models.tsp`
/// predates these types and continues to describe V2 / V1-alpha responses verbatim;
/// V3 response payloads add the new variants via the `EventV3` union below while
/// keeping every shared variant intact for backward compatibility.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Extract, ExtractFromRaw>))]
public sealed record class Extract : JsonModel
{
    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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
    /// The number of items that were transformed. Used for batch transformations
    /// to indicate how many items were transformed.
    /// </summary>
    public required long ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("itemCount");
        }
        init { this._rawData.Set("itemCount", value); }
    }

    /// <summary>
    /// The offset of the first item that was transformed. Used for batch transformations
    /// to indicate which item in the batch this event corresponds to.
    /// </summary>
    public required long ItemOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("itemOffset");
        }
        init { this._rawData.Set("itemOffset", value); }
    }

    /// <summary>
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// The transformed content of the input. The structure of this object is defined
    /// by the function configuration.
    /// </summary>
    public required JsonElement TransformedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("transformedContent");
        }
        init { this._rawData.Set("transformedContent", value); }
    }

    /// <summary>
    /// Average confidence score across all extracted fields, in the range [0, 1].
    /// </summary>
    public float? AvgConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("avgConfidence");
        }
        init { this._rawData.Set("avgConfidence", value); }
    }

    /// <summary>
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Corrected feedback provided for fine-tuning purposes.
    /// </summary>
    public ExtractCorrectedContent? CorrectedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtractCorrectedContent>("correctedContent");
        }
        init { this._rawData.Set("correctedContent", value); }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public ApiEnum<string, ExtractEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExtractEventType>>("eventType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Per-field confidence scores. A JSON object mapping RFC 6901 JSON Pointer paths
    /// (e.g. `"/invoiceNumber"`) to float values in the range [0, 1] indicating the
    /// model's confidence in each extracted field value.
    /// </summary>
    public JsonElement? FieldConfidences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("fieldConfidences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fieldConfidences", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    /// <summary>
    /// Array of transformation inputs with their types and S3 URLs.
    /// </summary>
    public IReadOnlyList<ExtractInput>? Inputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ExtractInput>>("inputs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExtractInput>?>(
                "inputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The input type of the content you're sending for transformation.
    /// </summary>
    public ApiEnum<string, ExtractInputType>? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExtractInputType>>("inputType");
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
    /// List of properties that were invalid in the input.
    /// </summary>
    public IReadOnlyList<string>? InvalidProperties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("invalidProperties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "invalidProperties",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ExtractMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtractMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Presigned S3 URL for the input content uploaded to S3.
    /// </summary>
    public string? S3Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3URL");
        }
        init { this._rawData.Set("s3URL", value); }
    }

    /// <summary>
    /// Unique ID for each transformation output generated by bem following Segment's
    /// KSUID conventions.
    /// </summary>
    public string? TransformationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transformationID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transformationID", value);
        }
    }

    /// <summary>
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.ItemCount;
        _ = this.ItemOffset;
        _ = this.ReferenceID;
        _ = this.TransformedContent;
        _ = this.AvgConfidence;
        _ = this.CallID;
        this.CorrectedContent?.Validate();
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.FieldConfidences;
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.InboundEmail?.Validate();
        foreach (var item in this.Inputs ?? [])
        {
            item.Validate();
        }
        this.InputType?.Validate();
        _ = this.InvalidProperties;
        this.Metadata?.Validate();
        _ = this.S3Url;
        _ = this.TransformationID;
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public Extract() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Extract(Extract extract)
        : base(extract) { }
#pragma warning restore CS8618

    public Extract(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Extract(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractFromRaw.FromRawUnchecked"/>
    public static Extract FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractFromRaw : IFromRawJson<Extract>
{
    /// <inheritdoc/>
    public Extract FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Extract.FromRawUnchecked(rawData);
}

/// <summary>
/// Corrected feedback provided for fine-tuning purposes.
/// </summary>
[JsonConverter(typeof(ExtractCorrectedContentConverter))]
public record class ExtractCorrectedContent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ExtractCorrectedContent(ExtractCorrectedContentOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractCorrectedContent(IReadOnlyList<JsonElement> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ExtractCorrectedContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractCorrectedContent(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractCorrectedContent(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractCorrectedContent(JsonElement element)
    {
        this._element = element;
        this.Value = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtractCorrectedContentOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtractCorrectedContentOutput(out var value)) {
    ///     // `value` is of type `ExtractCorrectedContentOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtractCorrectedContentOutput(
        [NotNullWhen(true)] out ExtractCorrectedContentOutput? value
    )
    {
        value = this.Value as ExtractCorrectedContentOutput;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JsonElement"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElement(out var value)) {
    ///     // `value` is of type `JsonElement`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElement([NotNullWhen(true)] out JsonElement? value)
    {
        value = this.Value as JsonElement?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements([NotNullWhen(true)] out IReadOnlyList<JsonElement>? value)
    {
        value = this.Value as IReadOnlyList<JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (ExtractCorrectedContentOutput value) =&gt; {...},
    ///     (JsonElement value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ExtractCorrectedContentOutput> extractCorrectedContentOutput,
        Action<JsonElement> jsonElement,
        Action<IReadOnlyList<JsonElement>> jsonElements,
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case ExtractCorrectedContentOutput value:
                extractCorrectedContentOutput(value);
                break;
            case JsonElement value:
                jsonElement(value);
                break;
            case IReadOnlyList<JsonElement> value:
                jsonElements(value);
                break;
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of ExtractCorrectedContent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (ExtractCorrectedContentOutput value) =&gt; {...},
    ///     (JsonElement value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ExtractCorrectedContentOutput, T> extractCorrectedContentOutput,
        Func<JsonElement, T> jsonElement,
        Func<IReadOnlyList<JsonElement>, T> jsonElements,
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            ExtractCorrectedContentOutput value => extractCorrectedContentOutput(value),
            JsonElement value => jsonElement(value),
            IReadOnlyList<JsonElement> value => jsonElements(value),
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of ExtractCorrectedContent"
            ),
        };
    }

    public static implicit operator ExtractCorrectedContent(ExtractCorrectedContentOutput value) =>
        new(value);

    public static implicit operator ExtractCorrectedContent(JsonElement value) => new(value);

    public static implicit operator ExtractCorrectedContent(List<JsonElement> value) =>
        new((IReadOnlyList<JsonElement>)value);

    public static implicit operator ExtractCorrectedContent(string value) => new(value);

    public static implicit operator ExtractCorrectedContent(double value) => new(value);

    public static implicit operator ExtractCorrectedContent(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new BemInvalidDataException(
                "Data did not match any variant of ExtractCorrectedContent"
            );
        }
        this.Switch(
            (extractCorrectedContentOutput) => extractCorrectedContentOutput.Validate(),
            (_) => { },
            (_) => { },
            (_) => { },
            (_) => { },
            (_) => { }
        );
    }

    public virtual bool Equals(ExtractCorrectedContent? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            ExtractCorrectedContentOutput _ => 0,
            JsonElement _ => 1,
            IReadOnlyList<JsonElement> _ => 2,
            string _ => 3,
            double _ => 4,
            bool _ => 5,
            _ => -1,
        };
    }
}

sealed class ExtractCorrectedContentConverter : JsonConverter<ExtractCorrectedContent?>
{
    public override ExtractCorrectedContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ExtractCorrectedContentOutput>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<JsonElement>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<JsonElement>(element, options));
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractCorrectedContent? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ExtractCorrectedContentOutput, ExtractCorrectedContentOutputFromRaw>)
)]
public sealed record class ExtractCorrectedContentOutput : JsonModel
{
    public IReadOnlyList<Outputs::AnyType?>? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Outputs::AnyType?>>("output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Outputs::AnyType?>?>(
                "output",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Output ?? [])
        {
            item?.Validate();
        }
    }

    public ExtractCorrectedContentOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractCorrectedContentOutput(
        ExtractCorrectedContentOutput extractCorrectedContentOutput
    )
        : base(extractCorrectedContentOutput) { }
#pragma warning restore CS8618

    public ExtractCorrectedContentOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractCorrectedContentOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractCorrectedContentOutputFromRaw.FromRawUnchecked"/>
    public static ExtractCorrectedContentOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractCorrectedContentOutputFromRaw : IFromRawJson<ExtractCorrectedContentOutput>
{
    /// <inheritdoc/>
    public ExtractCorrectedContentOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractCorrectedContentOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExtractEventTypeConverter))]
public enum ExtractEventType
{
    Extract,
}

sealed class ExtractEventTypeConverter : JsonConverter<ExtractEventType>
{
    public override ExtractEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "extract" => ExtractEventType.Extract,
            _ => (ExtractEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractEventType.Extract => "extract",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ExtractInput, ExtractInputFromRaw>))]
public sealed record class ExtractInput : JsonModel
{
    public string? InputContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inputContent");
        }
        init { this._rawData.Set("inputContent", value); }
    }

    public string? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inputType");
        }
        init { this._rawData.Set("inputType", value); }
    }

    public JsonElement? JsonInputContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("jsonInputContent");
        }
        init { this._rawData.Set("jsonInputContent", value); }
    }

    public string? S3Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3URL");
        }
        init { this._rawData.Set("s3URL", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputContent;
        _ = this.InputType;
        _ = this.JsonInputContent;
        _ = this.S3Url;
    }

    public ExtractInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractInput(ExtractInput extractInput)
        : base(extractInput) { }
#pragma warning restore CS8618

    public ExtractInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractInputFromRaw.FromRawUnchecked"/>
    public static ExtractInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractInputFromRaw : IFromRawJson<ExtractInput>
{
    /// <inheritdoc/>
    public ExtractInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractInput.FromRawUnchecked(rawData);
}

/// <summary>
/// The input type of the content you're sending for transformation.
/// </summary>
[JsonConverter(typeof(ExtractInputTypeConverter))]
public enum ExtractInputType
{
    Csv,
    Docx,
    Email,
    Heic,
    Html,
    Jpeg,
    Json,
    Heif,
    M4a,
    Mp3,
    Pdf,
    Png,
    Text,
    Wav,
    Webp,
    Xls,
    Xlsx,
    Xml,
}

sealed class ExtractInputTypeConverter : JsonConverter<ExtractInputType>
{
    public override ExtractInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => ExtractInputType.Csv,
            "docx" => ExtractInputType.Docx,
            "email" => ExtractInputType.Email,
            "heic" => ExtractInputType.Heic,
            "html" => ExtractInputType.Html,
            "jpeg" => ExtractInputType.Jpeg,
            "json" => ExtractInputType.Json,
            "heif" => ExtractInputType.Heif,
            "m4a" => ExtractInputType.M4a,
            "mp3" => ExtractInputType.Mp3,
            "pdf" => ExtractInputType.Pdf,
            "png" => ExtractInputType.Png,
            "text" => ExtractInputType.Text,
            "wav" => ExtractInputType.Wav,
            "webp" => ExtractInputType.Webp,
            "xls" => ExtractInputType.Xls,
            "xlsx" => ExtractInputType.Xlsx,
            "xml" => ExtractInputType.Xml,
            _ => (ExtractInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractInputType.Csv => "csv",
                ExtractInputType.Docx => "docx",
                ExtractInputType.Email => "email",
                ExtractInputType.Heic => "heic",
                ExtractInputType.Html => "html",
                ExtractInputType.Jpeg => "jpeg",
                ExtractInputType.Json => "json",
                ExtractInputType.Heif => "heif",
                ExtractInputType.M4a => "m4a",
                ExtractInputType.Mp3 => "mp3",
                ExtractInputType.Pdf => "pdf",
                ExtractInputType.Png => "png",
                ExtractInputType.Text => "text",
                ExtractInputType.Wav => "wav",
                ExtractInputType.Webp => "webp",
                ExtractInputType.Xls => "xls",
                ExtractInputType.Xlsx => "xlsx",
                ExtractInputType.Xml => "xml",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ExtractMetadata, ExtractMetadataFromRaw>))]
public sealed record class ExtractMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public ExtractMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractMetadata(ExtractMetadata extractMetadata)
        : base(extractMetadata) { }
#pragma warning restore CS8618

    public ExtractMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractMetadataFromRaw.FromRawUnchecked"/>
    public static ExtractMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractMetadataFromRaw : IFromRawJson<ExtractMetadata>
{
    /// <inheritdoc/>
    public ExtractMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Route, RouteFromRaw>))]
public sealed record class Route : JsonModel
{
    /// <summary>
    /// The choice made by the router function.
    /// </summary>
    public required string Choice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("choice");
        }
        init { this._rawData.Set("choice", value); }
    }

    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public ApiEnum<string, RouteEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RouteEventType>>("eventType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    public RouteMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RouteMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// The presigned S3 URL of the file that was routed.
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
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        _ = this.Choice;
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.ReferenceID;
        _ = this.CallID;
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.InboundEmail?.Validate();
        this.Metadata?.Validate();
        _ = this.S3Url;
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public Route() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Route(Route route)
        : base(route) { }
#pragma warning restore CS8618

    public Route(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Route(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RouteFromRaw.FromRawUnchecked"/>
    public static Route FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RouteFromRaw : IFromRawJson<Route>
{
    /// <inheritdoc/>
    public Route FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Route.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RouteEventTypeConverter))]
public enum RouteEventType
{
    Route,
}

sealed class RouteEventTypeConverter : JsonConverter<RouteEventType>
{
    public override RouteEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "route" => RouteEventType.Route,
            _ => (RouteEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteEventType.Route => "route",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<RouteMetadata, RouteMetadataFromRaw>))]
public sealed record class RouteMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public RouteMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RouteMetadata(RouteMetadata routeMetadata)
        : base(routeMetadata) { }
#pragma warning restore CS8618

    public RouteMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RouteMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RouteMetadataFromRaw.FromRawUnchecked"/>
    public static RouteMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RouteMetadataFromRaw : IFromRawJson<RouteMetadata>
{
    /// <inheritdoc/>
    public RouteMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RouteMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Classify, ClassifyFromRaw>))]
public sealed record class Classify : JsonModel
{
    /// <summary>
    /// The classification chosen by the classify function.
    /// </summary>
    public required string Choice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("choice");
        }
        init { this._rawData.Set("choice", value); }
    }

    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public ApiEnum<string, ClassifyEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ClassifyEventType>>("eventType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    public ClassifyMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ClassifyMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// The presigned S3 URL of the file that was classified.
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
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        _ = this.Choice;
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.ReferenceID;
        _ = this.CallID;
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.InboundEmail?.Validate();
        this.Metadata?.Validate();
        _ = this.S3Url;
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public Classify() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Classify(Classify classify)
        : base(classify) { }
#pragma warning restore CS8618

    public Classify(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Classify(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyFromRaw.FromRawUnchecked"/>
    public static Classify FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifyFromRaw : IFromRawJson<Classify>
{
    /// <inheritdoc/>
    public Classify FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Classify.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ClassifyEventTypeConverter))]
public enum ClassifyEventType
{
    Classify,
}

sealed class ClassifyEventTypeConverter : JsonConverter<ClassifyEventType>
{
    public override ClassifyEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "classify" => ClassifyEventType.Classify,
            _ => (ClassifyEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClassifyEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClassifyEventType.Classify => "classify",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ClassifyMetadata, ClassifyMetadataFromRaw>))]
public sealed record class ClassifyMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public ClassifyMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyMetadata(ClassifyMetadata classifyMetadata)
        : base(classifyMetadata) { }
#pragma warning restore CS8618

    public ClassifyMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyMetadataFromRaw.FromRawUnchecked"/>
    public static ClassifyMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifyMetadataFromRaw : IFromRawJson<ClassifyMetadata>
{
    /// <inheritdoc/>
    public ClassifyMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ClassifyMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SplitCollection, SplitCollectionFromRaw>))]
public sealed record class SplitCollection : JsonModel
{
    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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

    public required ApiEnum<string, OutputType> OutputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OutputType>>("outputType");
        }
        init { this._rawData.Set("outputType", value); }
    }

    public required PrintPageOutput PrintPageOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PrintPageOutput>("printPageOutput");
        }
        init { this._rawData.Set("printPageOutput", value); }
    }

    /// <summary>
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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

    public required SemanticPageOutput SemanticPageOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SemanticPageOutput>("semanticPageOutput");
        }
        init { this._rawData.Set("semanticPageOutput", value); }
    }

    /// <summary>
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public ApiEnum<string, SplitCollectionEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SplitCollectionEventType>>(
                "eventType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    public SplitCollectionMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SplitCollectionMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        this.OutputType.Validate();
        this.PrintPageOutput.Validate();
        _ = this.ReferenceID;
        this.SemanticPageOutput.Validate();
        _ = this.CallID;
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.InboundEmail?.Validate();
        this.Metadata?.Validate();
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public SplitCollection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitCollection(SplitCollection splitCollection)
        : base(splitCollection) { }
#pragma warning restore CS8618

    public SplitCollection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitCollection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitCollectionFromRaw.FromRawUnchecked"/>
    public static SplitCollection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitCollectionFromRaw : IFromRawJson<SplitCollection>
{
    /// <inheritdoc/>
    public SplitCollection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitCollection.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputTypeConverter))]
public enum OutputType
{
    PrintPage,
    SemanticPage,
}

sealed class OutputTypeConverter : JsonConverter<OutputType>
{
    public override OutputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => OutputType.PrintPage,
            "semantic_page" => OutputType.SemanticPage,
            _ => (OutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputType.PrintPage => "print_page",
                OutputType.SemanticPage => "semantic_page",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<PrintPageOutput, PrintPageOutputFromRaw>))]
public sealed record class PrintPageOutput : JsonModel
{
    public long? ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemCount", value);
        }
    }

    public IReadOnlyList<Item>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Item>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ItemCount;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
    }

    public PrintPageOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrintPageOutput(PrintPageOutput printPageOutput)
        : base(printPageOutput) { }
#pragma warning restore CS8618

    public PrintPageOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PrintPageOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrintPageOutputFromRaw.FromRawUnchecked"/>
    public static PrintPageOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrintPageOutputFromRaw : IFromRawJson<PrintPageOutput>
{
    /// <inheritdoc/>
    public PrintPageOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PrintPageOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public long? ItemOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemOffset", value);
        }
    }

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
        _ = this.ItemOffset;
        _ = this.ItemReferenceID;
        _ = this.S3Url;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SemanticPageOutput, SemanticPageOutputFromRaw>))]
public sealed record class SemanticPageOutput : JsonModel
{
    public long? ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemCount", value);
        }
    }

    public IReadOnlyList<SemanticPageOutputItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SemanticPageOutputItem>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SemanticPageOutputItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageCount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ItemCount;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.PageCount;
    }

    public SemanticPageOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SemanticPageOutput(SemanticPageOutput semanticPageOutput)
        : base(semanticPageOutput) { }
#pragma warning restore CS8618

    public SemanticPageOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SemanticPageOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SemanticPageOutputFromRaw.FromRawUnchecked"/>
    public static SemanticPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SemanticPageOutputFromRaw : IFromRawJson<SemanticPageOutput>
{
    /// <inheritdoc/>
    public SemanticPageOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SemanticPageOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SemanticPageOutputItem, SemanticPageOutputItemFromRaw>))]
public sealed record class SemanticPageOutputItem : JsonModel
{
    public string? ItemClass
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("itemClass");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemClass", value);
        }
    }

    public long? ItemClassCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemClassCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemClassCount", value);
        }
    }

    public long? ItemClassOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemClassOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemClassOffset", value);
        }
    }

    public long? ItemOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemOffset", value);
        }
    }

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

    public long? PageEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageEnd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageEnd", value);
        }
    }

    public long? PageStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageStart");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageStart", value);
        }
    }

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
        _ = this.ItemClass;
        _ = this.ItemClassCount;
        _ = this.ItemClassOffset;
        _ = this.ItemOffset;
        _ = this.ItemReferenceID;
        _ = this.PageEnd;
        _ = this.PageStart;
        _ = this.S3Url;
    }

    public SemanticPageOutputItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SemanticPageOutputItem(SemanticPageOutputItem semanticPageOutputItem)
        : base(semanticPageOutputItem) { }
#pragma warning restore CS8618

    public SemanticPageOutputItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SemanticPageOutputItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SemanticPageOutputItemFromRaw.FromRawUnchecked"/>
    public static SemanticPageOutputItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SemanticPageOutputItemFromRaw : IFromRawJson<SemanticPageOutputItem>
{
    /// <inheritdoc/>
    public SemanticPageOutputItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SemanticPageOutputItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SplitCollectionEventTypeConverter))]
public enum SplitCollectionEventType
{
    SplitCollection,
}

sealed class SplitCollectionEventTypeConverter : JsonConverter<SplitCollectionEventType>
{
    public override SplitCollectionEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "split_collection" => SplitCollectionEventType.SplitCollection,
            _ => (SplitCollectionEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitCollectionEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitCollectionEventType.SplitCollection => "split_collection",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SplitCollectionMetadata, SplitCollectionMetadataFromRaw>))]
public sealed record class SplitCollectionMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public SplitCollectionMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitCollectionMetadata(SplitCollectionMetadata splitCollectionMetadata)
        : base(splitCollectionMetadata) { }
#pragma warning restore CS8618

    public SplitCollectionMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitCollectionMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitCollectionMetadataFromRaw.FromRawUnchecked"/>
    public static SplitCollectionMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitCollectionMetadataFromRaw : IFromRawJson<SplitCollectionMetadata>
{
    /// <inheritdoc/>
    public SplitCollectionMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitCollectionMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SplitItem, SplitItemFromRaw>))]
public sealed record class SplitItem : JsonModel
{
    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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

    public required ApiEnum<string, SplitItemOutputType> OutputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SplitItemOutputType>>(
                "outputType"
            );
        }
        init { this._rawData.Set("outputType", value); }
    }

    /// <summary>
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public ApiEnum<string, SplitItemEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SplitItemEventType>>("eventType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    public SplitItemMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SplitItemMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    public SplitItemPrintPageOutput? PrintPageOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SplitItemPrintPageOutput>("printPageOutput");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("printPageOutput", value);
        }
    }

    public SplitItemSemanticPageOutput? SemanticPageOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SplitItemSemanticPageOutput>(
                "semanticPageOutput"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("semanticPageOutput", value);
        }
    }

    /// <summary>
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        this.OutputType.Validate();
        _ = this.ReferenceID;
        _ = this.CallID;
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.InboundEmail?.Validate();
        this.Metadata?.Validate();
        this.PrintPageOutput?.Validate();
        this.SemanticPageOutput?.Validate();
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public SplitItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitItem(SplitItem splitItem)
        : base(splitItem) { }
#pragma warning restore CS8618

    public SplitItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitItemFromRaw.FromRawUnchecked"/>
    public static SplitItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitItemFromRaw : IFromRawJson<SplitItem>
{
    /// <inheritdoc/>
    public SplitItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SplitItemOutputTypeConverter))]
public enum SplitItemOutputType
{
    PrintPage,
    SemanticPage,
}

sealed class SplitItemOutputTypeConverter : JsonConverter<SplitItemOutputType>
{
    public override SplitItemOutputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => SplitItemOutputType.PrintPage,
            "semantic_page" => SplitItemOutputType.SemanticPage,
            _ => (SplitItemOutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitItemOutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitItemOutputType.PrintPage => "print_page",
                SplitItemOutputType.SemanticPage => "semantic_page",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SplitItemEventTypeConverter))]
public enum SplitItemEventType
{
    SplitItem,
}

sealed class SplitItemEventTypeConverter : JsonConverter<SplitItemEventType>
{
    public override SplitItemEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "split_item" => SplitItemEventType.SplitItem,
            _ => (SplitItemEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitItemEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitItemEventType.SplitItem => "split_item",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SplitItemMetadata, SplitItemMetadataFromRaw>))]
public sealed record class SplitItemMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public SplitItemMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitItemMetadata(SplitItemMetadata splitItemMetadata)
        : base(splitItemMetadata) { }
#pragma warning restore CS8618

    public SplitItemMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitItemMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitItemMetadataFromRaw.FromRawUnchecked"/>
    public static SplitItemMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitItemMetadataFromRaw : IFromRawJson<SplitItemMetadata>
{
    /// <inheritdoc/>
    public SplitItemMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitItemMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SplitItemPrintPageOutput, SplitItemPrintPageOutputFromRaw>)
)]
public sealed record class SplitItemPrintPageOutput : JsonModel
{
    public string? CollectionReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("collectionReferenceID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectionReferenceID", value);
        }
    }

    public long? ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemCount", value);
        }
    }

    public long? ItemOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemOffset", value);
        }
    }

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
        _ = this.CollectionReferenceID;
        _ = this.ItemCount;
        _ = this.ItemOffset;
        _ = this.S3Url;
    }

    public SplitItemPrintPageOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitItemPrintPageOutput(SplitItemPrintPageOutput splitItemPrintPageOutput)
        : base(splitItemPrintPageOutput) { }
#pragma warning restore CS8618

    public SplitItemPrintPageOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitItemPrintPageOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitItemPrintPageOutputFromRaw.FromRawUnchecked"/>
    public static SplitItemPrintPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitItemPrintPageOutputFromRaw : IFromRawJson<SplitItemPrintPageOutput>
{
    /// <inheritdoc/>
    public SplitItemPrintPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitItemPrintPageOutput.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SplitItemSemanticPageOutput, SplitItemSemanticPageOutputFromRaw>)
)]
public sealed record class SplitItemSemanticPageOutput : JsonModel
{
    public string? CollectionReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("collectionReferenceID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectionReferenceID", value);
        }
    }

    public string? ItemClass
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("itemClass");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemClass", value);
        }
    }

    public long? ItemClassCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemClassCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemClassCount", value);
        }
    }

    public long? ItemClassOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemClassOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemClassOffset", value);
        }
    }

    public long? ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemCount", value);
        }
    }

    public long? ItemOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("itemOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemOffset", value);
        }
    }

    public long? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageCount", value);
        }
    }

    public long? PageEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageEnd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageEnd", value);
        }
    }

    public long? PageStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageStart");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageStart", value);
        }
    }

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
        _ = this.CollectionReferenceID;
        _ = this.ItemClass;
        _ = this.ItemClassCount;
        _ = this.ItemClassOffset;
        _ = this.ItemCount;
        _ = this.ItemOffset;
        _ = this.PageCount;
        _ = this.PageEnd;
        _ = this.PageStart;
        _ = this.S3Url;
    }

    public SplitItemSemanticPageOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitItemSemanticPageOutput(SplitItemSemanticPageOutput splitItemSemanticPageOutput)
        : base(splitItemSemanticPageOutput) { }
#pragma warning restore CS8618

    public SplitItemSemanticPageOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitItemSemanticPageOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitItemSemanticPageOutputFromRaw.FromRawUnchecked"/>
    public static SplitItemSemanticPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitItemSemanticPageOutputFromRaw : IFromRawJson<SplitItemSemanticPageOutput>
{
    /// <inheritdoc/>
    public SplitItemSemanticPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitItemSemanticPageOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Join, JoinFromRaw>))]
public sealed record class Join : JsonModel
{
    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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
    /// List of properties that were invalid in the input.
    /// </summary>
    public required IReadOnlyList<string> InvalidProperties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("invalidProperties");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "invalidProperties",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The items that were joined.
    /// </summary>
    public required IReadOnlyList<JoinItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JoinItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JoinItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of join that was performed.
    /// </summary>
    public required ApiEnum<string, JoinType> JoinType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JoinType>>("joinType");
        }
        init { this._rawData.Set("joinType", value); }
    }

    /// <summary>
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// The transformed content of the input. The structure of this object is defined
    /// by the function configuration.
    /// </summary>
    public required JsonElement TransformedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("transformedContent");
        }
        init { this._rawData.Set("transformedContent", value); }
    }

    /// <summary>
    /// Average confidence score across all extracted fields, in the range [0, 1].
    /// </summary>
    public float? AvgConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("avgConfidence");
        }
        init { this._rawData.Set("avgConfidence", value); }
    }

    /// <summary>
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public ApiEnum<string, JoinEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JoinEventType>>("eventType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Per-field confidence scores. A JSON object mapping RFC 6901 JSON Pointer paths
    /// (e.g. `"/invoiceNumber"`) to float values in the range [0, 1] indicating the
    /// model's confidence in each extracted field value.
    /// </summary>
    public JsonElement? FieldConfidences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("fieldConfidences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fieldConfidences", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    public JoinMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JoinMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Unique ID for each transformation output generated by bem following Segment's
    /// KSUID conventions.
    /// </summary>
    public string? TransformationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transformationID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transformationID", value);
        }
    }

    /// <summary>
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.InvalidProperties;
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.JoinType.Validate();
        _ = this.ReferenceID;
        _ = this.TransformedContent;
        _ = this.AvgConfidence;
        _ = this.CallID;
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.FieldConfidences;
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.InboundEmail?.Validate();
        this.Metadata?.Validate();
        _ = this.TransformationID;
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public Join() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Join(Join join)
        : base(join) { }
#pragma warning restore CS8618

    public Join(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Join(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinFromRaw.FromRawUnchecked"/>
    public static Join FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinFromRaw : IFromRawJson<Join>
{
    /// <inheritdoc/>
    public Join FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Join.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<JoinItem, JoinItemFromRaw>))]
public sealed record class JoinItem : JsonModel
{
    /// <summary>
    /// The number of items that were transformed.
    /// </summary>
    public required long ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("itemCount");
        }
        init { this._rawData.Set("itemCount", value); }
    }

    /// <summary>
    /// The offset of the first item that was transformed. Used for batch transformations
    /// to indicate which item in the batch this event corresponds to.
    /// </summary>
    public required long ItemOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("itemOffset");
        }
        init { this._rawData.Set("itemOffset", value); }
    }

    /// <summary>
    /// The unique ID you use internally to refer to this data point.
    /// </summary>
    public required string ItemReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("itemReferenceID");
        }
        init { this._rawData.Set("itemReferenceID", value); }
    }

    /// <summary>
    /// The presigned S3 URL of the file that was joined.
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
        _ = this.ItemCount;
        _ = this.ItemOffset;
        _ = this.ItemReferenceID;
        _ = this.S3Url;
    }

    public JoinItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinItem(JoinItem joinItem)
        : base(joinItem) { }
#pragma warning restore CS8618

    public JoinItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinItemFromRaw.FromRawUnchecked"/>
    public static JoinItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinItemFromRaw : IFromRawJson<JoinItem>
{
    /// <inheritdoc/>
    public JoinItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JoinItem.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of join that was performed.
/// </summary>
[JsonConverter(typeof(JoinTypeConverter))]
public enum JoinType
{
    Standard,
}

sealed class JoinTypeConverter : JsonConverter<JoinType>
{
    public override JoinType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => JoinType.Standard,
            _ => (JoinType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, JoinType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JoinType.Standard => "standard",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JoinEventTypeConverter))]
public enum JoinEventType
{
    Join,
}

sealed class JoinEventTypeConverter : JsonConverter<JoinEventType>
{
    public override JoinEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "join" => JoinEventType.Join,
            _ => (JoinEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JoinEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JoinEventType.Join => "join",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<JoinMetadata, JoinMetadataFromRaw>))]
public sealed record class JoinMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public JoinMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinMetadata(JoinMetadata joinMetadata)
        : base(joinMetadata) { }
#pragma warning restore CS8618

    public JoinMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinMetadataFromRaw.FromRawUnchecked"/>
    public static JoinMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinMetadataFromRaw : IFromRawJson<JoinMetadata>
{
    /// <inheritdoc/>
    public JoinMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JoinMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Enrich, EnrichFromRaw>))]
public sealed record class Enrich : JsonModel
{
    /// <summary>
    /// The enriched content produced by the enrich function. Contains the input data
    /// augmented with results from semantic search against collections.
    /// </summary>
    public required JsonElement EnrichedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("enrichedContent");
        }
        init { this._rawData.Set("enrichedContent", value); }
    }

    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public ApiEnum<string, EnrichEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EnrichEventType>>("eventType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    public EnrichMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EnrichMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        _ = this.EnrichedContent;
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.ReferenceID;
        _ = this.CallID;
        _ = this.CreatedAt;
        this.EventType?.Validate();
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.InboundEmail?.Validate();
        this.Metadata?.Validate();
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public Enrich() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Enrich(Enrich enrich)
        : base(enrich) { }
#pragma warning restore CS8618

    public Enrich(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Enrich(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnrichFromRaw.FromRawUnchecked"/>
    public static Enrich FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnrichFromRaw : IFromRawJson<Enrich>
{
    /// <inheritdoc/>
    public Enrich FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Enrich.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EnrichEventTypeConverter))]
public enum EnrichEventType
{
    Enrich,
}

sealed class EnrichEventTypeConverter : JsonConverter<EnrichEventType>
{
    public override EnrichEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enrich" => EnrichEventType.Enrich,
            _ => (EnrichEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EnrichEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EnrichEventType.Enrich => "enrich",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<EnrichMetadata, EnrichMetadataFromRaw>))]
public sealed record class EnrichMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public EnrichMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnrichMetadata(EnrichMetadata enrichMetadata)
        : base(enrichMetadata) { }
#pragma warning restore CS8618

    public EnrichMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnrichMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnrichMetadataFromRaw.FromRawUnchecked"/>
    public static EnrichMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnrichMetadataFromRaw : IFromRawJson<EnrichMetadata>
{
    /// <inheritdoc/>
    public EnrichMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EnrichMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CollectionProcessing, CollectionProcessingFromRaw>))]
public sealed record class CollectionProcessing : JsonModel
{
    /// <summary>
    /// Unique identifier of the collection.
    /// </summary>
    public required string CollectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collectionID");
        }
        init { this._rawData.Set("collectionID", value); }
    }

    /// <summary>
    /// Name/path of the collection.
    /// </summary>
    public required string CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collectionName");
        }
        init { this._rawData.Set("collectionName", value); }
    }

    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// The operation performed (add or update).
    /// </summary>
    public required ApiEnum<string, Operation> Operation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Operation>>("operation");
        }
        init { this._rawData.Set("operation", value); }
    }

    /// <summary>
    /// Number of items successfully processed.
    /// </summary>
    public required long ProcessedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("processedCount");
        }
        init { this._rawData.Set("processedCount", value); }
    }

    /// <summary>
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// Processing status (success or failed).
    /// </summary>
    public required ApiEnum<string, CollectionProcessingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CollectionProcessingStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Array of collection item KSUIDs that were added or updated.
    /// </summary>
    public IReadOnlyList<string>? CollectionItemIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("collectionItemIDs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "collectionItemIDs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Error message if processing failed.
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errorMessage", value);
        }
    }

    public ApiEnum<string, CollectionProcessingEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CollectionProcessingEventType>>(
                "eventType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    public CollectionProcessingMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CollectionProcessingMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CollectionID;
        _ = this.CollectionName;
        _ = this.EventID;
        this.Operation.Validate();
        _ = this.ProcessedCount;
        _ = this.ReferenceID;
        this.Status.Validate();
        _ = this.CollectionItemIds;
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        this.EventType?.Validate();
        _ = this.FunctionCallTryNumber;
        this.InboundEmail?.Validate();
        this.Metadata?.Validate();
    }

    public CollectionProcessing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionProcessing(CollectionProcessing collectionProcessing)
        : base(collectionProcessing) { }
#pragma warning restore CS8618

    public CollectionProcessing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionProcessing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CollectionProcessingFromRaw.FromRawUnchecked"/>
    public static CollectionProcessing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CollectionProcessingFromRaw : IFromRawJson<CollectionProcessing>
{
    /// <inheritdoc/>
    public CollectionProcessing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CollectionProcessing.FromRawUnchecked(rawData);
}

/// <summary>
/// The operation performed (add or update).
/// </summary>
[JsonConverter(typeof(OperationConverter))]
public enum Operation
{
    Add,
    Update,
}

sealed class OperationConverter : JsonConverter<Operation>
{
    public override Operation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "add" => Operation.Add,
            "update" => Operation.Update,
            _ => (Operation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operation.Add => "add",
                Operation.Update => "update",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Processing status (success or failed).
/// </summary>
[JsonConverter(typeof(CollectionProcessingStatusConverter))]
public enum CollectionProcessingStatus
{
    Success,
    Failed,
}

sealed class CollectionProcessingStatusConverter : JsonConverter<CollectionProcessingStatus>
{
    public override CollectionProcessingStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => CollectionProcessingStatus.Success,
            "failed" => CollectionProcessingStatus.Failed,
            _ => (CollectionProcessingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CollectionProcessingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CollectionProcessingStatus.Success => "success",
                CollectionProcessingStatus.Failed => "failed",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CollectionProcessingEventTypeConverter))]
public enum CollectionProcessingEventType
{
    CollectionProcessing,
}

sealed class CollectionProcessingEventTypeConverter : JsonConverter<CollectionProcessingEventType>
{
    public override CollectionProcessingEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "collection_processing" => CollectionProcessingEventType.CollectionProcessing,
            _ => (CollectionProcessingEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CollectionProcessingEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CollectionProcessingEventType.CollectionProcessing => "collection_processing",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<CollectionProcessingMetadata, CollectionProcessingMetadataFromRaw>)
)]
public sealed record class CollectionProcessingMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public CollectionProcessingMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionProcessingMetadata(CollectionProcessingMetadata collectionProcessingMetadata)
        : base(collectionProcessingMetadata) { }
#pragma warning restore CS8618

    public CollectionProcessingMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionProcessingMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CollectionProcessingMetadataFromRaw.FromRawUnchecked"/>
    public static CollectionProcessingMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CollectionProcessingMetadataFromRaw : IFromRawJson<CollectionProcessingMetadata>
{
    /// <inheritdoc/>
    public CollectionProcessingMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CollectionProcessingMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Send, SendFromRaw>))]
public sealed record class Send : JsonModel
{
    /// <summary>
    /// Outcome of a Send function's delivery attempt.
    /// </summary>
    public required ApiEnum<string, DeliveryStatus> DeliveryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeliveryStatus>>("deliveryStatus");
        }
        init { this._rawData.Set("deliveryStatus", value); }
    }

    /// <summary>
    /// Destination type for a Send function.
    /// </summary>
    public required ApiEnum<string, DestinationType> DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DestinationType>>(
                "destinationType"
            );
        }
        init { this._rawData.Set("destinationType", value); }
    }

    /// <summary>
    /// Unique ID generated by bem to identify the event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <summary>
    /// Unique identifier of function that this event is associated with.
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
    /// Unique name of function that this event is associated with.
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
    /// The unique ID you use internally to refer to this data point, propagated from
    /// the original function input.
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
    /// Unique identifier of workflow call that this event is associated with.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callID", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the event was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// The full protocol event JSON that was delivered — identical to what subscription
    /// publish would deliver for the same event. For ad-hoc calls with a JSON file
    /// input, contains the raw input JSON. For ad-hoc calls with a binary file input,
    /// contains {"s3URL": "&lt;presigned-url&gt;"}.
    /// </summary>
    public JsonElement? DeliveredContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("deliveredContent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deliveredContent", value);
        }
    }

    public ApiEnum<string, SendEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SendEventType>>("eventType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eventType", value);
        }
    }

    /// <summary>
    /// Unique identifier of function call that this event is associated with.
    /// </summary>
    public string? FunctionCallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionCallID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallID", value);
        }
    }

    /// <summary>
    /// The attempt number of the function call that created this event. 1 indexed.
    /// </summary>
    public long? FunctionCallTryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("functionCallTryNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCallTryNumber", value);
        }
    }

    /// <summary>
    /// Version number of function that this event is associated with.
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
    /// Metadata returned when a Send function delivers to Google Drive.
    /// </summary>
    public GoogleDriveOutput? GoogleDriveOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GoogleDriveOutput>("googleDriveOutput");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("googleDriveOutput", value);
        }
    }

    /// <summary>
    /// The inbound email that triggered this event.
    /// </summary>
    public InboundEmailEvent? InboundEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundEmailEvent>("inboundEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundEmail", value);
        }
    }

    public SendMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SendMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Metadata returned when a Send function delivers to an S3 bucket.
    /// </summary>
    public S3Output? S3Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<S3Output>("s3Output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3Output", value);
        }
    }

    /// <summary>
    /// Metadata returned when a Send function delivers to a webhook.
    /// </summary>
    public WebhookOutput? WebhookOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookOutput>("webhookOutput");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhookOutput", value);
        }
    }

    /// <summary>
    /// Unique identifier of workflow that this event is associated with.
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
    /// Name of workflow that this event is associated with.
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
    /// Version number of workflow that this event is associated with.
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
        this.DeliveryStatus.Validate();
        this.DestinationType.Validate();
        _ = this.EventID;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.ReferenceID;
        _ = this.CallID;
        _ = this.CreatedAt;
        _ = this.DeliveredContent;
        this.EventType?.Validate();
        _ = this.FunctionCallID;
        _ = this.FunctionCallTryNumber;
        _ = this.FunctionVersionNum;
        this.GoogleDriveOutput?.Validate();
        this.InboundEmail?.Validate();
        this.Metadata?.Validate();
        this.S3Output?.Validate();
        this.WebhookOutput?.Validate();
        _ = this.WorkflowID;
        _ = this.WorkflowName;
        _ = this.WorkflowVersionNum;
    }

    public Send() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Send(Send send)
        : base(send) { }
#pragma warning restore CS8618

    public Send(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Send(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendFromRaw.FromRawUnchecked"/>
    public static Send FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendFromRaw : IFromRawJson<Send>
{
    /// <inheritdoc/>
    public Send FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Send.FromRawUnchecked(rawData);
}

/// <summary>
/// Outcome of a Send function's delivery attempt.
/// </summary>
[JsonConverter(typeof(DeliveryStatusConverter))]
public enum DeliveryStatus
{
    Success,
    Skip,
}

sealed class DeliveryStatusConverter : JsonConverter<DeliveryStatus>
{
    public override DeliveryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => DeliveryStatus.Success,
            "skip" => DeliveryStatus.Skip,
            _ => (DeliveryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeliveryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeliveryStatus.Success => "success",
                DeliveryStatus.Skip => "skip",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Destination type for a Send function.
/// </summary>
[JsonConverter(typeof(DestinationTypeConverter))]
public enum DestinationType
{
    Webhook,
    S3,
    GoogleDrive,
}

sealed class DestinationTypeConverter : JsonConverter<DestinationType>
{
    public override DestinationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => DestinationType.Webhook,
            "s3" => DestinationType.S3,
            "google_drive" => DestinationType.GoogleDrive,
            _ => (DestinationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DestinationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DestinationType.Webhook => "webhook",
                DestinationType.S3 => "s3",
                DestinationType.GoogleDrive => "google_drive",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SendEventTypeConverter))]
public enum SendEventType
{
    Send,
}

sealed class SendEventTypeConverter : JsonConverter<SendEventType>
{
    public override SendEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "send" => SendEventType.Send,
            _ => (SendEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SendEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SendEventType.Send => "send",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Metadata returned when a Send function delivers to Google Drive.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GoogleDriveOutput, GoogleDriveOutputFromRaw>))]
public sealed record class GoogleDriveOutput : JsonModel
{
    /// <summary>
    /// Name of the file created in Google Drive.
    /// </summary>
    public required string FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fileName");
        }
        init { this._rawData.Set("fileName", value); }
    }

    /// <summary>
    /// ID of the Google Drive folder the file was placed in.
    /// </summary>
    public required string FolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("folderID");
        }
        init { this._rawData.Set("folderID", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileName;
        _ = this.FolderID;
    }

    public GoogleDriveOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleDriveOutput(GoogleDriveOutput googleDriveOutput)
        : base(googleDriveOutput) { }
#pragma warning restore CS8618

    public GoogleDriveOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleDriveOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleDriveOutputFromRaw.FromRawUnchecked"/>
    public static GoogleDriveOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoogleDriveOutputFromRaw : IFromRawJson<GoogleDriveOutput>
{
    /// <inheritdoc/>
    public GoogleDriveOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoogleDriveOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SendMetadata, SendMetadataFromRaw>))]
public sealed record class SendMetadata : JsonModel
{
    public double? DurationFunctionToEventSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationFunctionToEventSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationFunctionToEventSeconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationFunctionToEventSeconds;
    }

    public SendMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendMetadata(SendMetadata sendMetadata)
        : base(sendMetadata) { }
#pragma warning restore CS8618

    public SendMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendMetadataFromRaw.FromRawUnchecked"/>
    public static SendMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendMetadataFromRaw : IFromRawJson<SendMetadata>
{
    /// <inheritdoc/>
    public SendMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata returned when a Send function delivers to an S3 bucket.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<S3Output, S3OutputFromRaw>))]
public sealed record class S3Output : JsonModel
{
    /// <summary>
    /// Name of the S3 bucket the payload was written to.
    /// </summary>
    public required string BucketName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucketName");
        }
        init { this._rawData.Set("bucketName", value); }
    }

    /// <summary>
    /// Object key under which the payload was stored.
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BucketName;
        _ = this.Key;
    }

    public S3Output() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public S3Output(S3Output s3Output)
        : base(s3Output) { }
#pragma warning restore CS8618

    public S3Output(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    S3Output(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="S3OutputFromRaw.FromRawUnchecked"/>
    public static S3Output FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class S3OutputFromRaw : IFromRawJson<S3Output>
{
    /// <inheritdoc/>
    public S3Output FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        S3Output.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata returned when a Send function delivers to a webhook.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookOutput, WebhookOutputFromRaw>))]
public sealed record class WebhookOutput : JsonModel
{
    /// <summary>
    /// Raw HTTP response body returned by the webhook endpoint.
    /// </summary>
    public required string HttpResponseBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("httpResponseBody");
        }
        init { this._rawData.Set("httpResponseBody", value); }
    }

    /// <summary>
    /// HTTP status code returned by the webhook endpoint.
    /// </summary>
    public required long HttpStatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("httpStatusCode");
        }
        init { this._rawData.Set("httpStatusCode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HttpResponseBody;
        _ = this.HttpStatusCode;
    }

    public WebhookOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookOutput(WebhookOutput webhookOutput)
        : base(webhookOutput) { }
#pragma warning restore CS8618

    public WebhookOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookOutputFromRaw.FromRawUnchecked"/>
    public static WebhookOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookOutputFromRaw : IFromRawJson<WebhookOutput>
{
    /// <inheritdoc/>
    public WebhookOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// Input to the main function call.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallInput, CallInputFromRaw>))]
public sealed record class CallInput : JsonModel
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

    public CallInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallInput(CallInput callInput)
        : base(callInput) { }
#pragma warning restore CS8618

    public CallInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallInputFromRaw.FromRawUnchecked"/>
    public static CallInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallInputFromRaw : IFromRawJson<CallInput>
{
    /// <inheritdoc/>
    public CallInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallInput.FromRawUnchecked(rawData);
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
