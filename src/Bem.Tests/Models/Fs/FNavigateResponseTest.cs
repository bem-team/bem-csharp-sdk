using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Fs;

namespace Bem.Tests.Models.Fs;

public class FNavigateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,
            Count = 0,
            HasMore = true,
            Hint = "hint",
            NextCursor = "nextCursor",
        };

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, FNavigateResponseOp> expectedOp = FNavigateResponseOp.Ls;
        long expectedCount = 0;
        bool expectedHasMore = true;
        string expectedHint = "hint";
        string expectedNextCursor = "nextCursor";

        Assert.True(JsonElement.DeepEquals(expectedData, model.Data));
        Assert.Equal(expectedOp, model.Op);
        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedHint, model.Hint);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,
            Count = 0,
            HasMore = true,
            Hint = "hint",
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FNavigateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,
            Count = 0,
            HasMore = true,
            Hint = "hint",
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FNavigateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, FNavigateResponseOp> expectedOp = FNavigateResponseOp.Ls;
        long expectedCount = 0;
        bool expectedHasMore = true;
        string expectedHint = "hint";
        string expectedNextCursor = "nextCursor";

        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data));
        Assert.Equal(expectedOp, deserialized.Op);
        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedHint, deserialized.Hint);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,
            Count = 0,
            HasMore = true,
            Hint = "hint",
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,
        };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("hasMore"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,

            // Null should be interpreted as omitted for these properties
            Count = null,
            HasMore = null,
            Hint = null,
            NextCursor = null,
        };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("hasMore"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,

            // Null should be interpreted as omitted for these properties
            Count = null,
            HasMore = null,
            Hint = null,
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FNavigateResponseOp.Ls,
            Count = 0,
            HasMore = true,
            Hint = "hint",
            NextCursor = "nextCursor",
        };

        FNavigateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FNavigateResponseOpTest : TestBase
{
    [Theory]
    [InlineData(FNavigateResponseOp.Ls)]
    [InlineData(FNavigateResponseOp.Find)]
    [InlineData(FNavigateResponseOp.Open)]
    [InlineData(FNavigateResponseOp.Cat)]
    [InlineData(FNavigateResponseOp.Grep)]
    [InlineData(FNavigateResponseOp.Xref)]
    [InlineData(FNavigateResponseOp.Stat)]
    [InlineData(FNavigateResponseOp.Head)]
    public void Validation_Works(FNavigateResponseOp rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FNavigateResponseOp> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FNavigateResponseOp>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FNavigateResponseOp.Ls)]
    [InlineData(FNavigateResponseOp.Find)]
    [InlineData(FNavigateResponseOp.Open)]
    [InlineData(FNavigateResponseOp.Cat)]
    [InlineData(FNavigateResponseOp.Grep)]
    [InlineData(FNavigateResponseOp.Xref)]
    [InlineData(FNavigateResponseOp.Stat)]
    [InlineData(FNavigateResponseOp.Head)]
    public void SerializationRoundtrip_Works(FNavigateResponseOp rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FNavigateResponseOp> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FNavigateResponseOp>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FNavigateResponseOp>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FNavigateResponseOp>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
