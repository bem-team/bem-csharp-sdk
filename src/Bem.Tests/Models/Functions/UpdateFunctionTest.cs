using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class UpdateFunctionTest : TestBase
{
    [Fact]
    public void ExtractValidationWorks()
    {
        UpdateFunction value = new UpdateFunctionExtract()
        {
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void ClassifyValidationWorks()
    {
        UpdateFunction value = new UpdateFunctionClassify()
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
            DisplayName = "displayName",
            FunctionName = "functionName",
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void SendValidationWorks()
    {
        UpdateFunction value = new UpdateFunctionSend()
        {
            DestinationType = UpdateFunctionSendDestinationType.Webhook,
            DisplayName = "displayName",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };
        value.Validate();
    }

    [Fact]
    public void SplitValidationWorks()
    {
        UpdateFunction value = new UpdateFunctionSplit()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            PrintPageSplitConfig = new()
            {
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
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
            SplitType = UpdateFunctionSplitSplitType.PrintPage,
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void JoinValidationWorks()
    {
        UpdateFunction value = new UpdateFunctionJoin()
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = UpdateFunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void PayloadShapingValidationWorks()
    {
        UpdateFunction value = new UpdateFunctionPayloadShaping()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void EnrichValidationWorks()
    {
        UpdateFunction value = new UpdateFunctionEnrich()
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
        };
        value.Validate();
    }

    [Fact]
    public void ParseValidationWorks()
    {
        UpdateFunction value = new UpdateFunctionParse()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ParseConfig = new()
            {
                ExtractEntities = true,
                LinkAcrossDocuments = true,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void ExtractSerializationRoundtripWorks()
    {
        UpdateFunction value = new UpdateFunctionExtract()
        {
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClassifySerializationRoundtripWorks()
    {
        UpdateFunction value = new UpdateFunctionClassify()
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
            DisplayName = "displayName",
            FunctionName = "functionName",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        UpdateFunction value = new UpdateFunctionSend()
        {
            DestinationType = UpdateFunctionSendDestinationType.Webhook,
            DisplayName = "displayName",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitSerializationRoundtripWorks()
    {
        UpdateFunction value = new UpdateFunctionSplit()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            PrintPageSplitConfig = new()
            {
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
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
            SplitType = UpdateFunctionSplitSplitType.PrintPage,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        UpdateFunction value = new UpdateFunctionJoin()
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = UpdateFunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PayloadShapingSerializationRoundtripWorks()
    {
        UpdateFunction value = new UpdateFunctionPayloadShaping()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        UpdateFunction value = new UpdateFunctionEnrich()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ParseSerializationRoundtripWorks()
    {
        UpdateFunction value = new UpdateFunctionParse()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ParseConfig = new()
            {
                ExtractEntities = true,
                LinkAcrossDocuments = true,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UpdateFunctionExtractTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionExtract
        {
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("extract");
        string expectedDisplayName = "displayName";
        bool expectedEnableBoundingBoxes = true;
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedPreCount = true;
        bool expectedTabularChunkingEnabled = true;
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEnableBoundingBoxes, model.EnableBoundingBoxes);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.NotNull(model.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
        Assert.Equal(expectedPreCount, model.PreCount);
        Assert.Equal(expectedTabularChunkingEnabled, model.TabularChunkingEnabled);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionExtract
        {
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionExtract>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionExtract
        {
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionExtract>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("extract");
        string expectedDisplayName = "displayName";
        bool expectedEnableBoundingBoxes = true;
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedPreCount = true;
        bool expectedTabularChunkingEnabled = true;
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEnableBoundingBoxes, deserialized.EnableBoundingBoxes);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.NotNull(deserialized.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
        Assert.Equal(expectedPreCount, deserialized.PreCount);
        Assert.Equal(expectedTabularChunkingEnabled, deserialized.TabularChunkingEnabled);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionExtract
        {
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionExtract { };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.EnableBoundingBoxes);
        Assert.False(model.RawData.ContainsKey("enableBoundingBoxes"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.PreCount);
        Assert.False(model.RawData.ContainsKey("preCount"));
        Assert.Null(model.TabularChunkingEnabled);
        Assert.False(model.RawData.ContainsKey("tabularChunkingEnabled"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionExtract { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionExtract
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            EnableBoundingBoxes = null,
            FunctionName = null,
            OutputSchema = null,
            OutputSchemaName = null,
            PreCount = null,
            TabularChunkingEnabled = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.EnableBoundingBoxes);
        Assert.False(model.RawData.ContainsKey("enableBoundingBoxes"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.PreCount);
        Assert.False(model.RawData.ContainsKey("preCount"));
        Assert.Null(model.TabularChunkingEnabled);
        Assert.False(model.RawData.ContainsKey("tabularChunkingEnabled"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionExtract
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            EnableBoundingBoxes = null,
            FunctionName = null,
            OutputSchema = null,
            OutputSchemaName = null,
            PreCount = null,
            TabularChunkingEnabled = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionExtract
        {
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        UpdateFunctionExtract copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionClassifyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionClassify
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
            DisplayName = "displayName",
            FunctionName = "functionName",
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("classify");
        List<ClassificationListItem> expectedClassifications =
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
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Classifications);
        Assert.Equal(expectedClassifications.Count, model.Classifications.Count);
        for (int i = 0; i < expectedClassifications.Count; i++)
        {
            Assert.Equal(expectedClassifications[i], model.Classifications[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionClassify
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
            DisplayName = "displayName",
            FunctionName = "functionName",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionClassify>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionClassify
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
            DisplayName = "displayName",
            FunctionName = "functionName",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionClassify>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("classify");
        List<ClassificationListItem> expectedClassifications =
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
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Classifications);
        Assert.Equal(expectedClassifications.Count, deserialized.Classifications.Count);
        for (int i = 0; i < expectedClassifications.Count; i++)
        {
            Assert.Equal(expectedClassifications[i], deserialized.Classifications[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionClassify
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
            DisplayName = "displayName",
            FunctionName = "functionName",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionClassify { };

        Assert.Null(model.Classifications);
        Assert.False(model.RawData.ContainsKey("classifications"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionClassify { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionClassify
        {
            // Null should be interpreted as omitted for these properties
            Classifications = null,
            Description = null,
            DisplayName = null,
            FunctionName = null,
            Tags = null,
        };

        Assert.Null(model.Classifications);
        Assert.False(model.RawData.ContainsKey("classifications"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionClassify
        {
            // Null should be interpreted as omitted for these properties
            Classifications = null,
            Description = null,
            DisplayName = null,
            FunctionName = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionClassify
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
            DisplayName = "displayName",
            FunctionName = "functionName",
            Tags = ["string"],
        };

        UpdateFunctionClassify copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionSendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionSend
        {
            DestinationType = UpdateFunctionSendDestinationType.Webhook,
            DisplayName = "displayName",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("send");
        ApiEnum<string, UpdateFunctionSendDestinationType> expectedDestinationType =
            UpdateFunctionSendDestinationType.Webhook;
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        string expectedGoogleDriveFolderID = "googleDriveFolderId";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3Prefix = "s3Prefix";
        List<string> expectedTags = ["string"];
        bool expectedWebhookSigningEnabled = true;
        string expectedWebhookUrl = "webhookUrl";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDestinationType, model.DestinationType);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedGoogleDriveFolderID, model.GoogleDriveFolderID);
        Assert.Equal(expectedS3Bucket, model.S3Bucket);
        Assert.Equal(expectedS3Prefix, model.S3Prefix);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedWebhookSigningEnabled, model.WebhookSigningEnabled);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionSend
        {
            DestinationType = UpdateFunctionSendDestinationType.Webhook,
            DisplayName = "displayName",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionSend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionSend
        {
            DestinationType = UpdateFunctionSendDestinationType.Webhook,
            DisplayName = "displayName",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionSend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("send");
        ApiEnum<string, UpdateFunctionSendDestinationType> expectedDestinationType =
            UpdateFunctionSendDestinationType.Webhook;
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        string expectedGoogleDriveFolderID = "googleDriveFolderId";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3Prefix = "s3Prefix";
        List<string> expectedTags = ["string"];
        bool expectedWebhookSigningEnabled = true;
        string expectedWebhookUrl = "webhookUrl";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDestinationType, deserialized.DestinationType);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedGoogleDriveFolderID, deserialized.GoogleDriveFolderID);
        Assert.Equal(expectedS3Bucket, deserialized.S3Bucket);
        Assert.Equal(expectedS3Prefix, deserialized.S3Prefix);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedWebhookSigningEnabled, deserialized.WebhookSigningEnabled);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionSend
        {
            DestinationType = UpdateFunctionSendDestinationType.Webhook,
            DisplayName = "displayName",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionSend { };

        Assert.Null(model.DestinationType);
        Assert.False(model.RawData.ContainsKey("destinationType"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.GoogleDriveFolderID);
        Assert.False(model.RawData.ContainsKey("googleDriveFolderId"));
        Assert.Null(model.S3Bucket);
        Assert.False(model.RawData.ContainsKey("s3Bucket"));
        Assert.Null(model.S3Prefix);
        Assert.False(model.RawData.ContainsKey("s3Prefix"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.WebhookSigningEnabled);
        Assert.False(model.RawData.ContainsKey("webhookSigningEnabled"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionSend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionSend
        {
            // Null should be interpreted as omitted for these properties
            DestinationType = null,
            DisplayName = null,
            FunctionName = null,
            GoogleDriveFolderID = null,
            S3Bucket = null,
            S3Prefix = null,
            Tags = null,
            WebhookSigningEnabled = null,
            WebhookUrl = null,
        };

        Assert.Null(model.DestinationType);
        Assert.False(model.RawData.ContainsKey("destinationType"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.GoogleDriveFolderID);
        Assert.False(model.RawData.ContainsKey("googleDriveFolderId"));
        Assert.Null(model.S3Bucket);
        Assert.False(model.RawData.ContainsKey("s3Bucket"));
        Assert.Null(model.S3Prefix);
        Assert.False(model.RawData.ContainsKey("s3Prefix"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.WebhookSigningEnabled);
        Assert.False(model.RawData.ContainsKey("webhookSigningEnabled"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionSend
        {
            // Null should be interpreted as omitted for these properties
            DestinationType = null,
            DisplayName = null,
            FunctionName = null,
            GoogleDriveFolderID = null,
            S3Bucket = null,
            S3Prefix = null,
            Tags = null,
            WebhookSigningEnabled = null,
            WebhookUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionSend
        {
            DestinationType = UpdateFunctionSendDestinationType.Webhook,
            DisplayName = "displayName",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        UpdateFunctionSend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionSendDestinationTypeTest : TestBase
{
    [Theory]
    [InlineData(UpdateFunctionSendDestinationType.Webhook)]
    [InlineData(UpdateFunctionSendDestinationType.S3)]
    [InlineData(UpdateFunctionSendDestinationType.GoogleDrive)]
    public void Validation_Works(UpdateFunctionSendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateFunctionSendDestinationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateFunctionSendDestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UpdateFunctionSendDestinationType.Webhook)]
    [InlineData(UpdateFunctionSendDestinationType.S3)]
    [InlineData(UpdateFunctionSendDestinationType.GoogleDrive)]
    public void SerializationRoundtrip_Works(UpdateFunctionSendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateFunctionSendDestinationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateFunctionSendDestinationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateFunctionSendDestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateFunctionSendDestinationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UpdateFunctionSplitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionSplit
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            PrintPageSplitConfig = new()
            {
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
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
            SplitType = UpdateFunctionSplitSplitType.PrintPage,
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("split");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        UpdateFunctionSplitPrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };
        UpdateFunctionSplitSemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
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
        ApiEnum<string, UpdateFunctionSplitSplitType> expectedSplitType =
            UpdateFunctionSplitSplitType.PrintPage;
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedPrintPageSplitConfig, model.PrintPageSplitConfig);
        Assert.Equal(expectedSemanticPageSplitConfig, model.SemanticPageSplitConfig);
        Assert.Equal(expectedSplitType, model.SplitType);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionSplit
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            PrintPageSplitConfig = new()
            {
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
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
            SplitType = UpdateFunctionSplitSplitType.PrintPage,
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionSplit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionSplit
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            PrintPageSplitConfig = new()
            {
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
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
            SplitType = UpdateFunctionSplitSplitType.PrintPage,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionSplit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("split");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        UpdateFunctionSplitPrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };
        UpdateFunctionSplitSemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
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
        ApiEnum<string, UpdateFunctionSplitSplitType> expectedSplitType =
            UpdateFunctionSplitSplitType.PrintPage;
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedPrintPageSplitConfig, deserialized.PrintPageSplitConfig);
        Assert.Equal(expectedSemanticPageSplitConfig, deserialized.SemanticPageSplitConfig);
        Assert.Equal(expectedSplitType, deserialized.SplitType);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionSplit
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            PrintPageSplitConfig = new()
            {
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
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
            SplitType = UpdateFunctionSplitSplitType.PrintPage,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionSplit { };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.PrintPageSplitConfig);
        Assert.False(model.RawData.ContainsKey("printPageSplitConfig"));
        Assert.Null(model.SemanticPageSplitConfig);
        Assert.False(model.RawData.ContainsKey("semanticPageSplitConfig"));
        Assert.Null(model.SplitType);
        Assert.False(model.RawData.ContainsKey("splitType"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionSplit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionSplit
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            FunctionName = null,
            PrintPageSplitConfig = null,
            SemanticPageSplitConfig = null,
            SplitType = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.PrintPageSplitConfig);
        Assert.False(model.RawData.ContainsKey("printPageSplitConfig"));
        Assert.Null(model.SemanticPageSplitConfig);
        Assert.False(model.RawData.ContainsKey("semanticPageSplitConfig"));
        Assert.Null(model.SplitType);
        Assert.False(model.RawData.ContainsKey("splitType"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionSplit
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            FunctionName = null,
            PrintPageSplitConfig = null,
            SemanticPageSplitConfig = null,
            SplitType = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionSplit
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            PrintPageSplitConfig = new()
            {
                NextFunctionID = "nextFunctionID",
                NextFunctionName = "nextFunctionName",
            },
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
            SplitType = UpdateFunctionSplitSplitType.PrintPage,
            Tags = ["string"],
        };

        UpdateFunctionSplit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionSplitPrintPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string expectedNextFunctionID = "nextFunctionID";
        string expectedNextFunctionName = "nextFunctionName";

        Assert.Equal(expectedNextFunctionID, model.NextFunctionID);
        Assert.Equal(expectedNextFunctionName, model.NextFunctionName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionSplitPrintPageSplitConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionSplitPrintPageSplitConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNextFunctionID = "nextFunctionID";
        string expectedNextFunctionName = "nextFunctionName";

        Assert.Equal(expectedNextFunctionID, deserialized.NextFunctionID);
        Assert.Equal(expectedNextFunctionName, deserialized.NextFunctionName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig { };

        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
        Assert.Null(model.NextFunctionName);
        Assert.False(model.RawData.ContainsKey("nextFunctionName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            NextFunctionID = null,
            NextFunctionName = null,
        };

        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
        Assert.Null(model.NextFunctionName);
        Assert.False(model.RawData.ContainsKey("nextFunctionName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            NextFunctionID = null,
            NextFunctionName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionSplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        UpdateFunctionSplitPrintPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionSplitSemanticPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionSplitSemanticPageSplitConfig
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
        var model = new UpdateFunctionSplitSemanticPageSplitConfig
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
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionSplitSemanticPageSplitConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionSplitSemanticPageSplitConfig
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
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionSplitSemanticPageSplitConfig>(
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
        var model = new UpdateFunctionSplitSemanticPageSplitConfig
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
        var model = new UpdateFunctionSplitSemanticPageSplitConfig { };

        Assert.Null(model.ItemClasses);
        Assert.False(model.RawData.ContainsKey("itemClasses"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionSplitSemanticPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionSplitSemanticPageSplitConfig
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
        var model = new UpdateFunctionSplitSemanticPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            ItemClasses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionSplitSemanticPageSplitConfig
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

        UpdateFunctionSplitSemanticPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionSplitSplitTypeTest : TestBase
{
    [Theory]
    [InlineData(UpdateFunctionSplitSplitType.PrintPage)]
    [InlineData(UpdateFunctionSplitSplitType.SemanticPage)]
    public void Validation_Works(UpdateFunctionSplitSplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateFunctionSplitSplitType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateFunctionSplitSplitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UpdateFunctionSplitSplitType.PrintPage)]
    [InlineData(UpdateFunctionSplitSplitType.SemanticPage)]
    public void SerializationRoundtrip_Works(UpdateFunctionSplitSplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateFunctionSplitSplitType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateFunctionSplitSplitType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateFunctionSplitSplitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UpdateFunctionSplitSplitType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UpdateFunctionJoinTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = UpdateFunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("join");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        ApiEnum<string, UpdateFunctionJoinJoinType> expectedJoinType =
            UpdateFunctionJoinJoinType.Standard;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedJoinType, model.JoinType);
        Assert.NotNull(model.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = UpdateFunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionJoin>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = UpdateFunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionJoin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("join");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        ApiEnum<string, UpdateFunctionJoinJoinType> expectedJoinType =
            UpdateFunctionJoinJoinType.Standard;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedJoinType, deserialized.JoinType);
        Assert.NotNull(deserialized.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = UpdateFunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionJoin { };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.JoinType);
        Assert.False(model.RawData.ContainsKey("joinType"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionJoin { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionJoin
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            DisplayName = null,
            FunctionName = null,
            JoinType = null,
            OutputSchema = null,
            OutputSchemaName = null,
            Tags = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.JoinType);
        Assert.False(model.RawData.ContainsKey("joinType"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionJoin
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            DisplayName = null,
            FunctionName = null,
            JoinType = null,
            OutputSchema = null,
            OutputSchemaName = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = UpdateFunctionJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        UpdateFunctionJoin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionJoinJoinTypeTest : TestBase
{
    [Theory]
    [InlineData(UpdateFunctionJoinJoinType.Standard)]
    public void Validation_Works(UpdateFunctionJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateFunctionJoinJoinType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateFunctionJoinJoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UpdateFunctionJoinJoinType.Standard)]
    public void SerializationRoundtrip_Works(UpdateFunctionJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateFunctionJoinJoinType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UpdateFunctionJoinJoinType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateFunctionJoinJoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UpdateFunctionJoinJoinType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UpdateFunctionPayloadShapingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionPayloadShaping
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("payload_shaping");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        string expectedShapingSchema = "shapingSchema";
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedShapingSchema, model.ShapingSchema);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionPayloadShaping
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionPayloadShaping>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionPayloadShaping
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionPayloadShaping>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("payload_shaping");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        string expectedShapingSchema = "shapingSchema";
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedShapingSchema, deserialized.ShapingSchema);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionPayloadShaping
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionPayloadShaping { };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.ShapingSchema);
        Assert.False(model.RawData.ContainsKey("shapingSchema"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionPayloadShaping { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionPayloadShaping
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            FunctionName = null,
            ShapingSchema = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.ShapingSchema);
        Assert.False(model.RawData.ContainsKey("shapingSchema"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionPayloadShaping
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            FunctionName = null,
            ShapingSchema = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionPayloadShaping
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        UpdateFunctionPayloadShaping copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionEnrichTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionEnrich
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
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enrich");
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

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedConfig, model.Config);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionEnrich
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionEnrich>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionEnrich
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionEnrich>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enrich");
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

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedConfig, deserialized.Config);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionEnrich
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionEnrich { };

        Assert.Null(model.Config);
        Assert.False(model.RawData.ContainsKey("config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionEnrich { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionEnrich
        {
            // Null should be interpreted as omitted for these properties
            Config = null,
        };

        Assert.Null(model.Config);
        Assert.False(model.RawData.ContainsKey("config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionEnrich
        {
            // Null should be interpreted as omitted for these properties
            Config = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionEnrich
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
        };

        UpdateFunctionEnrich copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionParseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionParse
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ParseConfig = new()
            {
                ExtractEntities = true,
                LinkAcrossDocuments = true,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("parse");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        UpdateFunctionParseParseConfig expectedParseConfig = new()
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedParseConfig, model.ParseConfig);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionParse
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ParseConfig = new()
            {
                ExtractEntities = true,
                LinkAcrossDocuments = true,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionParse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionParse
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ParseConfig = new()
            {
                ExtractEntities = true,
                LinkAcrossDocuments = true,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionParse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("parse");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        UpdateFunctionParseParseConfig expectedParseConfig = new()
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedParseConfig, deserialized.ParseConfig);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionParse
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ParseConfig = new()
            {
                ExtractEntities = true,
                LinkAcrossDocuments = true,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionParse { };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.ParseConfig);
        Assert.False(model.RawData.ContainsKey("parseConfig"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionParse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionParse
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            FunctionName = null,
            ParseConfig = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.ParseConfig);
        Assert.False(model.RawData.ContainsKey("parseConfig"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionParse
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            FunctionName = null,
            ParseConfig = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionParse
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ParseConfig = new()
            {
                ExtractEntities = true,
                LinkAcrossDocuments = true,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Tags = ["string"],
        };

        UpdateFunctionParse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateFunctionParseParseConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateFunctionParseParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        bool expectedExtractEntities = true;
        bool expectedLinkAcrossDocuments = true;
        JsonElement expectedSchema = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedExtractEntities, model.ExtractEntities);
        Assert.Equal(expectedLinkAcrossDocuments, model.LinkAcrossDocuments);
        Assert.NotNull(model.Schema);
        Assert.True(JsonElement.DeepEquals(expectedSchema, model.Schema.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateFunctionParseParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionParseParseConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateFunctionParseParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateFunctionParseParseConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedExtractEntities = true;
        bool expectedLinkAcrossDocuments = true;
        JsonElement expectedSchema = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedExtractEntities, deserialized.ExtractEntities);
        Assert.Equal(expectedLinkAcrossDocuments, deserialized.LinkAcrossDocuments);
        Assert.NotNull(deserialized.Schema);
        Assert.True(JsonElement.DeepEquals(expectedSchema, deserialized.Schema.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateFunctionParseParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateFunctionParseParseConfig { };

        Assert.Null(model.ExtractEntities);
        Assert.False(model.RawData.ContainsKey("extractEntities"));
        Assert.Null(model.LinkAcrossDocuments);
        Assert.False(model.RawData.ContainsKey("linkAcrossDocuments"));
        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateFunctionParseParseConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateFunctionParseParseConfig
        {
            // Null should be interpreted as omitted for these properties
            ExtractEntities = null,
            LinkAcrossDocuments = null,
            Schema = null,
        };

        Assert.Null(model.ExtractEntities);
        Assert.False(model.RawData.ContainsKey("extractEntities"));
        Assert.Null(model.LinkAcrossDocuments);
        Assert.False(model.RawData.ContainsKey("linkAcrossDocuments"));
        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateFunctionParseParseConfig
        {
            // Null should be interpreted as omitted for these properties
            ExtractEntities = null,
            LinkAcrossDocuments = null,
            Schema = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateFunctionParseParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        UpdateFunctionParseParseConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
