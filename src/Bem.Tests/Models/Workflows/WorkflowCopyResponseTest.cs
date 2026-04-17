using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowCopyResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowCopyResponse
        {
            CopiedFunctions =
            [
                new()
                {
                    SourceFunctionID = "sourceFunctionID",
                    SourceFunctionName = "sourceFunctionName",
                    SourceVersionNum = 1,
                    TargetFunctionID = "targetFunctionID",
                    TargetFunctionName = "targetFunctionName",
                    TargetVersionNum = 1,
                },
            ],
            Environment = "environment",
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Edges =
                [
                    new()
                    {
                        DestinationNodeName = "destinationNodeName",
                        SourceNodeName = "sourceNodeName",
                        DestinationName = "destinationName",
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

        List<CopiedFunction> expectedCopiedFunctions =
        [
            new()
            {
                SourceFunctionID = "sourceFunctionID",
                SourceFunctionName = "sourceFunctionName",
                SourceVersionNum = 1,
                TargetFunctionID = "targetFunctionID",
                TargetFunctionName = "targetFunctionName",
                TargetVersionNum = 1,
            },
        ];
        string expectedEnvironment = "environment";
        string expectedError = "error";
        Workflow expectedWorkflow = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Edges =
            [
                new()
                {
                    DestinationNodeName = "destinationNodeName",
                    SourceNodeName = "sourceNodeName",
                    DestinationName = "destinationName",
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

        Assert.NotNull(model.CopiedFunctions);
        Assert.Equal(expectedCopiedFunctions.Count, model.CopiedFunctions.Count);
        for (int i = 0; i < expectedCopiedFunctions.Count; i++)
        {
            Assert.Equal(expectedCopiedFunctions[i], model.CopiedFunctions[i]);
        }
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedWorkflow, model.Workflow);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowCopyResponse
        {
            CopiedFunctions =
            [
                new()
                {
                    SourceFunctionID = "sourceFunctionID",
                    SourceFunctionName = "sourceFunctionName",
                    SourceVersionNum = 1,
                    TargetFunctionID = "targetFunctionID",
                    TargetFunctionName = "targetFunctionName",
                    TargetVersionNum = 1,
                },
            ],
            Environment = "environment",
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Edges =
                [
                    new()
                    {
                        DestinationNodeName = "destinationNodeName",
                        SourceNodeName = "sourceNodeName",
                        DestinationName = "destinationName",
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
        var deserialized = JsonSerializer.Deserialize<WorkflowCopyResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowCopyResponse
        {
            CopiedFunctions =
            [
                new()
                {
                    SourceFunctionID = "sourceFunctionID",
                    SourceFunctionName = "sourceFunctionName",
                    SourceVersionNum = 1,
                    TargetFunctionID = "targetFunctionID",
                    TargetFunctionName = "targetFunctionName",
                    TargetVersionNum = 1,
                },
            ],
            Environment = "environment",
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Edges =
                [
                    new()
                    {
                        DestinationNodeName = "destinationNodeName",
                        SourceNodeName = "sourceNodeName",
                        DestinationName = "destinationName",
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
        var deserialized = JsonSerializer.Deserialize<WorkflowCopyResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CopiedFunction> expectedCopiedFunctions =
        [
            new()
            {
                SourceFunctionID = "sourceFunctionID",
                SourceFunctionName = "sourceFunctionName",
                SourceVersionNum = 1,
                TargetFunctionID = "targetFunctionID",
                TargetFunctionName = "targetFunctionName",
                TargetVersionNum = 1,
            },
        ];
        string expectedEnvironment = "environment";
        string expectedError = "error";
        Workflow expectedWorkflow = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Edges =
            [
                new()
                {
                    DestinationNodeName = "destinationNodeName",
                    SourceNodeName = "sourceNodeName",
                    DestinationName = "destinationName",
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

        Assert.NotNull(deserialized.CopiedFunctions);
        Assert.Equal(expectedCopiedFunctions.Count, deserialized.CopiedFunctions.Count);
        for (int i = 0; i < expectedCopiedFunctions.Count; i++)
        {
            Assert.Equal(expectedCopiedFunctions[i], deserialized.CopiedFunctions[i]);
        }
        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedWorkflow, deserialized.Workflow);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowCopyResponse
        {
            CopiedFunctions =
            [
                new()
                {
                    SourceFunctionID = "sourceFunctionID",
                    SourceFunctionName = "sourceFunctionName",
                    SourceVersionNum = 1,
                    TargetFunctionID = "targetFunctionID",
                    TargetFunctionName = "targetFunctionName",
                    TargetVersionNum = 1,
                },
            ],
            Environment = "environment",
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Edges =
                [
                    new()
                    {
                        DestinationNodeName = "destinationNodeName",
                        SourceNodeName = "sourceNodeName",
                        DestinationName = "destinationName",
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
        var model = new WorkflowCopyResponse { };

        Assert.Null(model.CopiedFunctions);
        Assert.False(model.RawData.ContainsKey("copiedFunctions"));
        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Workflow);
        Assert.False(model.RawData.ContainsKey("workflow"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowCopyResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowCopyResponse
        {
            // Null should be interpreted as omitted for these properties
            CopiedFunctions = null,
            Environment = null,
            Error = null,
            Workflow = null,
        };

        Assert.Null(model.CopiedFunctions);
        Assert.False(model.RawData.ContainsKey("copiedFunctions"));
        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Workflow);
        Assert.False(model.RawData.ContainsKey("workflow"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowCopyResponse
        {
            // Null should be interpreted as omitted for these properties
            CopiedFunctions = null,
            Environment = null,
            Error = null,
            Workflow = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowCopyResponse
        {
            CopiedFunctions =
            [
                new()
                {
                    SourceFunctionID = "sourceFunctionID",
                    SourceFunctionName = "sourceFunctionName",
                    SourceVersionNum = 1,
                    TargetFunctionID = "targetFunctionID",
                    TargetFunctionName = "targetFunctionName",
                    TargetVersionNum = 1,
                },
            ],
            Environment = "environment",
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Edges =
                [
                    new()
                    {
                        DestinationNodeName = "destinationNodeName",
                        SourceNodeName = "sourceNodeName",
                        DestinationName = "destinationName",
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

        WorkflowCopyResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CopiedFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CopiedFunction
        {
            SourceFunctionID = "sourceFunctionID",
            SourceFunctionName = "sourceFunctionName",
            SourceVersionNum = 1,
            TargetFunctionID = "targetFunctionID",
            TargetFunctionName = "targetFunctionName",
            TargetVersionNum = 1,
        };

        string expectedSourceFunctionID = "sourceFunctionID";
        string expectedSourceFunctionName = "sourceFunctionName";
        long expectedSourceVersionNum = 1;
        string expectedTargetFunctionID = "targetFunctionID";
        string expectedTargetFunctionName = "targetFunctionName";
        long expectedTargetVersionNum = 1;

        Assert.Equal(expectedSourceFunctionID, model.SourceFunctionID);
        Assert.Equal(expectedSourceFunctionName, model.SourceFunctionName);
        Assert.Equal(expectedSourceVersionNum, model.SourceVersionNum);
        Assert.Equal(expectedTargetFunctionID, model.TargetFunctionID);
        Assert.Equal(expectedTargetFunctionName, model.TargetFunctionName);
        Assert.Equal(expectedTargetVersionNum, model.TargetVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CopiedFunction
        {
            SourceFunctionID = "sourceFunctionID",
            SourceFunctionName = "sourceFunctionName",
            SourceVersionNum = 1,
            TargetFunctionID = "targetFunctionID",
            TargetFunctionName = "targetFunctionName",
            TargetVersionNum = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CopiedFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CopiedFunction
        {
            SourceFunctionID = "sourceFunctionID",
            SourceFunctionName = "sourceFunctionName",
            SourceVersionNum = 1,
            TargetFunctionID = "targetFunctionID",
            TargetFunctionName = "targetFunctionName",
            TargetVersionNum = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CopiedFunction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSourceFunctionID = "sourceFunctionID";
        string expectedSourceFunctionName = "sourceFunctionName";
        long expectedSourceVersionNum = 1;
        string expectedTargetFunctionID = "targetFunctionID";
        string expectedTargetFunctionName = "targetFunctionName";
        long expectedTargetVersionNum = 1;

        Assert.Equal(expectedSourceFunctionID, deserialized.SourceFunctionID);
        Assert.Equal(expectedSourceFunctionName, deserialized.SourceFunctionName);
        Assert.Equal(expectedSourceVersionNum, deserialized.SourceVersionNum);
        Assert.Equal(expectedTargetFunctionID, deserialized.TargetFunctionID);
        Assert.Equal(expectedTargetFunctionName, deserialized.TargetFunctionName);
        Assert.Equal(expectedTargetVersionNum, deserialized.TargetVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CopiedFunction
        {
            SourceFunctionID = "sourceFunctionID",
            SourceFunctionName = "sourceFunctionName",
            SourceVersionNum = 1,
            TargetFunctionID = "targetFunctionID",
            TargetFunctionName = "targetFunctionName",
            TargetVersionNum = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CopiedFunction
        {
            SourceFunctionID = "sourceFunctionID",
            SourceFunctionName = "sourceFunctionName",
            SourceVersionNum = 1,
            TargetFunctionID = "targetFunctionID",
            TargetFunctionName = "targetFunctionName",
            TargetVersionNum = 1,
        };

        CopiedFunction copied = new(model);

        Assert.Equal(model, copied);
    }
}
