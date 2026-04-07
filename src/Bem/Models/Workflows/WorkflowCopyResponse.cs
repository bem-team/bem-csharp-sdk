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

[JsonConverter(typeof(JsonModelConverter<WorkflowCopyResponse, WorkflowCopyResponseFromRaw>))]
public sealed record class WorkflowCopyResponse : JsonModel
{
    /// <summary>
    /// Functions that were copied when copying to a different environment. Empty
    /// when copying within the same environment.
    /// </summary>
    public IReadOnlyList<CopiedFunction>? CopiedFunctions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CopiedFunction>>(
                "copiedFunctions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CopiedFunction>?>(
                "copiedFunctions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The environment the workflow was copied to.
    /// </summary>
    public string? Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("environment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("environment", value);
        }
    }

    /// <summary>
    /// Error message if the workflow copy failed.
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
    public WorkflowCopyResponseWorkflow? Workflow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowCopyResponseWorkflow>("workflow");
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
        foreach (var item in this.CopiedFunctions ?? [])
        {
            item.Validate();
        }
        _ = this.Environment;
        _ = this.Error;
        this.Workflow?.Validate();
    }

    public WorkflowCopyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCopyResponse(WorkflowCopyResponse workflowCopyResponse)
        : base(workflowCopyResponse) { }
#pragma warning restore CS8618

    public WorkflowCopyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCopyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowCopyResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowCopyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowCopyResponseFromRaw : IFromRawJson<WorkflowCopyResponse>
{
    /// <inheritdoc/>
    public WorkflowCopyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowCopyResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CopiedFunction, CopiedFunctionFromRaw>))]
public sealed record class CopiedFunction : JsonModel
{
    /// <summary>
    /// ID of the source function that was copied.
    /// </summary>
    public required string SourceFunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceFunctionID");
        }
        init { this._rawData.Set("sourceFunctionID", value); }
    }

    /// <summary>
    /// Name of the source function that was copied.
    /// </summary>
    public required string SourceFunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceFunctionName");
        }
        init { this._rawData.Set("sourceFunctionName", value); }
    }

    /// <summary>
    /// Version number of the source function that was copied.
    /// </summary>
    public required long SourceVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sourceVersionNum");
        }
        init { this._rawData.Set("sourceVersionNum", value); }
    }

    /// <summary>
    /// ID of the newly created function in the target environment.
    /// </summary>
    public required string TargetFunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("targetFunctionID");
        }
        init { this._rawData.Set("targetFunctionID", value); }
    }

    /// <summary>
    /// Name of the newly created function in the target environment.
    /// </summary>
    public required string TargetFunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("targetFunctionName");
        }
        init { this._rawData.Set("targetFunctionName", value); }
    }

    /// <summary>
    /// Version number of the newly created function in the target environment.
    /// </summary>
    public required long TargetVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("targetVersionNum");
        }
        init { this._rawData.Set("targetVersionNum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SourceFunctionID;
        _ = this.SourceFunctionName;
        _ = this.SourceVersionNum;
        _ = this.TargetFunctionID;
        _ = this.TargetFunctionName;
        _ = this.TargetVersionNum;
    }

    public CopiedFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CopiedFunction(CopiedFunction copiedFunction)
        : base(copiedFunction) { }
#pragma warning restore CS8618

    public CopiedFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CopiedFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CopiedFunctionFromRaw.FromRawUnchecked"/>
    public static CopiedFunction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CopiedFunctionFromRaw : IFromRawJson<CopiedFunction>
{
    /// <inheritdoc/>
    public CopiedFunction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CopiedFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 read representation of a workflow version.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WorkflowCopyResponseWorkflow, WorkflowCopyResponseWorkflowFromRaw>)
)]
public sealed record class WorkflowCopyResponseWorkflow : JsonModel
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
    public required IReadOnlyList<WorkflowCopyResponseWorkflowEdge> Edges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkflowCopyResponseWorkflowEdge>>(
                "edges"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowCopyResponseWorkflowEdge>>(
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
    public required IReadOnlyList<WorkflowCopyResponseWorkflowNode> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkflowCopyResponseWorkflowNode>>(
                "nodes"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowCopyResponseWorkflowNode>>(
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
    public WorkflowCopyResponseWorkflowAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowCopyResponseWorkflowAudit>("audit");
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

    public WorkflowCopyResponseWorkflow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCopyResponseWorkflow(WorkflowCopyResponseWorkflow workflowCopyResponseWorkflow)
        : base(workflowCopyResponseWorkflow) { }
#pragma warning restore CS8618

    public WorkflowCopyResponseWorkflow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCopyResponseWorkflow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowCopyResponseWorkflowFromRaw.FromRawUnchecked"/>
    public static WorkflowCopyResponseWorkflow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowCopyResponseWorkflowFromRaw : IFromRawJson<WorkflowCopyResponseWorkflow>
{
    /// <inheritdoc/>
    public WorkflowCopyResponseWorkflow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowCopyResponseWorkflow.FromRawUnchecked(rawData);
}

/// <summary>
/// Read representation of a directed edge between call-site nodes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowCopyResponseWorkflowEdge,
        WorkflowCopyResponseWorkflowEdgeFromRaw
    >)
)]
public sealed record class WorkflowCopyResponseWorkflowEdge : JsonModel
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

    public WorkflowCopyResponseWorkflowEdge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCopyResponseWorkflowEdge(
        WorkflowCopyResponseWorkflowEdge workflowCopyResponseWorkflowEdge
    )
        : base(workflowCopyResponseWorkflowEdge) { }
#pragma warning restore CS8618

    public WorkflowCopyResponseWorkflowEdge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCopyResponseWorkflowEdge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowCopyResponseWorkflowEdgeFromRaw.FromRawUnchecked"/>
    public static WorkflowCopyResponseWorkflowEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowCopyResponseWorkflowEdgeFromRaw : IFromRawJson<WorkflowCopyResponseWorkflowEdge>
{
    /// <inheritdoc/>
    public WorkflowCopyResponseWorkflowEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowCopyResponseWorkflowEdge.FromRawUnchecked(rawData);
}

/// <summary>
/// Read representation of a call-site node.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowCopyResponseWorkflowNode,
        WorkflowCopyResponseWorkflowNodeFromRaw
    >)
)]
public sealed record class WorkflowCopyResponseWorkflowNode : JsonModel
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

    public WorkflowCopyResponseWorkflowNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCopyResponseWorkflowNode(
        WorkflowCopyResponseWorkflowNode workflowCopyResponseWorkflowNode
    )
        : base(workflowCopyResponseWorkflowNode) { }
#pragma warning restore CS8618

    public WorkflowCopyResponseWorkflowNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCopyResponseWorkflowNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowCopyResponseWorkflowNodeFromRaw.FromRawUnchecked"/>
    public static WorkflowCopyResponseWorkflowNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowCopyResponseWorkflowNodeFromRaw : IFromRawJson<WorkflowCopyResponseWorkflowNode>
{
    /// <inheritdoc/>
    public WorkflowCopyResponseWorkflowNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowCopyResponseWorkflowNode.FromRawUnchecked(rawData);
}

/// <summary>
/// Audit trail information.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowCopyResponseWorkflowAudit,
        WorkflowCopyResponseWorkflowAuditFromRaw
    >)
)]
public sealed record class WorkflowCopyResponseWorkflowAudit : JsonModel
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

    public WorkflowCopyResponseWorkflowAudit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCopyResponseWorkflowAudit(
        WorkflowCopyResponseWorkflowAudit workflowCopyResponseWorkflowAudit
    )
        : base(workflowCopyResponseWorkflowAudit) { }
#pragma warning restore CS8618

    public WorkflowCopyResponseWorkflowAudit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCopyResponseWorkflowAudit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowCopyResponseWorkflowAuditFromRaw.FromRawUnchecked"/>
    public static WorkflowCopyResponseWorkflowAudit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowCopyResponseWorkflowAuditFromRaw : IFromRawJson<WorkflowCopyResponseWorkflowAudit>
{
    /// <inheritdoc/>
    public WorkflowCopyResponseWorkflowAudit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowCopyResponseWorkflowAudit.FromRawUnchecked(rawData);
}
