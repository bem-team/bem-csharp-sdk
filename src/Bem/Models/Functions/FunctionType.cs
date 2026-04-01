using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// The type of the function.
/// </summary>
[JsonConverter(typeof(FunctionTypeConverter))]
public enum FunctionType
{
    Transform,
    Route,
    Split,
    Join,
    Analyze,
    PayloadShaping,
    Enrich,
}

sealed class FunctionTypeConverter : JsonConverter<FunctionType>
{
    public override FunctionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transform" => FunctionType.Transform,
            "route" => FunctionType.Route,
            "split" => FunctionType.Split,
            "join" => FunctionType.Join,
            "analyze" => FunctionType.Analyze,
            "payload_shaping" => FunctionType.PayloadShaping,
            "enrich" => FunctionType.Enrich,
            _ => (FunctionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionType.Transform => "transform",
                FunctionType.Route => "route",
                FunctionType.Split => "split",
                FunctionType.Join => "join",
                FunctionType.Analyze => "analyze",
                FunctionType.PayloadShaping => "payload_shaping",
                FunctionType.Enrich => "enrich",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
