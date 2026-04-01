using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Services;

namespace Bem.Models.Functions;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IFunctionService.List(FunctionListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class FunctionListPage(
    IFunctionServiceWithRawResponse service,
    FunctionListParams parameters,
    ListFunctionsResponse response
) : IPage<Function>
{
    /// <inheritdoc/>
    public IReadOnlyList<Function> Items
    {
        get { return response.Functions ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<Function>> IPage<Function>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<FunctionListPage> Next(CancellationToken cancellationToken = default)
    {
        if (this.Items.Count == 0)
        {
            throw new InvalidOperationException("Cannot request next page");
        }
        if (parameters.EndingBefore != null)
        {
            var firstItem = this.Items[0];
            var previousCursor = firstItem;
            using var nextResponse = await service
                .List(parameters with { EndingBefore = previousCursor }, cancellationToken)
                .ConfigureAwait(false);
            return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
        }
        else
        {
            var lastItem = this.Items[this.Items.Count - 1];
            var nextCursor = lastItem;
            using var nextResponse = await service
                .List(parameters with { StartingAfter = nextCursor }, cancellationToken)
                .ConfigureAwait(false);
            return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
        }
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
        if (obj is not FunctionListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
