using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

[JsonConverter(
    typeof(JsonModelConverter<WorkflowRetrieveResponse, WorkflowRetrieveResponseFromRaw>)
)]
public sealed record class WorkflowRetrieveResponse : JsonModel
{
    /// <summary>
    /// Error message if the workflow retrieval failed.
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

    public WorkflowRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowRetrieveResponse(WorkflowRetrieveResponse workflowRetrieveResponse)
        : base(workflowRetrieveResponse) { }
#pragma warning restore CS8618

    public WorkflowRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowRetrieveResponseFromRaw : IFromRawJson<WorkflowRetrieveResponse>
{
    /// <inheritdoc/>
    public WorkflowRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowRetrieveResponse.FromRawUnchecked(rawData);
}
