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

[JsonConverter(typeof(JsonModelConverter<WorkflowCreateResponse, WorkflowCreateResponseFromRaw>))]
public sealed record class WorkflowCreateResponse : JsonModel
{
    /// <summary>
    /// Error message if the workflow creation failed.
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
    public Workflow? Workflow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Workflow>("workflow");
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

    public WorkflowCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCreateResponse(WorkflowCreateResponse workflowCreateResponse)
        : base(workflowCreateResponse) { }
#pragma warning restore CS8618

    public WorkflowCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowCreateResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowCreateResponseFromRaw : IFromRawJson<WorkflowCreateResponse>
{
    /// <inheritdoc/>
    public WorkflowCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// V3 read representation of a workflow version.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Workflow, WorkflowFromRaw>))]
public sealed record class Workflow : JsonModel
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
    public required IReadOnlyList<WorkflowEdge> Edges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkflowEdge>>("edges");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowEdge>>(
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
    public required IReadOnlyList<WorkflowNode> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkflowNode>>("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowNode>>(
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
    public Audit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Audit>("audit");
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

    public Workflow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Workflow(Workflow workflow)
        : base(workflow) { }
#pragma warning restore CS8618

    public Workflow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Workflow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowFromRaw.FromRawUnchecked"/>
    public static Workflow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowFromRaw : IFromRawJson<Workflow>
{
    /// <inheritdoc/>
    public Workflow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Workflow.FromRawUnchecked(rawData);
}

/// <summary>
/// Read representation of a directed edge between call-site nodes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WorkflowEdge, WorkflowEdgeFromRaw>))]
public sealed record class WorkflowEdge : JsonModel
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

    public WorkflowEdge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowEdge(WorkflowEdge workflowEdge)
        : base(workflowEdge) { }
#pragma warning restore CS8618

    public WorkflowEdge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowEdge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowEdgeFromRaw.FromRawUnchecked"/>
    public static WorkflowEdge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowEdgeFromRaw : IFromRawJson<WorkflowEdge>
{
    /// <inheritdoc/>
    public WorkflowEdge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WorkflowEdge.FromRawUnchecked(rawData);
}

/// <summary>
/// Read representation of a call-site node.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WorkflowNode, WorkflowNodeFromRaw>))]
public sealed record class WorkflowNode : JsonModel
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

    public WorkflowNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowNode(WorkflowNode workflowNode)
        : base(workflowNode) { }
#pragma warning restore CS8618

    public WorkflowNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowNodeFromRaw.FromRawUnchecked"/>
    public static WorkflowNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowNodeFromRaw : IFromRawJson<WorkflowNode>
{
    /// <inheritdoc/>
    public WorkflowNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WorkflowNode.FromRawUnchecked(rawData);
}

/// <summary>
/// Audit trail information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Audit, AuditFromRaw>))]
public sealed record class Audit : JsonModel
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

    public Audit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Audit(Audit audit)
        : base(audit) { }
#pragma warning restore CS8618

    public Audit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Audit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuditFromRaw.FromRawUnchecked"/>
    public static Audit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuditFromRaw : IFromRawJson<Audit>
{
    /// <inheritdoc/>
    public Audit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Audit.FromRawUnchecked(rawData);
}
