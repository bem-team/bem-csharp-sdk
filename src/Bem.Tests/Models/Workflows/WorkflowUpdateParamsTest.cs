using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkflowUpdateParams
        {
            WorkflowName = "workflowName",
            Connectors =
            [
                new()
                {
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    ConnectorID = "connectorID",
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                    },
                },
            ],
            DisplayName = "displayName",
            Edges =
            [
                new()
                {
                    DestinationNodeName = "destinationNodeName",
                    SourceNodeName = "sourceNodeName",
                    DestinationName = "destinationName",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            MainNodeName = "mainNodeName",
            Name = "name",
            Nodes =
            [
                new()
                {
                    Function = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                },
            ],
            Tags = ["string"],
        };

        string expectedWorkflowName = "workflowName";
        List<WorkflowConnector> expectedConnectors =
        [
            new()
            {
                Name = "name",
                Type = WorkflowConnectorType.Paragon,
                ConnectorID = "connectorID",
                Paragon = new()
                {
                    Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Integration = "integration",
                },
            },
        ];
        string expectedDisplayName = "displayName";
        List<WorkflowEdge> expectedEdges =
        [
            new()
            {
                DestinationNodeName = "destinationNodeName",
                SourceNodeName = "sourceNodeName",
                DestinationName = "destinationName",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];
        string expectedMainNodeName = "mainNodeName";
        string expectedName = "name";
        List<WorkflowNode> expectedNodes =
        [
            new()
            {
                Function = new()
                {
                    ID = "id",
                    Name = "name",
                    VersionNum = 0,
                },
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "name",
            },
        ];
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
        Assert.NotNull(parameters.Connectors);
        Assert.Equal(expectedConnectors.Count, parameters.Connectors.Count);
        for (int i = 0; i < expectedConnectors.Count; i++)
        {
            Assert.Equal(expectedConnectors[i], parameters.Connectors[i]);
        }
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Edges);
        Assert.Equal(expectedEdges.Count, parameters.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.Equal(expectedEdges[i], parameters.Edges[i]);
        }
        Assert.Equal(expectedMainNodeName, parameters.MainNodeName);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Nodes);
        Assert.Equal(expectedNodes.Count, parameters.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], parameters.Nodes[i]);
        }
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkflowUpdateParams { WorkflowName = "workflowName" };

        Assert.Null(parameters.Connectors);
        Assert.False(parameters.RawBodyData.ContainsKey("connectors"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Edges);
        Assert.False(parameters.RawBodyData.ContainsKey("edges"));
        Assert.Null(parameters.MainNodeName);
        Assert.False(parameters.RawBodyData.ContainsKey("mainNodeName"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Nodes);
        Assert.False(parameters.RawBodyData.ContainsKey("nodes"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkflowUpdateParams
        {
            WorkflowName = "workflowName",

            // Null should be interpreted as omitted for these properties
            Connectors = null,
            DisplayName = null,
            Edges = null,
            MainNodeName = null,
            Name = null,
            Nodes = null,
            Tags = null,
        };

        Assert.Null(parameters.Connectors);
        Assert.False(parameters.RawBodyData.ContainsKey("connectors"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Edges);
        Assert.False(parameters.RawBodyData.ContainsKey("edges"));
        Assert.Null(parameters.MainNodeName);
        Assert.False(parameters.RawBodyData.ContainsKey("mainNodeName"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Nodes);
        Assert.False(parameters.RawBodyData.ContainsKey("nodes"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkflowUpdateParams parameters = new() { WorkflowName = "workflowName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/workflows/workflowName"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkflowUpdateParams
        {
            WorkflowName = "workflowName",
            Connectors =
            [
                new()
                {
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    ConnectorID = "connectorID",
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                    },
                },
            ],
            DisplayName = "displayName",
            Edges =
            [
                new()
                {
                    DestinationNodeName = "destinationNodeName",
                    SourceNodeName = "sourceNodeName",
                    DestinationName = "destinationName",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            MainNodeName = "mainNodeName",
            Name = "name",
            Nodes =
            [
                new()
                {
                    Function = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "name",
                },
            ],
            Tags = ["string"],
        };

        WorkflowUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
