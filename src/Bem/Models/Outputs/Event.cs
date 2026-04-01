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

[JsonConverter(typeof(EventConverter))]
public record class Event : ModelBase
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
                route: (x) => x.EventID,
                splitCollection: (x) => x.EventID,
                splitItem: (x) => x.EventID,
                error: (x) => x.EventID,
                join: (x) => x.EventID,
                enrich: (x) => x.EventID,
                collectionProcessing: (x) => x.EventID
            );
        }
    }

    public string? FunctionID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.FunctionID,
                route: (x) => x.FunctionID,
                splitCollection: (x) => x.FunctionID,
                splitItem: (x) => x.FunctionID,
                error: (x) => x.FunctionID,
                join: (x) => x.FunctionID,
                enrich: (x) => x.FunctionID,
                collectionProcessing: (_) => null
            );
        }
    }

    public string? FunctionName
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.FunctionName,
                route: (x) => x.FunctionName,
                splitCollection: (x) => x.FunctionName,
                splitItem: (x) => x.FunctionName,
                error: (x) => x.FunctionName,
                join: (x) => x.FunctionName,
                enrich: (x) => x.FunctionName,
                collectionProcessing: (_) => null
            );
        }
    }

    public string ReferenceID
    {
        get
        {
            return Match(
                transform: (x) => x.ReferenceID,
                route: (x) => x.ReferenceID,
                splitCollection: (x) => x.ReferenceID,
                splitItem: (x) => x.ReferenceID,
                error: (x) => x.ReferenceID,
                join: (x) => x.ReferenceID,
                enrich: (x) => x.ReferenceID,
                collectionProcessing: (x) => x.ReferenceID
            );
        }
    }

    public JsonElement? TransformedContent
    {
        get
        {
            return Match<JsonElement?>(
                transform: (x) => x.TransformedContent,
                route: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                error: (_) => null,
                join: (x) => x.TransformedContent,
                enrich: (_) => null,
                collectionProcessing: (_) => null
            );
        }
    }

    public float? AvgConfidence
    {
        get
        {
            return Match<float?>(
                transform: (x) => x.AvgConfidence,
                route: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                error: (_) => null,
                join: (x) => x.AvgConfidence,
                enrich: (_) => null,
                collectionProcessing: (_) => null
            );
        }
    }

    public string? CallID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.CallID,
                route: (x) => x.CallID,
                splitCollection: (x) => x.CallID,
                splitItem: (x) => x.CallID,
                error: (x) => x.CallID,
                join: (x) => x.CallID,
                enrich: (x) => x.CallID,
                collectionProcessing: (_) => null
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            return Match<DateTimeOffset?>(
                transform: (x) => x.CreatedAt,
                route: (x) => x.CreatedAt,
                splitCollection: (x) => x.CreatedAt,
                splitItem: (x) => x.CreatedAt,
                error: (x) => x.CreatedAt,
                join: (x) => x.CreatedAt,
                enrich: (x) => x.CreatedAt,
                collectionProcessing: (x) => x.CreatedAt
            );
        }
    }

    public JsonElement? FieldConfidences
    {
        get
        {
            return Match<JsonElement?>(
                transform: (x) => x.FieldConfidences,
                route: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                error: (_) => null,
                join: (x) => x.FieldConfidences,
                enrich: (_) => null,
                collectionProcessing: (_) => null
            );
        }
    }

    public string? FunctionCallID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.FunctionCallID,
                route: (x) => x.FunctionCallID,
                splitCollection: (x) => x.FunctionCallID,
                splitItem: (x) => x.FunctionCallID,
                error: (x) => x.FunctionCallID,
                join: (x) => x.FunctionCallID,
                enrich: (x) => x.FunctionCallID,
                collectionProcessing: (_) => null
            );
        }
    }

    public long? FunctionCallTryNumber
    {
        get
        {
            return Match<long?>(
                transform: (x) => x.FunctionCallTryNumber,
                route: (x) => x.FunctionCallTryNumber,
                splitCollection: (x) => x.FunctionCallTryNumber,
                splitItem: (x) => x.FunctionCallTryNumber,
                error: (x) => x.FunctionCallTryNumber,
                join: (x) => x.FunctionCallTryNumber,
                enrich: (x) => x.FunctionCallTryNumber,
                collectionProcessing: (x) => x.FunctionCallTryNumber
            );
        }
    }

    public long? FunctionVersionNum
    {
        get
        {
            return Match<long?>(
                transform: (x) => x.FunctionVersionNum,
                route: (x) => x.FunctionVersionNum,
                splitCollection: (x) => x.FunctionVersionNum,
                splitItem: (x) => x.FunctionVersionNum,
                error: (x) => x.FunctionVersionNum,
                join: (x) => x.FunctionVersionNum,
                enrich: (x) => x.FunctionVersionNum,
                collectionProcessing: (_) => null
            );
        }
    }

    public InboundEmailEvent? InboundEmail
    {
        get
        {
            return Match<InboundEmailEvent?>(
                transform: (x) => x.InboundEmail,
                route: (x) => x.InboundEmail,
                splitCollection: (x) => x.InboundEmail,
                splitItem: (x) => x.InboundEmail,
                error: (x) => x.InboundEmail,
                join: (x) => x.InboundEmail,
                enrich: (x) => x.InboundEmail,
                collectionProcessing: (x) => x.InboundEmail
            );
        }
    }

    public string? S3Url
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.S3Url,
                route: (x) => x.S3Url,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                error: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                collectionProcessing: (_) => null
            );
        }
    }

    public string? TransformationID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.TransformationID,
                route: (_) => null,
                splitCollection: (_) => null,
                splitItem: (_) => null,
                error: (_) => null,
                join: (x) => x.TransformationID,
                enrich: (_) => null,
                collectionProcessing: (_) => null
            );
        }
    }

    public string? WorkflowID
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.WorkflowID,
                route: (x) => x.WorkflowID,
                splitCollection: (x) => x.WorkflowID,
                splitItem: (x) => x.WorkflowID,
                error: (x) => x.WorkflowID,
                join: (x) => x.WorkflowID,
                enrich: (x) => x.WorkflowID,
                collectionProcessing: (_) => null
            );
        }
    }

    public string? WorkflowName
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.WorkflowName,
                route: (x) => x.WorkflowName,
                splitCollection: (x) => x.WorkflowName,
                splitItem: (x) => x.WorkflowName,
                error: (x) => x.WorkflowName,
                join: (x) => x.WorkflowName,
                enrich: (x) => x.WorkflowName,
                collectionProcessing: (_) => null
            );
        }
    }

    public long? WorkflowVersionNum
    {
        get
        {
            return Match<long?>(
                transform: (x) => x.WorkflowVersionNum,
                route: (x) => x.WorkflowVersionNum,
                splitCollection: (x) => x.WorkflowVersionNum,
                splitItem: (x) => x.WorkflowVersionNum,
                error: (x) => x.WorkflowVersionNum,
                join: (x) => x.WorkflowVersionNum,
                enrich: (x) => x.WorkflowVersionNum,
                collectionProcessing: (_) => null
            );
        }
    }

    public Event(Transform value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(Route value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(SplitCollection value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(SplitItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(ErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(Join value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(Enrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(CollectionProcessing value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(JsonElement element)
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
    ///     (Route value) =&gt; {...},
    ///     (SplitCollection value) =&gt; {...},
    ///     (SplitItem value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...},
    ///     (Join value) =&gt; {...},
    ///     (Enrich value) =&gt; {...},
    ///     (CollectionProcessing value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Transform> transform,
        Action<Route> route,
        Action<SplitCollection> splitCollection,
        Action<SplitItem> splitItem,
        Action<ErrorEvent> error,
        Action<Join> join,
        Action<Enrich> enrich,
        Action<CollectionProcessing> collectionProcessing
    )
    {
        switch (this.Value)
        {
            case Transform value:
                transform(value);
                break;
            case Route value:
                route(value);
                break;
            case SplitCollection value:
                splitCollection(value);
                break;
            case SplitItem value:
                splitItem(value);
                break;
            case ErrorEvent value:
                error(value);
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
            default:
                throw new BemInvalidDataException("Data did not match any variant of Event");
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
    ///     (Route value) =&gt; {...},
    ///     (SplitCollection value) =&gt; {...},
    ///     (SplitItem value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...},
    ///     (Join value) =&gt; {...},
    ///     (Enrich value) =&gt; {...},
    ///     (CollectionProcessing value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Transform, T> transform,
        Func<Route, T> route,
        Func<SplitCollection, T> splitCollection,
        Func<SplitItem, T> splitItem,
        Func<ErrorEvent, T> error,
        Func<Join, T> join,
        Func<Enrich, T> enrich,
        Func<CollectionProcessing, T> collectionProcessing
    )
    {
        return this.Value switch
        {
            Transform value => transform(value),
            Route value => route(value),
            SplitCollection value => splitCollection(value),
            SplitItem value => splitItem(value),
            ErrorEvent value => error(value),
            Join value => join(value),
            Enrich value => enrich(value),
            CollectionProcessing value => collectionProcessing(value),
            _ => throw new BemInvalidDataException("Data did not match any variant of Event"),
        };
    }

    public static implicit operator Event(Transform value) => new(value);

    public static implicit operator Event(Route value) => new(value);

    public static implicit operator Event(SplitCollection value) => new(value);

    public static implicit operator Event(SplitItem value) => new(value);

    public static implicit operator Event(ErrorEvent value) => new(value);

    public static implicit operator Event(Join value) => new(value);

    public static implicit operator Event(Enrich value) => new(value);

    public static implicit operator Event(CollectionProcessing value) => new(value);

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
            throw new BemInvalidDataException("Data did not match any variant of Event");
        }
        this.Switch(
            (transform) => transform.Validate(),
            (route) => route.Validate(),
            (splitCollection) => splitCollection.Validate(),
            (splitItem) => splitItem.Validate(),
            (error) => error.Validate(),
            (join) => join.Validate(),
            (enrich) => enrich.Validate(),
            (collectionProcessing) => collectionProcessing.Validate()
        );
    }

    public virtual bool Equals(Event? other) =>
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
            Route _ => 1,
            SplitCollection _ => 2,
            SplitItem _ => 3,
            ErrorEvent _ => 4,
            Join _ => 5,
            Enrich _ => 6,
            CollectionProcessing _ => 7,
            _ => -1,
        };
    }
}

sealed class EventConverter : JsonConverter<Event>
{
    public override Event? Read(
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
            default:
            {
                return new Event(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
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

    public ApiEnum<string, global::Bem.Models.Outputs.EventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Bem.Models.Outputs.EventType>
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

    public global::Bem.Models.Outputs.Metadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Bem.Models.Outputs.Metadata>("metadata");
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

    public CorrectedContent(Output value, JsonElement? element = null)
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
    /// type <see cref="Output"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOutput(out var value)) {
    ///     // `value` is of type `Output`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOutput([NotNullWhen(true)] out Output? value)
    {
        value = this.Value as Output;
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
    ///     (Output value) =&gt; {...},
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
        Action<Output> output,
        Action<JsonElement> jsonElement,
        Action<IReadOnlyList<JsonElement>> jsonElements,
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case Output value:
                output(value);
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
    ///     (Output value) =&gt; {...},
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
        Func<Output, T> output,
        Func<JsonElement, T> jsonElement,
        Func<IReadOnlyList<JsonElement>, T> jsonElements,
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            Output value => output(value),
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

    public static implicit operator CorrectedContent(Output value) => new(value);

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
            (output) => output.Validate(),
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
            Output _ => 0,
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
            var deserialized = JsonSerializer.Deserialize<Output>(element, options);
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

[JsonConverter(typeof(JsonModelConverter<Output, OutputFromRaw>))]
public sealed record class Output : JsonModel
{
    public IReadOnlyList<AnyType?>? OutputValue
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
        foreach (var item in this.OutputValue ?? [])
        {
            item?.Validate();
        }
    }

    public Output() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Output(Output output)
        : base(output) { }
#pragma warning restore CS8618

    public Output(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Output(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputFromRaw.FromRawUnchecked"/>
    public static Output FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputFromRaw : IFromRawJson<Output>
{
    /// <inheritdoc/>
    public Output FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Output.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Bem.Models.Outputs.EventTypeConverter))]
public enum EventType
{
    Transform,
}

sealed class EventTypeConverter : JsonConverter<global::Bem.Models.Outputs.EventType>
{
    public override global::Bem.Models.Outputs.EventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transform" => global::Bem.Models.Outputs.EventType.Transform,
            _ => (global::Bem.Models.Outputs.EventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Bem.Models.Outputs.EventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Bem.Models.Outputs.EventType.Transform => "transform",
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
        global::Bem.Models.Outputs.Metadata,
        global::Bem.Models.Outputs.MetadataFromRaw
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
    public Metadata(global::Bem.Models.Outputs.Metadata metadata)
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

    /// <inheritdoc cref="global::Bem.Models.Outputs.MetadataFromRaw.FromRawUnchecked"/>
    public static global::Bem.Models.Outputs.Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<global::Bem.Models.Outputs.Metadata>
{
    /// <inheritdoc/>
    public global::Bem.Models.Outputs.Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Bem.Models.Outputs.Metadata.FromRawUnchecked(rawData);
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
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Success,
    Failed,
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
            "success" => Status.Success,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Success => "success",
                Status.Failed => "failed",
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
