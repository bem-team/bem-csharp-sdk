using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Workflows =
            [
                new()
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
                },
            ],
        };

        string expectedError = "error";
        long expectedTotalCount = 0;
        List<Workflow> expectedWorkflows =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.NotNull(model.Workflows);
        Assert.Equal(expectedWorkflows.Count, model.Workflows.Count);
        for (int i = 0; i < expectedWorkflows.Count; i++)
        {
            Assert.Equal(expectedWorkflows[i], model.Workflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Workflows =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Workflows =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        long expectedTotalCount = 0;
        List<Workflow> expectedWorkflows =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.NotNull(deserialized.Workflows);
        Assert.Equal(expectedWorkflows.Count, deserialized.Workflows.Count);
        for (int i = 0; i < expectedWorkflows.Count; i++)
        {
            Assert.Equal(expectedWorkflows[i], deserialized.Workflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Workflows =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowListPageResponse { };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Workflows);
        Assert.False(model.RawData.ContainsKey("workflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowListPageResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowListPageResponse
        {
            // Null should be interpreted as omitted for these properties
            Error = null,
            TotalCount = null,
            Workflows = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Workflows);
        Assert.False(model.RawData.ContainsKey("workflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowListPageResponse
        {
            // Null should be interpreted as omitted for these properties
            Error = null,
            TotalCount = null,
            Workflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Workflows =
            [
                new()
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
                },
            ],
        };

        WorkflowListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
