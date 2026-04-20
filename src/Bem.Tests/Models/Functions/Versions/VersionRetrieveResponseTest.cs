using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions.Versions;

namespace Bem.Tests.Models.Functions.Versions;

public class VersionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionRetrieveResponse
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
        };

        FunctionVersion expectedFunction = new Transform()
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

        Assert.Equal(expectedFunction, model.Function);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VersionRetrieveResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionRetrieveResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FunctionVersion expectedFunction = new Transform()
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

        Assert.Equal(expectedFunction, deserialized.Function);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VersionRetrieveResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VersionRetrieveResponse
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
        };

        VersionRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
