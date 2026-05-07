using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

[JsonConverter(typeof(JsonModelConverter<WorkflowUpdateResponse, WorkflowUpdateResponseFromRaw>))]
public sealed record class WorkflowUpdateResponse : JsonModel
{
    /// <summary>
    /// Per-connector failures from the diff/apply phase. Empty or omitted when all
    /// operations succeeded.
    /// </summary>
    public IReadOnlyList<WorkflowConnectorError>? ConnectorErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorkflowConnectorError>>(
                "connectorErrors"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorkflowConnectorError>?>(
                "connectorErrors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error message if the workflow update failed.
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
        foreach (var item in this.ConnectorErrors ?? [])
        {
            item.Validate();
        }
        _ = this.Error;
        this.Workflow?.Validate();
    }

    public WorkflowUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateResponse(WorkflowUpdateResponse workflowUpdateResponse)
        : base(workflowUpdateResponse) { }
#pragma warning restore CS8618

    public WorkflowUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateResponseFromRaw : IFromRawJson<WorkflowUpdateResponse>
{
    /// <inheritdoc/>
    public WorkflowUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateResponse.FromRawUnchecked(rawData);
}
