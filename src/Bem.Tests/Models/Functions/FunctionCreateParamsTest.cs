using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionCreateParams
        {
            Body = new Extract()
            {
                FunctionName = "functionName",
                DisplayName = "displayName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        Body expectedBody = new Extract()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionCreateParams parameters = new()
        {
            Body = new Extract()
            {
                FunctionName = "functionName",
                DisplayName = "displayName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionCreateParams
        {
            Body = new Extract()
            {
                FunctionName = "functionName",
                DisplayName = "displayName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        FunctionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void ExtractValidationWorks()
    {
        Body value = new Extract()
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
    public void ClassifyValidationWorks()
    {
        Body value = new Classify()
        {
            FunctionName = "functionName",
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
            Tags = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void SendValidationWorks()
    {
        Body value = new Send()
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
        Body value = new Split()
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
        Body value = new Join()
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
        Body value = new PayloadShaping()
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
        Body value = new Enrich()
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
    public void ExtractSerializationRoundtripWorks()
    {
        Body value = new Extract()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClassifySerializationRoundtripWorks()
    {
        Body value = new Classify()
        {
            FunctionName = "functionName",
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
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        Body value = new Send()
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
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitSerializationRoundtripWorks()
    {
        Body value = new Split()
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
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        Body value = new Join()
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
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PayloadShapingSerializationRoundtripWorks()
    {
        Body value = new PayloadShaping()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            ShapingSchema = "shapingSchema",
            Tags = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        Body value = new Enrich()
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
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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

public class ClassifyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Classify
        {
            FunctionName = "functionName",
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
            Tags = ["string"],
        };

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("classify");
        List<Classification> expectedClassifications =
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
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Classifications);
        Assert.Equal(expectedClassifications.Count, model.Classifications.Count);
        for (int i = 0; i < expectedClassifications.Count; i++)
        {
            Assert.Equal(expectedClassifications[i], model.Classifications[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
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
        var model = new Classify
        {
            FunctionName = "functionName",
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
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Classify>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Classify
        {
            FunctionName = "functionName",
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
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Classify>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        JsonElement expectedType = JsonSerializer.SerializeToElement("classify");
        List<Classification> expectedClassifications =
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
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Classifications);
        Assert.Equal(expectedClassifications.Count, deserialized.Classifications.Count);
        for (int i = 0; i < expectedClassifications.Count; i++)
        {
            Assert.Equal(expectedClassifications[i], deserialized.Classifications[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
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
        var model = new Classify
        {
            FunctionName = "functionName",
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
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Classify { FunctionName = "functionName" };

        Assert.Null(model.Classifications);
        Assert.False(model.RawData.ContainsKey("classifications"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Classify { FunctionName = "functionName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Classify
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            Classifications = null,
            Description = null,
            DisplayName = null,
            Tags = null,
        };

        Assert.Null(model.Classifications);
        Assert.False(model.RawData.ContainsKey("classifications"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Classify
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            Classifications = null,
            Description = null,
            DisplayName = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Classify
        {
            FunctionName = "functionName",
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
            Tags = ["string"],
        };

        Classify copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClassificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Classification
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
        Origin expectedOrigin = new() { Email = new() { Patterns = ["string"] } };
        Regex expectedRegex = new() { Patterns = ["string"] };

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
        var model = new Classification
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
        var deserialized = JsonSerializer.Deserialize<Classification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Classification
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
        var deserialized = JsonSerializer.Deserialize<Classification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        bool expectedIsErrorFallback = true;
        Origin expectedOrigin = new() { Email = new() { Patterns = ["string"] } };
        Regex expectedRegex = new() { Patterns = ["string"] };

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
        var model = new Classification
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
        var model = new Classification { Name = "name" };

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
        var model = new Classification { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Classification
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
        var model = new Classification
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
        var model = new Classification
        {
            Name = "name",
            Description = "description",
            FunctionID = "functionID",
            FunctionName = "functionName",
            IsErrorFallback = true,
            Origin = new() { Email = new() { Patterns = ["string"] } },
            Regex = new() { Patterns = ["string"] },
        };

        Classification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Origin { Email = new() { Patterns = ["string"] } };

        Email expectedEmail = new() { Patterns = ["string"] };

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Origin { Email = new() { Patterns = ["string"] } };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Origin>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Origin { Email = new() { Patterns = ["string"] } };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Email expectedEmail = new() { Patterns = ["string"] };

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Origin { Email = new() { Patterns = ["string"] } };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Origin { };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Origin { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Origin
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
        var model = new Origin
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Origin { Email = new() { Patterns = ["string"] } };

        Origin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Email { Patterns = ["string"] };

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
        var model = new Email { Patterns = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Email>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Email { Patterns = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Email>(element, ModelBase.SerializerOptions);
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
        var model = new Email { Patterns = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Email { };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Email { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Email
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
        var model = new Email
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Email { Patterns = ["string"] };

        Email copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RegexTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Regex { Patterns = ["string"] };

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
        var model = new Regex { Patterns = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Regex>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Regex { Patterns = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Regex>(element, ModelBase.SerializerOptions);
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
        var model = new Regex { Patterns = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Regex { };

        Assert.Null(model.Patterns);
        Assert.False(model.RawData.ContainsKey("patterns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Regex { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Regex
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
        var model = new Regex
        {
            // Null should be interpreted as omitted for these properties
            Patterns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Regex { Patterns = ["string"] };

        Regex copied = new(model);

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
