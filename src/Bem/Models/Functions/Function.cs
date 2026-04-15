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
/// A function that extracts structured JSON from documents and images. Accepts a
/// wide range of input types including PDFs, images, spreadsheets, emails, and more.
/// </summary>
[JsonConverter(typeof(FunctionConverter))]
public record class Function : ModelBase
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

    public string? EmailAddress
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.EmailAddress,
                extract: (_) => null,
                analyze: (_) => null,
                route: (x) => x.EmailAddress,
                send: (_) => null,
                split: (_) => null,
                join: (_) => null,
                payloadShaping: (_) => null,
                enrich: (_) => null
            );
        }
    }

    public string FunctionID
    {
        get
        {
            return Match(
                transform: (x) => x.FunctionID,
                extract: (x) => x.FunctionID,
                analyze: (x) => x.FunctionID,
                route: (x) => x.FunctionID,
                send: (x) => x.FunctionID,
                split: (x) => x.FunctionID,
                join: (x) => x.FunctionID,
                payloadShaping: (x) => x.FunctionID,
                enrich: (x) => x.FunctionID
            );
        }
    }

    public string FunctionName
    {
        get
        {
            return Match(
                transform: (x) => x.FunctionName,
                extract: (x) => x.FunctionName,
                analyze: (x) => x.FunctionName,
                route: (x) => x.FunctionName,
                send: (x) => x.FunctionName,
                split: (x) => x.FunctionName,
                join: (x) => x.FunctionName,
                payloadShaping: (x) => x.FunctionName,
                enrich: (x) => x.FunctionName
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

    public long VersionNum
    {
        get
        {
            return Match(
                transform: (x) => x.VersionNum,
                extract: (x) => x.VersionNum,
                analyze: (x) => x.VersionNum,
                route: (x) => x.VersionNum,
                send: (x) => x.VersionNum,
                split: (x) => x.VersionNum,
                join: (x) => x.VersionNum,
                payloadShaping: (x) => x.VersionNum,
                enrich: (x) => x.VersionNum
            );
        }
    }

    public FunctionAudit? Audit
    {
        get
        {
            return Match<FunctionAudit?>(
                transform: (x) => x.Audit,
                extract: (x) => x.Audit,
                analyze: (x) => x.Audit,
                route: (x) => x.Audit,
                send: (x) => x.Audit,
                split: (x) => x.Audit,
                join: (x) => x.Audit,
                payloadShaping: (x) => x.Audit,
                enrich: (x) => x.Audit
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
                enrich: (x) => x.DisplayName
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

    public Function(FunctionTransform value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(FunctionExtract value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(FunctionAnalyze value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(FunctionRoute value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(FunctionSend value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(FunctionSplit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(FunctionJoin value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(FunctionPayloadShaping value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(FunctionEnrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Function(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionTransform"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTransform(out var value)) {
    ///     // `value` is of type `FunctionTransform`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTransform([NotNullWhen(true)] out FunctionTransform? value)
    {
        value = this.Value as FunctionTransform;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionExtract"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtract(out var value)) {
    ///     // `value` is of type `FunctionExtract`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtract([NotNullWhen(true)] out FunctionExtract? value)
    {
        value = this.Value as FunctionExtract;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionAnalyze"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAnalyze(out var value)) {
    ///     // `value` is of type `FunctionAnalyze`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAnalyze([NotNullWhen(true)] out FunctionAnalyze? value)
    {
        value = this.Value as FunctionAnalyze;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionRoute"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRoute(out var value)) {
    ///     // `value` is of type `FunctionRoute`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRoute([NotNullWhen(true)] out FunctionRoute? value)
    {
        value = this.Value as FunctionRoute;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionSend"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `FunctionSend`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out FunctionSend? value)
    {
        value = this.Value as FunctionSend;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionSplit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplit(out var value)) {
    ///     // `value` is of type `FunctionSplit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplit([NotNullWhen(true)] out FunctionSplit? value)
    {
        value = this.Value as FunctionSplit;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionJoin"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJoin(out var value)) {
    ///     // `value` is of type `FunctionJoin`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJoin([NotNullWhen(true)] out FunctionJoin? value)
    {
        value = this.Value as FunctionJoin;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionPayloadShaping"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayloadShaping(out var value)) {
    ///     // `value` is of type `FunctionPayloadShaping`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayloadShaping([NotNullWhen(true)] out FunctionPayloadShaping? value)
    {
        value = this.Value as FunctionPayloadShaping;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionEnrich"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrich(out var value)) {
    ///     // `value` is of type `FunctionEnrich`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrich([NotNullWhen(true)] out FunctionEnrich? value)
    {
        value = this.Value as FunctionEnrich;
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
    ///     (FunctionTransform value) =&gt; {...},
    ///     (FunctionExtract value) =&gt; {...},
    ///     (FunctionAnalyze value) =&gt; {...},
    ///     (FunctionRoute value) =&gt; {...},
    ///     (FunctionSend value) =&gt; {...},
    ///     (FunctionSplit value) =&gt; {...},
    ///     (FunctionJoin value) =&gt; {...},
    ///     (FunctionPayloadShaping value) =&gt; {...},
    ///     (FunctionEnrich value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<FunctionTransform> transform,
        Action<FunctionExtract> extract,
        Action<FunctionAnalyze> analyze,
        Action<FunctionRoute> route,
        Action<FunctionSend> send,
        Action<FunctionSplit> split,
        Action<FunctionJoin> join,
        Action<FunctionPayloadShaping> payloadShaping,
        Action<FunctionEnrich> enrich
    )
    {
        switch (this.Value)
        {
            case FunctionTransform value:
                transform(value);
                break;
            case FunctionExtract value:
                extract(value);
                break;
            case FunctionAnalyze value:
                analyze(value);
                break;
            case FunctionRoute value:
                route(value);
                break;
            case FunctionSend value:
                send(value);
                break;
            case FunctionSplit value:
                split(value);
                break;
            case FunctionJoin value:
                join(value);
                break;
            case FunctionPayloadShaping value:
                payloadShaping(value);
                break;
            case FunctionEnrich value:
                enrich(value);
                break;
            default:
                throw new BemInvalidDataException("Data did not match any variant of Function");
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
    ///     (FunctionTransform value) =&gt; {...},
    ///     (FunctionExtract value) =&gt; {...},
    ///     (FunctionAnalyze value) =&gt; {...},
    ///     (FunctionRoute value) =&gt; {...},
    ///     (FunctionSend value) =&gt; {...},
    ///     (FunctionSplit value) =&gt; {...},
    ///     (FunctionJoin value) =&gt; {...},
    ///     (FunctionPayloadShaping value) =&gt; {...},
    ///     (FunctionEnrich value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<FunctionTransform, T> transform,
        Func<FunctionExtract, T> extract,
        Func<FunctionAnalyze, T> analyze,
        Func<FunctionRoute, T> route,
        Func<FunctionSend, T> send,
        Func<FunctionSplit, T> split,
        Func<FunctionJoin, T> join,
        Func<FunctionPayloadShaping, T> payloadShaping,
        Func<FunctionEnrich, T> enrich
    )
    {
        return this.Value switch
        {
            FunctionTransform value => transform(value),
            FunctionExtract value => extract(value),
            FunctionAnalyze value => analyze(value),
            FunctionRoute value => route(value),
            FunctionSend value => send(value),
            FunctionSplit value => split(value),
            FunctionJoin value => join(value),
            FunctionPayloadShaping value => payloadShaping(value),
            FunctionEnrich value => enrich(value),
            _ => throw new BemInvalidDataException("Data did not match any variant of Function"),
        };
    }

    public static implicit operator Function(FunctionTransform value) => new(value);

    public static implicit operator Function(FunctionExtract value) => new(value);

    public static implicit operator Function(FunctionAnalyze value) => new(value);

    public static implicit operator Function(FunctionRoute value) => new(value);

    public static implicit operator Function(FunctionSend value) => new(value);

    public static implicit operator Function(FunctionSplit value) => new(value);

    public static implicit operator Function(FunctionJoin value) => new(value);

    public static implicit operator Function(FunctionPayloadShaping value) => new(value);

    public static implicit operator Function(FunctionEnrich value) => new(value);

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
            throw new BemInvalidDataException("Data did not match any variant of Function");
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

    public virtual bool Equals(Function? other) =>
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
            FunctionTransform _ => 0,
            FunctionExtract _ => 1,
            FunctionAnalyze _ => 2,
            FunctionRoute _ => 3,
            FunctionSend _ => 4,
            FunctionSplit _ => 5,
            FunctionJoin _ => 6,
            FunctionPayloadShaping _ => 7,
            FunctionEnrich _ => 8,
            _ => -1,
        };
    }
}

sealed class FunctionConverter : JsonConverter<Function>
{
    public override Function? Read(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionTransform>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionExtract>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionAnalyze>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionRoute>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<FunctionSend>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<FunctionSplit>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<FunctionJoin>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<FunctionPayloadShaping>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionEnrich>(element, options);
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
                return new Function(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Function value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<FunctionTransform, FunctionTransformFromRaw>))]
public sealed record class FunctionTransform : JsonModel
{
    /// <summary>
    /// Email address automatically created by bem. You can forward emails with or
    /// without attachments, to be transformed.
    /// </summary>
    public required string EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("emailAddress");
        }
        init { this._rawData.Set("emailAddress", value); }
    }

    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// Desired output structure defined in standard JSON Schema convention.
    /// </summary>
    public required JsonElement OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("outputSchema");
        }
        init { this._rawData.Set("outputSchema", value); }
    }

    /// <summary>
    /// Name of output schema object.
    /// </summary>
    public required string OutputSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outputSchemaName");
        }
        init { this._rawData.Set("outputSchemaName", value); }
    }

    /// <summary>
    /// Whether tabular chunking is enabled on the pipeline. This processes tables
    /// in CSV/Excel in row batches, rather than all rows at once.
    /// </summary>
    public required bool TabularChunkingEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tabularChunkingEnabled");
        }
        init { this._rawData.Set("tabularChunkingEnabled", value); }
    }

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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EmailAddress;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        _ = this.TabularChunkingEnabled;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("transform")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public FunctionTransform()
    {
        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionTransform(FunctionTransform functionTransform)
        : base(functionTransform) { }
#pragma warning restore CS8618

    public FunctionTransform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionTransform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionTransformFromRaw.FromRawUnchecked"/>
    public static FunctionTransform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionTransformFromRaw : IFromRawJson<FunctionTransform>
{
    /// <inheritdoc/>
    public FunctionTransform FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionTransform.FromRawUnchecked(rawData);
}

/// <summary>
/// A function that extracts structured JSON from documents and images. Accepts a
/// wide range of input types including PDFs, images, spreadsheets, emails, and more.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FunctionExtract, FunctionExtractFromRaw>))]
public sealed record class FunctionExtract : JsonModel
{
    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// Desired output structure defined in standard JSON Schema convention.
    /// </summary>
    public required JsonElement OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("outputSchema");
        }
        init { this._rawData.Set("outputSchema", value); }
    }

    /// <summary>
    /// Name of output schema object.
    /// </summary>
    public required string OutputSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outputSchemaName");
        }
        init { this._rawData.Set("outputSchemaName", value); }
    }

    /// <summary>
    /// Whether tabular chunking is enabled. When true, tables in CSV/Excel files
    /// are processed in row batches rather than all at once.
    /// </summary>
    public required bool TabularChunkingEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tabularChunkingEnabled");
        }
        init { this._rawData.Set("tabularChunkingEnabled", value); }
    }

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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        _ = this.TabularChunkingEnabled;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("extract")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public FunctionExtract()
    {
        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionExtract(FunctionExtract functionExtract)
        : base(functionExtract) { }
#pragma warning restore CS8618

    public FunctionExtract(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionExtract(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionExtractFromRaw.FromRawUnchecked"/>
    public static FunctionExtract FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionExtractFromRaw : IFromRawJson<FunctionExtract>
{
    /// <inheritdoc/>
    public FunctionExtract FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionExtract.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FunctionAnalyze, FunctionAnalyzeFromRaw>))]
public sealed record class FunctionAnalyze : JsonModel
{
    /// <summary>
    /// Whether bounding box extraction is enabled. Only applicable to analyze and
    /// extract functions. When true, the function returns the document regions (page,
    /// coordinates) from which each field was extracted.
    /// </summary>
    public required bool EnableBoundingBoxes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enableBoundingBoxes");
        }
        init { this._rawData.Set("enableBoundingBoxes", value); }
    }

    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// Desired output structure defined in standard JSON Schema convention.
    /// </summary>
    public required JsonElement OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("outputSchema");
        }
        init { this._rawData.Set("outputSchema", value); }
    }

    /// <summary>
    /// Name of output schema object.
    /// </summary>
    public required string OutputSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outputSchemaName");
        }
        init { this._rawData.Set("outputSchemaName", value); }
    }

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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EnableBoundingBoxes;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("analyze")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public FunctionAnalyze()
    {
        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionAnalyze(FunctionAnalyze functionAnalyze)
        : base(functionAnalyze) { }
#pragma warning restore CS8618

    public FunctionAnalyze(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionAnalyze(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionAnalyzeFromRaw.FromRawUnchecked"/>
    public static FunctionAnalyze FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionAnalyzeFromRaw : IFromRawJson<FunctionAnalyze>
{
    /// <inheritdoc/>
    public FunctionAnalyze FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionAnalyze.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FunctionRoute, FunctionRouteFromRaw>))]
public sealed record class FunctionRoute : JsonModel
{
    /// <summary>
    /// Description of router. Can be used to provide additional context on router's
    /// purpose and expected inputs.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Email address automatically created by bem. You can forward emails with or
    /// without attachments, to be routed.
    /// </summary>
    public required string EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("emailAddress");
        }
        init { this._rawData.Set("emailAddress", value); }
    }

    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// List of routes.
    /// </summary>
    public required IReadOnlyList<RouteListItem> Routes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RouteListItem>>("routes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RouteListItem>>(
                "routes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.EmailAddress;
        _ = this.FunctionID;
        _ = this.FunctionName;
        foreach (var item in this.Routes)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("route")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public FunctionRoute()
    {
        this.Type = JsonSerializer.SerializeToElement("route");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionRoute(FunctionRoute functionRoute)
        : base(functionRoute) { }
#pragma warning restore CS8618

    public FunctionRoute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("route");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionRoute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionRouteFromRaw.FromRawUnchecked"/>
    public static FunctionRoute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionRouteFromRaw : IFromRawJson<FunctionRoute>
{
    /// <inheritdoc/>
    public FunctionRoute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionRoute.FromRawUnchecked(rawData);
}

/// <summary>
/// A function that delivers workflow outputs to an external destination. Send functions
/// receive the output of an upstream workflow node and forward it to a webhook,
/// S3 bucket, or Google Drive folder.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FunctionSend, FunctionSendFromRaw>))]
public sealed record class FunctionSend : JsonModel
{
    /// <summary>
    /// Destination type for a Send function.
    /// </summary>
    public required ApiEnum<string, FunctionSendDestinationType> DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FunctionSendDestinationType>>(
                "destinationType"
            );
        }
        init { this._rawData.Set("destinationType", value); }
    }

    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// Google Drive folder ID. Present when destinationType is google_drive. Managed
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
    /// S3 bucket to upload the payload to. Present when destinationType is s3.
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
    /// S3 key prefix (folder path). Optional, present when destinationType is s3.
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether webhook payloads are signed with an HMAC-SHA256 `bem-signature` header.
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
    /// Webhook URL to POST the payload to. Present when destinationType is webhook.
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
        this.DestinationType.Validate();
        _ = this.FunctionID;
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("send")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.GoogleDriveFolderID;
        _ = this.S3Bucket;
        _ = this.S3Prefix;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
        _ = this.WebhookSigningEnabled;
        _ = this.WebhookUrl;
    }

    public FunctionSend()
    {
        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionSend(FunctionSend functionSend)
        : base(functionSend) { }
#pragma warning restore CS8618

    public FunctionSend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionSend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionSendFromRaw.FromRawUnchecked"/>
    public static FunctionSend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionSendFromRaw : IFromRawJson<FunctionSend>
{
    /// <inheritdoc/>
    public FunctionSend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionSend.FromRawUnchecked(rawData);
}

/// <summary>
/// Destination type for a Send function.
/// </summary>
[JsonConverter(typeof(FunctionSendDestinationTypeConverter))]
public enum FunctionSendDestinationType
{
    Webhook,
    S3,
    GoogleDrive,
}

sealed class FunctionSendDestinationTypeConverter : JsonConverter<FunctionSendDestinationType>
{
    public override FunctionSendDestinationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => FunctionSendDestinationType.Webhook,
            "s3" => FunctionSendDestinationType.S3,
            "google_drive" => FunctionSendDestinationType.GoogleDrive,
            _ => (FunctionSendDestinationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionSendDestinationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionSendDestinationType.Webhook => "webhook",
                FunctionSendDestinationType.S3 => "s3",
                FunctionSendDestinationType.GoogleDrive => "google_drive",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<FunctionSplit, FunctionSplitFromRaw>))]
public sealed record class FunctionSplit : JsonModel
{
    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// The method used to split pages.
    /// </summary>
    public required ApiEnum<string, FunctionSplitSplitType> SplitType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FunctionSplitSplitType>>(
                "splitType"
            );
        }
        init { this._rawData.Set("splitType", value); }
    }

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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// Configuration for print page splitting.
    /// </summary>
    public FunctionSplitPrintPageSplitConfig? PrintPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionSplitPrintPageSplitConfig>(
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

    /// <summary>
    /// Configuration for semantic page splitting.
    /// </summary>
    public FunctionSplitSemanticPageSplitConfig? SemanticPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionSplitSemanticPageSplitConfig>(
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionID;
        _ = this.FunctionName;
        this.SplitType.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("split")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        this.PrintPageSplitConfig?.Validate();
        this.SemanticPageSplitConfig?.Validate();
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public FunctionSplit()
    {
        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionSplit(FunctionSplit functionSplit)
        : base(functionSplit) { }
#pragma warning restore CS8618

    public FunctionSplit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionSplit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionSplitFromRaw.FromRawUnchecked"/>
    public static FunctionSplit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionSplitFromRaw : IFromRawJson<FunctionSplit>
{
    /// <inheritdoc/>
    public FunctionSplit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionSplit.FromRawUnchecked(rawData);
}

/// <summary>
/// The method used to split pages.
/// </summary>
[JsonConverter(typeof(FunctionSplitSplitTypeConverter))]
public enum FunctionSplitSplitType
{
    PrintPage,
    SemanticPage,
}

sealed class FunctionSplitSplitTypeConverter : JsonConverter<FunctionSplitSplitType>
{
    public override FunctionSplitSplitType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => FunctionSplitSplitType.PrintPage,
            "semantic_page" => FunctionSplitSplitType.SemanticPage,
            _ => (FunctionSplitSplitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionSplitSplitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionSplitSplitType.PrintPage => "print_page",
                FunctionSplitSplitType.SemanticPage => "semantic_page",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for print page splitting.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionSplitPrintPageSplitConfig,
        FunctionSplitPrintPageSplitConfigFromRaw
    >)
)]
public sealed record class FunctionSplitPrintPageSplitConfig : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NextFunctionID;
    }

    public FunctionSplitPrintPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionSplitPrintPageSplitConfig(
        FunctionSplitPrintPageSplitConfig functionSplitPrintPageSplitConfig
    )
        : base(functionSplitPrintPageSplitConfig) { }
#pragma warning restore CS8618

    public FunctionSplitPrintPageSplitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionSplitPrintPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionSplitPrintPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static FunctionSplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionSplitPrintPageSplitConfigFromRaw : IFromRawJson<FunctionSplitPrintPageSplitConfig>
{
    /// <inheritdoc/>
    public FunctionSplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionSplitPrintPageSplitConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for semantic page splitting.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionSplitSemanticPageSplitConfig,
        FunctionSplitSemanticPageSplitConfigFromRaw
    >)
)]
public sealed record class FunctionSplitSemanticPageSplitConfig : JsonModel
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

    public FunctionSplitSemanticPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionSplitSemanticPageSplitConfig(
        FunctionSplitSemanticPageSplitConfig functionSplitSemanticPageSplitConfig
    )
        : base(functionSplitSemanticPageSplitConfig) { }
#pragma warning restore CS8618

    public FunctionSplitSemanticPageSplitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionSplitSemanticPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionSplitSemanticPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static FunctionSplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionSplitSemanticPageSplitConfigFromRaw
    : IFromRawJson<FunctionSplitSemanticPageSplitConfig>
{
    /// <inheritdoc/>
    public FunctionSplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionSplitSemanticPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FunctionJoin, FunctionJoinFromRaw>))]
public sealed record class FunctionJoin : JsonModel
{
    /// <summary>
    /// Description of join function.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// The type of join to perform.
    /// </summary>
    public required ApiEnum<string, FunctionJoinJoinType> JoinType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FunctionJoinJoinType>>("joinType");
        }
        init { this._rawData.Set("joinType", value); }
    }

    /// <summary>
    /// Desired output structure defined in standard JSON Schema convention.
    /// </summary>
    public required JsonElement OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("outputSchema");
        }
        init { this._rawData.Set("outputSchema", value); }
    }

    /// <summary>
    /// Name of output schema object.
    /// </summary>
    public required string OutputSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outputSchemaName");
        }
        init { this._rawData.Set("outputSchemaName", value); }
    }

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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.FunctionID;
        _ = this.FunctionName;
        this.JoinType.Validate();
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("join")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public FunctionJoin()
    {
        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionJoin(FunctionJoin functionJoin)
        : base(functionJoin) { }
#pragma warning restore CS8618

    public FunctionJoin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionJoin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionJoinFromRaw.FromRawUnchecked"/>
    public static FunctionJoin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionJoinFromRaw : IFromRawJson<FunctionJoin>
{
    /// <inheritdoc/>
    public FunctionJoin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionJoin.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of join to perform.
/// </summary>
[JsonConverter(typeof(FunctionJoinJoinTypeConverter))]
public enum FunctionJoinJoinType
{
    Standard,
}

sealed class FunctionJoinJoinTypeConverter : JsonConverter<FunctionJoinJoinType>
{
    public override FunctionJoinJoinType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => FunctionJoinJoinType.Standard,
            _ => (FunctionJoinJoinType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionJoinJoinType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionJoinJoinType.Standard => "standard",
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
[JsonConverter(typeof(JsonModelConverter<FunctionPayloadShaping, FunctionPayloadShapingFromRaw>))]
public sealed record class FunctionPayloadShaping : JsonModel
{
    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// JMESPath expression that defines how to transform and customize the input
    /// payload structure. Payload shaping allows you to extract, reshape, and reorganize
    /// data from complex input payloads into a simplified, standardized output format.
    /// Use JMESPath syntax to select specific fields, perform calculations, and create
    /// new data structures tailored to your needs.
    /// </summary>
    public required string ShapingSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("shapingSchema");
        }
        init { this._rawData.Set("shapingSchema", value); }
    }

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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.ShapingSchema;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("payload_shaping"))
        )
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public FunctionPayloadShaping()
    {
        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionPayloadShaping(FunctionPayloadShaping functionPayloadShaping)
        : base(functionPayloadShaping) { }
#pragma warning restore CS8618

    public FunctionPayloadShaping(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionPayloadShaping(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionPayloadShapingFromRaw.FromRawUnchecked"/>
    public static FunctionPayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionPayloadShapingFromRaw : IFromRawJson<FunctionPayloadShaping>
{
    /// <inheritdoc/>
    public FunctionPayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionPayloadShaping.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FunctionEnrich, FunctionEnrichFromRaw>))]
public sealed record class FunctionEnrich : JsonModel
{
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
    public required EnrichConfig Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EnrichConfig>("config");
        }
        init { this._rawData.Set("config", value); }
    }

    /// <summary>
    /// Unique identifier of function.
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
    /// Name of function. Must be UNIQUE on a per-environment basis.
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
    /// Version number of function.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the function.
    /// </summary>
    public FunctionAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
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
    /// List of workflows that use this function.
    /// </summary>
    public IReadOnlyList<WorkflowUsageInfo>? UsedInWorkflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowUsageInfo>>(
                "usedInWorkflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowUsageInfo>?>(
                "usedInWorkflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Config.Validate();
        _ = this.FunctionID;
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enrich")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public FunctionEnrich()
    {
        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionEnrich(FunctionEnrich functionEnrich)
        : base(functionEnrich) { }
#pragma warning restore CS8618

    public FunctionEnrich(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionEnrich(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionEnrichFromRaw.FromRawUnchecked"/>
    public static FunctionEnrich FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionEnrichFromRaw : IFromRawJson<FunctionEnrich>
{
    /// <inheritdoc/>
    public FunctionEnrich FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionEnrich.FromRawUnchecked(rawData);
}
