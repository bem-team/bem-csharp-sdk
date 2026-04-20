using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
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
                    Type = WorkflowUpdateParamsConnectorType.Paragon,
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
        List<WorkflowUpdateParamsConnector> expectedConnectors =
        [
            new()
            {
                Name = "name",
                Type = WorkflowUpdateParamsConnectorType.Paragon,
                ConnectorID = "connectorID",
                Paragon = new()
                {
                    Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Integration = "integration",
                },
            },
        ];
        string expectedDisplayName = "displayName";
        List<WorkflowUpdateParamsEdge> expectedEdges =
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
        List<WorkflowUpdateParamsNode> expectedNodes =
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
                    Type = WorkflowUpdateParamsConnectorType.Paragon,
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

public class WorkflowUpdateParamsConnectorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        string expectedName = "name";
        ApiEnum<string, WorkflowUpdateParamsConnectorType> expectedType =
            WorkflowUpdateParamsConnectorType.Paragon;
        string expectedConnectorID = "connectorID";
        WorkflowUpdateParamsConnectorParagon expectedParagon = new()
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedConnectorID, model.ConnectorID);
        Assert.Equal(expectedParagon, model.Paragon);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateParamsConnector>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateParamsConnector>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        ApiEnum<string, WorkflowUpdateParamsConnectorType> expectedType =
            WorkflowUpdateParamsConnectorType.Paragon;
        string expectedConnectorID = "connectorID";
        WorkflowUpdateParamsConnectorParagon expectedParagon = new()
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedConnectorID, deserialized.ConnectorID);
        Assert.Equal(expectedParagon, deserialized.Paragon);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,
        };

        Assert.Null(model.ConnectorID);
        Assert.False(model.RawData.ContainsKey("connectorID"));
        Assert.Null(model.Paragon);
        Assert.False(model.RawData.ContainsKey("paragon"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,

            // Null should be interpreted as omitted for these properties
            ConnectorID = null,
            Paragon = null,
        };

        Assert.Null(model.ConnectorID);
        Assert.False(model.RawData.ContainsKey("connectorID"));
        Assert.Null(model.Paragon);
        Assert.False(model.RawData.ContainsKey("paragon"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,

            // Null should be interpreted as omitted for these properties
            ConnectorID = null,
            Paragon = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowUpdateParamsConnector
        {
            Name = "name",
            Type = WorkflowUpdateParamsConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        WorkflowUpdateParamsConnector copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowUpdateParamsConnectorTypeTest : TestBase
{
    [Theory]
    [InlineData(WorkflowUpdateParamsConnectorType.Paragon)]
    public void Validation_Works(WorkflowUpdateParamsConnectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkflowUpdateParamsConnectorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkflowUpdateParamsConnectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkflowUpdateParamsConnectorType.Paragon)]
    public void SerializationRoundtrip_Works(WorkflowUpdateParamsConnectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkflowUpdateParamsConnectorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WorkflowUpdateParamsConnectorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkflowUpdateParamsConnectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WorkflowUpdateParamsConnectorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WorkflowUpdateParamsConnectorParagonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        JsonElement expectedConfiguration = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedIntegration = "integration";

        Assert.NotNull(model.Configuration);
        Assert.True(JsonElement.DeepEquals(expectedConfiguration, model.Configuration.Value));
        Assert.Equal(expectedIntegration, model.Integration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateParamsConnectorParagon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateParamsConnectorParagon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedConfiguration = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedIntegration = "integration";

        Assert.NotNull(deserialized.Configuration);
        Assert.True(
            JsonElement.DeepEquals(expectedConfiguration, deserialized.Configuration.Value)
        );
        Assert.Equal(expectedIntegration, deserialized.Integration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon { };

        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.Integration);
        Assert.False(model.RawData.ContainsKey("integration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon
        {
            // Null should be interpreted as omitted for these properties
            Configuration = null,
            Integration = null,
        };

        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.Integration);
        Assert.False(model.RawData.ContainsKey("integration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon
        {
            // Null should be interpreted as omitted for these properties
            Configuration = null,
            Integration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowUpdateParamsConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        WorkflowUpdateParamsConnectorParagon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowUpdateParamsEdgeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedDestinationNodeName = "destinationNodeName";
        string expectedSourceNodeName = "sourceNodeName";
        string expectedDestinationName = "destinationName";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedDestinationNodeName, model.DestinationNodeName);
        Assert.Equal(expectedSourceNodeName, model.SourceNodeName);
        Assert.Equal(expectedDestinationName, model.DestinationName);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateParamsEdge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateParamsEdge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDestinationNodeName = "destinationNodeName";
        string expectedSourceNodeName = "sourceNodeName";
        string expectedDestinationName = "destinationName";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedDestinationNodeName, deserialized.DestinationNodeName);
        Assert.Equal(expectedSourceNodeName, deserialized.SourceNodeName);
        Assert.Equal(expectedDestinationName, deserialized.DestinationName);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",

            // Null should be interpreted as omitted for these properties
            DestinationName = null,
            Metadata = null,
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",

            // Null should be interpreted as omitted for these properties
            DestinationName = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        WorkflowUpdateParamsEdge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowUpdateParamsNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        FunctionVersionIdentifier expectedFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";

        Assert.Equal(expectedFunction, model.Function);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateParamsNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateParamsNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FunctionVersionIdentifier expectedFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Name = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowUpdateParamsNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        WorkflowUpdateParamsNode copied = new(model);

        Assert.Equal(model, copied);
    }
}
