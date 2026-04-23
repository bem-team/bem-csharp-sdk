using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Events;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class EventService : IEventService
{
    readonly Lazy<IEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventService(this._client.WithOptions(modifier));
    }

    public EventService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EventServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EventSubmitFeedbackResponse> SubmitFeedback(
        EventSubmitFeedbackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SubmitFeedback(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventSubmitFeedbackResponse> SubmitFeedback(
        string eventID,
        EventSubmitFeedbackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubmitFeedback(parameters with { EventID = eventID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EventServiceWithRawResponse : IEventServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventSubmitFeedbackResponse>> SubmitFeedback(
        EventSubmitFeedbackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new BemInvalidDataException("'parameters.EventID' cannot be null");
        }

        HttpRequest<EventSubmitFeedbackParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<EventSubmitFeedbackResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EventSubmitFeedbackResponse>> SubmitFeedback(
        string eventID,
        EventSubmitFeedbackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubmitFeedback(parameters with { EventID = eventID }, cancellationToken);
    }
}
