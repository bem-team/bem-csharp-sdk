using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;
using System = System;

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
    public required IReadOnlyList<WorkflowConnector> Connectors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkflowConnector>>("connectors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkflowConnector>>(
                "connectors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The date and time the workflow was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
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
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updatedAt");
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
[JsonConverter(typeof(JsonModelConverter<WorkflowConnector, WorkflowConnectorFromRaw>))]
public sealed record class WorkflowConnector : JsonModel
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
    public WorkflowConnectorParagon? Paragon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowConnectorParagon>("paragon");
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

    public WorkflowConnector() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowConnector(WorkflowConnector workflowConnector)
        : base(workflowConnector) { }
#pragma warning restore CS8618

    public WorkflowConnector(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowConnector(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowConnectorFromRaw.FromRawUnchecked"/>
    public static WorkflowConnector FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowConnectorFromRaw : IFromRawJson<WorkflowConnector>
{
    /// <inheritdoc/>
    public WorkflowConnector FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WorkflowConnector.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator for a workflow connector. V3 supports `paragon` only.
/// </summary>
[JsonConverter(typeof(WorkflowConnectorTypeConverter))]
public enum WorkflowConnectorType
{
    Paragon,
}

sealed class WorkflowConnectorTypeConverter : JsonConverter<WorkflowConnectorType>
{
    public override WorkflowConnectorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "paragon" => WorkflowConnectorType.Paragon,
            _ => (WorkflowConnectorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkflowConnectorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkflowConnectorType.Paragon => "paragon",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Paragon-integration configuration on a workflow connector.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WorkflowConnectorParagon, WorkflowConnectorParagonFromRaw>)
)]
public sealed record class WorkflowConnectorParagon : JsonModel
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

    public WorkflowConnectorParagon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowConnectorParagon(WorkflowConnectorParagon workflowConnectorParagon)
        : base(workflowConnectorParagon) { }
#pragma warning restore CS8618

    public WorkflowConnectorParagon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowConnectorParagon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowConnectorParagonFromRaw.FromRawUnchecked"/>
    public static WorkflowConnectorParagon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowConnectorParagonFromRaw : IFromRawJson<WorkflowConnectorParagon>
{
    /// <inheritdoc/>
    public WorkflowConnectorParagon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowConnectorParagon.FromRawUnchecked(rawData);
}
