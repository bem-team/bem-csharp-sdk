using System;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkflowDeleteParams { WorkflowName = "workflowName" };

        string expectedWorkflowName = "workflowName";

        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
    }

    [Fact]
    public void Url_Works()
    {
        WorkflowDeleteParams parameters = new() { WorkflowName = "workflowName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/workflows/workflowName"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkflowDeleteParams { WorkflowName = "workflowName" };

        WorkflowDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
