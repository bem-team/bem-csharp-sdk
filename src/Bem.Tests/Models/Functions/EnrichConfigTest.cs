using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
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
                },
            ],
            Endpoints =
            [
                new()
                {
                    Method = Method.Get,
                    Name = "name",
                    Url = "url",
                    BodyTemplate = "bodyTemplate",
                    Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                    MatchInstructions = "matchInstructions",
                    MatchTopK = 1,
                    MaxCandidates = 1,
                    MaxPages = 1,
                    NextPageParam = "nextPageParam",
                    NextPagePath = "nextPagePath",
                    QueryParam = "queryParam",
                    ResponsePath = "responsePath",
                },
            ],
        };

        List<EnrichStep> expectedSteps =
        [
            new()
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
            },
        ];
        List<Endpoint> expectedEndpoints =
        [
            new()
            {
                Method = Method.Get,
                Name = "name",
                Url = "url",
                BodyTemplate = "bodyTemplate",
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                MatchInstructions = "matchInstructions",
                MatchTopK = 1,
                MaxCandidates = 1,
                MaxPages = 1,
                NextPageParam = "nextPageParam",
                NextPagePath = "nextPagePath",
                QueryParam = "queryParam",
                ResponsePath = "responsePath",
            },
        ];

        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], model.Steps[i]);
        }
        Assert.NotNull(model.Endpoints);
        Assert.Equal(expectedEndpoints.Count, model.Endpoints.Count);
        for (int i = 0; i < expectedEndpoints.Count; i++)
        {
            Assert.Equal(expectedEndpoints[i], model.Endpoints[i]);
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
                },
            ],
            Endpoints =
            [
                new()
                {
                    Method = Method.Get,
                    Name = "name",
                    Url = "url",
                    BodyTemplate = "bodyTemplate",
                    Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                    MatchInstructions = "matchInstructions",
                    MatchTopK = 1,
                    MaxCandidates = 1,
                    MaxPages = 1,
                    NextPageParam = "nextPageParam",
                    NextPagePath = "nextPagePath",
                    QueryParam = "queryParam",
                    ResponsePath = "responsePath",
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
                },
            ],
            Endpoints =
            [
                new()
                {
                    Method = Method.Get,
                    Name = "name",
                    Url = "url",
                    BodyTemplate = "bodyTemplate",
                    Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                    MatchInstructions = "matchInstructions",
                    MatchTopK = 1,
                    MaxCandidates = 1,
                    MaxPages = 1,
                    NextPageParam = "nextPageParam",
                    NextPagePath = "nextPagePath",
                    QueryParam = "queryParam",
                    ResponsePath = "responsePath",
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
            },
        ];
        List<Endpoint> expectedEndpoints =
        [
            new()
            {
                Method = Method.Get,
                Name = "name",
                Url = "url",
                BodyTemplate = "bodyTemplate",
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                MatchInstructions = "matchInstructions",
                MatchTopK = 1,
                MaxCandidates = 1,
                MaxPages = 1,
                NextPageParam = "nextPageParam",
                NextPagePath = "nextPagePath",
                QueryParam = "queryParam",
                ResponsePath = "responsePath",
            },
        ];

        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], deserialized.Steps[i]);
        }
        Assert.NotNull(deserialized.Endpoints);
        Assert.Equal(expectedEndpoints.Count, deserialized.Endpoints.Count);
        for (int i = 0; i < expectedEndpoints.Count; i++)
        {
            Assert.Equal(expectedEndpoints[i], deserialized.Endpoints[i]);
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
                },
            ],
            Endpoints =
            [
                new()
                {
                    Method = Method.Get,
                    Name = "name",
                    Url = "url",
                    BodyTemplate = "bodyTemplate",
                    Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                    MatchInstructions = "matchInstructions",
                    MatchTopK = 1,
                    MaxCandidates = 1,
                    MaxPages = 1,
                    NextPageParam = "nextPageParam",
                    NextPagePath = "nextPagePath",
                    QueryParam = "queryParam",
                    ResponsePath = "responsePath",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
            [
                new()
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
                },
            ],
        };

        Assert.Null(model.Endpoints);
        Assert.False(model.RawData.ContainsKey("endpoints"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
            [
                new()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            Endpoints = null,
        };

        Assert.Null(model.Endpoints);
        Assert.False(model.RawData.ContainsKey("endpoints"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EnrichConfig
        {
            Steps =
            [
                new()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            Endpoints = null,
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
                },
            ],
            Endpoints =
            [
                new()
                {
                    Method = Method.Get,
                    Name = "name",
                    Url = "url",
                    BodyTemplate = "bodyTemplate",
                    Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                    MatchInstructions = "matchInstructions",
                    MatchTopK = 1,
                    MaxCandidates = 1,
                    MaxPages = 1,
                    NextPageParam = "nextPageParam",
                    NextPagePath = "nextPagePath",
                    QueryParam = "queryParam",
                    ResponsePath = "responsePath",
                },
            ],
        };

        EnrichConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EndpointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",
            BodyTemplate = "bodyTemplate",
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            MatchInstructions = "matchInstructions",
            MatchTopK = 1,
            MaxCandidates = 1,
            MaxPages = 1,
            NextPageParam = "nextPageParam",
            NextPagePath = "nextPagePath",
            QueryParam = "queryParam",
            ResponsePath = "responsePath",
        };

        ApiEnum<string, Method> expectedMethod = Method.Get;
        string expectedName = "name";
        string expectedUrl = "url";
        string expectedBodyTemplate = "bodyTemplate";
        JsonElement expectedHeaders = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedMatchInstructions = "matchInstructions";
        long expectedMatchTopK = 1;
        long expectedMaxCandidates = 1;
        long expectedMaxPages = 1;
        string expectedNextPageParam = "nextPageParam";
        string expectedNextPagePath = "nextPagePath";
        string expectedQueryParam = "queryParam";
        string expectedResponsePath = "responsePath";

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedBodyTemplate, model.BodyTemplate);
        Assert.NotNull(model.Headers);
        Assert.True(JsonElement.DeepEquals(expectedHeaders, model.Headers.Value));
        Assert.Equal(expectedMatchInstructions, model.MatchInstructions);
        Assert.Equal(expectedMatchTopK, model.MatchTopK);
        Assert.Equal(expectedMaxCandidates, model.MaxCandidates);
        Assert.Equal(expectedMaxPages, model.MaxPages);
        Assert.Equal(expectedNextPageParam, model.NextPageParam);
        Assert.Equal(expectedNextPagePath, model.NextPagePath);
        Assert.Equal(expectedQueryParam, model.QueryParam);
        Assert.Equal(expectedResponsePath, model.ResponsePath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",
            BodyTemplate = "bodyTemplate",
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            MatchInstructions = "matchInstructions",
            MatchTopK = 1,
            MaxCandidates = 1,
            MaxPages = 1,
            NextPageParam = "nextPageParam",
            NextPagePath = "nextPagePath",
            QueryParam = "queryParam",
            ResponsePath = "responsePath",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Endpoint>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",
            BodyTemplate = "bodyTemplate",
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            MatchInstructions = "matchInstructions",
            MatchTopK = 1,
            MaxCandidates = 1,
            MaxPages = 1,
            NextPageParam = "nextPageParam",
            NextPagePath = "nextPagePath",
            QueryParam = "queryParam",
            ResponsePath = "responsePath",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Endpoint>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Method> expectedMethod = Method.Get;
        string expectedName = "name";
        string expectedUrl = "url";
        string expectedBodyTemplate = "bodyTemplate";
        JsonElement expectedHeaders = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedMatchInstructions = "matchInstructions";
        long expectedMatchTopK = 1;
        long expectedMaxCandidates = 1;
        long expectedMaxPages = 1;
        string expectedNextPageParam = "nextPageParam";
        string expectedNextPagePath = "nextPagePath";
        string expectedQueryParam = "queryParam";
        string expectedResponsePath = "responsePath";

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedBodyTemplate, deserialized.BodyTemplate);
        Assert.NotNull(deserialized.Headers);
        Assert.True(JsonElement.DeepEquals(expectedHeaders, deserialized.Headers.Value));
        Assert.Equal(expectedMatchInstructions, deserialized.MatchInstructions);
        Assert.Equal(expectedMatchTopK, deserialized.MatchTopK);
        Assert.Equal(expectedMaxCandidates, deserialized.MaxCandidates);
        Assert.Equal(expectedMaxPages, deserialized.MaxPages);
        Assert.Equal(expectedNextPageParam, deserialized.NextPageParam);
        Assert.Equal(expectedNextPagePath, deserialized.NextPagePath);
        Assert.Equal(expectedQueryParam, deserialized.QueryParam);
        Assert.Equal(expectedResponsePath, deserialized.ResponsePath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",
            BodyTemplate = "bodyTemplate",
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            MatchInstructions = "matchInstructions",
            MatchTopK = 1,
            MaxCandidates = 1,
            MaxPages = 1,
            NextPageParam = "nextPageParam",
            NextPagePath = "nextPagePath",
            QueryParam = "queryParam",
            ResponsePath = "responsePath",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",
        };

        Assert.Null(model.BodyTemplate);
        Assert.False(model.RawData.ContainsKey("bodyTemplate"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.MatchInstructions);
        Assert.False(model.RawData.ContainsKey("matchInstructions"));
        Assert.Null(model.MatchTopK);
        Assert.False(model.RawData.ContainsKey("matchTopK"));
        Assert.Null(model.MaxCandidates);
        Assert.False(model.RawData.ContainsKey("maxCandidates"));
        Assert.Null(model.MaxPages);
        Assert.False(model.RawData.ContainsKey("maxPages"));
        Assert.Null(model.NextPageParam);
        Assert.False(model.RawData.ContainsKey("nextPageParam"));
        Assert.Null(model.NextPagePath);
        Assert.False(model.RawData.ContainsKey("nextPagePath"));
        Assert.Null(model.QueryParam);
        Assert.False(model.RawData.ContainsKey("queryParam"));
        Assert.Null(model.ResponsePath);
        Assert.False(model.RawData.ContainsKey("responsePath"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",

            // Null should be interpreted as omitted for these properties
            BodyTemplate = null,
            Headers = null,
            MatchInstructions = null,
            MatchTopK = null,
            MaxCandidates = null,
            MaxPages = null,
            NextPageParam = null,
            NextPagePath = null,
            QueryParam = null,
            ResponsePath = null,
        };

        Assert.Null(model.BodyTemplate);
        Assert.False(model.RawData.ContainsKey("bodyTemplate"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.MatchInstructions);
        Assert.False(model.RawData.ContainsKey("matchInstructions"));
        Assert.Null(model.MatchTopK);
        Assert.False(model.RawData.ContainsKey("matchTopK"));
        Assert.Null(model.MaxCandidates);
        Assert.False(model.RawData.ContainsKey("maxCandidates"));
        Assert.Null(model.MaxPages);
        Assert.False(model.RawData.ContainsKey("maxPages"));
        Assert.Null(model.NextPageParam);
        Assert.False(model.RawData.ContainsKey("nextPageParam"));
        Assert.Null(model.NextPagePath);
        Assert.False(model.RawData.ContainsKey("nextPagePath"));
        Assert.Null(model.QueryParam);
        Assert.False(model.RawData.ContainsKey("queryParam"));
        Assert.Null(model.ResponsePath);
        Assert.False(model.RawData.ContainsKey("responsePath"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",

            // Null should be interpreted as omitted for these properties
            BodyTemplate = null,
            Headers = null,
            MatchInstructions = null,
            MatchTopK = null,
            MaxCandidates = null,
            MaxPages = null,
            NextPageParam = null,
            NextPagePath = null,
            QueryParam = null,
            ResponsePath = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Endpoint
        {
            Method = Method.Get,
            Name = "name",
            Url = "url",
            BodyTemplate = "bodyTemplate",
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            MatchInstructions = "matchInstructions",
            MatchTopK = 1,
            MaxCandidates = 1,
            MaxPages = 1,
            NextPageParam = "nextPageParam",
            NextPagePath = "nextPagePath",
            QueryParam = "queryParam",
            ResponsePath = "responsePath",
        };

        Endpoint copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Method.Get)]
    [InlineData(Method.Post)]
    public void Validation_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Method.Get)]
    [InlineData(Method.Post)]
    public void SerializationRoundtrip_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
