using System.Text.Json;
using Bem.Core;
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
            Op = FsOp.Ls,
            Count = 0,
            HasMore = true,
            Hint = "hint",
            NextCursor = "nextCursor",
        };

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, FsOp> expectedOp = FsOp.Ls;
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
            Op = FsOp.Ls,
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
            Op = FsOp.Ls,
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
        ApiEnum<string, FsOp> expectedOp = FsOp.Ls;
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
            Op = FsOp.Ls,
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
            Op = FsOp.Ls,
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
            Op = FsOp.Ls,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FNavigateResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Op = FsOp.Ls,

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
            Op = FsOp.Ls,

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
            Op = FsOp.Ls,
            Count = 0,
            HasMore = true,
            Hint = "hint",
            NextCursor = "nextCursor",
        };

        FNavigateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
