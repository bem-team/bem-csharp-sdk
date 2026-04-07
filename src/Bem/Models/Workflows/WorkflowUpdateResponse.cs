using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Models.Workflows;

[JsonConverter(typeof(JsonModelConverter<WorkflowUpdateResponse, WorkflowUpdateResponseFromRaw>))]
public sealed record class WorkflowUpdateResponse : JsonModel
{
    /// <summary>
    /// Error message if the workflow update failed.
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
    /// V3 read representation of a workflow version.
    /// </summary>
    public WorkflowUpdateResponseWorkflow? Workflow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowUpdateResponseWorkflow>("workflow");
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
        _ = this.Error;
        this.Workflow?.Validate();
    }

    public WorkflowUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateResponse(WorkflowUpdateResponse workflowUpdateResponse)
        : base(workflowUpdateResponse) { }
#pragma warning restore CS8618

    public WorkflowUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateResponseFromRaw : IFromRawJson<WorkflowUpdateResponse>
{
    /// <inheritdoc/>
    public WorkflowUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 read representation of a workflow version.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowUpdateResponseWorkflow,
        WorkflowUpdateResponseWorkflowFromRaw
    >)
)]
public sealed record class WorkflowUpdateResponseWorkflow : JsonModel
{
    /// <summary>
    /// Unique identifier of the workflow.
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
    /// The date and time the workflow was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// All directed edges in this workflow version's DAG.
    /// </summary>
    public required IReadOnlyList<WorkflowUpdateResponseWorkflowEdge> Edges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<WorkflowUpdateResponseWorkflowEdge>
            >("edges");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowUpdateResponseWorkflowEdge>>(
                "edges",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Name of the entry-point call-site node.
    /// </summary>
    public required string MainNodeName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mainNodeName");
        }
        init { this._rawData.Set("mainNodeName", value); }
    }

    /// <summary>
    /// Unique name of the workflow within the environment.
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
    /// All call-site nodes in this workflow version's DAG.
    /// </summary>
    public required IReadOnlyList<WorkflowUpdateResponseWorkflowNode> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<WorkflowUpdateResponseWorkflowNode>
            >("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowUpdateResponseWorkflowNode>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The date and time the workflow was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Version number of this workflow version.
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

    /// <summary>
    /// Audit trail information.
    /// </summary>
    public WorkflowUpdateResponseWorkflowAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowUpdateResponseWorkflowAudit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
        }
    }

    /// <summary>
    /// Human-readable display name.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Inbound email address associated with the workflow, if any.
    /// </summary>
    public string? EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("emailAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("emailAddress", value);
        }
    }

    /// <summary>
    /// Tags associated with the workflow.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        foreach (var item in this.Edges)
        {
            item.Validate();
        }
        _ = this.MainNodeName;
        _ = this.Name;
        foreach (var item in this.Nodes)
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.DisplayName;
        _ = this.EmailAddress;
        _ = this.Tags;
    }

    public WorkflowUpdateResponseWorkflow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateResponseWorkflow(
        WorkflowUpdateResponseWorkflow workflowUpdateResponseWorkflow
    )
        : base(workflowUpdateResponseWorkflow) { }
#pragma warning restore CS8618

    public WorkflowUpdateResponseWorkflow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateResponseWorkflow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateResponseWorkflowFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateResponseWorkflow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateResponseWorkflowFromRaw : IFromRawJson<WorkflowUpdateResponseWorkflow>
{
    /// <inheritdoc/>
    public WorkflowUpdateResponseWorkflow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateResponseWorkflow.FromRawUnchecked(rawData);
}

/// <summary>
/// Read representation of a directed edge between call-site nodes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowUpdateResponseWorkflowEdge,
        WorkflowUpdateResponseWorkflowEdgeFromRaw
    >)
)]
public sealed record class WorkflowUpdateResponseWorkflowEdge : JsonModel
{
    /// <summary>
    /// Name of the destination node.
    /// </summary>
    public required string DestinationNodeName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destinationNodeName");
        }
        init { this._rawData.Set("destinationNodeName", value); }
    }

    /// <summary>
    /// Name of the source node.
    /// </summary>
    public required string SourceNodeName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceNodeName");
        }
        init { this._rawData.Set("sourceNodeName", value); }
    }

    /// <summary>
    /// Labelled outlet on the source node, if any.
    /// </summary>
    public string? DestinationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destinationName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destinationName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DestinationNodeName;
        _ = this.SourceNodeName;
        _ = this.DestinationName;
    }

    public WorkflowUpdateResponseWorkflowEdge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateResponseWorkflowEdge(
        WorkflowUpdateResponseWorkflowEdge workflowUpdateResponseWorkflowEdge
    )
        : base(workflowUpdateResponseWorkflowEdge) { }
#pragma warning restore CS8618

    public WorkflowUpdateResponseWorkflowEdge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateResponseWorkflowEdge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateResponseWorkflowEdgeFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateResponseWorkflowEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateResponseWorkflowEdgeFromRaw : IFromRawJson<WorkflowUpdateResponseWorkflowEdge>
{
    /// <inheritdoc/>
    public WorkflowUpdateResponseWorkflowEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateResponseWorkflowEdge.FromRawUnchecked(rawData);
}

/// <summary>
/// Read representation of a call-site node.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowUpdateResponseWorkflowNode,
        WorkflowUpdateResponseWorkflowNodeFromRaw
    >)
)]
public sealed record class WorkflowUpdateResponseWorkflowNode : JsonModel
{
    /// <summary>
    /// Function (and version) executing at this call site.
    /// </summary>
    public required FunctionVersionIdentifier Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionVersionIdentifier>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    /// <summary>
    /// Name of this call site, unique within the workflow version.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
        _ = this.Name;
    }

    public WorkflowUpdateResponseWorkflowNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateResponseWorkflowNode(
        WorkflowUpdateResponseWorkflowNode workflowUpdateResponseWorkflowNode
    )
        : base(workflowUpdateResponseWorkflowNode) { }
#pragma warning restore CS8618

    public WorkflowUpdateResponseWorkflowNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateResponseWorkflowNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateResponseWorkflowNodeFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateResponseWorkflowNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateResponseWorkflowNodeFromRaw : IFromRawJson<WorkflowUpdateResponseWorkflowNode>
{
    /// <inheritdoc/>
    public WorkflowUpdateResponseWorkflowNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateResponseWorkflowNode.FromRawUnchecked(rawData);
}

/// <summary>
/// Audit trail information.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowUpdateResponseWorkflowAudit,
        WorkflowUpdateResponseWorkflowAuditFromRaw
    >)
)]
public sealed record class WorkflowUpdateResponseWorkflowAudit : JsonModel
{
    /// <summary>
    /// Information about who created the current version.
    /// </summary>
    public UserActionSummary? VersionCreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserActionSummary>("versionCreatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("versionCreatedBy", value);
        }
    }

    /// <summary>
    /// Information about who created the workflow.
    /// </summary>
    public UserActionSummary? WorkflowCreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserActionSummary>("workflowCreatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowCreatedBy", value);
        }
    }

    /// <summary>
    /// Information about who last updated the workflow.
    /// </summary>
    public UserActionSummary? WorkflowLastUpdatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserActionSummary>("workflowLastUpdatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowLastUpdatedBy", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.VersionCreatedBy?.Validate();
        this.WorkflowCreatedBy?.Validate();
        this.WorkflowLastUpdatedBy?.Validate();
    }

    public WorkflowUpdateResponseWorkflowAudit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateResponseWorkflowAudit(
        WorkflowUpdateResponseWorkflowAudit workflowUpdateResponseWorkflowAudit
    )
        : base(workflowUpdateResponseWorkflowAudit) { }
#pragma warning restore CS8618

    public WorkflowUpdateResponseWorkflowAudit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateResponseWorkflowAudit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateResponseWorkflowAuditFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateResponseWorkflowAudit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateResponseWorkflowAuditFromRaw : IFromRawJson<WorkflowUpdateResponseWorkflowAudit>
{
    /// <inheritdoc/>
    public WorkflowUpdateResponseWorkflowAudit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateResponseWorkflowAudit.FromRawUnchecked(rawData);
}
