using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class SendDestinationTypeTest : TestBase
{
    [Theory]
    [InlineData(SendDestinationType.Webhook)]
    [InlineData(SendDestinationType.S3)]
    [InlineData(SendDestinationType.GoogleDrive)]
    public void Validation_Works(SendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SendDestinationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SendDestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SendDestinationType.Webhook)]
    [InlineData(SendDestinationType.S3)]
    [InlineData(SendDestinationType.GoogleDrive)]
    public void SerializationRoundtrip_Works(SendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SendDestinationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SendDestinationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SendDestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SendDestinationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
