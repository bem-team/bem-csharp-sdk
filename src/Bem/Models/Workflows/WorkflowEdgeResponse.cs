using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

/// <summary>
/// Read representation of a directed edge between call-site nodes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WorkflowEdgeResponse, WorkflowEdgeResponseFromRaw>))]
public sealed record class WorkflowEdgeResponse : JsonModel
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

    /// <summary>
    /// Opaque free-form JSON object attached to this edge on create/update. Returned
    /// verbatim; never interpreted by the server.
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DestinationNodeName;
        _ = this.SourceNodeName;
        _ = this.DestinationName;
        _ = this.Metadata;
    }

    public WorkflowEdgeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowEdgeResponse(WorkflowEdgeResponse workflowEdgeResponse)
        : base(workflowEdgeResponse) { }
#pragma warning restore CS8618

    public WorkflowEdgeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowEdgeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowEdgeResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowEdgeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowEdgeResponseFromRaw : IFromRawJson<WorkflowEdgeResponse>
{
    /// <inheritdoc/>
    public WorkflowEdgeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowEdgeResponse.FromRawUnchecked(rawData);
}
