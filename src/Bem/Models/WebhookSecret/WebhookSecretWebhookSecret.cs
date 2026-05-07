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
    typeof(JsonModelConverter<WebhookSecretWebhookSecret, WebhookSecretWebhookSecretFromRaw>)
)]
public sealed record class WebhookSecretWebhookSecret : JsonModel
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

    public WebhookSecretWebhookSecret() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookSecretWebhookSecret(WebhookSecretWebhookSecret webhookSecretWebhookSecret)
        : base(webhookSecretWebhookSecret) { }
#pragma warning restore CS8618

    public WebhookSecretWebhookSecret(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookSecretWebhookSecret(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookSecretWebhookSecretFromRaw.FromRawUnchecked"/>
    public static WebhookSecretWebhookSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookSecretWebhookSecret(string secret)
        : this()
    {
        this.Secret = secret;
    }
}

class WebhookSecretWebhookSecretFromRaw : IFromRawJson<WebhookSecretWebhookSecret>
{
    /// <inheritdoc/>
    public WebhookSecretWebhookSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookSecretWebhookSecret.FromRawUnchecked(rawData);
}
