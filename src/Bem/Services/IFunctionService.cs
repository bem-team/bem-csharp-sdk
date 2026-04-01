using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Functions;
using Bem.Services.Functions;

namespace Bem.Services;

/// <summary>
/// Functions are the core building blocks of data transformation in Bem. Each function
/// type serves a specific purpose:
///
/// <para>- **Transform**: Extract structured JSON data from unstructured documents
/// (PDFs, emails, images) - **Analyze**: Perform visual analysis on documents to
/// extract layout-aware information - **Route**: Direct data to different processing
/// paths based on conditions - **Split**: Break multi-page documents into individual
/// pages for parallel processing - **Join**: Combine outputs from multiple function
/// calls into a single result - **Payload Shaping**: Transform and restructure data
/// using JMESPath expressions - **Enrich**: Enhance data with semantic search against collections</para>
///
/// <para>Use these endpoints to create, update, list, and manage your functions.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFunctionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFunctionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFunctionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICopyService Copy { get; }

    IVersionService Versions { get; }

    /// <summary>
    /// Create a Function
    /// </summary>
    Task<FunctionResponse> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a Function
    /// </summary>
    Task<FunctionResponse> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FunctionRetrieveParams, CancellationToken)"/>
    Task<FunctionResponse> Retrieve(
        string functionName,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Function
    /// </summary>
    Task<FunctionResponse> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FunctionUpdateParams, CancellationToken)"/>
    Task<FunctionResponse> Update(
        string pathFunctionName,
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Functions
    /// </summary>
    Task<FunctionListPage> List(
        FunctionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Function
    /// </summary>
    Task Delete(FunctionDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(FunctionDeleteParams, CancellationToken)"/>
    Task Delete(
        string functionName,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFunctionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFunctionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFunctionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICopyServiceWithRawResponse Copy { get; }

    IVersionServiceWithRawResponse Versions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/functions</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Create(FunctionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionResponse>> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/functions/{functionName}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Retrieve(FunctionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionResponse>> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FunctionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FunctionResponse>> Retrieve(
        string functionName,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/functions/{functionName}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Update(FunctionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionResponse>> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FunctionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FunctionResponse>> Update(
        string pathFunctionName,
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/functions</c>, but is otherwise the
    /// same as <see cref="IFunctionService.List(FunctionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionListPage>> List(
        FunctionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/functions/{functionName}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Delete(FunctionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        FunctionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FunctionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string functionName,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
