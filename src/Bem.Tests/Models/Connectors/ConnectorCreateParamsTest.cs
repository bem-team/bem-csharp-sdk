using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Connectors;

namespace Bem.Tests.Models.Connectors;

public class ConnectorCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConnectorCreateParams
        {
            Name = "Box → Invoice workflow",
            Type = ConnectorType.Paragon,
            BoxClientID = "boxClientID",
            BoxClientSecret = "boxClientSecret",
            BoxEnterpriseID = "boxEnterpriseID",
            BoxFolderID = "boxFolderID",
            ParagonConfiguration = JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "folderId": "YOUR_GOOGLE_DRIVE_FOLDER_ID"
                }
                """
            ),
            ParagonIntegration = "googledrive",
            WorkflowID = "wf_2N6gH8ZKCmvb6BnFcGqhKJ98VzP",
            WorkflowName = "workflowName",
        };

        string expectedName = "Box → Invoice workflow";
        ApiEnum<string, ConnectorType> expectedType = ConnectorType.Paragon;
        string expectedBoxClientID = "boxClientID";
        string expectedBoxClientSecret = "boxClientSecret";
        string expectedBoxEnterpriseID = "boxEnterpriseID";
        string expectedBoxFolderID = "boxFolderID";
        JsonElement expectedParagonConfiguration = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "folderId": "YOUR_GOOGLE_DRIVE_FOLDER_ID"
            }
            """
        );
        string expectedParagonIntegration = "googledrive";
        string expectedWorkflowID = "wf_2N6gH8ZKCmvb6BnFcGqhKJ98VzP";
        string expectedWorkflowName = "workflowName";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedBoxClientID, parameters.BoxClientID);
        Assert.Equal(expectedBoxClientSecret, parameters.BoxClientSecret);
        Assert.Equal(expectedBoxEnterpriseID, parameters.BoxEnterpriseID);
        Assert.Equal(expectedBoxFolderID, parameters.BoxFolderID);
        Assert.NotNull(parameters.ParagonConfiguration);
        Assert.True(
            JsonElement.DeepEquals(
                expectedParagonConfiguration,
                parameters.ParagonConfiguration.Value
            )
        );
        Assert.Equal(expectedParagonIntegration, parameters.ParagonIntegration);
        Assert.Equal(expectedWorkflowID, parameters.WorkflowID);
        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConnectorCreateParams
        {
            Name = "Box → Invoice workflow",
            Type = ConnectorType.Paragon,
        };

        Assert.Null(parameters.BoxClientID);
        Assert.False(parameters.RawBodyData.ContainsKey("boxClientID"));
        Assert.Null(parameters.BoxClientSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("boxClientSecret"));
        Assert.Null(parameters.BoxEnterpriseID);
        Assert.False(parameters.RawBodyData.ContainsKey("boxEnterpriseID"));
        Assert.Null(parameters.BoxFolderID);
        Assert.False(parameters.RawBodyData.ContainsKey("boxFolderID"));
        Assert.Null(parameters.ParagonConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("paragonConfiguration"));
        Assert.Null(parameters.ParagonIntegration);
        Assert.False(parameters.RawBodyData.ContainsKey("paragonIntegration"));
        Assert.Null(parameters.WorkflowID);
        Assert.False(parameters.RawBodyData.ContainsKey("workflowID"));
        Assert.Null(parameters.WorkflowName);
        Assert.False(parameters.RawBodyData.ContainsKey("workflowName"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConnectorCreateParams
        {
            Name = "Box → Invoice workflow",
            Type = ConnectorType.Paragon,

            // Null should be interpreted as omitted for these properties
            BoxClientID = null,
            BoxClientSecret = null,
            BoxEnterpriseID = null,
            BoxFolderID = null,
            ParagonConfiguration = null,
            ParagonIntegration = null,
            WorkflowID = null,
            WorkflowName = null,
        };

        Assert.Null(parameters.BoxClientID);
        Assert.False(parameters.RawBodyData.ContainsKey("boxClientID"));
        Assert.Null(parameters.BoxClientSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("boxClientSecret"));
        Assert.Null(parameters.BoxEnterpriseID);
        Assert.False(parameters.RawBodyData.ContainsKey("boxEnterpriseID"));
        Assert.Null(parameters.BoxFolderID);
        Assert.False(parameters.RawBodyData.ContainsKey("boxFolderID"));
        Assert.Null(parameters.ParagonConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("paragonConfiguration"));
        Assert.Null(parameters.ParagonIntegration);
        Assert.False(parameters.RawBodyData.ContainsKey("paragonIntegration"));
        Assert.Null(parameters.WorkflowID);
        Assert.False(parameters.RawBodyData.ContainsKey("workflowID"));
        Assert.Null(parameters.WorkflowName);
        Assert.False(parameters.RawBodyData.ContainsKey("workflowName"));
    }

    [Fact]
    public void Url_Works()
    {
        ConnectorCreateParams parameters = new()
        {
            Name = "Box → Invoice workflow",
            Type = ConnectorType.Paragon,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/connectors"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConnectorCreateParams
        {
            Name = "Box → Invoice workflow",
            Type = ConnectorType.Paragon,
            BoxClientID = "boxClientID",
            BoxClientSecret = "boxClientSecret",
            BoxEnterpriseID = "boxEnterpriseID",
            BoxFolderID = "boxFolderID",
            ParagonConfiguration = JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "folderId": "YOUR_GOOGLE_DRIVE_FOLDER_ID"
                }
                """
            ),
            ParagonIntegration = "googledrive",
            WorkflowID = "wf_2N6gH8ZKCmvb6BnFcGqhKJ98VzP",
            WorkflowName = "workflowName",
        };

        ConnectorCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
