using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class ParseExtraFunctionConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParseExtraFunctionConfig { EnableBoundingBoxes = true };

        bool expectedEnableBoundingBoxes = true;

        Assert.Equal(expectedEnableBoundingBoxes, model.EnableBoundingBoxes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParseExtraFunctionConfig { EnableBoundingBoxes = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParseExtraFunctionConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParseExtraFunctionConfig { EnableBoundingBoxes = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParseExtraFunctionConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnableBoundingBoxes = true;

        Assert.Equal(expectedEnableBoundingBoxes, deserialized.EnableBoundingBoxes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParseExtraFunctionConfig { EnableBoundingBoxes = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ParseExtraFunctionConfig { };

        Assert.Null(model.EnableBoundingBoxes);
        Assert.False(model.RawData.ContainsKey("enableBoundingBoxes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ParseExtraFunctionConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ParseExtraFunctionConfig
        {
            // Null should be interpreted as omitted for these properties
            EnableBoundingBoxes = null,
        };

        Assert.Null(model.EnableBoundingBoxes);
        Assert.False(model.RawData.ContainsKey("enableBoundingBoxes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ParseExtraFunctionConfig
        {
            // Null should be interpreted as omitted for these properties
            EnableBoundingBoxes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParseExtraFunctionConfig { EnableBoundingBoxes = true };

        ParseExtraFunctionConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
