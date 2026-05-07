using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

/// <summary>
/// A single function call-site node in a workflow DAG.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WorkflowNode, WorkflowNodeFromRaw>))]
public sealed record class WorkflowNode : JsonModel
{
    /// <summary>
    /// The function (and version) to execute at this call site.
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
    /// Opaque free-form JSON object attached to this node. Stored and returned verbatim;
    /// the server does not interpret it. Intended for client-side concerns such as
    /// canvas display properties (position, color, collapsed state, etc.).
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

    /// <summary>
    /// Name for this call site. Must be unique within the workflow version. Defaults
    /// to the function's own name when omitted.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
        _ = this.Metadata;
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

    [SetsRequiredMembers]
    public WorkflowNode(FunctionVersionIdentifier function)
        : this()
    {
        this.Function = function;
    }
}

class WorkflowNodeFromRaw : IFromRawJson<WorkflowNode>
{
    /// <inheritdoc/>
    public WorkflowNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WorkflowNode.FromRawUnchecked(rawData);
}
