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

namespace Bem.Models.Outputs;

/// <summary>
/// V3 read-side event union. Superset of the shared `Event` union: it contains every
/// shared variant verbatim (backward compatible) and adds the V3-only `extract` and
/// `classify` variants.
/// </summary>
[JsonConverter(typeof(OutputListResponseConverter))]
public record class OutputListResponse : ModelBase
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

    public OutputListResponse(OutputListResponseTransform value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(OutputListResponseExtract value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(OutputListResponseRoute value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(OutputListResponseClassify value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(OutputListResponseSplitCollection value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(OutputListResponseSplitItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(ErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(OutputListResponseJoin value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(OutputListResponseEnrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(
        OutputListResponseCollectionProcessing value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(OutputListResponseSend value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseTransform"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTransform(out var value)) {
    ///     // `value` is of type `OutputListResponseTransform`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTransform([NotNullWhen(true)] out OutputListResponseTransform? value)
    {
        value = this.Value as OutputListResponseTransform;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseExtract"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtract(out var value)) {
    ///     // `value` is of type `OutputListResponseExtract`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtract([NotNullWhen(true)] out OutputListResponseExtract? value)
    {
        value = this.Value as OutputListResponseExtract;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseRoute"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRoute(out var value)) {
    ///     // `value` is of type `OutputListResponseRoute`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRoute([NotNullWhen(true)] out OutputListResponseRoute? value)
    {
        value = this.Value as OutputListResponseRoute;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseClassify"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClassify(out var value)) {
    ///     // `value` is of type `OutputListResponseClassify`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClassify([NotNullWhen(true)] out OutputListResponseClassify? value)
    {
        value = this.Value as OutputListResponseClassify;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseSplitCollection"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplitCollection(out var value)) {
    ///     // `value` is of type `OutputListResponseSplitCollection`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplitCollection(
        [NotNullWhen(true)] out OutputListResponseSplitCollection? value
    )
    {
        value = this.Value as OutputListResponseSplitCollection;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseSplitItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplitItem(out var value)) {
    ///     // `value` is of type `OutputListResponseSplitItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplitItem([NotNullWhen(true)] out OutputListResponseSplitItem? value)
    {
        value = this.Value as OutputListResponseSplitItem;
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
    /// type <see cref="OutputListResponseJoin"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJoin(out var value)) {
    ///     // `value` is of type `OutputListResponseJoin`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJoin([NotNullWhen(true)] out OutputListResponseJoin? value)
    {
        value = this.Value as OutputListResponseJoin;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseEnrich"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrich(out var value)) {
    ///     // `value` is of type `OutputListResponseEnrich`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrich([NotNullWhen(true)] out OutputListResponseEnrich? value)
    {
        value = this.Value as OutputListResponseEnrich;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseCollectionProcessing"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCollectionProcessing(out var value)) {
    ///     // `value` is of type `OutputListResponseCollectionProcessing`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCollectionProcessing(
        [NotNullWhen(true)] out OutputListResponseCollectionProcessing? value
    )
    {
        value = this.Value as OutputListResponseCollectionProcessing;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseSend"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `OutputListResponseSend`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out OutputListResponseSend? value)
    {
        value = this.Value as OutputListResponseSend;
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
    ///     (OutputListResponseTransform value) =&gt; {...},
    ///     (OutputListResponseExtract value) =&gt; {...},
    ///     (OutputListResponseRoute value) =&gt; {...},
    ///     (OutputListResponseClassify value) =&gt; {...},
    ///     (OutputListResponseSplitCollection value) =&gt; {...},
    ///     (OutputListResponseSplitItem value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...},
    ///     (OutputListResponseJoin value) =&gt; {...},
    ///     (OutputListResponseEnrich value) =&gt; {...},
    ///     (OutputListResponseCollectionProcessing value) =&gt; {...},
    ///     (OutputListResponseSend value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<OutputListResponseTransform> transform,
        Action<OutputListResponseExtract> extract,
        Action<OutputListResponseRoute> route,
        Action<OutputListResponseClassify> classify,
        Action<OutputListResponseSplitCollection> splitCollection,
        Action<OutputListResponseSplitItem> splitItem,
        Action<ErrorEvent> errorEvent,
        Action<OutputListResponseJoin> join,
        Action<OutputListResponseEnrich> enrich,
        Action<OutputListResponseCollectionProcessing> collectionProcessing,
        Action<OutputListResponseSend> send
    )
    {
        switch (this.Value)
        {
            case OutputListResponseTransform value:
                transform(value);
                break;
            case OutputListResponseExtract value:
                extract(value);
                break;
            case OutputListResponseRoute value:
                route(value);
                break;
            case OutputListResponseClassify value:
                classify(value);
                break;
            case OutputListResponseSplitCollection value:
                splitCollection(value);
                break;
            case OutputListResponseSplitItem value:
                splitItem(value);
                break;
            case ErrorEvent value:
                errorEvent(value);
                break;
            case OutputListResponseJoin value:
                join(value);
                break;
            case OutputListResponseEnrich value:
                enrich(value);
                break;
            case OutputListResponseCollectionProcessing value:
                collectionProcessing(value);
                break;
            case OutputListResponseSend value:
                send(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of OutputListResponse"
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
    ///     (OutputListResponseTransform value) =&gt; {...},
    ///     (OutputListResponseExtract value) =&gt; {...},
    ///     (OutputListResponseRoute value) =&gt; {...},
    ///     (OutputListResponseClassify value) =&gt; {...},
    ///     (OutputListResponseSplitCollection value) =&gt; {...},
    ///     (OutputListResponseSplitItem value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...},
    ///     (OutputListResponseJoin value) =&gt; {...},
    ///     (OutputListResponseEnrich value) =&gt; {...},
    ///     (OutputListResponseCollectionProcessing value) =&gt; {...},
    ///     (OutputListResponseSend value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<OutputListResponseTransform, T> transform,
        Func<OutputListResponseExtract, T> extract,
        Func<OutputListResponseRoute, T> route,
        Func<OutputListResponseClassify, T> classify,
        Func<OutputListResponseSplitCollection, T> splitCollection,
        Func<OutputListResponseSplitItem, T> splitItem,
        Func<ErrorEvent, T> errorEvent,
        Func<OutputListResponseJoin, T> join,
        Func<OutputListResponseEnrich, T> enrich,
        Func<OutputListResponseCollectionProcessing, T> collectionProcessing,
        Func<OutputListResponseSend, T> send
    )
    {
        return this.Value switch
        {
            OutputListResponseTransform value => transform(value),
            OutputListResponseExtract value => extract(value),
            OutputListResponseRoute value => route(value),
            OutputListResponseClassify value => classify(value),
            OutputListResponseSplitCollection value => splitCollection(value),
            OutputListResponseSplitItem value => splitItem(value),
            ErrorEvent value => errorEvent(value),
            OutputListResponseJoin value => join(value),
            OutputListResponseEnrich value => enrich(value),
            OutputListResponseCollectionProcessing value => collectionProcessing(value),
            OutputListResponseSend value => send(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of OutputListResponse"
            ),
        };
    }

    public static implicit operator OutputListResponse(OutputListResponseTransform value) =>
        new(value);

    public static implicit operator OutputListResponse(OutputListResponseExtract value) =>
        new(value);

    public static implicit operator OutputListResponse(OutputListResponseRoute value) => new(value);

    public static implicit operator OutputListResponse(OutputListResponseClassify value) =>
        new(value);

    public static implicit operator OutputListResponse(OutputListResponseSplitCollection value) =>
        new(value);

    public static implicit operator OutputListResponse(OutputListResponseSplitItem value) =>
        new(value);

    public static implicit operator OutputListResponse(ErrorEvent value) => new(value);

    public static implicit operator OutputListResponse(OutputListResponseJoin value) => new(value);

    public static implicit operator OutputListResponse(OutputListResponseEnrich value) =>
        new(value);

    public static implicit operator OutputListResponse(
        OutputListResponseCollectionProcessing value
    ) => new(value);

    public static implicit operator OutputListResponse(OutputListResponseSend value) => new(value);

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
                "Data did not match any variant of OutputListResponse"
            );
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

    public virtual bool Equals(OutputListResponse? other) =>
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
            OutputListResponseTransform _ => 0,
            OutputListResponseExtract _ => 1,
            OutputListResponseRoute _ => 2,
            OutputListResponseClassify _ => 3,
            OutputListResponseSplitCollection _ => 4,
            OutputListResponseSplitItem _ => 5,
            ErrorEvent _ => 6,
            OutputListResponseJoin _ => 7,
            OutputListResponseEnrich _ => 8,
            OutputListResponseCollectionProcessing _ => 9,
            OutputListResponseSend _ => 10,
            _ => -1,
        };
    }
}

sealed class OutputListResponseConverter : JsonConverter<OutputListResponse>
{
    public override OutputListResponse? Read(
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
                    var deserialized = JsonSerializer.Deserialize<OutputListResponseTransform>(
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
            case "extract":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OutputListResponseExtract>(
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
            case "route":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OutputListResponseRoute>(
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
                    var deserialized = JsonSerializer.Deserialize<OutputListResponseClassify>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<OutputListResponseSplitCollection>(
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
                    var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitItem>(
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
            case "join":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OutputListResponseJoin>(
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
                    var deserialized = JsonSerializer.Deserialize<OutputListResponseEnrich>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<OutputListResponseCollectionProcessing>(
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
                    var deserialized = JsonSerializer.Deserialize<OutputListResponseSend>(
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
            default:
            {
                return new OutputListResponse(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<OutputListResponseTransform, OutputListResponseTransformFromRaw>)
)]
public sealed record class OutputListResponseTransform : JsonModel
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
    public OutputListResponseTransformCorrectedContent? CorrectedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseTransformCorrectedContent>(
                "correctedContent"
            );
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

    public ApiEnum<string, OutputListResponseTransformEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseTransformEventType>
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
    public IReadOnlyList<OutputListResponseTransformInput>? Inputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<OutputListResponseTransformInput>
            >("inputs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<OutputListResponseTransformInput>?>(
                "inputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The input type of the content you're sending for transformation.
    /// </summary>
    public ApiEnum<string, OutputListResponseTransformInputType>? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseTransformInputType>
            >("inputType");
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

    public OutputListResponseTransformMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseTransformMetadata>("metadata");
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
    public OutputListResponseTransformMetrics? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseTransformMetrics>("metrics");
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

    public OutputListResponseTransform() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseTransform(OutputListResponseTransform outputListResponseTransform)
        : base(outputListResponseTransform) { }
#pragma warning restore CS8618

    public OutputListResponseTransform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseTransform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseTransformFromRaw.FromRawUnchecked"/>
    public static OutputListResponseTransform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseTransformFromRaw : IFromRawJson<OutputListResponseTransform>
{
    /// <inheritdoc/>
    public OutputListResponseTransform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseTransform.FromRawUnchecked(rawData);
}

/// <summary>
/// Corrected feedback provided for fine-tuning purposes.
/// </summary>
[JsonConverter(typeof(OutputListResponseTransformCorrectedContentConverter))]
public record class OutputListResponseTransformCorrectedContent : ModelBase
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

    public OutputListResponseTransformCorrectedContent(
        OutputListResponseTransformCorrectedContentOutput value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponseTransformCorrectedContent(
        IReadOnlyList<JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public OutputListResponseTransformCorrectedContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponseTransformCorrectedContent(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponseTransformCorrectedContent(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponseTransformCorrectedContent(JsonElement element)
    {
        this._element = element;
        this.Value = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseTransformCorrectedContentOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOutputListResponseTransformCorrectedContentOutput(out var value)) {
    ///     // `value` is of type `OutputListResponseTransformCorrectedContentOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOutputListResponseTransformCorrectedContentOutput(
        [NotNullWhen(true)] out OutputListResponseTransformCorrectedContentOutput? value
    )
    {
        value = this.Value as OutputListResponseTransformCorrectedContentOutput;
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
    ///     (OutputListResponseTransformCorrectedContentOutput value) =&gt; {...},
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
        Action<OutputListResponseTransformCorrectedContentOutput> outputListResponseTransformCorrectedContentOutput,
        Action<JsonElement> jsonElement,
        Action<IReadOnlyList<JsonElement>> jsonElements,
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case OutputListResponseTransformCorrectedContentOutput value:
                outputListResponseTransformCorrectedContentOutput(value);
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
                    "Data did not match any variant of OutputListResponseTransformCorrectedContent"
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
    ///     (OutputListResponseTransformCorrectedContentOutput value) =&gt; {...},
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
        Func<
            OutputListResponseTransformCorrectedContentOutput,
            T
        > outputListResponseTransformCorrectedContentOutput,
        Func<JsonElement, T> jsonElement,
        Func<IReadOnlyList<JsonElement>, T> jsonElements,
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            OutputListResponseTransformCorrectedContentOutput value =>
                outputListResponseTransformCorrectedContentOutput(value),
            JsonElement value => jsonElement(value),
            IReadOnlyList<JsonElement> value => jsonElements(value),
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of OutputListResponseTransformCorrectedContent"
            ),
        };
    }

    public static implicit operator OutputListResponseTransformCorrectedContent(
        OutputListResponseTransformCorrectedContentOutput value
    ) => new(value);

    public static implicit operator OutputListResponseTransformCorrectedContent(
        JsonElement value
    ) => new(value);

    public static implicit operator OutputListResponseTransformCorrectedContent(
        List<JsonElement> value
    ) => new((IReadOnlyList<JsonElement>)value);

    public static implicit operator OutputListResponseTransformCorrectedContent(string value) =>
        new(value);

    public static implicit operator OutputListResponseTransformCorrectedContent(double value) =>
        new(value);

    public static implicit operator OutputListResponseTransformCorrectedContent(bool value) =>
        new(value);

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
                "Data did not match any variant of OutputListResponseTransformCorrectedContent"
            );
        }
        this.Switch(
            (outputListResponseTransformCorrectedContentOutput) =>
                outputListResponseTransformCorrectedContentOutput.Validate(),
            (_) => { },
            (_) => { },
            (_) => { },
            (_) => { },
            (_) => { }
        );
    }

    public virtual bool Equals(OutputListResponseTransformCorrectedContent? other) =>
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
            OutputListResponseTransformCorrectedContentOutput _ => 0,
            JsonElement _ => 1,
            IReadOnlyList<JsonElement> _ => 2,
            string _ => 3,
            double _ => 4,
            bool _ => 5,
            _ => -1,
        };
    }
}

sealed class OutputListResponseTransformCorrectedContentConverter
    : JsonConverter<OutputListResponseTransformCorrectedContent?>
{
    public override OutputListResponseTransformCorrectedContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContentOutput>(
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
        OutputListResponseTransformCorrectedContent? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseTransformCorrectedContentOutput,
        OutputListResponseTransformCorrectedContentOutputFromRaw
    >)
)]
public sealed record class OutputListResponseTransformCorrectedContentOutput : JsonModel
{
    public IReadOnlyList<AnyType?>? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AnyType?>>("output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AnyType?>?>(
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

    public OutputListResponseTransformCorrectedContentOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseTransformCorrectedContentOutput(
        OutputListResponseTransformCorrectedContentOutput outputListResponseTransformCorrectedContentOutput
    )
        : base(outputListResponseTransformCorrectedContentOutput) { }
#pragma warning restore CS8618

    public OutputListResponseTransformCorrectedContentOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseTransformCorrectedContentOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseTransformCorrectedContentOutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseTransformCorrectedContentOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseTransformCorrectedContentOutputFromRaw
    : IFromRawJson<OutputListResponseTransformCorrectedContentOutput>
{
    /// <inheritdoc/>
    public OutputListResponseTransformCorrectedContentOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseTransformCorrectedContentOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputListResponseTransformEventTypeConverter))]
public enum OutputListResponseTransformEventType
{
    Transform,
}

sealed class OutputListResponseTransformEventTypeConverter
    : JsonConverter<OutputListResponseTransformEventType>
{
    public override OutputListResponseTransformEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transform" => OutputListResponseTransformEventType.Transform,
            _ => (OutputListResponseTransformEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseTransformEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseTransformEventType.Transform => "transform",
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
        OutputListResponseTransformInput,
        OutputListResponseTransformInputFromRaw
    >)
)]
public sealed record class OutputListResponseTransformInput : JsonModel
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

    public OutputListResponseTransformInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseTransformInput(
        OutputListResponseTransformInput outputListResponseTransformInput
    )
        : base(outputListResponseTransformInput) { }
#pragma warning restore CS8618

    public OutputListResponseTransformInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseTransformInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseTransformInputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseTransformInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseTransformInputFromRaw : IFromRawJson<OutputListResponseTransformInput>
{
    /// <inheritdoc/>
    public OutputListResponseTransformInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseTransformInput.FromRawUnchecked(rawData);
}

/// <summary>
/// The input type of the content you're sending for transformation.
/// </summary>
[JsonConverter(typeof(OutputListResponseTransformInputTypeConverter))]
public enum OutputListResponseTransformInputType
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

sealed class OutputListResponseTransformInputTypeConverter
    : JsonConverter<OutputListResponseTransformInputType>
{
    public override OutputListResponseTransformInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => OutputListResponseTransformInputType.Csv,
            "docx" => OutputListResponseTransformInputType.Docx,
            "email" => OutputListResponseTransformInputType.Email,
            "heic" => OutputListResponseTransformInputType.Heic,
            "html" => OutputListResponseTransformInputType.Html,
            "jpeg" => OutputListResponseTransformInputType.Jpeg,
            "json" => OutputListResponseTransformInputType.Json,
            "heif" => OutputListResponseTransformInputType.Heif,
            "m4a" => OutputListResponseTransformInputType.M4a,
            "mp3" => OutputListResponseTransformInputType.Mp3,
            "pdf" => OutputListResponseTransformInputType.Pdf,
            "png" => OutputListResponseTransformInputType.Png,
            "text" => OutputListResponseTransformInputType.Text,
            "wav" => OutputListResponseTransformInputType.Wav,
            "webp" => OutputListResponseTransformInputType.Webp,
            "xls" => OutputListResponseTransformInputType.Xls,
            "xlsx" => OutputListResponseTransformInputType.Xlsx,
            "xml" => OutputListResponseTransformInputType.Xml,
            _ => (OutputListResponseTransformInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseTransformInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseTransformInputType.Csv => "csv",
                OutputListResponseTransformInputType.Docx => "docx",
                OutputListResponseTransformInputType.Email => "email",
                OutputListResponseTransformInputType.Heic => "heic",
                OutputListResponseTransformInputType.Html => "html",
                OutputListResponseTransformInputType.Jpeg => "jpeg",
                OutputListResponseTransformInputType.Json => "json",
                OutputListResponseTransformInputType.Heif => "heif",
                OutputListResponseTransformInputType.M4a => "m4a",
                OutputListResponseTransformInputType.Mp3 => "mp3",
                OutputListResponseTransformInputType.Pdf => "pdf",
                OutputListResponseTransformInputType.Png => "png",
                OutputListResponseTransformInputType.Text => "text",
                OutputListResponseTransformInputType.Wav => "wav",
                OutputListResponseTransformInputType.Webp => "webp",
                OutputListResponseTransformInputType.Xls => "xls",
                OutputListResponseTransformInputType.Xlsx => "xlsx",
                OutputListResponseTransformInputType.Xml => "xml",
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
        OutputListResponseTransformMetadata,
        OutputListResponseTransformMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseTransformMetadata : JsonModel
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

    public OutputListResponseTransformMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseTransformMetadata(
        OutputListResponseTransformMetadata outputListResponseTransformMetadata
    )
        : base(outputListResponseTransformMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseTransformMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseTransformMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseTransformMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseTransformMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseTransformMetadataFromRaw : IFromRawJson<OutputListResponseTransformMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseTransformMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseTransformMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Accuracy, precision, recall, and F1 score when corrected JSON is provided.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseTransformMetrics,
        OutputListResponseTransformMetricsFromRaw
    >)
)]
public sealed record class OutputListResponseTransformMetrics : JsonModel
{
    public IReadOnlyList<OutputListResponseTransformMetricsDifference>? Differences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<OutputListResponseTransformMetricsDifference>
            >("differences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OutputListResponseTransformMetricsDifference>?>(
                "differences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public OutputListResponseTransformMetricsMetrics? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseTransformMetricsMetrics>(
                "metrics"
            );
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
        this.Metrics?.Validate();
    }

    public OutputListResponseTransformMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseTransformMetrics(
        OutputListResponseTransformMetrics outputListResponseTransformMetrics
    )
        : base(outputListResponseTransformMetrics) { }
#pragma warning restore CS8618

    public OutputListResponseTransformMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseTransformMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseTransformMetricsFromRaw.FromRawUnchecked"/>
    public static OutputListResponseTransformMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseTransformMetricsFromRaw : IFromRawJson<OutputListResponseTransformMetrics>
{
    /// <inheritdoc/>
    public OutputListResponseTransformMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseTransformMetrics.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseTransformMetricsDifference,
        OutputListResponseTransformMetricsDifferenceFromRaw
    >)
)]
public sealed record class OutputListResponseTransformMetricsDifference : JsonModel
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

    public OutputListResponseTransformMetricsDifference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseTransformMetricsDifference(
        OutputListResponseTransformMetricsDifference outputListResponseTransformMetricsDifference
    )
        : base(outputListResponseTransformMetricsDifference) { }
#pragma warning restore CS8618

    public OutputListResponseTransformMetricsDifference(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseTransformMetricsDifference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseTransformMetricsDifferenceFromRaw.FromRawUnchecked"/>
    public static OutputListResponseTransformMetricsDifference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseTransformMetricsDifferenceFromRaw
    : IFromRawJson<OutputListResponseTransformMetricsDifference>
{
    /// <inheritdoc/>
    public OutputListResponseTransformMetricsDifference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseTransformMetricsDifference.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseTransformMetricsMetrics,
        OutputListResponseTransformMetricsMetricsFromRaw
    >)
)]
public sealed record class OutputListResponseTransformMetricsMetrics : JsonModel
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

    public OutputListResponseTransformMetricsMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseTransformMetricsMetrics(
        OutputListResponseTransformMetricsMetrics outputListResponseTransformMetricsMetrics
    )
        : base(outputListResponseTransformMetricsMetrics) { }
#pragma warning restore CS8618

    public OutputListResponseTransformMetricsMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseTransformMetricsMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseTransformMetricsMetricsFromRaw.FromRawUnchecked"/>
    public static OutputListResponseTransformMetricsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseTransformMetricsMetricsFromRaw
    : IFromRawJson<OutputListResponseTransformMetricsMetrics>
{
    /// <inheritdoc/>
    public OutputListResponseTransformMetricsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseTransformMetricsMetrics.FromRawUnchecked(rawData);
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
[JsonConverter(
    typeof(JsonModelConverter<OutputListResponseExtract, OutputListResponseExtractFromRaw>)
)]
public sealed record class OutputListResponseExtract : JsonModel
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
    public OutputListResponseExtractCorrectedContent? CorrectedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseExtractCorrectedContent>(
                "correctedContent"
            );
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

    public ApiEnum<string, OutputListResponseExtractEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseExtractEventType>
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
    public IReadOnlyList<OutputListResponseExtractInput>? Inputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OutputListResponseExtractInput>>(
                "inputs"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<OutputListResponseExtractInput>?>(
                "inputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The input type of the content you're sending for transformation.
    /// </summary>
    public ApiEnum<string, OutputListResponseExtractInputType>? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseExtractInputType>
            >("inputType");
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

    public OutputListResponseExtractMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseExtractMetadata>("metadata");
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

    public OutputListResponseExtract() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseExtract(OutputListResponseExtract outputListResponseExtract)
        : base(outputListResponseExtract) { }
#pragma warning restore CS8618

    public OutputListResponseExtract(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseExtract(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseExtractFromRaw.FromRawUnchecked"/>
    public static OutputListResponseExtract FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseExtractFromRaw : IFromRawJson<OutputListResponseExtract>
{
    /// <inheritdoc/>
    public OutputListResponseExtract FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseExtract.FromRawUnchecked(rawData);
}

/// <summary>
/// Corrected feedback provided for fine-tuning purposes.
/// </summary>
[JsonConverter(typeof(OutputListResponseExtractCorrectedContentConverter))]
public record class OutputListResponseExtractCorrectedContent : ModelBase
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

    public OutputListResponseExtractCorrectedContent(
        OutputListResponseExtractCorrectedContentOutput value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponseExtractCorrectedContent(
        IReadOnlyList<JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public OutputListResponseExtractCorrectedContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponseExtractCorrectedContent(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponseExtractCorrectedContent(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OutputListResponseExtractCorrectedContent(JsonElement element)
    {
        this._element = element;
        this.Value = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OutputListResponseExtractCorrectedContentOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOutputListResponseExtractCorrectedContentOutput(out var value)) {
    ///     // `value` is of type `OutputListResponseExtractCorrectedContentOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOutputListResponseExtractCorrectedContentOutput(
        [NotNullWhen(true)] out OutputListResponseExtractCorrectedContentOutput? value
    )
    {
        value = this.Value as OutputListResponseExtractCorrectedContentOutput;
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
    ///     (OutputListResponseExtractCorrectedContentOutput value) =&gt; {...},
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
        Action<OutputListResponseExtractCorrectedContentOutput> outputListResponseExtractCorrectedContentOutput,
        Action<JsonElement> jsonElement,
        Action<IReadOnlyList<JsonElement>> jsonElements,
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case OutputListResponseExtractCorrectedContentOutput value:
                outputListResponseExtractCorrectedContentOutput(value);
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
                    "Data did not match any variant of OutputListResponseExtractCorrectedContent"
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
    ///     (OutputListResponseExtractCorrectedContentOutput value) =&gt; {...},
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
        Func<
            OutputListResponseExtractCorrectedContentOutput,
            T
        > outputListResponseExtractCorrectedContentOutput,
        Func<JsonElement, T> jsonElement,
        Func<IReadOnlyList<JsonElement>, T> jsonElements,
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            OutputListResponseExtractCorrectedContentOutput value =>
                outputListResponseExtractCorrectedContentOutput(value),
            JsonElement value => jsonElement(value),
            IReadOnlyList<JsonElement> value => jsonElements(value),
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of OutputListResponseExtractCorrectedContent"
            ),
        };
    }

    public static implicit operator OutputListResponseExtractCorrectedContent(
        OutputListResponseExtractCorrectedContentOutput value
    ) => new(value);

    public static implicit operator OutputListResponseExtractCorrectedContent(JsonElement value) =>
        new(value);

    public static implicit operator OutputListResponseExtractCorrectedContent(
        List<JsonElement> value
    ) => new((IReadOnlyList<JsonElement>)value);

    public static implicit operator OutputListResponseExtractCorrectedContent(string value) =>
        new(value);

    public static implicit operator OutputListResponseExtractCorrectedContent(double value) =>
        new(value);

    public static implicit operator OutputListResponseExtractCorrectedContent(bool value) =>
        new(value);

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
                "Data did not match any variant of OutputListResponseExtractCorrectedContent"
            );
        }
        this.Switch(
            (outputListResponseExtractCorrectedContentOutput) =>
                outputListResponseExtractCorrectedContentOutput.Validate(),
            (_) => { },
            (_) => { },
            (_) => { },
            (_) => { },
            (_) => { }
        );
    }

    public virtual bool Equals(OutputListResponseExtractCorrectedContent? other) =>
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
            OutputListResponseExtractCorrectedContentOutput _ => 0,
            JsonElement _ => 1,
            IReadOnlyList<JsonElement> _ => 2,
            string _ => 3,
            double _ => 4,
            bool _ => 5,
            _ => -1,
        };
    }
}

sealed class OutputListResponseExtractCorrectedContentConverter
    : JsonConverter<OutputListResponseExtractCorrectedContent?>
{
    public override OutputListResponseExtractCorrectedContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContentOutput>(
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
        OutputListResponseExtractCorrectedContent? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseExtractCorrectedContentOutput,
        OutputListResponseExtractCorrectedContentOutputFromRaw
    >)
)]
public sealed record class OutputListResponseExtractCorrectedContentOutput : JsonModel
{
    public IReadOnlyList<AnyType?>? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AnyType?>>("output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AnyType?>?>(
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

    public OutputListResponseExtractCorrectedContentOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseExtractCorrectedContentOutput(
        OutputListResponseExtractCorrectedContentOutput outputListResponseExtractCorrectedContentOutput
    )
        : base(outputListResponseExtractCorrectedContentOutput) { }
#pragma warning restore CS8618

    public OutputListResponseExtractCorrectedContentOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseExtractCorrectedContentOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseExtractCorrectedContentOutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseExtractCorrectedContentOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseExtractCorrectedContentOutputFromRaw
    : IFromRawJson<OutputListResponseExtractCorrectedContentOutput>
{
    /// <inheritdoc/>
    public OutputListResponseExtractCorrectedContentOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseExtractCorrectedContentOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputListResponseExtractEventTypeConverter))]
public enum OutputListResponseExtractEventType
{
    Extract,
}

sealed class OutputListResponseExtractEventTypeConverter
    : JsonConverter<OutputListResponseExtractEventType>
{
    public override OutputListResponseExtractEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "extract" => OutputListResponseExtractEventType.Extract,
            _ => (OutputListResponseExtractEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseExtractEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseExtractEventType.Extract => "extract",
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
        OutputListResponseExtractInput,
        OutputListResponseExtractInputFromRaw
    >)
)]
public sealed record class OutputListResponseExtractInput : JsonModel
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

    public OutputListResponseExtractInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseExtractInput(
        OutputListResponseExtractInput outputListResponseExtractInput
    )
        : base(outputListResponseExtractInput) { }
#pragma warning restore CS8618

    public OutputListResponseExtractInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseExtractInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseExtractInputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseExtractInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseExtractInputFromRaw : IFromRawJson<OutputListResponseExtractInput>
{
    /// <inheritdoc/>
    public OutputListResponseExtractInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseExtractInput.FromRawUnchecked(rawData);
}

/// <summary>
/// The input type of the content you're sending for transformation.
/// </summary>
[JsonConverter(typeof(OutputListResponseExtractInputTypeConverter))]
public enum OutputListResponseExtractInputType
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

sealed class OutputListResponseExtractInputTypeConverter
    : JsonConverter<OutputListResponseExtractInputType>
{
    public override OutputListResponseExtractInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => OutputListResponseExtractInputType.Csv,
            "docx" => OutputListResponseExtractInputType.Docx,
            "email" => OutputListResponseExtractInputType.Email,
            "heic" => OutputListResponseExtractInputType.Heic,
            "html" => OutputListResponseExtractInputType.Html,
            "jpeg" => OutputListResponseExtractInputType.Jpeg,
            "json" => OutputListResponseExtractInputType.Json,
            "heif" => OutputListResponseExtractInputType.Heif,
            "m4a" => OutputListResponseExtractInputType.M4a,
            "mp3" => OutputListResponseExtractInputType.Mp3,
            "pdf" => OutputListResponseExtractInputType.Pdf,
            "png" => OutputListResponseExtractInputType.Png,
            "text" => OutputListResponseExtractInputType.Text,
            "wav" => OutputListResponseExtractInputType.Wav,
            "webp" => OutputListResponseExtractInputType.Webp,
            "xls" => OutputListResponseExtractInputType.Xls,
            "xlsx" => OutputListResponseExtractInputType.Xlsx,
            "xml" => OutputListResponseExtractInputType.Xml,
            _ => (OutputListResponseExtractInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseExtractInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseExtractInputType.Csv => "csv",
                OutputListResponseExtractInputType.Docx => "docx",
                OutputListResponseExtractInputType.Email => "email",
                OutputListResponseExtractInputType.Heic => "heic",
                OutputListResponseExtractInputType.Html => "html",
                OutputListResponseExtractInputType.Jpeg => "jpeg",
                OutputListResponseExtractInputType.Json => "json",
                OutputListResponseExtractInputType.Heif => "heif",
                OutputListResponseExtractInputType.M4a => "m4a",
                OutputListResponseExtractInputType.Mp3 => "mp3",
                OutputListResponseExtractInputType.Pdf => "pdf",
                OutputListResponseExtractInputType.Png => "png",
                OutputListResponseExtractInputType.Text => "text",
                OutputListResponseExtractInputType.Wav => "wav",
                OutputListResponseExtractInputType.Webp => "webp",
                OutputListResponseExtractInputType.Xls => "xls",
                OutputListResponseExtractInputType.Xlsx => "xlsx",
                OutputListResponseExtractInputType.Xml => "xml",
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
        OutputListResponseExtractMetadata,
        OutputListResponseExtractMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseExtractMetadata : JsonModel
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

    public OutputListResponseExtractMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseExtractMetadata(
        OutputListResponseExtractMetadata outputListResponseExtractMetadata
    )
        : base(outputListResponseExtractMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseExtractMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseExtractMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseExtractMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseExtractMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseExtractMetadataFromRaw : IFromRawJson<OutputListResponseExtractMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseExtractMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseExtractMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OutputListResponseRoute, OutputListResponseRouteFromRaw>))]
public sealed record class OutputListResponseRoute : JsonModel
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

    public ApiEnum<string, OutputListResponseRouteEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseRouteEventType>
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

    public OutputListResponseRouteMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseRouteMetadata>("metadata");
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

    public OutputListResponseRoute() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseRoute(OutputListResponseRoute outputListResponseRoute)
        : base(outputListResponseRoute) { }
#pragma warning restore CS8618

    public OutputListResponseRoute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseRoute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseRouteFromRaw.FromRawUnchecked"/>
    public static OutputListResponseRoute FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseRouteFromRaw : IFromRawJson<OutputListResponseRoute>
{
    /// <inheritdoc/>
    public OutputListResponseRoute FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseRoute.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputListResponseRouteEventTypeConverter))]
public enum OutputListResponseRouteEventType
{
    Route,
}

sealed class OutputListResponseRouteEventTypeConverter
    : JsonConverter<OutputListResponseRouteEventType>
{
    public override OutputListResponseRouteEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "route" => OutputListResponseRouteEventType.Route,
            _ => (OutputListResponseRouteEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseRouteEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseRouteEventType.Route => "route",
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
        OutputListResponseRouteMetadata,
        OutputListResponseRouteMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseRouteMetadata : JsonModel
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

    public OutputListResponseRouteMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseRouteMetadata(
        OutputListResponseRouteMetadata outputListResponseRouteMetadata
    )
        : base(outputListResponseRouteMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseRouteMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseRouteMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseRouteMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseRouteMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseRouteMetadataFromRaw : IFromRawJson<OutputListResponseRouteMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseRouteMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseRouteMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<OutputListResponseClassify, OutputListResponseClassifyFromRaw>)
)]
public sealed record class OutputListResponseClassify : JsonModel
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

    public ApiEnum<string, OutputListResponseClassifyEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseClassifyEventType>
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

    public OutputListResponseClassifyMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseClassifyMetadata>("metadata");
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

    public OutputListResponseClassify() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseClassify(OutputListResponseClassify outputListResponseClassify)
        : base(outputListResponseClassify) { }
#pragma warning restore CS8618

    public OutputListResponseClassify(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseClassify(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseClassifyFromRaw.FromRawUnchecked"/>
    public static OutputListResponseClassify FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseClassifyFromRaw : IFromRawJson<OutputListResponseClassify>
{
    /// <inheritdoc/>
    public OutputListResponseClassify FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseClassify.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputListResponseClassifyEventTypeConverter))]
public enum OutputListResponseClassifyEventType
{
    Classify,
}

sealed class OutputListResponseClassifyEventTypeConverter
    : JsonConverter<OutputListResponseClassifyEventType>
{
    public override OutputListResponseClassifyEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "classify" => OutputListResponseClassifyEventType.Classify,
            _ => (OutputListResponseClassifyEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseClassifyEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseClassifyEventType.Classify => "classify",
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
        OutputListResponseClassifyMetadata,
        OutputListResponseClassifyMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseClassifyMetadata : JsonModel
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

    public OutputListResponseClassifyMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseClassifyMetadata(
        OutputListResponseClassifyMetadata outputListResponseClassifyMetadata
    )
        : base(outputListResponseClassifyMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseClassifyMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseClassifyMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseClassifyMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseClassifyMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseClassifyMetadataFromRaw : IFromRawJson<OutputListResponseClassifyMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseClassifyMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseClassifyMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSplitCollection,
        OutputListResponseSplitCollectionFromRaw
    >)
)]
public sealed record class OutputListResponseSplitCollection : JsonModel
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

    public required ApiEnum<string, OutputListResponseSplitCollectionOutputType> OutputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, OutputListResponseSplitCollectionOutputType>
            >("outputType");
        }
        init { this._rawData.Set("outputType", value); }
    }

    public required OutputListResponseSplitCollectionPrintPageOutput PrintPageOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OutputListResponseSplitCollectionPrintPageOutput>(
                "printPageOutput"
            );
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

    public required OutputListResponseSplitCollectionSemanticPageOutput SemanticPageOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OutputListResponseSplitCollectionSemanticPageOutput>(
                "semanticPageOutput"
            );
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

    public ApiEnum<string, OutputListResponseSplitCollectionEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseSplitCollectionEventType>
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

    public OutputListResponseSplitCollectionMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseSplitCollectionMetadata>(
                "metadata"
            );
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

    public OutputListResponseSplitCollection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitCollection(
        OutputListResponseSplitCollection outputListResponseSplitCollection
    )
        : base(outputListResponseSplitCollection) { }
#pragma warning restore CS8618

    public OutputListResponseSplitCollection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitCollection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitCollectionFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitCollectionFromRaw : IFromRawJson<OutputListResponseSplitCollection>
{
    /// <inheritdoc/>
    public OutputListResponseSplitCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitCollection.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputListResponseSplitCollectionOutputTypeConverter))]
public enum OutputListResponseSplitCollectionOutputType
{
    PrintPage,
    SemanticPage,
}

sealed class OutputListResponseSplitCollectionOutputTypeConverter
    : JsonConverter<OutputListResponseSplitCollectionOutputType>
{
    public override OutputListResponseSplitCollectionOutputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => OutputListResponseSplitCollectionOutputType.PrintPage,
            "semantic_page" => OutputListResponseSplitCollectionOutputType.SemanticPage,
            _ => (OutputListResponseSplitCollectionOutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseSplitCollectionOutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseSplitCollectionOutputType.PrintPage => "print_page",
                OutputListResponseSplitCollectionOutputType.SemanticPage => "semantic_page",
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
        OutputListResponseSplitCollectionPrintPageOutput,
        OutputListResponseSplitCollectionPrintPageOutputFromRaw
    >)
)]
public sealed record class OutputListResponseSplitCollectionPrintPageOutput : JsonModel
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

    public IReadOnlyList<OutputListResponseSplitCollectionPrintPageOutputItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<OutputListResponseSplitCollectionPrintPageOutputItem>
            >("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OutputListResponseSplitCollectionPrintPageOutputItem>?>(
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

    public OutputListResponseSplitCollectionPrintPageOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitCollectionPrintPageOutput(
        OutputListResponseSplitCollectionPrintPageOutput outputListResponseSplitCollectionPrintPageOutput
    )
        : base(outputListResponseSplitCollectionPrintPageOutput) { }
#pragma warning restore CS8618

    public OutputListResponseSplitCollectionPrintPageOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitCollectionPrintPageOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitCollectionPrintPageOutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitCollectionPrintPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitCollectionPrintPageOutputFromRaw
    : IFromRawJson<OutputListResponseSplitCollectionPrintPageOutput>
{
    /// <inheritdoc/>
    public OutputListResponseSplitCollectionPrintPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitCollectionPrintPageOutput.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSplitCollectionPrintPageOutputItem,
        OutputListResponseSplitCollectionPrintPageOutputItemFromRaw
    >)
)]
public sealed record class OutputListResponseSplitCollectionPrintPageOutputItem : JsonModel
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

    public OutputListResponseSplitCollectionPrintPageOutputItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitCollectionPrintPageOutputItem(
        OutputListResponseSplitCollectionPrintPageOutputItem outputListResponseSplitCollectionPrintPageOutputItem
    )
        : base(outputListResponseSplitCollectionPrintPageOutputItem) { }
#pragma warning restore CS8618

    public OutputListResponseSplitCollectionPrintPageOutputItem(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitCollectionPrintPageOutputItem(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitCollectionPrintPageOutputItemFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitCollectionPrintPageOutputItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitCollectionPrintPageOutputItemFromRaw
    : IFromRawJson<OutputListResponseSplitCollectionPrintPageOutputItem>
{
    /// <inheritdoc/>
    public OutputListResponseSplitCollectionPrintPageOutputItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitCollectionPrintPageOutputItem.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSplitCollectionSemanticPageOutput,
        OutputListResponseSplitCollectionSemanticPageOutputFromRaw
    >)
)]
public sealed record class OutputListResponseSplitCollectionSemanticPageOutput : JsonModel
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

    public IReadOnlyList<OutputListResponseSplitCollectionSemanticPageOutputItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<OutputListResponseSplitCollectionSemanticPageOutputItem>
            >("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OutputListResponseSplitCollectionSemanticPageOutputItem>?>(
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

    public OutputListResponseSplitCollectionSemanticPageOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitCollectionSemanticPageOutput(
        OutputListResponseSplitCollectionSemanticPageOutput outputListResponseSplitCollectionSemanticPageOutput
    )
        : base(outputListResponseSplitCollectionSemanticPageOutput) { }
#pragma warning restore CS8618

    public OutputListResponseSplitCollectionSemanticPageOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitCollectionSemanticPageOutput(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitCollectionSemanticPageOutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitCollectionSemanticPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitCollectionSemanticPageOutputFromRaw
    : IFromRawJson<OutputListResponseSplitCollectionSemanticPageOutput>
{
    /// <inheritdoc/>
    public OutputListResponseSplitCollectionSemanticPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitCollectionSemanticPageOutput.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSplitCollectionSemanticPageOutputItem,
        OutputListResponseSplitCollectionSemanticPageOutputItemFromRaw
    >)
)]
public sealed record class OutputListResponseSplitCollectionSemanticPageOutputItem : JsonModel
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

    public OutputListResponseSplitCollectionSemanticPageOutputItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitCollectionSemanticPageOutputItem(
        OutputListResponseSplitCollectionSemanticPageOutputItem outputListResponseSplitCollectionSemanticPageOutputItem
    )
        : base(outputListResponseSplitCollectionSemanticPageOutputItem) { }
#pragma warning restore CS8618

    public OutputListResponseSplitCollectionSemanticPageOutputItem(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitCollectionSemanticPageOutputItem(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitCollectionSemanticPageOutputItemFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitCollectionSemanticPageOutputItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitCollectionSemanticPageOutputItemFromRaw
    : IFromRawJson<OutputListResponseSplitCollectionSemanticPageOutputItem>
{
    /// <inheritdoc/>
    public OutputListResponseSplitCollectionSemanticPageOutputItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitCollectionSemanticPageOutputItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputListResponseSplitCollectionEventTypeConverter))]
public enum OutputListResponseSplitCollectionEventType
{
    SplitCollection,
}

sealed class OutputListResponseSplitCollectionEventTypeConverter
    : JsonConverter<OutputListResponseSplitCollectionEventType>
{
    public override OutputListResponseSplitCollectionEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "split_collection" => OutputListResponseSplitCollectionEventType.SplitCollection,
            _ => (OutputListResponseSplitCollectionEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseSplitCollectionEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseSplitCollectionEventType.SplitCollection => "split_collection",
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
        OutputListResponseSplitCollectionMetadata,
        OutputListResponseSplitCollectionMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseSplitCollectionMetadata : JsonModel
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

    public OutputListResponseSplitCollectionMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitCollectionMetadata(
        OutputListResponseSplitCollectionMetadata outputListResponseSplitCollectionMetadata
    )
        : base(outputListResponseSplitCollectionMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseSplitCollectionMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitCollectionMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitCollectionMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitCollectionMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitCollectionMetadataFromRaw
    : IFromRawJson<OutputListResponseSplitCollectionMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseSplitCollectionMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitCollectionMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<OutputListResponseSplitItem, OutputListResponseSplitItemFromRaw>)
)]
public sealed record class OutputListResponseSplitItem : JsonModel
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

    public required ApiEnum<string, OutputListResponseSplitItemOutputType> OutputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, OutputListResponseSplitItemOutputType>
            >("outputType");
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

    public ApiEnum<string, OutputListResponseSplitItemEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseSplitItemEventType>
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

    public OutputListResponseSplitItemMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseSplitItemMetadata>("metadata");
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

    public OutputListResponseSplitItemPrintPageOutput? PrintPageOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseSplitItemPrintPageOutput>(
                "printPageOutput"
            );
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

    public OutputListResponseSplitItemSemanticPageOutput? SemanticPageOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseSplitItemSemanticPageOutput>(
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

    public OutputListResponseSplitItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitItem(OutputListResponseSplitItem outputListResponseSplitItem)
        : base(outputListResponseSplitItem) { }
#pragma warning restore CS8618

    public OutputListResponseSplitItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitItemFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitItemFromRaw : IFromRawJson<OutputListResponseSplitItem>
{
    /// <inheritdoc/>
    public OutputListResponseSplitItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputListResponseSplitItemOutputTypeConverter))]
public enum OutputListResponseSplitItemOutputType
{
    PrintPage,
    SemanticPage,
}

sealed class OutputListResponseSplitItemOutputTypeConverter
    : JsonConverter<OutputListResponseSplitItemOutputType>
{
    public override OutputListResponseSplitItemOutputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => OutputListResponseSplitItemOutputType.PrintPage,
            "semantic_page" => OutputListResponseSplitItemOutputType.SemanticPage,
            _ => (OutputListResponseSplitItemOutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseSplitItemOutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseSplitItemOutputType.PrintPage => "print_page",
                OutputListResponseSplitItemOutputType.SemanticPage => "semantic_page",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(OutputListResponseSplitItemEventTypeConverter))]
public enum OutputListResponseSplitItemEventType
{
    SplitItem,
}

sealed class OutputListResponseSplitItemEventTypeConverter
    : JsonConverter<OutputListResponseSplitItemEventType>
{
    public override OutputListResponseSplitItemEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "split_item" => OutputListResponseSplitItemEventType.SplitItem,
            _ => (OutputListResponseSplitItemEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseSplitItemEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseSplitItemEventType.SplitItem => "split_item",
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
        OutputListResponseSplitItemMetadata,
        OutputListResponseSplitItemMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseSplitItemMetadata : JsonModel
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

    public OutputListResponseSplitItemMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitItemMetadata(
        OutputListResponseSplitItemMetadata outputListResponseSplitItemMetadata
    )
        : base(outputListResponseSplitItemMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseSplitItemMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitItemMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitItemMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitItemMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitItemMetadataFromRaw : IFromRawJson<OutputListResponseSplitItemMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseSplitItemMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitItemMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSplitItemPrintPageOutput,
        OutputListResponseSplitItemPrintPageOutputFromRaw
    >)
)]
public sealed record class OutputListResponseSplitItemPrintPageOutput : JsonModel
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

    public OutputListResponseSplitItemPrintPageOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitItemPrintPageOutput(
        OutputListResponseSplitItemPrintPageOutput outputListResponseSplitItemPrintPageOutput
    )
        : base(outputListResponseSplitItemPrintPageOutput) { }
#pragma warning restore CS8618

    public OutputListResponseSplitItemPrintPageOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitItemPrintPageOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitItemPrintPageOutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitItemPrintPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitItemPrintPageOutputFromRaw
    : IFromRawJson<OutputListResponseSplitItemPrintPageOutput>
{
    /// <inheritdoc/>
    public OutputListResponseSplitItemPrintPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitItemPrintPageOutput.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSplitItemSemanticPageOutput,
        OutputListResponseSplitItemSemanticPageOutputFromRaw
    >)
)]
public sealed record class OutputListResponseSplitItemSemanticPageOutput : JsonModel
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

    public OutputListResponseSplitItemSemanticPageOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSplitItemSemanticPageOutput(
        OutputListResponseSplitItemSemanticPageOutput outputListResponseSplitItemSemanticPageOutput
    )
        : base(outputListResponseSplitItemSemanticPageOutput) { }
#pragma warning restore CS8618

    public OutputListResponseSplitItemSemanticPageOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSplitItemSemanticPageOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSplitItemSemanticPageOutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSplitItemSemanticPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSplitItemSemanticPageOutputFromRaw
    : IFromRawJson<OutputListResponseSplitItemSemanticPageOutput>
{
    /// <inheritdoc/>
    public OutputListResponseSplitItemSemanticPageOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSplitItemSemanticPageOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OutputListResponseJoin, OutputListResponseJoinFromRaw>))]
public sealed record class OutputListResponseJoin : JsonModel
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
    public required IReadOnlyList<OutputListResponseJoinItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<OutputListResponseJoinItem>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<OutputListResponseJoinItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of join that was performed.
    /// </summary>
    public required ApiEnum<string, OutputListResponseJoinJoinType> JoinType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OutputListResponseJoinJoinType>>(
                "joinType"
            );
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

    public ApiEnum<string, OutputListResponseJoinEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutputListResponseJoinEventType>>(
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

    public OutputListResponseJoinMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseJoinMetadata>("metadata");
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

    public OutputListResponseJoin() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseJoin(OutputListResponseJoin outputListResponseJoin)
        : base(outputListResponseJoin) { }
#pragma warning restore CS8618

    public OutputListResponseJoin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseJoin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseJoinFromRaw.FromRawUnchecked"/>
    public static OutputListResponseJoin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseJoinFromRaw : IFromRawJson<OutputListResponseJoin>
{
    /// <inheritdoc/>
    public OutputListResponseJoin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseJoin.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<OutputListResponseJoinItem, OutputListResponseJoinItemFromRaw>)
)]
public sealed record class OutputListResponseJoinItem : JsonModel
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

    public OutputListResponseJoinItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseJoinItem(OutputListResponseJoinItem outputListResponseJoinItem)
        : base(outputListResponseJoinItem) { }
#pragma warning restore CS8618

    public OutputListResponseJoinItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseJoinItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseJoinItemFromRaw.FromRawUnchecked"/>
    public static OutputListResponseJoinItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseJoinItemFromRaw : IFromRawJson<OutputListResponseJoinItem>
{
    /// <inheritdoc/>
    public OutputListResponseJoinItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseJoinItem.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of join that was performed.
/// </summary>
[JsonConverter(typeof(OutputListResponseJoinJoinTypeConverter))]
public enum OutputListResponseJoinJoinType
{
    Standard,
}

sealed class OutputListResponseJoinJoinTypeConverter : JsonConverter<OutputListResponseJoinJoinType>
{
    public override OutputListResponseJoinJoinType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => OutputListResponseJoinJoinType.Standard,
            _ => (OutputListResponseJoinJoinType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseJoinJoinType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseJoinJoinType.Standard => "standard",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(OutputListResponseJoinEventTypeConverter))]
public enum OutputListResponseJoinEventType
{
    Join,
}

sealed class OutputListResponseJoinEventTypeConverter
    : JsonConverter<OutputListResponseJoinEventType>
{
    public override OutputListResponseJoinEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "join" => OutputListResponseJoinEventType.Join,
            _ => (OutputListResponseJoinEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseJoinEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseJoinEventType.Join => "join",
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
        OutputListResponseJoinMetadata,
        OutputListResponseJoinMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseJoinMetadata : JsonModel
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

    public OutputListResponseJoinMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseJoinMetadata(
        OutputListResponseJoinMetadata outputListResponseJoinMetadata
    )
        : base(outputListResponseJoinMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseJoinMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseJoinMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseJoinMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseJoinMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseJoinMetadataFromRaw : IFromRawJson<OutputListResponseJoinMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseJoinMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseJoinMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<OutputListResponseEnrich, OutputListResponseEnrichFromRaw>)
)]
public sealed record class OutputListResponseEnrich : JsonModel
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

    public ApiEnum<string, OutputListResponseEnrichEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseEnrichEventType>
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

    public OutputListResponseEnrichMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseEnrichMetadata>("metadata");
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

    public OutputListResponseEnrich() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseEnrich(OutputListResponseEnrich outputListResponseEnrich)
        : base(outputListResponseEnrich) { }
#pragma warning restore CS8618

    public OutputListResponseEnrich(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseEnrich(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseEnrichFromRaw.FromRawUnchecked"/>
    public static OutputListResponseEnrich FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseEnrichFromRaw : IFromRawJson<OutputListResponseEnrich>
{
    /// <inheritdoc/>
    public OutputListResponseEnrich FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseEnrich.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OutputListResponseEnrichEventTypeConverter))]
public enum OutputListResponseEnrichEventType
{
    Enrich,
}

sealed class OutputListResponseEnrichEventTypeConverter
    : JsonConverter<OutputListResponseEnrichEventType>
{
    public override OutputListResponseEnrichEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enrich" => OutputListResponseEnrichEventType.Enrich,
            _ => (OutputListResponseEnrichEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseEnrichEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseEnrichEventType.Enrich => "enrich",
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
        OutputListResponseEnrichMetadata,
        OutputListResponseEnrichMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseEnrichMetadata : JsonModel
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

    public OutputListResponseEnrichMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseEnrichMetadata(
        OutputListResponseEnrichMetadata outputListResponseEnrichMetadata
    )
        : base(outputListResponseEnrichMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseEnrichMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseEnrichMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseEnrichMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseEnrichMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseEnrichMetadataFromRaw : IFromRawJson<OutputListResponseEnrichMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseEnrichMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseEnrichMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseCollectionProcessing,
        OutputListResponseCollectionProcessingFromRaw
    >)
)]
public sealed record class OutputListResponseCollectionProcessing : JsonModel
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
    public required ApiEnum<string, OutputListResponseCollectionProcessingOperation> Operation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, OutputListResponseCollectionProcessingOperation>
            >("operation");
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
    public required ApiEnum<string, OutputListResponseCollectionProcessingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, OutputListResponseCollectionProcessingStatus>
            >("status");
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

    public ApiEnum<string, OutputListResponseCollectionProcessingEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OutputListResponseCollectionProcessingEventType>
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

    public OutputListResponseCollectionProcessingMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseCollectionProcessingMetadata>(
                "metadata"
            );
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

    public OutputListResponseCollectionProcessing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseCollectionProcessing(
        OutputListResponseCollectionProcessing outputListResponseCollectionProcessing
    )
        : base(outputListResponseCollectionProcessing) { }
#pragma warning restore CS8618

    public OutputListResponseCollectionProcessing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseCollectionProcessing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseCollectionProcessingFromRaw.FromRawUnchecked"/>
    public static OutputListResponseCollectionProcessing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseCollectionProcessingFromRaw
    : IFromRawJson<OutputListResponseCollectionProcessing>
{
    /// <inheritdoc/>
    public OutputListResponseCollectionProcessing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseCollectionProcessing.FromRawUnchecked(rawData);
}

/// <summary>
/// The operation performed (add or update).
/// </summary>
[JsonConverter(typeof(OutputListResponseCollectionProcessingOperationConverter))]
public enum OutputListResponseCollectionProcessingOperation
{
    Add,
    Update,
}

sealed class OutputListResponseCollectionProcessingOperationConverter
    : JsonConverter<OutputListResponseCollectionProcessingOperation>
{
    public override OutputListResponseCollectionProcessingOperation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "add" => OutputListResponseCollectionProcessingOperation.Add,
            "update" => OutputListResponseCollectionProcessingOperation.Update,
            _ => (OutputListResponseCollectionProcessingOperation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseCollectionProcessingOperation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseCollectionProcessingOperation.Add => "add",
                OutputListResponseCollectionProcessingOperation.Update => "update",
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
[JsonConverter(typeof(OutputListResponseCollectionProcessingStatusConverter))]
public enum OutputListResponseCollectionProcessingStatus
{
    Success,
    Failed,
}

sealed class OutputListResponseCollectionProcessingStatusConverter
    : JsonConverter<OutputListResponseCollectionProcessingStatus>
{
    public override OutputListResponseCollectionProcessingStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => OutputListResponseCollectionProcessingStatus.Success,
            "failed" => OutputListResponseCollectionProcessingStatus.Failed,
            _ => (OutputListResponseCollectionProcessingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseCollectionProcessingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseCollectionProcessingStatus.Success => "success",
                OutputListResponseCollectionProcessingStatus.Failed => "failed",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(OutputListResponseCollectionProcessingEventTypeConverter))]
public enum OutputListResponseCollectionProcessingEventType
{
    CollectionProcessing,
}

sealed class OutputListResponseCollectionProcessingEventTypeConverter
    : JsonConverter<OutputListResponseCollectionProcessingEventType>
{
    public override OutputListResponseCollectionProcessingEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "collection_processing" =>
                OutputListResponseCollectionProcessingEventType.CollectionProcessing,
            _ => (OutputListResponseCollectionProcessingEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseCollectionProcessingEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseCollectionProcessingEventType.CollectionProcessing =>
                    "collection_processing",
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
        OutputListResponseCollectionProcessingMetadata,
        OutputListResponseCollectionProcessingMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseCollectionProcessingMetadata : JsonModel
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

    public OutputListResponseCollectionProcessingMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseCollectionProcessingMetadata(
        OutputListResponseCollectionProcessingMetadata outputListResponseCollectionProcessingMetadata
    )
        : base(outputListResponseCollectionProcessingMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseCollectionProcessingMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseCollectionProcessingMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseCollectionProcessingMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseCollectionProcessingMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseCollectionProcessingMetadataFromRaw
    : IFromRawJson<OutputListResponseCollectionProcessingMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseCollectionProcessingMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseCollectionProcessingMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OutputListResponseSend, OutputListResponseSendFromRaw>))]
public sealed record class OutputListResponseSend : JsonModel
{
    /// <summary>
    /// Outcome of a Send function's delivery attempt.
    /// </summary>
    public required ApiEnum<string, OutputListResponseSendDeliveryStatus> DeliveryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, OutputListResponseSendDeliveryStatus>
            >("deliveryStatus");
        }
        init { this._rawData.Set("deliveryStatus", value); }
    }

    /// <summary>
    /// Destination type for a Send function.
    /// </summary>
    public required ApiEnum<string, OutputListResponseSendDestinationType> DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, OutputListResponseSendDestinationType>
            >("destinationType");
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

    public ApiEnum<string, OutputListResponseSendEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutputListResponseSendEventType>>(
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
    /// Metadata returned when a Send function delivers to Google Drive.
    /// </summary>
    public OutputListResponseSendGoogleDriveOutput? GoogleDriveOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseSendGoogleDriveOutput>(
                "googleDriveOutput"
            );
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

    public OutputListResponseSendMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseSendMetadata>("metadata");
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
    public OutputListResponseSendS3Output? S3Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseSendS3Output>("s3Output");
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
    public OutputListResponseSendWebhookOutput? WebhookOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutputListResponseSendWebhookOutput>(
                "webhookOutput"
            );
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

    public OutputListResponseSend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSend(OutputListResponseSend outputListResponseSend)
        : base(outputListResponseSend) { }
#pragma warning restore CS8618

    public OutputListResponseSend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSendFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSendFromRaw : IFromRawJson<OutputListResponseSend>
{
    /// <inheritdoc/>
    public OutputListResponseSend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSend.FromRawUnchecked(rawData);
}

/// <summary>
/// Outcome of a Send function's delivery attempt.
/// </summary>
[JsonConverter(typeof(OutputListResponseSendDeliveryStatusConverter))]
public enum OutputListResponseSendDeliveryStatus
{
    Success,
    Skip,
}

sealed class OutputListResponseSendDeliveryStatusConverter
    : JsonConverter<OutputListResponseSendDeliveryStatus>
{
    public override OutputListResponseSendDeliveryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => OutputListResponseSendDeliveryStatus.Success,
            "skip" => OutputListResponseSendDeliveryStatus.Skip,
            _ => (OutputListResponseSendDeliveryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseSendDeliveryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseSendDeliveryStatus.Success => "success",
                OutputListResponseSendDeliveryStatus.Skip => "skip",
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
[JsonConverter(typeof(OutputListResponseSendDestinationTypeConverter))]
public enum OutputListResponseSendDestinationType
{
    Webhook,
    S3,
    GoogleDrive,
}

sealed class OutputListResponseSendDestinationTypeConverter
    : JsonConverter<OutputListResponseSendDestinationType>
{
    public override OutputListResponseSendDestinationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => OutputListResponseSendDestinationType.Webhook,
            "s3" => OutputListResponseSendDestinationType.S3,
            "google_drive" => OutputListResponseSendDestinationType.GoogleDrive,
            _ => (OutputListResponseSendDestinationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseSendDestinationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseSendDestinationType.Webhook => "webhook",
                OutputListResponseSendDestinationType.S3 => "s3",
                OutputListResponseSendDestinationType.GoogleDrive => "google_drive",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(OutputListResponseSendEventTypeConverter))]
public enum OutputListResponseSendEventType
{
    Send,
}

sealed class OutputListResponseSendEventTypeConverter
    : JsonConverter<OutputListResponseSendEventType>
{
    public override OutputListResponseSendEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "send" => OutputListResponseSendEventType.Send,
            _ => (OutputListResponseSendEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputListResponseSendEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputListResponseSendEventType.Send => "send",
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
[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSendGoogleDriveOutput,
        OutputListResponseSendGoogleDriveOutputFromRaw
    >)
)]
public sealed record class OutputListResponseSendGoogleDriveOutput : JsonModel
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

    public OutputListResponseSendGoogleDriveOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSendGoogleDriveOutput(
        OutputListResponseSendGoogleDriveOutput outputListResponseSendGoogleDriveOutput
    )
        : base(outputListResponseSendGoogleDriveOutput) { }
#pragma warning restore CS8618

    public OutputListResponseSendGoogleDriveOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSendGoogleDriveOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSendGoogleDriveOutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSendGoogleDriveOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSendGoogleDriveOutputFromRaw
    : IFromRawJson<OutputListResponseSendGoogleDriveOutput>
{
    /// <inheritdoc/>
    public OutputListResponseSendGoogleDriveOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSendGoogleDriveOutput.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSendMetadata,
        OutputListResponseSendMetadataFromRaw
    >)
)]
public sealed record class OutputListResponseSendMetadata : JsonModel
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

    public OutputListResponseSendMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSendMetadata(
        OutputListResponseSendMetadata outputListResponseSendMetadata
    )
        : base(outputListResponseSendMetadata) { }
#pragma warning restore CS8618

    public OutputListResponseSendMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSendMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSendMetadataFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSendMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSendMetadataFromRaw : IFromRawJson<OutputListResponseSendMetadata>
{
    /// <inheritdoc/>
    public OutputListResponseSendMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSendMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata returned when a Send function delivers to an S3 bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSendS3Output,
        OutputListResponseSendS3OutputFromRaw
    >)
)]
public sealed record class OutputListResponseSendS3Output : JsonModel
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

    public OutputListResponseSendS3Output() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSendS3Output(
        OutputListResponseSendS3Output outputListResponseSendS3Output
    )
        : base(outputListResponseSendS3Output) { }
#pragma warning restore CS8618

    public OutputListResponseSendS3Output(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSendS3Output(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSendS3OutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSendS3Output FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSendS3OutputFromRaw : IFromRawJson<OutputListResponseSendS3Output>
{
    /// <inheritdoc/>
    public OutputListResponseSendS3Output FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSendS3Output.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata returned when a Send function delivers to a webhook.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OutputListResponseSendWebhookOutput,
        OutputListResponseSendWebhookOutputFromRaw
    >)
)]
public sealed record class OutputListResponseSendWebhookOutput : JsonModel
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

    public OutputListResponseSendWebhookOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListResponseSendWebhookOutput(
        OutputListResponseSendWebhookOutput outputListResponseSendWebhookOutput
    )
        : base(outputListResponseSendWebhookOutput) { }
#pragma warning restore CS8618

    public OutputListResponseSendWebhookOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListResponseSendWebhookOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListResponseSendWebhookOutputFromRaw.FromRawUnchecked"/>
    public static OutputListResponseSendWebhookOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListResponseSendWebhookOutputFromRaw : IFromRawJson<OutputListResponseSendWebhookOutput>
{
    /// <inheritdoc/>
    public OutputListResponseSendWebhookOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListResponseSendWebhookOutput.FromRawUnchecked(rawData);
}
