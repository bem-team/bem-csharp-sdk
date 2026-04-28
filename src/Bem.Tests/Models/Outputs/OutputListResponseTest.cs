using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Outputs;
using Errors = Bem.Models.Errors;

namespace Bem.Tests.Models.Outputs;

public class OutputListResponseTest : TestBase
{
    [Fact]
    public void TransformValidationWorks()
    {
        OutputListResponse value = new OutputListResponseTransform()
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
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            LastPublishErrorAt = "lastPublishErrorAt",
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };
        value.Validate();
    }

    [Fact]
    public void ExtractValidationWorks()
    {
        OutputListResponse value = new OutputListResponseExtract()
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
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
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
    public void RouteValidationWorks()
    {
        OutputListResponse value = new OutputListResponseRoute()
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseRouteEventType.Route,
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
    public void ClassifyValidationWorks()
    {
        OutputListResponse value = new OutputListResponseClassify()
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseClassifyEventType.Classify,
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
    public void SplitCollectionValidationWorks()
    {
        OutputListResponse value = new OutputListResponseSplitCollection()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
            EventType = OutputListResponseSplitCollectionEventType.SplitCollection,
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
        OutputListResponse value = new OutputListResponseSplitItem()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseSplitItemEventType.SplitItem,
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
    public void ErrorEventValidationWorks()
    {
        OutputListResponse value = new Errors::ErrorEvent()
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
    public void JoinValidationWorks()
    {
        OutputListResponse value = new OutputListResponseJoin()
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        OutputListResponse value = new OutputListResponseEnrich()
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseEnrichEventType.Enrich,
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
        OutputListResponse value = new OutputListResponseCollectionProcessing()
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = OutputListResponseCollectionProcessingEventType.CollectionProcessing,
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
    public void SendValidationWorks()
    {
        OutputListResponse value = new OutputListResponseSend()
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = OutputListResponseSendEventType.Send,
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
    public void TransformSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseTransform()
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
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            LastPublishErrorAt = "lastPublishErrorAt",
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseExtract()
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
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RouteSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseRoute()
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseRouteEventType.Route,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClassifySerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseClassify()
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseClassifyEventType.Classify,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitCollectionSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseSplitCollection()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
            EventType = OutputListResponseSplitCollectionEventType.SplitCollection,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitItemSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseSplitItem()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseSplitItemEventType.SplitItem,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErrorEventSerializationRoundtripWorks()
    {
        OutputListResponse value = new Errors::ErrorEvent()
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseJoin()
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseEnrich()
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseEnrichEventType.Enrich,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CollectionProcessingSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseCollectionProcessing()
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = OutputListResponseCollectionProcessingEventType.CollectionProcessing,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        OutputListResponse value = new OutputListResponseSend()
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = OutputListResponseSendEventType.Send,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseTransformTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseTransform
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
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            LastPublishErrorAt = "lastPublishErrorAt",
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        OutputListResponseTransformCorrectedContent expectedCorrectedContent =
            new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseTransformEventType> expectedEventType =
            OutputListResponseTransformEventType.Transform;
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
        List<OutputListResponseTransformInput> expectedInputs =
        [
            new()
            {
                InputContent = "inputContent",
                InputType = "inputType",
                JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, OutputListResponseTransformInputType> expectedInputType =
            OutputListResponseTransformInputType.Csv;
        List<string> expectedInvalidProperties = ["string"];
        bool expectedIsRegression = true;
        string expectedLastPublishErrorAt = "lastPublishErrorAt";
        OutputListResponseTransformMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        OutputListResponseTransformMetrics expectedMetrics = new()
        {
            Differences =
            [
                new()
                {
                    Category = "category",
                    CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonPointer = "jsonPointer",
                },
            ],
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };
        bool expectedOrderMatching = true;
        string expectedPipelineID = "pipelineID";
        DateTimeOffset expectedPublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        Assert.Equal(expectedIsRegression, model.IsRegression);
        Assert.Equal(expectedLastPublishErrorAt, model.LastPublishErrorAt);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedMetrics, model.Metrics);
        Assert.Equal(expectedOrderMatching, model.OrderMatching);
        Assert.Equal(expectedPipelineID, model.PipelineID);
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
        Assert.Equal(expectedS3Url, model.S3Url);
        Assert.Equal(expectedTransformationID, model.TransformationID);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseTransform
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
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            LastPublishErrorAt = "lastPublishErrorAt",
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransform>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseTransform
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
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            LastPublishErrorAt = "lastPublishErrorAt",
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransform>(
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
        OutputListResponseTransformCorrectedContent expectedCorrectedContent =
            new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseTransformEventType> expectedEventType =
            OutputListResponseTransformEventType.Transform;
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
        List<OutputListResponseTransformInput> expectedInputs =
        [
            new()
            {
                InputContent = "inputContent",
                InputType = "inputType",
                JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, OutputListResponseTransformInputType> expectedInputType =
            OutputListResponseTransformInputType.Csv;
        List<string> expectedInvalidProperties = ["string"];
        bool expectedIsRegression = true;
        string expectedLastPublishErrorAt = "lastPublishErrorAt";
        OutputListResponseTransformMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        OutputListResponseTransformMetrics expectedMetrics = new()
        {
            Differences =
            [
                new()
                {
                    Category = "category",
                    CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonPointer = "jsonPointer",
                },
            ],
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };
        bool expectedOrderMatching = true;
        string expectedPipelineID = "pipelineID";
        DateTimeOffset expectedPublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        Assert.Equal(expectedIsRegression, deserialized.IsRegression);
        Assert.Equal(expectedLastPublishErrorAt, deserialized.LastPublishErrorAt);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedMetrics, deserialized.Metrics);
        Assert.Equal(expectedOrderMatching, deserialized.OrderMatching);
        Assert.Equal(expectedPipelineID, deserialized.PipelineID);
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
        Assert.Equal(expectedTransformationID, deserialized.TransformationID);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseTransform
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
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            LastPublishErrorAt = "lastPublishErrorAt",
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new OutputListResponseTransform
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            LastPublishErrorAt = "lastPublishErrorAt",
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            S3Url = "s3URL",
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
        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.InvalidProperties);
        Assert.False(model.RawData.ContainsKey("invalidProperties"));
        Assert.Null(model.IsRegression);
        Assert.False(model.RawData.ContainsKey("isRegression"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OrderMatching);
        Assert.False(model.RawData.ContainsKey("orderMatching"));
        Assert.Null(model.PipelineID);
        Assert.False(model.RawData.ContainsKey("pipelineID"));
        Assert.Null(model.PublishedAt);
        Assert.False(model.RawData.ContainsKey("publishedAt"));
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
        var model = new OutputListResponseTransform
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            LastPublishErrorAt = "lastPublishErrorAt",
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            S3Url = "s3URL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseTransform
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            LastPublishErrorAt = "lastPublishErrorAt",
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            S3Url = "s3URL",

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            EventType = null,
            FieldConfidences = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            InboundEmail = null,
            InputType = null,
            InvalidProperties = null,
            IsRegression = null,
            Metadata = null,
            OrderMatching = null,
            PipelineID = null,
            PublishedAt = null,
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
        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.InvalidProperties);
        Assert.False(model.RawData.ContainsKey("invalidProperties"));
        Assert.Null(model.IsRegression);
        Assert.False(model.RawData.ContainsKey("isRegression"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OrderMatching);
        Assert.False(model.RawData.ContainsKey("orderMatching"));
        Assert.Null(model.PipelineID);
        Assert.False(model.RawData.ContainsKey("pipelineID"));
        Assert.Null(model.PublishedAt);
        Assert.False(model.RawData.ContainsKey("publishedAt"));
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
        var model = new OutputListResponseTransform
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            LastPublishErrorAt = "lastPublishErrorAt",
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            S3Url = "s3URL",

            // Null should be interpreted as omitted for these properties
            CallID = null,
            CreatedAt = null,
            EventType = null,
            FieldConfidences = null,
            FunctionCallID = null,
            FunctionCallTryNumber = null,
            FunctionVersionNum = null,
            InboundEmail = null,
            InputType = null,
            InvalidProperties = null,
            IsRegression = null,
            Metadata = null,
            OrderMatching = null,
            PipelineID = null,
            PublishedAt = null,
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
        var model = new OutputListResponseTransform
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
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        Assert.Null(model.LastPublishErrorAt);
        Assert.False(model.RawData.ContainsKey("lastPublishErrorAt"));
        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseTransform
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
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new OutputListResponseTransform
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
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,

            AvgConfidence = null,
            CorrectedContent = null,
            Inputs = null,
            LastPublishErrorAt = null,
            Metrics = null,
            S3Url = null,
        };

        Assert.Null(model.AvgConfidence);
        Assert.True(model.RawData.ContainsKey("avgConfidence"));
        Assert.Null(model.CorrectedContent);
        Assert.True(model.RawData.ContainsKey("correctedContent"));
        Assert.Null(model.Inputs);
        Assert.True(model.RawData.ContainsKey("inputs"));
        Assert.Null(model.LastPublishErrorAt);
        Assert.True(model.RawData.ContainsKey("lastPublishErrorAt"));
        Assert.Null(model.Metrics);
        Assert.True(model.RawData.ContainsKey("metrics"));
        Assert.Null(model.S3Url);
        Assert.True(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseTransform
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
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,

            AvgConfidence = null,
            CorrectedContent = null,
            Inputs = null,
            LastPublishErrorAt = null,
            Metrics = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseTransform
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
            CorrectedContent = new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseTransformEventType.Transform,
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
            InputType = OutputListResponseTransformInputType.Csv,
            InvalidProperties = ["string"],
            IsRegression = true,
            LastPublishErrorAt = "lastPublishErrorAt",
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            Metrics = new()
            {
                Differences =
                [
                    new()
                    {
                        Category = "category",
                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonPointer = "jsonPointer",
                    },
                ],
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Precision = 0,
                    Recall = 0,
                },
            },
            OrderMatching = true,
            PipelineID = "pipelineID",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        OutputListResponseTransform copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseTransformCorrectedContentTest : TestBase
{
    [Fact]
    public void OutputListResponseTransformCorrectedContentOutputValidationWorks()
    {
        OutputListResponseTransformCorrectedContent value =
            new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            };
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        OutputListResponseTransformCorrectedContent value = JsonSerializer.Deserialize<JsonElement>(
            "{}"
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        OutputListResponseTransformCorrectedContent value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        OutputListResponseTransformCorrectedContent value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        OutputListResponseTransformCorrectedContent value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        OutputListResponseTransformCorrectedContent value = true;
        value.Validate();
    }

    [Fact]
    public void OutputListResponseTransformCorrectedContentOutputSerializationRoundtripWorks()
    {
        OutputListResponseTransformCorrectedContent value =
            new OutputListResponseTransformCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        OutputListResponseTransformCorrectedContent value = JsonSerializer.Deserialize<JsonElement>(
            "{}"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        OutputListResponseTransformCorrectedContent value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        OutputListResponseTransformCorrectedContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        OutputListResponseTransformCorrectedContent value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        OutputListResponseTransformCorrectedContent value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseTransformCorrectedContentOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        List<AnyType?> expectedOutput = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.NotNull(model.Output);
        Assert.Equal(expectedOutput.Count, model.Output.Count);
        for (int i = 0; i < expectedOutput.Count; i++)
        {
            Assert.Equal(expectedOutput[i], model.Output[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContentOutput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseTransformCorrectedContentOutput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<AnyType?> expectedOutput = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.NotNull(deserialized.Output);
        Assert.Equal(expectedOutput.Count, deserialized.Output.Count);
        for (int i = 0; i < expectedOutput.Count; i++)
        {
            Assert.Equal(expectedOutput[i], deserialized.Output[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput { };

        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput
        {
            // Null should be interpreted as omitted for these properties
            Output = null,
        };

        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput
        {
            // Null should be interpreted as omitted for these properties
            Output = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseTransformCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        OutputListResponseTransformCorrectedContentOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseTransformEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseTransformEventType.Transform)]
    public void Validation_Works(OutputListResponseTransformEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseTransformEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseTransformEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseTransformEventType.Transform)]
    public void SerializationRoundtrip_Works(OutputListResponseTransformEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseTransformEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseTransformEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseTransformEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseTransformEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseTransformInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseTransformInput
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
        var model = new OutputListResponseTransformInput
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseTransformInput
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformInput>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new OutputListResponseTransformInput
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
        var model = new OutputListResponseTransformInput { };

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
        var model = new OutputListResponseTransformInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OutputListResponseTransformInput
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
        var model = new OutputListResponseTransformInput
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
        var model = new OutputListResponseTransformInput
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        OutputListResponseTransformInput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseTransformInputTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseTransformInputType.Csv)]
    [InlineData(OutputListResponseTransformInputType.Docx)]
    [InlineData(OutputListResponseTransformInputType.Email)]
    [InlineData(OutputListResponseTransformInputType.Heic)]
    [InlineData(OutputListResponseTransformInputType.Html)]
    [InlineData(OutputListResponseTransformInputType.Jpeg)]
    [InlineData(OutputListResponseTransformInputType.Json)]
    [InlineData(OutputListResponseTransformInputType.Heif)]
    [InlineData(OutputListResponseTransformInputType.M4a)]
    [InlineData(OutputListResponseTransformInputType.Mp3)]
    [InlineData(OutputListResponseTransformInputType.Pdf)]
    [InlineData(OutputListResponseTransformInputType.Png)]
    [InlineData(OutputListResponseTransformInputType.Text)]
    [InlineData(OutputListResponseTransformInputType.Wav)]
    [InlineData(OutputListResponseTransformInputType.Webp)]
    [InlineData(OutputListResponseTransformInputType.Xls)]
    [InlineData(OutputListResponseTransformInputType.Xlsx)]
    [InlineData(OutputListResponseTransformInputType.Xml)]
    public void Validation_Works(OutputListResponseTransformInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseTransformInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseTransformInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseTransformInputType.Csv)]
    [InlineData(OutputListResponseTransformInputType.Docx)]
    [InlineData(OutputListResponseTransformInputType.Email)]
    [InlineData(OutputListResponseTransformInputType.Heic)]
    [InlineData(OutputListResponseTransformInputType.Html)]
    [InlineData(OutputListResponseTransformInputType.Jpeg)]
    [InlineData(OutputListResponseTransformInputType.Json)]
    [InlineData(OutputListResponseTransformInputType.Heif)]
    [InlineData(OutputListResponseTransformInputType.M4a)]
    [InlineData(OutputListResponseTransformInputType.Mp3)]
    [InlineData(OutputListResponseTransformInputType.Pdf)]
    [InlineData(OutputListResponseTransformInputType.Png)]
    [InlineData(OutputListResponseTransformInputType.Text)]
    [InlineData(OutputListResponseTransformInputType.Wav)]
    [InlineData(OutputListResponseTransformInputType.Webp)]
    [InlineData(OutputListResponseTransformInputType.Xls)]
    [InlineData(OutputListResponseTransformInputType.Xlsx)]
    [InlineData(OutputListResponseTransformInputType.Xml)]
    public void SerializationRoundtrip_Works(OutputListResponseTransformInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseTransformInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseTransformInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseTransformInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseTransformInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseTransformMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseTransformMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseTransformMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseTransformMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformMetadata>(
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
        var model = new OutputListResponseTransformMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseTransformMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseTransformMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseTransformMetadata
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
        var model = new OutputListResponseTransformMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseTransformMetadata { DurationFunctionToEventSeconds = 0 };

        OutputListResponseTransformMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseTransformMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseTransformMetrics
        {
            Differences =
            [
                new()
                {
                    Category = "category",
                    CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonPointer = "jsonPointer",
                },
            ],
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        List<OutputListResponseTransformMetricsDifference> expectedDifferences =
        [
            new()
            {
                Category = "category",
                CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonPointer = "jsonPointer",
            },
        ];
        OutputListResponseTransformMetricsMetrics expectedMetrics = new()
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        Assert.NotNull(model.Differences);
        Assert.Equal(expectedDifferences.Count, model.Differences.Count);
        for (int i = 0; i < expectedDifferences.Count; i++)
        {
            Assert.Equal(expectedDifferences[i], model.Differences[i]);
        }
        Assert.Equal(expectedMetrics, model.Metrics);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseTransformMetrics
        {
            Differences =
            [
                new()
                {
                    Category = "category",
                    CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonPointer = "jsonPointer",
                },
            ],
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseTransformMetrics
        {
            Differences =
            [
                new()
                {
                    Category = "category",
                    CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonPointer = "jsonPointer",
                },
            ],
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<OutputListResponseTransformMetricsDifference> expectedDifferences =
        [
            new()
            {
                Category = "category",
                CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonPointer = "jsonPointer",
            },
        ];
        OutputListResponseTransformMetricsMetrics expectedMetrics = new()
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        Assert.NotNull(deserialized.Differences);
        Assert.Equal(expectedDifferences.Count, deserialized.Differences.Count);
        for (int i = 0; i < expectedDifferences.Count; i++)
        {
            Assert.Equal(expectedDifferences[i], deserialized.Differences[i]);
        }
        Assert.Equal(expectedMetrics, deserialized.Metrics);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseTransformMetrics
        {
            Differences =
            [
                new()
                {
                    Category = "category",
                    CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonPointer = "jsonPointer",
                },
            ],
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseTransformMetrics { };

        Assert.Null(model.Differences);
        Assert.False(model.RawData.ContainsKey("differences"));
        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseTransformMetrics { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseTransformMetrics
        {
            // Null should be interpreted as omitted for these properties
            Differences = null,
            Metrics = null,
        };

        Assert.Null(model.Differences);
        Assert.False(model.RawData.ContainsKey("differences"));
        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseTransformMetrics
        {
            // Null should be interpreted as omitted for these properties
            Differences = null,
            Metrics = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseTransformMetrics
        {
            Differences =
            [
                new()
                {
                    Category = "category",
                    CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonPointer = "jsonPointer",
                },
            ],
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        OutputListResponseTransformMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseTransformMetricsDifferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference
        {
            Category = "category",
            CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonPointer = "jsonPointer",
        };

        string expectedCategory = "category";
        JsonElement expectedCorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedJsonPointer = "jsonPointer";

        Assert.Equal(expectedCategory, model.Category);
        Assert.NotNull(model.CorrectedVal);
        Assert.True(JsonElement.DeepEquals(expectedCorrectedVal, model.CorrectedVal.Value));
        Assert.NotNull(model.ExtractedVal);
        Assert.True(JsonElement.DeepEquals(expectedExtractedVal, model.ExtractedVal.Value));
        Assert.Equal(expectedJsonPointer, model.JsonPointer);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference
        {
            Category = "category",
            CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonPointer = "jsonPointer",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformMetricsDifference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference
        {
            Category = "category",
            CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonPointer = "jsonPointer",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformMetricsDifference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCategory = "category";
        JsonElement expectedCorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedJsonPointer = "jsonPointer";

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.NotNull(deserialized.CorrectedVal);
        Assert.True(JsonElement.DeepEquals(expectedCorrectedVal, deserialized.CorrectedVal.Value));
        Assert.NotNull(deserialized.ExtractedVal);
        Assert.True(JsonElement.DeepEquals(expectedExtractedVal, deserialized.ExtractedVal.Value));
        Assert.Equal(expectedJsonPointer, deserialized.JsonPointer);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference
        {
            Category = "category",
            CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonPointer = "jsonPointer",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference { };

        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.CorrectedVal);
        Assert.False(model.RawData.ContainsKey("correctedVal"));
        Assert.Null(model.ExtractedVal);
        Assert.False(model.RawData.ContainsKey("extractedVal"));
        Assert.Null(model.JsonPointer);
        Assert.False(model.RawData.ContainsKey("jsonPointer"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference
        {
            // Null should be interpreted as omitted for these properties
            Category = null,
            CorrectedVal = null,
            ExtractedVal = null,
            JsonPointer = null,
        };

        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.CorrectedVal);
        Assert.False(model.RawData.ContainsKey("correctedVal"));
        Assert.Null(model.ExtractedVal);
        Assert.False(model.RawData.ContainsKey("extractedVal"));
        Assert.Null(model.JsonPointer);
        Assert.False(model.RawData.ContainsKey("jsonPointer"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference
        {
            // Null should be interpreted as omitted for these properties
            Category = null,
            CorrectedVal = null,
            ExtractedVal = null,
            JsonPointer = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseTransformMetricsDifference
        {
            Category = "category",
            CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonPointer = "jsonPointer",
        };

        OutputListResponseTransformMetricsDifference copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseTransformMetricsMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        double expectedAccuracy = 0;
        double expectedF1Score = 0;
        double expectedPrecision = 0;
        double expectedRecall = 0;

        Assert.Equal(expectedAccuracy, model.Accuracy);
        Assert.Equal(expectedF1Score, model.F1Score);
        Assert.Equal(expectedPrecision, model.Precision);
        Assert.Equal(expectedRecall, model.Recall);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformMetricsMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseTransformMetricsMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAccuracy = 0;
        double expectedF1Score = 0;
        double expectedPrecision = 0;
        double expectedRecall = 0;

        Assert.Equal(expectedAccuracy, deserialized.Accuracy);
        Assert.Equal(expectedF1Score, deserialized.F1Score);
        Assert.Equal(expectedPrecision, deserialized.Precision);
        Assert.Equal(expectedRecall, deserialized.Recall);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics { };

        Assert.Null(model.Accuracy);
        Assert.False(model.RawData.ContainsKey("accuracy"));
        Assert.Null(model.F1Score);
        Assert.False(model.RawData.ContainsKey("f1Score"));
        Assert.Null(model.Precision);
        Assert.False(model.RawData.ContainsKey("precision"));
        Assert.Null(model.Recall);
        Assert.False(model.RawData.ContainsKey("recall"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics
        {
            // Null should be interpreted as omitted for these properties
            Accuracy = null,
            F1Score = null,
            Precision = null,
            Recall = null,
        };

        Assert.Null(model.Accuracy);
        Assert.False(model.RawData.ContainsKey("accuracy"));
        Assert.Null(model.F1Score);
        Assert.False(model.RawData.ContainsKey("f1Score"));
        Assert.Null(model.Precision);
        Assert.False(model.RawData.ContainsKey("precision"));
        Assert.Null(model.Recall);
        Assert.False(model.RawData.ContainsKey("recall"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics
        {
            // Null should be interpreted as omitted for these properties
            Accuracy = null,
            F1Score = null,
            Precision = null,
            Recall = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseTransformMetricsMetrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        OutputListResponseTransformMetricsMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseExtractTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseExtract
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
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
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
        OutputListResponseExtractCorrectedContent expectedCorrectedContent =
            new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseExtractEventType> expectedEventType =
            OutputListResponseExtractEventType.Extract;
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
        List<OutputListResponseExtractInput> expectedInputs =
        [
            new()
            {
                InputContent = "inputContent",
                InputType = "inputType",
                JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, OutputListResponseExtractInputType> expectedInputType =
            OutputListResponseExtractInputType.Csv;
        List<string> expectedInvalidProperties = ["string"];
        OutputListResponseExtractMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
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
        var model = new OutputListResponseExtract
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
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtract>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseExtract
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
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtract>(
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
        OutputListResponseExtractCorrectedContent expectedCorrectedContent =
            new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseExtractEventType> expectedEventType =
            OutputListResponseExtractEventType.Extract;
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
        List<OutputListResponseExtractInput> expectedInputs =
        [
            new()
            {
                InputContent = "inputContent",
                InputType = "inputType",
                JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, OutputListResponseExtractInputType> expectedInputType =
            OutputListResponseExtractInputType.Csv;
        List<string> expectedInvalidProperties = ["string"];
        OutputListResponseExtractMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
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
        var model = new OutputListResponseExtract
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
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
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
        var model = new OutputListResponseExtract
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
        var model = new OutputListResponseExtract
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
        var model = new OutputListResponseExtract
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
        var model = new OutputListResponseExtract
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ItemCount = 0,
            ItemOffset = 0,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
        var model = new OutputListResponseExtract
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
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
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
        var model = new OutputListResponseExtract
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
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
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
        var model = new OutputListResponseExtract
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
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
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
        var model = new OutputListResponseExtract
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
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
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
        var model = new OutputListResponseExtract
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
            CorrectedContent = new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseExtractEventType.Extract,
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
            InputType = OutputListResponseExtractInputType.Csv,
            InvalidProperties = ["string"],
            Metadata = new() { DurationFunctionToEventSeconds = 0 },
            S3Url = "s3URL",
            TransformationID = "transformationID",
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
            WorkflowVersionNum = 0,
        };

        OutputListResponseExtract copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseExtractCorrectedContentTest : TestBase
{
    [Fact]
    public void OutputListResponseExtractCorrectedContentOutputValidationWorks()
    {
        OutputListResponseExtractCorrectedContent value =
            new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            };
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        OutputListResponseExtractCorrectedContent value = JsonSerializer.Deserialize<JsonElement>(
            "{}"
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        OutputListResponseExtractCorrectedContent value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        OutputListResponseExtractCorrectedContent value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        OutputListResponseExtractCorrectedContent value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        OutputListResponseExtractCorrectedContent value = true;
        value.Validate();
    }

    [Fact]
    public void OutputListResponseExtractCorrectedContentOutputSerializationRoundtripWorks()
    {
        OutputListResponseExtractCorrectedContent value =
            new OutputListResponseExtractCorrectedContentOutput()
            {
                Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        OutputListResponseExtractCorrectedContent value = JsonSerializer.Deserialize<JsonElement>(
            "{}"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        OutputListResponseExtractCorrectedContent value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        OutputListResponseExtractCorrectedContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        OutputListResponseExtractCorrectedContent value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        OutputListResponseExtractCorrectedContent value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseExtractCorrectedContentOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        List<AnyType?> expectedOutput = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.NotNull(model.Output);
        Assert.Equal(expectedOutput.Count, model.Output.Count);
        for (int i = 0; i < expectedOutput.Count; i++)
        {
            Assert.Equal(expectedOutput[i], model.Output[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContentOutput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseExtractCorrectedContentOutput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<AnyType?> expectedOutput = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.NotNull(deserialized.Output);
        Assert.Equal(expectedOutput.Count, deserialized.Output.Count);
        for (int i = 0; i < expectedOutput.Count; i++)
        {
            Assert.Equal(expectedOutput[i], deserialized.Output[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput { };

        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput
        {
            // Null should be interpreted as omitted for these properties
            Output = null,
        };

        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput
        {
            // Null should be interpreted as omitted for these properties
            Output = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseExtractCorrectedContentOutput
        {
            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        OutputListResponseExtractCorrectedContentOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseExtractEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseExtractEventType.Extract)]
    public void Validation_Works(OutputListResponseExtractEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseExtractEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseExtractEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseExtractEventType.Extract)]
    public void SerializationRoundtrip_Works(OutputListResponseExtractEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseExtractEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseExtractEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseExtractEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseExtractEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseExtractInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseExtractInput
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
        var model = new OutputListResponseExtractInput
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseExtractInput
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractInput>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new OutputListResponseExtractInput
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
        var model = new OutputListResponseExtractInput { };

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
        var model = new OutputListResponseExtractInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OutputListResponseExtractInput
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
        var model = new OutputListResponseExtractInput
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
        var model = new OutputListResponseExtractInput
        {
            InputContent = "inputContent",
            InputType = "inputType",
            JsonInputContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            S3Url = "s3URL",
        };

        OutputListResponseExtractInput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseExtractInputTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseExtractInputType.Csv)]
    [InlineData(OutputListResponseExtractInputType.Docx)]
    [InlineData(OutputListResponseExtractInputType.Email)]
    [InlineData(OutputListResponseExtractInputType.Heic)]
    [InlineData(OutputListResponseExtractInputType.Html)]
    [InlineData(OutputListResponseExtractInputType.Jpeg)]
    [InlineData(OutputListResponseExtractInputType.Json)]
    [InlineData(OutputListResponseExtractInputType.Heif)]
    [InlineData(OutputListResponseExtractInputType.M4a)]
    [InlineData(OutputListResponseExtractInputType.Mp3)]
    [InlineData(OutputListResponseExtractInputType.Pdf)]
    [InlineData(OutputListResponseExtractInputType.Png)]
    [InlineData(OutputListResponseExtractInputType.Text)]
    [InlineData(OutputListResponseExtractInputType.Wav)]
    [InlineData(OutputListResponseExtractInputType.Webp)]
    [InlineData(OutputListResponseExtractInputType.Xls)]
    [InlineData(OutputListResponseExtractInputType.Xlsx)]
    [InlineData(OutputListResponseExtractInputType.Xml)]
    public void Validation_Works(OutputListResponseExtractInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseExtractInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseExtractInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseExtractInputType.Csv)]
    [InlineData(OutputListResponseExtractInputType.Docx)]
    [InlineData(OutputListResponseExtractInputType.Email)]
    [InlineData(OutputListResponseExtractInputType.Heic)]
    [InlineData(OutputListResponseExtractInputType.Html)]
    [InlineData(OutputListResponseExtractInputType.Jpeg)]
    [InlineData(OutputListResponseExtractInputType.Json)]
    [InlineData(OutputListResponseExtractInputType.Heif)]
    [InlineData(OutputListResponseExtractInputType.M4a)]
    [InlineData(OutputListResponseExtractInputType.Mp3)]
    [InlineData(OutputListResponseExtractInputType.Pdf)]
    [InlineData(OutputListResponseExtractInputType.Png)]
    [InlineData(OutputListResponseExtractInputType.Text)]
    [InlineData(OutputListResponseExtractInputType.Wav)]
    [InlineData(OutputListResponseExtractInputType.Webp)]
    [InlineData(OutputListResponseExtractInputType.Xls)]
    [InlineData(OutputListResponseExtractInputType.Xlsx)]
    [InlineData(OutputListResponseExtractInputType.Xml)]
    public void SerializationRoundtrip_Works(OutputListResponseExtractInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseExtractInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseExtractInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseExtractInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseExtractInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseExtractMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseExtractMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseExtractMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseExtractMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseExtractMetadata>(
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
        var model = new OutputListResponseExtractMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseExtractMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseExtractMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseExtractMetadata
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
        var model = new OutputListResponseExtractMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseExtractMetadata { DurationFunctionToEventSeconds = 0 };

        OutputListResponseExtractMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseRouteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseRouteEventType.Route,
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

        string expectedChoice = "choice";
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseRouteEventType> expectedEventType =
            OutputListResponseRouteEventType.Route;
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
        OutputListResponseRouteMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        string expectedS3Url = "s3URL";
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedChoice, model.Choice);
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
        Assert.Equal(expectedS3Url, model.S3Url);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseRouteEventType.Route,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseRoute>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseRouteEventType.Route,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseRoute>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChoice = "choice";
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseRouteEventType> expectedEventType =
            OutputListResponseRouteEventType.Route;
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
        OutputListResponseRouteMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        string expectedS3Url = "s3URL";
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedChoice, deserialized.Choice);
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
        Assert.Equal(expectedS3Url, deserialized.S3Url);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseRouteEventType.Route,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
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
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
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
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
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
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
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
            S3Url = null,
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
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
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
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
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
            S3Url = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseRoute
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseRouteEventType.Route,
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

        OutputListResponseRoute copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseRouteEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseRouteEventType.Route)]
    public void Validation_Works(OutputListResponseRouteEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseRouteEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseRouteEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseRouteEventType.Route)]
    public void SerializationRoundtrip_Works(OutputListResponseRouteEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseRouteEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseRouteEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseRouteEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseRouteEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseRouteMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseRouteMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseRouteMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseRouteMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseRouteMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseRouteMetadata>(
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
        var model = new OutputListResponseRouteMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseRouteMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseRouteMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseRouteMetadata
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
        var model = new OutputListResponseRouteMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseRouteMetadata { DurationFunctionToEventSeconds = 0 };

        OutputListResponseRouteMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseClassifyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseClassifyEventType.Classify,
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

        string expectedChoice = "choice";
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseClassifyEventType> expectedEventType =
            OutputListResponseClassifyEventType.Classify;
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
        OutputListResponseClassifyMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        string expectedS3Url = "s3URL";
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedChoice, model.Choice);
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
        Assert.Equal(expectedS3Url, model.S3Url);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseClassifyEventType.Classify,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseClassify>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseClassifyEventType.Classify,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseClassify>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChoice = "choice";
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseClassifyEventType> expectedEventType =
            OutputListResponseClassifyEventType.Classify;
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
        OutputListResponseClassifyMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        string expectedS3Url = "s3URL";
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedChoice, deserialized.Choice);
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
        Assert.Equal(expectedS3Url, deserialized.S3Url);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseClassifyEventType.Classify,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
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
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
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
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
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
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
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
            S3Url = null,
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
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
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
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
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
            S3Url = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseClassify
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseClassifyEventType.Classify,
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

        OutputListResponseClassify copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseClassifyEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseClassifyEventType.Classify)]
    public void Validation_Works(OutputListResponseClassifyEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseClassifyEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseClassifyEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseClassifyEventType.Classify)]
    public void SerializationRoundtrip_Works(OutputListResponseClassifyEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseClassifyEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseClassifyEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseClassifyEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseClassifyEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseClassifyMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseClassifyMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseClassifyMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseClassifyMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseClassifyMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseClassifyMetadata>(
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
        var model = new OutputListResponseClassifyMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseClassifyMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseClassifyMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseClassifyMetadata
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
        var model = new OutputListResponseClassifyMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseClassifyMetadata { DurationFunctionToEventSeconds = 0 };

        OutputListResponseClassifyMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitCollectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
            EventType = OutputListResponseSplitCollectionEventType.SplitCollection,
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

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, OutputListResponseSplitCollectionOutputType> expectedOutputType =
            OutputListResponseSplitCollectionOutputType.PrintPage;
        OutputListResponseSplitCollectionPrintPageOutput expectedPrintPageOutput = new()
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
        };
        string expectedReferenceID = "referenceID";
        OutputListResponseSplitCollectionSemanticPageOutput expectedSemanticPageOutput = new()
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
        };
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseSplitCollectionEventType> expectedEventType =
            OutputListResponseSplitCollectionEventType.SplitCollection;
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
        OutputListResponseSplitCollectionMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedOutputType, model.OutputType);
        Assert.Equal(expectedPrintPageOutput, model.PrintPageOutput);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedSemanticPageOutput, model.SemanticPageOutput);
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
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
            EventType = OutputListResponseSplitCollectionEventType.SplitCollection,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitCollection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
            EventType = OutputListResponseSplitCollectionEventType.SplitCollection,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitCollection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, OutputListResponseSplitCollectionOutputType> expectedOutputType =
            OutputListResponseSplitCollectionOutputType.PrintPage;
        OutputListResponseSplitCollectionPrintPageOutput expectedPrintPageOutput = new()
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
        };
        string expectedReferenceID = "referenceID";
        OutputListResponseSplitCollectionSemanticPageOutput expectedSemanticPageOutput = new()
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
        };
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseSplitCollectionEventType> expectedEventType =
            OutputListResponseSplitCollectionEventType.SplitCollection;
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
        OutputListResponseSplitCollectionMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedOutputType, deserialized.OutputType);
        Assert.Equal(expectedPrintPageOutput, deserialized.PrintPageOutput);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedSemanticPageOutput, deserialized.SemanticPageOutput);
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
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
            EventType = OutputListResponseSplitCollectionEventType.SplitCollection,
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
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
        var model = new OutputListResponseSplitCollection
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitCollectionOutputType.PrintPage,
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
            EventType = OutputListResponseSplitCollectionEventType.SplitCollection,
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

        OutputListResponseSplitCollection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitCollectionOutputTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseSplitCollectionOutputType.PrintPage)]
    [InlineData(OutputListResponseSplitCollectionOutputType.SemanticPage)]
    public void Validation_Works(OutputListResponseSplitCollectionOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSplitCollectionOutputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitCollectionOutputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseSplitCollectionOutputType.PrintPage)]
    [InlineData(OutputListResponseSplitCollectionOutputType.SemanticPage)]
    public void SerializationRoundtrip_Works(OutputListResponseSplitCollectionOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSplitCollectionOutputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitCollectionOutputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitCollectionOutputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitCollectionOutputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseSplitCollectionPrintPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput
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
        };

        long expectedItemCount = 0;
        List<OutputListResponseSplitCollectionPrintPageOutputItem> expectedItems =
        [
            new()
            {
                ItemOffset = 0,
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];

        Assert.Equal(expectedItemCount, model.ItemCount);
        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitCollectionPrintPageOutput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitCollectionPrintPageOutput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedItemCount = 0;
        List<OutputListResponseSplitCollectionPrintPageOutputItem> expectedItems =
        [
            new()
            {
                ItemOffset = 0,
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];

        Assert.Equal(expectedItemCount, deserialized.ItemCount);
        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput { };

        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput
        {
            // Null should be interpreted as omitted for these properties
            ItemCount = null,
            Items = null,
        };

        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput
        {
            // Null should be interpreted as omitted for these properties
            ItemCount = null,
            Items = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutput
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
        };

        OutputListResponseSplitCollectionPrintPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitCollectionPrintPageOutputItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem
        {
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        long expectedItemOffset = 0;
        string expectedItemReferenceID = "itemReferenceID";
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedItemOffset, model.ItemOffset);
        Assert.Equal(expectedItemReferenceID, model.ItemReferenceID);
        Assert.Equal(expectedS3Url, model.S3Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem
        {
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitCollectionPrintPageOutputItem>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem
        {
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitCollectionPrintPageOutputItem>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedItemOffset = 0;
        string expectedItemReferenceID = "itemReferenceID";
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedItemOffset, deserialized.ItemOffset);
        Assert.Equal(expectedItemReferenceID, deserialized.ItemReferenceID);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem
        {
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem { };

        Assert.Null(model.ItemOffset);
        Assert.False(model.RawData.ContainsKey("itemOffset"));
        Assert.Null(model.ItemReferenceID);
        Assert.False(model.RawData.ContainsKey("itemReferenceID"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem
        {
            // Null should be interpreted as omitted for these properties
            ItemOffset = null,
            ItemReferenceID = null,
            S3Url = null,
        };

        Assert.Null(model.ItemOffset);
        Assert.False(model.RawData.ContainsKey("itemOffset"));
        Assert.Null(model.ItemReferenceID);
        Assert.False(model.RawData.ContainsKey("itemReferenceID"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem
        {
            // Null should be interpreted as omitted for these properties
            ItemOffset = null,
            ItemReferenceID = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitCollectionPrintPageOutputItem
        {
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        OutputListResponseSplitCollectionPrintPageOutputItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitCollectionSemanticPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput
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
        };

        long expectedItemCount = 0;
        List<OutputListResponseSplitCollectionSemanticPageOutputItem> expectedItems =
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
        ];
        long expectedPageCount = 0;

        Assert.Equal(expectedItemCount, model.ItemCount);
        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPageCount, model.PageCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitCollectionSemanticPageOutput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitCollectionSemanticPageOutput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedItemCount = 0;
        List<OutputListResponseSplitCollectionSemanticPageOutputItem> expectedItems =
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
        ];
        long expectedPageCount = 0;

        Assert.Equal(expectedItemCount, deserialized.ItemCount);
        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPageCount, deserialized.PageCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput { };

        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput
        {
            // Null should be interpreted as omitted for these properties
            ItemCount = null,
            Items = null,
            PageCount = null,
        };

        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput
        {
            // Null should be interpreted as omitted for these properties
            ItemCount = null,
            Items = null,
            PageCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutput
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
        };

        OutputListResponseSplitCollectionSemanticPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitCollectionSemanticPageOutputItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem
        {
            ItemClass = "itemClass",
            ItemClassCount = 0,
            ItemClassOffset = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            PageEnd = 0,
            PageStart = 0,
            S3Url = "s3URL",
        };

        string expectedItemClass = "itemClass";
        long expectedItemClassCount = 0;
        long expectedItemClassOffset = 0;
        long expectedItemOffset = 0;
        string expectedItemReferenceID = "itemReferenceID";
        long expectedPageEnd = 0;
        long expectedPageStart = 0;
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedItemClass, model.ItemClass);
        Assert.Equal(expectedItemClassCount, model.ItemClassCount);
        Assert.Equal(expectedItemClassOffset, model.ItemClassOffset);
        Assert.Equal(expectedItemOffset, model.ItemOffset);
        Assert.Equal(expectedItemReferenceID, model.ItemReferenceID);
        Assert.Equal(expectedPageEnd, model.PageEnd);
        Assert.Equal(expectedPageStart, model.PageStart);
        Assert.Equal(expectedS3Url, model.S3Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem
        {
            ItemClass = "itemClass",
            ItemClassCount = 0,
            ItemClassOffset = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            PageEnd = 0,
            PageStart = 0,
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitCollectionSemanticPageOutputItem>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem
        {
            ItemClass = "itemClass",
            ItemClassCount = 0,
            ItemClassOffset = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            PageEnd = 0,
            PageStart = 0,
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitCollectionSemanticPageOutputItem>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedItemClass = "itemClass";
        long expectedItemClassCount = 0;
        long expectedItemClassOffset = 0;
        long expectedItemOffset = 0;
        string expectedItemReferenceID = "itemReferenceID";
        long expectedPageEnd = 0;
        long expectedPageStart = 0;
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedItemClass, deserialized.ItemClass);
        Assert.Equal(expectedItemClassCount, deserialized.ItemClassCount);
        Assert.Equal(expectedItemClassOffset, deserialized.ItemClassOffset);
        Assert.Equal(expectedItemOffset, deserialized.ItemOffset);
        Assert.Equal(expectedItemReferenceID, deserialized.ItemReferenceID);
        Assert.Equal(expectedPageEnd, deserialized.PageEnd);
        Assert.Equal(expectedPageStart, deserialized.PageStart);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem
        {
            ItemClass = "itemClass",
            ItemClassCount = 0,
            ItemClassOffset = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            PageEnd = 0,
            PageStart = 0,
            S3Url = "s3URL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem { };

        Assert.Null(model.ItemClass);
        Assert.False(model.RawData.ContainsKey("itemClass"));
        Assert.Null(model.ItemClassCount);
        Assert.False(model.RawData.ContainsKey("itemClassCount"));
        Assert.Null(model.ItemClassOffset);
        Assert.False(model.RawData.ContainsKey("itemClassOffset"));
        Assert.Null(model.ItemOffset);
        Assert.False(model.RawData.ContainsKey("itemOffset"));
        Assert.Null(model.ItemReferenceID);
        Assert.False(model.RawData.ContainsKey("itemReferenceID"));
        Assert.Null(model.PageEnd);
        Assert.False(model.RawData.ContainsKey("pageEnd"));
        Assert.Null(model.PageStart);
        Assert.False(model.RawData.ContainsKey("pageStart"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem
        {
            // Null should be interpreted as omitted for these properties
            ItemClass = null,
            ItemClassCount = null,
            ItemClassOffset = null,
            ItemOffset = null,
            ItemReferenceID = null,
            PageEnd = null,
            PageStart = null,
            S3Url = null,
        };

        Assert.Null(model.ItemClass);
        Assert.False(model.RawData.ContainsKey("itemClass"));
        Assert.Null(model.ItemClassCount);
        Assert.False(model.RawData.ContainsKey("itemClassCount"));
        Assert.Null(model.ItemClassOffset);
        Assert.False(model.RawData.ContainsKey("itemClassOffset"));
        Assert.Null(model.ItemOffset);
        Assert.False(model.RawData.ContainsKey("itemOffset"));
        Assert.Null(model.ItemReferenceID);
        Assert.False(model.RawData.ContainsKey("itemReferenceID"));
        Assert.Null(model.PageEnd);
        Assert.False(model.RawData.ContainsKey("pageEnd"));
        Assert.Null(model.PageStart);
        Assert.False(model.RawData.ContainsKey("pageStart"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem
        {
            // Null should be interpreted as omitted for these properties
            ItemClass = null,
            ItemClassCount = null,
            ItemClassOffset = null,
            ItemOffset = null,
            ItemReferenceID = null,
            PageEnd = null,
            PageStart = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitCollectionSemanticPageOutputItem
        {
            ItemClass = "itemClass",
            ItemClassCount = 0,
            ItemClassOffset = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            PageEnd = 0,
            PageStart = 0,
            S3Url = "s3URL",
        };

        OutputListResponseSplitCollectionSemanticPageOutputItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitCollectionEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseSplitCollectionEventType.SplitCollection)]
    public void Validation_Works(OutputListResponseSplitCollectionEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSplitCollectionEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitCollectionEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseSplitCollectionEventType.SplitCollection)]
    public void SerializationRoundtrip_Works(OutputListResponseSplitCollectionEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSplitCollectionEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitCollectionEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitCollectionEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitCollectionEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseSplitCollectionMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitCollectionMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitCollectionMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitCollectionMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitCollectionMetadata>(
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
        var model = new OutputListResponseSplitCollectionMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSplitCollectionMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitCollectionMetadata
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
        var model = new OutputListResponseSplitCollectionMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitCollectionMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        OutputListResponseSplitCollectionMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseSplitItemEventType.SplitItem,
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

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, OutputListResponseSplitItemOutputType> expectedOutputType =
            OutputListResponseSplitItemOutputType.PrintPage;
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseSplitItemEventType> expectedEventType =
            OutputListResponseSplitItemEventType.SplitItem;
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
        OutputListResponseSplitItemMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        OutputListResponseSplitItemPrintPageOutput expectedPrintPageOutput = new()
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };
        OutputListResponseSplitItemSemanticPageOutput expectedSemanticPageOutput = new()
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
        };
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedOutputType, model.OutputType);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedFunctionCallID, model.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, model.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, model.FunctionVersionNum);
        Assert.Equal(expectedInboundEmail, model.InboundEmail);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedPrintPageOutput, model.PrintPageOutput);
        Assert.Equal(expectedSemanticPageOutput, model.SemanticPageOutput);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseSplitItemEventType.SplitItem,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseSplitItemEventType.SplitItem,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, OutputListResponseSplitItemOutputType> expectedOutputType =
            OutputListResponseSplitItemOutputType.PrintPage;
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseSplitItemEventType> expectedEventType =
            OutputListResponseSplitItemEventType.SplitItem;
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
        OutputListResponseSplitItemMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        OutputListResponseSplitItemPrintPageOutput expectedPrintPageOutput = new()
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };
        OutputListResponseSplitItemSemanticPageOutput expectedSemanticPageOutput = new()
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
        };
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedOutputType, deserialized.OutputType);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedFunctionCallID, deserialized.FunctionCallID);
        Assert.Equal(expectedFunctionCallTryNumber, deserialized.FunctionCallTryNumber);
        Assert.Equal(expectedFunctionVersionNum, deserialized.FunctionVersionNum);
        Assert.Equal(expectedInboundEmail, deserialized.InboundEmail);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedPrintPageOutput, deserialized.PrintPageOutput);
        Assert.Equal(expectedSemanticPageOutput, deserialized.SemanticPageOutput);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseSplitItemEventType.SplitItem,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
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
        Assert.Null(model.PrintPageOutput);
        Assert.False(model.RawData.ContainsKey("printPageOutput"));
        Assert.Null(model.SemanticPageOutput);
        Assert.False(model.RawData.ContainsKey("semanticPageOutput"));
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
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
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
            PrintPageOutput = null,
            SemanticPageOutput = null,
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
        Assert.Null(model.PrintPageOutput);
        Assert.False(model.RawData.ContainsKey("printPageOutput"));
        Assert.Null(model.SemanticPageOutput);
        Assert.False(model.RawData.ContainsKey("semanticPageOutput"));
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
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
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
            PrintPageOutput = null,
            SemanticPageOutput = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = OutputListResponseSplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseSplitItemEventType.SplitItem,
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

        OutputListResponseSplitItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitItemOutputTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseSplitItemOutputType.PrintPage)]
    [InlineData(OutputListResponseSplitItemOutputType.SemanticPage)]
    public void Validation_Works(OutputListResponseSplitItemOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSplitItemOutputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitItemOutputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseSplitItemOutputType.PrintPage)]
    [InlineData(OutputListResponseSplitItemOutputType.SemanticPage)]
    public void SerializationRoundtrip_Works(OutputListResponseSplitItemOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSplitItemOutputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitItemOutputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitItemOutputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitItemOutputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseSplitItemEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseSplitItemEventType.SplitItem)]
    public void Validation_Works(OutputListResponseSplitItemEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSplitItemEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitItemEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseSplitItemEventType.SplitItem)]
    public void SerializationRoundtrip_Works(OutputListResponseSplitItemEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSplitItemEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitItemEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitItemEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSplitItemEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseSplitItemMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitItemMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitItemMetadata>(
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
        var model = new OutputListResponseSplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitItemMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSplitItemMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitItemMetadata
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
        var model = new OutputListResponseSplitItemMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        OutputListResponseSplitItemMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitItemPrintPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        string expectedCollectionReferenceID = "collectionReferenceID";
        long expectedItemCount = 0;
        long expectedItemOffset = 0;
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedCollectionReferenceID, model.CollectionReferenceID);
        Assert.Equal(expectedItemCount, model.ItemCount);
        Assert.Equal(expectedItemOffset, model.ItemOffset);
        Assert.Equal(expectedS3Url, model.S3Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitItemPrintPageOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSplitItemPrintPageOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionReferenceID = "collectionReferenceID";
        long expectedItemCount = 0;
        long expectedItemOffset = 0;
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedCollectionReferenceID, deserialized.CollectionReferenceID);
        Assert.Equal(expectedItemCount, deserialized.ItemCount);
        Assert.Equal(expectedItemOffset, deserialized.ItemOffset);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput { };

        Assert.Null(model.CollectionReferenceID);
        Assert.False(model.RawData.ContainsKey("collectionReferenceID"));
        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.ItemOffset);
        Assert.False(model.RawData.ContainsKey("itemOffset"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput
        {
            // Null should be interpreted as omitted for these properties
            CollectionReferenceID = null,
            ItemCount = null,
            ItemOffset = null,
            S3Url = null,
        };

        Assert.Null(model.CollectionReferenceID);
        Assert.False(model.RawData.ContainsKey("collectionReferenceID"));
        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.ItemOffset);
        Assert.False(model.RawData.ContainsKey("itemOffset"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput
        {
            // Null should be interpreted as omitted for these properties
            CollectionReferenceID = null,
            ItemCount = null,
            ItemOffset = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitItemPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        OutputListResponseSplitItemPrintPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSplitItemSemanticPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput
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
        };

        string expectedCollectionReferenceID = "collectionReferenceID";
        string expectedItemClass = "itemClass";
        long expectedItemClassCount = 0;
        long expectedItemClassOffset = 0;
        long expectedItemCount = 0;
        long expectedItemOffset = 0;
        long expectedPageCount = 0;
        long expectedPageEnd = 0;
        long expectedPageStart = 0;
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedCollectionReferenceID, model.CollectionReferenceID);
        Assert.Equal(expectedItemClass, model.ItemClass);
        Assert.Equal(expectedItemClassCount, model.ItemClassCount);
        Assert.Equal(expectedItemClassOffset, model.ItemClassOffset);
        Assert.Equal(expectedItemCount, model.ItemCount);
        Assert.Equal(expectedItemOffset, model.ItemOffset);
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.Equal(expectedPageEnd, model.PageEnd);
        Assert.Equal(expectedPageStart, model.PageStart);
        Assert.Equal(expectedS3Url, model.S3Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitItemSemanticPageOutput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseSplitItemSemanticPageOutput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCollectionReferenceID = "collectionReferenceID";
        string expectedItemClass = "itemClass";
        long expectedItemClassCount = 0;
        long expectedItemClassOffset = 0;
        long expectedItemCount = 0;
        long expectedItemOffset = 0;
        long expectedPageCount = 0;
        long expectedPageEnd = 0;
        long expectedPageStart = 0;
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedCollectionReferenceID, deserialized.CollectionReferenceID);
        Assert.Equal(expectedItemClass, deserialized.ItemClass);
        Assert.Equal(expectedItemClassCount, deserialized.ItemClassCount);
        Assert.Equal(expectedItemClassOffset, deserialized.ItemClassOffset);
        Assert.Equal(expectedItemCount, deserialized.ItemCount);
        Assert.Equal(expectedItemOffset, deserialized.ItemOffset);
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.Equal(expectedPageEnd, deserialized.PageEnd);
        Assert.Equal(expectedPageStart, deserialized.PageStart);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput { };

        Assert.Null(model.CollectionReferenceID);
        Assert.False(model.RawData.ContainsKey("collectionReferenceID"));
        Assert.Null(model.ItemClass);
        Assert.False(model.RawData.ContainsKey("itemClass"));
        Assert.Null(model.ItemClassCount);
        Assert.False(model.RawData.ContainsKey("itemClassCount"));
        Assert.Null(model.ItemClassOffset);
        Assert.False(model.RawData.ContainsKey("itemClassOffset"));
        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.ItemOffset);
        Assert.False(model.RawData.ContainsKey("itemOffset"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.PageEnd);
        Assert.False(model.RawData.ContainsKey("pageEnd"));
        Assert.Null(model.PageStart);
        Assert.False(model.RawData.ContainsKey("pageStart"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput
        {
            // Null should be interpreted as omitted for these properties
            CollectionReferenceID = null,
            ItemClass = null,
            ItemClassCount = null,
            ItemClassOffset = null,
            ItemCount = null,
            ItemOffset = null,
            PageCount = null,
            PageEnd = null,
            PageStart = null,
            S3Url = null,
        };

        Assert.Null(model.CollectionReferenceID);
        Assert.False(model.RawData.ContainsKey("collectionReferenceID"));
        Assert.Null(model.ItemClass);
        Assert.False(model.RawData.ContainsKey("itemClass"));
        Assert.Null(model.ItemClassCount);
        Assert.False(model.RawData.ContainsKey("itemClassCount"));
        Assert.Null(model.ItemClassOffset);
        Assert.False(model.RawData.ContainsKey("itemClassOffset"));
        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.ItemOffset);
        Assert.False(model.RawData.ContainsKey("itemOffset"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.PageEnd);
        Assert.False(model.RawData.ContainsKey("pageEnd"));
        Assert.Null(model.PageStart);
        Assert.False(model.RawData.ContainsKey("pageStart"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput
        {
            // Null should be interpreted as omitted for these properties
            CollectionReferenceID = null,
            ItemClass = null,
            ItemClassCount = null,
            ItemClassOffset = null,
            ItemCount = null,
            ItemOffset = null,
            PageCount = null,
            PageEnd = null,
            PageStart = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSplitItemSemanticPageOutput
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
        };

        OutputListResponseSplitItemSemanticPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseJoinTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        List<OutputListResponseJoinItem> expectedItems =
        [
            new()
            {
                ItemCount = 0,
                ItemOffset = 0,
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, OutputListResponseJoinJoinType> expectedJoinType =
            OutputListResponseJoinJoinType.Standard;
        string expectedReferenceID = "referenceID";
        JsonElement expectedTransformedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        float expectedAvgConfidence = 0;
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseJoinEventType> expectedEventType =
            OutputListResponseJoinEventType.Join;
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
        OutputListResponseJoinMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseJoin>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseJoin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        List<string> expectedInvalidProperties = ["string"];
        List<OutputListResponseJoinItem> expectedItems =
        [
            new()
            {
                ItemCount = 0,
                ItemOffset = 0,
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];
        ApiEnum<string, OutputListResponseJoinJoinType> expectedJoinType =
            OutputListResponseJoinJoinType.Standard;
        string expectedReferenceID = "referenceID";
        JsonElement expectedTransformedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        float expectedAvgConfidence = 0;
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OutputListResponseJoinEventType> expectedEventType =
            OutputListResponseJoinEventType.Join;
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
        OutputListResponseJoinMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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
        var model = new OutputListResponseJoin
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
            JoinType = OutputListResponseJoinJoinType.Standard,
            ReferenceID = "referenceID",
            TransformedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            AvgConfidence = 0,
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseJoinEventType.Join,
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

        OutputListResponseJoin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseJoinItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseJoinItem
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
        var model = new OutputListResponseJoinItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseJoinItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseJoinItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseJoinItem>(
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
        var model = new OutputListResponseJoinItem
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
        var model = new OutputListResponseJoinItem
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
        var model = new OutputListResponseJoinItem
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
        var model = new OutputListResponseJoinItem
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
        var model = new OutputListResponseJoinItem
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
        var model = new OutputListResponseJoinItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        OutputListResponseJoinItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseJoinJoinTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseJoinJoinType.Standard)]
    public void Validation_Works(OutputListResponseJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseJoinJoinType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseJoinJoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseJoinJoinType.Standard)]
    public void SerializationRoundtrip_Works(OutputListResponseJoinJoinType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseJoinJoinType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseJoinJoinType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseJoinJoinType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseJoinJoinType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseJoinEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseJoinEventType.Join)]
    public void Validation_Works(OutputListResponseJoinEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseJoinEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseJoinEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseJoinEventType.Join)]
    public void SerializationRoundtrip_Works(OutputListResponseJoinEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseJoinEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseJoinEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseJoinEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseJoinEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseJoinMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseJoinMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseJoinMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseJoinMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseJoinMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseJoinMetadata>(
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
        var model = new OutputListResponseJoinMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseJoinMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseJoinMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseJoinMetadata
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
        var model = new OutputListResponseJoinMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseJoinMetadata { DurationFunctionToEventSeconds = 0 };

        OutputListResponseJoinMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseEnrichTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseEnrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseEnrichEventType.Enrich,
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
        ApiEnum<string, OutputListResponseEnrichEventType> expectedEventType =
            OutputListResponseEnrichEventType.Enrich;
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
        OutputListResponseEnrichMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
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
        var model = new OutputListResponseEnrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseEnrichEventType.Enrich,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseEnrich>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseEnrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseEnrichEventType.Enrich,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseEnrich>(
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
        ApiEnum<string, OutputListResponseEnrichEventType> expectedEventType =
            OutputListResponseEnrichEventType.Enrich;
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
        OutputListResponseEnrichMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
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
        var model = new OutputListResponseEnrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseEnrichEventType.Enrich,
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
        var model = new OutputListResponseEnrich
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
        var model = new OutputListResponseEnrich
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
        var model = new OutputListResponseEnrich
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
        var model = new OutputListResponseEnrich
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
        var model = new OutputListResponseEnrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = OutputListResponseEnrichEventType.Enrich,
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

        OutputListResponseEnrich copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseEnrichEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseEnrichEventType.Enrich)]
    public void Validation_Works(OutputListResponseEnrichEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseEnrichEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseEnrichEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseEnrichEventType.Enrich)]
    public void SerializationRoundtrip_Works(OutputListResponseEnrichEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseEnrichEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseEnrichEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseEnrichEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseEnrichEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseEnrichMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseEnrichMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseEnrichMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseEnrichMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseEnrichMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseEnrichMetadata>(
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
        var model = new OutputListResponseEnrichMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseEnrichMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseEnrichMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseEnrichMetadata
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
        var model = new OutputListResponseEnrichMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseEnrichMetadata { DurationFunctionToEventSeconds = 0 };

        OutputListResponseEnrichMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseCollectionProcessingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = OutputListResponseCollectionProcessingEventType.CollectionProcessing,
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
        ApiEnum<string, OutputListResponseCollectionProcessingOperation> expectedOperation =
            OutputListResponseCollectionProcessingOperation.Add;
        long expectedProcessedCount = 0;
        string expectedReferenceID = "referenceID";
        ApiEnum<string, OutputListResponseCollectionProcessingStatus> expectedStatus =
            OutputListResponseCollectionProcessingStatus.Success;
        List<string> expectedCollectionItemIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        ApiEnum<string, OutputListResponseCollectionProcessingEventType> expectedEventType =
            OutputListResponseCollectionProcessingEventType.CollectionProcessing;
        long expectedFunctionCallTryNumber = 0;
        Errors::InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        OutputListResponseCollectionProcessingMetadata expectedMetadata = new()
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
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = OutputListResponseCollectionProcessingEventType.CollectionProcessing,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseCollectionProcessing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = OutputListResponseCollectionProcessingEventType.CollectionProcessing,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseCollectionProcessing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        string expectedEventID = "eventID";
        ApiEnum<string, OutputListResponseCollectionProcessingOperation> expectedOperation =
            OutputListResponseCollectionProcessingOperation.Add;
        long expectedProcessedCount = 0;
        string expectedReferenceID = "referenceID";
        ApiEnum<string, OutputListResponseCollectionProcessingStatus> expectedStatus =
            OutputListResponseCollectionProcessingStatus.Success;
        List<string> expectedCollectionItemIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        ApiEnum<string, OutputListResponseCollectionProcessingEventType> expectedEventType =
            OutputListResponseCollectionProcessingEventType.CollectionProcessing;
        long expectedFunctionCallTryNumber = 0;
        Errors::InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        OutputListResponseCollectionProcessingMetadata expectedMetadata = new()
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
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = OutputListResponseCollectionProcessingEventType.CollectionProcessing,
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
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
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
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,

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
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,

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
        var model = new OutputListResponseCollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = OutputListResponseCollectionProcessingOperation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = OutputListResponseCollectionProcessingStatus.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = OutputListResponseCollectionProcessingEventType.CollectionProcessing,
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

        OutputListResponseCollectionProcessing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseCollectionProcessingOperationTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseCollectionProcessingOperation.Add)]
    [InlineData(OutputListResponseCollectionProcessingOperation.Update)]
    public void Validation_Works(OutputListResponseCollectionProcessingOperation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseCollectionProcessingOperation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingOperation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseCollectionProcessingOperation.Add)]
    [InlineData(OutputListResponseCollectionProcessingOperation.Update)]
    public void SerializationRoundtrip_Works(
        OutputListResponseCollectionProcessingOperation rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseCollectionProcessingOperation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingOperation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseCollectionProcessingStatusTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseCollectionProcessingStatus.Success)]
    [InlineData(OutputListResponseCollectionProcessingStatus.Failed)]
    public void Validation_Works(OutputListResponseCollectionProcessingStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseCollectionProcessingStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseCollectionProcessingStatus.Success)]
    [InlineData(OutputListResponseCollectionProcessingStatus.Failed)]
    public void SerializationRoundtrip_Works(OutputListResponseCollectionProcessingStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseCollectionProcessingStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseCollectionProcessingEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseCollectionProcessingEventType.CollectionProcessing)]
    public void Validation_Works(OutputListResponseCollectionProcessingEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseCollectionProcessingEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseCollectionProcessingEventType.CollectionProcessing)]
    public void SerializationRoundtrip_Works(
        OutputListResponseCollectionProcessingEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseCollectionProcessingEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseCollectionProcessingEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseCollectionProcessingMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseCollectionProcessingMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseCollectionProcessingMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseCollectionProcessingMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseCollectionProcessingMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OutputListResponseCollectionProcessingMetadata>(
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
        var model = new OutputListResponseCollectionProcessingMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseCollectionProcessingMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseCollectionProcessingMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseCollectionProcessingMetadata
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
        var model = new OutputListResponseCollectionProcessingMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseCollectionProcessingMetadata
        {
            DurationFunctionToEventSeconds = 0,
        };

        OutputListResponseCollectionProcessingMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = OutputListResponseSendEventType.Send,
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

        ApiEnum<string, OutputListResponseSendDeliveryStatus> expectedDeliveryStatus =
            OutputListResponseSendDeliveryStatus.Success;
        ApiEnum<string, OutputListResponseSendDestinationType> expectedDestinationType =
            OutputListResponseSendDestinationType.Webhook;
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedDeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, OutputListResponseSendEventType> expectedEventType =
            OutputListResponseSendEventType.Send;
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        OutputListResponseSendGoogleDriveOutput expectedGoogleDriveOutput = new()
        {
            FileName = "fileName",
            FolderID = "folderID",
        };
        Errors::InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        OutputListResponseSendMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        OutputListResponseSendS3Output expectedS3Output = new()
        {
            BucketName = "bucketName",
            Key = "key",
        };
        OutputListResponseSendWebhookOutput expectedWebhookOutput = new()
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
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = OutputListResponseSendEventType.Send,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = OutputListResponseSendEventType.Send,
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
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, OutputListResponseSendDeliveryStatus> expectedDeliveryStatus =
            OutputListResponseSendDeliveryStatus.Success;
        ApiEnum<string, OutputListResponseSendDestinationType> expectedDestinationType =
            OutputListResponseSendDestinationType.Webhook;
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedDeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, OutputListResponseSendEventType> expectedEventType =
            OutputListResponseSendEventType.Send;
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        OutputListResponseSendGoogleDriveOutput expectedGoogleDriveOutput = new()
        {
            FileName = "fileName",
            FolderID = "folderID",
        };
        Errors::InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        OutputListResponseSendMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        OutputListResponseSendS3Output expectedS3Output = new()
        {
            BucketName = "bucketName",
            Key = "key",
        };
        OutputListResponseSendWebhookOutput expectedWebhookOutput = new()
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
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = OutputListResponseSendEventType.Send,
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
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
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
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
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
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
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
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
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
        var model = new OutputListResponseSend
        {
            DeliveryStatus = OutputListResponseSendDeliveryStatus.Success,
            DestinationType = OutputListResponseSendDestinationType.Webhook,
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = OutputListResponseSendEventType.Send,
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

        OutputListResponseSend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSendDeliveryStatusTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseSendDeliveryStatus.Success)]
    [InlineData(OutputListResponseSendDeliveryStatus.Skip)]
    public void Validation_Works(OutputListResponseSendDeliveryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSendDeliveryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendDeliveryStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseSendDeliveryStatus.Success)]
    [InlineData(OutputListResponseSendDeliveryStatus.Skip)]
    public void SerializationRoundtrip_Works(OutputListResponseSendDeliveryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSendDeliveryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendDeliveryStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendDeliveryStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendDeliveryStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseSendDestinationTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseSendDestinationType.Webhook)]
    [InlineData(OutputListResponseSendDestinationType.S3)]
    [InlineData(OutputListResponseSendDestinationType.GoogleDrive)]
    public void Validation_Works(OutputListResponseSendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSendDestinationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendDestinationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseSendDestinationType.Webhook)]
    [InlineData(OutputListResponseSendDestinationType.S3)]
    [InlineData(OutputListResponseSendDestinationType.GoogleDrive)]
    public void SerializationRoundtrip_Works(OutputListResponseSendDestinationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSendDestinationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendDestinationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendDestinationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendDestinationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseSendEventTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputListResponseSendEventType.Send)]
    public void Validation_Works(OutputListResponseSendEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSendEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseSendEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputListResponseSendEventType.Send)]
    public void SerializationRoundtrip_Works(OutputListResponseSendEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputListResponseSendEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputListResponseSendEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputListResponseSendEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputListResponseSendGoogleDriveOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSendGoogleDriveOutput
        {
            FileName = "fileName",
            FolderID = "folderID",
        };

        string expectedFileName = "fileName";
        string expectedFolderID = "folderID";

        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedFolderID, model.FolderID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSendGoogleDriveOutput
        {
            FileName = "fileName",
            FolderID = "folderID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSendGoogleDriveOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSendGoogleDriveOutput
        {
            FileName = "fileName",
            FolderID = "folderID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSendGoogleDriveOutput>(
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
        var model = new OutputListResponseSendGoogleDriveOutput
        {
            FileName = "fileName",
            FolderID = "folderID",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSendGoogleDriveOutput
        {
            FileName = "fileName",
            FolderID = "folderID",
        };

        OutputListResponseSendGoogleDriveOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSendMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSendMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSendMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSendMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSendMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSendMetadata>(
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
        var model = new OutputListResponseSendMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputListResponseSendMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputListResponseSendMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputListResponseSendMetadata
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
        var model = new OutputListResponseSendMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSendMetadata { DurationFunctionToEventSeconds = 0 };

        OutputListResponseSendMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSendS3OutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSendS3Output { BucketName = "bucketName", Key = "key" };

        string expectedBucketName = "bucketName";
        string expectedKey = "key";

        Assert.Equal(expectedBucketName, model.BucketName);
        Assert.Equal(expectedKey, model.Key);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSendS3Output { BucketName = "bucketName", Key = "key" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSendS3Output>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSendS3Output { BucketName = "bucketName", Key = "key" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSendS3Output>(
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
        var model = new OutputListResponseSendS3Output { BucketName = "bucketName", Key = "key" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSendS3Output { BucketName = "bucketName", Key = "key" };

        OutputListResponseSendS3Output copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputListResponseSendWebhookOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListResponseSendWebhookOutput
        {
            HttpResponseBody = "httpResponseBody",
            HttpStatusCode = 0,
        };

        string expectedHttpResponseBody = "httpResponseBody";
        long expectedHttpStatusCode = 0;

        Assert.Equal(expectedHttpResponseBody, model.HttpResponseBody);
        Assert.Equal(expectedHttpStatusCode, model.HttpStatusCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListResponseSendWebhookOutput
        {
            HttpResponseBody = "httpResponseBody",
            HttpStatusCode = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSendWebhookOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListResponseSendWebhookOutput
        {
            HttpResponseBody = "httpResponseBody",
            HttpStatusCode = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListResponseSendWebhookOutput>(
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
        var model = new OutputListResponseSendWebhookOutput
        {
            HttpResponseBody = "httpResponseBody",
            HttpStatusCode = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListResponseSendWebhookOutput
        {
            HttpResponseBody = "httpResponseBody",
            HttpStatusCode = 0,
        };

        OutputListResponseSendWebhookOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}
