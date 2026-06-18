using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.ReviewQueue;

namespace Bem.Tests.Models.ReviewQueue;

public class ReviewQueueListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        List<Entity> expectedEntities =
        [
            new()
            {
                Canonical = "canonical",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntityID = "entityID",
                MentionCount = 0,
                PreviewMentions =
                [
                    new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        EntityID = "entityID",
                        MentionID = "mentionID",
                        Page = 0,
                        ReferenceID = "referenceID",
                        Surface = "surface",
                        SectionLabel = "sectionLabel",
                        TransformationID = "transformationID",
                    },
                ],
                Status = "status",
                SurfaceForms = ["string"],
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                TypeID = "typeID",
                ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidatedByUserID = "validatedByUserID",
            },
        ];
        bool expectedHasMore = true;
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedEntities.Count, model.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], model.Entities[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewQueueListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewQueueListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Entity> expectedEntities =
        [
            new()
            {
                Canonical = "canonical",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntityID = "entityID",
                MentionCount = 0,
                PreviewMentions =
                [
                    new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        EntityID = "entityID",
                        MentionID = "mentionID",
                        Page = 0,
                        ReferenceID = "referenceID",
                        Surface = "surface",
                        SectionLabel = "sectionLabel",
                        TransformationID = "transformationID",
                    },
                ],
                Status = "status",
                SurfaceForms = ["string"],
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                TypeID = "typeID",
                ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidatedByUserID = "validatedByUserID",
            },
        ];
        bool expectedHasMore = true;
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedEntities.Count, deserialized.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], deserialized.Entities[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReviewQueueListResponse
        {
            Entities =
            [
                new()
                {
                    Canonical = "canonical",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionCount = 0,
                    PreviewMentions =
                    [
                        new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EntityID = "entityID",
                            MentionID = "mentionID",
                            Page = 0,
                            ReferenceID = "referenceID",
                            Surface = "surface",
                            SectionLabel = "sectionLabel",
                            TransformationID = "transformationID",
                        },
                    ],
                    Status = "status",
                    SurfaceForms = ["string"],
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    TypeID = "typeID",
                    ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidatedByUserID = "validatedByUserID",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        ReviewQueueListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        string expectedCanonical = "canonical";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityID";
        int expectedMentionCount = 0;
        List<PreviewMention> expectedPreviewMentions =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntityID = "entityID",
                MentionID = "mentionID",
                Page = 0,
                ReferenceID = "referenceID",
                Surface = "surface",
                SectionLabel = "sectionLabel",
                TransformationID = "transformationID",
            },
        ];
        string expectedStatus = "status";
        List<string> expectedSurfaceForms = ["string"];
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedTypeID = "typeID";
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedValidatedByUserID = "validatedByUserID";

        Assert.Equal(expectedCanonical, model.Canonical);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedMentionCount, model.MentionCount);
        Assert.Equal(expectedPreviewMentions.Count, model.PreviewMentions.Count);
        for (int i = 0; i < expectedPreviewMentions.Count; i++)
        {
            Assert.Equal(expectedPreviewMentions[i], model.PreviewMentions[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSurfaceForms.Count, model.SurfaceForms.Count);
        for (int i = 0; i < expectedSurfaceForms.Count; i++)
        {
            Assert.Equal(expectedSurfaceForms[i], model.SurfaceForms[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedTypeID, model.TypeID);
        Assert.Equal(expectedValidatedAt, model.ValidatedAt);
        Assert.Equal(expectedValidatedByUserID, model.ValidatedByUserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCanonical = "canonical";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityID";
        int expectedMentionCount = 0;
        List<PreviewMention> expectedPreviewMentions =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntityID = "entityID",
                MentionID = "mentionID",
                Page = 0,
                ReferenceID = "referenceID",
                Surface = "surface",
                SectionLabel = "sectionLabel",
                TransformationID = "transformationID",
            },
        ];
        string expectedStatus = "status";
        List<string> expectedSurfaceForms = ["string"];
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedTypeID = "typeID";
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedValidatedByUserID = "validatedByUserID";

        Assert.Equal(expectedCanonical, deserialized.Canonical);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedMentionCount, deserialized.MentionCount);
        Assert.Equal(expectedPreviewMentions.Count, deserialized.PreviewMentions.Count);
        for (int i = 0; i < expectedPreviewMentions.Count; i++)
        {
            Assert.Equal(expectedPreviewMentions[i], deserialized.PreviewMentions[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSurfaceForms.Count, deserialized.SurfaceForms.Count);
        for (int i = 0; i < expectedSurfaceForms.Count; i++)
        {
            Assert.Equal(expectedSurfaceForms[i], deserialized.SurfaceForms[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedTypeID, deserialized.TypeID);
        Assert.Equal(expectedValidatedAt, deserialized.ValidatedAt);
        Assert.Equal(expectedValidatedByUserID, deserialized.ValidatedByUserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.TypeID);
        Assert.False(model.RawData.ContainsKey("typeID"));
        Assert.Null(model.ValidatedAt);
        Assert.False(model.RawData.ContainsKey("validatedAt"));
        Assert.Null(model.ValidatedByUserID);
        Assert.False(model.RawData.ContainsKey("validatedByUserID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Description = null,
            TypeID = null,
            ValidatedAt = null,
            ValidatedByUserID = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.TypeID);
        Assert.False(model.RawData.ContainsKey("typeID"));
        Assert.Null(model.ValidatedAt);
        Assert.False(model.RawData.ContainsKey("validatedAt"));
        Assert.Null(model.ValidatedByUserID);
        Assert.False(model.RawData.ContainsKey("validatedByUserID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Description = null,
            TypeID = null,
            ValidatedAt = null,
            ValidatedByUserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            PreviewMentions =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityID",
                    MentionID = "mentionID",
                    Page = 0,
                    ReferenceID = "referenceID",
                    Surface = "surface",
                    SectionLabel = "sectionLabel",
                    TransformationID = "transformationID",
                },
            ],
            Status = "status",
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        Entity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PreviewMentionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",
            SectionLabel = "sectionLabel",
            TransformationID = "transformationID",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityID";
        string expectedMentionID = "mentionID";
        int expectedPage = 0;
        string expectedReferenceID = "referenceID";
        string expectedSurface = "surface";
        string expectedSectionLabel = "sectionLabel";
        string expectedTransformationID = "transformationID";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedMentionID, model.MentionID);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedSurface, model.Surface);
        Assert.Equal(expectedSectionLabel, model.SectionLabel);
        Assert.Equal(expectedTransformationID, model.TransformationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",
            SectionLabel = "sectionLabel",
            TransformationID = "transformationID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewMention>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",
            SectionLabel = "sectionLabel",
            TransformationID = "transformationID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewMention>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityID";
        string expectedMentionID = "mentionID";
        int expectedPage = 0;
        string expectedReferenceID = "referenceID";
        string expectedSurface = "surface";
        string expectedSectionLabel = "sectionLabel";
        string expectedTransformationID = "transformationID";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedMentionID, deserialized.MentionID);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedSurface, deserialized.Surface);
        Assert.Equal(expectedSectionLabel, deserialized.SectionLabel);
        Assert.Equal(expectedTransformationID, deserialized.TransformationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",
            SectionLabel = "sectionLabel",
            TransformationID = "transformationID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",
        };

        Assert.Null(model.SectionLabel);
        Assert.False(model.RawData.ContainsKey("sectionLabel"));
        Assert.Null(model.TransformationID);
        Assert.False(model.RawData.ContainsKey("transformationID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",

            // Null should be interpreted as omitted for these properties
            SectionLabel = null,
            TransformationID = null,
        };

        Assert.Null(model.SectionLabel);
        Assert.False(model.RawData.ContainsKey("sectionLabel"));
        Assert.Null(model.TransformationID);
        Assert.False(model.RawData.ContainsKey("transformationID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",

            // Null should be interpreted as omitted for these properties
            SectionLabel = null,
            TransformationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreviewMention
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionID = "mentionID",
            Page = 0,
            ReferenceID = "referenceID",
            Surface = "surface",
            SectionLabel = "sectionLabel",
            TransformationID = "transformationID",
        };

        PreviewMention copied = new(model);

        Assert.Equal(model, copied);
    }
}
