using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;
using Bem.Models.Workflows.Versions;

namespace Bem.Tests.Models.Workflows.Versions;

public class VersionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Versions =
            [
                new()
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
            ],
        };

        string expectedError = "error";
        long expectedTotalCount = 0;
        List<Workflow> expectedVersions =
        [
            new()
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
        ];

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.NotNull(model.Versions);
        Assert.Equal(expectedVersions.Count, model.Versions.Count);
        for (int i = 0; i < expectedVersions.Count; i++)
        {
            Assert.Equal(expectedVersions[i], model.Versions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VersionListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Versions =
            [
                new()
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
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Versions =
            [
                new()
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
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        long expectedTotalCount = 0;
        List<Workflow> expectedVersions =
        [
            new()
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
        ];

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.NotNull(deserialized.Versions);
        Assert.Equal(expectedVersions.Count, deserialized.Versions.Count);
        for (int i = 0; i < expectedVersions.Count; i++)
        {
            Assert.Equal(expectedVersions[i], deserialized.Versions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VersionListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Versions =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VersionListPageResponse { };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Versions);
        Assert.False(model.RawData.ContainsKey("versions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VersionListPageResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VersionListPageResponse
        {
            // Null should be interpreted as omitted for these properties
            Error = null,
            TotalCount = null,
            Versions = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Versions);
        Assert.False(model.RawData.ContainsKey("versions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VersionListPageResponse
        {
            // Null should be interpreted as omitted for these properties
            Error = null,
            TotalCount = null,
            Versions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VersionListPageResponse
        {
            Error = "error",
            TotalCount = 0,
            Versions =
            [
                new()
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
            ],
        };

        VersionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
