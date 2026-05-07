using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;
using Bem.Models.Webhooks;

namespace Bem.Tests.Models.Webhooks;

public class CollectionProcessingWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingWebhookEventEventType.CollectionProcessing,
            FunctionCallTryNumber = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
        };

        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        string expectedEventID = "eventID";
        ApiEnum<string, Operation> expectedOperation = Operation.Add;
        long expectedProcessedCount = 0;
        string expectedReferenceID = "referenceID";
        ApiEnum<string, CollectionProcessingWebhookEventStatus> expectedStatus =
            CollectionProcessingWebhookEventStatus.Success;
        List<string> expectedCollectionItemIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        ApiEnum<string, CollectionProcessingWebhookEventEventType> expectedEventType =
            CollectionProcessingWebhookEventEventType.CollectionProcessing;
        long expectedFunctionCallTryNumber = 0;
        InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        CollectionProcessingWebhookEventMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };

        Assert.Equal(expectedCollectionID, model.CollectionID);
        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedOperation, model.Operation);
        Assert.Equal(expectedProcessedCount, model.ProcessedCount);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.CollectionItemIds);
        Assert.Equal(expectedCollectionItemIds.Count, model.CollectionItemIds.Count);
        for (int i = 0; i < expectedCollectionItemIds.Count; i++)
        {
            Assert.Equal(expectedCollectionItemIds[i], model.CollectionItemIds[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedFunctionCallTryNumber, model.FunctionCallTryNumber);
        Assert.Equal(expectedInboundEmail, model.InboundEmail);
        Assert.Equal(expectedMetadata, model.Metadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingWebhookEventEventType.CollectionProcessing,
            FunctionCallTryNumber = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionProcessingWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingWebhookEventEventType.CollectionProcessing,
            FunctionCallTryNumber = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionProcessingWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        string expectedEventID = "eventID";
        ApiEnum<string, Operation> expectedOperation = Operation.Add;
        long expectedProcessedCount = 0;
        string expectedReferenceID = "referenceID";
        ApiEnum<string, CollectionProcessingWebhookEventStatus> expectedStatus =
            CollectionProcessingWebhookEventStatus.Success;
        List<string> expectedCollectionItemIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        ApiEnum<string, CollectionProcessingWebhookEventEventType> expectedEventType =
            CollectionProcessingWebhookEventEventType.CollectionProcessing;
        long expectedFunctionCallTryNumber = 0;
        InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        CollectionProcessingWebhookEventMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };

        Assert.Equal(expectedCollectionID, deserialized.CollectionID);
        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedOperation, deserialized.Operation);
        Assert.Equal(expectedProcessedCount, deserialized.ProcessedCount);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.CollectionItemIds);
        Assert.Equal(expectedCollectionItemIds.Count, deserialized.CollectionItemIds.Count);
        for (int i = 0; i < expectedCollectionItemIds.Count; i++)
        {
            Assert.Equal(expectedCollectionItemIds[i], deserialized.CollectionItemIds[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedFunctionCallTryNumber, deserialized.FunctionCallTryNumber);
        Assert.Equal(expectedInboundEmail, deserialized.InboundEmail);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingWebhookEventEventType.CollectionProcessing,
            FunctionCallTryNumber = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,
        };

        Assert.Null(model.CollectionItemIds);
        Assert.False(model.RawData.ContainsKey("collectionItemIDs"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("eventType"));
        Assert.Null(model.FunctionCallTryNumber);
        Assert.False(model.RawData.ContainsKey("functionCallTryNumber"));
        Assert.Null(model.InboundEmail);
        Assert.False(model.RawData.ContainsKey("inboundEmail"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,

            // Null should be interpreted as omitted for these properties
            CollectionItemIds = null,
            CreatedAt = null,
            ErrorMessage = null,
            EventType = null,
            FunctionCallTryNumber = null,
            InboundEmail = null,
            Metadata = null,
        };

        Assert.Null(model.CollectionItemIds);
        Assert.False(model.RawData.ContainsKey("collectionItemIDs"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("eventType"));
        Assert.Null(model.FunctionCallTryNumber);
        Assert.False(model.RawData.ContainsKey("functionCallTryNumber"));
        Assert.Null(model.InboundEmail);
        Assert.False(model.RawData.ContainsKey("inboundEmail"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,

            // Null should be interpreted as omitted for these properties
            CollectionItemIds = null,
            CreatedAt = null,
            ErrorMessage = null,
            EventType = null,
            FunctionCallTryNumber = null,
            InboundEmail = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CollectionProcessingWebhookEvent
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = CollectionProcessingWebhookEventStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingWebhookEventEventType.CollectionProcessing,
            FunctionCallTryNumber = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
        };

        CollectionProcessingWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OperationTest : TestBase
{
    [Theory]
    [InlineData(Operation.Add)]
    [InlineData(Operation.Update)]
    public void Validation_Works(Operation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operation.Add)]
    [InlineData(Operation.Update)]
    public void SerializationRoundtrip_Works(Operation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CollectionProcessingWebhookEventStatusTest : TestBase
{
    [Theory]
    [InlineData(CollectionProcessingWebhookEventStatus.Success)]
    [InlineData(CollectionProcessingWebhookEventStatus.Failed)]
    public void Validation_Works(CollectionProcessingWebhookEventStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CollectionProcessingWebhookEventStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingWebhookEventStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CollectionProcessingWebhookEventStatus.Success)]
    [InlineData(CollectionProcessingWebhookEventStatus.Failed)]
    public void SerializationRoundtrip_Works(CollectionProcessingWebhookEventStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CollectionProcessingWebhookEventStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingWebhookEventStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingWebhookEventStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingWebhookEventStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CollectionProcessingWebhookEventEventTypeTest : TestBase
{
    [Theory]
    [InlineData(CollectionProcessingWebhookEventEventType.CollectionProcessing)]
    public void Validation_Works(CollectionProcessingWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CollectionProcessingWebhookEventEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingWebhookEventEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CollectionProcessingWebhookEventEventType.CollectionProcessing)]
    public void SerializationRoundtrip_Works(CollectionProcessingWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CollectionProcessingWebhookEventEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingWebhookEventEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CollectionProcessingWebhookEventMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionProcessingWebhookEventMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionProcessingWebhookEventMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(
            expectedDurationFunctionToEventSeconds,
            deserialized.DurationFunctionToEventSeconds
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CollectionProcessingWebhookEventMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        CollectionProcessingWebhookEventMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
