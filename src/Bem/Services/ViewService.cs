using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class ViewService : IViewService
{
    readonly Lazy<IViewServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IViewServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IViewService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ViewService(this._client.WithOptions(modifier));
    }

    public ViewService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ViewServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ViewCreateResponse> Create(
        ViewCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ViewRetrieveResponse> Retrieve(
        ViewRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ViewRetrieveResponse> Retrieve(
        string viewID,
        ViewRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ViewID = viewID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ViewUpdateResponse> Update(
        ViewUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ViewUpdateResponse> Update(
        string viewID,
        ViewUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ViewID = viewID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ViewListResponse> List(
        ViewListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(ViewDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string viewID,
        ViewDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ViewID = viewID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ViewGenerateAggregationDataResponse> GenerateAggregationData(
        ViewGenerateAggregationDataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GenerateAggregationData(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ViewGenerateTableDataResponse> GenerateTableData(
        ViewGenerateTableDataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GenerateTableData(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ViewServiceWithRawResponse : IViewServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IViewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ViewServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ViewServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ViewCreateResponse>> Create(
        ViewCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ViewCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var view = await response
                    .Deserialize<ViewCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    view.Validate();
                }
                return view;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ViewRetrieveResponse>> Retrieve(
        ViewRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ViewID == null)
        {
            throw new BemInvalidDataException("'parameters.ViewID' cannot be null");
        }

        HttpRequest<ViewRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var view = await response
                    .Deserialize<ViewRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    view.Validate();
                }
                return view;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ViewRetrieveResponse>> Retrieve(
        string viewID,
        ViewRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ViewID = viewID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ViewUpdateResponse>> Update(
        ViewUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ViewID == null)
        {
            throw new BemInvalidDataException("'parameters.ViewID' cannot be null");
        }

        HttpRequest<ViewUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var view = await response
                    .Deserialize<ViewUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    view.Validate();
                }
                return view;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ViewUpdateResponse>> Update(
        string viewID,
        ViewUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ViewID = viewID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ViewListResponse>> List(
        ViewListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ViewListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var views = await response
                    .Deserialize<ViewListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    views.Validate();
                }
                return views;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ViewDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ViewID == null)
        {
            throw new BemInvalidDataException("'parameters.ViewID' cannot be null");
        }

        HttpRequest<ViewDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string viewID,
        ViewDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ViewID = viewID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ViewGenerateAggregationDataResponse>> GenerateAggregationData(
        ViewGenerateAggregationDataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ViewGenerateAggregationDataParams> request = new()
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
                    .Deserialize<ViewGenerateAggregationDataResponse>(token)
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
    public async Task<HttpResponse<ViewGenerateTableDataResponse>> GenerateTableData(
        ViewGenerateTableDataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ViewGenerateTableDataParams> request = new()
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
                    .Deserialize<ViewGenerateTableDataResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
