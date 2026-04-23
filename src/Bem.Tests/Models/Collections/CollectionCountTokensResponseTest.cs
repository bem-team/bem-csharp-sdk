using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Collections;

namespace Bem.Tests.Models.Collections;

public class CollectionCountTokensResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CollectionCountTokensResponse
        {
            MaxTokenLimit = 0,
            TextsExceedingLimit = 0,
            TokenCounts =
            [
                new()
                {
                    CharCount = 0,
                    ExceedsLimit = true,
                    Index = 0,
                    TokenCountValue = 0,
                },
            ],
            TotalTokens = 0,
        };

        long expectedMaxTokenLimit = 0;
        long expectedTextsExceedingLimit = 0;
        List<TokenCount> expectedTokenCounts =
        [
            new()
            {
                CharCount = 0,
                ExceedsLimit = true,
                Index = 0,
                TokenCountValue = 0,
            },
        ];
        long expectedTotalTokens = 0;

        Assert.Equal(expectedMaxTokenLimit, model.MaxTokenLimit);
        Assert.Equal(expectedTextsExceedingLimit, model.TextsExceedingLimit);
        Assert.NotNull(model.TokenCounts);
        Assert.Equal(expectedTokenCounts.Count, model.TokenCounts.Count);
        for (int i = 0; i < expectedTokenCounts.Count; i++)
        {
            Assert.Equal(expectedTokenCounts[i], model.TokenCounts[i]);
        }
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CollectionCountTokensResponse
        {
            MaxTokenLimit = 0,
            TextsExceedingLimit = 0,
            TokenCounts =
            [
                new()
                {
                    CharCount = 0,
                    ExceedsLimit = true,
                    Index = 0,
                    TokenCountValue = 0,
                },
            ],
            TotalTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionCountTokensResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CollectionCountTokensResponse
        {
            MaxTokenLimit = 0,
            TextsExceedingLimit = 0,
            TokenCounts =
            [
                new()
                {
                    CharCount = 0,
                    ExceedsLimit = true,
                    Index = 0,
                    TokenCountValue = 0,
                },
            ],
            TotalTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionCountTokensResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMaxTokenLimit = 0;
        long expectedTextsExceedingLimit = 0;
        List<TokenCount> expectedTokenCounts =
        [
            new()
            {
                CharCount = 0,
                ExceedsLimit = true,
                Index = 0,
                TokenCountValue = 0,
            },
        ];
        long expectedTotalTokens = 0;

        Assert.Equal(expectedMaxTokenLimit, deserialized.MaxTokenLimit);
        Assert.Equal(expectedTextsExceedingLimit, deserialized.TextsExceedingLimit);
        Assert.NotNull(deserialized.TokenCounts);
        Assert.Equal(expectedTokenCounts.Count, deserialized.TokenCounts.Count);
        for (int i = 0; i < expectedTokenCounts.Count; i++)
        {
            Assert.Equal(expectedTokenCounts[i], deserialized.TokenCounts[i]);
        }
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CollectionCountTokensResponse
        {
            MaxTokenLimit = 0,
            TextsExceedingLimit = 0,
            TokenCounts =
            [
                new()
                {
                    CharCount = 0,
                    ExceedsLimit = true,
                    Index = 0,
                    TokenCountValue = 0,
                },
            ],
            TotalTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CollectionCountTokensResponse { };

        Assert.Null(model.MaxTokenLimit);
        Assert.False(model.RawData.ContainsKey("max_token_limit"));
        Assert.Null(model.TextsExceedingLimit);
        Assert.False(model.RawData.ContainsKey("texts_exceeding_limit"));
        Assert.Null(model.TokenCounts);
        Assert.False(model.RawData.ContainsKey("token_counts"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CollectionCountTokensResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CollectionCountTokensResponse
        {
            // Null should be interpreted as omitted for these properties
            MaxTokenLimit = null,
            TextsExceedingLimit = null,
            TokenCounts = null,
            TotalTokens = null,
        };

        Assert.Null(model.MaxTokenLimit);
        Assert.False(model.RawData.ContainsKey("max_token_limit"));
        Assert.Null(model.TextsExceedingLimit);
        Assert.False(model.RawData.ContainsKey("texts_exceeding_limit"));
        Assert.Null(model.TokenCounts);
        Assert.False(model.RawData.ContainsKey("token_counts"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CollectionCountTokensResponse
        {
            // Null should be interpreted as omitted for these properties
            MaxTokenLimit = null,
            TextsExceedingLimit = null,
            TokenCounts = null,
            TotalTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CollectionCountTokensResponse
        {
            MaxTokenLimit = 0,
            TextsExceedingLimit = 0,
            TokenCounts =
            [
                new()
                {
                    CharCount = 0,
                    ExceedsLimit = true,
                    Index = 0,
                    TokenCountValue = 0,
                },
            ],
            TotalTokens = 0,
        };

        CollectionCountTokensResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TokenCountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TokenCount
        {
            CharCount = 0,
            ExceedsLimit = true,
            Index = 0,
            TokenCountValue = 0,
        };

        long expectedCharCount = 0;
        bool expectedExceedsLimit = true;
        long expectedIndex = 0;
        long expectedTokenCountValue = 0;

        Assert.Equal(expectedCharCount, model.CharCount);
        Assert.Equal(expectedExceedsLimit, model.ExceedsLimit);
        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedTokenCountValue, model.TokenCountValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TokenCount
        {
            CharCount = 0,
            ExceedsLimit = true,
            Index = 0,
            TokenCountValue = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenCount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TokenCount
        {
            CharCount = 0,
            ExceedsLimit = true,
            Index = 0,
            TokenCountValue = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenCount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCharCount = 0;
        bool expectedExceedsLimit = true;
        long expectedIndex = 0;
        long expectedTokenCountValue = 0;

        Assert.Equal(expectedCharCount, deserialized.CharCount);
        Assert.Equal(expectedExceedsLimit, deserialized.ExceedsLimit);
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedTokenCountValue, deserialized.TokenCountValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TokenCount
        {
            CharCount = 0,
            ExceedsLimit = true,
            Index = 0,
            TokenCountValue = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TokenCount { };

        Assert.Null(model.CharCount);
        Assert.False(model.RawData.ContainsKey("char_count"));
        Assert.Null(model.ExceedsLimit);
        Assert.False(model.RawData.ContainsKey("exceeds_limit"));
        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
        Assert.Null(model.TokenCountValue);
        Assert.False(model.RawData.ContainsKey("token_count"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TokenCount { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TokenCount
        {
            // Null should be interpreted as omitted for these properties
            CharCount = null,
            ExceedsLimit = null,
            Index = null,
            TokenCountValue = null,
        };

        Assert.Null(model.CharCount);
        Assert.False(model.RawData.ContainsKey("char_count"));
        Assert.Null(model.ExceedsLimit);
        Assert.False(model.RawData.ContainsKey("exceeds_limit"));
        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
        Assert.Null(model.TokenCountValue);
        Assert.False(model.RawData.ContainsKey("token_count"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TokenCount
        {
            // Null should be interpreted as omitted for these properties
            CharCount = null,
            ExceedsLimit = null,
            Index = null,
            TokenCountValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TokenCount
        {
            CharCount = 0,
            ExceedsLimit = true,
            Index = 0,
            TokenCountValue = 0,
        };

        TokenCount copied = new(model);

        Assert.Equal(model, copied);
    }
}
