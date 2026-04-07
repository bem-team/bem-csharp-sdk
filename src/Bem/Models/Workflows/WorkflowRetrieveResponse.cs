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

[JsonConverter(
    typeof(JsonModelConverter<WorkflowRetrieveResponse, WorkflowRetrieveResponseFromRaw>)
)]
public sealed record class WorkflowRetrieveResponse : JsonModel
{
    /// <summary>
    /// Error message if the workflow retrieval failed.
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
    public WorkflowRetrieveResponseWorkflow? Workflow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowRetrieveResponseWorkflow>("workflow");
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

    public WorkflowRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowRetrieveResponse(WorkflowRetrieveResponse workflowRetrieveResponse)
        : base(workflowRetrieveResponse) { }
#pragma warning restore CS8618

    public WorkflowRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowRetrieveResponseFromRaw : IFromRawJson<WorkflowRetrieveResponse>
{
    /// <inheritdoc/>
    public WorkflowRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 read representation of a workflow version.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowRetrieveResponseWorkflow,
        WorkflowRetrieveResponseWorkflowFromRaw
    >)
)]
public sealed record class WorkflowRetrieveResponseWorkflow : JsonModel
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
    public required IReadOnlyList<WorkflowRetrieveResponseWorkflowEdge> Edges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<WorkflowRetrieveResponseWorkflowEdge>
            >("edges");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowRetrieveResponseWorkflowEdge>>(
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
    public required IReadOnlyList<WorkflowRetrieveResponseWorkflowNode> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<WorkflowRetrieveResponseWorkflowNode>
            >("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowRetrieveResponseWorkflowNode>>(
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
    public WorkflowRetrieveResponseWorkflowAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowRetrieveResponseWorkflowAudit>("audit");
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

    public WorkflowRetrieveResponseWorkflow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowRetrieveResponseWorkflow(
        WorkflowRetrieveResponseWorkflow workflowRetrieveResponseWorkflow
    )
        : base(workflowRetrieveResponseWorkflow) { }
#pragma warning restore CS8618

    public WorkflowRetrieveResponseWorkflow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowRetrieveResponseWorkflow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowRetrieveResponseWorkflowFromRaw.FromRawUnchecked"/>
    public static WorkflowRetrieveResponseWorkflow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowRetrieveResponseWorkflowFromRaw : IFromRawJson<WorkflowRetrieveResponseWorkflow>
{
    /// <inheritdoc/>
    public WorkflowRetrieveResponseWorkflow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowRetrieveResponseWorkflow.FromRawUnchecked(rawData);
}

/// <summary>
/// Read representation of a directed edge between call-site nodes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowRetrieveResponseWorkflowEdge,
        WorkflowRetrieveResponseWorkflowEdgeFromRaw
    >)
)]
public sealed record class WorkflowRetrieveResponseWorkflowEdge : JsonModel
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

    public WorkflowRetrieveResponseWorkflowEdge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowRetrieveResponseWorkflowEdge(
        WorkflowRetrieveResponseWorkflowEdge workflowRetrieveResponseWorkflowEdge
    )
        : base(workflowRetrieveResponseWorkflowEdge) { }
#pragma warning restore CS8618

    public WorkflowRetrieveResponseWorkflowEdge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowRetrieveResponseWorkflowEdge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowRetrieveResponseWorkflowEdgeFromRaw.FromRawUnchecked"/>
    public static WorkflowRetrieveResponseWorkflowEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowRetrieveResponseWorkflowEdgeFromRaw
    : IFromRawJson<WorkflowRetrieveResponseWorkflowEdge>
{
    /// <inheritdoc/>
    public WorkflowRetrieveResponseWorkflowEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowRetrieveResponseWorkflowEdge.FromRawUnchecked(rawData);
}

/// <summary>
/// Read representation of a call-site node.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowRetrieveResponseWorkflowNode,
        WorkflowRetrieveResponseWorkflowNodeFromRaw
    >)
)]
public sealed record class WorkflowRetrieveResponseWorkflowNode : JsonModel
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

    public WorkflowRetrieveResponseWorkflowNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowRetrieveResponseWorkflowNode(
        WorkflowRetrieveResponseWorkflowNode workflowRetrieveResponseWorkflowNode
    )
        : base(workflowRetrieveResponseWorkflowNode) { }
#pragma warning restore CS8618

    public WorkflowRetrieveResponseWorkflowNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowRetrieveResponseWorkflowNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowRetrieveResponseWorkflowNodeFromRaw.FromRawUnchecked"/>
    public static WorkflowRetrieveResponseWorkflowNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowRetrieveResponseWorkflowNodeFromRaw
    : IFromRawJson<WorkflowRetrieveResponseWorkflowNode>
{
    /// <inheritdoc/>
    public WorkflowRetrieveResponseWorkflowNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowRetrieveResponseWorkflowNode.FromRawUnchecked(rawData);
}

/// <summary>
/// Audit trail information.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowRetrieveResponseWorkflowAudit,
        WorkflowRetrieveResponseWorkflowAuditFromRaw
    >)
)]
public sealed record class WorkflowRetrieveResponseWorkflowAudit : JsonModel
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

    public WorkflowRetrieveResponseWorkflowAudit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowRetrieveResponseWorkflowAudit(
        WorkflowRetrieveResponseWorkflowAudit workflowRetrieveResponseWorkflowAudit
    )
        : base(workflowRetrieveResponseWorkflowAudit) { }
#pragma warning restore CS8618

    public WorkflowRetrieveResponseWorkflowAudit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowRetrieveResponseWorkflowAudit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowRetrieveResponseWorkflowAuditFromRaw.FromRawUnchecked"/>
    public static WorkflowRetrieveResponseWorkflowAudit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowRetrieveResponseWorkflowAuditFromRaw
    : IFromRawJson<WorkflowRetrieveResponseWorkflowAudit>
{
    /// <inheritdoc/>
    public WorkflowRetrieveResponseWorkflowAudit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowRetrieveResponseWorkflowAudit.FromRawUnchecked(rawData);
}
