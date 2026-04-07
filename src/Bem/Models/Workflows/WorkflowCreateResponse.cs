using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

[JsonConverter(typeof(JsonModelConverter<WorkflowCreateResponse, WorkflowCreateResponseFromRaw>))]
public sealed record class WorkflowCreateResponse : JsonModel
{
    /// <summary>
    /// Error message if the workflow creation failed.
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
        _ = this.Error;
        this.Workflow?.Validate();
    }

    public WorkflowCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCreateResponse(WorkflowCreateResponse workflowCreateResponse)
        : base(workflowCreateResponse) { }
#pragma warning restore CS8618

    public WorkflowCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowCreateResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowCreateResponseFromRaw : IFromRawJson<WorkflowCreateResponse>
{
    /// <inheritdoc/>
    public WorkflowCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowCreateResponse.FromRawUnchecked(rawData);
}
