using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.WebhookSecret;

namespace Bem.Services;

/// <summary>
/// Manage the webhook signing secret used to authenticate outbound webhook deliveries.
///
/// <para>When a signing secret is active, every webhook delivery includes a `bem-signature`
/// header in the format `t={unix_timestamp},v1={hex_hmac_sha256}`. The signature
/// covers `{timestamp}.{raw_request_body}` and can be verified using HMAC-SHA256
/// with your secret.</para>
///
/// <para>Rotate the secret at any time with `POST /v3/webhook-secret`. To avoid downtime
/// during rotation, update your verification logic to accept both the old and new
/// secret briefly before revoking the old one.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWebhookSecretService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookSecretServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookSecretService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Generate a new webhook signing secret.**
    ///
    /// <para>Creates a new signing secret for this environment (or replaces the
    /// existing one). The new secret is returned in full exactly once — store it
    /// securely.</para>
    ///
    /// <para>After rotation all newly delivered webhooks will be signed with the new
    /// secret. Update your verification logic before calling this endpoint if you need
    /// zero-downtime rotation.</para>
    /// </summary>
    Task<WebhookSecretCreateResponse> Create(
        WebhookSecretCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Get the current webhook signing secret.**
    ///
    /// <para>Returns the active secret used to sign outbound webhook deliveries via the
    /// `bem-signature` header. Returns 404 if no secret has been generated for this
    /// environment yet.</para>
    ///
    /// <para>Use the secret to verify incoming webhook payloads: 1. Parse
    /// `bem-signature: t={timestamp},v1={signature}`. 2. Construct the signed string:
    /// `{timestamp}.{raw request body}`. 3. Compute HMAC-SHA256 of that string using
    /// the secret. 4. Compare the hex digest against `v1`. 5. Reject requests where the
    /// timestamp is more than a few minutes old.</para>
    /// </summary>
    Task<WebhookSecretRetrieveResponse> Retrieve(
        WebhookSecretRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Revoke the current webhook signing secret.**
    ///
    /// <para>Deletes the active signing secret. Webhook deliveries will continue but
    /// will no longer include a `bem-signature` header until a new secret is generated.</para>
    /// </summary>
    Task Revoke(
        WebhookSecretRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookSecretService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookSecretServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookSecretServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/webhook-secret</c>, but is otherwise the
    /// same as <see cref="IWebhookSecretService.Create(WebhookSecretCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookSecretCreateResponse>> Create(
        WebhookSecretCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/webhook-secret</c>, but is otherwise the
    /// same as <see cref="IWebhookSecretService.Retrieve(WebhookSecretRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookSecretRetrieveResponse>> Retrieve(
        WebhookSecretRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/webhook-secret</c>, but is otherwise the
    /// same as <see cref="IWebhookSecretService.Revoke(WebhookSecretRevokeParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Revoke(
        WebhookSecretRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
