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

[JsonConverter(typeof(JsonModelConverter<VersionListResponse, VersionListResponseFromRaw>))]
public sealed record class VersionListResponse : JsonModel
{
    /// <summary>
    /// The total number of results available.
    /// </summary>
    public long? TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCount", value);
        }
    }

    public IReadOnlyList<global::Bem.Models.Functions.Versions.Version>? Versions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::Bem.Models.Functions.Versions.Version>
            >("versions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::Bem.Models.Functions.Versions.Version>?>(
                "versions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TotalCount;
        foreach (var item in this.Versions ?? [])
        {
            item.Validate();
        }
    }

    public VersionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionListResponse(VersionListResponse versionListResponse)
        : base(versionListResponse) { }
#pragma warning restore CS8618

    public VersionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionListResponseFromRaw.FromRawUnchecked"/>
    public static VersionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionListResponseFromRaw : IFromRawJson<VersionListResponse>
{
    /// <inheritdoc/>
    public VersionListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 read-side union for function versions. Same shape as the shared `FunctionVersion`
/// union but with `classify` in place of `route`.
/// </summary>
[JsonConverter(typeof(VersionConverter))]
public record class Version : ModelBase
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
                extract: (x) => x.FunctionID,
                analyze: (x) => x.FunctionID,
                classify: (x) => x.FunctionID,
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
                extract: (x) => x.FunctionName,
                analyze: (x) => x.FunctionName,
                classify: (x) => x.FunctionName,
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
                extract: (x) => x.OutputSchema,
                analyze: (x) => x.OutputSchema,
                classify: (_) => null,
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
                extract: (x) => x.OutputSchemaName,
                analyze: (x) => x.OutputSchemaName,
                classify: (_) => null,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.OutputSchemaName,
                enrich: (_) => null,
                payloadShaping: (_) => null
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
                extract: (x) => x.Type,
                analyze: (x) => x.Type,
                classify: (x) => x.Type,
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
                extract: (x) => x.VersionNum,
                analyze: (x) => x.VersionNum,
                classify: (x) => x.VersionNum,
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
                extract: (x) => x.Audit,
                analyze: (x) => x.Audit,
                classify: (x) => x.Audit,
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
                extract: (x) => x.CreatedAt,
                analyze: (x) => x.CreatedAt,
                classify: (x) => x.CreatedAt,
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
                extract: (x) => x.DisplayName,
                analyze: (x) => x.DisplayName,
                classify: (x) => x.DisplayName,
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
                extract: (_) => null,
                analyze: (_) => null,
                classify: (x) => x.Description,
                send: (_) => null,
                split: (_) => null,
                join: (x) => x.Description,
                enrich: (_) => null,
                payloadShaping: (_) => null
            );
        }
    }

    public Version(VersionTransform value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(VersionExtract value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(VersionAnalyze value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(VersionClassify value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(VersionSend value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(VersionSplit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(VersionJoin value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(VersionEnrich value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(VersionPayloadShaping value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Version(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionTransform"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTransform(out var value)) {
    ///     // `value` is of type `VersionTransform`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTransform([NotNullWhen(true)] out VersionTransform? value)
    {
        value = this.Value as VersionTransform;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionExtract"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtract(out var value)) {
    ///     // `value` is of type `VersionExtract`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtract([NotNullWhen(true)] out VersionExtract? value)
    {
        value = this.Value as VersionExtract;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionAnalyze"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAnalyze(out var value)) {
    ///     // `value` is of type `VersionAnalyze`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAnalyze([NotNullWhen(true)] out VersionAnalyze? value)
    {
        value = this.Value as VersionAnalyze;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionClassify"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClassify(out var value)) {
    ///     // `value` is of type `VersionClassify`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClassify([NotNullWhen(true)] out VersionClassify? value)
    {
        value = this.Value as VersionClassify;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionSend"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `VersionSend`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out VersionSend? value)
    {
        value = this.Value as VersionSend;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionSplit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplit(out var value)) {
    ///     // `value` is of type `VersionSplit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplit([NotNullWhen(true)] out VersionSplit? value)
    {
        value = this.Value as VersionSplit;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionJoin"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJoin(out var value)) {
    ///     // `value` is of type `VersionJoin`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJoin([NotNullWhen(true)] out VersionJoin? value)
    {
        value = this.Value as VersionJoin;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionEnrich"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrich(out var value)) {
    ///     // `value` is of type `VersionEnrich`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrich([NotNullWhen(true)] out VersionEnrich? value)
    {
        value = this.Value as VersionEnrich;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VersionPayloadShaping"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayloadShaping(out var value)) {
    ///     // `value` is of type `VersionPayloadShaping`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayloadShaping([NotNullWhen(true)] out VersionPayloadShaping? value)
    {
        value = this.Value as VersionPayloadShaping;
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
    ///     (VersionTransform value) =&gt; {...},
    ///     (VersionExtract value) =&gt; {...},
    ///     (VersionAnalyze value) =&gt; {...},
    ///     (VersionClassify value) =&gt; {...},
    ///     (VersionSend value) =&gt; {...},
    ///     (VersionSplit value) =&gt; {...},
    ///     (VersionJoin value) =&gt; {...},
    ///     (VersionEnrich value) =&gt; {...},
    ///     (VersionPayloadShaping value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<VersionTransform> transform,
        Action<VersionExtract> extract,
        Action<VersionAnalyze> analyze,
        Action<VersionClassify> classify,
        Action<VersionSend> send,
        Action<VersionSplit> split,
        Action<VersionJoin> join,
        Action<VersionEnrich> enrich,
        Action<VersionPayloadShaping> payloadShaping
    )
    {
        switch (this.Value)
        {
            case VersionTransform value:
                transform(value);
                break;
            case VersionExtract value:
                extract(value);
                break;
            case VersionAnalyze value:
                analyze(value);
                break;
            case VersionClassify value:
                classify(value);
                break;
            case VersionSend value:
                send(value);
                break;
            case VersionSplit value:
                split(value);
                break;
            case VersionJoin value:
                join(value);
                break;
            case VersionEnrich value:
                enrich(value);
                break;
            case VersionPayloadShaping value:
                payloadShaping(value);
                break;
            default:
                throw new BemInvalidDataException("Data did not match any variant of Version");
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
    ///     (VersionTransform value) =&gt; {...},
    ///     (VersionExtract value) =&gt; {...},
    ///     (VersionAnalyze value) =&gt; {...},
    ///     (VersionClassify value) =&gt; {...},
    ///     (VersionSend value) =&gt; {...},
    ///     (VersionSplit value) =&gt; {...},
    ///     (VersionJoin value) =&gt; {...},
    ///     (VersionEnrich value) =&gt; {...},
    ///     (VersionPayloadShaping value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<VersionTransform, T> transform,
        Func<VersionExtract, T> extract,
        Func<VersionAnalyze, T> analyze,
        Func<VersionClassify, T> classify,
        Func<VersionSend, T> send,
        Func<VersionSplit, T> split,
        Func<VersionJoin, T> join,
        Func<VersionEnrich, T> enrich,
        Func<VersionPayloadShaping, T> payloadShaping
    )
    {
        return this.Value switch
        {
            VersionTransform value => transform(value),
            VersionExtract value => extract(value),
            VersionAnalyze value => analyze(value),
            VersionClassify value => classify(value),
            VersionSend value => send(value),
            VersionSplit value => split(value),
            VersionJoin value => join(value),
            VersionEnrich value => enrich(value),
            VersionPayloadShaping value => payloadShaping(value),
            _ => throw new BemInvalidDataException("Data did not match any variant of Version"),
        };
    }

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionTransform value
    ) => new(value);

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionExtract value
    ) => new(value);

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionAnalyze value
    ) => new(value);

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionClassify value
    ) => new(value);

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionSend value
    ) => new(value);

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionSplit value
    ) => new(value);

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionJoin value
    ) => new(value);

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionEnrich value
    ) => new(value);

    public static implicit operator global::Bem.Models.Functions.Versions.Version(
        VersionPayloadShaping value
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
            throw new BemInvalidDataException("Data did not match any variant of Version");
        }
        this.Switch(
            (transform) => transform.Validate(),
            (extract) => extract.Validate(),
            (analyze) => analyze.Validate(),
            (classify) => classify.Validate(),
            (send) => send.Validate(),
            (split) => split.Validate(),
            (join) => join.Validate(),
            (enrich) => enrich.Validate(),
            (payloadShaping) => payloadShaping.Validate()
        );
    }

    public virtual bool Equals(global::Bem.Models.Functions.Versions.Version? other) =>
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
            VersionTransform _ => 0,
            VersionExtract _ => 1,
            VersionAnalyze _ => 2,
            VersionClassify _ => 3,
            VersionSend _ => 4,
            VersionSplit _ => 5,
            VersionJoin _ => 6,
            VersionEnrich _ => 7,
            VersionPayloadShaping _ => 8,
            _ => -1,
        };
    }
}

sealed class VersionConverter : JsonConverter<global::Bem.Models.Functions.Versions.Version>
{
    public override global::Bem.Models.Functions.Versions.Version? Read(
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
                    var deserialized = JsonSerializer.Deserialize<VersionTransform>(
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
                    var deserialized = JsonSerializer.Deserialize<VersionExtract>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<VersionAnalyze>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<VersionClassify>(
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
                    var deserialized = JsonSerializer.Deserialize<VersionSend>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<VersionSplit>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<VersionJoin>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<VersionEnrich>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<VersionPayloadShaping>(
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
                return new global::Bem.Models.Functions.Versions.Version(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Bem.Models.Functions.Versions.Version value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<VersionTransform, VersionTransformFromRaw>))]
public sealed record class VersionTransform : JsonModel
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

    public VersionTransform()
    {
        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionTransform(VersionTransform versionTransform)
        : base(versionTransform) { }
#pragma warning restore CS8618

    public VersionTransform(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("transform");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionTransform(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionTransformFromRaw.FromRawUnchecked"/>
    public static VersionTransform FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionTransformFromRaw : IFromRawJson<VersionTransform>
{
    /// <inheritdoc/>
    public VersionTransform FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionTransform.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VersionExtract, VersionExtractFromRaw>))]
public sealed record class VersionExtract : JsonModel
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
        _ = this.TabularChunkingEnabled;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("extract")))
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

    public VersionExtract()
    {
        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionExtract(VersionExtract versionExtract)
        : base(versionExtract) { }
#pragma warning restore CS8618

    public VersionExtract(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("extract");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionExtract(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionExtractFromRaw.FromRawUnchecked"/>
    public static VersionExtract FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionExtractFromRaw : IFromRawJson<VersionExtract>
{
    /// <inheritdoc/>
    public VersionExtract FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionExtract.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VersionAnalyze, VersionAnalyzeFromRaw>))]
public sealed record class VersionAnalyze : JsonModel
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public VersionAnalyze()
    {
        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionAnalyze(VersionAnalyze versionAnalyze)
        : base(versionAnalyze) { }
#pragma warning restore CS8618

    public VersionAnalyze(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("analyze");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionAnalyze(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionAnalyzeFromRaw.FromRawUnchecked"/>
    public static VersionAnalyze FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionAnalyzeFromRaw : IFromRawJson<VersionAnalyze>
{
    /// <inheritdoc/>
    public VersionAnalyze FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionAnalyze.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 read-side shape of a Classify (internally Route) function version. Mirrors {
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VersionClassify, VersionClassifyFromRaw>))]
public sealed record class VersionClassify : JsonModel
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
    public required IReadOnlyList<VersionClassifyClassification> Classifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<VersionClassifyClassification>>(
                "classifications"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<VersionClassifyClassification>>(
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Tags;
        foreach (var item in this.UsedInWorkflows ?? [])
        {
            item.Validate();
        }
    }

    public VersionClassify()
    {
        this.Type = JsonSerializer.SerializeToElement("classify");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionClassify(VersionClassify versionClassify)
        : base(versionClassify) { }
#pragma warning restore CS8618

    public VersionClassify(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("classify");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionClassify(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionClassifyFromRaw.FromRawUnchecked"/>
    public static VersionClassify FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionClassifyFromRaw : IFromRawJson<VersionClassify>
{
    /// <inheritdoc/>
    public VersionClassify FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionClassify.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<VersionClassifyClassification, VersionClassifyClassificationFromRaw>)
)]
public sealed record class VersionClassifyClassification : JsonModel
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

    public VersionClassifyClassificationOrigin? Origin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VersionClassifyClassificationOrigin>("origin");
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

    public VersionClassifyClassificationRegex? Regex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VersionClassifyClassificationRegex>("regex");
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

    public VersionClassifyClassification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionClassifyClassification(
        VersionClassifyClassification versionClassifyClassification
    )
        : base(versionClassifyClassification) { }
#pragma warning restore CS8618

    public VersionClassifyClassification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionClassifyClassification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionClassifyClassificationFromRaw.FromRawUnchecked"/>
    public static VersionClassifyClassification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VersionClassifyClassification(string name)
        : this()
    {
        this.Name = name;
    }
}

class VersionClassifyClassificationFromRaw : IFromRawJson<VersionClassifyClassification>
{
    /// <inheritdoc/>
    public VersionClassifyClassification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionClassifyClassification.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VersionClassifyClassificationOrigin,
        VersionClassifyClassificationOriginFromRaw
    >)
)]
public sealed record class VersionClassifyClassificationOrigin : JsonModel
{
    public VersionClassifyClassificationOriginEmail? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VersionClassifyClassificationOriginEmail>(
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

    public VersionClassifyClassificationOrigin() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionClassifyClassificationOrigin(
        VersionClassifyClassificationOrigin versionClassifyClassificationOrigin
    )
        : base(versionClassifyClassificationOrigin) { }
#pragma warning restore CS8618

    public VersionClassifyClassificationOrigin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionClassifyClassificationOrigin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionClassifyClassificationOriginFromRaw.FromRawUnchecked"/>
    public static VersionClassifyClassificationOrigin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionClassifyClassificationOriginFromRaw : IFromRawJson<VersionClassifyClassificationOrigin>
{
    /// <inheritdoc/>
    public VersionClassifyClassificationOrigin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionClassifyClassificationOrigin.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VersionClassifyClassificationOriginEmail,
        VersionClassifyClassificationOriginEmailFromRaw
    >)
)]
public sealed record class VersionClassifyClassificationOriginEmail : JsonModel
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

    public VersionClassifyClassificationOriginEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionClassifyClassificationOriginEmail(
        VersionClassifyClassificationOriginEmail versionClassifyClassificationOriginEmail
    )
        : base(versionClassifyClassificationOriginEmail) { }
#pragma warning restore CS8618

    public VersionClassifyClassificationOriginEmail(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionClassifyClassificationOriginEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionClassifyClassificationOriginEmailFromRaw.FromRawUnchecked"/>
    public static VersionClassifyClassificationOriginEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionClassifyClassificationOriginEmailFromRaw
    : IFromRawJson<VersionClassifyClassificationOriginEmail>
{
    /// <inheritdoc/>
    public VersionClassifyClassificationOriginEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionClassifyClassificationOriginEmail.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VersionClassifyClassificationRegex,
        VersionClassifyClassificationRegexFromRaw
    >)
)]
public sealed record class VersionClassifyClassificationRegex : JsonModel
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

    public VersionClassifyClassificationRegex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionClassifyClassificationRegex(
        VersionClassifyClassificationRegex versionClassifyClassificationRegex
    )
        : base(versionClassifyClassificationRegex) { }
#pragma warning restore CS8618

    public VersionClassifyClassificationRegex(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionClassifyClassificationRegex(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionClassifyClassificationRegexFromRaw.FromRawUnchecked"/>
    public static VersionClassifyClassificationRegex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionClassifyClassificationRegexFromRaw : IFromRawJson<VersionClassifyClassificationRegex>
{
    /// <inheritdoc/>
    public VersionClassifyClassificationRegex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionClassifyClassificationRegex.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VersionSend, VersionSendFromRaw>))]
public sealed record class VersionSend : JsonModel
{
    /// <summary>
    /// Destination type for a Send function.
    /// </summary>
    public required ApiEnum<string, VersionSendDestinationType> DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VersionSendDestinationType>>(
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

    /// <summary>
    /// Whether webhook deliveries are signed with an HMAC-SHA256 `bem-signature` header.
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

    public VersionSend()
    {
        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionSend(VersionSend versionSend)
        : base(versionSend) { }
#pragma warning restore CS8618

    public VersionSend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("send");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionSend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionSendFromRaw.FromRawUnchecked"/>
    public static VersionSend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionSendFromRaw : IFromRawJson<VersionSend>
{
    /// <inheritdoc/>
    public VersionSend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionSend.FromRawUnchecked(rawData);
}

/// <summary>
/// Destination type for a Send function.
/// </summary>
[JsonConverter(typeof(VersionSendDestinationTypeConverter))]
public enum VersionSendDestinationType
{
    Webhook,
    S3,
    GoogleDrive,
}

sealed class VersionSendDestinationTypeConverter : JsonConverter<VersionSendDestinationType>
{
    public override VersionSendDestinationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => VersionSendDestinationType.Webhook,
            "s3" => VersionSendDestinationType.S3,
            "google_drive" => VersionSendDestinationType.GoogleDrive,
            _ => (VersionSendDestinationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VersionSendDestinationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VersionSendDestinationType.Webhook => "webhook",
                VersionSendDestinationType.S3 => "s3",
                VersionSendDestinationType.GoogleDrive => "google_drive",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<VersionSplit, VersionSplitFromRaw>))]
public sealed record class VersionSplit : JsonModel
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

    public required ApiEnum<string, VersionSplitSplitType> SplitType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VersionSplitSplitType>>(
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

    public VersionSplitPrintPageSplitConfig? PrintPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VersionSplitPrintPageSplitConfig>(
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

    public VersionSplitSemanticPageSplitConfig? SemanticPageSplitConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VersionSplitSemanticPageSplitConfig>(
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

    public VersionSplit()
    {
        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionSplit(VersionSplit versionSplit)
        : base(versionSplit) { }
#pragma warning restore CS8618

    public VersionSplit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("split");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionSplit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionSplitFromRaw.FromRawUnchecked"/>
    public static VersionSplit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionSplitFromRaw : IFromRawJson<VersionSplit>
{
    /// <inheritdoc/>
    public VersionSplit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionSplit.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(VersionSplitSplitTypeConverter))]
public enum VersionSplitSplitType
{
    PrintPage,
    SemanticPage,
}

sealed class VersionSplitSplitTypeConverter : JsonConverter<VersionSplitSplitType>
{
    public override VersionSplitSplitType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "print_page" => VersionSplitSplitType.PrintPage,
            "semantic_page" => VersionSplitSplitType.SemanticPage,
            _ => (VersionSplitSplitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VersionSplitSplitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VersionSplitSplitType.PrintPage => "print_page",
                VersionSplitSplitType.SemanticPage => "semantic_page",
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
        VersionSplitPrintPageSplitConfig,
        VersionSplitPrintPageSplitConfigFromRaw
    >)
)]
public sealed record class VersionSplitPrintPageSplitConfig : JsonModel
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

    public VersionSplitPrintPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionSplitPrintPageSplitConfig(
        VersionSplitPrintPageSplitConfig versionSplitPrintPageSplitConfig
    )
        : base(versionSplitPrintPageSplitConfig) { }
#pragma warning restore CS8618

    public VersionSplitPrintPageSplitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionSplitPrintPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionSplitPrintPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static VersionSplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionSplitPrintPageSplitConfigFromRaw : IFromRawJson<VersionSplitPrintPageSplitConfig>
{
    /// <inheritdoc/>
    public VersionSplitPrintPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionSplitPrintPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VersionSplitSemanticPageSplitConfig,
        VersionSplitSemanticPageSplitConfigFromRaw
    >)
)]
public sealed record class VersionSplitSemanticPageSplitConfig : JsonModel
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

    public VersionSplitSemanticPageSplitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionSplitSemanticPageSplitConfig(
        VersionSplitSemanticPageSplitConfig versionSplitSemanticPageSplitConfig
    )
        : base(versionSplitSemanticPageSplitConfig) { }
#pragma warning restore CS8618

    public VersionSplitSemanticPageSplitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionSplitSemanticPageSplitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionSplitSemanticPageSplitConfigFromRaw.FromRawUnchecked"/>
    public static VersionSplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionSplitSemanticPageSplitConfigFromRaw : IFromRawJson<VersionSplitSemanticPageSplitConfig>
{
    /// <inheritdoc/>
    public VersionSplitSemanticPageSplitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionSplitSemanticPageSplitConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VersionJoin, VersionJoinFromRaw>))]
public sealed record class VersionJoin : JsonModel
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
    public required ApiEnum<string, VersionJoinJoinType> JoinType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VersionJoinJoinType>>("joinType");
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

    public VersionJoin()
    {
        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionJoin(VersionJoin versionJoin)
        : base(versionJoin) { }
#pragma warning restore CS8618

    public VersionJoin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("join");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionJoin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionJoinFromRaw.FromRawUnchecked"/>
    public static VersionJoin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionJoinFromRaw : IFromRawJson<VersionJoin>
{
    /// <inheritdoc/>
    public VersionJoin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionJoin.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of join to perform.
/// </summary>
[JsonConverter(typeof(VersionJoinJoinTypeConverter))]
public enum VersionJoinJoinType
{
    Standard,
}

sealed class VersionJoinJoinTypeConverter : JsonConverter<VersionJoinJoinType>
{
    public override VersionJoinJoinType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => VersionJoinJoinType.Standard,
            _ => (VersionJoinJoinType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VersionJoinJoinType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VersionJoinJoinType.Standard => "standard",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<VersionEnrich, VersionEnrichFromRaw>))]
public sealed record class VersionEnrich : JsonModel
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

    public VersionEnrich()
    {
        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionEnrich(VersionEnrich versionEnrich)
        : base(versionEnrich) { }
#pragma warning restore CS8618

    public VersionEnrich(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enrich");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionEnrich(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionEnrichFromRaw.FromRawUnchecked"/>
    public static VersionEnrich FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionEnrichFromRaw : IFromRawJson<VersionEnrich>
{
    /// <inheritdoc/>
    public VersionEnrich FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionEnrich.FromRawUnchecked(rawData);
}

/// <summary>
/// A version of a payload shaping function that transforms and customizes input
/// payloads using JMESPath expressions. Payload shaping allows you to extract specific
/// data, perform calculations, and reshape complex input structures into simplified,
/// standardized output formats tailored to your downstream systems or business requirements.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VersionPayloadShaping, VersionPayloadShapingFromRaw>))]
public sealed record class VersionPayloadShaping : JsonModel
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

    public VersionPayloadShaping()
    {
        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionPayloadShaping(VersionPayloadShaping versionPayloadShaping)
        : base(versionPayloadShaping) { }
#pragma warning restore CS8618

    public VersionPayloadShaping(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payload_shaping");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionPayloadShaping(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionPayloadShapingFromRaw.FromRawUnchecked"/>
    public static VersionPayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionPayloadShapingFromRaw : IFromRawJson<VersionPayloadShaping>
{
    /// <inheritdoc/>
    public VersionPayloadShaping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionPayloadShaping.FromRawUnchecked(rawData);
}
