using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;
using Versions = Bem.Models.Functions.Versions;

namespace Bem.Tests.Models.Functions.Versions;

public class VersionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionListResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Versions::VersionTransform()
                {
                    EmailAddress = "emailAddress",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OutputSchemaName = "outputSchemaName",
                    TabularChunkingEnabled = true,
                    VersionNum = 0,
                    Audit = new()
                    {
                        FunctionCreatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        FunctionLastUpdatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        VersionCreatedBy = new()
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
                    Tags = ["string"],
                    UsedInWorkflows =
                    [
                        new()
                        {
                            CurrentVersionNum = 0,
                            UsedInWorkflowVersionNums = [0],
                            WorkflowID = "workflowID",
                            WorkflowName = "workflowName",
                        },
                    ],
                },
            ],
        };

        long expectedTotalCount = 0;
        List<Versions::Version> expectedVersions =
        [
            new Versions::VersionTransform()
            {
                EmailAddress = "emailAddress",
                FunctionID = "functionID",
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                VersionNum = 0,
                Audit = new()
                {
                    FunctionCreatedBy = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UserActionID = "userActionID",
                        ApiKeyName = "apiKeyName",
                        EmailAddress = "emailAddress",
                        UserEmail = "userEmail",
                        UserID = "userID",
                    },
                    FunctionLastUpdatedBy = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UserActionID = "userActionID",
                        ApiKeyName = "apiKeyName",
                        EmailAddress = "emailAddress",
                        UserEmail = "userEmail",
                        UserID = "userID",
                    },
                    VersionCreatedBy = new()
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
                Tags = ["string"],
                UsedInWorkflows =
                [
                    new()
                    {
                        CurrentVersionNum = 0,
                        UsedInWorkflowVersionNums = [0],
                        WorkflowID = "workflowID",
                        WorkflowName = "workflowName",
                    },
                ],
            },
        ];

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
        var model = new Versions::VersionListResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Versions::VersionTransform()
                {
                    EmailAddress = "emailAddress",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OutputSchemaName = "outputSchemaName",
                    TabularChunkingEnabled = true,
                    VersionNum = 0,
                    Audit = new()
                    {
                        FunctionCreatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        FunctionLastUpdatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        VersionCreatedBy = new()
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
                    Tags = ["string"],
                    UsedInWorkflows =
                    [
                        new()
                        {
                            CurrentVersionNum = 0,
                            UsedInWorkflowVersionNums = [0],
                            WorkflowID = "workflowID",
                            WorkflowName = "workflowName",
                        },
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionListResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Versions::VersionTransform()
                {
                    EmailAddress = "emailAddress",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OutputSchemaName = "outputSchemaName",
                    TabularChunkingEnabled = true,
                    VersionNum = 0,
                    Audit = new()
                    {
                        FunctionCreatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        FunctionLastUpdatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        VersionCreatedBy = new()
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
                    Tags = ["string"],
                    UsedInWorkflows =
                    [
                        new()
                        {
                            CurrentVersionNum = 0,
                            UsedInWorkflowVersionNums = [0],
                            WorkflowID = "workflowID",
                            WorkflowName = "workflowName",
                        },
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTotalCount = 0;
        List<Versions::Version> expectedVersions =
        [
            new Versions::VersionTransform()
            {
                EmailAddress = "emailAddress",
                FunctionID = "functionID",
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                VersionNum = 0,
                Audit = new()
                {
                    FunctionCreatedBy = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UserActionID = "userActionID",
                        ApiKeyName = "apiKeyName",
                        EmailAddress = "emailAddress",
                        UserEmail = "userEmail",
                        UserID = "userID",
                    },
                    FunctionLastUpdatedBy = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UserActionID = "userActionID",
                        ApiKeyName = "apiKeyName",
                        EmailAddress = "emailAddress",
                        UserEmail = "userEmail",
                        UserID = "userID",
                    },
                    VersionCreatedBy = new()
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
                Tags = ["string"],
                UsedInWorkflows =
                [
                    new()
                    {
                        CurrentVersionNum = 0,
                        UsedInWorkflowVersionNums = [0],
                        WorkflowID = "workflowID",
                        WorkflowName = "workflowName",
                    },
                ],
            },
        ];

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
        var model = new Versions::VersionListResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Versions::VersionTransform()
                {
                    EmailAddress = "emailAddress",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OutputSchemaName = "outputSchemaName",
                    TabularChunkingEnabled = true,
                    VersionNum = 0,
                    Audit = new()
                    {
                        FunctionCreatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        FunctionLastUpdatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        VersionCreatedBy = new()
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
                    Tags = ["string"],
                    UsedInWorkflows =
                    [
                        new()
                        {
                            CurrentVersionNum = 0,
                            UsedInWorkflowVersionNums = [0],
                            WorkflowID = "workflowID",
                            WorkflowName = "workflowName",
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionListResponse { };

        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Versions);
        Assert.False(model.RawData.ContainsKey("versions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionListResponse
        {
            // Null should be interpreted as omitted for these properties
            TotalCount = null,
            Versions = null,
        };

        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Versions);
        Assert.False(model.RawData.ContainsKey("versions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionListResponse
        {
            // Null should be interpreted as omitted for these properties
            TotalCount = null,
            Versions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionListResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Versions::VersionTransform()
                {
                    EmailAddress = "emailAddress",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OutputSchemaName = "outputSchemaName",
                    TabularChunkingEnabled = true,
                    VersionNum = 0,
                    Audit = new()
                    {
                        FunctionCreatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        FunctionLastUpdatedBy = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UserActionID = "userActionID",
                            ApiKeyName = "apiKeyName",
                            EmailAddress = "emailAddress",
                            UserEmail = "userEmail",
                            UserID = "userID",
                        },
                        VersionCreatedBy = new()
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
                    Tags = ["string"],
                    UsedInWorkflows =
                    [
                        new()
                        {
                            CurrentVersionNum = 0,
                            UsedInWorkflowVersionNums = [0],
                            WorkflowID = "workflowID",
                            WorkflowName = "workflowName",
                        },
                    ],
                },
            ],
        };

        Versions::VersionListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionTest : TestBase
{
    [Fact]
    public void TransformValidationWorks()
    {
        Versions::Version value = new Versions::VersionTransform()
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void ExtractValidationWorks()
    {
        Versions::Version value = new Versions::VersionExtract()
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void AnalyzeValidationWorks()
    {
        Versions::Version value = new Versions::VersionAnalyze()
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void ClassifyValidationWorks()
    {
        Versions::Version value = new Versions::VersionClassify()
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void SendValidationWorks()
    {
        Versions::Version value = new Versions::VersionSend()
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };
        value.Validate();
    }

    [Fact]
    public void SplitValidationWorks()
    {
        Versions::Version value = new Versions::VersionSplit()
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            PrintPageSplitConfig = new() { NextFunctionID = "nextFunctionID" },
            SemanticPageSplitConfig = new()
            {
                ItemClasses =
                [
                    new()
                    {
                        Name = "name",
                        Description = "description",
                        NextFunctionID = "nextFunctionID",
                        NextFunctionName = "nextFunctionName",
                    },
                ],
            },
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void JoinValidationWorks()
    {
        Versions::Version value = new Versions::VersionJoin()
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void EnrichValidationWorks()
    {
        Versions::Version value = new Versions::VersionEnrich()
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void PayloadShapingValidationWorks()
    {
        Versions::Version value = new Versions::VersionPayloadShaping()
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void TransformSerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionTransform()
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractSerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionExtract()
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnalyzeSerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionAnalyze()
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClassifySerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionClassify()
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionSend()
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitSerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionSplit()
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            PrintPageSplitConfig = new() { NextFunctionID = "nextFunctionID" },
            SemanticPageSplitConfig = new()
            {
                ItemClasses =
                [
                    new()
                    {
                        Name = "name",
                        Description = "description",
                        NextFunctionID = "nextFunctionID",
                        NextFunctionName = "nextFunctionName",
                    },
                ],
            },
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionJoin()
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionEnrich()
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PayloadShapingSerializationRoundtripWorks()
    {
        Versions::Version value = new Versions::VersionPayloadShaping()
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::Version>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VersionTransformTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string expectedEmailAddress = "emailAddress";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("transform");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
        Assert.Equal(expectedTabularChunkingEnabled, model.TabularChunkingEnabled);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionTransform>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionTransform>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmailAddress = "emailAddress";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("transform");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
        Assert.Equal(expectedTabularChunkingEnabled, deserialized.TabularChunkingEnabled);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionTransform
        {
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        Versions::VersionTransform copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionExtractTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("extract");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
        Assert.Equal(expectedTabularChunkingEnabled, model.TabularChunkingEnabled);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionExtract>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionExtract>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("extract");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
        Assert.Equal(expectedTabularChunkingEnabled, deserialized.TabularChunkingEnabled);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        Versions::VersionExtract copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionAnalyzeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        bool expectedEnableBoundingBoxes = true;
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedPreCount = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("analyze");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedEnableBoundingBoxes, model.EnableBoundingBoxes);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
        Assert.Equal(expectedPreCount, model.PreCount);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionAnalyze>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionAnalyze>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnableBoundingBoxes = true;
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedPreCount = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("analyze");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedEnableBoundingBoxes, deserialized.EnableBoundingBoxes);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
        Assert.Equal(expectedPreCount, deserialized.PreCount);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionAnalyze
        {
            EnableBoundingBoxes = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        Versions::VersionAnalyze copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionClassifyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        List<Versions::VersionClassifyClassification> expectedClassifications =
        [
            new()
            {
                Name = "name",
                Description = "description",
                FunctionID = "functionID",
                FunctionName = "functionName",
                IsErrorFallback = true,
                Origin = new() { Email = new() { Patterns = ["string"] } },
                Regex = new() { Patterns = ["string"] },
            },
        ];
        string expectedDescription = "description";
        string expectedEmailAddress = "emailAddress";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("classify");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedClassifications.Count, model.Classifications.Count);
        for (int i = 0; i < expectedClassifications.Count; i++)
        {
            Assert.Equal(expectedClassifications[i], model.Classifications[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionClassify>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionClassify>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Versions::VersionClassifyClassification> expectedClassifications =
        [
            new()
            {
                Name = "name",
                Description = "description",
                FunctionID = "functionID",
                FunctionName = "functionName",
                IsErrorFallback = true,
                Origin = new() { Email = new() { Patterns = ["string"] } },
                Regex = new() { Patterns = ["string"] },
            },
        ];
        string expectedDescription = "description";
        string expectedEmailAddress = "emailAddress";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("classify");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedClassifications.Count, deserialized.Classifications.Count);
        for (int i = 0; i < expectedClassifications.Count; i++)
        {
            Assert.Equal(expectedClassifications[i], deserialized.Classifications[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionClassify
        {
            Classifications =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    IsErrorFallback = true,
                    Origin = new() { Email = new() { Patterns = ["string"] } },
                    Regex = new() { Patterns = ["string"] },
                },
            ],
            Description = "description",
            EmailAddress = "emailAddress",
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        Versions::VersionClassify copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionClassifyClassificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionClassifyClassification
        {
            Name = "name",
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            IsErrorFallback = true,
            Origin = new() { Email = new() { Patterns = ["string"] } },
            Regex = new() { Patterns = ["string"] },
        };

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        bool expectedIsErrorFallback = true;
        Versions::VersionClassifyClassificationOrigin expectedOrigin = new()
        {
            Email = new() { Patterns = ["string"] },
        };
        Versions::VersionClassifyClassificationRegex expectedRegex = new()
        {
            Patterns = ["string"],
        };

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedIsErrorFallback, model.IsErrorFallback);
        Assert.Equal(expectedOrigin, model.Origin);
        Assert.Equal(expectedRegex, model.Regex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionClassifyClassification
        {
            Name = "name",
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            IsErrorFallback = true,
            Origin = new() { Email = new() { Patterns = ["string"] } },
            Regex = new() { Patterns = ["string"] },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionClassifyClassification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionClassifyClassification
        {
            Name = "name",
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            IsErrorFallback = true,
            Origin = new() { Email = new() { Patterns = ["string"] } },
            Regex = new() { Patterns = ["string"] },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionClassifyClassification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        bool expectedIsErrorFallback = true;
        Versions::VersionClassifyClassificationOrigin expectedOrigin = new()
        {
            Email = new() { Patterns = ["string"] },
        };
        Versions::VersionClassifyClassificationRegex expectedRegex = new()
        {
            Patterns = ["string"],
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedIsErrorFallback, deserialized.IsErrorFallback);
        Assert.Equal(expectedOrigin, deserialized.Origin);
        Assert.Equal(expectedRegex, deserialized.Regex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionClassifyClassification
        {
            Name = "name",
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            IsErrorFallback = true,
            Origin = new() { Email = new() { Patterns = ["string"] } },
            Regex = new() { Patterns = ["string"] },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionClassifyClassification { Name = "name" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FunctionID);
        Assert.False(model.RawData.ContainsKey("functionID"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.IsErrorFallback);
        Assert.False(model.RawData.ContainsKey("isErrorFallback"));
        Assert.Null(model.Origin);
        Assert.False(model.RawData.ContainsKey("origin"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionClassifyClassification { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionClassifyClassification
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            FunctionID = null,
            FunctionName = null,
            IsErrorFallback = null,
            Origin = null,
            Regex = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FunctionID);
        Assert.False(model.RawData.ContainsKey("functionID"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.IsErrorFallback);
        Assert.False(model.RawData.ContainsKey("isErrorFallback"));
        Assert.Null(model.Origin);
        Assert.False(model.RawData.ContainsKey("origin"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionClassifyClassification
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            FunctionID = null,
            FunctionName = null,
            IsErrorFallback = null,
            Origin = null,
            Regex = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionClassifyClassification
        {
            Name = "name",
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            IsErrorFallback = true,
            Origin = new() { Email = new() { Patterns = ["string"] } },
            Regex = new() { Patterns = ["string"] },
        };

        Versions::VersionClassifyClassification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionClassifyClassificationOriginTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        Versions::VersionClassifyClassificationOriginEmail expectedEmail = new()
        {
            Patterns = ["string"],
        };

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Versions::VersionClassifyClassificationOrigin>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Versions::VersionClassifyClassificationOrigin>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Versions::VersionClassifyClassificationOriginEmail expectedEmail = new()
        {
            Patterns = ["string"],
        };

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin { };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
        };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        Versions::VersionClassifyClassificationOrigin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionClassifyClassificationOriginEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        List<string> expectedPatterns = ["string"];

        Assert.NotNull(model.Patterns);
        Assert.Equal(expectedPatterns.Count, model.Patterns.Count);
        for (int i = 0; i < expectedPatterns.Count; i++)
        {
            Assert.Equal(expectedPatterns[i], model.Patterns[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Versions::VersionClassifyClassificationOriginEmail>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Versions::VersionClassifyClassificationOriginEmail>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedPatterns = ["string"];

        Assert.NotNull(deserialized.Patterns);
        Assert.Equal(expectedPatterns.Count, deserialized.Patterns.Count);
        for (int i = 0; i < expectedPatterns.Count; i++)
        {
            Assert.Equal(expectedPatterns[i], deserialized.Patterns[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail { };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        Versions::VersionClassifyClassificationOriginEmail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionClassifyClassificationRegexTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex { Patterns = ["string"] };

        List<string> expectedPatterns = ["string"];

        Assert.NotNull(model.Patterns);
        Assert.Equal(expectedPatterns.Count, model.Patterns.Count);
        for (int i = 0; i < expectedPatterns.Count; i++)
        {
            Assert.Equal(expectedPatterns[i], model.Patterns[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex { Patterns = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionClassifyClassificationRegex>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex { Patterns = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionClassifyClassificationRegex>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedPatterns = ["string"];

        Assert.NotNull(deserialized.Patterns);
        Assert.Equal(expectedPatterns.Count, deserialized.Patterns.Count);
        for (int i = 0; i < expectedPatterns.Count; i++)
        {
            Assert.Equal(expectedPatterns[i], deserialized.Patterns[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex { Patterns = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex { };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionClassifyClassificationRegex { Patterns = ["string"] };

        Versions::VersionClassifyClassificationRegex copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionSendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        ApiEnum<string, Versions::VersionSendDestinationType> expectedDestinationType =
            Versions::VersionSendDestinationType.Webhook;
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("send");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        string expectedGoogleDriveFolderID = "googleDriveFolderId";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3Prefix = "s3Prefix";
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];
        bool expectedWebhookSigningEnabled = true;
        string expectedWebhookUrl = "webhookUrl";

        Assert.Equal(expectedDestinationType, model.DestinationType);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedGoogleDriveFolderID, model.GoogleDriveFolderID);
        Assert.Equal(expectedS3Bucket, model.S3Bucket);
        Assert.Equal(expectedS3Prefix, model.S3Prefix);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
        Assert.Equal(expectedWebhookSigningEnabled, model.WebhookSigningEnabled);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionSend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionSend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Versions::VersionSendDestinationType> expectedDestinationType =
            Versions::VersionSendDestinationType.Webhook;
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("send");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        string expectedGoogleDriveFolderID = "googleDriveFolderId";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3Prefix = "s3Prefix";
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];
        bool expectedWebhookSigningEnabled = true;
        string expectedWebhookUrl = "webhookUrl";

        Assert.Equal(expectedDestinationType, deserialized.DestinationType);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedGoogleDriveFolderID, deserialized.GoogleDriveFolderID);
        Assert.Equal(expectedS3Bucket, deserialized.S3Bucket);
        Assert.Equal(expectedS3Prefix, deserialized.S3Prefix);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
        Assert.Equal(expectedWebhookSigningEnabled, deserialized.WebhookSigningEnabled);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.GoogleDriveFolderID);
        Assert.False(model.RawData.ContainsKey("googleDriveFolderId"));
        Assert.Null(model.S3Bucket);
        Assert.False(model.RawData.ContainsKey("s3Bucket"));
        Assert.Null(model.S3Prefix);
        Assert.False(model.RawData.ContainsKey("s3Prefix"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
        Assert.Null(model.WebhookSigningEnabled);
        Assert.False(model.RawData.ContainsKey("webhookSigningEnabled"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            GoogleDriveFolderID = null,
            S3Bucket = null,
            S3Prefix = null,
            Tags = null,
            UsedInWorkflows = null,
            WebhookSigningEnabled = null,
            WebhookUrl = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.GoogleDriveFolderID);
        Assert.False(model.RawData.ContainsKey("googleDriveFolderId"));
        Assert.Null(model.S3Bucket);
        Assert.False(model.RawData.ContainsKey("s3Bucket"));
        Assert.Null(model.S3Prefix);
        Assert.False(model.RawData.ContainsKey("s3Prefix"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
        Assert.Null(model.WebhookSigningEnabled);
        Assert.False(model.RawData.ContainsKey("webhookSigningEnabled"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            GoogleDriveFolderID = null,
            S3Bucket = null,
            S3Prefix = null,
            Tags = null,
            UsedInWorkflows = null,
            WebhookSigningEnabled = null,
            WebhookUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionSend
        {
            DestinationType = Versions::VersionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        Versions::VersionSend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionSendDestinationTypeTest : TestBase
{
    [Theory]
    [InlineData(Versions::VersionSendDestinationType.Webhook)]
    [InlineData(Versions::VersionSendDestinationType.S3)]
    [InlineData(Versions::VersionSendDestinationType.GoogleDrive)]
    public void Validation_Works(Versions::VersionSendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Versions::VersionSendDestinationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Versions::VersionSendDestinationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Versions::VersionSendDestinationType.Webhook)]
    [InlineData(Versions::VersionSendDestinationType.S3)]
    [InlineData(Versions::VersionSendDestinationType.GoogleDrive)]
    public void SerializationRoundtrip_Works(Versions::VersionSendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Versions::VersionSendDestinationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Versions::VersionSendDestinationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Versions::VersionSendDestinationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Versions::VersionSendDestinationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VersionSplitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            PrintPageSplitConfig = new() { NextFunctionID = "nextFunctionID" },
            SemanticPageSplitConfig = new()
            {
                ItemClasses =
                [
                    new()
                    {
                        Name = "name",
                        Description = "description",
                        NextFunctionID = "nextFunctionID",
                        NextFunctionName = "nextFunctionName",
                    },
                ],
            },
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, Versions::VersionSplitSplitType> expectedSplitType =
            Versions::VersionSplitSplitType.PrintPage;
        JsonElement expectedType = JsonSerializer.SerializeToElement("split");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        Versions::VersionSplitPrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
        };
        Versions::VersionSplitSemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
        {
            ItemClasses =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    NextFunctionID = "nextFunctionID",
                    NextFunctionName = "nextFunctionName",
                },
            ],
        };
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedSplitType, model.SplitType);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedPrintPageSplitConfig, model.PrintPageSplitConfig);
        Assert.Equal(expectedSemanticPageSplitConfig, model.SemanticPageSplitConfig);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            PrintPageSplitConfig = new() { NextFunctionID = "nextFunctionID" },
            SemanticPageSplitConfig = new()
            {
                ItemClasses =
                [
                    new()
                    {
                        Name = "name",
                        Description = "description",
                        NextFunctionID = "nextFunctionID",
                        NextFunctionName = "nextFunctionName",
                    },
                ],
            },
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionSplit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            PrintPageSplitConfig = new() { NextFunctionID = "nextFunctionID" },
            SemanticPageSplitConfig = new()
            {
                ItemClasses =
                [
                    new()
                    {
                        Name = "name",
                        Description = "description",
                        NextFunctionID = "nextFunctionID",
                        NextFunctionName = "nextFunctionName",
                    },
                ],
            },
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionSplit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, Versions::VersionSplitSplitType> expectedSplitType =
            Versions::VersionSplitSplitType.PrintPage;
        JsonElement expectedType = JsonSerializer.SerializeToElement("split");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        Versions::VersionSplitPrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
        };
        Versions::VersionSplitSemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
        {
            ItemClasses =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    NextFunctionID = "nextFunctionID",
                    NextFunctionName = "nextFunctionName",
                },
            ],
        };
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedSplitType, deserialized.SplitType);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedPrintPageSplitConfig, deserialized.PrintPageSplitConfig);
        Assert.Equal(expectedSemanticPageSplitConfig, deserialized.SemanticPageSplitConfig);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            PrintPageSplitConfig = new() { NextFunctionID = "nextFunctionID" },
            SemanticPageSplitConfig = new()
            {
                ItemClasses =
                [
                    new()
                    {
                        Name = "name",
                        Description = "description",
                        NextFunctionID = "nextFunctionID",
                        NextFunctionName = "nextFunctionName",
                    },
                ],
            },
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.PrintPageSplitConfig);
        Assert.False(model.RawData.ContainsKey("printPageSplitConfig"));
        Assert.Null(model.SemanticPageSplitConfig);
        Assert.False(model.RawData.ContainsKey("semanticPageSplitConfig"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            PrintPageSplitConfig = null,
            SemanticPageSplitConfig = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.PrintPageSplitConfig);
        Assert.False(model.RawData.ContainsKey("printPageSplitConfig"));
        Assert.Null(model.SemanticPageSplitConfig);
        Assert.False(model.RawData.ContainsKey("semanticPageSplitConfig"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            PrintPageSplitConfig = null,
            SemanticPageSplitConfig = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = Versions::VersionSplitSplitType.PrintPage,
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            PrintPageSplitConfig = new() { NextFunctionID = "nextFunctionID" },
            SemanticPageSplitConfig = new()
            {
                ItemClasses =
                [
                    new()
                    {
                        Name = "name",
                        Description = "description",
                        NextFunctionID = "nextFunctionID",
                        NextFunctionName = "nextFunctionName",
                    },
                ],
            },
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        Versions::VersionSplit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionSplitSplitTypeTest : TestBase
{
    [Theory]
    [InlineData(Versions::VersionSplitSplitType.PrintPage)]
    [InlineData(Versions::VersionSplitSplitType.SemanticPage)]
    public void Validation_Works(Versions::VersionSplitSplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Versions::VersionSplitSplitType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Versions::VersionSplitSplitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Versions::VersionSplitSplitType.PrintPage)]
    [InlineData(Versions::VersionSplitSplitType.SemanticPage)]
    public void SerializationRoundtrip_Works(Versions::VersionSplitSplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Versions::VersionSplitSplitType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Versions::VersionSplitSplitType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Versions::VersionSplitSplitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Versions::VersionSplitSplitType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VersionSplitPrintPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
        };

        string expectedNextFunctionID = "nextFunctionID";

        Assert.Equal(expectedNextFunctionID, model.NextFunctionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionSplitPrintPageSplitConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionSplitPrintPageSplitConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNextFunctionID = "nextFunctionID";

        Assert.Equal(expectedNextFunctionID, deserialized.NextFunctionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig { };

        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            NextFunctionID = null,
        };

        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            NextFunctionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
        };

        Versions::VersionSplitPrintPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionSplitSemanticPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig
        {
            ItemClasses =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    NextFunctionID = "nextFunctionID",
                    NextFunctionName = "nextFunctionName",
                },
            ],
        };

        List<SplitFunctionSemanticPageItemClass> expectedItemClasses =
        [
            new()
            {
                Name = "name",
                Description = "description",
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
        ];

        Assert.NotNull(model.ItemClasses);
        Assert.Equal(expectedItemClasses.Count, model.ItemClasses.Count);
        for (int i = 0; i < expectedItemClasses.Count; i++)
        {
            Assert.Equal(expectedItemClasses[i], model.ItemClasses[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig
        {
            ItemClasses =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    NextFunctionID = "nextFunctionID",
                    NextFunctionName = "nextFunctionName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Versions::VersionSplitSemanticPageSplitConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig
        {
            ItemClasses =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    NextFunctionID = "nextFunctionID",
                    NextFunctionName = "nextFunctionName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Versions::VersionSplitSemanticPageSplitConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<SplitFunctionSemanticPageItemClass> expectedItemClasses =
        [
            new()
            {
                Name = "name",
                Description = "description",
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
        ];

        Assert.NotNull(deserialized.ItemClasses);
        Assert.Equal(expectedItemClasses.Count, deserialized.ItemClasses.Count);
        for (int i = 0; i < expectedItemClasses.Count; i++)
        {
            Assert.Equal(expectedItemClasses[i], deserialized.ItemClasses[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig
        {
            ItemClasses =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    NextFunctionID = "nextFunctionID",
                    NextFunctionName = "nextFunctionName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig { };

        Assert.Null(model.ItemClasses);
        Assert.False(model.RawData.ContainsKey("itemClasses"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            ItemClasses = null,
        };

        Assert.Null(model.ItemClasses);
        Assert.False(model.RawData.ContainsKey("itemClasses"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            ItemClasses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionSplitSemanticPageSplitConfig
        {
            ItemClasses =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    NextFunctionID = "nextFunctionID",
                    NextFunctionName = "nextFunctionName",
                },
            ],
        };

        Versions::VersionSplitSemanticPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionJoinTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string expectedDescription = "description";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, Versions::VersionJoinJoinType> expectedJoinType =
            Versions::VersionJoinJoinType.Standard;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("join");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedJoinType, model.JoinType);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionJoin>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionJoin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, Versions::VersionJoinJoinType> expectedJoinType =
            Versions::VersionJoinJoinType.Standard;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("join");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedJoinType, deserialized.JoinType);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = Versions::VersionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        Versions::VersionJoin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionJoinJoinTypeTest : TestBase
{
    [Theory]
    [InlineData(Versions::VersionJoinJoinType.Standard)]
    public void Validation_Works(Versions::VersionJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Versions::VersionJoinJoinType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Versions::VersionJoinJoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Versions::VersionJoinJoinType.Standard)]
    public void SerializationRoundtrip_Works(Versions::VersionJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Versions::VersionJoinJoinType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Versions::VersionJoinJoinType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Versions::VersionJoinJoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Versions::VersionJoinJoinType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VersionEnrichTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        EnrichConfig expectedConfig = new(
            [
                new()
                {
                    CollectionName = "collectionName",
                    SourceField = "sourceField",
                    TargetField = "targetField",
                    IncludeCosineDistance = true,
                    IncludeSubcollections = true,
                    ScoreThreshold = 0,
                    SearchMode = SearchMode.Semantic,
                    TopK = 1,
                },
            ]
        );
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("enrich");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedConfig, model.Config);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionEnrich>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionEnrich>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EnrichConfig expectedConfig = new(
            [
                new()
                {
                    CollectionName = "collectionName",
                    SourceField = "sourceField",
                    TargetField = "targetField",
                    IncludeCosineDistance = true,
                    IncludeSubcollections = true,
                    ScoreThreshold = 0,
                    SearchMode = SearchMode.Semantic,
                    TopK = 1,
                },
            ]
        );
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("enrich");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedConfig, deserialized.Config);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionEnrich
        {
            Config = new(
                [
                    new()
                    {
                        CollectionName = "collectionName",
                        SourceField = "sourceField",
                        TargetField = "targetField",
                        IncludeCosineDistance = true,
                        IncludeSubcollections = true,
                        ScoreThreshold = 0,
                        SearchMode = SearchMode.Semantic,
                        TopK = 1,
                    },
                ]
            ),
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        Versions::VersionEnrich copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionPayloadShapingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedShapingSchema = "shapingSchema";
        JsonElement expectedType = JsonSerializer.SerializeToElement("payload_shaping");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedShapingSchema, model.ShapingSchema);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersionNum, model.VersionNum);
        Assert.Equal(expectedAudit, model.Audit);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.NotNull(model.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, model.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], model.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionPayloadShaping>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Versions::VersionPayloadShaping>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedShapingSchema = "shapingSchema";
        JsonElement expectedType = JsonSerializer.SerializeToElement("payload_shaping");
        long expectedVersionNum = 0;
        FunctionAudit expectedAudit = new()
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
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
        List<string> expectedTags = ["string"];
        List<WorkflowUsageInfo> expectedUsedInWorkflows =
        [
            new()
            {
                CurrentVersionNum = 0,
                UsedInWorkflowVersionNums = [0],
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
            },
        ];

        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedShapingSchema, deserialized.ShapingSchema);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
        Assert.Equal(expectedAudit, deserialized.Audit);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.NotNull(deserialized.UsedInWorkflows);
        Assert.Equal(expectedUsedInWorkflows.Count, deserialized.UsedInWorkflows.Count);
        for (int i = 0; i < expectedUsedInWorkflows.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflows[i], deserialized.UsedInWorkflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UsedInWorkflows);
        Assert.False(model.RawData.ContainsKey("usedInWorkflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            CreatedAt = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Versions::VersionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
            Audit = new()
            {
                FunctionCreatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                FunctionLastUpdatedBy = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserActionID = "userActionID",
                    ApiKeyName = "apiKeyName",
                    EmailAddress = "emailAddress",
                    UserEmail = "userEmail",
                    UserID = "userID",
                },
                VersionCreatedBy = new()
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
            Tags = ["string"],
            UsedInWorkflows =
            [
                new()
                {
                    CurrentVersionNum = 0,
                    UsedInWorkflowVersionNums = [0],
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                },
            ],
        };

        Versions::VersionPayloadShaping copied = new(model);

        Assert.Equal(model, copied);
    }
}
