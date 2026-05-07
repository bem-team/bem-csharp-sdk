using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Workflows;

/// <summary>
/// Per-connector failure surfaced alongside a successful workflow DAG save.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WorkflowConnectorError, WorkflowConnectorErrorFromRaw>))]
public sealed record class WorkflowConnectorError : JsonModel
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

    public WorkflowConnectorError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowConnectorError(WorkflowConnectorError workflowConnectorError)
        : base(workflowConnectorError) { }
#pragma warning restore CS8618

    public WorkflowConnectorError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowConnectorError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowConnectorErrorFromRaw.FromRawUnchecked"/>
    public static WorkflowConnectorError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowConnectorErrorFromRaw : IFromRawJson<WorkflowConnectorError>
{
    /// <inheritdoc/>
    public WorkflowConnectorError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowConnectorError.FromRawUnchecked(rawData);
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
        Type typeToConvert,
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
