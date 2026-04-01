using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions.Versions;

namespace Bem.Tests.Models.Functions.Versions;

public class ListFunctionVersionsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListFunctionVersionsResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Transform()
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
        List<FunctionVersion> expectedVersions =
        [
            new Transform()
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
        var model = new ListFunctionVersionsResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Transform()
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
        var deserialized = JsonSerializer.Deserialize<ListFunctionVersionsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListFunctionVersionsResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Transform()
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
        var deserialized = JsonSerializer.Deserialize<ListFunctionVersionsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTotalCount = 0;
        List<FunctionVersion> expectedVersions =
        [
            new Transform()
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
        var model = new ListFunctionVersionsResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Transform()
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
        var model = new ListFunctionVersionsResponse { };

        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Versions);
        Assert.False(model.RawData.ContainsKey("versions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ListFunctionVersionsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ListFunctionVersionsResponse
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
        var model = new ListFunctionVersionsResponse
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
        var model = new ListFunctionVersionsResponse
        {
            TotalCount = 0,
            Versions =
            [
                new Transform()
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

        ListFunctionVersionsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
