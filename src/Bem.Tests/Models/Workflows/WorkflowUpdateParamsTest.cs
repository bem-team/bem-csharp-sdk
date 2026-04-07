using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
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
            DisplayName = "displayName",
            Edges =
            [
                new()
                {
                    DestinationNodeName = "destinationNodeName",
                    SourceNodeName = "sourceNodeName",
                    DestinationName = "destinationName",
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
                    Name = "name",
                },
            ],
            Tags = ["string"],
        };

        string expectedWorkflowName = "workflowName";
        string expectedDisplayName = "displayName";
        List<WorkflowUpdateParamsEdge> expectedEdges =
        [
            new()
            {
                DestinationNodeName = "destinationNodeName",
                SourceNodeName = "sourceNodeName",
                DestinationName = "destinationName",
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
                Name = "name",
            },
        ];
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
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
            DisplayName = null,
            Edges = null,
            MainNodeName = null,
            Name = null,
            Nodes = null,
            Tags = null,
        };

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

        Assert.Equal(new Uri("https://api.bem.ai/v3/workflows/workflowName"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkflowUpdateParams
        {
            WorkflowName = "workflowName",
            DisplayName = "displayName",
            Edges =
            [
                new()
                {
                    DestinationNodeName = "destinationNodeName",
                    SourceNodeName = "sourceNodeName",
                    DestinationName = "destinationName",
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
                    Name = "name",
                },
            ],
            Tags = ["string"],
        };

        WorkflowUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
        };

        string expectedDestinationNodeName = "destinationNodeName";
        string expectedSourceNodeName = "sourceNodeName";
        string expectedDestinationName = "destinationName";

        Assert.Equal(expectedDestinationNodeName, model.DestinationNodeName);
        Assert.Equal(expectedSourceNodeName, model.SourceNodeName);
        Assert.Equal(expectedDestinationName, model.DestinationName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
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

        Assert.Equal(expectedDestinationNodeName, deserialized.DestinationNodeName);
        Assert.Equal(expectedSourceNodeName, deserialized.SourceNodeName);
        Assert.Equal(expectedDestinationName, deserialized.DestinationName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUpdateParamsEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
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
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
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
            Name = "name",
        };

        FunctionVersionIdentifier expectedFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedName = "name";

        Assert.Equal(expectedFunction, model.Function);
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
        string expectedName = "name";

        Assert.Equal(expectedFunction, deserialized.Function);
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
            Name = null,
        };

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
            Name = "name",
        };

        WorkflowUpdateParamsNode copied = new(model);

        Assert.Equal(model, copied);
    }
}
