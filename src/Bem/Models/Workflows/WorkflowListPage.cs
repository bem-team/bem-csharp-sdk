using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Services;

namespace Bem.Models.Workflows;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IWorkflowService.List(WorkflowListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class WorkflowListPage(
    IWorkflowServiceWithRawResponse service,
    WorkflowListParams parameters,
    WorkflowListPageResponse response
) : IPage<WorkflowListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<WorkflowListResponse> Items
    {
        get { return response.Workflows ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<WorkflowListResponse>> IPage<WorkflowListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<WorkflowListPage> Next(CancellationToken cancellationToken = default)
    {
        if (this.Items.Count == 0)
        {
            throw new InvalidOperationException("Cannot request next page");
        }
        if (parameters.EndingBefore != null)
        {
            var firstItem = this.Items[0];
            var previousCursor = firstItem.ID;
            using var nextResponse = await service
                .List(parameters with { EndingBefore = previousCursor }, cancellationToken)
                .ConfigureAwait(false);
            return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
        }
        else
        {
            var lastItem = this.Items[this.Items.Count - 1];
            var nextCursor = lastItem.ID;
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
        if (obj is not WorkflowListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
