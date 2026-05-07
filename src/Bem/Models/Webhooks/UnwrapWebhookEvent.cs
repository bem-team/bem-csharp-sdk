using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;
using Bem.Models.Outputs;

namespace Bem.Models.Webhooks;

/// <summary>
/// V3 event variants that do not exist in the shared `Event` union.
///
/// <para>`ExtractEvent` and `ClassifyEvent` are emitted only by V3-era function types
/// (`extract` and `classify`). The shared `Event` union in `specs/events/models.tsp`
/// predates these types and continues to describe V2 / V1-alpha responses verbatim;
/// V3 response payloads add the new variants via the `EventV3` union below while
/// keeping every shared variant intact for backward compatibility.</para>
/// </summary>
[JsonConverter(typeof(UnwrapWebhookEventConverter))]
public record class UnwrapWebhookEvent : ModelBase
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
                extract: (x) => x.EventID,
                classify: (x) => x.EventID,
                parse: (x) => x.EventID,
                splitCollection: (x) => x.EventID,
                splitItem: (x) => x.EventID,
                join: (x) => x.EventID,
                enrich: (x) => x.EventID,
                payloadShaping: (x) => x.EventID,
                send: (x) => x.EventID,
                evaluation: (x) => x.EventID,
                collectionProcessing: (x) => x.EventID,
                error: (x) => x.EventID
            );
        }
    }

    public string? FunctionID
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.FunctionID,
                classify: (x) => x.FunctionID,
                parse: (x) => x.FunctionID,
                splitCollection: (x) => x.FunctionID,
                splitItem: (x) => x.FunctionID,
                join: (x) => x.FunctionID,
                enrich: (x) => x.FunctionID,
                payloadShaping: (x) => x.FunctionID,
                send: (x) => x.FunctionID,
                evaluation: (x) => x.FunctionID,
                collectionProcessing: (_) => null,
                error: (x) => x.FunctionID
            );
        }
    }

    public string? FunctionName
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.FunctionName,
                classify: (x) => x.FunctionName,
                parse: (x) => x.FunctionName,
                splitCollection: (x) => x.FunctionName,
                splitItem: (x) => x.FunctionName,
                join: (x) => x.FunctionName,
                enrich: (x) => x.FunctionName,
                payloadShaping: (x) => x.FunctionName,
                send: (x) => x.FunctionName,
                evaluation: (x) => x.FunctionName,
                collectionProcessing: (_) => null,
                error: (x) => x.FunctionName
            );
        }
    }

    public long? ItemCount
    {
        get
        {
            return Match<long?>(
                extract: (x) => x.ItemCount,
                classify: (_) => null,
                parse: (x) => x.ItemCount,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public long? ItemOffset
    {
        get
        {
            return Match<long?>(
                extract: (x) => x.ItemOffset,
                classify: (_) => null,
                parse: (x) => x.ItemOffset,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public string ReferenceID
    {
        get
        {
            return Match(
                extract: (x) => x.ReferenceID,
                classify: (x) => x.ReferenceID,
                parse: (x) => x.ReferenceID,
                splitCollection: (x) => x.ReferenceID,
                splitItem: (x) => x.ReferenceID,
                join: (x) => x.ReferenceID,
                enrich: (x) => x.ReferenceID,
                payloadShaping: (x) => x.ReferenceID,
                send: (x) => x.ReferenceID,
                evaluation: (x) => x.ReferenceID,
                collectionProcessing: (x) => x.ReferenceID,
                error: (x) => x.ReferenceID
            );
        }
    }

    public JsonElement? TransformedContent
    {
        get
        {
            return Match<JsonElement?>(
                extract: (x) => x.TransformedContent,
                classify: (_) => null,
                parse: (x) => x.TransformedContent,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (x) => x.TransformedContent,
                enrich: (_) => null,
                payloadShaping: (x) => x.TransformedContent,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public float? AvgConfidence
    {
        get
        {
            return Match<float?>(
                extract: (x) => x.AvgConfidence,
                classify: (_) => null,
                parse: (x) => x.AvgConfidence,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (x) => x.AvgConfidence,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public string? CallID
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.CallID,
                classify: (x) => x.CallID,
                parse: (x) => x.CallID,
                splitCollection: (x) => x.CallID,
                splitItem: (x) => x.CallID,
                join: (x) => x.CallID,
                enrich: (x) => x.CallID,
                payloadShaping: (x) => x.CallID,
                send: (x) => x.CallID,
                evaluation: (x) => x.CallID,
                collectionProcessing: (_) => null,
                error: (x) => x.CallID
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            return Match<DateTimeOffset?>(
                extract: (x) => x.CreatedAt,
                classify: (x) => x.CreatedAt,
                parse: (x) => x.CreatedAt,
                splitCollection: (x) => x.CreatedAt,
                splitItem: (x) => x.CreatedAt,
                join: (x) => x.CreatedAt,
                enrich: (x) => x.CreatedAt,
                payloadShaping: (x) => x.CreatedAt,
                send: (x) => x.CreatedAt,
                evaluation: (x) => x.CreatedAt,
                collectionProcessing: (x) => x.CreatedAt,
                error: (x) => x.CreatedAt
            );
        }
    }

    public JsonElement? FieldBoundingBoxes
    {
        get
        {
            return Match<JsonElement?>(
                extract: (x) => x.FieldBoundingBoxes,
                classify: (_) => null,
                parse: (x) => x.FieldBoundingBoxes,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public JsonElement? FieldConfidences
    {
        get
        {
            return Match<JsonElement?>(
                extract: (x) => x.FieldConfidences,
                classify: (_) => null,
                parse: (x) => x.FieldConfidences,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (x) => x.FieldConfidences,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public string? FunctionCallID
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.FunctionCallID,
                classify: (x) => x.FunctionCallID,
                parse: (x) => x.FunctionCallID,
                splitCollection: (x) => x.FunctionCallID,
                splitItem: (x) => x.FunctionCallID,
                join: (x) => x.FunctionCallID,
                enrich: (x) => x.FunctionCallID,
                payloadShaping: (x) => x.FunctionCallID,
                send: (x) => x.FunctionCallID,
                evaluation: (x) => x.FunctionCallID,
                collectionProcessing: (_) => null,
                error: (x) => x.FunctionCallID
            );
        }
    }

    public long? FunctionCallTryNumber
    {
        get
        {
            return Match<long?>(
                extract: (x) => x.FunctionCallTryNumber,
                classify: (x) => x.FunctionCallTryNumber,
                parse: (x) => x.FunctionCallTryNumber,
                splitCollection: (x) => x.FunctionCallTryNumber,
                splitItem: (x) => x.FunctionCallTryNumber,
                join: (x) => x.FunctionCallTryNumber,
                enrich: (x) => x.FunctionCallTryNumber,
                payloadShaping: (x) => x.FunctionCallTryNumber,
                send: (x) => x.FunctionCallTryNumber,
                evaluation: (x) => x.FunctionCallTryNumber,
                collectionProcessing: (x) => x.FunctionCallTryNumber,
                error: (x) => x.FunctionCallTryNumber
            );
        }
    }

    public long? FunctionVersionNum
    {
        get
        {
            return Match<long?>(
                extract: (x) => x.FunctionVersionNum,
                classify: (x) => x.FunctionVersionNum,
                parse: (x) => x.FunctionVersionNum,
                splitCollection: (x) => x.FunctionVersionNum,
                splitItem: (x) => x.FunctionVersionNum,
                join: (x) => x.FunctionVersionNum,
                enrich: (x) => x.FunctionVersionNum,
                payloadShaping: (x) => x.FunctionVersionNum,
                send: (x) => x.FunctionVersionNum,
                evaluation: (x) => x.FunctionVersionNum,
                collectionProcessing: (_) => null,
                error: (x) => x.FunctionVersionNum
            );
        }
    }

    public InboundEmailEvent? InboundEmail
    {
        get
        {
            return Match<InboundEmailEvent?>(
                extract: (x) => x.InboundEmail,
                classify: (x) => x.InboundEmail,
                parse: (x) => x.InboundEmail,
                splitCollection: (x) => x.InboundEmail,
                splitItem: (x) => x.InboundEmail,
                join: (x) => x.InboundEmail,
                enrich: (x) => x.InboundEmail,
                payloadShaping: (x) => x.InboundEmail,
                send: (x) => x.InboundEmail,
                evaluation: (x) => x.InboundEmail,
                collectionProcessing: (x) => x.InboundEmail,
                error: (x) => x.InboundEmail
            );
        }
    }

    public ApiEnum<string, InputType>? InputType
    {
        get
        {
            return Match<ApiEnum<string, InputType>?>(
                extract: (x) => x.InputType,
                classify: (_) => null,
                parse: (x) => x.InputType,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public string? S3Url
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.S3Url,
                classify: (x) => x.S3Url,
                parse: (x) => x.S3Url,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public string? TransformationID
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.TransformationID,
                classify: (_) => null,
                parse: (x) => x.TransformationID,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (x) => x.TransformationID,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (_) => null,
                collectionProcessing: (_) => null,
                error: (_) => null
            );
        }
    }

    public string? WorkflowID
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.WorkflowID,
                classify: (x) => x.WorkflowID,
                parse: (x) => x.WorkflowID,
                splitCollection: (x) => x.WorkflowID,
                splitItem: (x) => x.WorkflowID,
                join: (x) => x.WorkflowID,
                enrich: (x) => x.WorkflowID,
                payloadShaping: (x) => x.WorkflowID,
                send: (x) => x.WorkflowID,
                evaluation: (x) => x.WorkflowID,
                collectionProcessing: (_) => null,
                error: (x) => x.WorkflowID
            );
        }
    }

    public string? WorkflowName
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.WorkflowName,
                classify: (x) => x.WorkflowName,
                parse: (x) => x.WorkflowName,
                splitCollection: (x) => x.WorkflowName,
                splitItem: (x) => x.WorkflowName,
                join: (x) => x.WorkflowName,
                enrich: (x) => x.WorkflowName,
                payloadShaping: (x) => x.WorkflowName,
                send: (x) => x.WorkflowName,
                evaluation: (x) => x.WorkflowName,
                collectionProcessing: (_) => null,
                error: (x) => x.WorkflowName
            );
        }
    }

    public long? WorkflowVersionNum
    {
        get
        {
            return Match<long?>(
                extract: (x) => x.WorkflowVersionNum,
                classify: (x) => x.WorkflowVersionNum,
                parse: (x) => x.WorkflowVersionNum,
                splitCollection: (x) => x.WorkflowVersionNum,
                splitItem: (x) => x.WorkflowVersionNum,
                join: (x) => x.WorkflowVersionNum,
                enrich: (x) => x.WorkflowVersionNum,
                payloadShaping: (x) => x.WorkflowVersionNum,
                send: (x) => x.WorkflowVersionNum,
                evaluation: (x) => x.WorkflowVersionNum,
                collectionProcessing: (_) => null,
                error: (x) => x.WorkflowVersionNum
            );
        }
    }

    public string? ErrorMessage
    {
        get
        {
            return Match<string?>(
                extract: (_) => null,
                classify: (_) => null,
                parse: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                payloadShaping: (_) => null,
                send: (_) => null,
                evaluation: (x) => x.ErrorMessage,
                collectionProcessing: (x) => x.ErrorMessage,
                error: (_) => null
            );
        }
    }

    public UnwrapWebhookEvent(ExtractWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(ClassifyWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(ParseWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SplitCollectionWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SplitItemWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(JoinWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(EnrichWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PayloadShapingWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SendWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(EvaluationWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CollectionProcessingWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(ErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtractWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtract(out var value)) {
    ///     // `value` is of type `ExtractWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtract([NotNullWhen(true)] out ExtractWebhookEvent? value)
    {
        value = this.Value as ExtractWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ClassifyWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClassify(out var value)) {
    ///     // `value` is of type `ClassifyWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClassify([NotNullWhen(true)] out ClassifyWebhookEvent? value)
    {
        value = this.Value as ClassifyWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ParseWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickParse(out var value)) {
    ///     // `value` is of type `ParseWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickParse([NotNullWhen(true)] out ParseWebhookEvent? value)
    {
        value = this.Value as ParseWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SplitCollectionWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplitCollection(out var value)) {
    ///     // `value` is of type `SplitCollectionWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplitCollection([NotNullWhen(true)] out SplitCollectionWebhookEvent? value)
    {
        value = this.Value as SplitCollectionWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SplitItemWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplitItem(out var value)) {
    ///     // `value` is of type `SplitItemWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplitItem([NotNullWhen(true)] out SplitItemWebhookEvent? value)
    {
        value = this.Value as SplitItemWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JoinWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJoin(out var value)) {
    ///     // `value` is of type `JoinWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJoin([NotNullWhen(true)] out JoinWebhookEvent? value)
    {
        value = this.Value as JoinWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EnrichWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrich(out var value)) {
    ///     // `value` is of type `EnrichWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrich([NotNullWhen(true)] out EnrichWebhookEvent? value)
    {
        value = this.Value as EnrichWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PayloadShapingWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayloadShaping(out var value)) {
    ///     // `value` is of type `PayloadShapingWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayloadShaping([NotNullWhen(true)] out PayloadShapingWebhookEvent? value)
    {
        value = this.Value as PayloadShapingWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `SendWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out SendWebhookEvent? value)
    {
        value = this.Value as SendWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EvaluationWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEvaluation(out var value)) {
    ///     // `value` is of type `EvaluationWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEvaluation([NotNullWhen(true)] out EvaluationWebhookEvent? value)
    {
        value = this.Value as EvaluationWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CollectionProcessingWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCollectionProcessing(out var value)) {
    ///     // `value` is of type `CollectionProcessingWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCollectionProcessing(
        [NotNullWhen(true)] out CollectionProcessingWebhookEvent? value
    )
    {
        value = this.Value as CollectionProcessingWebhookEvent;
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
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `ErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError([NotNullWhen(true)] out ErrorEvent? value)
    {
        value = this.Value as ErrorEvent;
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
    ///     (ExtractWebhookEvent value) =&gt; {...},
    ///     (ClassifyWebhookEvent value) =&gt; {...},
    ///     (ParseWebhookEvent value) =&gt; {...},
    ///     (SplitCollectionWebhookEvent value) =&gt; {...},
    ///     (SplitItemWebhookEvent value) =&gt; {...},
    ///     (JoinWebhookEvent value) =&gt; {...},
    ///     (EnrichWebhookEvent value) =&gt; {...},
    ///     (PayloadShapingWebhookEvent value) =&gt; {...},
    ///     (SendWebhookEvent value) =&gt; {...},
    ///     (EvaluationWebhookEvent value) =&gt; {...},
    ///     (CollectionProcessingWebhookEvent value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ExtractWebhookEvent> extract,
        Action<ClassifyWebhookEvent> classify,
        Action<ParseWebhookEvent> parse,
        Action<SplitCollectionWebhookEvent> splitCollection,
        Action<SplitItemWebhookEvent> splitItem,
        Action<JoinWebhookEvent> join,
        Action<EnrichWebhookEvent> enrich,
        Action<PayloadShapingWebhookEvent> payloadShaping,
        Action<SendWebhookEvent> send,
        Action<EvaluationWebhookEvent> evaluation,
        Action<CollectionProcessingWebhookEvent> collectionProcessing,
        Action<ErrorEvent> error
    )
    {
        switch (this.Value)
        {
            case ExtractWebhookEvent value:
                extract(value);
                break;
            case ClassifyWebhookEvent value:
                classify(value);
                break;
            case ParseWebhookEvent value:
                parse(value);
                break;
            case SplitCollectionWebhookEvent value:
                splitCollection(value);
                break;
            case SplitItemWebhookEvent value:
                splitItem(value);
                break;
            case JoinWebhookEvent value:
                join(value);
                break;
            case EnrichWebhookEvent value:
                enrich(value);
                break;
            case PayloadShapingWebhookEvent value:
                payloadShaping(value);
                break;
            case SendWebhookEvent value:
                send(value);
                break;
            case EvaluationWebhookEvent value:
                evaluation(value);
                break;
            case CollectionProcessingWebhookEvent value:
                collectionProcessing(value);
                break;
            case ErrorEvent value:
                error(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of UnwrapWebhookEvent"
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
    ///     (ExtractWebhookEvent value) =&gt; {...},
    ///     (ClassifyWebhookEvent value) =&gt; {...},
    ///     (ParseWebhookEvent value) =&gt; {...},
    ///     (SplitCollectionWebhookEvent value) =&gt; {...},
    ///     (SplitItemWebhookEvent value) =&gt; {...},
    ///     (JoinWebhookEvent value) =&gt; {...},
    ///     (EnrichWebhookEvent value) =&gt; {...},
    ///     (PayloadShapingWebhookEvent value) =&gt; {...},
    ///     (SendWebhookEvent value) =&gt; {...},
    ///     (EvaluationWebhookEvent value) =&gt; {...},
    ///     (CollectionProcessingWebhookEvent value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ExtractWebhookEvent, T> extract,
        Func<ClassifyWebhookEvent, T> classify,
        Func<ParseWebhookEvent, T> parse,
        Func<SplitCollectionWebhookEvent, T> splitCollection,
        Func<SplitItemWebhookEvent, T> splitItem,
        Func<JoinWebhookEvent, T> join,
        Func<EnrichWebhookEvent, T> enrich,
        Func<PayloadShapingWebhookEvent, T> payloadShaping,
        Func<SendWebhookEvent, T> send,
        Func<EvaluationWebhookEvent, T> evaluation,
        Func<CollectionProcessingWebhookEvent, T> collectionProcessing,
        Func<ErrorEvent, T> error
    )
    {
        return this.Value switch
        {
            ExtractWebhookEvent value => extract(value),
            ClassifyWebhookEvent value => classify(value),
            ParseWebhookEvent value => parse(value),
            SplitCollectionWebhookEvent value => splitCollection(value),
            SplitItemWebhookEvent value => splitItem(value),
            JoinWebhookEvent value => join(value),
            EnrichWebhookEvent value => enrich(value),
            PayloadShapingWebhookEvent value => payloadShaping(value),
            SendWebhookEvent value => send(value),
            EvaluationWebhookEvent value => evaluation(value),
            CollectionProcessingWebhookEvent value => collectionProcessing(value),
            ErrorEvent value => error(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of UnwrapWebhookEvent"
            ),
        };
    }

    public static implicit operator UnwrapWebhookEvent(ExtractWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(ClassifyWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(ParseWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(SplitCollectionWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SplitItemWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(JoinWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(EnrichWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(PayloadShapingWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SendWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(EvaluationWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(CollectionProcessingWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(ErrorEvent value) => new(value);

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
                "Data did not match any variant of UnwrapWebhookEvent"
            );
        }
        this.Switch(
            (extract) => extract.Validate(),
            (classify) => classify.Validate(),
            (parse) => parse.Validate(),
            (splitCollection) => splitCollection.Validate(),
            (splitItem) => splitItem.Validate(),
            (join) => join.Validate(),
            (enrich) => enrich.Validate(),
            (payloadShaping) => payloadShaping.Validate(),
            (send) => send.Validate(),
            (evaluation) => evaluation.Validate(),
            (collectionProcessing) => collectionProcessing.Validate(),
            (error) => error.Validate()
        );
    }

    public virtual bool Equals(UnwrapWebhookEvent? other) =>
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
            ExtractWebhookEvent _ => 0,
            ClassifyWebhookEvent _ => 1,
            ParseWebhookEvent _ => 2,
            SplitCollectionWebhookEvent _ => 3,
            SplitItemWebhookEvent _ => 4,
            JoinWebhookEvent _ => 5,
            EnrichWebhookEvent _ => 6,
            PayloadShapingWebhookEvent _ => 7,
            SendWebhookEvent _ => 8,
            EvaluationWebhookEvent _ => 9,
            CollectionProcessingWebhookEvent _ => 10,
            ErrorEvent _ => 11,
            _ => -1,
        };
    }
}

sealed class UnwrapWebhookEventConverter : JsonConverter<UnwrapWebhookEvent>
{
    public override UnwrapWebhookEvent? Read(
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
            case "extract":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExtractWebhookEvent>(
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
            case "classify":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ClassifyWebhookEvent>(
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
            case "parse":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ParseWebhookEvent>(
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
            case "split_collection":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SplitCollectionWebhookEvent>(
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
                    var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEvent>(
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
            case "join":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<JoinWebhookEvent>(
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
            case "enrich":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EnrichWebhookEvent>(
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
            case "payload_shaping":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PayloadShapingWebhookEvent>(
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
                    var deserialized = JsonSerializer.Deserialize<SendWebhookEvent>(
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
            case "evaluation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EvaluationWebhookEvent>(
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
            case "collection_processing":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CollectionProcessingWebhookEvent>(
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
            default:
            {
                return new UnwrapWebhookEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
