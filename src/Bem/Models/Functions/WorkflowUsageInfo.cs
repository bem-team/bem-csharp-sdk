using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<WorkflowUsageInfo, WorkflowUsageInfoFromRaw>))]
public sealed record class WorkflowUsageInfo : JsonModel
{
    /// <summary>
    /// Current version number of workflow, provided for reference - compare to usedInWorkflowVersionNums
    /// to see whether the current version of the workflow uses this function version.
    /// </summary>
    public required long CurrentVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("currentVersionNum");
        }
        init { this._rawData.Set("currentVersionNum", value); }
    }

    /// <summary>
    /// Version numbers of workflows that this function version is used in.
    /// </summary>
    public required IReadOnlyList<long> UsedInWorkflowVersionNums
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>(
                "usedInWorkflowVersionNums"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>(
                "usedInWorkflowVersionNums",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Unique identifier of workflow.
    /// </summary>
    public required string WorkflowID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workflowID");
        }
        init { this._rawData.Set("workflowID", value); }
    }

    /// <summary>
    /// Name of workflow.
    /// </summary>
    public required string WorkflowName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workflowName");
        }
        init { this._rawData.Set("workflowName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrentVersionNum;
        _ = this.UsedInWorkflowVersionNums;
        _ = this.WorkflowID;
        _ = this.WorkflowName;
    }

    public WorkflowUsageInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUsageInfo(WorkflowUsageInfo workflowUsageInfo)
        : base(workflowUsageInfo) { }
#pragma warning restore CS8618

    public WorkflowUsageInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUsageInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUsageInfoFromRaw.FromRawUnchecked"/>
    public static WorkflowUsageInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUsageInfoFromRaw : IFromRawJson<WorkflowUsageInfo>
{
    /// <inheritdoc/>
    public WorkflowUsageInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WorkflowUsageInfo.FromRawUnchecked(rawData);
}
