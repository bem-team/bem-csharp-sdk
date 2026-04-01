using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Errors;

[JsonConverter(typeof(JsonModelConverter<InboundEmailEvent, InboundEmailEventFromRaw>))]
public sealed record class InboundEmailEvent : JsonModel
{
    /// <summary>
    /// The email address of the sender.
    /// </summary>
    public required string From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// The subject of the email.
    /// </summary>
    public required string Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <summary>
    /// The email address of the recipient.
    /// </summary>
    public required string To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("to");
        }
        init { this._rawData.Set("to", value); }
    }

    /// <summary>
    /// The email address of the original intended recipient if the email itself
    /// was forwarded.
    /// </summary>
    public string? DeliveredTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("deliveredTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deliveredTo", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        _ = this.Subject;
        _ = this.To;
        _ = this.DeliveredTo;
    }

    public InboundEmailEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundEmailEvent(InboundEmailEvent inboundEmailEvent)
        : base(inboundEmailEvent) { }
#pragma warning restore CS8618

    public InboundEmailEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundEmailEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundEmailEventFromRaw.FromRawUnchecked"/>
    public static InboundEmailEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundEmailEventFromRaw : IFromRawJson<InboundEmailEvent>
{
    /// <inheritdoc/>
    public InboundEmailEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundEmailEvent.FromRawUnchecked(rawData);
}
