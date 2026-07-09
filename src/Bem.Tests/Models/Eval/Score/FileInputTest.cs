using System.Text.Json;
using Bem.Core;
using Bem.Models.Eval.Score;
using Bem.Models.Outputs;

namespace Bem.Tests.Models.Eval.Score;

public class FileInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileInput { InputContent = "inputContent", InputType = InputType.Csv };

        string expectedInputContent = "inputContent";
        ApiEnum<string, InputType> expectedInputType = InputType.Csv;

        Assert.Equal(expectedInputContent, model.InputContent);
        Assert.Equal(expectedInputType, model.InputType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileInput { InputContent = "inputContent", InputType = InputType.Csv };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileInput>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileInput { InputContent = "inputContent", InputType = InputType.Csv };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInputContent = "inputContent";
        ApiEnum<string, InputType> expectedInputType = InputType.Csv;

        Assert.Equal(expectedInputContent, deserialized.InputContent);
        Assert.Equal(expectedInputType, deserialized.InputType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileInput { InputContent = "inputContent", InputType = InputType.Csv };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileInput { InputContent = "inputContent", InputType = InputType.Csv };

        FileInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
