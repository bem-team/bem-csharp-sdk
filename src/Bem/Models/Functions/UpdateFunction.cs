using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// A function that transforms and customizes input payloads using JMESPath expressions.
/// Payload shaping allows you to extract specific data, perform calculations, and
/// reshape complex input structures into simplified, standardized output formats
/// tailored to your downstream systems or business requirements.
/// </summary>
[JsonConverter(typeof(UpdateFunctionConverter))]
public record class UpdateFunction : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return Match(
                transform: (x) => x.Type,
                extract: (x) => x.Type,
                analyze: (x) => x.Type,
                route: (x) => x.Type,
                send: (x) => x.Type,
                split: (x) => x.Type,
                join: (x) => x.Type,
                payloadShaping: (x) => x.Type,
                enrich: (x) => x.Type
            );
        }
    }

    public string? DisplayName
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.DisplayName,
                extract: (x) => x.DisplayName,
                analyze: (x) => x.DisplayName,
                route: (x) => x.DisplayName,
                send: (x) => x.DisplayName,
                split: (x) => x.DisplayName,
                join: (x) => x.DisplayName,
                payloadShaping: (x) => x.DisplayName,
                enrich: (_) => null
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
                analyze: (x) => x.FunctionName,
                route: (x) => x.FunctionName,
                send: (x) => x.FunctionName,
                split: (x) => x.FunctionName,
                join: (x) => x.FunctionName,
                payloadShaping: (x) => x.FunctionName,
                enrich: (_) => null
            );
        }
    }

    public JsonElement? OutputSchema
    {
        get
        {
            return Match<JsonElement?>(
                transform: (x) => x.OutputSchema,
                extract: (x) => x.OutputSchema,
                analyze: (x) => x.OutputSchema,
                route: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.OutputSchema,
                payloadShaping: (_) => null,
                enrich: (_) => null
            );
        }
    }

    public string? OutputSchemaName
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.OutputSchemaName,
                extract: (x) => x.OutputSchemaName,
                analyze: (x) => x.OutputSchemaName,
                route: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.OutputSchemaName,
                payloadShaping: (_) => null,
                enrich: (_) => null
            );
        }
    }

    public bool? TabularChunkingEnabled
    {
        get
        {
            return Match<bool?>(
                transform: (x) => x.TabularChunkingEnabled,
                extract: (x) => x.TabularChunkingEnabled,
                analyze: (_) => null,
                route: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (_) => null,
                payloadShaping: (_) => null,
                enrich: (_) => null
            );
        }
    }

    public string? Description
    {
        get
        {
            return Match<string?>(
                transform: (_) => null,
                extract: (_) => null,
                analyze: (_) => null,
                route: (x) => x.Description,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.Description,
                payloadShaping: (_) => null,
                enrich: (_) => null
            );
        }
    }

    public UpdateFunction(UpdateFunctionTransform value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(UpdateFunctionExtract value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(UpdateFunctionAnalyze value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(UpdateFunctionRoute value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(UpdateFunctionSend value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(UpdateFunctionSplit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(UpdateFunctionJoin value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(UpdateFunctionPayloadShaping value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(UpdateFunctionEnrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFunction(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionTransform"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTransform(out var value)) {
    ///     // `value` is of type `UpdateFunctionTransform`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTransform([NotNullWhen(true)] out UpdateFunctionTransform? value)
    {
        value = this.Value as UpdateFunctionTransform;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionExtract"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtract(out var value)) {
    ///     // `value` is of type `UpdateFunctionExtract`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtract([NotNullWhen(true)] out UpdateFunctionExtract? value)
    {
        value = this.Value as UpdateFunctionExtract;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionAnalyze"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAnalyze(out var value)) {
    ///     // `value` is of type `UpdateFunctionAnalyze`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAnalyze([NotNullWhen(true)] out UpdateFunctionAnalyze? value)
    {
        value = this.Value as UpdateFunctionAnalyze;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionRoute"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRoute(out var value)) {
    ///     // `value` is of type `UpdateFunctionRoute`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRoute([NotNullWhen(true)] out UpdateFunctionRoute? value)
    {
        value = this.Value as UpdateFunctionRoute;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionSend"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `UpdateFunctionSend`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out UpdateFunctionSend? value)
    {
        value = this.Value as UpdateFunctionSend;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionSplit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplit(out var value)) {
    ///     // `value` is of type `UpdateFunctionSplit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplit([NotNullWhen(true)] out UpdateFunctionSplit? value)
    {
        value = this.Value as UpdateFunctionSplit;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionJoin"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJoin(out var value)) {
    ///     // `value` is of type `UpdateFunctionJoin`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJoin([NotNullWhen(true)] out UpdateFunctionJoin? value)
    {
        value = this.Value as UpdateFunctionJoin;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionPayloadShaping"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayloadShaping(out var value)) {
    ///     // `value` is of type `UpdateFunctionPayloadShaping`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayloadShaping([NotNullWhen(true)] out UpdateFunctionPayloadShaping? value)
    {
        value = this.Value as UpdateFunctionPayloadShaping;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFunctionEnrich"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrich(out var value)) {
    ///     // `value` is of type `UpdateFunctionEnrich`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrich([NotNullWhen(true)] out UpdateFunctionEnrich? value)
    {
        value = this.Value as UpdateFunctionEnrich;
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
    ///     (UpdateFunctionTransform value) =&gt; {...},
    ///     (UpdateFunctionExtract value) =&gt; {...},
    ///     (UpdateFunctionAnalyze value) =&gt; {...},
    ///     (UpdateFunctionRoute value) =&gt; {...},
    ///     (UpdateFunctionSend value) =&gt; {...},
    ///     (UpdateFunctionSplit value) =&gt; {...},
    ///     (UpdateFunctionJoin value) =&gt; {...},
    ///     (UpdateFunctionPayloadShaping value) =&gt; {...},
    ///     (UpdateFunctionEnrich value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<UpdateFunctionTransform> transform,
        Action<UpdateFunctionExtract> extract,
        Action<UpdateFunctionAnalyze> analyze,
        Action<UpdateFunctionRoute> route,
        Action<UpdateFunctionSend> send,
        Action<UpdateFunctionSplit> split,
        Action<UpdateFunctionJoin> join,
        Action<UpdateFunctionPayloadShaping> payloadShaping,
        Action<UpdateFunctionEnrich> enrich
    )
    {
        switch (this.Value)
        {
            case UpdateFunctionTransform value:
                transform(value);
                break;
            case UpdateFunctionExtract value:
                extract(value);
                break;
            case UpdateFunctionAnalyze value:
                analyze(value);
                break;
            case UpdateFunctionRoute value:
                route(value);
                break;
            case UpdateFunctionSend value:
                send(value);
                break;
            case UpdateFunctionSplit value:
                split(value);
                break;
            case UpdateFunctionJoin value:
                join(value);
                break;
            case UpdateFunctionPayloadShaping value:
                payloadShaping(value);
                break;
            case UpdateFunctionEnrich value:
                enrich(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of UpdateFunction"
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
    ///     (UpdateFunctionTransform value) =&gt; {...},
    ///     (UpdateFunctionExtract value) =&gt; {...},
    ///     (UpdateFunctionAnalyze value) =&gt; {...},
    ///     (UpdateFunctionRoute value) =&gt; {...},
    ///     (UpdateFunctionSend value) =&gt; {...},
    ///     (UpdateFunctionSplit value) =&gt; {...},
    ///     (UpdateFunctionJoin value) =&gt; {...},
    ///     (UpdateFunctionPayloadShaping value) =&gt; {...},
    ///     (UpdateFunctionEnrich value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<UpdateFunctionTransform, T> transform,
        Func<UpdateFunctionExtract, T> extract,
        Func<UpdateFunctionAnalyze, T> analyze,
        Func<UpdateFunctionRoute, T> route,
        Func<UpdateFunctionSend, T> send,
        Func<UpdateFunctionSplit, T> split,
        Func<UpdateFunctionJoin, T> join,
        Func<UpdateFunctionPayloadShaping, T> payloadShaping,
        Func<UpdateFunctionEnrich, T> enrich
    )
    {
        return this.Value switch
        {
            UpdateFunctionTransform value => transform(value),
            UpdateFunctionExtract value => extract(value),
            UpdateFunctionAnalyze value => analyze(value),
            UpdateFunctionRoute value => route(value),
            UpdateFunctionSend value => send(value),
            UpdateFunctionSplit value => split(value),
            UpdateFunctionJoin value => join(value),
            UpdateFunctionPayloadShaping value => payloadShaping(value),
            UpdateFunctionEnrich value => enrich(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of UpdateFunction"
            ),
        };
    }

    public static implicit operator UpdateFunction(UpdateFunctionTransform value) => new(value);

    public static implicit operator UpdateFunction(UpdateFunctionExtract value) => new(value);

    public static implicit operator UpdateFunction(UpdateFunctionAnalyze value) => new(value);

    public static implicit operator UpdateFunction(UpdateFunctionRoute value) => new(value);

    public static implicit operator UpdateFunction(UpdateFunctionSend value) => new(value);

    public static implicit operator UpdateFunction(UpdateFunctionSplit value) => new(value);

    public static implicit operator UpdateFunction(UpdateFunctionJoin value) => new(value);

    public static implicit operator UpdateFunction(UpdateFunctionPayloadShaping value) =>
        new(value);

    public static implicit operator UpdateFunction(UpdateFunctionEnrich value) => new(value);

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
            throw new BemInvalidDataException("Data did not match any variant of UpdateFunction");
        }
        this.Switch(
            (transform) => transform.Validate(),
            (extract) => extract.Validate(),
            (analyze) => analyze.Validate(),
            (route) => route.Validate(),
            (send) => send.Validate(),
            (split) => split.Validate(),
            (join) => join.Validate(),
            (payloadShaping) => payloadShaping.Validate(),
            (enrich) => enrich.Validate()
        );
    }

    public virtual bool Equals(UpdateFunction? other) =>
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
            UpdateFunctionTransform _ => 0,
            UpdateFunctionExtract _ => 1,
            UpdateFunctionAnalyze _ => 2,
            UpdateFunctionRoute _ => 3,
            UpdateFunctionSend _ => 4,
            UpdateFunctionSplit _ => 5,
            UpdateFunctionJoin _ => 6,
            UpdateFunctionPayloadShaping _ => 7,
            UpdateFunctionEnrich _ => 8,
            _ => -1,
        };
    }
}

sealed class UpdateFunctionConverter : JsonConverter<UpdateFunction>
{
    public override UpdateFunction? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "transform":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionTransform>(
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
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionExtract>(
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
            case "analyze":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionAnalyze>(
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
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionRoute>(
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
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionSend>(
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
            case "split":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionSplit>(
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
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionJoin>(
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
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionPayloadShaping>(
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
                    var deserialized = JsonSerializer.Deserialize<UpdateFunctionEnrich>(
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
                return new UpdateFunction(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<UpdateFunctionTransform, UpdateFunctionTransformFromRaw>))]
public sealed record class UpdateFunctionTransform : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Display name of function. Human-readable name to help you identify the function.
    /// </summary>
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

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// Desired output structure defined in standard JSON Schema convention.
    /// </summary>
    public JsonElement? OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("outputSchema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputSchema", value);
        }
    }

    /// <summary>
    /// Name of output schema object.
    /// </summary>
    public string? OutputSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("outputSchemaName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputSchemaName", value);
        }
    }

    /// <summary>
    /// Whether tabular chunking is enabled on the pipeline. This processes tables
    /// in CSV/Excel in row batches, rather than all rows at once.
    /// </summary>
    public bool? TabularChunkingEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tabularChunkingEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tabularChunkingEnabled", value);
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize functions.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("transform")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        _ = this.FunctionName;
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        _ = this.TabularChunkingEnabled;
        _ = this.Tags;
    }

    public UpdateFunctionTransform()
    {
        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionTransform(UpdateFunctionTransform updateFunctionTransform)
        : base(updateFunctionTransform) { }
#pragma warning restore CS8618

    public UpdateFunctionTransform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionTransform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionTransformFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionTransform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionTransformFromRaw : IFromRawJson<UpdateFunctionTransform>
{
    /// <inheritdoc/>
    public UpdateFunctionTransform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateFunctionTransform.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UpdateFunctionExtract, UpdateFunctionExtractFromRaw>))]
public sealed record class UpdateFunctionExtract : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Display name of function. Human-readable name to help you identify the function.
    /// </summary>
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

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// Desired output structure defined in standard JSON Schema convention.
    /// </summary>
    public JsonElement? OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("outputSchema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputSchema", value);
        }
    }

    /// <summary>
    /// Name of output schema object.
    /// </summary>
    public string? OutputSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("outputSchemaName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputSchemaName", value);
        }
    }

    /// <summary>
    /// Whether tabular chunking is enabled. When true, tables in CSV/Excel files
    /// are processed in row batches rather than all at once.
    /// </summary>
    public bool? TabularChunkingEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tabularChunkingEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tabularChunkingEnabled", value);
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize functions.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("extract")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        _ = this.FunctionName;
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        _ = this.TabularChunkingEnabled;
        _ = this.Tags;
    }

    public UpdateFunctionExtract()
    {
        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionExtract(UpdateFunctionExtract updateFunctionExtract)
        : base(updateFunctionExtract) { }
#pragma warning restore CS8618

    public UpdateFunctionExtract(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionExtract(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionExtractFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionExtract FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionExtractFromRaw : IFromRawJson<UpdateFunctionExtract>
{
    /// <inheritdoc/>
    public UpdateFunctionExtract FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateFunctionExtract.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UpdateFunctionAnalyze, UpdateFunctionAnalyzeFromRaw>))]
public sealed record class UpdateFunctionAnalyze : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Display name of function. Human-readable name to help you identify the function.
    /// </summary>
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

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// Desired output structure defined in standard JSON Schema convention.
    /// </summary>
    public JsonElement? OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("outputSchema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputSchema", value);
        }
    }

    /// <summary>
    /// Name of output schema object.
    /// </summary>
    public string? OutputSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("outputSchemaName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputSchemaName", value);
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize functions.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("analyze")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        _ = this.FunctionName;
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        _ = this.Tags;
    }

    public UpdateFunctionAnalyze()
    {
        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionAnalyze(UpdateFunctionAnalyze updateFunctionAnalyze)
        : base(updateFunctionAnalyze) { }
#pragma warning restore CS8618

    public UpdateFunctionAnalyze(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionAnalyze(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionAnalyzeFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionAnalyze FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionAnalyzeFromRaw : IFromRawJson<UpdateFunctionAnalyze>
{
    /// <inheritdoc/>
    public UpdateFunctionAnalyze FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateFunctionAnalyze.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UpdateFunctionRoute, UpdateFunctionRouteFromRaw>))]
public sealed record class UpdateFunctionRoute : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Description of router. Can be used to provide additional context on router's
    /// purpose and expected inputs.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Display name of function. Human-readable name to help you identify the function.
    /// </summary>
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

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// List of routes.
    /// </summary>
    public IReadOnlyList<RouteListItem>? Routes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RouteListItem>>("routes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<RouteListItem>?>(
                "routes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize functions.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("route")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.FunctionName;
        foreach (var item in this.Routes ?? [])
        {
            item.Validate();
        }
        _ = this.Tags;
    }

    public UpdateFunctionRoute()
    {
        this.Type = JsonSerializer.SerializeToElement("route");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionRoute(UpdateFunctionRoute updateFunctionRoute)
        : base(updateFunctionRoute) { }
#pragma warning restore CS8618

    public UpdateFunctionRoute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("route");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionRoute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionRouteFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionRoute FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionRouteFromRaw : IFromRawJson<UpdateFunctionRoute>
{
    /// <inheritdoc/>
    public UpdateFunctionRoute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UpdateFunctionRoute.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UpdateFunctionSend, UpdateFunctionSendFromRaw>))]
public sealed record class UpdateFunctionSend : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Destination type for a Send function.
    /// </summary>
    public ApiEnum<string, UpdateFunctionSendDestinationType>? DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UpdateFunctionSendDestinationType>
            >("destinationType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destinationType", value);
        }
    }

    /// <summary>
    /// Display name of function. Human-readable name to help you identify the function.
    /// </summary>
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

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// Google Drive folder ID. Required when destinationType is google_drive. Managed
    /// via Paragon OAuth.
    /// </summary>
    public string? GoogleDriveFolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("googleDriveFolderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("googleDriveFolderId", value);
        }
    }

    /// <summary>
    /// S3 bucket to upload the payload to. Required when destinationType is s3.
    /// </summary>
    public string? S3Bucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3Bucket");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3Bucket", value);
        }
    }

    /// <summary>
    /// Optional S3 key prefix (folder path).
    /// </summary>
    public string? S3Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3Prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3Prefix", value);
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize functions.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to sign webhook deliveries with an HMAC-SHA256 `bem-signature` header.
    /// Defaults to `true` when omitted — signing is on by default for new send functions.
    /// Set explicitly to `false` to disable.
    /// </summary>
    public bool? WebhookSigningEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("webhookSigningEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhookSigningEnabled", value);
        }
    }

    /// <summary>
    /// Webhook URL to POST the payload to. Required when destinationType is webhook.
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhookUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhookUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("send")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        this.DestinationType?.Validate();
        _ = this.DisplayName;
        _ = this.FunctionName;
        _ = this.GoogleDriveFolderID;
        _ = this.S3Bucket;
        _ = this.S3Prefix;
        _ = this.Tags;
        _ = this.WebhookSigningEnabled;
        _ = this.WebhookUrl;
    }

    public UpdateFunctionSend()
    {
        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionSend(UpdateFunctionSend updateFunctionSend)
        : base(updateFunctionSend) { }
#pragma warning restore CS8618

    public UpdateFunctionSend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionSend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionSendFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionSend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionSendFromRaw : IFromRawJson<UpdateFunctionSend>
{
    /// <inheritdoc/>
    public UpdateFunctionSend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UpdateFunctionSend.FromRawUnchecked(rawData);
}

/// <summary>
/// Destination type for a Send function.
/// </summary>
[JsonConverter(typeof(UpdateFunctionSendDestinationTypeConverter))]
public enum UpdateFunctionSendDestinationType
{
    Webhook,
    S3,
    GoogleDrive,
}

sealed class UpdateFunctionSendDestinationTypeConverter
    : JsonConverter<UpdateFunctionSendDestinationType>
{
    public override UpdateFunctionSendDestinationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => UpdateFunctionSendDestinationType.Webhook,
            "s3" => UpdateFunctionSendDestinationType.S3,
            "google_drive" => UpdateFunctionSendDestinationType.GoogleDrive,
            _ => (UpdateFunctionSendDestinationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateFunctionSendDestinationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateFunctionSendDestinationType.Webhook => "webhook",
                UpdateFunctionSendDestinationType.S3 => "s3",
                UpdateFunctionSendDestinationType.GoogleDrive => "google_drive",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UpdateFunctionSplit, UpdateFunctionSplitFromRaw>))]
public sealed record class UpdateFunctionSplit : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Display name of function. Human-readable name to help you identify the function.
    /// </summary>
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

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    public UpdateFunctionSplitPrintPageSplitConfig? PrintPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UpdateFunctionSplitPrintPageSplitConfig>(
                "printPageSplitConfig"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("printPageSplitConfig", value);
        }
    }

    public UpdateFunctionSplitSemanticPageSplitConfig? SemanticPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UpdateFunctionSplitSemanticPageSplitConfig>(
                "semanticPageSplitConfig"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("semanticPageSplitConfig", value);
        }
    }

    public ApiEnum<string, UpdateFunctionSplitSplitType>? SplitType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UpdateFunctionSplitSplitType>>(
                "splitType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("splitType", value);
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize functions.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("split")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        _ = this.FunctionName;
        this.PrintPageSplitConfig?.Validate();
        this.SemanticPageSplitConfig?.Validate();
        this.SplitType?.Validate();
        _ = this.Tags;
    }

    public UpdateFunctionSplit()
    {
        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionSplit(UpdateFunctionSplit updateFunctionSplit)
        : base(updateFunctionSplit) { }
#pragma warning restore CS8618

    public UpdateFunctionSplit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionSplit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionSplitFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionSplit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionSplitFromRaw : IFromRawJson<UpdateFunctionSplit>
{
    /// <inheritdoc/>
    public UpdateFunctionSplit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UpdateFunctionSplit.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UpdateFunctionSplitPrintPageSplitConfig,
        UpdateFunctionSplitPrintPageSplitConfigFromRaw
    >)
)]
public sealed record class UpdateFunctionSplitPrintPageSplitConfig : JsonModel
{
    public string? NextFunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextFunctionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextFunctionID", value);
        }
    }

    public string? NextFunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextFunctionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextFunctionName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NextFunctionID;
        _ = this.NextFunctionName;
    }

    public UpdateFunctionSplitPrintPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionSplitPrintPageSplitConfig(
        UpdateFunctionSplitPrintPageSplitConfig updateFunctionSplitPrintPageSplitConfig
    )
        : base(updateFunctionSplitPrintPageSplitConfig) { }
#pragma warning restore CS8618

    public UpdateFunctionSplitPrintPageSplitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionSplitPrintPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionSplitPrintPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionSplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionSplitPrintPageSplitConfigFromRaw
    : IFromRawJson<UpdateFunctionSplitPrintPageSplitConfig>
{
    /// <inheritdoc/>
    public UpdateFunctionSplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateFunctionSplitPrintPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UpdateFunctionSplitSemanticPageSplitConfig,
        UpdateFunctionSplitSemanticPageSplitConfigFromRaw
    >)
)]
public sealed record class UpdateFunctionSplitSemanticPageSplitConfig : JsonModel
{
    public IReadOnlyList<SplitFunctionSemanticPageItemClass>? ItemClasses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SplitFunctionSemanticPageItemClass>
            >("itemClasses");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SplitFunctionSemanticPageItemClass>?>(
                "itemClasses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ItemClasses ?? [])
        {
            item.Validate();
        }
    }

    public UpdateFunctionSplitSemanticPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionSplitSemanticPageSplitConfig(
        UpdateFunctionSplitSemanticPageSplitConfig updateFunctionSplitSemanticPageSplitConfig
    )
        : base(updateFunctionSplitSemanticPageSplitConfig) { }
#pragma warning restore CS8618

    public UpdateFunctionSplitSemanticPageSplitConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionSplitSemanticPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionSplitSemanticPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionSplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionSplitSemanticPageSplitConfigFromRaw
    : IFromRawJson<UpdateFunctionSplitSemanticPageSplitConfig>
{
    /// <inheritdoc/>
    public UpdateFunctionSplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateFunctionSplitSemanticPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UpdateFunctionSplitSplitTypeConverter))]
public enum UpdateFunctionSplitSplitType
{
    PrintPage,
    SemanticPage,
}

sealed class UpdateFunctionSplitSplitTypeConverter : JsonConverter<UpdateFunctionSplitSplitType>
{
    public override UpdateFunctionSplitSplitType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => UpdateFunctionSplitSplitType.PrintPage,
            "semantic_page" => UpdateFunctionSplitSplitType.SemanticPage,
            _ => (UpdateFunctionSplitSplitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateFunctionSplitSplitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateFunctionSplitSplitType.PrintPage => "print_page",
                UpdateFunctionSplitSplitType.SemanticPage => "semantic_page",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UpdateFunctionJoin, UpdateFunctionJoinFromRaw>))]
public sealed record class UpdateFunctionJoin : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Description of join function.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Display name of function. Human-readable name to help you identify the function.
    /// </summary>
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

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// The type of join to perform.
    /// </summary>
    public ApiEnum<string, UpdateFunctionJoinJoinType>? JoinType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UpdateFunctionJoinJoinType>>(
                "joinType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("joinType", value);
        }
    }

    /// <summary>
    /// Desired output structure defined in standard JSON Schema convention.
    /// </summary>
    public JsonElement? OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("outputSchema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputSchema", value);
        }
    }

    /// <summary>
    /// Name of output schema object.
    /// </summary>
    public string? OutputSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("outputSchemaName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputSchemaName", value);
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize functions.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("join")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.FunctionName;
        this.JoinType?.Validate();
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        _ = this.Tags;
    }

    public UpdateFunctionJoin()
    {
        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionJoin(UpdateFunctionJoin updateFunctionJoin)
        : base(updateFunctionJoin) { }
#pragma warning restore CS8618

    public UpdateFunctionJoin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionJoin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionJoinFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionJoin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionJoinFromRaw : IFromRawJson<UpdateFunctionJoin>
{
    /// <inheritdoc/>
    public UpdateFunctionJoin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UpdateFunctionJoin.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of join to perform.
/// </summary>
[JsonConverter(typeof(UpdateFunctionJoinJoinTypeConverter))]
public enum UpdateFunctionJoinJoinType
{
    Standard,
}

sealed class UpdateFunctionJoinJoinTypeConverter : JsonConverter<UpdateFunctionJoinJoinType>
{
    public override UpdateFunctionJoinJoinType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => UpdateFunctionJoinJoinType.Standard,
            _ => (UpdateFunctionJoinJoinType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateFunctionJoinJoinType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateFunctionJoinJoinType.Standard => "standard",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A function that transforms and customizes input payloads using JMESPath expressions.
/// Payload shaping allows you to extract specific data, perform calculations, and
/// reshape complex input structures into simplified, standardized output formats
/// tailored to your downstream systems or business requirements.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UpdateFunctionPayloadShaping, UpdateFunctionPayloadShapingFromRaw>)
)]
public sealed record class UpdateFunctionPayloadShaping : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Display name of function. Human-readable name to help you identify the function.
    /// </summary>
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

    /// <summary>
    /// Name of function. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// JMESPath expression that defines how to transform and customize the input
    /// payload structure. Payload shaping allows you to extract, reshape, and reorganize
    /// data from complex input payloads into a simplified, standardized output format.
    /// Use JMESPath syntax to select specific fields, perform calculations, and create
    /// new data structures tailored to your needs.
    /// </summary>
    public string? ShapingSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shapingSchema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shapingSchema", value);
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize functions.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("payload_shaping"))
        )
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        _ = this.FunctionName;
        _ = this.ShapingSchema;
        _ = this.Tags;
    }

    public UpdateFunctionPayloadShaping()
    {
        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionPayloadShaping(UpdateFunctionPayloadShaping updateFunctionPayloadShaping)
        : base(updateFunctionPayloadShaping) { }
#pragma warning restore CS8618

    public UpdateFunctionPayloadShaping(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionPayloadShaping(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionPayloadShapingFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionPayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionPayloadShapingFromRaw : IFromRawJson<UpdateFunctionPayloadShaping>
{
    /// <inheritdoc/>
    public UpdateFunctionPayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateFunctionPayloadShaping.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UpdateFunctionEnrich, UpdateFunctionEnrichFromRaw>))]
public sealed record class UpdateFunctionEnrich : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Configuration for enrich function with semantic search steps.
    ///
    /// <para>**How Enrich Functions Work:**</para>
    ///
    /// <para>Enrich functions use semantic search to augment JSON data with relevant
    /// information from collections. They take JSON input (typically from a transform
    /// function), extract specified fields, perform vector-based semantic search
    /// against collections, and inject the results back into the data.</para>
    ///
    /// <para>**Input Requirements:** - Must receive JSON input (typically uploaded
    /// to S3 from a previous function) - Can be chained after transform or other
    /// functions that produce JSON output</para>
    ///
    /// <para>**Example Use Cases:** - Match product descriptions to SKU codes from
    /// a product catalog - Enrich customer data with account information - Link order
    /// line items to inventory records</para>
    ///
    /// <para>**Configuration:** - Define one or more enrichment steps - Each step
    /// extracts values, searches a collection, and injects results - Steps are executed sequentially</para>
    /// </summary>
    public EnrichConfig? Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EnrichConfig>("config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("config", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enrich")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        this.Config?.Validate();
    }

    public UpdateFunctionEnrich()
    {
        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFunctionEnrich(UpdateFunctionEnrich updateFunctionEnrich)
        : base(updateFunctionEnrich) { }
#pragma warning restore CS8618

    public UpdateFunctionEnrich(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFunctionEnrich(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFunctionEnrichFromRaw.FromRawUnchecked"/>
    public static UpdateFunctionEnrich FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFunctionEnrichFromRaw : IFromRawJson<UpdateFunctionEnrich>
{
    /// <inheritdoc/>
    public UpdateFunctionEnrich FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateFunctionEnrich.FromRawUnchecked(rawData);
}
