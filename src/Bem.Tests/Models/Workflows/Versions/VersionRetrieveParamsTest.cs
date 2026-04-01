using System;
using Bem.Models.Workflows.Versions;

namespace Bem.Tests.Models.Workflows.Versions;

public class VersionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionRetrieveParams
        {
            WorkflowName = "workflowName",
            VersionNum = 0,
        };

        string expectedWorkflowName = "workflowName";
        long expectedVersionNum = 0;

        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
        Assert.Equal(expectedVersionNum, parameters.VersionNum);
    }

    [Fact]
    public void Url_Works()
    {
        VersionRetrieveParams parameters = new() { WorkflowName = "workflowName", VersionNum = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/workflows/workflowName/versions/0"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionRetrieveParams
        {
            WorkflowName = "workflowName",
            VersionNum = 0,
        };

        VersionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
