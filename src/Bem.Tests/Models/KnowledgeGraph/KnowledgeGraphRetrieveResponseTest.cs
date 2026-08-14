using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.KnowledgeGraph;

namespace Bem.Tests.Models.KnowledgeGraph;

public class KnowledgeGraphRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Edge> expectedEdges =
        [
            new()
            {
                MentionCount = 0,
                RelationType = "relationType",
                SourceID = "sourceId",
                TargetID = "targetId",
            },
        ];
        List<Node> expectedNodes =
        [
            new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                MentionCount = 0,
                Type = "type",
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedEdges.Count, model.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.Equal(expectedEdges[i], model.Edges[i]);
        }
        Assert.Equal(expectedNodes.Count, model.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], model.Nodes[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KnowledgeGraphRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KnowledgeGraphRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Edge> expectedEdges =
        [
            new()
            {
                MentionCount = 0,
                RelationType = "relationType",
                SourceID = "sourceId",
                TargetID = "targetId",
            },
        ];
        List<Node> expectedNodes =
        [
            new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                MentionCount = 0,
                Type = "type",
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedEdges.Count, deserialized.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.Equal(expectedEdges[i], deserialized.Edges[i]);
        }
        Assert.Equal(expectedNodes.Count, deserialized.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], deserialized.Nodes[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new KnowledgeGraphRetrieveResponse
        {
            Edges =
            [
                new()
                {
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceID = "sourceId",
                    TargetID = "targetId",
                },
            ],
            Nodes =
            [
                new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    MentionCount = 0,
                    Type = "type",
                },
            ],
            NextCursor = "nextCursor",
        };

        KnowledgeGraphRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EdgeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Edge
        {
            MentionCount = 0,
            RelationType = "relationType",
            SourceID = "sourceId",
            TargetID = "targetId",
        };

        int expectedMentionCount = 0;
        string expectedRelationType = "relationType";
        string expectedSourceID = "sourceId";
        string expectedTargetID = "targetId";

        Assert.Equal(expectedMentionCount, model.MentionCount);
        Assert.Equal(expectedRelationType, model.RelationType);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedTargetID, model.TargetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Edge
        {
            MentionCount = 0,
            RelationType = "relationType",
            SourceID = "sourceId",
            TargetID = "targetId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Edge>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Edge
        {
            MentionCount = 0,
            RelationType = "relationType",
            SourceID = "sourceId",
            TargetID = "targetId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Edge>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        int expectedMentionCount = 0;
        string expectedRelationType = "relationType";
        string expectedSourceID = "sourceId";
        string expectedTargetID = "targetId";

        Assert.Equal(expectedMentionCount, deserialized.MentionCount);
        Assert.Equal(expectedRelationType, deserialized.RelationType);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedTargetID, deserialized.TargetID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Edge
        {
            MentionCount = 0,
            RelationType = "relationType",
            SourceID = "sourceId",
            TargetID = "targetId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Edge
        {
            MentionCount = 0,
            RelationType = "relationType",
            SourceID = "sourceId",
            TargetID = "targetId",
        };

        Edge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Node
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            MentionCount = 0,
            Type = "type",
        };

        string expectedID = "id";
        string expectedCanonical = "canonical";
        int expectedDepth = 0;
        int expectedMentionCount = 0;
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCanonical, model.Canonical);
        Assert.Equal(expectedDepth, model.Depth);
        Assert.Equal(expectedMentionCount, model.MentionCount);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Node
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            MentionCount = 0,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Node>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Node
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            MentionCount = 0,
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Node>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCanonical = "canonical";
        int expectedDepth = 0;
        int expectedMentionCount = 0;
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCanonical, deserialized.Canonical);
        Assert.Equal(expectedDepth, deserialized.Depth);
        Assert.Equal(expectedMentionCount, deserialized.MentionCount);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Node
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            MentionCount = 0,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Node
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            MentionCount = 0,
            Type = "type",
        };

        Node copied = new(model);

        Assert.Equal(model, copied);
    }
}
