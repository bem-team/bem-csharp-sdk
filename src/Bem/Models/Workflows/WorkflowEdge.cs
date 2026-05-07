using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

/// <summary>
/// A directed edge between two named call-site nodes.
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
    /// Labelled outlet on the source node that activates this edge. Omit for the
    /// default (unlabelled) outlet.
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
    /// Opaque free-form JSON object attached to this edge. Stored and returned verbatim;
    /// the server does not interpret it.
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
