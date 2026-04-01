using System.Text.Json;
using Bem.Core;
using Bem.Models.Outputs;

namespace Bem.Tests.Models.Outputs;

public class AnyTypeTest : TestBase
{
    [Fact]
    public void JsonElementValidationWorks()
    {
        AnyType value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        AnyType value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AnyType value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        AnyType value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        AnyType value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        AnyType value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnyType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        AnyType value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnyType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AnyType value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnyType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AnyType value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnyType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        AnyType value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnyType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
