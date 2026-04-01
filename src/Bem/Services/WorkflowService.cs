using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Calls;
using Bem.Models.Workflows;
using Bem.Services.Workflows;

namespace Bem.Services;

/// <inheritdoc/>
public sealed class WorkflowService : IWorkflowService
{
    readonly Lazy<IWorkflowServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWorkflowServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBemClient _client;

    /// <inheritdoc/>
    public IWorkflowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkflowService(this._client.WithOptions(modifier));
    }

    public WorkflowService(IBemClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WorkflowServiceWithRawResponse(client.WithRawResponse));
        _versions = new(() => new VersionService(client));
    }

    readonly Lazy<IVersionService> _versions;
    public IVersionService Versions
    {
        get { return _versions.Value; }
    }

    /// <inheritdoc/>
    public async Task<WorkflowCreateResponse> Create(
        WorkflowCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WorkflowRetrieveResponse> Retrieve(
        WorkflowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkflowRetrieveResponse> Retrieve(
        string workflowName,
        WorkflowRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WorkflowName = workflowName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkflowUpdateResponse> Update(
        WorkflowUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkflowUpdateResponse> Update(
        string workflowName,
        WorkflowUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { WorkflowName = workflowName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkflowListPage> List(
        WorkflowListParams? parameters = null,
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
        WorkflowDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string workflowName,
        WorkflowDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { WorkflowName = workflowName }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CallGetResponse> Call(
        WorkflowCallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Call(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CallGetResponse> Call(
        string workflowName,
        WorkflowCallParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Call(parameters with { WorkflowName = workflowName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkflowCopyResponse> Copy(
        WorkflowCopyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Copy(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WorkflowServiceWithRawResponse : IWorkflowServiceWithRawResponse
{
    readonly IBemClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWorkflowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkflowServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WorkflowServiceWithRawResponse(IBemClientWithRawResponse client)
    {
        _client = client;

        _versions = new(() => new VersionServiceWithRawResponse(client));
    }

    readonly Lazy<IVersionServiceWithRawResponse> _versions;
    public IVersionServiceWithRawResponse Versions
    {
        get { return _versions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkflowCreateResponse>> Create(
        WorkflowCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WorkflowCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workflow = await response
                    .Deserialize<WorkflowCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workflow.Validate();
                }
                return workflow;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkflowRetrieveResponse>> Retrieve(
        WorkflowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkflowName == null)
        {
            throw new BemInvalidDataException("'parameters.WorkflowName' cannot be null");
        }

        HttpRequest<WorkflowRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workflow = await response
                    .Deserialize<WorkflowRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workflow.Validate();
                }
                return workflow;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkflowRetrieveResponse>> Retrieve(
        string workflowName,
        WorkflowRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WorkflowName = workflowName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkflowUpdateResponse>> Update(
        WorkflowUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkflowName == null)
        {
            throw new BemInvalidDataException("'parameters.WorkflowName' cannot be null");
        }

        HttpRequest<WorkflowUpdateParams> request = new()
        {
            Method = BemClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workflow = await response
                    .Deserialize<WorkflowUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workflow.Validate();
                }
                return workflow;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkflowUpdateResponse>> Update(
        string workflowName,
        WorkflowUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { WorkflowName = workflowName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkflowListPage>> List(
        WorkflowListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WorkflowListParams> request = new()
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
                    .Deserialize<WorkflowListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new WorkflowListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        WorkflowDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkflowName == null)
        {
            throw new BemInvalidDataException("'parameters.WorkflowName' cannot be null");
        }

        HttpRequest<WorkflowDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string workflowName,
        WorkflowDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { WorkflowName = workflowName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallGetResponse>> Call(
        WorkflowCallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkflowName == null)
        {
            throw new BemInvalidDataException("'parameters.WorkflowName' cannot be null");
        }

        HttpRequest<WorkflowCallParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var callGetResponse = await response
                    .Deserialize<CallGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    callGetResponse.Validate();
                }
                return callGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CallGetResponse>> Call(
        string workflowName,
        WorkflowCallParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Call(parameters with { WorkflowName = workflowName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkflowCopyResponse>> Copy(
        WorkflowCopyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WorkflowCopyParams> request = new()
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
                    .Deserialize<WorkflowCopyResponse>(token)
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
