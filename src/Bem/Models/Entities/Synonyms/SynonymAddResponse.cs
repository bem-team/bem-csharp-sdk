using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Entities.Synonyms;

/// <summary>
/// One synonym attached to an entity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SynonymAddResponse, SynonymAddResponseFromRaw>))]
public sealed record class SynonymAddResponse : JsonModel
{
    /// <summary>
    /// Creation timestamp of the synonym (RFC 3339).
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Lowercased, whitespace-folded form of `text`.
    /// </summary>
    public required string NormalizedText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("normalizedText");
        }
        init { this._rawData.Set("normalizedText", value); }
    }

    /// <summary>
    /// Provenance of the synonym. `customer_defined` and `sme_approved` synonyms
    /// are deletable; `extracted` synonyms are resolver-owned and cannot be deleted.
    /// </summary>
    public required ApiEnum<string, Source> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Source>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Stable public identifier for the synonym (`esn_...`).
    /// </summary>
    public required string SynonymID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("synonymID");
        }
        init { this._rawData.Set("synonymID", value); }
    }

    /// <summary>
    /// The human-readable synonym as authored.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Optional BCP 47 locale tag, when one was supplied.
    /// </summary>
    public string? Locale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locale", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.NormalizedText;
        this.Source.Validate();
        _ = this.SynonymID;
        _ = this.Text;
        _ = this.Locale;
    }

    public SynonymAddResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SynonymAddResponse(SynonymAddResponse synonymAddResponse)
        : base(synonymAddResponse) { }
#pragma warning restore CS8618

    public SynonymAddResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SynonymAddResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SynonymAddResponseFromRaw.FromRawUnchecked"/>
    public static SynonymAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SynonymAddResponseFromRaw : IFromRawJson<SynonymAddResponse>
{
    /// <inheritdoc/>
    public SynonymAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SynonymAddResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Provenance of the synonym. `customer_defined` and `sme_approved` synonyms are
/// deletable; `extracted` synonyms are resolver-owned and cannot be deleted.
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Extracted,
    CustomerDefined,
    SmeApproved,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "extracted" => Source.Extracted,
            "customer_defined" => Source.CustomerDefined,
            "sme_approved" => Source.SmeApproved,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Extracted => "extracted",
                Source.CustomerDefined => "customer_defined",
                Source.SmeApproved => "sme_approved",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
