using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// Update a Function
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FunctionUpdateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? PathFunctionName { get; init; }

    /// <summary>
    /// V3 wire form of the Route (classify) function upsert payload. Mirrors {
    /// </summary>
    public required FunctionUpdateParamsBody Body
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClass<FunctionUpdateParamsBody>(
                this.RawBodyData,
                "RawBodyData"
            );
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public FunctionUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParams(FunctionUpdateParams functionUpdateParams)
        : base(functionUpdateParams)
    {
        this.PathFunctionName = functionUpdateParams.PathFunctionName;

        this.RawBodyData = functionUpdateParams.RawBodyData;
    }
#pragma warning restore CS8618

    public FunctionUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string pathFunctionName
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.PathFunctionName = pathFunctionName;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FunctionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string pathFunctionName
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            pathFunctionName
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PathFunctionName"] = JsonSerializer.SerializeToElement(this.PathFunctionName),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FunctionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.PathFunctionName?.Equals(other.PathFunctionName)
                ?? other.PathFunctionName == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/functions/{0}", this.PathFunctionName)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// V3 wire form of the Route (classify) function upsert payload. Mirrors {
/// </summary>
[JsonConverter(typeof(FunctionUpdateParamsBodyConverter))]
public record class FunctionUpdateParamsBody : ModelBase
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
                extract: (x) => x.Type,
                classify: (x) => x.Type,
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
                extract: (x) => x.DisplayName,
                classify: (x) => x.DisplayName,
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
                extract: (x) => x.FunctionName,
                classify: (x) => x.FunctionName,
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
                extract: (x) => x.OutputSchema,
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
                extract: (x) => x.OutputSchemaName,
                classify: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.OutputSchemaName,
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
                extract: (_) => null,
                classify: (x) => x.Description,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.Description,
                payloadShaping: (_) => null,
                enrich: (_) => null
            );
        }
    }

    public FunctionUpdateParamsBody(
        FunctionUpdateParamsBodyExtract value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionUpdateParamsBody(
        FunctionUpdateParamsBodyClassify value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionUpdateParamsBody(FunctionUpdateParamsBodySend value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionUpdateParamsBody(
        FunctionUpdateParamsBodySplit value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionUpdateParamsBody(FunctionUpdateParamsBodyJoin value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionUpdateParamsBody(
        FunctionUpdateParamsBodyPayloadShaping value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionUpdateParamsBody(
        FunctionUpdateParamsBodyEnrich value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionUpdateParamsBody(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionUpdateParamsBodyExtract"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtract(out var value)) {
    ///     // `value` is of type `FunctionUpdateParamsBodyExtract`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtract([NotNullWhen(true)] out FunctionUpdateParamsBodyExtract? value)
    {
        value = this.Value as FunctionUpdateParamsBodyExtract;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionUpdateParamsBodyClassify"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClassify(out var value)) {
    ///     // `value` is of type `FunctionUpdateParamsBodyClassify`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClassify([NotNullWhen(true)] out FunctionUpdateParamsBodyClassify? value)
    {
        value = this.Value as FunctionUpdateParamsBodyClassify;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionUpdateParamsBodySend"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `FunctionUpdateParamsBodySend`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out FunctionUpdateParamsBodySend? value)
    {
        value = this.Value as FunctionUpdateParamsBodySend;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionUpdateParamsBodySplit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplit(out var value)) {
    ///     // `value` is of type `FunctionUpdateParamsBodySplit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplit([NotNullWhen(true)] out FunctionUpdateParamsBodySplit? value)
    {
        value = this.Value as FunctionUpdateParamsBodySplit;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionUpdateParamsBodyJoin"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJoin(out var value)) {
    ///     // `value` is of type `FunctionUpdateParamsBodyJoin`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJoin([NotNullWhen(true)] out FunctionUpdateParamsBodyJoin? value)
    {
        value = this.Value as FunctionUpdateParamsBodyJoin;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionUpdateParamsBodyPayloadShaping"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayloadShaping(out var value)) {
    ///     // `value` is of type `FunctionUpdateParamsBodyPayloadShaping`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayloadShaping(
        [NotNullWhen(true)] out FunctionUpdateParamsBodyPayloadShaping? value
    )
    {
        value = this.Value as FunctionUpdateParamsBodyPayloadShaping;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionUpdateParamsBodyEnrich"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrich(out var value)) {
    ///     // `value` is of type `FunctionUpdateParamsBodyEnrich`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrich([NotNullWhen(true)] out FunctionUpdateParamsBodyEnrich? value)
    {
        value = this.Value as FunctionUpdateParamsBodyEnrich;
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
    ///     (FunctionUpdateParamsBodyExtract value) =&gt; {...},
    ///     (FunctionUpdateParamsBodyClassify value) =&gt; {...},
    ///     (FunctionUpdateParamsBodySend value) =&gt; {...},
    ///     (FunctionUpdateParamsBodySplit value) =&gt; {...},
    ///     (FunctionUpdateParamsBodyJoin value) =&gt; {...},
    ///     (FunctionUpdateParamsBodyPayloadShaping value) =&gt; {...},
    ///     (FunctionUpdateParamsBodyEnrich value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<FunctionUpdateParamsBodyExtract> extract,
        Action<FunctionUpdateParamsBodyClassify> classify,
        Action<FunctionUpdateParamsBodySend> send,
        Action<FunctionUpdateParamsBodySplit> split,
        Action<FunctionUpdateParamsBodyJoin> join,
        Action<FunctionUpdateParamsBodyPayloadShaping> payloadShaping,
        Action<FunctionUpdateParamsBodyEnrich> enrich
    )
    {
        switch (this.Value)
        {
            case FunctionUpdateParamsBodyExtract value:
                extract(value);
                break;
            case FunctionUpdateParamsBodyClassify value:
                classify(value);
                break;
            case FunctionUpdateParamsBodySend value:
                send(value);
                break;
            case FunctionUpdateParamsBodySplit value:
                split(value);
                break;
            case FunctionUpdateParamsBodyJoin value:
                join(value);
                break;
            case FunctionUpdateParamsBodyPayloadShaping value:
                payloadShaping(value);
                break;
            case FunctionUpdateParamsBodyEnrich value:
                enrich(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of FunctionUpdateParamsBody"
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
    ///     (FunctionUpdateParamsBodyExtract value) =&gt; {...},
    ///     (FunctionUpdateParamsBodyClassify value) =&gt; {...},
    ///     (FunctionUpdateParamsBodySend value) =&gt; {...},
    ///     (FunctionUpdateParamsBodySplit value) =&gt; {...},
    ///     (FunctionUpdateParamsBodyJoin value) =&gt; {...},
    ///     (FunctionUpdateParamsBodyPayloadShaping value) =&gt; {...},
    ///     (FunctionUpdateParamsBodyEnrich value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<FunctionUpdateParamsBodyExtract, T> extract,
        Func<FunctionUpdateParamsBodyClassify, T> classify,
        Func<FunctionUpdateParamsBodySend, T> send,
        Func<FunctionUpdateParamsBodySplit, T> split,
        Func<FunctionUpdateParamsBodyJoin, T> join,
        Func<FunctionUpdateParamsBodyPayloadShaping, T> payloadShaping,
        Func<FunctionUpdateParamsBodyEnrich, T> enrich
    )
    {
        return this.Value switch
        {
            FunctionUpdateParamsBodyExtract value => extract(value),
            FunctionUpdateParamsBodyClassify value => classify(value),
            FunctionUpdateParamsBodySend value => send(value),
            FunctionUpdateParamsBodySplit value => split(value),
            FunctionUpdateParamsBodyJoin value => join(value),
            FunctionUpdateParamsBodyPayloadShaping value => payloadShaping(value),
            FunctionUpdateParamsBodyEnrich value => enrich(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of FunctionUpdateParamsBody"
            ),
        };
    }

    public static implicit operator FunctionUpdateParamsBody(
        FunctionUpdateParamsBodyExtract value
    ) => new(value);

    public static implicit operator FunctionUpdateParamsBody(
        FunctionUpdateParamsBodyClassify value
    ) => new(value);

    public static implicit operator FunctionUpdateParamsBody(FunctionUpdateParamsBodySend value) =>
        new(value);

    public static implicit operator FunctionUpdateParamsBody(FunctionUpdateParamsBodySplit value) =>
        new(value);

    public static implicit operator FunctionUpdateParamsBody(FunctionUpdateParamsBodyJoin value) =>
        new(value);

    public static implicit operator FunctionUpdateParamsBody(
        FunctionUpdateParamsBodyPayloadShaping value
    ) => new(value);

    public static implicit operator FunctionUpdateParamsBody(
        FunctionUpdateParamsBodyEnrich value
    ) => new(value);

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
                "Data did not match any variant of FunctionUpdateParamsBody"
            );
        }
        this.Switch(
            (extract) => extract.Validate(),
            (classify) => classify.Validate(),
            (send) => send.Validate(),
            (split) => split.Validate(),
            (join) => join.Validate(),
            (payloadShaping) => payloadShaping.Validate(),
            (enrich) => enrich.Validate()
        );
    }

    public virtual bool Equals(FunctionUpdateParamsBody? other) =>
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
            FunctionUpdateParamsBodyExtract _ => 0,
            FunctionUpdateParamsBodyClassify _ => 1,
            FunctionUpdateParamsBodySend _ => 2,
            FunctionUpdateParamsBodySplit _ => 3,
            FunctionUpdateParamsBodyJoin _ => 4,
            FunctionUpdateParamsBodyPayloadShaping _ => 5,
            FunctionUpdateParamsBodyEnrich _ => 6,
            _ => -1,
        };
    }
}

sealed class FunctionUpdateParamsBodyConverter : JsonConverter<FunctionUpdateParamsBody>
{
    public override FunctionUpdateParamsBody? Read(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyExtract>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassify>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodySend>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodySplit>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyJoin>(
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
                        JsonSerializer.Deserialize<FunctionUpdateParamsBodyPayloadShaping>(
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
                    var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyEnrich>(
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
                return new FunctionUpdateParamsBody(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionUpdateParamsBody value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodyExtract,
        FunctionUpdateParamsBodyExtractFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodyExtract : JsonModel
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

    public FunctionUpdateParamsBodyExtract()
    {
        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyExtract(
        FunctionUpdateParamsBodyExtract functionUpdateParamsBodyExtract
    )
        : base(functionUpdateParamsBodyExtract) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyExtract(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyExtract(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyExtractFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyExtract FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodyExtractFromRaw : IFromRawJson<FunctionUpdateParamsBodyExtract>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyExtract FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyExtract.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 wire form of the Route (classify) function upsert payload. Mirrors {
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodyClassify,
        FunctionUpdateParamsBodyClassifyFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodyClassify : JsonModel
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
    public IReadOnlyList<FunctionUpdateParamsBodyClassifyClassification>? Classifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FunctionUpdateParamsBodyClassifyClassification>
            >("classifications");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FunctionUpdateParamsBodyClassifyClassification>?>(
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
        _ = this.FunctionName;
        _ = this.Tags;
    }

    public FunctionUpdateParamsBodyClassify()
    {
        this.Type = JsonSerializer.SerializeToElement("classify");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyClassify(
        FunctionUpdateParamsBodyClassify functionUpdateParamsBodyClassify
    )
        : base(functionUpdateParamsBodyClassify) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyClassify(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("classify");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyClassify(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyClassifyFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyClassify FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodyClassifyFromRaw : IFromRawJson<FunctionUpdateParamsBodyClassify>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyClassify FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyClassify.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodyClassifyClassification,
        FunctionUpdateParamsBodyClassifyClassificationFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodyClassifyClassification : JsonModel
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

    public FunctionUpdateParamsBodyClassifyClassificationOrigin? Origin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionUpdateParamsBodyClassifyClassificationOrigin>(
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

    public FunctionUpdateParamsBodyClassifyClassificationRegex? Regex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionUpdateParamsBodyClassifyClassificationRegex>(
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

    public FunctionUpdateParamsBodyClassifyClassification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyClassifyClassification(
        FunctionUpdateParamsBodyClassifyClassification functionUpdateParamsBodyClassifyClassification
    )
        : base(functionUpdateParamsBodyClassifyClassification) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyClassifyClassification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyClassifyClassification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyClassifyClassificationFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyClassifyClassification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyClassifyClassification(string name)
        : this()
    {
        this.Name = name;
    }
}

class FunctionUpdateParamsBodyClassifyClassificationFromRaw
    : IFromRawJson<FunctionUpdateParamsBodyClassifyClassification>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyClassifyClassification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyClassifyClassification.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodyClassifyClassificationOrigin,
        FunctionUpdateParamsBodyClassifyClassificationOriginFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodyClassifyClassificationOrigin : JsonModel
{
    public FunctionUpdateParamsBodyClassifyClassificationOriginEmail? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionUpdateParamsBodyClassifyClassificationOriginEmail>(
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

    public FunctionUpdateParamsBodyClassifyClassificationOrigin() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyClassifyClassificationOrigin(
        FunctionUpdateParamsBodyClassifyClassificationOrigin functionUpdateParamsBodyClassifyClassificationOrigin
    )
        : base(functionUpdateParamsBodyClassifyClassificationOrigin) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyClassifyClassificationOrigin(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyClassifyClassificationOrigin(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyClassifyClassificationOriginFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyClassifyClassificationOrigin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodyClassifyClassificationOriginFromRaw
    : IFromRawJson<FunctionUpdateParamsBodyClassifyClassificationOrigin>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyClassifyClassificationOrigin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyClassifyClassificationOrigin.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodyClassifyClassificationOriginEmail,
        FunctionUpdateParamsBodyClassifyClassificationOriginEmailFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodyClassifyClassificationOriginEmail : JsonModel
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

    public FunctionUpdateParamsBodyClassifyClassificationOriginEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyClassifyClassificationOriginEmail(
        FunctionUpdateParamsBodyClassifyClassificationOriginEmail functionUpdateParamsBodyClassifyClassificationOriginEmail
    )
        : base(functionUpdateParamsBodyClassifyClassificationOriginEmail) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyClassifyClassificationOriginEmail(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyClassifyClassificationOriginEmail(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyClassifyClassificationOriginEmailFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyClassifyClassificationOriginEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodyClassifyClassificationOriginEmailFromRaw
    : IFromRawJson<FunctionUpdateParamsBodyClassifyClassificationOriginEmail>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyClassifyClassificationOriginEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyClassifyClassificationOriginEmail.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodyClassifyClassificationRegex,
        FunctionUpdateParamsBodyClassifyClassificationRegexFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodyClassifyClassificationRegex : JsonModel
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

    public FunctionUpdateParamsBodyClassifyClassificationRegex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyClassifyClassificationRegex(
        FunctionUpdateParamsBodyClassifyClassificationRegex functionUpdateParamsBodyClassifyClassificationRegex
    )
        : base(functionUpdateParamsBodyClassifyClassificationRegex) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyClassifyClassificationRegex(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyClassifyClassificationRegex(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyClassifyClassificationRegexFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyClassifyClassificationRegex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodyClassifyClassificationRegexFromRaw
    : IFromRawJson<FunctionUpdateParamsBodyClassifyClassificationRegex>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyClassifyClassificationRegex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyClassifyClassificationRegex.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FunctionUpdateParamsBodySend, FunctionUpdateParamsBodySendFromRaw>)
)]
public sealed record class FunctionUpdateParamsBodySend : JsonModel
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
    public ApiEnum<string, FunctionUpdateParamsBodySendDestinationType>? DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FunctionUpdateParamsBodySendDestinationType>
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

    public FunctionUpdateParamsBodySend()
    {
        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodySend(FunctionUpdateParamsBodySend functionUpdateParamsBodySend)
        : base(functionUpdateParamsBodySend) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodySend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodySend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodySendFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodySend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodySendFromRaw : IFromRawJson<FunctionUpdateParamsBodySend>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodySend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodySend.FromRawUnchecked(rawData);
}

/// <summary>
/// Destination type for a Send function.
/// </summary>
[JsonConverter(typeof(FunctionUpdateParamsBodySendDestinationTypeConverter))]
public enum FunctionUpdateParamsBodySendDestinationType
{
    Webhook,
    S3,
    GoogleDrive,
}

sealed class FunctionUpdateParamsBodySendDestinationTypeConverter
    : JsonConverter<FunctionUpdateParamsBodySendDestinationType>
{
    public override FunctionUpdateParamsBodySendDestinationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => FunctionUpdateParamsBodySendDestinationType.Webhook,
            "s3" => FunctionUpdateParamsBodySendDestinationType.S3,
            "google_drive" => FunctionUpdateParamsBodySendDestinationType.GoogleDrive,
            _ => (FunctionUpdateParamsBodySendDestinationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionUpdateParamsBodySendDestinationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionUpdateParamsBodySendDestinationType.Webhook => "webhook",
                FunctionUpdateParamsBodySendDestinationType.S3 => "s3",
                FunctionUpdateParamsBodySendDestinationType.GoogleDrive => "google_drive",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<FunctionUpdateParamsBodySplit, FunctionUpdateParamsBodySplitFromRaw>)
)]
public sealed record class FunctionUpdateParamsBodySplit : JsonModel
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

    public FunctionUpdateParamsBodySplitPrintPageSplitConfig? PrintPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionUpdateParamsBodySplitPrintPageSplitConfig>(
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

    public FunctionUpdateParamsBodySplitSemanticPageSplitConfig? SemanticPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionUpdateParamsBodySplitSemanticPageSplitConfig>(
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

    public ApiEnum<string, FunctionUpdateParamsBodySplitSplitType>? SplitType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FunctionUpdateParamsBodySplitSplitType>
            >("splitType");
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

    public FunctionUpdateParamsBodySplit()
    {
        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodySplit(
        FunctionUpdateParamsBodySplit functionUpdateParamsBodySplit
    )
        : base(functionUpdateParamsBodySplit) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodySplit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodySplit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodySplitFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodySplit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodySplitFromRaw : IFromRawJson<FunctionUpdateParamsBodySplit>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodySplit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodySplit.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodySplitPrintPageSplitConfig,
        FunctionUpdateParamsBodySplitPrintPageSplitConfigFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodySplitPrintPageSplitConfig : JsonModel
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

    public FunctionUpdateParamsBodySplitPrintPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodySplitPrintPageSplitConfig(
        FunctionUpdateParamsBodySplitPrintPageSplitConfig functionUpdateParamsBodySplitPrintPageSplitConfig
    )
        : base(functionUpdateParamsBodySplitPrintPageSplitConfig) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodySplitPrintPageSplitConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodySplitPrintPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodySplitPrintPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodySplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodySplitPrintPageSplitConfigFromRaw
    : IFromRawJson<FunctionUpdateParamsBodySplitPrintPageSplitConfig>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodySplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodySplitPrintPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodySplitSemanticPageSplitConfig,
        FunctionUpdateParamsBodySplitSemanticPageSplitConfigFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodySplitSemanticPageSplitConfig : JsonModel
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

    public FunctionUpdateParamsBodySplitSemanticPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodySplitSemanticPageSplitConfig(
        FunctionUpdateParamsBodySplitSemanticPageSplitConfig functionUpdateParamsBodySplitSemanticPageSplitConfig
    )
        : base(functionUpdateParamsBodySplitSemanticPageSplitConfig) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodySplitSemanticPageSplitConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodySplitSemanticPageSplitConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodySplitSemanticPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodySplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodySplitSemanticPageSplitConfigFromRaw
    : IFromRawJson<FunctionUpdateParamsBodySplitSemanticPageSplitConfig>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodySplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodySplitSemanticPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FunctionUpdateParamsBodySplitSplitTypeConverter))]
public enum FunctionUpdateParamsBodySplitSplitType
{
    PrintPage,
    SemanticPage,
}

sealed class FunctionUpdateParamsBodySplitSplitTypeConverter
    : JsonConverter<FunctionUpdateParamsBodySplitSplitType>
{
    public override FunctionUpdateParamsBodySplitSplitType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => FunctionUpdateParamsBodySplitSplitType.PrintPage,
            "semantic_page" => FunctionUpdateParamsBodySplitSplitType.SemanticPage,
            _ => (FunctionUpdateParamsBodySplitSplitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionUpdateParamsBodySplitSplitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionUpdateParamsBodySplitSplitType.PrintPage => "print_page",
                FunctionUpdateParamsBodySplitSplitType.SemanticPage => "semantic_page",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<FunctionUpdateParamsBodyJoin, FunctionUpdateParamsBodyJoinFromRaw>)
)]
public sealed record class FunctionUpdateParamsBodyJoin : JsonModel
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
    public ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType>? JoinType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType>
            >("joinType");
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

    public FunctionUpdateParamsBodyJoin()
    {
        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyJoin(FunctionUpdateParamsBodyJoin functionUpdateParamsBodyJoin)
        : base(functionUpdateParamsBodyJoin) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyJoin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyJoin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyJoinFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyJoin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodyJoinFromRaw : IFromRawJson<FunctionUpdateParamsBodyJoin>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyJoin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyJoin.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of join to perform.
/// </summary>
[JsonConverter(typeof(FunctionUpdateParamsBodyJoinJoinTypeConverter))]
public enum FunctionUpdateParamsBodyJoinJoinType
{
    Standard,
}

sealed class FunctionUpdateParamsBodyJoinJoinTypeConverter
    : JsonConverter<FunctionUpdateParamsBodyJoinJoinType>
{
    public override FunctionUpdateParamsBodyJoinJoinType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => FunctionUpdateParamsBodyJoinJoinType.Standard,
            _ => (FunctionUpdateParamsBodyJoinJoinType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionUpdateParamsBodyJoinJoinType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionUpdateParamsBodyJoinJoinType.Standard => "standard",
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
        FunctionUpdateParamsBodyPayloadShaping,
        FunctionUpdateParamsBodyPayloadShapingFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodyPayloadShaping : JsonModel
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

    public FunctionUpdateParamsBodyPayloadShaping()
    {
        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyPayloadShaping(
        FunctionUpdateParamsBodyPayloadShaping functionUpdateParamsBodyPayloadShaping
    )
        : base(functionUpdateParamsBodyPayloadShaping) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyPayloadShaping(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyPayloadShaping(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyPayloadShapingFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyPayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodyPayloadShapingFromRaw
    : IFromRawJson<FunctionUpdateParamsBodyPayloadShaping>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyPayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyPayloadShaping.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateParamsBodyEnrich,
        FunctionUpdateParamsBodyEnrichFromRaw
    >)
)]
public sealed record class FunctionUpdateParamsBodyEnrich : JsonModel
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

    public FunctionUpdateParamsBodyEnrich()
    {
        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParamsBodyEnrich(
        FunctionUpdateParamsBodyEnrich functionUpdateParamsBodyEnrich
    )
        : base(functionUpdateParamsBodyEnrich) { }
#pragma warning restore CS8618

    public FunctionUpdateParamsBodyEnrich(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParamsBodyEnrich(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateParamsBodyEnrichFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateParamsBodyEnrich FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateParamsBodyEnrichFromRaw : IFromRawJson<FunctionUpdateParamsBodyEnrich>
{
    /// <inheritdoc/>
    public FunctionUpdateParamsBodyEnrich FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateParamsBodyEnrich.FromRawUnchecked(rawData);
}
