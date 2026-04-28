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
    Extract,
    Route,
    Classify,
    Send,
    Split,
    Join,
    Analyze,
    PayloadShaping,
    Enrich,
    Parse,
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
            "extract" => FunctionType.Extract,
            "route" => FunctionType.Route,
            "classify" => FunctionType.Classify,
            "send" => FunctionType.Send,
            "split" => FunctionType.Split,
            "join" => FunctionType.Join,
            "analyze" => FunctionType.Analyze,
            "payload_shaping" => FunctionType.PayloadShaping,
            "enrich" => FunctionType.Enrich,
            "parse" => FunctionType.Parse,
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
                FunctionType.Extract => "extract",
                FunctionType.Route => "route",
                FunctionType.Classify => "classify",
                FunctionType.Send => "send",
                FunctionType.Split => "split",
                FunctionType.Join => "join",
                FunctionType.Analyze => "analyze",
                FunctionType.PayloadShaping => "payload_shaping",
                FunctionType.Enrich => "enrich",
                FunctionType.Parse => "parse",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
