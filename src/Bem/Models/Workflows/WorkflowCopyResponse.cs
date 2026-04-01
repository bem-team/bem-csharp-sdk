using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows;

[JsonConverter(typeof(JsonModelConverter<WorkflowCopyResponse, WorkflowCopyResponseFromRaw>))]
public sealed record class WorkflowCopyResponse : JsonModel
{
    /// <summary>
    /// Information about functions that were copied when copying to a different environment.
    /// Empty when copying within the same environment.
    /// </summary>
    public IReadOnlyList<CopiedFunction>? CopiedFunctions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CopiedFunction>>(
                "copiedFunctions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CopiedFunction>?>(
                "copiedFunctions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The environment where the workflow was copied to.
    /// </summary>
    public string? Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("environment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("environment", value);
        }
    }

    /// <summary>
    /// Error message if the workflow copy failed.
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
    /// The newly created workflow.
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
        foreach (var item in this.CopiedFunctions ?? [])
        {
            item.Validate();
        }
        _ = this.Environment;
        _ = this.Error;
        this.Workflow?.Validate();
    }

    public WorkflowCopyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCopyResponse(WorkflowCopyResponse workflowCopyResponse)
        : base(workflowCopyResponse) { }
#pragma warning restore CS8618

    public WorkflowCopyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCopyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowCopyResponseFromRaw.FromRawUnchecked"/>
    public static WorkflowCopyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowCopyResponseFromRaw : IFromRawJson<WorkflowCopyResponse>
{
    /// <inheritdoc/>
    public WorkflowCopyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowCopyResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CopiedFunction, CopiedFunctionFromRaw>))]
public sealed record class CopiedFunction : JsonModel
{
    /// <summary>
    /// ID of the source function that was copied.
    /// </summary>
    public required string SourceFunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceFunctionID");
        }
        init { this._rawData.Set("sourceFunctionID", value); }
    }

    /// <summary>
    /// Name of the source function that was copied.
    /// </summary>
    public required string SourceFunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceFunctionName");
        }
        init { this._rawData.Set("sourceFunctionName", value); }
    }

    /// <summary>
    /// Version number of the source function that was copied.
    /// </summary>
    public required long SourceVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sourceVersionNum");
        }
        init { this._rawData.Set("sourceVersionNum", value); }
    }

    /// <summary>
    /// ID of the newly created function in the target environment.
    /// </summary>
    public required string TargetFunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("targetFunctionID");
        }
        init { this._rawData.Set("targetFunctionID", value); }
    }

    /// <summary>
    /// Name of the newly created function in the target environment.
    /// </summary>
    public required string TargetFunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("targetFunctionName");
        }
        init { this._rawData.Set("targetFunctionName", value); }
    }

    /// <summary>
    /// Version number of the newly created function in the target environment.
    /// </summary>
    public required long TargetVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("targetVersionNum");
        }
        init { this._rawData.Set("targetVersionNum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SourceFunctionID;
        _ = this.SourceFunctionName;
        _ = this.SourceVersionNum;
        _ = this.TargetFunctionID;
        _ = this.TargetFunctionName;
        _ = this.TargetVersionNum;
    }

    public CopiedFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CopiedFunction(CopiedFunction copiedFunction)
        : base(copiedFunction) { }
#pragma warning restore CS8618

    public CopiedFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CopiedFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CopiedFunctionFromRaw.FromRawUnchecked"/>
    public static CopiedFunction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CopiedFunctionFromRaw : IFromRawJson<CopiedFunction>
{
    /// <inheritdoc/>
    public CopiedFunction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CopiedFunction.FromRawUnchecked(rawData);
}
