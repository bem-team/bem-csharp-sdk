using System;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Events;

namespace Bem.Tests.Models.Events;

public class EventSubmitFeedbackResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventSubmitFeedbackResponse
        {
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
            FunctionType = FunctionType.Extract,
        };

        JsonElement expectedCorrection = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventID = "eventID";
        ApiEnum<string, FunctionType> expectedFunctionType = FunctionType.Extract;

        Assert.True(JsonElement.DeepEquals(expectedCorrection, model.Correction));
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedFunctionType, model.FunctionType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventSubmitFeedbackResponse
        {
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
            FunctionType = FunctionType.Extract,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventSubmitFeedbackResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventSubmitFeedbackResponse
        {
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
            FunctionType = FunctionType.Extract,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventSubmitFeedbackResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedCorrection = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventID = "eventID";
        ApiEnum<string, FunctionType> expectedFunctionType = FunctionType.Extract;

        Assert.True(JsonElement.DeepEquals(expectedCorrection, deserialized.Correction));
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedFunctionType, deserialized.FunctionType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventSubmitFeedbackResponse
        {
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
            FunctionType = FunctionType.Extract,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventSubmitFeedbackResponse
        {
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
            FunctionType = FunctionType.Extract,
        };

        EventSubmitFeedbackResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionTypeTest : TestBase
{
    [Theory]
    [InlineData(FunctionType.Extract)]
    [InlineData(FunctionType.Classify)]
    [InlineData(FunctionType.Join)]
    public void Validation_Works(FunctionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionType.Extract)]
    [InlineData(FunctionType.Classify)]
    [InlineData(FunctionType.Join)]
    public void SerializationRoundtrip_Works(FunctionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
