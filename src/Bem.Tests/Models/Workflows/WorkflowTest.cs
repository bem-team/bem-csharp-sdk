using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,
            Audit = new()
            {
                VersionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Relationships =
            [
                new()
                {
                    DestinationFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    SourceFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    DestinationName = "destinationName",
                },
            ],
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        FunctionVersionIdentifier expectedMainFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedName = "name";
        long expectedVersionNum = 0;
        Audit expectedAudit = new()
        {
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "displayName";
        string expectedEmailAddress = "emailAddress";
        List<Relationship> expectedRelationships =
        [
            new()
            {
                DestinationFunction = new()
                {
                    ID = "id",
                    Name = "name",
                    VersionNum = 0,
                },
                SourceFunction = new()
                {
                    ID = "id",
                    Name = "name",
                    VersionNum = 0,
                },
                DestinationName = "destinationName",
            },
        ];
        List<string> expectedTags = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMainFunction, model.MainFunction);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.NotNull(model.Relationships);
        Assert.Equal(expectedRelationships.Count, model.Relationships.Count);
        for (int i = 0; i < expectedRelationships.Count; i++)
        {
            Assert.Equal(expectedRelationships[i], model.Relationships[i]);
        }
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,
            Audit = new()
            {
                VersionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Relationships =
            [
                new()
                {
                    DestinationFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    SourceFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    DestinationName = "destinationName",
                },
            ],
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Workflow>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,
            Audit = new()
            {
                VersionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Relationships =
            [
                new()
                {
                    DestinationFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    SourceFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    DestinationName = "destinationName",
                },
            ],
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Workflow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        FunctionVersionIdentifier expectedMainFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedName = "name";
        long expectedVersionNum = 0;
        Audit expectedAudit = new()
        {
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "displayName";
        string expectedEmailAddress = "emailAddress";
        List<Relationship> expectedRelationships =
        [
            new()
            {
                DestinationFunction = new()
                {
                    ID = "id",
                    Name = "name",
                    VersionNum = 0,
                },
                SourceFunction = new()
                {
                    ID = "id",
                    Name = "name",
                    VersionNum = 0,
                },
                DestinationName = "destinationName",
            },
        ];
        List<string> expectedTags = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMainFunction, deserialized.MainFunction);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.NotNull(deserialized.Relationships);
        Assert.Equal(expectedRelationships.Count, deserialized.Relationships.Count);
        for (int i = 0; i < expectedRelationships.Count; i++)
        {
            Assert.Equal(expectedRelationships[i], deserialized.Relationships[i]);
        }
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,
            Audit = new()
            {
                VersionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Relationships =
            [
                new()
                {
                    DestinationFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    SourceFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    DestinationName = "destinationName",
                },
            ],
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("emailAddress"));
        Assert.Null(model.Relationships);
        Assert.False(model.RawData.ContainsKey("relationships"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            EmailAddress = null,
            Relationships = null,
            Tags = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("emailAddress"));
        Assert.Null(model.Relationships);
        Assert.False(model.RawData.ContainsKey("relationships"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            EmailAddress = null,
            Relationships = null,
            Tags = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            VersionNum = 0,
            Audit = new()
            {
                VersionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                WorkflowLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Relationships =
            [
                new()
                {
                    DestinationFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    SourceFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    DestinationName = "destinationName",
                },
            ],
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Workflow copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AuditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Audit
        {
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        UserActionSummary expectedVersionCreatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };
        UserActionSummary expectedWorkflowCreatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };
        UserActionSummary expectedWorkflowLastUpdatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        Assert.Equal(expectedVersionCreatedBy, model.VersionCreatedBy);
        Assert.Equal(expectedWorkflowCreatedBy, model.WorkflowCreatedBy);
        Assert.Equal(expectedWorkflowLastUpdatedBy, model.WorkflowLastUpdatedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Audit
        {
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Audit>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Audit
        {
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Audit>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        UserActionSummary expectedVersionCreatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };
        UserActionSummary expectedWorkflowCreatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };
        UserActionSummary expectedWorkflowLastUpdatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        Assert.Equal(expectedVersionCreatedBy, deserialized.VersionCreatedBy);
        Assert.Equal(expectedWorkflowCreatedBy, deserialized.WorkflowCreatedBy);
        Assert.Equal(expectedWorkflowLastUpdatedBy, deserialized.WorkflowLastUpdatedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Audit
        {
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Audit { };

        Assert.Null(model.VersionCreatedBy);
        Assert.False(model.RawData.ContainsKey("versionCreatedBy"));
        Assert.Null(model.WorkflowCreatedBy);
        Assert.False(model.RawData.ContainsKey("workflowCreatedBy"));
        Assert.Null(model.WorkflowLastUpdatedBy);
        Assert.False(model.RawData.ContainsKey("workflowLastUpdatedBy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Audit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Audit
        {
            // Null should be interpreted as omitted for these properties
            VersionCreatedBy = null,
            WorkflowCreatedBy = null,
            WorkflowLastUpdatedBy = null,
        };

        Assert.Null(model.VersionCreatedBy);
        Assert.False(model.RawData.ContainsKey("versionCreatedBy"));
        Assert.Null(model.WorkflowCreatedBy);
        Assert.False(model.RawData.ContainsKey("workflowCreatedBy"));
        Assert.Null(model.WorkflowLastUpdatedBy);
        Assert.False(model.RawData.ContainsKey("workflowLastUpdatedBy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Audit
        {
            // Null should be interpreted as omitted for these properties
            VersionCreatedBy = null,
            WorkflowCreatedBy = null,
            WorkflowLastUpdatedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Audit
        {
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            WorkflowLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        Audit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RelationshipTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            DestinationName = "destinationName",
        };

        FunctionVersionIdentifier expectedDestinationFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        FunctionVersionIdentifier expectedSourceFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedDestinationName = "destinationName";

        Assert.Equal(expectedDestinationFunction, model.DestinationFunction);
        Assert.Equal(expectedSourceFunction, model.SourceFunction);
        Assert.Equal(expectedDestinationName, model.DestinationName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            DestinationName = "destinationName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Relationship>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            DestinationName = "destinationName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Relationship>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FunctionVersionIdentifier expectedDestinationFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        FunctionVersionIdentifier expectedSourceFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedDestinationName = "destinationName";

        Assert.Equal(expectedDestinationFunction, deserialized.DestinationFunction);
        Assert.Equal(expectedSourceFunction, deserialized.SourceFunction);
        Assert.Equal(expectedDestinationName, deserialized.DestinationName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            DestinationName = "destinationName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
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
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },

            // Null should be interpreted as omitted for these properties
            DestinationName = null,
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },

            // Null should be interpreted as omitted for these properties
            DestinationName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Relationship
        {
            DestinationFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            SourceFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            DestinationName = "destinationName",
        };

        Relationship copied = new(model);

        Assert.Equal(model, copied);
    }
}
