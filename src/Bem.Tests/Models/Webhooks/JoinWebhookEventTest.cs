using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;
using Bem.Models.Webhooks;

namespace Bem.Tests.Models.Webhooks;

public class JoinWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        List<string> expectedInvalidProperties = ["string"];
        List<JoinWebhookEventItem> expectedItems =
        [
            new()
            {
                ItemCount = 0,
                ItemOffset = 0,
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, JoinType> expectedJoinType = JoinType.Standard;
        string expectedReferenceID = "referenceID";
        JsonElement expectedTransformedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        float expectedAvgConfidence = 0;
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, JoinWebhookEventEventType> expectedEventType =
            JoinWebhookEventEventType.Join;
        JsonElement expectedFieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}");
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
        JoinWebhookEventMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        string expectedTransformationID = "transformationID";
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedInvalidProperties.Count, model.InvalidProperties.Count);
        for (int i = 0; i < expectedInvalidProperties.Count; i++)
        {
            Assert.Equal(expectedInvalidProperties[i], model.InvalidProperties[i]);
        }
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedJoinType, model.JoinType);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.True(JsonElement.DeepEquals(expectedTransformedContent, model.TransformedContent));
        Assert.Equal(expectedAvgConfidence, model.AvgConfidence);
        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.NotNull(model.FieldConfidences);
        Assert.True(JsonElement.DeepEquals(expectedFieldConfidences, model.FieldConfidences.Value));
        Assert.Equal(expectedFunctionCallID, model.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, model.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, model.FunctionVersionNum);
        Assert.Equal(expectedInboundEmail, model.InboundEmail);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedTransformationID, model.TransformationID);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        List<string> expectedInvalidProperties = ["string"];
        List<JoinWebhookEventItem> expectedItems =
        [
            new()
            {
                ItemCount = 0,
                ItemOffset = 0,
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, JoinType> expectedJoinType = JoinType.Standard;
        string expectedReferenceID = "referenceID";
        JsonElement expectedTransformedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        float expectedAvgConfidence = 0;
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, JoinWebhookEventEventType> expectedEventType =
            JoinWebhookEventEventType.Join;
        JsonElement expectedFieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}");
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
        JoinWebhookEventMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        string expectedTransformationID = "transformationID";
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedInvalidProperties.Count, deserialized.InvalidProperties.Count);
        for (int i = 0; i < expectedInvalidProperties.Count; i++)
        {
            Assert.Equal(expectedInvalidProperties[i], deserialized.InvalidProperties[i]);
        }
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedJoinType, deserialized.JoinType);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.True(
            JsonElement.DeepEquals(expectedTransformedContent, deserialized.TransformedContent)
        );
        Assert.Equal(expectedAvgConfidence, deserialized.AvgConfidence);
        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.NotNull(deserialized.FieldConfidences);
        Assert.True(
            JsonElement.DeepEquals(expectedFieldConfidences, deserialized.FieldConfidences.Value)
        );
        Assert.Equal(expectedFunctionCallID, deserialized.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, deserialized.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, deserialized.FunctionVersionNum);
        Assert.Equal(expectedInboundEmail, deserialized.InboundEmail);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedTransformationID, deserialized.TransformationID);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("callID"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("eventType"));
        Assert.Null(model.FieldConfidences);
        Assert.False(model.RawData.ContainsKey("fieldConfidences"));
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
        Assert.Null(model.TransformationID);
        Assert.False(model.RawData.ContainsKey("transformationID"));
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
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            EventType = null,
            FieldConfidences = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            InboundEmail = null,
            Metadata = null,
            TransformationID = null,
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
        Assert.Null(model.FieldConfidences);
        Assert.False(model.RawData.ContainsKey("fieldConfidences"));
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
        Assert.Null(model.TransformationID);
        Assert.False(model.RawData.ContainsKey("transformationID"));
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
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            EventType = null,
            FieldConfidences = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            InboundEmail = null,
            Metadata = null,
            TransformationID = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        Assert.Null(model.AvgConfidence);
        Assert.False(model.RawData.ContainsKey("avgConfidence"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,

            AvgConfidence = null,
        };

        Assert.Null(model.AvgConfidence);
        Assert.True(model.RawData.ContainsKey("avgConfidence"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,

            AvgConfidence = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JoinWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            InvalidProperties = ["string"],
            Items =
            [
                new()
                {
                    ItemCount = 0,
                    ItemOffset = 0,
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            JoinType = JoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = JoinWebhookEventEventType.Join,
            FieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        JoinWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JoinWebhookEventItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        long expectedItemCount = 0;
        long expectedItemOffset = 0;
        string expectedItemReferenceID = "itemReferenceID";
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedItemCount, model.ItemCount);
        Assert.Equal(expectedItemOffset, model.ItemOffset);
        Assert.Equal(expectedItemReferenceID, model.ItemReferenceID);
        Assert.Equal(expectedS3Url, model.S3Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinWebhookEventItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinWebhookEventItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedItemCount = 0;
        long expectedItemOffset = 0;
        string expectedItemReferenceID = "itemReferenceID";
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedItemCount, deserialized.ItemCount);
        Assert.Equal(expectedItemOffset, deserialized.ItemOffset);
        Assert.Equal(expectedItemReferenceID, deserialized.ItemReferenceID);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
        };

        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",

            // Null should be interpreted as omitted for these properties
            S3Url = null,
        };

        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",

            // Null should be interpreted as omitted for these properties
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JoinWebhookEventItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        JoinWebhookEventItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JoinTypeTest : TestBase
{
    [Theory]
    [InlineData(JoinType.Standard)]
    public void Validation_Works(JoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JoinType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JoinType.Standard)]
    public void SerializationRoundtrip_Works(JoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JoinType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JoinType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JoinType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JoinWebhookEventEventTypeTest : TestBase
{
    [Theory]
    [InlineData(JoinWebhookEventEventType.Join)]
    public void Validation_Works(JoinWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JoinWebhookEventEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JoinWebhookEventEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JoinWebhookEventEventType.Join)]
    public void SerializationRoundtrip_Works(JoinWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JoinWebhookEventEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JoinWebhookEventEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JoinWebhookEventEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JoinWebhookEventEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JoinWebhookEventMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JoinWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JoinWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinWebhookEventMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JoinWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinWebhookEventMetadata>(
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
        var model = new JoinWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JoinWebhookEventMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JoinWebhookEventMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JoinWebhookEventMetadata
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
        var model = new JoinWebhookEventMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JoinWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        JoinWebhookEventMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
