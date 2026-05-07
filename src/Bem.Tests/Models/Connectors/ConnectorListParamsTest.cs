using System;
using Bem.Models.Connectors;

namespace Bem.Tests.Models.Connectors;

public class ConnectorListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConnectorListParams
        {
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";

        Assert.Equal(expectedWorkflowID, parameters.WorkflowID);
        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConnectorListParams { };

        Assert.Null(parameters.WorkflowID);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowID"));
        Assert.Null(parameters.WorkflowName);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowName"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConnectorListParams
        {
            // Null should be interpreted as omitted for these properties
            WorkflowID = null,
            WorkflowName = null,
        };

        Assert.Null(parameters.WorkflowID);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowID"));
        Assert.Null(parameters.WorkflowName);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowName"));
    }

    [Fact]
    public void Url_Works()
    {
        ConnectorListParams parameters = new()
        {
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/connectors?workflowID=workflowID&workflowName=workflowName"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConnectorListParams
        {
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        ConnectorListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
