using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionTypeTest : TestBase
{
    [Theory]
    [InlineData(FunctionType.Transform)]
    [InlineData(FunctionType.Extract)]
    [InlineData(FunctionType.Route)]
    [InlineData(FunctionType.Classify)]
    [InlineData(FunctionType.Send)]
    [InlineData(FunctionType.Split)]
    [InlineData(FunctionType.Join)]
    [InlineData(FunctionType.Analyze)]
    [InlineData(FunctionType.PayloadShaping)]
    [InlineData(FunctionType.Enrich)]
    [InlineData(FunctionType.Parse)]
    public void Validation_Works(FunctionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionType.Transform)]
    [InlineData(FunctionType.Extract)]
    [InlineData(FunctionType.Route)]
    [InlineData(FunctionType.Classify)]
    [InlineData(FunctionType.Send)]
    [InlineData(FunctionType.Split)]
    [InlineData(FunctionType.Join)]
    [InlineData(FunctionType.Analyze)]
    [InlineData(FunctionType.PayloadShaping)]
    [InlineData(FunctionType.Enrich)]
    [InlineData(FunctionType.Parse)]
    public void SerializationRoundtrip_Works(FunctionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
