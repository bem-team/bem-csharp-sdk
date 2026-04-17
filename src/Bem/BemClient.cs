using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Services;

namespace Bem;

/// <inheritdoc/>
public sealed class BemClient : IBemClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    readonly Lazy<IBemClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBemClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IBemClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BemClient(modifier(this._options));
    }

    readonly Lazy<IFunctionService> _functions;
    public IFunctionService Functions
    {
        get { return _functions.Value; }
    }

    readonly Lazy<ICallService> _calls;
    public ICallService Calls
    {
        get { return _calls.Value; }
    }

    readonly Lazy<IErrorService> _errors;
    public IErrorService Errors
    {
        get { return _errors.Value; }
    }

    readonly Lazy<IOutputService> _outputs;
    public IOutputService Outputs
    {
        get { return _outputs.Value; }
    }

    readonly Lazy<IWorkflowService> _workflows;
    public IWorkflowService Workflows
    {
        get { return _workflows.Value; }
    }

    readonly Lazy<IInferSchemaService> _inferSchema;
    public IInferSchemaService InferSchema
    {
        get { return _inferSchema.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public BemClient()
    {
        _options = new();

        _withRawResponse = new(() => new BemClientWithRawResponse(this._options));
        _functions = new(() => new FunctionService(this));
        _calls = new(() => new CallService(this));
        _errors = new(() => new ErrorService(this));
        _outputs = new(() => new OutputService(this));
        _workflows = new(() => new WorkflowService(this));
        _inferSchema = new(() => new InferSchemaService(this));
    }

    public BemClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class BemClientWithRawResponse : IBemClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public IBemClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BemClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IFunctionServiceWithRawResponse> _functions;
    public IFunctionServiceWithRawResponse Functions
    {
        get { return _functions.Value; }
    }

    readonly Lazy<ICallServiceWithRawResponse> _calls;
    public ICallServiceWithRawResponse Calls
    {
        get { return _calls.Value; }
    }

    readonly Lazy<IErrorServiceWithRawResponse> _errors;
    public IErrorServiceWithRawResponse Errors
    {
        get { return _errors.Value; }
    }

    readonly Lazy<IOutputServiceWithRawResponse> _outputs;
    public IOutputServiceWithRawResponse Outputs
    {
        get { return _outputs.Value; }
    }

    readonly Lazy<IWorkflowServiceWithRawResponse> _workflows;
    public IWorkflowServiceWithRawResponse Workflows
    {
        get { return _workflows.Value; }
    }

    readonly Lazy<IInferSchemaServiceWithRawResponse> _inferSchema;
    public IInferSchemaServiceWithRawResponse InferSchema
    {
        get { return _inferSchema.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw BemExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new BemIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new BemIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is BemIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public BemClientWithRawResponse()
    {
        _options = new();

        _functions = new(() => new FunctionServiceWithRawResponse(this));
        _calls = new(() => new CallServiceWithRawResponse(this));
        _errors = new(() => new ErrorServiceWithRawResponse(this));
        _outputs = new(() => new OutputServiceWithRawResponse(this));
        _workflows = new(() => new WorkflowServiceWithRawResponse(this));
        _inferSchema = new(() => new InferSchemaServiceWithRawResponse(this));
    }

    public BemClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
