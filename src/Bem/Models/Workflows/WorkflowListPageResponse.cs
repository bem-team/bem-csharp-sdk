using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

[JsonConverter(
    typeof(JsonModelConverter<WorkflowListPageResponse, WorkflowListPageResponseFromRaw>)
)]
public sealed record class WorkflowListPageResponse : JsonModel
{
    /// <summary>
    /// Error message if the workflow listing failed.
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// The total number of results available.
    /// </summary>
    public long? TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCount", value);
        }
    }

    public IReadOnlyList<WorkflowListResponse>? Workflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowListResponse>>(
                "workflows"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowListResponse>?>(
                "workflows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        _ = this.TotalCount;
        foreach (var item in this.Workflows ?? [])
        {
            item.Validate();
        }
    }

    public WorkflowListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowListPageResponse(WorkflowListPageResponse workflowListPageResponse)
        : base(workflowListPageResponse) { }
#pragma warning restore CS8618

    public WorkflowListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowListPageResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowListPageResponseFromRaw : IFromRawJson<WorkflowListPageResponse>
{
    /// <inheritdoc/>
    public WorkflowListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowListPageResponse.FromRawUnchecked(rawData);
}
