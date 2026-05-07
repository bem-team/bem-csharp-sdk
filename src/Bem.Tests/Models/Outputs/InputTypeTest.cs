using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Outputs;

namespace Bem.Tests.Models.Outputs;

public class InputTypeTest : TestBase
{
    [Theory]
    [InlineData(InputType.Csv)]
    [InlineData(InputType.Docx)]
    [InlineData(InputType.Email)]
    [InlineData(InputType.Heic)]
    [InlineData(InputType.Html)]
    [InlineData(InputType.Jpeg)]
    [InlineData(InputType.Json)]
    [InlineData(InputType.Heif)]
    [InlineData(InputType.M4a)]
    [InlineData(InputType.Mp3)]
    [InlineData(InputType.Pdf)]
    [InlineData(InputType.Png)]
    [InlineData(InputType.Text)]
    [InlineData(InputType.Wav)]
    [InlineData(InputType.Webp)]
    [InlineData(InputType.Xls)]
    [InlineData(InputType.Xlsx)]
    [InlineData(InputType.Xml)]
    public void Validation_Works(InputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InputType.Csv)]
    [InlineData(InputType.Docx)]
    [InlineData(InputType.Email)]
    [InlineData(InputType.Heic)]
    [InlineData(InputType.Html)]
    [InlineData(InputType.Jpeg)]
    [InlineData(InputType.Json)]
    [InlineData(InputType.Heif)]
    [InlineData(InputType.M4a)]
    [InlineData(InputType.Mp3)]
    [InlineData(InputType.Pdf)]
    [InlineData(InputType.Png)]
    [InlineData(InputType.Text)]
    [InlineData(InputType.Wav)]
    [InlineData(InputType.Webp)]
    [InlineData(InputType.Xls)]
    [InlineData(InputType.Xlsx)]
    [InlineData(InputType.Xml)]
    public void SerializationRoundtrip_Works(InputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
