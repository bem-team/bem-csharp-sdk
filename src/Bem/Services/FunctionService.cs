using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;
using Bem.Services.Functions;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class FunctionService : IFunctionService
{
    readonly Lazy<IFunctionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFunctionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IFunctionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FunctionService(this._client.WithOptions(modifier));
    }

    public FunctionService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FunctionServiceWithRawResponse(client.WithRawResponse));
        _copy = new(() => new CopyService(client));
        _versions = new(() => new VersionService(client));
    }

    readonly Lazy<ICopyService> _copy;
    public ICopyService Copy
    {
        get { return _copy.Value; }
    }

    readonly Lazy<IVersionService> _versions;
    public IVersionService Versions
    {
        get { return _versions.Value; }
    }

    /// <inheritdoc/>
    public async Task<FunctionResponse> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FunctionResponse> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionResponse> Retrieve(
        string functionName,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FunctionName = functionName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FunctionResponse> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionResponse> Update(
        string pathFunctionName,
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                PathFunctionName = pathFunctionName,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<FunctionListPage> List(
        FunctionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        FunctionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string functionName,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { FunctionName = functionName }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FunctionServiceWithRawResponse : IFunctionServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFunctionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FunctionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FunctionServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;

        _copy = new(() => new CopyServiceWithRawResponse(client));
        _versions = new(() => new VersionServiceWithRawResponse(client));
    }

    readonly Lazy<ICopyServiceWithRawResponse> _copy;
    public ICopyServiceWithRawResponse Copy
    {
        get { return _copy.Value; }
    }

    readonly Lazy<IVersionServiceWithRawResponse> _versions;
    public IVersionServiceWithRawResponse Versions
    {
        get { return _versions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionResponse>> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FunctionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var functionResponse = await response
                    .Deserialize<FunctionResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    functionResponse.Validate();
                }
                return functionResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionResponse>> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionName == null)
        {
            throw new BemInvalidDataException("'parameters.FunctionName' cannot be null");
        }

        HttpRequest<FunctionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var functionResponse = await response
                    .Deserialize<FunctionResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    functionResponse.Validate();
                }
                return functionResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FunctionResponse>> Retrieve(
        string functionName,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FunctionName = functionName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionResponse>> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PathFunctionName == null)
        {
            throw new BemInvalidDataException("'parameters.PathFunctionName' cannot be null");
        }

        HttpRequest<FunctionUpdateParams> request = new()
        {
            Method = BemClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var functionResponse = await response
                    .Deserialize<FunctionResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    functionResponse.Validate();
                }
                return functionResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FunctionResponse>> Update(
        string pathFunctionName,
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                PathFunctionName = pathFunctionName,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionListPage>> List(
        FunctionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FunctionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<FunctionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new FunctionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        FunctionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionName == null)
        {
            throw new BemInvalidDataException("'parameters.FunctionName' cannot be null");
        }

        HttpRequest<FunctionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string functionName,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FunctionName = functionName }, cancellationToken);
    }
}
