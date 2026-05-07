using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// Destination type for a Send function.
/// </summary>
[JsonConverter(typeof(SendDestinationTypeConverter))]
public enum SendDestinationType
{
    Webhook,
    S3,
    GoogleDrive,
}

sealed class SendDestinationTypeConverter : JsonConverter<SendDestinationType>
{
    public override SendDestinationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => SendDestinationType.Webhook,
            "s3" => SendDestinationType.S3,
            "google_drive" => SendDestinationType.GoogleDrive,
            _ => (SendDestinationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SendDestinationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SendDestinationType.Webhook => "webhook",
                SendDestinationType.S3 => "s3",
                SendDestinationType.GoogleDrive => "google_drive",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
