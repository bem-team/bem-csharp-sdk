using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

/// <summary>
/// Create/update entry for a connector inline with the workflow.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WorkflowConnector, WorkflowConnectorFromRaw>))]
public sealed record class WorkflowConnector : JsonModel
{
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
    /// Present → update. Absent → create.
    /// </summary>
    public string? ConnectorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connectorID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectorID", value);
        }
    }

    /// <summary>
    /// Request-side config block for a Paragon connector. Fields absent on update
    /// are unchanged.
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
        _ = this.Name;
        this.Type.Validate();
        _ = this.ConnectorID;
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
/// Request-side config block for a Paragon connector. Fields absent on update are unchanged.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WorkflowConnectorParagon, WorkflowConnectorParagonFromRaw>)
)]
public sealed record class WorkflowConnectorParagon : JsonModel
{
    /// <summary>
    /// Opaque per-integration configuration. Required on create.
    /// </summary>
    public JsonElement? Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("configuration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configuration", value);
        }
    }

    /// <summary>
    /// Paragon integration key. Required on create.
    /// </summary>
    public string? Integration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("integration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("integration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Configuration;
        _ = this.Integration;
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
