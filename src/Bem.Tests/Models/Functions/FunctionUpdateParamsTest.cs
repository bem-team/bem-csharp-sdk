using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionUpdateParams
        {
            PathFunctionName = "functionName",
            Body = new FunctionUpdateParamsBodyExtract()
            {
                DisplayName = "displayName",
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        string expectedPathFunctionName = "functionName";
        FunctionUpdateParamsBody expectedBody = new FunctionUpdateParamsBodyExtract()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        Assert.Equal(expectedPathFunctionName, parameters.PathFunctionName);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionUpdateParams parameters = new()
        {
            PathFunctionName = "functionName",
            Body = new FunctionUpdateParamsBodyExtract()
            {
                DisplayName = "displayName",
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions/functionName"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionUpdateParams
        {
            PathFunctionName = "functionName",
            Body = new FunctionUpdateParamsBodyExtract()
            {
                DisplayName = "displayName",
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        FunctionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FunctionUpdateParamsBodyTest : TestBase
{
    [Fact]
    public void ExtractValidationWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyExtract()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void ClassifyValidationWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyClassify()
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
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodySend()
        {
            DestinationType = FunctionUpdateParamsBodySendDestinationType.Webhook,
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
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodySplit()
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
            SplitType = FunctionUpdateParamsBodySplitSplitType.PrintPage,
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void JoinValidationWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyJoin()
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = FunctionUpdateParamsBodyJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void PayloadShapingValidationWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyPayloadShaping()
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
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyEnrich()
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
    public void ExtractSerializationRoundtripWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyExtract()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBody>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClassifySerializationRoundtripWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyClassify()
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBody>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodySend()
        {
            DestinationType = FunctionUpdateParamsBodySendDestinationType.Webhook,
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBody>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitSerializationRoundtripWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodySplit()
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
            SplitType = FunctionUpdateParamsBodySplitSplitType.PrintPage,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBody>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyJoin()
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = FunctionUpdateParamsBodyJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBody>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PayloadShapingSerializationRoundtripWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyPayloadShaping()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBody>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        FunctionUpdateParamsBody value = new FunctionUpdateParamsBodyEnrich()
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBody>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FunctionUpdateParamsBodyExtractTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyExtract
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("extract");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFunctionName, model.FunctionName);
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
        var model = new FunctionUpdateParamsBodyExtract
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyExtract>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyExtract
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyExtract>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("extract");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOutputSchemaName = "outputSchemaName";
        bool expectedTabularChunkingEnabled = true;
        List<string> expectedTags = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
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
        var model = new FunctionUpdateParamsBodyExtract
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
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
        var model = new FunctionUpdateParamsBodyExtract { };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
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
        var model = new FunctionUpdateParamsBodyExtract { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyExtract
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            FunctionName = null,
            OutputSchema = null,
            OutputSchemaName = null,
            TabularChunkingEnabled = null,
            Tags = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
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
        var model = new FunctionUpdateParamsBodyExtract
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            FunctionName = null,
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
        var model = new FunctionUpdateParamsBodyExtract
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        FunctionUpdateParamsBodyExtract copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodyClassifyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyClassify
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
        List<FunctionUpdateParamsBodyClassifyClassification> expectedClassifications =
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
        var model = new FunctionUpdateParamsBodyClassify
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassify>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyClassify
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassify>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("classify");
        List<FunctionUpdateParamsBodyClassifyClassification> expectedClassifications =
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
        var model = new FunctionUpdateParamsBodyClassify
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
        var model = new FunctionUpdateParamsBodyClassify { };

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
        var model = new FunctionUpdateParamsBodyClassify { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyClassify
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
        var model = new FunctionUpdateParamsBodyClassify
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
        var model = new FunctionUpdateParamsBodyClassify
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

        FunctionUpdateParamsBodyClassify copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodyClassifyClassificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassification
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
        FunctionUpdateParamsBodyClassifyClassificationOrigin expectedOrigin = new()
        {
            Email = new() { Patterns = ["string"] },
        };
        FunctionUpdateParamsBodyClassifyClassificationRegex expectedRegex = new()
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
        var model = new FunctionUpdateParamsBodyClassifyClassification
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
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassifyClassification>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassification
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
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassifyClassification>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        bool expectedIsErrorFallback = true;
        FunctionUpdateParamsBodyClassifyClassificationOrigin expectedOrigin = new()
        {
            Email = new() { Patterns = ["string"] },
        };
        FunctionUpdateParamsBodyClassifyClassificationRegex expectedRegex = new()
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
        var model = new FunctionUpdateParamsBodyClassifyClassification
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
        var model = new FunctionUpdateParamsBodyClassifyClassification { Name = "name" };

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
        var model = new FunctionUpdateParamsBodyClassifyClassification { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassification
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
        var model = new FunctionUpdateParamsBodyClassifyClassification
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
        var model = new FunctionUpdateParamsBodyClassifyClassification
        {
            Name = "name",
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            IsErrorFallback = true,
            Origin = new() { Email = new() { Patterns = ["string"] } },
            Regex = new() { Patterns = ["string"] },
        };

        FunctionUpdateParamsBodyClassifyClassification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodyClassifyClassificationOriginTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        FunctionUpdateParamsBodyClassifyClassificationOriginEmail expectedEmail = new()
        {
            Patterns = ["string"],
        };

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassifyClassificationOrigin>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassifyClassificationOrigin>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        FunctionUpdateParamsBodyClassifyClassificationOriginEmail expectedEmail = new()
        {
            Patterns = ["string"],
        };

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin { };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin
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
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOrigin
        {
            Email = new() { Patterns = ["string"] },
        };

        FunctionUpdateParamsBodyClassifyClassificationOrigin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodyClassifyClassificationOriginEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail
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
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassifyClassificationOriginEmail>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassifyClassificationOriginEmail>(
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
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail { };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail
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
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationOriginEmail
        {
            Patterns = ["string"],
        };

        FunctionUpdateParamsBodyClassifyClassificationOriginEmail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodyClassifyClassificationRegexTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex
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
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex
        {
            Patterns = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassifyClassificationRegex>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex
        {
            Patterns = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodyClassifyClassificationRegex>(
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
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex
        {
            Patterns = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex { };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex
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
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionUpdateParamsBodyClassifyClassificationRegex
        {
            Patterns = ["string"],
        };

        FunctionUpdateParamsBodyClassifyClassificationRegex copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodySendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodySend
        {
            DestinationType = FunctionUpdateParamsBodySendDestinationType.Webhook,
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
        ApiEnum<string, FunctionUpdateParamsBodySendDestinationType> expectedDestinationType =
            FunctionUpdateParamsBodySendDestinationType.Webhook;
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
        var model = new FunctionUpdateParamsBodySend
        {
            DestinationType = FunctionUpdateParamsBodySendDestinationType.Webhook,
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodySend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodySend
        {
            DestinationType = FunctionUpdateParamsBodySendDestinationType.Webhook,
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodySend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("send");
        ApiEnum<string, FunctionUpdateParamsBodySendDestinationType> expectedDestinationType =
            FunctionUpdateParamsBodySendDestinationType.Webhook;
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
        var model = new FunctionUpdateParamsBodySend
        {
            DestinationType = FunctionUpdateParamsBodySendDestinationType.Webhook,
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
        var model = new FunctionUpdateParamsBodySend { };

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
        var model = new FunctionUpdateParamsBodySend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodySend
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
        var model = new FunctionUpdateParamsBodySend
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
        var model = new FunctionUpdateParamsBodySend
        {
            DestinationType = FunctionUpdateParamsBodySendDestinationType.Webhook,
            DisplayName = "displayName",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderId",
            S3Bucket = "s3Bucket",
            S3Prefix = "s3Prefix",
            Tags = ["string"],
            WebhookSigningEnabled = true,
            WebhookUrl = "webhookUrl",
        };

        FunctionUpdateParamsBodySend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodySendDestinationTypeTest : TestBase
{
    [Theory]
    [InlineData(FunctionUpdateParamsBodySendDestinationType.Webhook)]
    [InlineData(FunctionUpdateParamsBodySendDestinationType.S3)]
    [InlineData(FunctionUpdateParamsBodySendDestinationType.GoogleDrive)]
    public void Validation_Works(FunctionUpdateParamsBodySendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateParamsBodySendDestinationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodySendDestinationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionUpdateParamsBodySendDestinationType.Webhook)]
    [InlineData(FunctionUpdateParamsBodySendDestinationType.S3)]
    [InlineData(FunctionUpdateParamsBodySendDestinationType.GoogleDrive)]
    public void SerializationRoundtrip_Works(FunctionUpdateParamsBodySendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateParamsBodySendDestinationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodySendDestinationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodySendDestinationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodySendDestinationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FunctionUpdateParamsBodySplitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodySplit
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
            SplitType = FunctionUpdateParamsBodySplitSplitType.PrintPage,
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("split");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        FunctionUpdateParamsBodySplitPrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };
        FunctionUpdateParamsBodySplitSemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
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
        ApiEnum<string, FunctionUpdateParamsBodySplitSplitType> expectedSplitType =
            FunctionUpdateParamsBodySplitSplitType.PrintPage;
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
        var model = new FunctionUpdateParamsBodySplit
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
            SplitType = FunctionUpdateParamsBodySplitSplitType.PrintPage,
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodySplit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodySplit
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
            SplitType = FunctionUpdateParamsBodySplitSplitType.PrintPage,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodySplit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("split");
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        FunctionUpdateParamsBodySplitPrintPageSplitConfig expectedPrintPageSplitConfig = new()
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };
        FunctionUpdateParamsBodySplitSemanticPageSplitConfig expectedSemanticPageSplitConfig = new()
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
        ApiEnum<string, FunctionUpdateParamsBodySplitSplitType> expectedSplitType =
            FunctionUpdateParamsBodySplitSplitType.PrintPage;
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
        var model = new FunctionUpdateParamsBodySplit
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
            SplitType = FunctionUpdateParamsBodySplitSplitType.PrintPage,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodySplit { };

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
        var model = new FunctionUpdateParamsBodySplit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodySplit
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
        var model = new FunctionUpdateParamsBodySplit
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
        var model = new FunctionUpdateParamsBodySplit
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
            SplitType = FunctionUpdateParamsBodySplitSplitType.PrintPage,
            Tags = ["string"],
        };

        FunctionUpdateParamsBodySplit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodySplitPrintPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig
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
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodySplitPrintPageSplitConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionUpdateParamsBodySplitPrintPageSplitConfig>(
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
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig { };

        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
        Assert.Null(model.NextFunctionName);
        Assert.False(model.RawData.ContainsKey("nextFunctionName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig
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
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig
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
        var model = new FunctionUpdateParamsBodySplitPrintPageSplitConfig
        {
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        FunctionUpdateParamsBodySplitPrintPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodySplitSemanticPageSplitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig
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
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig
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
            JsonSerializer.Deserialize<FunctionUpdateParamsBodySplitSemanticPageSplitConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig
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
            JsonSerializer.Deserialize<FunctionUpdateParamsBodySplitSemanticPageSplitConfig>(
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
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig
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
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig { };

        Assert.Null(model.ItemClasses);
        Assert.False(model.RawData.ContainsKey("itemClasses"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig
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
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig
        {
            // Null should be interpreted as omitted for these properties
            ItemClasses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionUpdateParamsBodySplitSemanticPageSplitConfig
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

        FunctionUpdateParamsBodySplitSemanticPageSplitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodySplitSplitTypeTest : TestBase
{
    [Theory]
    [InlineData(FunctionUpdateParamsBodySplitSplitType.PrintPage)]
    [InlineData(FunctionUpdateParamsBodySplitSplitType.SemanticPage)]
    public void Validation_Works(FunctionUpdateParamsBodySplitSplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateParamsBodySplitSplitType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodySplitSplitType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionUpdateParamsBodySplitSplitType.PrintPage)]
    [InlineData(FunctionUpdateParamsBodySplitSplitType.SemanticPage)]
    public void SerializationRoundtrip_Works(FunctionUpdateParamsBodySplitSplitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateParamsBodySplitSplitType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodySplitSplitType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodySplitSplitType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodySplitSplitType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FunctionUpdateParamsBodyJoinTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = FunctionUpdateParamsBodyJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("join");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType> expectedJoinType =
            FunctionUpdateParamsBodyJoinJoinType.Standard;
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
        var model = new FunctionUpdateParamsBodyJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = FunctionUpdateParamsBodyJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyJoin>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = FunctionUpdateParamsBodyJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyJoin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("join");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        string expectedFunctionName = "functionName";
        ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType> expectedJoinType =
            FunctionUpdateParamsBodyJoinJoinType.Standard;
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
        var model = new FunctionUpdateParamsBodyJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = FunctionUpdateParamsBodyJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyJoin { };

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
        var model = new FunctionUpdateParamsBodyJoin { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyJoin
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
        var model = new FunctionUpdateParamsBodyJoin
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
        var model = new FunctionUpdateParamsBodyJoin
        {
            Description = "description",
            DisplayName = "displayName",
            FunctionName = "functionName",
            JoinType = FunctionUpdateParamsBodyJoinJoinType.Standard,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            Tags = ["string"],
        };

        FunctionUpdateParamsBodyJoin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodyJoinJoinTypeTest : TestBase
{
    [Theory]
    [InlineData(FunctionUpdateParamsBodyJoinJoinType.Standard)]
    public void Validation_Works(FunctionUpdateParamsBodyJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionUpdateParamsBodyJoinJoinType.Standard)]
    public void SerializationRoundtrip_Works(FunctionUpdateParamsBodyJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateParamsBodyJoinJoinType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FunctionUpdateParamsBodyPayloadShapingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyPayloadShaping
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
        var model = new FunctionUpdateParamsBodyPayloadShaping
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyPayloadShaping>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyPayloadShaping
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyPayloadShaping>(
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
        var model = new FunctionUpdateParamsBodyPayloadShaping
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
        var model = new FunctionUpdateParamsBodyPayloadShaping { };

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
        var model = new FunctionUpdateParamsBodyPayloadShaping { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyPayloadShaping
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
        var model = new FunctionUpdateParamsBodyPayloadShaping
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
        var model = new FunctionUpdateParamsBodyPayloadShaping
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };

        FunctionUpdateParamsBodyPayloadShaping copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateParamsBodyEnrichTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateParamsBodyEnrich
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
        var model = new FunctionUpdateParamsBodyEnrich
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyEnrich>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateParamsBodyEnrich
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
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateParamsBodyEnrich>(
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
        var model = new FunctionUpdateParamsBodyEnrich
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
        var model = new FunctionUpdateParamsBodyEnrich { };

        Assert.Null(model.Config);
        Assert.False(model.RawData.ContainsKey("config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionUpdateParamsBodyEnrich { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionUpdateParamsBodyEnrich
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
        var model = new FunctionUpdateParamsBodyEnrich
        {
            // Null should be interpreted as omitted for these properties
            Config = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionUpdateParamsBodyEnrich
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

        FunctionUpdateParamsBodyEnrich copied = new(model);

        Assert.Equal(model, copied);
    }
}
