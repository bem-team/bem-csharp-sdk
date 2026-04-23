using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Events;

/// <summary>
/// Echoed response after a correction is recorded.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EventSubmitFeedbackResponse, EventSubmitFeedbackResponseFromRaw>)
)]
public sealed record class EventSubmitFeedbackResponse : JsonModel
{
    public required JsonElement Correction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("correction");
        }
        init { this._rawData.Set("correction", value); }
    }

    /// <summary>
    /// Server timestamp when the correction was persisted (RFC 3339).
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
    /// Function types that support feedback submission.
    /// </summary>
    public required ApiEnum<string, FunctionType> FunctionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FunctionType>>("functionType");
        }
        init { this._rawData.Set("functionType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Correction;
        _ = this.CreatedAt;
        _ = this.EventID;
        this.FunctionType.Validate();
    }

    public EventSubmitFeedbackResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventSubmitFeedbackResponse(EventSubmitFeedbackResponse eventSubmitFeedbackResponse)
        : base(eventSubmitFeedbackResponse) { }
#pragma warning restore CS8618

    public EventSubmitFeedbackResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventSubmitFeedbackResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventSubmitFeedbackResponseFromRaw.FromRawUnchecked"/>
    public static EventSubmitFeedbackResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventSubmitFeedbackResponseFromRaw : IFromRawJson<EventSubmitFeedbackResponse>
{
    /// <inheritdoc/>
    public EventSubmitFeedbackResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventSubmitFeedbackResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Function types that support feedback submission.
/// </summary>
[JsonConverter(typeof(FunctionTypeConverter))]
public enum FunctionType
{
    Extract,
    Classify,
    Join,
}

sealed class FunctionTypeConverter : JsonConverter<FunctionType>
{
    public override FunctionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "extract" => FunctionType.Extract,
            "classify" => FunctionType.Classify,
            "join" => FunctionType.Join,
            _ => (FunctionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionType.Extract => "extract",
                FunctionType.Classify => "classify",
                FunctionType.Join => "join",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
