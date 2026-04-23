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
    typeof(JsonModelConverter<WebhookSecretCreateResponse, WebhookSecretCreateResponseFromRaw>)
)]
public sealed record class WebhookSecretCreateResponse : JsonModel
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

    public WebhookSecretCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookSecretCreateResponse(WebhookSecretCreateResponse webhookSecretCreateResponse)
        : base(webhookSecretCreateResponse) { }
#pragma warning restore CS8618

    public WebhookSecretCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookSecretCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookSecretCreateResponseFromRaw.FromRawUnchecked"/>
    public static WebhookSecretCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookSecretCreateResponse(string secret)
        : this()
    {
        this.Secret = secret;
    }
}

class WebhookSecretCreateResponseFromRaw : IFromRawJson<WebhookSecretCreateResponse>
{
    /// <inheritdoc/>
    public WebhookSecretCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookSecretCreateResponse.FromRawUnchecked(rawData);
}
