using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Webhooks;
using Errors = Bem.Models.Errors;
using Functions = Bem.Models.Functions;
using Outputs = Bem.Models.Outputs;

namespace Bem.Tests.Models.Webhooks;

public class UnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void ExtractValidationWorks()
    {
        UnwrapWebhookEvent value = new ExtractWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void ClassifyValidationWorks()
    {
        UnwrapWebhookEvent value = new ClassifyWebhookEvent()
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = ClassifyWebhookEventEventType.Classify,
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
            S3Url = "s3URL",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };
        value.Validate();
    }

    [Fact]
    public void ParseValidationWorks()
    {
        UnwrapWebhookEvent value = new ParseWebhookEvent()
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
            CorrectedContent = new ParseWebhookEventCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = ParseWebhookEventEventType.Parse,
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
        value.Validate();
    }

    [Fact]
    public void SplitCollectionValidationWorks()
    {
        UnwrapWebhookEvent value = new SplitCollectionWebhookEvent()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputType.PrintPage,
            PrintPageOutput = new()
            {
                ItemCount = 0,
                Items =
                [
                    new()
                    {
                        ItemOffset = 0,
                        ItemReferenceID = "itemReferenceID",
                        S3Url = "s3URL",
                    },
                ],
            },
            ReferenceID = "referenceID",
            SemanticPageOutput = new()
            {
                ItemCount = 0,
                Items =
                [
                    new()
                    {
                        ItemClass = "itemClass",
                        ItemClassCount = 0,
                        ItemClassOffset = 0,
                        ItemOffset = 0,
                        ItemReferenceID = "itemReferenceID",
                        PageEnd = 0,
                        PageStart = 0,
                        S3Url = "s3URL",
                    },
                ],
                PageCount = 0,
            },
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitCollectionWebhookEventEventType.SplitCollection,
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
        value.Validate();
    }

    [Fact]
    public void SplitItemValidationWorks()
    {
        UnwrapWebhookEvent value = new SplitItemWebhookEvent()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemWebhookEventEventType.SplitItem,
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
            PrintPageOutput = new()
            {
                CollectionReferenceID = "collectionReferenceID",
                ItemCount = 0,
                ItemOffset = 0,
                S3Url = "s3URL",
            },
            SemanticPageOutput = new()
            {
                CollectionReferenceID = "collectionReferenceID",
                ItemClass = "itemClass",
                ItemClassCount = 0,
                ItemClassOffset = 0,
                ItemCount = 0,
                ItemOffset = 0,
                PageCount = 0,
                PageEnd = 0,
                PageStart = 0,
                S3Url = "s3URL",
            },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };
        value.Validate();
    }

    [Fact]
    public void JoinValidationWorks()
    {
        UnwrapWebhookEvent value = new JoinWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void EnrichValidationWorks()
    {
        UnwrapWebhookEvent value = new EnrichWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void PayloadShapingValidationWorks()
    {
        UnwrapWebhookEvent value = new PayloadShapingWebhookEvent()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = PayloadShapingWebhookEventEventType.PayloadShaping,
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
        value.Validate();
    }

    [Fact]
    public void SendValidationWorks()
    {
        UnwrapWebhookEvent value = new SendWebhookEvent()
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = Functions::SendDestinationType.Webhook,
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
        value.Validate();
    }

    [Fact]
    public void EvaluationValidationWorks()
    {
        UnwrapWebhookEvent value = new EvaluationWebhookEvent()
        {
            EvaluationVersion = "evaluationVersion",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = Status.Success,
            TransformID = "transformId",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = EvaluationWebhookEventEventType.Evaluation,
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
        value.Validate();
    }

    [Fact]
    public void CollectionProcessingValidationWorks()
    {
        UnwrapWebhookEvent value = new CollectionProcessingWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void ErrorValidationWorks()
    {
        UnwrapWebhookEvent value = new Errors::ErrorEvent()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            Message = "message",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = Errors::EventType.Error,
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
        value.Validate();
    }

    [Fact]
    public void ExtractSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new ExtractWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClassifySerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new ClassifyWebhookEvent()
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = ClassifyWebhookEventEventType.Classify,
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
            S3Url = "s3URL",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ParseSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new ParseWebhookEvent()
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
            CorrectedContent = new ParseWebhookEventCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = ParseWebhookEventEventType.Parse,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitCollectionSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SplitCollectionWebhookEvent()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputType.PrintPage,
            PrintPageOutput = new()
            {
                ItemCount = 0,
                Items =
                [
                    new()
                    {
                        ItemOffset = 0,
                        ItemReferenceID = "itemReferenceID",
                        S3Url = "s3URL",
                    },
                ],
            },
            ReferenceID = "referenceID",
            SemanticPageOutput = new()
            {
                ItemCount = 0,
                Items =
                [
                    new()
                    {
                        ItemClass = "itemClass",
                        ItemClassCount = 0,
                        ItemClassOffset = 0,
                        ItemOffset = 0,
                        ItemReferenceID = "itemReferenceID",
                        PageEnd = 0,
                        PageStart = 0,
                        S3Url = "s3URL",
                    },
                ],
                PageCount = 0,
            },
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitCollectionWebhookEventEventType.SplitCollection,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitItemSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SplitItemWebhookEvent()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemWebhookEventEventType.SplitItem,
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
            PrintPageOutput = new()
            {
                CollectionReferenceID = "collectionReferenceID",
                ItemCount = 0,
                ItemOffset = 0,
                S3Url = "s3URL",
            },
            SemanticPageOutput = new()
            {
                CollectionReferenceID = "collectionReferenceID",
                ItemClass = "itemClass",
                ItemClassCount = 0,
                ItemClassOffset = 0,
                ItemCount = 0,
                ItemOffset = 0,
                PageCount = 0,
                PageEnd = 0,
                PageStart = 0,
                S3Url = "s3URL",
            },
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new JoinWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new EnrichWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PayloadShapingSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new PayloadShapingWebhookEvent()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = PayloadShapingWebhookEventEventType.PayloadShaping,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SendWebhookEvent()
        {
            DeliveryStatus = DeliveryStatus.Success,
            DestinationType = Functions::SendDestinationType.Webhook,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EvaluationSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new EvaluationWebhookEvent()
        {
            EvaluationVersion = "evaluationVersion",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = Status.Success,
            TransformID = "transformId",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = EvaluationWebhookEventEventType.Evaluation,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CollectionProcessingSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CollectionProcessingWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new Errors::ErrorEvent()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            Message = "message",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = Errors::EventType.Error,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
