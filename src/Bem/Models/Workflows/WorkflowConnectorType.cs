using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Exceptions;

namespace Bem.Models.Workflows;

/// <summary>
/// Discriminator for a workflow connector. V3 supports `paragon` only.
/// </summary>
[JsonConverter(typeof(WorkflowConnectorTypeConverter))]
public enum WorkflowConnectorType
{
    Paragon,
}

sealed class WorkflowConnectorTypeConverter : JsonConverter<WorkflowConnectorType>
{
    public override WorkflowConnectorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "paragon" => WorkflowConnectorType.Paragon,
            _ => (WorkflowConnectorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkflowConnectorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkflowConnectorType.Paragon => "paragon",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
