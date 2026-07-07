using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityRetrieveRelationsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Inbound> expectedInbound =
        [
            new()
            {
                FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MentionCount = 0,
                RelationType = "relationType",
                SourceEntity = new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    Type = "type",
                },
            },
        ];
        List<Outbound> expectedOutbound =
        [
            new()
            {
                FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MentionCount = 0,
                RelationType = "relationType",
                TargetEntity = new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    Type = "type",
                },
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedInbound.Count, model.Inbound.Count);
        for (int i = 0; i < expectedInbound.Count; i++)
        {
            Assert.Equal(expectedInbound[i], model.Inbound[i]);
        }
        Assert.Equal(expectedOutbound.Count, model.Outbound.Count);
        for (int i = 0; i < expectedOutbound.Count; i++)
        {
            Assert.Equal(expectedOutbound[i], model.Outbound[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityRetrieveRelationsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityRetrieveRelationsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Inbound> expectedInbound =
        [
            new()
            {
                FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MentionCount = 0,
                RelationType = "relationType",
                SourceEntity = new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    Type = "type",
                },
            },
        ];
        List<Outbound> expectedOutbound =
        [
            new()
            {
                FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MentionCount = 0,
                RelationType = "relationType",
                TargetEntity = new()
                {
                    ID = "id",
                    Canonical = "canonical",
                    Depth = 0,
                    Type = "type",
                },
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedInbound.Count, deserialized.Inbound.Count);
        for (int i = 0; i < expectedInbound.Count; i++)
        {
            Assert.Equal(expectedInbound[i], deserialized.Inbound[i]);
        }
        Assert.Equal(expectedOutbound.Count, deserialized.Outbound.Count);
        for (int i = 0; i < expectedOutbound.Count; i++)
        {
            Assert.Equal(expectedOutbound[i], deserialized.Outbound[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
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
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
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
        var model = new EntityRetrieveRelationsResponse
        {
            Inbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    SourceEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            Outbound =
            [
                new()
                {
                    FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MentionCount = 0,
                    RelationType = "relationType",
                    TargetEntity = new()
                    {
                        ID = "id",
                        Canonical = "canonical",
                        Depth = 0,
                        Type = "type",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        EntityRetrieveRelationsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Inbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            SourceEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        DateTimeOffset expectedFirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedMentionCount = 0;
        string expectedRelationType = "relationType";
        SourceEntity expectedSourceEntity = new()
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        Assert.Equal(expectedFirstSeenAt, model.FirstSeenAt);
        Assert.Equal(expectedMentionCount, model.MentionCount);
        Assert.Equal(expectedRelationType, model.RelationType);
        Assert.Equal(expectedSourceEntity, model.SourceEntity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Inbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            SourceEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Inbound>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Inbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            SourceEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Inbound>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedFirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedMentionCount = 0;
        string expectedRelationType = "relationType";
        SourceEntity expectedSourceEntity = new()
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        Assert.Equal(expectedFirstSeenAt, deserialized.FirstSeenAt);
        Assert.Equal(expectedMentionCount, deserialized.MentionCount);
        Assert.Equal(expectedRelationType, deserialized.RelationType);
        Assert.Equal(expectedSourceEntity, deserialized.SourceEntity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Inbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            SourceEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Inbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            SourceEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        Inbound copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceEntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SourceEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string expectedID = "id";
        string expectedCanonical = "canonical";
        int expectedDepth = 0;
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCanonical, model.Canonical);
        Assert.Equal(expectedDepth, model.Depth);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SourceEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SourceEntity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SourceEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SourceEntity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCanonical = "canonical";
        int expectedDepth = 0;
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCanonical, deserialized.Canonical);
        Assert.Equal(expectedDepth, deserialized.Depth);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SourceEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SourceEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        SourceEntity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutboundTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Outbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            TargetEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        DateTimeOffset expectedFirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedMentionCount = 0;
        string expectedRelationType = "relationType";
        TargetEntity expectedTargetEntity = new()
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        Assert.Equal(expectedFirstSeenAt, model.FirstSeenAt);
        Assert.Equal(expectedMentionCount, model.MentionCount);
        Assert.Equal(expectedRelationType, model.RelationType);
        Assert.Equal(expectedTargetEntity, model.TargetEntity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Outbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            TargetEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Outbound>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Outbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            TargetEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Outbound>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedFirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedMentionCount = 0;
        string expectedRelationType = "relationType";
        TargetEntity expectedTargetEntity = new()
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        Assert.Equal(expectedFirstSeenAt, deserialized.FirstSeenAt);
        Assert.Equal(expectedMentionCount, deserialized.MentionCount);
        Assert.Equal(expectedRelationType, deserialized.RelationType);
        Assert.Equal(expectedTargetEntity, deserialized.TargetEntity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Outbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            TargetEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Outbound
        {
            FirstSeenAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MentionCount = 0,
            RelationType = "relationType",
            TargetEntity = new()
            {
                ID = "id",
                Canonical = "canonical",
                Depth = 0,
                Type = "type",
            },
        };

        Outbound copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetEntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TargetEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string expectedID = "id";
        string expectedCanonical = "canonical";
        int expectedDepth = 0;
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCanonical, model.Canonical);
        Assert.Equal(expectedDepth, model.Depth);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TargetEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TargetEntity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TargetEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TargetEntity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCanonical = "canonical";
        int expectedDepth = 0;
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCanonical, deserialized.Canonical);
        Assert.Equal(expectedDepth, deserialized.Depth);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TargetEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TargetEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        TargetEntity copied = new(model);

        Assert.Equal(model, copied);
    }
}
