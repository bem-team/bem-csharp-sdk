using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

/// <summary>
/// Read representation of a call-site node.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WorkflowNodeResponse, WorkflowNodeResponseFromRaw>))]
public sealed record class WorkflowNodeResponse : JsonModel
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

    public WorkflowNodeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowNodeResponse(WorkflowNodeResponse workflowNodeResponse)
        : base(workflowNodeResponse) { }
#pragma warning restore CS8618

    public WorkflowNodeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowNodeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowNodeResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowNodeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowNodeResponseFromRaw : IFromRawJson<WorkflowNodeResponse>
{
    /// <inheritdoc/>
    public WorkflowNodeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowNodeResponse.FromRawUnchecked(rawData);
}
