using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class EnrichStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",
            IncludeCosineDistance = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            TopK = 1,
        };

        string expectedCollectionName = "collectionName";
        string expectedSourceField = "sourceField";
        string expectedTargetField = "targetField";
        bool expectedIncludeCosineDistance = true;
        bool expectedIncludeSubcollections = true;
        double expectedScoreThreshold = 0;
        ApiEnum<string, SearchMode> expectedSearchMode = SearchMode.Semantic;
        long expectedTopK = 1;

        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedSourceField, model.SourceField);
        Assert.Equal(expectedTargetField, model.TargetField);
        Assert.Equal(expectedIncludeCosineDistance, model.IncludeCosineDistance);
        Assert.Equal(expectedIncludeSubcollections, model.IncludeSubcollections);
        Assert.Equal(expectedScoreThreshold, model.ScoreThreshold);
        Assert.Equal(expectedSearchMode, model.SearchMode);
        Assert.Equal(expectedTopK, model.TopK);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",
            IncludeCosineDistance = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            TopK = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",
            IncludeCosineDistance = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            TopK = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionName = "collectionName";
        string expectedSourceField = "sourceField";
        string expectedTargetField = "targetField";
        bool expectedIncludeCosineDistance = true;
        bool expectedIncludeSubcollections = true;
        double expectedScoreThreshold = 0;
        ApiEnum<string, SearchMode> expectedSearchMode = SearchMode.Semantic;
        long expectedTopK = 1;

        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedSourceField, deserialized.SourceField);
        Assert.Equal(expectedTargetField, deserialized.TargetField);
        Assert.Equal(expectedIncludeCosineDistance, deserialized.IncludeCosineDistance);
        Assert.Equal(expectedIncludeSubcollections, deserialized.IncludeSubcollections);
        Assert.Equal(expectedScoreThreshold, deserialized.ScoreThreshold);
        Assert.Equal(expectedSearchMode, deserialized.SearchMode);
        Assert.Equal(expectedTopK, deserialized.TopK);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",
            IncludeCosineDistance = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            TopK = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",
        };

        Assert.Null(model.IncludeCosineDistance);
        Assert.False(model.RawData.ContainsKey("includeCosineDistance"));
        Assert.Null(model.IncludeSubcollections);
        Assert.False(model.RawData.ContainsKey("includeSubcollections"));
        Assert.Null(model.ScoreThreshold);
        Assert.False(model.RawData.ContainsKey("scoreThreshold"));
        Assert.Null(model.SearchMode);
        Assert.False(model.RawData.ContainsKey("searchMode"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("topK"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",

            // Null should be interpreted as omitted for these properties
            IncludeCosineDistance = null,
            IncludeSubcollections = null,
            ScoreThreshold = null,
            SearchMode = null,
            TopK = null,
        };

        Assert.Null(model.IncludeCosineDistance);
        Assert.False(model.RawData.ContainsKey("includeCosineDistance"));
        Assert.Null(model.IncludeSubcollections);
        Assert.False(model.RawData.ContainsKey("includeSubcollections"));
        Assert.Null(model.ScoreThreshold);
        Assert.False(model.RawData.ContainsKey("scoreThreshold"));
        Assert.Null(model.SearchMode);
        Assert.False(model.RawData.ContainsKey("searchMode"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("topK"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",

            // Null should be interpreted as omitted for these properties
            IncludeCosineDistance = null,
            IncludeSubcollections = null,
            ScoreThreshold = null,
            SearchMode = null,
            TopK = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EnrichStep
        {
            CollectionName = "collectionName",
            SourceField = "sourceField",
            TargetField = "targetField",
            IncludeCosineDistance = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            TopK = 1,
        };

        EnrichStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchModeTest : TestBase
{
    [Theory]
    [InlineData(SearchMode.Semantic)]
    [InlineData(SearchMode.Exact)]
    [InlineData(SearchMode.Hybrid)]
    public void Validation_Works(SearchMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SearchMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SearchMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SearchMode.Semantic)]
    [InlineData(SearchMode.Exact)]
    [InlineData(SearchMode.Hybrid)]
    public void SerializationRoundtrip_Works(SearchMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SearchMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SearchMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SearchMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SearchMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
