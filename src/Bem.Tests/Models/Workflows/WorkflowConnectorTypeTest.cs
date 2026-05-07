using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowConnectorTypeTest : TestBase
{
    [Theory]
    [InlineData(WorkflowConnectorType.Paragon)]
    public void Validation_Works(WorkflowConnectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkflowConnectorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkflowConnectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkflowConnectorType.Paragon)]
    public void SerializationRoundtrip_Works(WorkflowConnectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkflowConnectorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkflowConnectorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkflowConnectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkflowConnectorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
