using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowRetrieveResponse
        {
            Error = "error",
            Workflow = new()
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
            },
        };

        string expectedError = "error";
        Workflow expectedWorkflow = new()
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

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedWorkflow, model.Workflow);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowRetrieveResponse
        {
            Error = "error",
            Workflow = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowRetrieveResponse
        {
            Error = "error",
            Workflow = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        Workflow expectedWorkflow = new()
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

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedWorkflow, deserialized.Workflow);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowRetrieveResponse
        {
            Error = "error",
            Workflow = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowRetrieveResponse { };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Workflow);
        Assert.False(model.RawData.ContainsKey("workflow"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowRetrieveResponse
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
        var model = new WorkflowRetrieveResponse
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
        var model = new WorkflowRetrieveResponse
        {
            Error = "error",
            Workflow = new()
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
            },
        };

        WorkflowRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
