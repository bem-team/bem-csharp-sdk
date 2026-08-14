using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class RenderConfigInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RenderConfigInput
        {
            Template = new() { Base64 = "base64", Name = "name" },
        };

        RenderConfigInputTemplate expectedTemplate = new() { Base64 = "base64", Name = "name" };

        Assert.Equal(expectedTemplate, model.Template);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RenderConfigInput
        {
            Template = new() { Base64 = "base64", Name = "name" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RenderConfigInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RenderConfigInput
        {
            Template = new() { Base64 = "base64", Name = "name" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RenderConfigInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RenderConfigInputTemplate expectedTemplate = new() { Base64 = "base64", Name = "name" };

        Assert.Equal(expectedTemplate, deserialized.Template);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RenderConfigInput
        {
            Template = new() { Base64 = "base64", Name = "name" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RenderConfigInput
        {
            Template = new() { Base64 = "base64", Name = "name" },
        };

        RenderConfigInput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RenderConfigInputTemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RenderConfigInputTemplate { Base64 = "base64", Name = "name" };

        string expectedBase64 = "base64";
        string expectedName = "name";

        Assert.Equal(expectedBase64, model.Base64);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RenderConfigInputTemplate { Base64 = "base64", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RenderConfigInputTemplate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RenderConfigInputTemplate { Base64 = "base64", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RenderConfigInputTemplate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBase64 = "base64";
        string expectedName = "name";

        Assert.Equal(expectedBase64, deserialized.Base64);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RenderConfigInputTemplate { Base64 = "base64", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RenderConfigInputTemplate { Base64 = "base64" };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RenderConfigInputTemplate { Base64 = "base64" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RenderConfigInputTemplate
        {
            Base64 = "base64",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RenderConfigInputTemplate
        {
            Base64 = "base64",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RenderConfigInputTemplate { Base64 = "base64", Name = "name" };

        RenderConfigInputTemplate copied = new(model);

        Assert.Equal(model, copied);
    }
}
