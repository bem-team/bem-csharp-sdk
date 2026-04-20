using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;
using System = System;

namespace Bem.Models.Workflows;

[JsonConverter(typeof(JsonModelConverter<WorkflowCreateResponse, WorkflowCreateResponseFromRaw>))]
public sealed record class WorkflowCreateResponse : JsonModel
{
    /// <summary>
    /// Per-connector failures from the diff/apply phase. Empty or omitted when all
    /// operations succeeded.
    /// </summary>
    public IReadOnlyList<ConnectorError>? ConnectorErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ConnectorError>>(
                "connectorErrors"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ConnectorError>?>(
                "connectorErrors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
        foreach (var item in this.ConnectorErrors ?? [])
        {
            item.Validate();
        }
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

/// <summary>
/// Per-connector failure surfaced alongside a successful workflow DAG save.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConnectorError, ConnectorErrorFromRaw>))]
public sealed record class ConnectorError : JsonModel
{
    /// <summary>
    /// Machine-readable error code.
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Human-readable error message.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Which diff operation was attempted.
    /// </summary>
    public required ApiEnum<string, Operation> Operation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Operation>>("operation");
        }
        init { this._rawData.Set("operation", value); }
    }

    /// <summary>
    /// Populated for update/delete failures.
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
    /// Populated for create failures.
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
        _ = this.Code;
        _ = this.Message;
        this.Operation.Validate();
        _ = this.ConnectorID;
        _ = this.Name;
    }

    public ConnectorError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectorError(ConnectorError connectorError)
        : base(connectorError) { }
#pragma warning restore CS8618

    public ConnectorError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectorError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConnectorErrorFromRaw.FromRawUnchecked"/>
    public static ConnectorError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConnectorErrorFromRaw : IFromRawJson<ConnectorError>
{
    /// <inheritdoc/>
    public ConnectorError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ConnectorError.FromRawUnchecked(rawData);
}

/// <summary>
/// Which diff operation was attempted.
/// </summary>
[JsonConverter(typeof(OperationConverter))]
public enum Operation
{
    Create,
    Update,
    Delete,
}

sealed class OperationConverter : JsonConverter<Operation>
{
    public override Operation Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create" => Operation.Create,
            "update" => Operation.Update,
            "delete" => Operation.Delete,
            _ => (Operation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operation.Create => "create",
                Operation.Update => "update",
                Operation.Delete => "delete",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
