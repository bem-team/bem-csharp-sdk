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
/// V3 wire form of the classify function create payload.
/// </summary>
[JsonConverter(typeof(CreateFunctionConverter))]
public record class CreateFunction : ModelBase
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

    public string FunctionName
    {
        get
        {
            return Match(
                extract: (x) => x.FunctionName,
                classify: (x) => x.FunctionName,
                send: (x) => x.FunctionName,
                split: (x) => x.FunctionName,
                join: (x) => x.FunctionName,
                payloadShaping: (x) => x.FunctionName,
                enrich: (x) => x.FunctionName,
                parse: (x) => x.FunctionName
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                extract: (x) => x.Type,
                classify: (x) => x.Type,
                send: (x) => x.Type,
                split: (x) => x.Type,
                join: (x) => x.Type,
                payloadShaping: (x) => x.Type,
                enrich: (x) => x.Type,
                parse: (x) => x.Type
            );
        }
    }

    public string? DisplayName
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.DisplayName,
                classify: (x) => x.DisplayName,
                send: (x) => x.DisplayName,
                split: (x) => x.DisplayName,
                join: (x) => x.DisplayName,
                payloadShaping: (x) => x.DisplayName,
                enrich: (x) => x.DisplayName,
                parse: (x) => x.DisplayName
            );
        }
    }

    public JsonElement? OutputSchema
    {
        get
        {
            return Match<JsonElement?>(
                extract: (x) => x.OutputSchema,
                classify: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.OutputSchema,
                payloadShaping: (_) => null,
                enrich: (_) => null,
                parse: (_) => null
            );
        }
    }

    public string? OutputSchemaName
    {
        get
        {
            return Match<string?>(
                extract: (x) => x.OutputSchemaName,
                classify: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.OutputSchemaName,
                payloadShaping: (_) => null,
                enrich: (_) => null,
                parse: (_) => null
            );
        }
    }

    public string? Description
    {
        get
        {
            return Match<string?>(
                extract: (_) => null,
                classify: (x) => x.Description,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.Description,
                payloadShaping: (_) => null,
                enrich: (_) => null,
                parse: (_) => null
            );
        }
    }

    public CreateFunction(Extract value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateFunction(Classify value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateFunction(Send value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateFunction(Split value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateFunction(Join value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateFunction(PayloadShaping value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateFunction(Enrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateFunction(Parse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateFunction(JsonElement element)
    {
        this._element = element;
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
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Split"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplit(out var value)) {
    ///     // `value` is of type `Split`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplit([NotNullWhen(true)] out Split? value)
    {
        value = this.Value as Split;
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
    /// type <see cref="PayloadShaping"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayloadShaping(out var value)) {
    ///     // `value` is of type `PayloadShaping`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayloadShaping([NotNullWhen(true)] out PayloadShaping? value)
    {
        value = this.Value as PayloadShaping;
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
    /// type <see cref="Parse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickParse(out var value)) {
    ///     // `value` is of type `Parse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickParse([NotNullWhen(true)] out Parse? value)
    {
        value = this.Value as Parse;
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
    ///     (Extract value) =&gt; {...},
    ///     (Classify value) =&gt; {...},
    ///     (Send value) =&gt; {...},
    ///     (Split value) =&gt; {...},
    ///     (Join value) =&gt; {...},
    ///     (PayloadShaping value) =&gt; {...},
    ///     (Enrich value) =&gt; {...},
    ///     (Parse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Extract> extract,
        Action<Classify> classify,
        Action<Send> send,
        Action<Split> split,
        Action<Join> join,
        Action<PayloadShaping> payloadShaping,
        Action<Enrich> enrich,
        Action<Parse> parse
    )
    {
        switch (this.Value)
        {
            case Extract value:
                extract(value);
                break;
            case Classify value:
                classify(value);
                break;
            case Send value:
                send(value);
                break;
            case Split value:
                split(value);
                break;
            case Join value:
                join(value);
                break;
            case PayloadShaping value:
                payloadShaping(value);
                break;
            case Enrich value:
                enrich(value);
                break;
            case Parse value:
                parse(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of CreateFunction"
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
    ///     (Extract value) =&gt; {...},
    ///     (Classify value) =&gt; {...},
    ///     (Send value) =&gt; {...},
    ///     (Split value) =&gt; {...},
    ///     (Join value) =&gt; {...},
    ///     (PayloadShaping value) =&gt; {...},
    ///     (Enrich value) =&gt; {...},
    ///     (Parse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Extract, T> extract,
        Func<Classify, T> classify,
        Func<Send, T> send,
        Func<Split, T> split,
        Func<Join, T> join,
        Func<PayloadShaping, T> payloadShaping,
        Func<Enrich, T> enrich,
        Func<Parse, T> parse
    )
    {
        return this.Value switch
        {
            Extract value => extract(value),
            Classify value => classify(value),
            Send value => send(value),
            Split value => split(value),
            Join value => join(value),
            PayloadShaping value => payloadShaping(value),
            Enrich value => enrich(value),
            Parse value => parse(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of CreateFunction"
            ),
        };
    }

    public static implicit operator CreateFunction(Extract value) => new(value);

    public static implicit operator CreateFunction(Classify value) => new(value);

    public static implicit operator CreateFunction(Send value) => new(value);

    public static implicit operator CreateFunction(Split value) => new(value);

    public static implicit operator CreateFunction(Join value) => new(value);

    public static implicit operator CreateFunction(PayloadShaping value) => new(value);

    public static implicit operator CreateFunction(Enrich value) => new(value);

    public static implicit operator CreateFunction(Parse value) => new(value);

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
            throw new BemInvalidDataException("Data did not match any variant of CreateFunction");
        }
        this.Switch(
            (extract) => extract.Validate(),
            (classify) => classify.Validate(),
            (send) => send.Validate(),
            (split) => split.Validate(),
            (join) => join.Validate(),
            (payloadShaping) => payloadShaping.Validate(),
            (enrich) => enrich.Validate(),
            (parse) => parse.Validate()
        );
    }

    public virtual bool Equals(CreateFunction? other) =>
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
            Extract _ => 0,
            Classify _ => 1,
            Send _ => 2,
            Split _ => 3,
            Join _ => 4,
            PayloadShaping _ => 5,
            Enrich _ => 6,
            Parse _ => 7,
            _ => -1,
        };
    }
}

sealed class CreateFunctionConverter : JsonConverter<CreateFunction>
{
    public override CreateFunction? Read(
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
            case "split":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Split>(element, options);
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
            case "payload_shaping":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PayloadShaping>(element, options);
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
            case "parse":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Parse>(element, options);
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
                return new CreateFunction(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Extract, ExtractFromRaw>))]
public sealed record class Extract : JsonModel
{
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
    /// Whether bounding box extraction is enabled. Applies to vision input types
    /// (pdf, png, jpeg, heic, heif, webp) that dispatch through the analyze path.
    /// When true, the function returns the document regions (page, coordinates) from
    /// which each field was extracted. Enabling this automatically configures the
    /// function to use the bounding box model. Disabling resets to the default.
    /// </summary>
    public bool? EnableBoundingBoxes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enableBoundingBoxes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enableBoundingBoxes", value);
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
    /// Reducing the risk of the model stopping early on long documents. Trade-off:
    /// Increases total latency. Compatible with `enableBoundingBoxes`.
    /// </summary>
    public bool? PreCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preCount", value);
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
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("extract")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        _ = this.EnableBoundingBoxes;
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        _ = this.PreCount;
        _ = this.TabularChunkingEnabled;
        _ = this.Tags;
    }

    public Extract()
    {
        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Extract(Extract extract)
        : base(extract) { }
#pragma warning restore CS8618

    public Extract(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("extract");
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

    [SetsRequiredMembers]
    public Extract(string functionName)
        : this()
    {
        this.FunctionName = functionName;
    }
}

class ExtractFromRaw : IFromRawJson<Extract>
{
    /// <inheritdoc/>
    public Extract FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Extract.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 wire form of the classify function create payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Classify, ClassifyFromRaw>))]
public sealed record class Classify : JsonModel
{
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
    /// List of classifications a classify function can produce. Shares the underlying
    /// route list shape.
    /// </summary>
    public IReadOnlyList<ClassificationListItem>? Classifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ClassificationListItem>>(
                "classifications"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ClassificationListItem>?>(
                "classifications",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Description of classifier. Can be used to provide additional context on classifier's
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
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("classify")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Classifications ?? [])
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.Tags;
    }

    public Classify()
    {
        this.Type = JsonSerializer.SerializeToElement("classify");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Classify(Classify classify)
        : base(classify) { }
#pragma warning restore CS8618

    public Classify(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("classify");
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

    [SetsRequiredMembers]
    public Classify(string functionName)
        : this()
    {
        this.FunctionName = functionName;
    }
}

class ClassifyFromRaw : IFromRawJson<Classify>
{
    /// <inheritdoc/>
    public Classify FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Classify.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Send, SendFromRaw>))]
public sealed record class Send : JsonModel
{
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
    /// Destination type for a Send function.
    /// </summary>
    public ApiEnum<string, DestinationType>? DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DestinationType>>(
                "destinationType"
            );
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
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("send")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        this.DestinationType?.Validate();
        _ = this.DisplayName;
        _ = this.GoogleDriveFolderID;
        _ = this.S3Bucket;
        _ = this.S3Prefix;
        _ = this.Tags;
        _ = this.WebhookSigningEnabled;
        _ = this.WebhookUrl;
    }

    public Send()
    {
        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Send(Send send)
        : base(send) { }
#pragma warning restore CS8618

    public Send(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("send");
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

    [SetsRequiredMembers]
    public Send(string functionName)
        : this()
    {
        this.FunctionName = functionName;
    }
}

class SendFromRaw : IFromRawJson<Send>
{
    /// <inheritdoc/>
    public Send FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Send.FromRawUnchecked(rawData);
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

[JsonConverter(typeof(JsonModelConverter<Split, SplitFromRaw>))]
public sealed record class Split : JsonModel
{
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

    public PrintPageSplitConfig? PrintPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PrintPageSplitConfig>("printPageSplitConfig");
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

    public SemanticPageSplitConfig? SemanticPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SemanticPageSplitConfig>(
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

    public ApiEnum<string, SplitType>? SplitType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SplitType>>("splitType");
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
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("split")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        this.PrintPageSplitConfig?.Validate();
        this.SemanticPageSplitConfig?.Validate();
        this.SplitType?.Validate();
        _ = this.Tags;
    }

    public Split()
    {
        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Split(Split split)
        : base(split) { }
#pragma warning restore CS8618

    public Split(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Split(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitFromRaw.FromRawUnchecked"/>
    public static Split FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Split(string functionName)
        : this()
    {
        this.FunctionName = functionName;
    }
}

class SplitFromRaw : IFromRawJson<Split>
{
    /// <inheritdoc/>
    public Split FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Split.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PrintPageSplitConfig, PrintPageSplitConfigFromRaw>))]
public sealed record class PrintPageSplitConfig : JsonModel
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

    public PrintPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrintPageSplitConfig(PrintPageSplitConfig printPageSplitConfig)
        : base(printPageSplitConfig) { }
#pragma warning restore CS8618

    public PrintPageSplitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PrintPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrintPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static PrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrintPageSplitConfigFromRaw : IFromRawJson<PrintPageSplitConfig>
{
    /// <inheritdoc/>
    public PrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PrintPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SemanticPageSplitConfig, SemanticPageSplitConfigFromRaw>))]
public sealed record class SemanticPageSplitConfig : JsonModel
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

    public SemanticPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SemanticPageSplitConfig(SemanticPageSplitConfig semanticPageSplitConfig)
        : base(semanticPageSplitConfig) { }
#pragma warning restore CS8618

    public SemanticPageSplitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SemanticPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SemanticPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static SemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SemanticPageSplitConfigFromRaw : IFromRawJson<SemanticPageSplitConfig>
{
    /// <inheritdoc/>
    public SemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SemanticPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SplitTypeConverter))]
public enum SplitType
{
    PrintPage,
    SemanticPage,
}

sealed class SplitTypeConverter : JsonConverter<SplitType>
{
    public override SplitType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => SplitType.PrintPage,
            "semantic_page" => SplitType.SemanticPage,
            _ => (SplitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitType.PrintPage => "print_page",
                SplitType.SemanticPage => "semantic_page",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Join, JoinFromRaw>))]
public sealed record class Join : JsonModel
{
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
    /// The type of join to perform.
    /// </summary>
    public ApiEnum<string, JoinType>? JoinType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JoinType>>("joinType");
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
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("join")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.Description;
        _ = this.DisplayName;
        this.JoinType?.Validate();
        _ = this.OutputSchema;
        _ = this.OutputSchemaName;
        _ = this.Tags;
    }

    public Join()
    {
        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Join(Join join)
        : base(join) { }
#pragma warning restore CS8618

    public Join(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("join");
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

    [SetsRequiredMembers]
    public Join(string functionName)
        : this()
    {
        this.FunctionName = functionName;
    }
}

class JoinFromRaw : IFromRawJson<Join>
{
    /// <inheritdoc/>
    public Join FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Join.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of join to perform.
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

[JsonConverter(typeof(JsonModelConverter<PayloadShaping, PayloadShapingFromRaw>))]
public sealed record class PayloadShaping : JsonModel
{
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
        _ = this.FunctionName;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("payload_shaping"))
        )
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        _ = this.ShapingSchema;
        _ = this.Tags;
    }

    public PayloadShaping()
    {
        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayloadShaping(PayloadShaping payloadShaping)
        : base(payloadShaping) { }
#pragma warning restore CS8618

    public PayloadShaping(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayloadShaping(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayloadShapingFromRaw.FromRawUnchecked"/>
    public static PayloadShaping FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PayloadShaping(string functionName)
        : this()
    {
        this.FunctionName = functionName;
    }
}

class PayloadShapingFromRaw : IFromRawJson<PayloadShaping>
{
    /// <inheritdoc/>
    public PayloadShaping FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PayloadShaping.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Enrich, EnrichFromRaw>))]
public sealed record class Enrich : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enrich")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        this.Config?.Validate();
        _ = this.DisplayName;
        _ = this.Tags;
    }

    public Enrich()
    {
        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Enrich(Enrich enrich)
        : base(enrich) { }
#pragma warning restore CS8618

    public Enrich(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enrich");
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

    [SetsRequiredMembers]
    public Enrich(string functionName)
        : this()
    {
        this.FunctionName = functionName;
    }
}

class EnrichFromRaw : IFromRawJson<Enrich>
{
    /// <inheritdoc/>
    public Enrich FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Enrich.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Parse, ParseFromRaw>))]
public sealed record class Parse : JsonModel
{
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
    /// Per-version configuration for a Parse function.
    ///
    /// <para>Parse renders document pages (PDF, image) via vision LLM and emits structured
    /// JSON. The two toggles below independently control entity extraction (a per-call
    /// output concern) and cross-document memory linking (an environment-wide concern).</para>
    /// </summary>
    public ParseConfig? ParseConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParseConfig>("parseConfig");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("parseConfig", value);
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
        _ = this.FunctionName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("parse")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisplayName;
        this.ParseConfig?.Validate();
        _ = this.Tags;
    }

    public Parse()
    {
        this.Type = JsonSerializer.SerializeToElement("parse");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Parse(Parse parse)
        : base(parse) { }
#pragma warning restore CS8618

    public Parse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("parse");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Parse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParseFromRaw.FromRawUnchecked"/>
    public static Parse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Parse(string functionName)
        : this()
    {
        this.FunctionName = functionName;
    }
}

class ParseFromRaw : IFromRawJson<Parse>
{
    /// <inheritdoc/>
    public Parse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Parse.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-version configuration for a Parse function.
///
/// <para>Parse renders document pages (PDF, image) via vision LLM and emits structured
/// JSON. The two toggles below independently control entity extraction (a per-call
/// output concern) and cross-document memory linking (an environment-wide concern).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParseConfig, ParseConfigFromRaw>))]
public sealed record class ParseConfig : JsonModel
{
    /// <summary>
    /// When true, extract named entities (people, organizations, products, studies,
    /// identifiers, etc.) and the relationships between them, and dedupe by canonical
    /// name within the document. When false, only `sections[]` is extracted; `entities[]`
    /// and `relationships[]` come back empty in the parse output. Defaults to true.
    /// </summary>
    public bool? ExtractEntities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("extractEntities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extractEntities", value);
        }
    }

    /// <summary>
    /// When true, link this document's entities to entities seen in earlier documents
    /// in this environment, building one canonical record per real-world thing across
    /// the corpus. Visible in the Memory tab and queryable via `POST /v3/fs` (op=find
    /// / open / xref). Doesn't change this call's parse output. Requires `extractEntities=true`.
    /// Defaults to true.
    /// </summary>
    public bool? LinkAcrossDocuments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("linkAcrossDocuments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("linkAcrossDocuments", value);
        }
    }

    /// <summary>
    /// Optional JSONSchema. When provided, each chunk performs schema-guided extraction.
    /// When absent, chunks perform open-ended discovery and return sections, entities,
    /// and relationships per the discovery schema.
    /// </summary>
    public JsonElement? Schema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("schema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("schema", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExtractEntities;
        _ = this.LinkAcrossDocuments;
        _ = this.Schema;
    }

    public ParseConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParseConfig(ParseConfig parseConfig)
        : base(parseConfig) { }
#pragma warning restore CS8618

    public ParseConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParseConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParseConfigFromRaw.FromRawUnchecked"/>
    public static ParseConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParseConfigFromRaw : IFromRawJson<ParseConfig>
{
    /// <inheritdoc/>
    public ParseConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ParseConfig.FromRawUnchecked(rawData);
}
