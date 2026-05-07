using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Connectors;

namespace Bem.Tests.Models.Connectors;

public class ConnectorListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConnectorListResponse
        {
            Connectors =
            [
                new()
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
                },
            ],
        };

        List<Connector> expectedConnectors =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedConnectors.Count, model.Connectors.Count);
        for (int i = 0; i < expectedConnectors.Count; i++)
        {
            Assert.Equal(expectedConnectors[i], model.Connectors[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConnectorListResponse
        {
            Connectors =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConnectorListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConnectorListResponse
        {
            Connectors =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConnectorListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Connector> expectedConnectors =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedConnectors.Count, deserialized.Connectors.Count);
        for (int i = 0; i < expectedConnectors.Count; i++)
        {
            Assert.Equal(expectedConnectors[i], deserialized.Connectors[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConnectorListResponse
        {
            Connectors =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConnectorListResponse
        {
            Connectors =
            [
                new()
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
                },
            ],
        };

        ConnectorListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
