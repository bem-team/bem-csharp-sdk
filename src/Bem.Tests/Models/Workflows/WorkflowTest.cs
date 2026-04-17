using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
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
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        List<WorkflowConnector> expectedConnectors =
        [
            new()
            {
                ConnectorID = "connectorID",
                Name = "name",
                Type = WorkflowConnectorType.Paragon,
                Paragon = new()
                {
                    Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Integration = "integration",
                    SyncID = "syncID",
                },
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<WorkflowEdgeResponse> expectedEdges =
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
        List<WorkflowNodeResponse> expectedNodes =
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
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNum = 0;
        WorkflowAudit expectedAudit = new()
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
        Assert.Equal(expectedConnectors.Count, model.Connectors.Count);
        for (int i = 0; i < expectedConnectors.Count; i++)
        {
            Assert.Equal(expectedConnectors[i], model.Connectors[i]);
        }
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
        var model = new Workflow
        {
            ID = "id",
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var deserialized = JsonSerializer.Deserialize<Workflow>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var deserialized = JsonSerializer.Deserialize<Workflow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<WorkflowConnector> expectedConnectors =
        [
            new()
            {
                ConnectorID = "connectorID",
                Name = "name",
                Type = WorkflowConnectorType.Paragon,
                Paragon = new()
                {
                    Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Integration = "integration",
                    SyncID = "syncID",
                },
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<WorkflowEdgeResponse> expectedEdges =
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
        List<WorkflowNodeResponse> expectedNodes =
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
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNum = 0;
        WorkflowAudit expectedAudit = new()
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
        Assert.Equal(expectedConnectors.Count, deserialized.Connectors.Count);
        for (int i = 0; i < expectedConnectors.Count; i++)
        {
            Assert.Equal(expectedConnectors[i], deserialized.Connectors[i]);
        }
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
        var model = new Workflow
        {
            ID = "id",
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Workflow
        {
            ID = "id",
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Workflow
        {
            ID = "id",
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Workflow
        {
            ID = "id",
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Workflow
        {
            ID = "id",
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Workflow
        {
            ID = "id",
            Connectors =
            [
                new()
                {
                    ConnectorID = "connectorID",
                    Name = "name",
                    Type = WorkflowConnectorType.Paragon,
                    Paragon = new()
                    {
                        Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Integration = "integration",
                        SyncID = "syncID",
                    },
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    Name = "name",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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

        Workflow copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowConnectorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
                SyncID = "syncID",
            },
        };

        string expectedConnectorID = "connectorID";
        string expectedName = "name";
        ApiEnum<string, WorkflowConnectorType> expectedType = WorkflowConnectorType.Paragon;
        WorkflowConnectorParagon expectedParagon = new()
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
            SyncID = "syncID",
        };

        Assert.Equal(expectedConnectorID, model.ConnectorID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedParagon, model.Paragon);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
                SyncID = "syncID",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnector>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
                SyncID = "syncID",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnector>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConnectorID = "connectorID";
        string expectedName = "name";
        ApiEnum<string, WorkflowConnectorType> expectedType = WorkflowConnectorType.Paragon;
        WorkflowConnectorParagon expectedParagon = new()
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
            SyncID = "syncID",
        };

        Assert.Equal(expectedConnectorID, deserialized.ConnectorID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedParagon, deserialized.Paragon);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
                SyncID = "syncID",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
        };

        Assert.Null(model.Paragon);
        Assert.False(model.RawData.ContainsKey("paragon"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,

            // Null should be interpreted as omitted for these properties
            Paragon = null,
        };

        Assert.Null(model.Paragon);
        Assert.False(model.RawData.ContainsKey("paragon"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,

            // Null should be interpreted as omitted for these properties
            Paragon = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowConnector
        {
            ConnectorID = "connectorID",
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
                SyncID = "syncID",
            },
        };

        WorkflowConnector copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowConnectorTypeTest : TestBase
{
    [Theory]
    [InlineData(WorkflowConnectorType.Paragon)]
    public void Validation_Works(WorkflowConnectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkflowConnectorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkflowConnectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkflowConnectorType.Paragon)]
    public void SerializationRoundtrip_Works(WorkflowConnectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkflowConnectorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkflowConnectorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkflowConnectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkflowConnectorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WorkflowConnectorParagonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
            SyncID = "syncID",
        };

        JsonElement expectedConfiguration = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedIntegration = "integration";
        string expectedSyncID = "syncID";

        Assert.True(JsonElement.DeepEquals(expectedConfiguration, model.Configuration));
        Assert.Equal(expectedIntegration, model.Integration);
        Assert.Equal(expectedSyncID, model.SyncID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
            SyncID = "syncID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnectorParagon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
            SyncID = "syncID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnectorParagon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedConfiguration = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedIntegration = "integration";
        string expectedSyncID = "syncID";

        Assert.True(JsonElement.DeepEquals(expectedConfiguration, deserialized.Configuration));
        Assert.Equal(expectedIntegration, deserialized.Integration);
        Assert.Equal(expectedSyncID, deserialized.SyncID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
            SyncID = "syncID",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
            SyncID = "syncID",
        };

        WorkflowConnectorParagon copied = new(model);

        Assert.Equal(model, copied);
    }
}
