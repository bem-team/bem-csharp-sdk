using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Subscriptions;

namespace Bem.Services;

/// <summary>
/// Subscriptions wire up notifications for the events your functions and collections produce.
///
/// <para>Each subscription targets a single function (by `functionName` or `functionID`)
/// or a single collection (by `collectionName` or `collectionID`) and selects a `type`
/// corresponding to the event you want to receive — for example `transform`, `route`,
/// `join`, `evaluation`, `error`, `enrich`, or `collection_processing`.</para>
///
/// <para>Deliveries can be sent to any combination of:</para>
///
/// <para>- `webhookURL` — HTTPS endpoint that receives a JSON POST per event. - `s3Bucket`
/// + `s3FilePath` — sync output JSON into an AWS S3 prefix you own. - `googleDriveFolderID`
/// — drop output JSON into a Google Drive folder.</para>
///
/// <para>Use `disabled: true` to pause delivery without deleting the subscription.
/// Updates follow conventional PATCH semantics — only the fields you include are changed.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new subscription to listen to transform or error events.
    /// </summary>
    Task<SubscriptionV3> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a Subscription
    /// </summary>
    Task<SubscriptionV3> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>
    Task<SubscriptionV3> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing subscription. Follow conventional PATCH behavior, so only
    /// included fields will be updated.
    /// </summary>
    Task<SubscriptionV3> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task<SubscriptionV3> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Subscriptions
    /// </summary>
    Task<List<SubscriptionV3>> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an existing subscription.
    /// </summary>
    Task Delete(SubscriptionDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(SubscriptionDeleteParams, CancellationToken)"/>
    Task Delete(
        string subscriptionID,
        SubscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISubscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/subscriptions</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Create(SubscriptionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionV3>> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/subscriptions/{subscriptionID}</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionV3>> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionV3>> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/subscriptions/{subscriptionID}</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Update(SubscriptionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionV3>> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionV3>> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/subscriptions</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.List(SubscriptionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<SubscriptionV3>>> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/subscriptions/{subscriptionID}</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Delete(SubscriptionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SubscriptionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string subscriptionID,
        SubscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
