using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions.Copy;

namespace Bem.Tests.Models.Functions.Copy;

public class FunctionCopyRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
            Tags = ["string"],
            TargetDisplayName = "targetDisplayName",
            TargetEnvironment = "targetEnvironment",
        };

        string expectedSourceFunctionName = "sourceFunctionName";
        string expectedTargetFunctionName = "targetFunctionName";
        List<string> expectedTags = ["string"];
        string expectedTargetDisplayName = "targetDisplayName";
        string expectedTargetEnvironment = "targetEnvironment";

        Assert.Equal(expectedSourceFunctionName, model.SourceFunctionName);
        Assert.Equal(expectedTargetFunctionName, model.TargetFunctionName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedTargetDisplayName, model.TargetDisplayName);
        Assert.Equal(expectedTargetEnvironment, model.TargetEnvironment);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
            Tags = ["string"],
            TargetDisplayName = "targetDisplayName",
            TargetEnvironment = "targetEnvironment",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCopyRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
            Tags = ["string"],
            TargetDisplayName = "targetDisplayName",
            TargetEnvironment = "targetEnvironment",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCopyRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSourceFunctionName = "sourceFunctionName";
        string expectedTargetFunctionName = "targetFunctionName";
        List<string> expectedTags = ["string"];
        string expectedTargetDisplayName = "targetDisplayName";
        string expectedTargetEnvironment = "targetEnvironment";

        Assert.Equal(expectedSourceFunctionName, deserialized.SourceFunctionName);
        Assert.Equal(expectedTargetFunctionName, deserialized.TargetFunctionName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedTargetDisplayName, deserialized.TargetDisplayName);
        Assert.Equal(expectedTargetEnvironment, deserialized.TargetEnvironment);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
            Tags = ["string"],
            TargetDisplayName = "targetDisplayName",
            TargetEnvironment = "targetEnvironment",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
        };

        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.TargetDisplayName);
        Assert.False(model.RawData.ContainsKey("targetDisplayName"));
        Assert.Null(model.TargetEnvironment);
        Assert.False(model.RawData.ContainsKey("targetEnvironment"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",

            // Null should be interpreted as omitted for these properties
            Tags = null,
            TargetDisplayName = null,
            TargetEnvironment = null,
        };

        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.TargetDisplayName);
        Assert.False(model.RawData.ContainsKey("targetDisplayName"));
        Assert.Null(model.TargetEnvironment);
        Assert.False(model.RawData.ContainsKey("targetEnvironment"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",

            // Null should be interpreted as omitted for these properties
            Tags = null,
            TargetDisplayName = null,
            TargetEnvironment = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionCopyRequest
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
            Tags = ["string"],
            TargetDisplayName = "targetDisplayName",
            TargetEnvironment = "targetEnvironment",
        };

        FunctionCopyRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
