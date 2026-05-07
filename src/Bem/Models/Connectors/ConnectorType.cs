using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Exceptions;

namespace Bem.Models.Connectors;

/// <summary>
/// Connector type.
/// </summary>
[JsonConverter(typeof(ConnectorTypeConverter))]
public enum ConnectorType
{
    Box,
    Paragon,
}

sealed class ConnectorTypeConverter : JsonConverter<ConnectorType>
{
    public override ConnectorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "box" => ConnectorType.Box,
            "paragon" => ConnectorType.Paragon,
            _ => (ConnectorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConnectorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConnectorType.Box => "box",
                ConnectorType.Paragon => "paragon",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
