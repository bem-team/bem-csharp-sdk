using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class EnrichConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
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
            ],
        };

        List<EnrichStep> expectedSteps =
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
        ];

        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], model.Steps[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
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
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
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
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EnrichStep> expectedSteps =
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
        ];

        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], deserialized.Steps[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
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
            ],
        };

        EnrichConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
