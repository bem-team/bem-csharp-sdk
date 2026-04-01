using System;
using System.Collections.Generic;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowCopyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkflowCopyParams
        {
            SourceWorkflowName = "sourceWorkflowName",
            TargetWorkflowName = "targetWorkflowName",
            SourceWorkflowVersionNum = 1,
            Tags = ["string"],
            TargetDisplayName = "targetDisplayName",
            TargetEnvironment = "targetEnvironment",
        };

        string expectedSourceWorkflowName = "sourceWorkflowName";
        string expectedTargetWorkflowName = "targetWorkflowName";
        long expectedSourceWorkflowVersionNum = 1;
        List<string> expectedTags = ["string"];
        string expectedTargetDisplayName = "targetDisplayName";
        string expectedTargetEnvironment = "targetEnvironment";

        Assert.Equal(expectedSourceWorkflowName, parameters.SourceWorkflowName);
        Assert.Equal(expectedTargetWorkflowName, parameters.TargetWorkflowName);
        Assert.Equal(expectedSourceWorkflowVersionNum, parameters.SourceWorkflowVersionNum);
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
        var parameters = new WorkflowCopyParams
        {
            SourceWorkflowName = "sourceWorkflowName",
            TargetWorkflowName = "targetWorkflowName",
        };

        Assert.Null(parameters.SourceWorkflowVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("sourceWorkflowVersionNum"));
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
        var parameters = new WorkflowCopyParams
        {
            SourceWorkflowName = "sourceWorkflowName",
            TargetWorkflowName = "targetWorkflowName",

            // Null should be interpreted as omitted for these properties
            SourceWorkflowVersionNum = null,
            Tags = null,
            TargetDisplayName = null,
            TargetEnvironment = null,
        };

        Assert.Null(parameters.SourceWorkflowVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("sourceWorkflowVersionNum"));
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
        WorkflowCopyParams parameters = new()
        {
            SourceWorkflowName = "sourceWorkflowName",
            TargetWorkflowName = "targetWorkflowName",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/workflows/copy"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkflowCopyParams
        {
            SourceWorkflowName = "sourceWorkflowName",
            TargetWorkflowName = "targetWorkflowName",
            SourceWorkflowVersionNum = 1,
            Tags = ["string"],
            TargetDisplayName = "targetDisplayName",
            TargetEnvironment = "targetEnvironment",
        };

        WorkflowCopyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
