using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Exceptions;

namespace Bem.Models.Outputs;

/// <summary>
/// The input type of the content you're sending for transformation.
/// </summary>
[JsonConverter(typeof(InputTypeConverter))]
public enum InputType
{
    Csv,
    Docx,
    Email,
    Heic,
    Html,
    Jpeg,
    Json,
    Heif,
    M4a,
    Mp3,
    Pdf,
    Png,
    Text,
    Wav,
    Webp,
    Xls,
    Xlsx,
    Xml,
}

sealed class InputTypeConverter : JsonConverter<InputType>
{
    public override InputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => InputType.Csv,
            "docx" => InputType.Docx,
            "email" => InputType.Email,
            "heic" => InputType.Heic,
            "html" => InputType.Html,
            "jpeg" => InputType.Jpeg,
            "json" => InputType.Json,
            "heif" => InputType.Heif,
            "m4a" => InputType.M4a,
            "mp3" => InputType.Mp3,
            "pdf" => InputType.Pdf,
            "png" => InputType.Png,
            "text" => InputType.Text,
            "wav" => InputType.Wav,
            "webp" => InputType.Webp,
            "xls" => InputType.Xls,
            "xlsx" => InputType.Xlsx,
            "xml" => InputType.Xml,
            _ => (InputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InputType.Csv => "csv",
                InputType.Docx => "docx",
                InputType.Email => "email",
                InputType.Heic => "heic",
                InputType.Html => "html",
                InputType.Jpeg => "jpeg",
                InputType.Json => "json",
                InputType.Heif => "heif",
                InputType.M4a => "m4a",
                InputType.Mp3 => "mp3",
                InputType.Pdf => "pdf",
                InputType.Png => "png",
                InputType.Text => "text",
                InputType.Wav => "wav",
                InputType.Webp => "webp",
                InputType.Xls => "xls",
                InputType.Xlsx => "xlsx",
                InputType.Xml => "xml",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
