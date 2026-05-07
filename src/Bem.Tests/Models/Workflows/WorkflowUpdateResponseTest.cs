using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
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
        };

        List<WorkflowConnectorError> expectedConnectorErrors =
        [
            new()
            {
                Code = "code",
                Message = "message",
                Operation = Operation.Create,
                ConnectorID = "connectorID",
                Name = "name",
            },
        ];
        string expectedError = "error";
        Workflow expectedWorkflow = new()
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

        Assert.NotNull(model.ConnectorErrors);
        Assert.Equal(expectedConnectorErrors.Count, model.ConnectorErrors.Count);
        for (int i = 0; i < expectedConnectorErrors.Count; i++)
        {
            Assert.Equal(expectedConnectorErrors[i], model.ConnectorErrors[i]);
        }
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedWorkflow, model.Workflow);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
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
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WorkflowConnectorError> expectedConnectorErrors =
        [
            new()
            {
                Code = "code",
                Message = "message",
                Operation = Operation.Create,
                ConnectorID = "connectorID",
                Name = "name",
            },
        ];
        string expectedError = "error";
        Workflow expectedWorkflow = new()
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

        Assert.NotNull(deserialized.ConnectorErrors);
        Assert.Equal(expectedConnectorErrors.Count, deserialized.ConnectorErrors.Count);
        for (int i = 0; i < expectedConnectorErrors.Count; i++)
        {
            Assert.Equal(expectedConnectorErrors[i], deserialized.ConnectorErrors[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedWorkflow, deserialized.Workflow);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUpdateResponse
        {
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowUpdateResponse { };

        Assert.Null(model.ConnectorErrors);
        Assert.False(model.RawData.ContainsKey("connectorErrors"));
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
            ConnectorErrors = null,
            Error = null,
            Workflow = null,
        };

        Assert.Null(model.ConnectorErrors);
        Assert.False(model.RawData.ContainsKey("connectorErrors"));
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
            ConnectorErrors = null,
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
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
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
        };

        WorkflowUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
