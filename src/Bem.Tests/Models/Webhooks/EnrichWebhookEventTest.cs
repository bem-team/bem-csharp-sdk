using System;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;
using Bem.Models.Webhooks;

namespace Bem.Tests.Models.Webhooks;

public class EnrichWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichWebhookEventEventType.Enrich,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        JsonElement expectedEnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EnrichWebhookEventEventType> expectedEventType =
            EnrichWebhookEventEventType.Enrich;
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        EnrichWebhookEventMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.True(JsonElement.DeepEquals(expectedEnrichedContent, model.EnrichedContent));
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedFunctionCallID, model.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, model.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, model.FunctionVersionNum);
        Assert.Equal(expectedInboundEmail, model.InboundEmail);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichWebhookEventEventType.Enrich,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichWebhookEventEventType.Enrich,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedEnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EnrichWebhookEventEventType> expectedEventType =
            EnrichWebhookEventEventType.Enrich;
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        EnrichWebhookEventMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.True(JsonElement.DeepEquals(expectedEnrichedContent, deserialized.EnrichedContent));
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedFunctionCallID, deserialized.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, deserialized.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, deserialized.FunctionVersionNum);
        Assert.Equal(expectedInboundEmail, deserialized.InboundEmail);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichWebhookEventEventType.Enrich,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("callID"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("eventType"));
        Assert.Null(model.FunctionCallID);
        Assert.False(model.RawData.ContainsKey("functionCallID"));
        Assert.Null(model.FunctionCallTryNumber);
        Assert.False(model.RawData.ContainsKey("functionCallTryNumber"));
        Assert.Null(model.FunctionVersionNum);
        Assert.False(model.RawData.ContainsKey("functionVersionNum"));
        Assert.Null(model.InboundEmail);
        Assert.False(model.RawData.ContainsKey("inboundEmail"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.WorkflowID);
        Assert.False(model.RawData.ContainsKey("workflowID"));
        Assert.Null(model.WorkflowName);
        Assert.False(model.RawData.ContainsKey("workflowName"));
        Assert.Null(model.WorkflowVersionNum);
        Assert.False(model.RawData.ContainsKey("workflowVersionNum"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            EventType = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            InboundEmail = null,
            Metadata = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("callID"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("eventType"));
        Assert.Null(model.FunctionCallID);
        Assert.False(model.RawData.ContainsKey("functionCallID"));
        Assert.Null(model.FunctionCallTryNumber);
        Assert.False(model.RawData.ContainsKey("functionCallTryNumber"));
        Assert.Null(model.FunctionVersionNum);
        Assert.False(model.RawData.ContainsKey("functionVersionNum"));
        Assert.Null(model.InboundEmail);
        Assert.False(model.RawData.ContainsKey("inboundEmail"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.WorkflowID);
        Assert.False(model.RawData.ContainsKey("workflowID"));
        Assert.Null(model.WorkflowName);
        Assert.False(model.RawData.ContainsKey("workflowName"));
        Assert.Null(model.WorkflowVersionNum);
        Assert.False(model.RawData.ContainsKey("workflowVersionNum"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            EventType = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            InboundEmail = null,
            Metadata = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EnrichWebhookEvent
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichWebhookEventEventType.Enrich,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        EnrichWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EnrichWebhookEventEventTypeTest : TestBase
{
    [Theory]
    [InlineData(EnrichWebhookEventEventType.Enrich)]
    public void Validation_Works(EnrichWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EnrichWebhookEventEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EnrichWebhookEventEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EnrichWebhookEventEventType.Enrich)]
    public void SerializationRoundtrip_Works(EnrichWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EnrichWebhookEventEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EnrichWebhookEventEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EnrichWebhookEventEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EnrichWebhookEventEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EnrichWebhookEventMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnrichWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnrichWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichWebhookEventMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EnrichWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichWebhookEventMetadata>(
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
        var model = new EnrichWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EnrichWebhookEventMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EnrichWebhookEventMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EnrichWebhookEventMetadata
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
        var model = new EnrichWebhookEventMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EnrichWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        EnrichWebhookEventMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
