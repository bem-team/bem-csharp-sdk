using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Exceptions;
using Bem.Services;

namespace Bem.Models.Collections;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ICollectionService.List(CollectionListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class CollectionListPage(
    ICollectionServiceWithRawResponse service,
    CollectionListParams parameters,
    CollectionListPageResponse response
) : IPage<CollectionListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<CollectionListResponse> Items
    {
        get { return response.Collections; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            if (this.Items.Count == 0)
            {
                return false;
            }
            var pageNumber = response.Page;
            var pageCount = response.TotalPages;

            return pageNumber < pageCount;
        }
        catch (BemInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<CollectionListResponse>> IPage<CollectionListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<CollectionListPage> Next(CancellationToken cancellationToken = default)
    {
        var currentPageNumber = parameters.Page ?? 1;
        using var nextResponse = await service
            .List(parameters with { Page = currentPageNumber + 1 }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not CollectionListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
