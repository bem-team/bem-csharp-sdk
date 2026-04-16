using System;
using System.Collections.Generic;
using Bem.Models.Functions.Copy;

namespace Bem.Tests.Models.Functions.Copy;

public class CopyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CopyCreateParams
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

        Assert.Equal(expectedSourceFunctionName, parameters.SourceFunctionName);
        Assert.Equal(expectedTargetFunctionName, parameters.TargetFunctionName);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
        Assert.Equal(expectedTargetDisplayName, parameters.TargetDisplayName);
        Assert.Equal(expectedTargetEnvironment, parameters.TargetEnvironment);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CopyCreateParams
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
        };

        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.TargetDisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("targetDisplayName"));
        Assert.Null(parameters.TargetEnvironment);
        Assert.False(parameters.RawBodyData.ContainsKey("targetEnvironment"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CopyCreateParams
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",

            // Null should be interpreted as omitted for these properties
            Tags = null,
            TargetDisplayName = null,
            TargetEnvironment = null,
        };

        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.TargetDisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("targetDisplayName"));
        Assert.Null(parameters.TargetEnvironment);
        Assert.False(parameters.RawBodyData.ContainsKey("targetEnvironment"));
    }

    [Fact]
    public void Url_Works()
    {
        CopyCreateParams parameters = new()
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions/copy"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CopyCreateParams
        {
            SourceFunctionName = "sourceFunctionName",
            TargetFunctionName = "targetFunctionName",
            Tags = ["string"],
            TargetDisplayName = "targetDisplayName",
            TargetEnvironment = "targetEnvironment",
        };

        CopyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
