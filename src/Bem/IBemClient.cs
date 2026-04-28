using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Services;

namespace Bem;

/// <summary>
/// A client for interacting with the Bem REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBemClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Authenticate using API Key in request header
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBemClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBemClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFunctionService Functions { get; }

    ICallService Calls { get; }

    IErrorService Errors { get; }

    IOutputService Outputs { get; }

    IWorkflowService Workflows { get; }

    IInferSchemaService InferSchema { get; }

    ICollectionService Collections { get; }

    IEventService Events { get; }

    IWebhookSecretService WebhookSecret { get; }

    IEvalService Eval { get; }

    IFService Fs { get; }
}

/// <summary>
/// A view of <see cref="IBemClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IBemClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Authenticate using API Key in request header
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBemClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFunctionServiceWithRawResponse Functions { get; }

    ICallServiceWithRawResponse Calls { get; }

    IErrorServiceWithRawResponse Errors { get; }

    IOutputServiceWithRawResponse Outputs { get; }

    IWorkflowServiceWithRawResponse Workflows { get; }

    IInferSchemaServiceWithRawResponse InferSchema { get; }

    ICollectionServiceWithRawResponse Collections { get; }

    IEventServiceWithRawResponse Events { get; }

    IWebhookSecretServiceWithRawResponse WebhookSecret { get; }

    IEvalServiceWithRawResponse Eval { get; }

    IFServiceWithRawResponse Fs { get; }

    /// <summary>
    /// Sends a request to the Bem REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
