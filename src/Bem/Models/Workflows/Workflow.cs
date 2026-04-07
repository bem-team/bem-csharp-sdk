using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

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
    public required IReadOnlyList<WorkflowEdgeResponse> Edges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkflowEdgeResponse>>("edges");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowEdgeResponse>>(
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
    public required IReadOnlyList<WorkflowNodeResponse> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkflowNodeResponse>>("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowNodeResponse>>(
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
    public WorkflowAudit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowAudit>("audit");
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
