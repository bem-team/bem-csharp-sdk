using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class ListFunctionsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListFunctionsResponse
        {
            Functions =
            [
                new FunctionTransform()
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
            ],
            TotalCount = 0,
        };

        List<Function> expectedFunctions =
        [
            new FunctionTransform()
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
        ];
        long expectedTotalCount = 0;

        Assert.NotNull(model.Functions);
        Assert.Equal(expectedFunctions.Count, model.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], model.Functions[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ListFunctionsResponse
        {
            Functions =
            [
                new FunctionTransform()
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
            ],
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListFunctionsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListFunctionsResponse
        {
            Functions =
            [
                new FunctionTransform()
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
            ],
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListFunctionsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Function> expectedFunctions =
        [
            new FunctionTransform()
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
        ];
        long expectedTotalCount = 0;

        Assert.NotNull(deserialized.Functions);
        Assert.Equal(expectedFunctions.Count, deserialized.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], deserialized.Functions[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ListFunctionsResponse
        {
            Functions =
            [
                new FunctionTransform()
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
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ListFunctionsResponse { };

        Assert.Null(model.Functions);
        Assert.False(model.RawData.ContainsKey("functions"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ListFunctionsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ListFunctionsResponse
        {
            // Null should be interpreted as omitted for these properties
            Functions = null,
            TotalCount = null,
        };

        Assert.Null(model.Functions);
        Assert.False(model.RawData.ContainsKey("functions"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ListFunctionsResponse
        {
            // Null should be interpreted as omitted for these properties
            Functions = null,
            TotalCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ListFunctionsResponse
        {
            Functions =
            [
                new FunctionTransform()
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
            ],
            TotalCount = 0,
        };

        ListFunctionsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
