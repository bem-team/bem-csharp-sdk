using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.WebhookSecret;

/// <summary>
/// Webhook signing secret used to verify `bem-signature` headers on delivered webhooks.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookSecretRetrieveResponse, WebhookSecretRetrieveResponseFromRaw>)
)]
public sealed record class WebhookSecretRetrieveResponse : JsonModel
{
    /// <summary>
    /// The signing secret value. Store this securely — it is shown in full only
    /// on generation.
    /// </summary>
    public required string Secret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secret");
        }
        init { this._rawData.Set("secret", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Secret;
    }

    public WebhookSecretRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookSecretRetrieveResponse(
        WebhookSecretRetrieveResponse webhookSecretRetrieveResponse
    )
        : base(webhookSecretRetrieveResponse) { }
#pragma warning restore CS8618

    public WebhookSecretRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookSecretRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookSecretRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WebhookSecretRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookSecretRetrieveResponse(string secret)
        : this()
    {
        this.Secret = secret;
    }
}

class WebhookSecretRetrieveResponseFromRaw : IFromRawJson<WebhookSecretRetrieveResponse>
{
    /// <inheritdoc/>
    public WebhookSecretRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookSecretRetrieveResponse.FromRawUnchecked(rawData);
}
