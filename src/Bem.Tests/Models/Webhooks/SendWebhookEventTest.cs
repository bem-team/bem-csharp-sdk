using System;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;
using Bem.Models.Functions;
using Bem.Models.Webhooks;

namespace Bem.Tests.Models.Webhooks;

public class SendWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = SendWebhookEventEventType.Send,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            GoogleDriveOutput = new() { FileName = "fileName", FolderID = "folderID" },
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Output = new() { BucketName = "bucketName", Key = "key" },
            WebhookOutput = new() { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        ApiEnum<string, DeliveryStatus> expectedDeliveryStatus = DeliveryStatus.Success;
        ApiEnum<string, SendDestinationType> expectedDestinationType = SendDestinationType.Webhook;
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedDeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, SendWebhookEventEventType> expectedEventType =
            SendWebhookEventEventType.Send;
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        GoogleDriveOutput expectedGoogleDriveOutput = new()
        {
            FileName = "fileName",
            FolderID = "folderID",
        };
        InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        SendWebhookEventMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        S3Output expectedS3Output = new() { BucketName = "bucketName", Key = "key" };
        WebhookOutput expectedWebhookOutput = new()
        {
            HttpResponseBody = "httpResponseBody",
            HttpStatusCode = 0,
        };
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedDeliveryStatus, model.DeliveryStatus);
        Assert.Equal(expectedDestinationType, model.DestinationType);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.DeliveredContent);
        Assert.True(JsonElement.DeepEquals(expectedDeliveredContent, model.DeliveredContent.Value));
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedFunctionCallID, model.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, model.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, model.FunctionVersionNum);
        Assert.Equal(expectedGoogleDriveOutput, model.GoogleDriveOutput);
        Assert.Equal(expectedInboundEmail, model.InboundEmail);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedS3Output, model.S3Output);
        Assert.Equal(expectedWebhookOutput, model.WebhookOutput);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = SendWebhookEventEventType.Send,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            GoogleDriveOutput = new() { FileName = "fileName", FolderID = "folderID" },
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Output = new() { BucketName = "bucketName", Key = "key" },
            WebhookOutput = new() { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = SendWebhookEventEventType.Send,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            GoogleDriveOutput = new() { FileName = "fileName", FolderID = "folderID" },
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Output = new() { BucketName = "bucketName", Key = "key" },
            WebhookOutput = new() { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DeliveryStatus> expectedDeliveryStatus = DeliveryStatus.Success;
        ApiEnum<string, SendDestinationType> expectedDestinationType = SendDestinationType.Webhook;
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedDeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, SendWebhookEventEventType> expectedEventType =
            SendWebhookEventEventType.Send;
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        GoogleDriveOutput expectedGoogleDriveOutput = new()
        {
            FileName = "fileName",
            FolderID = "folderID",
        };
        InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        SendWebhookEventMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        S3Output expectedS3Output = new() { BucketName = "bucketName", Key = "key" };
        WebhookOutput expectedWebhookOutput = new()
        {
            HttpResponseBody = "httpResponseBody",
            HttpStatusCode = 0,
        };
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedDeliveryStatus, deserialized.DeliveryStatus);
        Assert.Equal(expectedDestinationType, deserialized.DestinationType);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.DeliveredContent);
        Assert.True(
            JsonElement.DeepEquals(expectedDeliveredContent, deserialized.DeliveredContent.Value)
        );
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedFunctionCallID, deserialized.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, deserialized.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, deserialized.FunctionVersionNum);
        Assert.Equal(expectedGoogleDriveOutput, deserialized.GoogleDriveOutput);
        Assert.Equal(expectedInboundEmail, deserialized.InboundEmail);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedS3Output, deserialized.S3Output);
        Assert.Equal(expectedWebhookOutput, deserialized.WebhookOutput);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = SendWebhookEventEventType.Send,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            GoogleDriveOutput = new() { FileName = "fileName", FolderID = "folderID" },
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Output = new() { BucketName = "bucketName", Key = "key" },
            WebhookOutput = new() { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("callID"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DeliveredContent);
        Assert.False(model.RawData.ContainsKey("deliveredContent"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("eventType"));
        Assert.Null(model.FunctionCallID);
        Assert.False(model.RawData.ContainsKey("functionCallID"));
        Assert.Null(model.FunctionCallTryNumber);
        Assert.False(model.RawData.ContainsKey("functionCallTryNumber"));
        Assert.Null(model.FunctionVersionNum);
        Assert.False(model.RawData.ContainsKey("functionVersionNum"));
        Assert.Null(model.GoogleDriveOutput);
        Assert.False(model.RawData.ContainsKey("googleDriveOutput"));
        Assert.Null(model.InboundEmail);
        Assert.False(model.RawData.ContainsKey("inboundEmail"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.S3Output);
        Assert.False(model.RawData.ContainsKey("s3Output"));
        Assert.Null(model.WebhookOutput);
        Assert.False(model.RawData.ContainsKey("webhookOutput"));
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
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
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
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            DeliveredContent = null,
            EventType = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            GoogleDriveOutput = null,
            InboundEmail = null,
            Metadata = null,
            S3Output = null,
            WebhookOutput = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("callID"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DeliveredContent);
        Assert.False(model.RawData.ContainsKey("deliveredContent"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("eventType"));
        Assert.Null(model.FunctionCallID);
        Assert.False(model.RawData.ContainsKey("functionCallID"));
        Assert.Null(model.FunctionCallTryNumber);
        Assert.False(model.RawData.ContainsKey("functionCallTryNumber"));
        Assert.Null(model.FunctionVersionNum);
        Assert.False(model.RawData.ContainsKey("functionVersionNum"));
        Assert.Null(model.GoogleDriveOutput);
        Assert.False(model.RawData.ContainsKey("googleDriveOutput"));
        Assert.Null(model.InboundEmail);
        Assert.False(model.RawData.ContainsKey("inboundEmail"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.S3Output);
        Assert.False(model.RawData.ContainsKey("s3Output"));
        Assert.Null(model.WebhookOutput);
        Assert.False(model.RawData.ContainsKey("webhookOutput"));
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
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            DeliveredContent = null,
            EventType = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            GoogleDriveOutput = null,
            InboundEmail = null,
            Metadata = null,
            S3Output = null,
            WebhookOutput = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendWebhookEvent
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = SendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = SendWebhookEventEventType.Send,
            FunctionCallID = "functionCallID",
            FunctionCallTryNumber = 0,
            FunctionVersionNum = 0,
            GoogleDriveOutput = new() { FileName = "fileName", FolderID = "folderID" },
            InboundEmail = new()
            {
                From = "from",
                Subject = "subject",
                To = "to",
                DeliveredTo = "deliveredTo",
            },
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Output = new() { BucketName = "bucketName", Key = "key" },
            WebhookOutput = new() { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        SendWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeliveryStatusTest : TestBase
{
    [Theory]
    [InlineData(DeliveryStatus.Success)]
    [InlineData(DeliveryStatus.Skip)]
    public void Validation_Works(DeliveryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeliveryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeliveryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeliveryStatus.Success)]
    [InlineData(DeliveryStatus.Skip)]
    public void SerializationRoundtrip_Works(DeliveryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeliveryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeliveryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeliveryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeliveryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SendWebhookEventEventTypeTest : TestBase
{
    [Theory]
    [InlineData(SendWebhookEventEventType.Send)]
    public void Validation_Works(SendWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SendWebhookEventEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SendWebhookEventEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SendWebhookEventEventType.Send)]
    public void SerializationRoundtrip_Works(SendWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SendWebhookEventEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SendWebhookEventEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SendWebhookEventEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SendWebhookEventEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GoogleDriveOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleDriveOutput { FileName = "fileName", FolderID = "folderID" };

        string expectedFileName = "fileName";
        string expectedFolderID = "folderID";

        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedFolderID, model.FolderID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleDriveOutput { FileName = "fileName", FolderID = "folderID" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleDriveOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleDriveOutput { FileName = "fileName", FolderID = "folderID" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleDriveOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileName = "fileName";
        string expectedFolderID = "folderID";

        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedFolderID, deserialized.FolderID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleDriveOutput { FileName = "fileName", FolderID = "folderID" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleDriveOutput { FileName = "fileName", FolderID = "folderID" };

        GoogleDriveOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SendWebhookEventMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendWebhookEventMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendWebhookEventMetadata>(
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
        var model = new SendWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SendWebhookEventMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SendWebhookEventMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SendWebhookEventMetadata
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
        var model = new SendWebhookEventMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        SendWebhookEventMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class S3OutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new S3Output { BucketName = "bucketName", Key = "key" };

        string expectedBucketName = "bucketName";
        string expectedKey = "key";

        Assert.Equal(expectedBucketName, model.BucketName);
        Assert.Equal(expectedKey, model.Key);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new S3Output { BucketName = "bucketName", Key = "key" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<S3Output>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new S3Output { BucketName = "bucketName", Key = "key" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<S3Output>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucketName = "bucketName";
        string expectedKey = "key";

        Assert.Equal(expectedBucketName, deserialized.BucketName);
        Assert.Equal(expectedKey, deserialized.Key);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new S3Output { BucketName = "bucketName", Key = "key" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new S3Output { BucketName = "bucketName", Key = "key" };

        S3Output copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookOutput { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 };

        string expectedHttpResponseBody = "httpResponseBody";
        long expectedHttpStatusCode = 0;

        Assert.Equal(expectedHttpResponseBody, model.HttpResponseBody);
        Assert.Equal(expectedHttpStatusCode, model.HttpStatusCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookOutput { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookOutput { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedHttpResponseBody = "httpResponseBody";
        long expectedHttpStatusCode = 0;

        Assert.Equal(expectedHttpResponseBody, deserialized.HttpResponseBody);
        Assert.Equal(expectedHttpStatusCode, deserialized.HttpStatusCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookOutput { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookOutput { HttpResponseBody = "httpResponseBody", HttpStatusCode = 0 };

        WebhookOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}
