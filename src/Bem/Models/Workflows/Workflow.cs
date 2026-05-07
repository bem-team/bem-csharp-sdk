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
    /// Connectors currently attached to this workflow. For version-scoped reads (`/versions/{n}`)
    /// this is always empty — connectors are current-state and not part of version history.
    /// </summary>
    public required IReadOnlyList<Connector> Connectors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Connector>>("connectors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Connector>>(
                "connectors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        foreach (var item in this.Connectors)
        {
            item.Validate();
        }
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
/// A connector attached to a workflow. Ingestion point that triggers the workflow.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Connector, ConnectorFromRaw>))]
public sealed record class Connector : JsonModel
{
    /// <summary>
    /// Unique connector API ID.
    /// </summary>
    public required string ConnectorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("connectorID");
        }
        init { this._rawData.Set("connectorID", value); }
    }

    /// <summary>
    /// Human-friendly connector name.
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
    /// Discriminator for a workflow connector. V3 supports `paragon` only.
    /// </summary>
    public required ApiEnum<string, WorkflowConnectorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WorkflowConnectorType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Paragon-integration configuration on a workflow connector.
    /// </summary>
    public Paragon? Paragon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Paragon>("paragon");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paragon", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectorID;
        _ = this.Name;
        this.Type.Validate();
        this.Paragon?.Validate();
    }

    public Connector() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Connector(Connector connector)
        : base(connector) { }
#pragma warning restore CS8618

    public Connector(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Connector(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConnectorFromRaw.FromRawUnchecked"/>
    public static Connector FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConnectorFromRaw : IFromRawJson<Connector>
{
    /// <inheritdoc/>
    public Connector FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Connector.FromRawUnchecked(rawData);
}

/// <summary>
/// Paragon-integration configuration on a workflow connector.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Paragon, ParagonFromRaw>))]
public sealed record class Paragon : JsonModel
{
    /// <summary>
    /// Opaque per-integration configuration (e.g. `{"folderId": "..."}`).
    /// </summary>
    public required JsonElement Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("configuration");
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <summary>
    /// Paragon integration key (e.g. "googledrive").
    /// </summary>
    public required string Integration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("integration");
        }
        init { this._rawData.Set("integration", value); }
    }

    /// <summary>
    /// Paragon sync ID managed by the server. Read-only.
    /// </summary>
    public required string SyncID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("syncID");
        }
        init { this._rawData.Set("syncID", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Configuration;
        _ = this.Integration;
        _ = this.SyncID;
    }

    public Paragon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Paragon(Paragon paragon)
        : base(paragon) { }
#pragma warning restore CS8618

    public Paragon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Paragon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParagonFromRaw.FromRawUnchecked"/>
    public static Paragon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParagonFromRaw : IFromRawJson<Paragon>
{
    /// <inheritdoc/>
    public Paragon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Paragon.FromRawUnchecked(rawData);
}
