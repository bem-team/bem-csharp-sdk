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
/// V3 read-side union. Same shape as the shared `Function` union but with `classify`
/// in place of `route`. Legacy `transform` and `analyze` functions remain readable
/// via V3.
/// </summary>
[JsonConverter(typeof(FunctionListResponseConverter))]
public record class FunctionListResponse : ModelBase
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
                classify: (x) => x.EmailAddress,
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
                classify: (x) => x.FunctionID,
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
                classify: (x) => x.FunctionName,
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
                classify: (_) => null,
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
                classify: (_) => null,
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
                classify: (_) => null,
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
                classify: (x) => x.Type,
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
                classify: (x) => x.VersionNum,
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
                classify: (x) => x.Audit,
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
                classify: (x) => x.DisplayName,
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
                classify: (x) => x.Description,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.Description,
                payloadShaping: (_) => null,
                enrich: (_) => null
            );
        }
    }

    public FunctionListResponse(FunctionListResponseTransform value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(FunctionListResponseExtract value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(FunctionListResponseAnalyze value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(FunctionListResponseClassify value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(FunctionListResponseSend value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(FunctionListResponseSplit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(FunctionListResponseJoin value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(
        FunctionListResponsePayloadShaping value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(FunctionListResponseEnrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionListResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponseTransform"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTransform(out var value)) {
    ///     // `value` is of type `FunctionListResponseTransform`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTransform([NotNullWhen(true)] out FunctionListResponseTransform? value)
    {
        value = this.Value as FunctionListResponseTransform;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponseExtract"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtract(out var value)) {
    ///     // `value` is of type `FunctionListResponseExtract`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtract([NotNullWhen(true)] out FunctionListResponseExtract? value)
    {
        value = this.Value as FunctionListResponseExtract;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponseAnalyze"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAnalyze(out var value)) {
    ///     // `value` is of type `FunctionListResponseAnalyze`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAnalyze([NotNullWhen(true)] out FunctionListResponseAnalyze? value)
    {
        value = this.Value as FunctionListResponseAnalyze;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponseClassify"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClassify(out var value)) {
    ///     // `value` is of type `FunctionListResponseClassify`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClassify([NotNullWhen(true)] out FunctionListResponseClassify? value)
    {
        value = this.Value as FunctionListResponseClassify;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponseSend"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `FunctionListResponseSend`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out FunctionListResponseSend? value)
    {
        value = this.Value as FunctionListResponseSend;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponseSplit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplit(out var value)) {
    ///     // `value` is of type `FunctionListResponseSplit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplit([NotNullWhen(true)] out FunctionListResponseSplit? value)
    {
        value = this.Value as FunctionListResponseSplit;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponseJoin"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJoin(out var value)) {
    ///     // `value` is of type `FunctionListResponseJoin`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJoin([NotNullWhen(true)] out FunctionListResponseJoin? value)
    {
        value = this.Value as FunctionListResponseJoin;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponsePayloadShaping"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayloadShaping(out var value)) {
    ///     // `value` is of type `FunctionListResponsePayloadShaping`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayloadShaping(
        [NotNullWhen(true)] out FunctionListResponsePayloadShaping? value
    )
    {
        value = this.Value as FunctionListResponsePayloadShaping;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionListResponseEnrich"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrich(out var value)) {
    ///     // `value` is of type `FunctionListResponseEnrich`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrich([NotNullWhen(true)] out FunctionListResponseEnrich? value)
    {
        value = this.Value as FunctionListResponseEnrich;
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
    ///     (FunctionListResponseTransform value) =&gt; {...},
    ///     (FunctionListResponseExtract value) =&gt; {...},
    ///     (FunctionListResponseAnalyze value) =&gt; {...},
    ///     (FunctionListResponseClassify value) =&gt; {...},
    ///     (FunctionListResponseSend value) =&gt; {...},
    ///     (FunctionListResponseSplit value) =&gt; {...},
    ///     (FunctionListResponseJoin value) =&gt; {...},
    ///     (FunctionListResponsePayloadShaping value) =&gt; {...},
    ///     (FunctionListResponseEnrich value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<FunctionListResponseTransform> transform,
        Action<FunctionListResponseExtract> extract,
        Action<FunctionListResponseAnalyze> analyze,
        Action<FunctionListResponseClassify> classify,
        Action<FunctionListResponseSend> send,
        Action<FunctionListResponseSplit> split,
        Action<FunctionListResponseJoin> join,
        Action<FunctionListResponsePayloadShaping> payloadShaping,
        Action<FunctionListResponseEnrich> enrich
    )
    {
        switch (this.Value)
        {
            case FunctionListResponseTransform value:
                transform(value);
                break;
            case FunctionListResponseExtract value:
                extract(value);
                break;
            case FunctionListResponseAnalyze value:
                analyze(value);
                break;
            case FunctionListResponseClassify value:
                classify(value);
                break;
            case FunctionListResponseSend value:
                send(value);
                break;
            case FunctionListResponseSplit value:
                split(value);
                break;
            case FunctionListResponseJoin value:
                join(value);
                break;
            case FunctionListResponsePayloadShaping value:
                payloadShaping(value);
                break;
            case FunctionListResponseEnrich value:
                enrich(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of FunctionListResponse"
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
    ///     (FunctionListResponseTransform value) =&gt; {...},
    ///     (FunctionListResponseExtract value) =&gt; {...},
    ///     (FunctionListResponseAnalyze value) =&gt; {...},
    ///     (FunctionListResponseClassify value) =&gt; {...},
    ///     (FunctionListResponseSend value) =&gt; {...},
    ///     (FunctionListResponseSplit value) =&gt; {...},
    ///     (FunctionListResponseJoin value) =&gt; {...},
    ///     (FunctionListResponsePayloadShaping value) =&gt; {...},
    ///     (FunctionListResponseEnrich value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<FunctionListResponseTransform, T> transform,
        Func<FunctionListResponseExtract, T> extract,
        Func<FunctionListResponseAnalyze, T> analyze,
        Func<FunctionListResponseClassify, T> classify,
        Func<FunctionListResponseSend, T> send,
        Func<FunctionListResponseSplit, T> split,
        Func<FunctionListResponseJoin, T> join,
        Func<FunctionListResponsePayloadShaping, T> payloadShaping,
        Func<FunctionListResponseEnrich, T> enrich
    )
    {
        return this.Value switch
        {
            FunctionListResponseTransform value => transform(value),
            FunctionListResponseExtract value => extract(value),
            FunctionListResponseAnalyze value => analyze(value),
            FunctionListResponseClassify value => classify(value),
            FunctionListResponseSend value => send(value),
            FunctionListResponseSplit value => split(value),
            FunctionListResponseJoin value => join(value),
            FunctionListResponsePayloadShaping value => payloadShaping(value),
            FunctionListResponseEnrich value => enrich(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of FunctionListResponse"
            ),
        };
    }

    public static implicit operator FunctionListResponse(FunctionListResponseTransform value) =>
        new(value);

    public static implicit operator FunctionListResponse(FunctionListResponseExtract value) =>
        new(value);

    public static implicit operator FunctionListResponse(FunctionListResponseAnalyze value) =>
        new(value);

    public static implicit operator FunctionListResponse(FunctionListResponseClassify value) =>
        new(value);

    public static implicit operator FunctionListResponse(FunctionListResponseSend value) =>
        new(value);

    public static implicit operator FunctionListResponse(FunctionListResponseSplit value) =>
        new(value);

    public static implicit operator FunctionListResponse(FunctionListResponseJoin value) =>
        new(value);

    public static implicit operator FunctionListResponse(
        FunctionListResponsePayloadShaping value
    ) => new(value);

    public static implicit operator FunctionListResponse(FunctionListResponseEnrich value) =>
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
                "Data did not match any variant of FunctionListResponse"
            );
        }
        this.Switch(
            (transform) => transform.Validate(),
            (extract) => extract.Validate(),
            (analyze) => analyze.Validate(),
            (classify) => classify.Validate(),
            (send) => send.Validate(),
            (split) => split.Validate(),
            (join) => join.Validate(),
            (payloadShaping) => payloadShaping.Validate(),
            (enrich) => enrich.Validate()
        );
    }

    public virtual bool Equals(FunctionListResponse? other) =>
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
            FunctionListResponseTransform _ => 0,
            FunctionListResponseExtract _ => 1,
            FunctionListResponseAnalyze _ => 2,
            FunctionListResponseClassify _ => 3,
            FunctionListResponseSend _ => 4,
            FunctionListResponseSplit _ => 5,
            FunctionListResponseJoin _ => 6,
            FunctionListResponsePayloadShaping _ => 7,
            FunctionListResponseEnrich _ => 8,
            _ => -1,
        };
    }
}

sealed class FunctionListResponseConverter : JsonConverter<FunctionListResponse>
{
    public override FunctionListResponse? Read(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionListResponseTransform>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionListResponseExtract>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionListResponseAnalyze>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionListResponseClassify>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionListResponseSend>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionListResponseSplit>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionListResponseJoin>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<FunctionListResponsePayloadShaping>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionListResponseEnrich>(
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
                return new FunctionListResponse(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionListResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<FunctionListResponseTransform, FunctionListResponseTransformFromRaw>)
)]
public sealed record class FunctionListResponseTransform : JsonModel
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

    public FunctionListResponseTransform()
    {
        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseTransform(
        FunctionListResponseTransform functionListResponseTransform
    )
        : base(functionListResponseTransform) { }
#pragma warning restore CS8618

    public FunctionListResponseTransform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseTransform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseTransformFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseTransform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseTransformFromRaw : IFromRawJson<FunctionListResponseTransform>
{
    /// <inheritdoc/>
    public FunctionListResponseTransform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseTransform.FromRawUnchecked(rawData);
}

/// <summary>
/// A function that extracts structured JSON from documents and images. Accepts a
/// wide range of input types including PDFs, images, spreadsheets, emails, and more.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FunctionListResponseExtract, FunctionListResponseExtractFromRaw>)
)]
public sealed record class FunctionListResponseExtract : JsonModel
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

    public FunctionListResponseExtract()
    {
        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseExtract(FunctionListResponseExtract functionListResponseExtract)
        : base(functionListResponseExtract) { }
#pragma warning restore CS8618

    public FunctionListResponseExtract(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseExtract(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseExtractFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseExtract FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseExtractFromRaw : IFromRawJson<FunctionListResponseExtract>
{
    /// <inheritdoc/>
    public FunctionListResponseExtract FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseExtract.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FunctionListResponseAnalyze, FunctionListResponseAnalyzeFromRaw>)
)]
public sealed record class FunctionListResponseAnalyze : JsonModel
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

    /// <summary>
    /// Reducing the risk of the model stopping early on long documents. Trade-off:
    /// Increases total latency.
    /// </summary>
    public required bool PreCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("preCount");
        }
        init { this._rawData.Set("preCount", value); }
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
        _ = this.PreCount;
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

    public FunctionListResponseAnalyze()
    {
        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseAnalyze(FunctionListResponseAnalyze functionListResponseAnalyze)
        : base(functionListResponseAnalyze) { }
#pragma warning restore CS8618

    public FunctionListResponseAnalyze(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseAnalyze(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseAnalyzeFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseAnalyze FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseAnalyzeFromRaw : IFromRawJson<FunctionListResponseAnalyze>
{
    /// <inheritdoc/>
    public FunctionListResponseAnalyze FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseAnalyze.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 read-side shape of a Classify (internally Route) function. Mirrors {
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FunctionListResponseClassify, FunctionListResponseClassifyFromRaw>)
)]
public sealed record class FunctionListResponseClassify : JsonModel
{
    /// <summary>
    /// V3 create/update variants of the shared function payloads.
    ///
    /// <para>The V3 Functions API no longer accepts the legacy `transform` or `analyze`
    /// function types when creating new functions or updating existing ones — both
    /// have been unified under `extract`. Existing functions of those types remain
    /// readable and callable via V3, so the V3 read-side unions still include `transform`
    /// and `analyze` variants.</para>
    ///
    /// <para>The V3 API also renames the internal `route` function type to `classify`
    /// on the wire, and the associated `routes` field to `classifications` (type
    /// `ClassificationList`). Platform-internal storage and processing still use
    /// `route` / `routes`; the rename is applied only at the V3 API boundary.V3-facing
    /// name for the list of classifications a classify function can produce.</para>
    /// </summary>
    public required IReadOnlyList<FunctionListResponseClassifyClassification> Classifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FunctionListResponseClassifyClassification>
            >("classifications");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FunctionListResponseClassifyClassification>>(
                "classifications",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Description of classifier. Can be used to provide additional context on classifier's
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
    /// without attachments, to be classified.
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
        foreach (var item in this.Classifications)
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.EmailAddress;
        _ = this.FunctionID;
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("classify")))
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

    public FunctionListResponseClassify()
    {
        this.Type = JsonSerializer.SerializeToElement("classify");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseClassify(FunctionListResponseClassify functionListResponseClassify)
        : base(functionListResponseClassify) { }
#pragma warning restore CS8618

    public FunctionListResponseClassify(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("classify");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseClassify(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseClassifyFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseClassify FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseClassifyFromRaw : IFromRawJson<FunctionListResponseClassify>
{
    /// <inheritdoc/>
    public FunctionListResponseClassify FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseClassify.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionListResponseClassifyClassification,
        FunctionListResponseClassifyClassificationFromRaw
    >)
)]
public sealed record class FunctionListResponseClassifyClassification : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

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

    public string? FunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionID", value);
        }
    }

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

    public bool? IsErrorFallback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isErrorFallback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isErrorFallback", value);
        }
    }

    public FunctionListResponseClassifyClassificationOrigin? Origin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionListResponseClassifyClassificationOrigin>(
                "origin"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("origin", value);
        }
    }

    public FunctionListResponseClassifyClassificationRegex? Regex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionListResponseClassifyClassificationRegex>(
                "regex"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("regex", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.IsErrorFallback;
        this.Origin?.Validate();
        this.Regex?.Validate();
    }

    public FunctionListResponseClassifyClassification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseClassifyClassification(
        FunctionListResponseClassifyClassification functionListResponseClassifyClassification
    )
        : base(functionListResponseClassifyClassification) { }
#pragma warning restore CS8618

    public FunctionListResponseClassifyClassification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseClassifyClassification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseClassifyClassificationFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseClassifyClassification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionListResponseClassifyClassification(string name)
        : this()
    {
        this.Name = name;
    }
}

class FunctionListResponseClassifyClassificationFromRaw
    : IFromRawJson<FunctionListResponseClassifyClassification>
{
    /// <inheritdoc/>
    public FunctionListResponseClassifyClassification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseClassifyClassification.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionListResponseClassifyClassificationOrigin,
        FunctionListResponseClassifyClassificationOriginFromRaw
    >)
)]
public sealed record class FunctionListResponseClassifyClassificationOrigin : JsonModel
{
    public FunctionListResponseClassifyClassificationOriginEmail? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionListResponseClassifyClassificationOriginEmail>(
                "email"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Email?.Validate();
    }

    public FunctionListResponseClassifyClassificationOrigin() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseClassifyClassificationOrigin(
        FunctionListResponseClassifyClassificationOrigin functionListResponseClassifyClassificationOrigin
    )
        : base(functionListResponseClassifyClassificationOrigin) { }
#pragma warning restore CS8618

    public FunctionListResponseClassifyClassificationOrigin(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseClassifyClassificationOrigin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseClassifyClassificationOriginFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseClassifyClassificationOrigin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseClassifyClassificationOriginFromRaw
    : IFromRawJson<FunctionListResponseClassifyClassificationOrigin>
{
    /// <inheritdoc/>
    public FunctionListResponseClassifyClassificationOrigin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseClassifyClassificationOrigin.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionListResponseClassifyClassificationOriginEmail,
        FunctionListResponseClassifyClassificationOriginEmailFromRaw
    >)
)]
public sealed record class FunctionListResponseClassifyClassificationOriginEmail : JsonModel
{
    public IReadOnlyList<string>? Patterns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("patterns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "patterns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Patterns;
    }

    public FunctionListResponseClassifyClassificationOriginEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseClassifyClassificationOriginEmail(
        FunctionListResponseClassifyClassificationOriginEmail functionListResponseClassifyClassificationOriginEmail
    )
        : base(functionListResponseClassifyClassificationOriginEmail) { }
#pragma warning restore CS8618

    public FunctionListResponseClassifyClassificationOriginEmail(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseClassifyClassificationOriginEmail(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseClassifyClassificationOriginEmailFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseClassifyClassificationOriginEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseClassifyClassificationOriginEmailFromRaw
    : IFromRawJson<FunctionListResponseClassifyClassificationOriginEmail>
{
    /// <inheritdoc/>
    public FunctionListResponseClassifyClassificationOriginEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseClassifyClassificationOriginEmail.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionListResponseClassifyClassificationRegex,
        FunctionListResponseClassifyClassificationRegexFromRaw
    >)
)]
public sealed record class FunctionListResponseClassifyClassificationRegex : JsonModel
{
    public IReadOnlyList<string>? Patterns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("patterns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "patterns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Patterns;
    }

    public FunctionListResponseClassifyClassificationRegex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseClassifyClassificationRegex(
        FunctionListResponseClassifyClassificationRegex functionListResponseClassifyClassificationRegex
    )
        : base(functionListResponseClassifyClassificationRegex) { }
#pragma warning restore CS8618

    public FunctionListResponseClassifyClassificationRegex(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseClassifyClassificationRegex(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseClassifyClassificationRegexFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseClassifyClassificationRegex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseClassifyClassificationRegexFromRaw
    : IFromRawJson<FunctionListResponseClassifyClassificationRegex>
{
    /// <inheritdoc/>
    public FunctionListResponseClassifyClassificationRegex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseClassifyClassificationRegex.FromRawUnchecked(rawData);
}

/// <summary>
/// A function that delivers workflow outputs to an external destination. Send functions
/// receive the output of an upstream workflow node and forward it to a webhook,
/// S3 bucket, or Google Drive folder.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FunctionListResponseSend, FunctionListResponseSendFromRaw>)
)]
public sealed record class FunctionListResponseSend : JsonModel
{
    /// <summary>
    /// Destination type for a Send function.
    /// </summary>
    public required ApiEnum<string, FunctionListResponseSendDestinationType> DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FunctionListResponseSendDestinationType>
            >("destinationType");
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

    public FunctionListResponseSend()
    {
        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseSend(FunctionListResponseSend functionListResponseSend)
        : base(functionListResponseSend) { }
#pragma warning restore CS8618

    public FunctionListResponseSend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseSend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseSendFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseSend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseSendFromRaw : IFromRawJson<FunctionListResponseSend>
{
    /// <inheritdoc/>
    public FunctionListResponseSend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseSend.FromRawUnchecked(rawData);
}

/// <summary>
/// Destination type for a Send function.
/// </summary>
[JsonConverter(typeof(FunctionListResponseSendDestinationTypeConverter))]
public enum FunctionListResponseSendDestinationType
{
    Webhook,
    S3,
    GoogleDrive,
}

sealed class FunctionListResponseSendDestinationTypeConverter
    : JsonConverter<FunctionListResponseSendDestinationType>
{
    public override FunctionListResponseSendDestinationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => FunctionListResponseSendDestinationType.Webhook,
            "s3" => FunctionListResponseSendDestinationType.S3,
            "google_drive" => FunctionListResponseSendDestinationType.GoogleDrive,
            _ => (FunctionListResponseSendDestinationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionListResponseSendDestinationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionListResponseSendDestinationType.Webhook => "webhook",
                FunctionListResponseSendDestinationType.S3 => "s3",
                FunctionListResponseSendDestinationType.GoogleDrive => "google_drive",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<FunctionListResponseSplit, FunctionListResponseSplitFromRaw>)
)]
public sealed record class FunctionListResponseSplit : JsonModel
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
    public required ApiEnum<string, FunctionListResponseSplitSplitType> SplitType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FunctionListResponseSplitSplitType>
            >("splitType");
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
    public FunctionListResponseSplitPrintPageSplitConfig? PrintPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionListResponseSplitPrintPageSplitConfig>(
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
    public FunctionListResponseSplitSemanticPageSplitConfig? SemanticPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionListResponseSplitSemanticPageSplitConfig>(
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

    public FunctionListResponseSplit()
    {
        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseSplit(FunctionListResponseSplit functionListResponseSplit)
        : base(functionListResponseSplit) { }
#pragma warning restore CS8618

    public FunctionListResponseSplit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseSplit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseSplitFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseSplit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseSplitFromRaw : IFromRawJson<FunctionListResponseSplit>
{
    /// <inheritdoc/>
    public FunctionListResponseSplit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseSplit.FromRawUnchecked(rawData);
}

/// <summary>
/// The method used to split pages.
/// </summary>
[JsonConverter(typeof(FunctionListResponseSplitSplitTypeConverter))]
public enum FunctionListResponseSplitSplitType
{
    PrintPage,
    SemanticPage,
}

sealed class FunctionListResponseSplitSplitTypeConverter
    : JsonConverter<FunctionListResponseSplitSplitType>
{
    public override FunctionListResponseSplitSplitType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => FunctionListResponseSplitSplitType.PrintPage,
            "semantic_page" => FunctionListResponseSplitSplitType.SemanticPage,
            _ => (FunctionListResponseSplitSplitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionListResponseSplitSplitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionListResponseSplitSplitType.PrintPage => "print_page",
                FunctionListResponseSplitSplitType.SemanticPage => "semantic_page",
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
        FunctionListResponseSplitPrintPageSplitConfig,
        FunctionListResponseSplitPrintPageSplitConfigFromRaw
    >)
)]
public sealed record class FunctionListResponseSplitPrintPageSplitConfig : JsonModel
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

    public FunctionListResponseSplitPrintPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseSplitPrintPageSplitConfig(
        FunctionListResponseSplitPrintPageSplitConfig functionListResponseSplitPrintPageSplitConfig
    )
        : base(functionListResponseSplitPrintPageSplitConfig) { }
#pragma warning restore CS8618

    public FunctionListResponseSplitPrintPageSplitConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseSplitPrintPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseSplitPrintPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseSplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseSplitPrintPageSplitConfigFromRaw
    : IFromRawJson<FunctionListResponseSplitPrintPageSplitConfig>
{
    /// <inheritdoc/>
    public FunctionListResponseSplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseSplitPrintPageSplitConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for semantic page splitting.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionListResponseSplitSemanticPageSplitConfig,
        FunctionListResponseSplitSemanticPageSplitConfigFromRaw
    >)
)]
public sealed record class FunctionListResponseSplitSemanticPageSplitConfig : JsonModel
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

    public FunctionListResponseSplitSemanticPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseSplitSemanticPageSplitConfig(
        FunctionListResponseSplitSemanticPageSplitConfig functionListResponseSplitSemanticPageSplitConfig
    )
        : base(functionListResponseSplitSemanticPageSplitConfig) { }
#pragma warning restore CS8618

    public FunctionListResponseSplitSemanticPageSplitConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseSplitSemanticPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseSplitSemanticPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseSplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseSplitSemanticPageSplitConfigFromRaw
    : IFromRawJson<FunctionListResponseSplitSemanticPageSplitConfig>
{
    /// <inheritdoc/>
    public FunctionListResponseSplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseSplitSemanticPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FunctionListResponseJoin, FunctionListResponseJoinFromRaw>)
)]
public sealed record class FunctionListResponseJoin : JsonModel
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
    public required ApiEnum<string, FunctionListResponseJoinJoinType> JoinType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FunctionListResponseJoinJoinType>>(
                "joinType"
            );
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

    public FunctionListResponseJoin()
    {
        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseJoin(FunctionListResponseJoin functionListResponseJoin)
        : base(functionListResponseJoin) { }
#pragma warning restore CS8618

    public FunctionListResponseJoin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseJoin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseJoinFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseJoin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseJoinFromRaw : IFromRawJson<FunctionListResponseJoin>
{
    /// <inheritdoc/>
    public FunctionListResponseJoin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseJoin.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of join to perform.
/// </summary>
[JsonConverter(typeof(FunctionListResponseJoinJoinTypeConverter))]
public enum FunctionListResponseJoinJoinType
{
    Standard,
}

sealed class FunctionListResponseJoinJoinTypeConverter
    : JsonConverter<FunctionListResponseJoinJoinType>
{
    public override FunctionListResponseJoinJoinType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => FunctionListResponseJoinJoinType.Standard,
            _ => (FunctionListResponseJoinJoinType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionListResponseJoinJoinType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionListResponseJoinJoinType.Standard => "standard",
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
    typeof(JsonModelConverter<
        FunctionListResponsePayloadShaping,
        FunctionListResponsePayloadShapingFromRaw
    >)
)]
public sealed record class FunctionListResponsePayloadShaping : JsonModel
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

    public FunctionListResponsePayloadShaping()
    {
        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponsePayloadShaping(
        FunctionListResponsePayloadShaping functionListResponsePayloadShaping
    )
        : base(functionListResponsePayloadShaping) { }
#pragma warning restore CS8618

    public FunctionListResponsePayloadShaping(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponsePayloadShaping(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponsePayloadShapingFromRaw.FromRawUnchecked"/>
    public static FunctionListResponsePayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponsePayloadShapingFromRaw : IFromRawJson<FunctionListResponsePayloadShaping>
{
    /// <inheritdoc/>
    public FunctionListResponsePayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponsePayloadShaping.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FunctionListResponseEnrich, FunctionListResponseEnrichFromRaw>)
)]
public sealed record class FunctionListResponseEnrich : JsonModel
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

    public FunctionListResponseEnrich()
    {
        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListResponseEnrich(FunctionListResponseEnrich functionListResponseEnrich)
        : base(functionListResponseEnrich) { }
#pragma warning restore CS8618

    public FunctionListResponseEnrich(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListResponseEnrich(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListResponseEnrichFromRaw.FromRawUnchecked"/>
    public static FunctionListResponseEnrich FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListResponseEnrichFromRaw : IFromRawJson<FunctionListResponseEnrich>
{
    /// <inheritdoc/>
    public FunctionListResponseEnrich FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListResponseEnrich.FromRawUnchecked(rawData);
}
