using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Connectors;

namespace Bem.Tests.Models.Connectors;

public class ConnectorTypeTest : TestBase
{
    [Theory]
    [InlineData(ConnectorType.Box)]
    [InlineData(ConnectorType.Paragon)]
    public void Validation_Works(ConnectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConnectorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConnectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConnectorType.Box)]
    [InlineData(ConnectorType.Paragon)]
    public void SerializationRoundtrip_Works(ConnectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConnectorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConnectorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConnectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConnectorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
