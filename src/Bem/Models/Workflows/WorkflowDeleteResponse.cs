using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

[JsonConverter(typeof(JsonModelConverter<WorkflowDeleteResponse, WorkflowDeleteResponseFromRaw>))]
public sealed record class WorkflowDeleteResponse : JsonModel
{
    /// <summary>
    /// Per-connector failures from tearing down the deleted workflow's connectors.
    /// Connector teardown is best-effort: a failure here is reported but does not
    /// block the deletion, so a `200` response with a non-empty `connectorErrors`
    /// means the workflow is gone while one or more of its connectors may still
    /// need manual cleanup. Empty or omitted when all teardowns succeeded.
    /// </summary>
    public IReadOnlyList<WorkflowConnectorError>? ConnectorErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowConnectorError>>(
                "connectorErrors"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowConnectorError>?>(
                "connectorErrors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error message if the workflow deletion failed.
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
    /// Identifies the workflow that was deleted, pinned to the version number it
    /// was on at deletion time.
    /// </summary>
    public WorkflowDeleteResponseWorkflow? Workflow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowDeleteResponseWorkflow>("workflow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflow", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ConnectorErrors ?? [])
        {
            item.Validate();
        }
        _ = this.Error;
        this.Workflow?.Validate();
    }

    public WorkflowDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowDeleteResponse(WorkflowDeleteResponse workflowDeleteResponse)
        : base(workflowDeleteResponse) { }
#pragma warning restore CS8618

    public WorkflowDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowDeleteResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowDeleteResponseFromRaw : IFromRawJson<WorkflowDeleteResponse>
{
    /// <inheritdoc/>
    public WorkflowDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the workflow that was deleted, pinned to the version number it was
/// on at deletion time.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowDeleteResponseWorkflow,
        WorkflowDeleteResponseWorkflowFromRaw
    >)
)]
public sealed record class WorkflowDeleteResponseWorkflow : JsonModel
{
    /// <summary>
    /// Unique identifier of workflow.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Unique name of workflow. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Version number of workflow version.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.VersionNum;
    }

    public WorkflowDeleteResponseWorkflow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowDeleteResponseWorkflow(
        WorkflowDeleteResponseWorkflow workflowDeleteResponseWorkflow
    )
        : base(workflowDeleteResponseWorkflow) { }
#pragma warning restore CS8618

    public WorkflowDeleteResponseWorkflow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowDeleteResponseWorkflow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowDeleteResponseWorkflowFromRaw.FromRawUnchecked"/>
    public static WorkflowDeleteResponseWorkflow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowDeleteResponseWorkflowFromRaw : IFromRawJson<WorkflowDeleteResponseWorkflow>
{
    /// <inheritdoc/>
    public WorkflowDeleteResponseWorkflow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowDeleteResponseWorkflow.FromRawUnchecked(rawData);
}
