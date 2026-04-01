using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowCallParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkflowCallParams
        {
            WorkflowName = "workflowName",
            CallReferenceID = "callReferenceID",
            File = JsonSerializer.Deserialize<JsonElement>("{}"),
            Files = ["string"],
            Wait = "wait",
        };

        string expectedWorkflowName = "workflowName";
        string expectedCallReferenceID = "callReferenceID";
        JsonElement expectedFile = JsonSerializer.Deserialize<JsonElement>("{}");
        List<string> expectedFiles = ["string"];
        string expectedWait = "wait";

        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
        Assert.Equal(expectedCallReferenceID, parameters.CallReferenceID);
        Assert.NotNull(parameters.File);
        Assert.True(JsonElement.DeepEquals(expectedFile, parameters.File.Value));
        Assert.NotNull(parameters.Files);
        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], parameters.Files[i]);
        }
        Assert.Equal(expectedWait, parameters.Wait);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkflowCallParams { WorkflowName = "workflowName" };

        Assert.Null(parameters.CallReferenceID);
        Assert.False(parameters.RawBodyData.ContainsKey("callReferenceID"));
        Assert.Null(parameters.File);
        Assert.False(parameters.RawBodyData.ContainsKey("file"));
        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
        Assert.Null(parameters.Wait);
        Assert.False(parameters.RawBodyData.ContainsKey("wait"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkflowCallParams
        {
            WorkflowName = "workflowName",

            // Null should be interpreted as omitted for these properties
            CallReferenceID = null,
            File = null,
            Files = null,
            Wait = null,
        };

        Assert.Null(parameters.CallReferenceID);
        Assert.False(parameters.RawBodyData.ContainsKey("callReferenceID"));
        Assert.Null(parameters.File);
        Assert.False(parameters.RawBodyData.ContainsKey("file"));
        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
        Assert.Null(parameters.Wait);
        Assert.False(parameters.RawBodyData.ContainsKey("wait"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkflowCallParams parameters = new() { WorkflowName = "workflowName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/workflows/workflowName/call"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkflowCallParams
        {
            WorkflowName = "workflowName",
            CallReferenceID = "callReferenceID",
            File = JsonSerializer.Deserialize<JsonElement>("{}"),
            Files = ["string"],
            Wait = "wait",
        };

        WorkflowCallParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
