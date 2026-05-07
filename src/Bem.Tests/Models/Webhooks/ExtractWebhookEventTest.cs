using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Webhooks;
using Errors = Bem.Models.Errors;
using Outputs = Bem.Models.Outputs;

namespace Bem.Tests.Models.Webhooks;

public class ExtractWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        long expectedItemCount = 0;
        long expectedItemOffset = 0;
        string expectedReferenceID = "referenceID";
        JsonElement expectedTransformedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        float expectedAvgConfidence = 0;
        string expectedCallID = "callID";
        CorrectedContent expectedCorrectedContent = new Output()
        {
            OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EventType> expectedEventType = EventType.Extract;
        JsonElement expectedFieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedFieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        Errors::InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        List<Input> expectedInputs =
        [
            new()
            {
                InputContent = "inputContent",
                InputType = "inputType",
                JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, Outputs::InputType> expectedInputType = Outputs::InputType.Csv;
        List<string> expectedInvalidProperties = ["string"];
        Metadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        string expectedS3Url = "s3URL";
        string expectedTransformationID = "transformationID";
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedItemCount, model.ItemCount);
        Assert.Equal(expectedItemOffset, model.ItemOffset);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.True(JsonElement.DeepEquals(expectedTransformedContent, model.TransformedContent));
        Assert.Equal(expectedAvgConfidence, model.AvgConfidence);
        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedCorrectedContent, model.CorrectedContent);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.NotNull(model.FieldBoundingBoxes);
        Assert.True(
            JsonElement.DeepEquals(expectedFieldBoundingBoxes, model.FieldBoundingBoxes.Value)
        );
        Assert.NotNull(model.FieldConfidences);
        Assert.True(JsonElement.DeepEquals(expectedFieldConfidences, model.FieldConfidences.Value));
        Assert.Equal(expectedFunctionCallID, model.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, model.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, model.FunctionVersionNum);
        Assert.Equal(expectedInboundEmail, model.InboundEmail);
        Assert.NotNull(model.Inputs);
        Assert.Equal(expectedInputs.Count, model.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], model.Inputs[i]);
        }
        Assert.Equal(expectedInputType, model.InputType);
        Assert.NotNull(model.InvalidProperties);
        Assert.Equal(expectedInvalidProperties.Count, model.InvalidProperties.Count);
        for (int i = 0; i < expectedInvalidProperties.Count; i++)
        {
            Assert.Equal(expectedInvalidProperties[i], model.InvalidProperties[i]);
        }
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedS3Url, model.S3Url);
        Assert.Equal(expectedTransformationID, model.TransformationID);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        long expectedItemCount = 0;
        long expectedItemOffset = 0;
        string expectedReferenceID = "referenceID";
        JsonElement expectedTransformedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        float expectedAvgConfidence = 0;
        string expectedCallID = "callID";
        CorrectedContent expectedCorrectedContent = new Output()
        {
            OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EventType> expectedEventType = EventType.Extract;
        JsonElement expectedFieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedFieldConfidences = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        Errors::InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        List<Input> expectedInputs =
        [
            new()
            {
                InputContent = "inputContent",
                InputType = "inputType",
                JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, Outputs::InputType> expectedInputType = Outputs::InputType.Csv;
        List<string> expectedInvalidProperties = ["string"];
        Metadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        string expectedS3Url = "s3URL";
        string expectedTransformationID = "transformationID";
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedItemCount, deserialized.ItemCount);
        Assert.Equal(expectedItemOffset, deserialized.ItemOffset);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.True(
            JsonElement.DeepEquals(expectedTransformedContent, deserialized.TransformedContent)
        );
        Assert.Equal(expectedAvgConfidence, deserialized.AvgConfidence);
        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedCorrectedContent, deserialized.CorrectedContent);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.NotNull(deserialized.FieldBoundingBoxes);
        Assert.True(
            JsonElement.DeepEquals(
                expectedFieldBoundingBoxes,
                deserialized.FieldBoundingBoxes.Value
            )
        );
        Assert.NotNull(deserialized.FieldConfidences);
        Assert.True(
            JsonElement.DeepEquals(expectedFieldConfidences, deserialized.FieldConfidences.Value)
        );
        Assert.Equal(expectedFunctionCallID, deserialized.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, deserialized.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, deserialized.FunctionVersionNum);
        Assert.Equal(expectedInboundEmail, deserialized.InboundEmail);
        Assert.NotNull(deserialized.Inputs);
        Assert.Equal(expectedInputs.Count, deserialized.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], deserialized.Inputs[i]);
        }
        Assert.Equal(expectedInputType, deserialized.InputType);
        Assert.NotNull(deserialized.InvalidProperties);
        Assert.Equal(expectedInvalidProperties.Count, deserialized.InvalidProperties.Count);
        for (int i = 0; i < expectedInvalidProperties.Count; i++)
        {
            Assert.Equal(expectedInvalidProperties[i], deserialized.InvalidProperties[i]);
        }
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
        Assert.Equal(expectedTransformationID, deserialized.TransformationID);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
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
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            S3Url = "s3URL",
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("callID"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("eventType"));
        Assert.Null(model.FieldBoundingBoxes);
        Assert.False(model.RawData.ContainsKey("fieldBoundingBoxes"));
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
        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.InvalidProperties);
        Assert.False(model.RawData.ContainsKey("invalidProperties"));
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
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            S3Url = "s3URL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            S3Url = "s3URL",

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            EventType = null,
            FieldBoundingBoxes = null,
            FieldConfidences = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            InboundEmail = null,
            InputType = null,
            InvalidProperties = null,
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
        Assert.Null(model.FieldBoundingBoxes);
        Assert.False(model.RawData.ContainsKey("fieldBoundingBoxes"));
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
        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.InvalidProperties);
        Assert.False(model.RawData.ContainsKey("invalidProperties"));
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
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            S3Url = "s3URL",

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            EventType = null,
            FieldBoundingBoxes = null,
            FieldConfidences = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            InboundEmail = null,
            InputType = null,
            InvalidProperties = null,
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
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        Assert.Null(model.AvgConfidence);
        Assert.False(model.RawData.ContainsKey("avgConfidence"));
        Assert.Null(model.CorrectedContent);
        Assert.False(model.RawData.ContainsKey("correctedContent"));
        Assert.Null(model.Inputs);
        Assert.False(model.RawData.ContainsKey("inputs"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
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
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,

            AvgConfidence = null,
            CorrectedContent = null,
            Inputs = null,
            S3Url = null,
        };

        Assert.Null(model.AvgConfidence);
        Assert.True(model.RawData.ContainsKey("avgConfidence"));
        Assert.Null(model.CorrectedContent);
        Assert.True(model.RawData.ContainsKey("correctedContent"));
        Assert.Null(model.Inputs);
        Assert.True(model.RawData.ContainsKey("inputs"));
        Assert.Null(model.S3Url);
        Assert.True(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,

            AvgConfidence = null,
            CorrectedContent = null,
            Inputs = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CorrectedContent = new Output()
            {
                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EventType.Extract,
            FieldBoundingBoxes = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = "inputType",
                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                    S3Url = "s3URL",
                },
            ],
            InputType = Outputs::InputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        ExtractWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CorrectedContentTest : TestBase
{
    [Fact]
    public void OutputValidationWorks()
    {
        CorrectedContent value = new Output()
        {
            OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        CorrectedContent value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        CorrectedContent value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        CorrectedContent value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CorrectedContent value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CorrectedContent value = true;
        value.Validate();
    }

    [Fact]
    public void OutputSerializationRoundtripWorks()
    {
        CorrectedContent value = new Output()
        {
            OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        CorrectedContent value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        CorrectedContent value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CorrectedContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CorrectedContent value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CorrectedContent value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Output { OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        List<Outputs::AnyType?> expectedOutputValue =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];

        Assert.NotNull(model.OutputValue);
        Assert.Equal(expectedOutputValue.Count, model.OutputValue.Count);
        for (int i = 0; i < expectedOutputValue.Count; i++)
        {
            Assert.Equal(expectedOutputValue[i], model.OutputValue[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Output { OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Output>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Output { OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Output>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Outputs::AnyType?> expectedOutputValue =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];

        Assert.NotNull(deserialized.OutputValue);
        Assert.Equal(expectedOutputValue.Count, deserialized.OutputValue.Count);
        for (int i = 0; i < expectedOutputValue.Count; i++)
        {
            Assert.Equal(expectedOutputValue[i], deserialized.OutputValue[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Output { OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Output { };

        Assert.Null(model.OutputValue);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Output { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Output
        {
            // Null should be interpreted as omitted for these properties
            OutputValue = null,
        };

        Assert.Null(model.OutputValue);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Output
        {
            // Null should be interpreted as omitted for these properties
            OutputValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Output { OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        Output copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventType.Extract)]
    public void Validation_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventType.Extract)]
    public void SerializationRoundtrip_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Input
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        string expectedInputContent = "inputContent";
        string expectedInputType = "inputType";
        JsonElement expectedJsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedInputContent, model.InputContent);
        Assert.Equal(expectedInputType, model.InputType);
        Assert.NotNull(model.JsonInputContent);
        Assert.True(JsonElement.DeepEquals(expectedJsonInputContent, model.JsonInputContent.Value));
        Assert.Equal(expectedS3Url, model.S3Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Input
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Input
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedInputContent = "inputContent";
        string expectedInputType = "inputType";
        JsonElement expectedJsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedInputContent, deserialized.InputContent);
        Assert.Equal(expectedInputType, deserialized.InputType);
        Assert.NotNull(deserialized.JsonInputContent);
        Assert.True(
            JsonElement.DeepEquals(expectedJsonInputContent, deserialized.JsonInputContent.Value)
        );
        Assert.Equal(expectedS3Url, deserialized.S3Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Input
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Input { };

        Assert.Null(model.InputContent);
        Assert.False(model.RawData.ContainsKey("inputContent"));
        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.JsonInputContent);
        Assert.False(model.RawData.ContainsKey("jsonInputContent"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Input { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Input
        {
            InputContent = null,
            InputType = null,
            JsonInputContent = null,
            S3Url = null,
        };

        Assert.Null(model.InputContent);
        Assert.True(model.RawData.ContainsKey("inputContent"));
        Assert.Null(model.InputType);
        Assert.True(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.JsonInputContent);
        Assert.True(model.RawData.ContainsKey("jsonInputContent"));
        Assert.Null(model.S3Url);
        Assert.True(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Input
        {
            InputContent = null,
            InputType = null,
            JsonInputContent = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Input
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        Input copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
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
        var model = new Metadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Metadata
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
        var model = new Metadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metadata { DurationFunctionToEventSeconds = 0 };

        Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
