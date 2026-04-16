using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class CreateFunctionTest : TestBase
{
    [Fact]
    public void TransformValidationWorks()
    {
        CreateFunction value = new Transform()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void ExtractValidationWorks()
    {
        CreateFunction value = new Extract()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void AnalyzeValidationWorks()
    {
        CreateFunction value = new Analyze()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void RouteValidationWorks()
    {
        CreateFunction value = new Route()
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            Routes =
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
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void SendValidationWorks()
    {
        CreateFunction value = new Send()
        {
            FunctionName = "functionName",
            DestinationType = DestinationType.Webhook,
            DisplayName = "displayName",
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
        CreateFunction value = new Split()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
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
            SplitType = SplitType.PrintPage,
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void JoinValidationWorks()
    {
        CreateFunction value = new Join()
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            JoinType = JoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void PayloadShapingValidationWorks()
    {
        CreateFunction value = new PayloadShaping()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void EnrichValidationWorks()
    {
        CreateFunction value = new Enrich()
        {
            FunctionName = "functionName",
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
            DisplayName = "displayName",
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void TransformSerializationRoundtripWorks()
    {
        CreateFunction value = new Transform()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractSerializationRoundtripWorks()
    {
        CreateFunction value = new Extract()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnalyzeSerializationRoundtripWorks()
    {
        CreateFunction value = new Analyze()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RouteSerializationRoundtripWorks()
    {
        CreateFunction value = new Route()
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            Routes =
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
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        CreateFunction value = new Send()
        {
            FunctionName = "functionName",
            DestinationType = DestinationType.Webhook,
            DisplayName = "displayName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitSerializationRoundtripWorks()
    {
        CreateFunction value = new Split()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
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
            SplitType = SplitType.PrintPage,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        CreateFunction value = new Join()
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            JoinType = JoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PayloadShapingSerializationRoundtripWorks()
    {
        CreateFunction value = new PayloadShaping()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        CreateFunction value = new Enrich()
        {
            FunctionName = "functionName",
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
            DisplayName = "displayName",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateFunction>(
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
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("transform");
        string expectedDisplayName = "displayName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
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
        var model = new Transform
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
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
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transform>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("transform");
        string expectedDisplayName = "displayName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
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
        var model = new Transform
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Transform { FunctionName = "functionName" };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.TabularChunkingEnabled);
        Assert.False(model.RawData.ContainsKey("tabularChunkingEnabled"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transform { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Transform
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            OutputSchema = null,
            OutputSchemaName = null,
            TabularChunkingEnabled = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.TabularChunkingEnabled);
        Assert.False(model.RawData.ContainsKey("tabularChunkingEnabled"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transform
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            OutputSchema = null,
            OutputSchemaName = null,
            TabularChunkingEnabled = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Transform
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        Transform copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Extract
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("extract");
        string expectedDisplayName = "displayName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
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
        var model = new Extract
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Extract>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Extract
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Extract>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("extract");
        string expectedDisplayName = "displayName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
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
        var model = new Extract
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Extract { FunctionName = "functionName" };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.TabularChunkingEnabled);
        Assert.False(model.RawData.ContainsKey("tabularChunkingEnabled"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Extract { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Extract
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            OutputSchema = null,
            OutputSchemaName = null,
            TabularChunkingEnabled = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.TabularChunkingEnabled);
        Assert.False(model.RawData.ContainsKey("tabularChunkingEnabled"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Extract
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            OutputSchema = null,
            OutputSchemaName = null,
            TabularChunkingEnabled = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Extract
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        Extract copied = new(model);

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
            FunctionName = "functionName",
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("analyze");
        string expectedDisplayName = "displayName";
        bool expectedEnableBoundingBoxes = true;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedPreCount = true;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEnableBoundingBoxes, model.EnableBoundingBoxes);
        Assert.NotNull(model.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, model.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, model.OutputSchemaName);
        Assert.Equal(expectedPreCount, model.PreCount);
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
        var model = new Analyze
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            Tags = ["string"],
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
            FunctionName = "functionName",
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Analyze>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("analyze");
        string expectedDisplayName = "displayName";
        bool expectedEnableBoundingBoxes = true;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedPreCount = true;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEnableBoundingBoxes, deserialized.EnableBoundingBoxes);
        Assert.NotNull(deserialized.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, deserialized.OutputSchema.Value));
        Assert.Equal(expectedOutputSchemaName, deserialized.OutputSchemaName);
        Assert.Equal(expectedPreCount, deserialized.PreCount);
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
        var model = new Analyze
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Analyze { FunctionName = "functionName" };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.EnableBoundingBoxes);
        Assert.False(model.RawData.ContainsKey("enableBoundingBoxes"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.PreCount);
        Assert.False(model.RawData.ContainsKey("preCount"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Analyze { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Analyze
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            EnableBoundingBoxes = null,
            OutputSchema = null,
            OutputSchemaName = null,
            PreCount = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.EnableBoundingBoxes);
        Assert.False(model.RawData.ContainsKey("enableBoundingBoxes"));
        Assert.Null(model.OutputSchema);
        Assert.False(model.RawData.ContainsKey("outputSchema"));
        Assert.Null(model.OutputSchemaName);
        Assert.False(model.RawData.ContainsKey("outputSchemaName"));
        Assert.Null(model.PreCount);
        Assert.False(model.RawData.ContainsKey("preCount"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Analyze
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            EnableBoundingBoxes = null,
            OutputSchema = null,
            OutputSchemaName = null,
            PreCount = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Analyze
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            Tags = ["string"],
        };

        Analyze copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RouteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Route
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            Routes =
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
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("route");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<RouteListItem> expectedRoutes =
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
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.Routes);
        Assert.Equal(expectedRoutes.Count, model.Routes.Count);
        for (int i = 0; i < expectedRoutes.Count; i++)
        {
            Assert.Equal(expectedRoutes[i], model.Routes[i]);
        }
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
        var model = new Route
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            Routes =
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
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Route>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Route
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            Routes =
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
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Route>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("route");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<RouteListItem> expectedRoutes =
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
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.Routes);
        Assert.Equal(expectedRoutes.Count, deserialized.Routes.Count);
        for (int i = 0; i < expectedRoutes.Count; i++)
        {
            Assert.Equal(expectedRoutes[i], deserialized.Routes[i]);
        }
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
        var model = new Route
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            Routes =
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
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Route { FunctionName = "functionName" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Routes);
        Assert.False(model.RawData.ContainsKey("routes"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Route { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Route
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            Description = null,
            DisplayName = null,
            Routes = null,
            Tags = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Routes);
        Assert.False(model.RawData.ContainsKey("routes"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Route
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            Description = null,
            DisplayName = null,
            Routes = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Route
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            Routes =
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
            Tags = ["string"],
        };

        Route copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Send
        {
            FunctionName = "functionName",
            DestinationType = DestinationType.Webhook,
            DisplayName = "displayName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("send");
        ApiEnum<string, DestinationType> expectedDestinationType = DestinationType.Webhook;
        string expectedDisplayName = "displayName";
        string expectedGoogleDriveFolderID = "googleDriveFolderId";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3Prefix = "s3Prefix";
        List<string> expectedTags = ["string"];
        bool expectedWebhookSigningEnabled = true;
        string expectedWebhookUrl = "webhookUrl";

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDestinationType, model.DestinationType);
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
        Assert.Equal(expectedWebhookSigningEnabled, model.WebhookSigningEnabled);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Send
        {
            FunctionName = "functionName",
            DestinationType = DestinationType.Webhook,
            DisplayName = "displayName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Send>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Send
        {
            FunctionName = "functionName",
            DestinationType = DestinationType.Webhook,
            DisplayName = "displayName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Send>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("send");
        ApiEnum<string, DestinationType> expectedDestinationType = DestinationType.Webhook;
        string expectedDisplayName = "displayName";
        string expectedGoogleDriveFolderID = "googleDriveFolderId";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3Prefix = "s3Prefix";
        List<string> expectedTags = ["string"];
        bool expectedWebhookSigningEnabled = true;
        string expectedWebhookUrl = "webhookUrl";

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDestinationType, deserialized.DestinationType);
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
        Assert.Equal(expectedWebhookSigningEnabled, deserialized.WebhookSigningEnabled);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Send
        {
            FunctionName = "functionName",
            DestinationType = DestinationType.Webhook,
            DisplayName = "displayName",
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
        var model = new Send { FunctionName = "functionName" };

        Assert.Null(model.DestinationType);
        Assert.False(model.RawData.ContainsKey("destinationType"));
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
        Assert.Null(model.WebhookSigningEnabled);
        Assert.False(model.RawData.ContainsKey("webhookSigningEnabled"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Send { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Send
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DestinationType = null,
            DisplayName = null,
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
        var model = new Send
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DestinationType = null,
            DisplayName = null,
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
        var model = new Send
        {
            FunctionName = "functionName",
            DestinationType = DestinationType.Webhook,
            DisplayName = "displayName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        Send copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DestinationTypeTest : TestBase
{
    [Theory]
    [InlineData(DestinationType.Webhook)]
    [InlineData(DestinationType.S3)]
    [InlineData(DestinationType.GoogleDrive)]
    public void Validation_Works(DestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DestinationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DestinationType.Webhook)]
    [InlineData(DestinationType.S3)]
    [InlineData(DestinationType.GoogleDrive)]
    public void SerializationRoundtrip_Works(DestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DestinationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DestinationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DestinationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DestinationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SplitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Split
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
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
            SplitType = SplitType.PrintPage,
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("split");
        string expectedDisplayName = "displayName";
        PrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };
        SemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
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
        ApiEnum<string, SplitType> expectedSplitType = SplitType.PrintPage;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
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
        var model = new Split
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
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
            SplitType = SplitType.PrintPage,
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Split>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Split
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
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
            SplitType = SplitType.PrintPage,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Split>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("split");
        string expectedDisplayName = "displayName";
        PrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };
        SemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
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
        ApiEnum<string, SplitType> expectedSplitType = SplitType.PrintPage;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
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
        var model = new Split
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
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
            SplitType = SplitType.PrintPage,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Split { FunctionName = "functionName" };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
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
        var model = new Split { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Split
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            PrintPageSplitConfig = null,
            SemanticPageSplitConfig = null,
            SplitType = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
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
        var model = new Split
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
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
        var model = new Split
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
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
            SplitType = SplitType.PrintPage,
            Tags = ["string"],
        };

        Split copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PrintPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PrintPageSplitConfig
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
        var model = new PrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PrintPageSplitConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PrintPageSplitConfig>(
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
        var model = new PrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PrintPageSplitConfig { };

        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
        Assert.Null(model.NextFunctionName);
        Assert.False(model.RawData.ContainsKey("nextFunctionName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PrintPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PrintPageSplitConfig
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
        var model = new PrintPageSplitConfig
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
        var model = new PrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        PrintPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SemanticPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SemanticPageSplitConfig
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
        var model = new SemanticPageSplitConfig
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
        var deserialized = JsonSerializer.Deserialize<SemanticPageSplitConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SemanticPageSplitConfig
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
        var deserialized = JsonSerializer.Deserialize<SemanticPageSplitConfig>(
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
        var model = new SemanticPageSplitConfig
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
        var model = new SemanticPageSplitConfig { };

        Assert.Null(model.ItemClasses);
        Assert.False(model.RawData.ContainsKey("itemClasses"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SemanticPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SemanticPageSplitConfig
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
        var model = new SemanticPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            ItemClasses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SemanticPageSplitConfig
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

        SemanticPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitType.PrintPage)]
    [InlineData(SplitType.SemanticPage)]
    public void Validation_Works(SplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitType.PrintPage)]
    [InlineData(SplitType.SemanticPage)]
    public void SerializationRoundtrip_Works(SplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JoinTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Join
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            JoinType = JoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("join");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        ApiEnum<string, JoinType> expectedJoinType = JoinType.Standard;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
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
        var model = new Join
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            JoinType = JoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Join>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Join
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            JoinType = JoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Join>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("join");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        ApiEnum<string, JoinType> expectedJoinType = JoinType.Standard;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
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
        var model = new Join
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            JoinType = JoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Join { FunctionName = "functionName" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
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
        var model = new Join { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Join
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            Description = null,
            DisplayName = null,
            JoinType = null,
            OutputSchema = null,
            OutputSchemaName = null,
            Tags = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
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
        var model = new Join
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            Description = null,
            DisplayName = null,
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
        var model = new Join
        {
            FunctionName = "functionName",
            Description = "description",
            DisplayName = "displayName",
            JoinType = JoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        Join copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JoinTypeTest : TestBase
{
    [Theory]
    [InlineData(JoinType.Standard)]
    public void Validation_Works(JoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JoinType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JoinType.Standard)]
    public void SerializationRoundtrip_Works(JoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JoinType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JoinType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JoinType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PayloadShapingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayloadShaping
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("payload_shaping");
        string expectedDisplayName = "displayName";
        string expectedShapingSchema = "shapingSchema";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
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
        var model = new PayloadShaping
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayloadShaping>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PayloadShaping
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayloadShaping>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("payload_shaping");
        string expectedDisplayName = "displayName";
        string expectedShapingSchema = "shapingSchema";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
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
        var model = new PayloadShaping
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PayloadShaping { FunctionName = "functionName" };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.ShapingSchema);
        Assert.False(model.RawData.ContainsKey("shapingSchema"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PayloadShaping { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PayloadShaping
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            ShapingSchema = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.ShapingSchema);
        Assert.False(model.RawData.ContainsKey("shapingSchema"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PayloadShaping
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            ShapingSchema = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PayloadShaping
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        PayloadShaping copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EnrichTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Enrich
        {
            FunctionName = "functionName",
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
            DisplayName = "displayName",
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
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
        string expectedDisplayName = "displayName";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedConfig, model.Config);
        Assert.Equal(expectedDisplayName, model.DisplayName);
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
        var model = new Enrich
        {
            FunctionName = "functionName",
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
            DisplayName = "displayName",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Enrich>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Enrich
        {
            FunctionName = "functionName",
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
            DisplayName = "displayName",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Enrich>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
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
        string expectedDisplayName = "displayName";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedConfig, deserialized.Config);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
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
        var model = new Enrich
        {
            FunctionName = "functionName",
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
            DisplayName = "displayName",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Enrich { FunctionName = "functionName" };

        Assert.Null(model.Config);
        Assert.False(model.RawData.ContainsKey("config"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Enrich { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Enrich
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            Config = null,
            DisplayName = null,
            Tags = null,
        };

        Assert.Null(model.Config);
        Assert.False(model.RawData.ContainsKey("config"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Enrich
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            Config = null,
            DisplayName = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Enrich
        {
            FunctionName = "functionName",
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
            DisplayName = "displayName",
            Tags = ["string"],
        };

        Enrich copied = new(model);

        Assert.Equal(model, copied);
    }
}
