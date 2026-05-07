using System.Text.Json;
using Bem.Core;
using Bem.Models.Connectors;

namespace Bem.Tests.Models.Connectors;

public class ConnectorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Connector
        {
            BoxClientID = "boxClientID",
            BoxClientSecret = "boxClientSecret",
            BoxEnterpriseID = "boxEnterpriseID",
            BoxFolderID = "boxFolderID",
            ConnectorID = "connectorID",
            Name = "name",
            ParagonConfiguration = JsonSerializer.Deserialize<JsonElement>("{}"),
            ParagonIntegration = "paragonIntegration",
            ParagonSyncID = "paragonSyncID",
            Type = ConnectorType.Box,
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        string expectedBoxClientID = "boxClientID";
        string expectedBoxClientSecret = "boxClientSecret";
        string expectedBoxEnterpriseID = "boxEnterpriseID";
        string expectedBoxFolderID = "boxFolderID";
        string expectedConnectorID = "connectorID";
        string expectedName = "name";
        JsonElement expectedParagonConfiguration = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedParagonIntegration = "paragonIntegration";
        string expectedParagonSyncID = "paragonSyncID";
        ApiEnum<string, ConnectorType> expectedType = ConnectorType.Box;
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";

        Assert.Equal(expectedBoxClientID, model.BoxClientID);
        Assert.Equal(expectedBoxClientSecret, model.BoxClientSecret);
        Assert.Equal(expectedBoxEnterpriseID, model.BoxEnterpriseID);
        Assert.Equal(expectedBoxFolderID, model.BoxFolderID);
        Assert.Equal(expectedConnectorID, model.ConnectorID);
        Assert.Equal(expectedName, model.Name);
        Assert.True(
            JsonElement.DeepEquals(expectedParagonConfiguration, model.ParagonConfiguration)
        );
        Assert.Equal(expectedParagonIntegration, model.ParagonIntegration);
        Assert.Equal(expectedParagonSyncID, model.ParagonSyncID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Connector
        {
            BoxClientID = "boxClientID",
            BoxClientSecret = "boxClientSecret",
            BoxEnterpriseID = "boxEnterpriseID",
            BoxFolderID = "boxFolderID",
            ConnectorID = "connectorID",
            Name = "name",
            ParagonConfiguration = JsonSerializer.Deserialize<JsonElement>("{}"),
            ParagonIntegration = "paragonIntegration",
            ParagonSyncID = "paragonSyncID",
            Type = ConnectorType.Box,
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Connector>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Connector
        {
            BoxClientID = "boxClientID",
            BoxClientSecret = "boxClientSecret",
            BoxEnterpriseID = "boxEnterpriseID",
            BoxFolderID = "boxFolderID",
            ConnectorID = "connectorID",
            Name = "name",
            ParagonConfiguration = JsonSerializer.Deserialize<JsonElement>("{}"),
            ParagonIntegration = "paragonIntegration",
            ParagonSyncID = "paragonSyncID",
            Type = ConnectorType.Box,
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Connector>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBoxClientID = "boxClientID";
        string expectedBoxClientSecret = "boxClientSecret";
        string expectedBoxEnterpriseID = "boxEnterpriseID";
        string expectedBoxFolderID = "boxFolderID";
        string expectedConnectorID = "connectorID";
        string expectedName = "name";
        JsonElement expectedParagonConfiguration = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedParagonIntegration = "paragonIntegration";
        string expectedParagonSyncID = "paragonSyncID";
        ApiEnum<string, ConnectorType> expectedType = ConnectorType.Box;
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";

        Assert.Equal(expectedBoxClientID, deserialized.BoxClientID);
        Assert.Equal(expectedBoxClientSecret, deserialized.BoxClientSecret);
        Assert.Equal(expectedBoxEnterpriseID, deserialized.BoxEnterpriseID);
        Assert.Equal(expectedBoxFolderID, deserialized.BoxFolderID);
        Assert.Equal(expectedConnectorID, deserialized.ConnectorID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(
            JsonElement.DeepEquals(expectedParagonConfiguration, deserialized.ParagonConfiguration)
        );
        Assert.Equal(expectedParagonIntegration, deserialized.ParagonIntegration);
        Assert.Equal(expectedParagonSyncID, deserialized.ParagonSyncID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Connector
        {
            BoxClientID = "boxClientID",
            BoxClientSecret = "boxClientSecret",
            BoxEnterpriseID = "boxEnterpriseID",
            BoxFolderID = "boxFolderID",
            ConnectorID = "connectorID",
            Name = "name",
            ParagonConfiguration = JsonSerializer.Deserialize<JsonElement>("{}"),
            ParagonIntegration = "paragonIntegration",
            ParagonSyncID = "paragonSyncID",
            Type = ConnectorType.Box,
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Connector
        {
            BoxClientID = "boxClientID",
            BoxClientSecret = "boxClientSecret",
            BoxEnterpriseID = "boxEnterpriseID",
            BoxFolderID = "boxFolderID",
            ConnectorID = "connectorID",
            Name = "name",
            ParagonConfiguration = JsonSerializer.Deserialize<JsonElement>("{}"),
            ParagonIntegration = "paragonIntegration",
            ParagonSyncID = "paragonSyncID",
            Type = ConnectorType.Box,
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        Connector copied = new(model);

        Assert.Equal(model, copied);
    }
}
