using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Functions.Versions;

/// <summary>
/// A version of a payload shaping function that transforms and customizes input
/// payloads using JMESPath expressions. Payload shaping allows you to extract specific
/// data, perform calculations, and reshape complex input structures into simplified,
/// standardized output formats tailored to your downstream systems or business requirements.
/// </summary>
[JsonConverter(typeof(FunctionVersionConverter))]
public record class FunctionVersion : ModelBase
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
                analyze: (_) => null,
                route: (x) => x.EmailAddress,
                send: (_) => null,
                split: (_) => null,
                join: (_) => null,
                enrich: (_) => null,
                payloadShaping: (_) => null
            );
        }
    }

    public string FunctionID
    {
        get
        {
            return Match(
                transform: (x) => x.FunctionID,
                analyze: (x) => x.FunctionID,
                route: (x) => x.FunctionID,
                send: (x) => x.FunctionID,
                split: (x) => x.FunctionID,
                join: (x) => x.FunctionID,
                enrich: (x) => x.FunctionID,
                payloadShaping: (x) => x.FunctionID
            );
        }
    }

    public string FunctionName
    {
        get
        {
            return Match(
                transform: (x) => x.FunctionName,
                analyze: (x) => x.FunctionName,
                route: (x) => x.FunctionName,
                send: (x) => x.FunctionName,
                split: (x) => x.FunctionName,
                join: (x) => x.FunctionName,
                enrich: (x) => x.FunctionName,
                payloadShaping: (x) => x.FunctionName
            );
        }
    }

    public JsonElement? OutputSchema
    {
        get
        {
            return Match<JsonElement?>(
                transform: (x) => x.OutputSchema,
                analyze: (x) => x.OutputSchema,
                route: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.OutputSchema,
                enrich: (_) => null,
                payloadShaping: (_) => null
            );
        }
    }

    public string? OutputSchemaName
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.OutputSchemaName,
                analyze: (x) => x.OutputSchemaName,
                route: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.OutputSchemaName,
                enrich: (_) => null,
                payloadShaping: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                transform: (x) => x.Type,
                analyze: (x) => x.Type,
                route: (x) => x.Type,
                send: (x) => x.Type,
                split: (x) => x.Type,
                join: (x) => x.Type,
                enrich: (x) => x.Type,
                payloadShaping: (x) => x.Type
            );
        }
    }

    public long VersionNum
    {
        get
        {
            return Match(
                transform: (x) => x.VersionNum,
                analyze: (x) => x.VersionNum,
                route: (x) => x.VersionNum,
                send: (x) => x.VersionNum,
                split: (x) => x.VersionNum,
                join: (x) => x.VersionNum,
                enrich: (x) => x.VersionNum,
                payloadShaping: (x) => x.VersionNum
            );
        }
    }

    public FunctionAudit? Audit
    {
        get
        {
            return Match<FunctionAudit?>(
                transform: (x) => x.Audit,
                analyze: (x) => x.Audit,
                route: (x) => x.Audit,
                send: (x) => x.Audit,
                split: (x) => x.Audit,
                join: (x) => x.Audit,
                enrich: (x) => x.Audit,
                payloadShaping: (x) => x.Audit
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            return Match<DateTimeOffset?>(
                transform: (x) => x.CreatedAt,
                analyze: (x) => x.CreatedAt,
                route: (x) => x.CreatedAt,
                send: (x) => x.CreatedAt,
                split: (x) => x.CreatedAt,
                join: (x) => x.CreatedAt,
                enrich: (x) => x.CreatedAt,
                payloadShaping: (x) => x.CreatedAt
            );
        }
    }

    public string? DisplayName
    {
        get
        {
            return Match<string?>(
                transform: (x) => x.DisplayName,
                analyze: (x) => x.DisplayName,
                route: (x) => x.DisplayName,
                send: (x) => x.DisplayName,
                split: (x) => x.DisplayName,
                join: (x) => x.DisplayName,
                enrich: (x) => x.DisplayName,
                payloadShaping: (x) => x.DisplayName
            );
        }
    }

    public string? Description
    {
        get
        {
            return Match<string?>(
                transform: (_) => null,
                analyze: (_) => null,
                route: (x) => x.Description,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.Description,
                enrich: (_) => null,
                payloadShaping: (_) => null
            );
        }
    }

    public FunctionVersion(Transform value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionVersion(Analyze value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionVersion(Route value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionVersion(Send value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionVersion(Split value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionVersion(Join value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionVersion(Enrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionVersion(PayloadShaping value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionVersion(JsonElement element)
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
    /// type <see cref="Analyze"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAnalyze(out var value)) {
    ///     // `value` is of type `Analyze`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAnalyze([NotNullWhen(true)] out Analyze? value)
    {
        value = this.Value as Analyze;
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
    ///     (Analyze value) =&gt; {...},
    ///     (Route value) =&gt; {...},
    ///     (Send value) =&gt; {...},
    ///     (Split value) =&gt; {...},
    ///     (Join value) =&gt; {...},
    ///     (Enrich value) =&gt; {...},
    ///     (PayloadShaping value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Transform> transform,
        Action<Analyze> analyze,
        Action<Route> route,
        Action<Send> send,
        Action<Split> split,
        Action<Join> join,
        Action<Enrich> enrich,
        Action<PayloadShaping> payloadShaping
    )
    {
        switch (this.Value)
        {
            case Transform value:
                transform(value);
                break;
            case Analyze value:
                analyze(value);
                break;
            case Route value:
                route(value);
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
            case Enrich value:
                enrich(value);
                break;
            case PayloadShaping value:
                payloadShaping(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of FunctionVersion"
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
    ///     (Transform value) =&gt; {...},
    ///     (Analyze value) =&gt; {...},
    ///     (Route value) =&gt; {...},
    ///     (Send value) =&gt; {...},
    ///     (Split value) =&gt; {...},
    ///     (Join value) =&gt; {...},
    ///     (Enrich value) =&gt; {...},
    ///     (PayloadShaping value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Transform, T> transform,
        Func<Analyze, T> analyze,
        Func<Route, T> route,
        Func<Send, T> send,
        Func<Split, T> split,
        Func<Join, T> join,
        Func<Enrich, T> enrich,
        Func<PayloadShaping, T> payloadShaping
    )
    {
        return this.Value switch
        {
            Transform value => transform(value),
            Analyze value => analyze(value),
            Route value => route(value),
            Send value => send(value),
            Split value => split(value),
            Join value => join(value),
            Enrich value => enrich(value),
            PayloadShaping value => payloadShaping(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of FunctionVersion"
            ),
        };
    }

    public static implicit operator FunctionVersion(Transform value) => new(value);

    public static implicit operator FunctionVersion(Analyze value) => new(value);

    public static implicit operator FunctionVersion(Route value) => new(value);

    public static implicit operator FunctionVersion(Send value) => new(value);

    public static implicit operator FunctionVersion(Split value) => new(value);

    public static implicit operator FunctionVersion(Join value) => new(value);

    public static implicit operator FunctionVersion(Enrich value) => new(value);

    public static implicit operator FunctionVersion(PayloadShaping value) => new(value);

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
            throw new BemInvalidDataException("Data did not match any variant of FunctionVersion");
        }
        this.Switch(
            (transform) => transform.Validate(),
            (analyze) => analyze.Validate(),
            (route) => route.Validate(),
            (send) => send.Validate(),
            (split) => split.Validate(),
            (join) => join.Validate(),
            (enrich) => enrich.Validate(),
            (payloadShaping) => payloadShaping.Validate()
        );
    }

    public virtual bool Equals(FunctionVersion? other) =>
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
            Analyze _ => 1,
            Route _ => 2,
            Send _ => 3,
            Split _ => 4,
            Join _ => 5,
            Enrich _ => 6,
            PayloadShaping _ => 7,
            _ => -1,
        };
    }
}

sealed class FunctionVersionConverter : JsonConverter<FunctionVersion>
{
    public override FunctionVersion? Read(
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
            case "analyze":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Analyze>(element, options);
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
            default:
            {
                return new FunctionVersion(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Transform, TransformFromRaw>))]
public sealed record class Transform : JsonModel
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
    /// Audit trail information for the function version.
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
    /// The date and time the function version was created.
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public Transform()
    {
        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transform(Transform transform)
        : base(transform) { }
#pragma warning restore CS8618

    public Transform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("transform");
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

[JsonConverter(typeof(JsonModelConverter<Analyze, AnalyzeFromRaw>))]
public sealed record class Analyze : JsonModel
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
    /// Audit trail information for the function version.
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
    /// The date and time the function version was created.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("analyze")))
        {
            throw new BemInvalidDataException("Invalid value given for constant");
        }
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public Analyze()
    {
        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Analyze(Analyze analyze)
        : base(analyze) { }
#pragma warning restore CS8618

    public Analyze(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Analyze(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyzeFromRaw.FromRawUnchecked"/>
    public static Analyze FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyzeFromRaw : IFromRawJson<Analyze>
{
    /// <inheritdoc/>
    public Analyze FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Analyze.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Route, RouteFromRaw>))]
public sealed record class Route : JsonModel
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
    /// Audit trail information for the function version.
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
    /// The date and time the function version was created.
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public Route()
    {
        this.Type = JsonSerializer.SerializeToElement("route");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Route(Route route)
        : base(route) { }
#pragma warning restore CS8618

    public Route(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("route");
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

[JsonConverter(typeof(JsonModelConverter<Send, SendFromRaw>))]
public sealed record class Send : JsonModel
{
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
    /// Audit trail information for the function version.
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
    /// The date and time the function version was created.
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
        _ = this.CreatedAt;
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

    public required ApiEnum<string, SplitType> SplitType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SplitType>>("splitType");
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
    /// Audit trail information for the function version.
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
    /// The date and time the function version was created.
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
        this.PrintPageSplitConfig?.Validate();
        this.SemanticPageSplitConfig?.Validate();
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
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
}

class SplitFromRaw : IFromRawJson<Split>
{
    /// <inheritdoc/>
    public Split FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Split.FromRawUnchecked(rawData);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NextFunctionID;
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

[JsonConverter(typeof(JsonModelConverter<Join, JoinFromRaw>))]
public sealed record class Join : JsonModel
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
    /// Audit trail information for the function version.
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
    /// The date and time the function version was created.
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
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

[JsonConverter(typeof(JsonModelConverter<Enrich, EnrichFromRaw>))]
public sealed record class Enrich : JsonModel
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
    /// Audit trail information for the function version.
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
    /// The date and time the function version was created.
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
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
}

class EnrichFromRaw : IFromRawJson<Enrich>
{
    /// <inheritdoc/>
    public Enrich FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Enrich.FromRawUnchecked(rawData);
}

/// <summary>
/// A version of a payload shaping function that transforms and customizes input
/// payloads using JMESPath expressions. Payload shaping allows you to extract specific
/// data, perform calculations, and reshape complex input structures into simplified,
/// standardized output formats tailored to your downstream systems or business requirements.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PayloadShaping, PayloadShapingFromRaw>))]
public sealed record class PayloadShaping : JsonModel
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
    /// Audit trail information for the function version.
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
    /// The date and time the function version was created.
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
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
}

class PayloadShapingFromRaw : IFromRawJson<PayloadShaping>
{
    /// <inheritdoc/>
    public PayloadShaping FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PayloadShaping.FromRawUnchecked(rawData);
}
