using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

[JsonConverter(
    typeof(JsonModelConverter<WorkflowRequestRelationship, WorkflowRequestRelationshipFromRaw>)
)]
public sealed record class WorkflowRequestRelationship : JsonModel
{
    public required FunctionVersionIdentifier DestinationFunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionVersionIdentifier>("destinationFunction");
        }
        init { this._rawData.Set("destinationFunction", value); }
    }

    public required FunctionVersionIdentifier SourceFunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionVersionIdentifier>("sourceFunction");
        }
        init { this._rawData.Set("sourceFunction", value); }
    }

    /// <summary>
    /// Name of destination.
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
        this.DestinationFunction.Validate();
        this.SourceFunction.Validate();
        _ = this.DestinationName;
    }

    public WorkflowRequestRelationship() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowRequestRelationship(WorkflowRequestRelationship workflowRequestRelationship)
        : base(workflowRequestRelationship) { }
#pragma warning restore CS8618

    public WorkflowRequestRelationship(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowRequestRelationship(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowRequestRelationshipFromRaw.FromRawUnchecked"/>
    public static WorkflowRequestRelationship FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowRequestRelationshipFromRaw : IFromRawJson<WorkflowRequestRelationship>
{
    /// <inheritdoc/>
    public WorkflowRequestRelationship FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowRequestRelationship.FromRawUnchecked(rawData);
}
