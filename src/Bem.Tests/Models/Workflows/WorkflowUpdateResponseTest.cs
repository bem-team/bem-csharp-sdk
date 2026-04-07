using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                DisplayName = "displayName",
                EmailAddress = "emailAddress",
                Tags = ["string"],
            },
        };

        string expectedError = "error";
        WorkflowUpdateResponseWorkflow expectedWorkflow = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Tags = ["string"],
        };

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedWorkflow, model.Workflow);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                DisplayName = "displayName",
                EmailAddress = "emailAddress",
                Tags = ["string"],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                DisplayName = "displayName",
                EmailAddress = "emailAddress",
                Tags = ["string"],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        WorkflowUpdateResponseWorkflow expectedWorkflow = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Tags = ["string"],
        };

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedWorkflow, deserialized.Workflow);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                DisplayName = "displayName",
                EmailAddress = "emailAddress",
                Tags = ["string"],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowUpdateResponse { };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Workflow);
        Assert.False(model.RawData.ContainsKey("workflow"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowUpdateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            Error = null,
            Workflow = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Workflow);
        Assert.False(model.RawData.ContainsKey("workflow"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            Error = null,
            Workflow = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                DisplayName = "displayName",
                EmailAddress = "emailAddress",
                Tags = ["string"],
            },
        };

        WorkflowUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowUpdateResponseWorkflowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Tags = ["string"],
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<WorkflowUpdateResponseWorkflowEdge> expectedEdges =
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
        List<WorkflowUpdateResponseWorkflowNode> expectedNodes =
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNum = 0;
        WorkflowUpdateResponseWorkflowAudit expectedAudit = new()
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
        string expectedDisplayName = "displayName";
        string expectedEmailAddress = "emailAddress";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEdges.Count, model.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.Equal(expectedEdges[i], model.Edges[i]);
        }
        Assert.Equal(expectedMainNodeName, model.MainNodeName);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNodes.Count, model.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], model.Nodes[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponseWorkflow>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponseWorkflow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<WorkflowUpdateResponseWorkflowEdge> expectedEdges =
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
        List<WorkflowUpdateResponseWorkflowNode> expectedNodes =
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNum = 0;
        WorkflowUpdateResponseWorkflowAudit expectedAudit = new()
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
        string expectedDisplayName = "displayName";
        string expectedEmailAddress = "emailAddress";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEdges.Count, deserialized.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.Equal(expectedEdges[i], deserialized.Edges[i]);
        }
        Assert.Equal(expectedMainNodeName, deserialized.MainNodeName);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNodes.Count, deserialized.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], deserialized.Nodes[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("emailAddress"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            EmailAddress = null,
            Tags = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("emailAddress"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            EmailAddress = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowUpdateResponseWorkflow
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            DisplayName = "displayName",
            EmailAddress = "emailAddress",
            Tags = ["string"],
        };

        WorkflowUpdateResponseWorkflow copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowUpdateResponseWorkflowEdgeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowEdge
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
        var model = new WorkflowUpdateResponseWorkflowEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponseWorkflowEdge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponseWorkflowEdge>(
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
        var model = new WorkflowUpdateResponseWorkflowEdge
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
        var model = new WorkflowUpdateResponseWorkflowEdge
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
        var model = new WorkflowUpdateResponseWorkflowEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowEdge
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
        var model = new WorkflowUpdateResponseWorkflowEdge
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
        var model = new WorkflowUpdateResponseWorkflowEdge
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
        };

        WorkflowUpdateResponseWorkflowEdge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowUpdateResponseWorkflowNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowNode
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
        var model = new WorkflowUpdateResponseWorkflowNode
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
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponseWorkflowNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowNode
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
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponseWorkflowNode>(
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
        var model = new WorkflowUpdateResponseWorkflowNode
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
    public void CopyConstructor_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
        };

        WorkflowUpdateResponseWorkflowNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowUpdateResponseWorkflowAuditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowAudit
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
        var model = new WorkflowUpdateResponseWorkflowAudit
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
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponseWorkflowAudit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowAudit
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
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponseWorkflowAudit>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new WorkflowUpdateResponseWorkflowAudit
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
        var model = new WorkflowUpdateResponseWorkflowAudit { };

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
        var model = new WorkflowUpdateResponseWorkflowAudit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowUpdateResponseWorkflowAudit
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
        var model = new WorkflowUpdateResponseWorkflowAudit
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
        var model = new WorkflowUpdateResponseWorkflowAudit
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

        WorkflowUpdateResponseWorkflowAudit copied = new(model);

        Assert.Equal(model, copied);
    }
}
