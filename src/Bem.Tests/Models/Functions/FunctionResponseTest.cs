using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionResponse
        {
            Function = new Transform()
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
        };

        Function expectedFunction = new Transform()
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

        Assert.Equal(expectedFunction, model.Function);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionResponse
        {
            Function = new Transform()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionResponse
        {
            Function = new Transform()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Function expectedFunction = new Transform()
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

        Assert.Equal(expectedFunction, deserialized.Function);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionResponse
        {
            Function = new Transform()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionResponse
        {
            Function = new Transform()
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
        };

        FunctionResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionTest : TestBase
{
    [Fact]
    public void TransformValidationWorks()
    {
        Function value = new Transform()
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
        Function value = new FunctionExtract()
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
        Function value = new Analyze()
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
        Function value = new FunctionClassify()
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
        Function value = new FunctionSend()
        {
            DestinationType = FunctionSendDestinationType.Webhook,
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
        Function value = new FunctionSplit()
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
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
        Function value = new FunctionJoin()
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
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
        Function value = new FunctionPayloadShaping()
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
        Function value = new FunctionEnrich()
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
        Function value = new Transform()
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractSerializationRoundtripWorks()
    {
        Function value = new FunctionExtract()
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnalyzeSerializationRoundtripWorks()
    {
        Function value = new Analyze()
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClassifySerializationRoundtripWorks()
    {
        Function value = new FunctionClassify()
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        Function value = new FunctionSend()
        {
            DestinationType = FunctionSendDestinationType.Webhook,
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitSerializationRoundtripWorks()
    {
        Function value = new FunctionSplit()
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        Function value = new FunctionJoin()
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PayloadShapingSerializationRoundtripWorks()
    {
        Function value = new FunctionPayloadShaping()
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        Function value = new FunctionEnrich()
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
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transform
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
        var model = new Transform
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
        var deserialized = JsonSerializer.Deserialize<Transform>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transform
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
        var deserialized = JsonSerializer.Deserialize<Transform>(
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
        var model = new Transform
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
        var model = new Transform
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
        var model = new Transform
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
        var model = new Transform
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
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new Transform
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
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Transform
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

        Transform copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionExtractTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionExtract
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
        var model = new FunctionExtract
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
        var deserialized = JsonSerializer.Deserialize<FunctionExtract>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionExtract
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
        var deserialized = JsonSerializer.Deserialize<FunctionExtract>(
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
        var model = new FunctionExtract
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
        var model = new FunctionExtract
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
        var model = new FunctionExtract
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
        var model = new FunctionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionExtract
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionExtract
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

        FunctionExtract copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AnalyzeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Analyze
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
        var model = new Analyze
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
        var deserialized = JsonSerializer.Deserialize<Analyze>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Analyze
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
        var deserialized = JsonSerializer.Deserialize<Analyze>(
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
        var model = new Analyze
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
        var model = new Analyze
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
        var model = new Analyze
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
        var model = new Analyze
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
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new Analyze
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
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Analyze
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

        Analyze copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionClassifyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionClassify
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

        List<FunctionClassifyClassification> expectedClassifications =
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
        var model = new FunctionClassify
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
        var deserialized = JsonSerializer.Deserialize<FunctionClassify>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionClassify
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
        var deserialized = JsonSerializer.Deserialize<FunctionClassify>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FunctionClassifyClassification> expectedClassifications =
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
        var model = new FunctionClassify
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
        var model = new FunctionClassify
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
        var model = new FunctionClassify
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
        var model = new FunctionClassify
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
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionClassify
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
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionClassify
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

        FunctionClassify copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionClassifyClassificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionClassifyClassification
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
        FunctionClassifyClassificationOrigin expectedOrigin = new()
        {
            Email = new() { Patterns = ["string"] },
        };
        FunctionClassifyClassificationRegex expectedRegex = new() { Patterns = ["string"] };

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
        var model = new FunctionClassifyClassification
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
        var deserialized = JsonSerializer.Deserialize<FunctionClassifyClassification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionClassifyClassification
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
        var deserialized = JsonSerializer.Deserialize<FunctionClassifyClassification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        bool expectedIsErrorFallback = true;
        FunctionClassifyClassificationOrigin expectedOrigin = new()
        {
            Email = new() { Patterns = ["string"] },
        };
        FunctionClassifyClassificationRegex expectedRegex = new() { Patterns = ["string"] };

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
        var model = new FunctionClassifyClassification
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
        var model = new FunctionClassifyClassification { Name = "name" };

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
        var model = new FunctionClassifyClassification { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionClassifyClassification
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
        var model = new FunctionClassifyClassification
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
        var model = new FunctionClassifyClassification
        {
            Name = "name",
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            IsErrorFallback = true,
            Origin = new() { Email = new() { Patterns = ["string"] } },
            Regex = new() { Patterns = ["string"] },
        };

        FunctionClassifyClassification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionClassifyClassificationOriginTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        FunctionClassifyClassificationOriginEmail expectedEmail = new() { Patterns = ["string"] };

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionClassifyClassificationOrigin>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionClassifyClassificationOrigin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FunctionClassifyClassificationOriginEmail expectedEmail = new() { Patterns = ["string"] };

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionClassifyClassificationOrigin { };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionClassifyClassificationOrigin { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionClassifyClassificationOrigin
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
        var model = new FunctionClassifyClassificationOrigin
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        FunctionClassifyClassificationOrigin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionClassifyClassificationOriginEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionClassifyClassificationOriginEmail { Patterns = ["string"] };

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
        var model = new FunctionClassifyClassificationOriginEmail { Patterns = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionClassifyClassificationOriginEmail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionClassifyClassificationOriginEmail { Patterns = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionClassifyClassificationOriginEmail>(
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
        var model = new FunctionClassifyClassificationOriginEmail { Patterns = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionClassifyClassificationOriginEmail { };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionClassifyClassificationOriginEmail { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionClassifyClassificationOriginEmail
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
        var model = new FunctionClassifyClassificationOriginEmail
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionClassifyClassificationOriginEmail { Patterns = ["string"] };

        FunctionClassifyClassificationOriginEmail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionClassifyClassificationRegexTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionClassifyClassificationRegex { Patterns = ["string"] };

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
        var model = new FunctionClassifyClassificationRegex { Patterns = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionClassifyClassificationRegex>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionClassifyClassificationRegex { Patterns = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionClassifyClassificationRegex>(
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
        var model = new FunctionClassifyClassificationRegex { Patterns = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionClassifyClassificationRegex { };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionClassifyClassificationRegex { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionClassifyClassificationRegex
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
        var model = new FunctionClassifyClassificationRegex
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionClassifyClassificationRegex { Patterns = ["string"] };

        FunctionClassifyClassificationRegex copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionSendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
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

        ApiEnum<string, FunctionSendDestinationType> expectedDestinationType =
            FunctionSendDestinationType.Webhook;
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
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
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
        var deserialized = JsonSerializer.Deserialize<FunctionSend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
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
        var deserialized = JsonSerializer.Deserialize<FunctionSend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FunctionSendDestinationType> expectedDestinationType =
            FunctionSendDestinationType.Webhook;
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
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
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
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
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
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
            FunctionID = "functionID",
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
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
        var model = new FunctionSend
        {
            DestinationType = FunctionSendDestinationType.Webhook,
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

        FunctionSend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionSendDestinationTypeTest : TestBase
{
    [Theory]
    [InlineData(FunctionSendDestinationType.Webhook)]
    [InlineData(FunctionSendDestinationType.S3)]
    [InlineData(FunctionSendDestinationType.GoogleDrive)]
    public void Validation_Works(FunctionSendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionSendDestinationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionSendDestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionSendDestinationType.Webhook)]
    [InlineData(FunctionSendDestinationType.S3)]
    [InlineData(FunctionSendDestinationType.GoogleDrive)]
    public void SerializationRoundtrip_Works(FunctionSendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionSendDestinationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionSendDestinationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionSendDestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionSendDestinationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FunctionSplitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
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
        ApiEnum<string, FunctionSplitSplitType> expectedSplitType =
            FunctionSplitSplitType.PrintPage;
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
        string expectedDisplayName = "displayName";
        FunctionSplitPrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
        };
        FunctionSplitSemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
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
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
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
        var deserialized = JsonSerializer.Deserialize<FunctionSplit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
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
        var deserialized = JsonSerializer.Deserialize<FunctionSplit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, FunctionSplitSplitType> expectedSplitType =
            FunctionSplitSplitType.PrintPage;
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
        string expectedDisplayName = "displayName";
        FunctionSplitPrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
        };
        FunctionSplitSemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
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
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
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
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            PrintPageSplitConfig = null,
            SemanticPageSplitConfig = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
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
        var model = new FunctionSplit
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            SplitType = FunctionSplitSplitType.PrintPage,
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

        FunctionSplit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionSplitSplitTypeTest : TestBase
{
    [Theory]
    [InlineData(FunctionSplitSplitType.PrintPage)]
    [InlineData(FunctionSplitSplitType.SemanticPage)]
    public void Validation_Works(FunctionSplitSplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionSplitSplitType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionSplitSplitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionSplitSplitType.PrintPage)]
    [InlineData(FunctionSplitSplitType.SemanticPage)]
    public void SerializationRoundtrip_Works(FunctionSplitSplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionSplitSplitType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionSplitSplitType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionSplitSplitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionSplitSplitType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FunctionSplitPrintPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionSplitPrintPageSplitConfig { NextFunctionID = "nextFunctionID" };

        string expectedNextFunctionID = "nextFunctionID";

        Assert.Equal(expectedNextFunctionID, model.NextFunctionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionSplitPrintPageSplitConfig { NextFunctionID = "nextFunctionID" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionSplitPrintPageSplitConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionSplitPrintPageSplitConfig { NextFunctionID = "nextFunctionID" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionSplitPrintPageSplitConfig>(
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
        var model = new FunctionSplitPrintPageSplitConfig { NextFunctionID = "nextFunctionID" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionSplitPrintPageSplitConfig { };

        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionSplitPrintPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionSplitPrintPageSplitConfig
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
        var model = new FunctionSplitPrintPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            NextFunctionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionSplitPrintPageSplitConfig { NextFunctionID = "nextFunctionID" };

        FunctionSplitPrintPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionSplitSemanticPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionSplitSemanticPageSplitConfig
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
        var model = new FunctionSplitSemanticPageSplitConfig
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
        var deserialized = JsonSerializer.Deserialize<FunctionSplitSemanticPageSplitConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionSplitSemanticPageSplitConfig
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
        var deserialized = JsonSerializer.Deserialize<FunctionSplitSemanticPageSplitConfig>(
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
        var model = new FunctionSplitSemanticPageSplitConfig
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
        var model = new FunctionSplitSemanticPageSplitConfig { };

        Assert.Null(model.ItemClasses);
        Assert.False(model.RawData.ContainsKey("itemClasses"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionSplitSemanticPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionSplitSemanticPageSplitConfig
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
        var model = new FunctionSplitSemanticPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            ItemClasses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionSplitSemanticPageSplitConfig
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

        FunctionSplitSemanticPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionJoinTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
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
        ApiEnum<string, FunctionJoinJoinType> expectedJoinType = FunctionJoinJoinType.Standard;
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
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
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
        var deserialized = JsonSerializer.Deserialize<FunctionJoin>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
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
        var deserialized = JsonSerializer.Deserialize<FunctionJoin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, FunctionJoinJoinType> expectedJoinType = FunctionJoinJoinType.Standard;
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
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
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
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionJoin
        {
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            JoinType = FunctionJoinJoinType.Standard,
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

        FunctionJoin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionJoinJoinTypeTest : TestBase
{
    [Theory]
    [InlineData(FunctionJoinJoinType.Standard)]
    public void Validation_Works(FunctionJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionJoinJoinType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionJoinJoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionJoinJoinType.Standard)]
    public void SerializationRoundtrip_Works(FunctionJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionJoinJoinType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionJoinJoinType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionJoinJoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionJoinJoinType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FunctionPayloadShapingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionPayloadShaping
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
        var model = new FunctionPayloadShaping
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
        var deserialized = JsonSerializer.Deserialize<FunctionPayloadShaping>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionPayloadShaping
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
        var deserialized = JsonSerializer.Deserialize<FunctionPayloadShaping>(
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
        var model = new FunctionPayloadShaping
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
        var model = new FunctionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionPayloadShaping
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
        var model = new FunctionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionPayloadShaping
        {
            FunctionID = "functionID",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Audit = null,
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionPayloadShaping
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

        FunctionPayloadShaping copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionEnrichTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionEnrich
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
        var model = new FunctionEnrich
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
        var deserialized = JsonSerializer.Deserialize<FunctionEnrich>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionEnrich
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
        var deserialized = JsonSerializer.Deserialize<FunctionEnrich>(
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
        var model = new FunctionEnrich
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
        var model = new FunctionEnrich
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
        var model = new FunctionEnrich
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
        var model = new FunctionEnrich
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
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        Assert.Null(model.Audit);
        Assert.False(model.RawData.ContainsKey("audit"));
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
        var model = new FunctionEnrich
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
            DisplayName = null,
            Tags = null,
            UsedInWorkflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionEnrich
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

        FunctionEnrich copied = new(model);

        Assert.Equal(model, copied);
    }
}
