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
            SourceField = "sourceField",
            TargetField = "targetField",
            CollectionName = "collectionName",
            EndpointName = "endpointName",
            IncludeScore = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            Source = Source.Collection,
            TopK = 1,
        };

        string expectedSourceField = "sourceField";
        string expectedTargetField = "targetField";
        string expectedCollectionName = "collectionName";
        string expectedEndpointName = "endpointName";
        bool expectedIncludeScore = true;
        bool expectedIncludeSubcollections = true;
        double expectedScoreThreshold = 0;
        ApiEnum<string, SearchMode> expectedSearchMode = SearchMode.Semantic;
        ApiEnum<string, Source> expectedSource = Source.Collection;
        long expectedTopK = 1;

        Assert.Equal(expectedSourceField, model.SourceField);
        Assert.Equal(expectedTargetField, model.TargetField);
        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedEndpointName, model.EndpointName);
        Assert.Equal(expectedIncludeScore, model.IncludeScore);
        Assert.Equal(expectedIncludeSubcollections, model.IncludeSubcollections);
        Assert.Equal(expectedScoreThreshold, model.ScoreThreshold);
        Assert.Equal(expectedSearchMode, model.SearchMode);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTopK, model.TopK);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnrichStep
        {
            SourceField = "sourceField",
            TargetField = "targetField",
            CollectionName = "collectionName",
            EndpointName = "endpointName",
            IncludeScore = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            Source = Source.Collection,
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
            SourceField = "sourceField",
            TargetField = "targetField",
            CollectionName = "collectionName",
            EndpointName = "endpointName",
            IncludeScore = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            Source = Source.Collection,
            TopK = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSourceField = "sourceField";
        string expectedTargetField = "targetField";
        string expectedCollectionName = "collectionName";
        string expectedEndpointName = "endpointName";
        bool expectedIncludeScore = true;
        bool expectedIncludeSubcollections = true;
        double expectedScoreThreshold = 0;
        ApiEnum<string, SearchMode> expectedSearchMode = SearchMode.Semantic;
        ApiEnum<string, Source> expectedSource = Source.Collection;
        long expectedTopK = 1;

        Assert.Equal(expectedSourceField, deserialized.SourceField);
        Assert.Equal(expectedTargetField, deserialized.TargetField);
        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedEndpointName, deserialized.EndpointName);
        Assert.Equal(expectedIncludeScore, deserialized.IncludeScore);
        Assert.Equal(expectedIncludeSubcollections, deserialized.IncludeSubcollections);
        Assert.Equal(expectedScoreThreshold, deserialized.ScoreThreshold);
        Assert.Equal(expectedSearchMode, deserialized.SearchMode);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTopK, deserialized.TopK);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EnrichStep
        {
            SourceField = "sourceField",
            TargetField = "targetField",
            CollectionName = "collectionName",
            EndpointName = "endpointName",
            IncludeScore = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            Source = Source.Collection,
            TopK = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EnrichStep { SourceField = "sourceField", TargetField = "targetField" };

        Assert.Null(model.CollectionName);
        Assert.False(model.RawData.ContainsKey("collectionName"));
        Assert.Null(model.EndpointName);
        Assert.False(model.RawData.ContainsKey("endpointName"));
        Assert.Null(model.IncludeScore);
        Assert.False(model.RawData.ContainsKey("includeScore"));
        Assert.Null(model.IncludeSubcollections);
        Assert.False(model.RawData.ContainsKey("includeSubcollections"));
        Assert.Null(model.ScoreThreshold);
        Assert.False(model.RawData.ContainsKey("scoreThreshold"));
        Assert.Null(model.SearchMode);
        Assert.False(model.RawData.ContainsKey("searchMode"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("topK"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EnrichStep { SourceField = "sourceField", TargetField = "targetField" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EnrichStep
        {
            SourceField = "sourceField",
            TargetField = "targetField",

            // Null should be interpreted as omitted for these properties
            CollectionName = null,
            EndpointName = null,
            IncludeScore = null,
            IncludeSubcollections = null,
            ScoreThreshold = null,
            SearchMode = null,
            Source = null,
            TopK = null,
        };

        Assert.Null(model.CollectionName);
        Assert.False(model.RawData.ContainsKey("collectionName"));
        Assert.Null(model.EndpointName);
        Assert.False(model.RawData.ContainsKey("endpointName"));
        Assert.Null(model.IncludeScore);
        Assert.False(model.RawData.ContainsKey("includeScore"));
        Assert.Null(model.IncludeSubcollections);
        Assert.False(model.RawData.ContainsKey("includeSubcollections"));
        Assert.Null(model.ScoreThreshold);
        Assert.False(model.RawData.ContainsKey("scoreThreshold"));
        Assert.Null(model.SearchMode);
        Assert.False(model.RawData.ContainsKey("searchMode"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("topK"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EnrichStep
        {
            SourceField = "sourceField",
            TargetField = "targetField",

            // Null should be interpreted as omitted for these properties
            CollectionName = null,
            EndpointName = null,
            IncludeScore = null,
            IncludeSubcollections = null,
            ScoreThreshold = null,
            SearchMode = null,
            Source = null,
            TopK = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EnrichStep
        {
            SourceField = "sourceField",
            TargetField = "targetField",
            CollectionName = "collectionName",
            EndpointName = "endpointName",
            IncludeScore = true,
            IncludeSubcollections = true,
            ScoreThreshold = 0,
            SearchMode = SearchMode.Semantic,
            Source = Source.Collection,
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

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Collection)]
    [InlineData(Source.Endpoint)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Collection)]
    [InlineData(Source.Endpoint)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
