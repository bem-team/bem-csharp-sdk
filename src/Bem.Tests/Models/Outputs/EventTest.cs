using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Outputs;
using Errors = Bem.Models.Errors;

namespace Bem.Tests.Models.Outputs;

public class EventTest : TestBase
{
    [Fact]
    public void TransformValidationWorks()
    {
        Event value = new Transform()
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
                MetricsValue = new()
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
    public void RouteValidationWorks()
    {
        Event value = new Route()
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = RouteEventType.Route,
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
        Event value = new SplitCollection()
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
            EventType = SplitCollectionEventType.SplitCollection,
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
        Event value = new SplitItem()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemEventType.SplitItem,
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
    public void ErrorValidationWorks()
    {
        Event value = new Errors::ErrorEvent()
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
        Event value = new Join()
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
            EventType = JoinEventType.Join,
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
        Event value = new Enrich()
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichEventType.Enrich,
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
        Event value = new CollectionProcessing()
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingEventType.CollectionProcessing,
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
    public void TransformSerializationRoundtripWorks()
    {
        Event value = new Transform()
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
                MetricsValue = new()
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
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RouteSerializationRoundtripWorks()
    {
        Event value = new Route()
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = RouteEventType.Route,
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
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitCollectionSerializationRoundtripWorks()
    {
        Event value = new SplitCollection()
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
            EventType = SplitCollectionEventType.SplitCollection,
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
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitItemSerializationRoundtripWorks()
    {
        Event value = new SplitItem()
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemEventType.SplitItem,
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
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        Event value = new Errors::ErrorEvent()
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
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JoinSerializationRoundtripWorks()
    {
        Event value = new Join()
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
            EventType = JoinEventType.Join,
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
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrichSerializationRoundtripWorks()
    {
        Event value = new Enrich()
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichEventType.Enrich,
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
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CollectionProcessingSerializationRoundtripWorks()
    {
        Event value = new CollectionProcessing()
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingEventType.CollectionProcessing,
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
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TransformTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
                MetricsValue = new()
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
        CorrectedContent expectedCorrectedContent = new Output()
        {
            OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EventType> expectedEventType = EventType.Transform;
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
        ApiEnum<string, InputType> expectedInputType = InputType.Csv;
        List<string> expectedInvalidProperties = ["string"];
        bool expectedIsRegression = true;
        string expectedLastPublishErrorAt = "lastPublishErrorAt";
        Metadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        Metrics expectedMetrics = new()
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
            MetricsValue = new()
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
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
                MetricsValue = new()
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
        var deserialized = JsonSerializer.Deserialize<Transform>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
                MetricsValue = new()
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
        var deserialized = JsonSerializer.Deserialize<Transform>(
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
        ApiEnum<string, EventType> expectedEventType = EventType.Transform;
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
        ApiEnum<string, InputType> expectedInputType = InputType.Csv;
        List<string> expectedInvalidProperties = ["string"];
        bool expectedIsRegression = true;
        string expectedLastPublishErrorAt = "lastPublishErrorAt";
        Metadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        Metrics expectedMetrics = new()
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
            MetricsValue = new()
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
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
                MetricsValue = new()
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
        var model = new Transform
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
                MetricsValue = new()
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
        var model = new Transform
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
                MetricsValue = new()
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
        var model = new Transform
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
                MetricsValue = new()
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
        var model = new Transform
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
                MetricsValue = new()
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
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
        var model = new Transform
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
            EventType = EventType.Transform,
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
            InputType = InputType.Csv,
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
                MetricsValue = new()
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

        Transform copied = new(model);

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

        List<AnyType?> expectedOutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")];

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

        List<AnyType?> expectedOutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")];

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
    [InlineData(EventType.Transform)]
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
    [InlineData(EventType.Transform)]
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

public class InputTypeTest : TestBase
{
    [Theory]
    [InlineData(InputType.Csv)]
    [InlineData(InputType.Docx)]
    [InlineData(InputType.Email)]
    [InlineData(InputType.Heic)]
    [InlineData(InputType.Html)]
    [InlineData(InputType.Jpeg)]
    [InlineData(InputType.Json)]
    [InlineData(InputType.Heif)]
    [InlineData(InputType.M4a)]
    [InlineData(InputType.Mp3)]
    [InlineData(InputType.Pdf)]
    [InlineData(InputType.Png)]
    [InlineData(InputType.Text)]
    [InlineData(InputType.Wav)]
    [InlineData(InputType.Webp)]
    [InlineData(InputType.Xls)]
    [InlineData(InputType.Xlsx)]
    [InlineData(InputType.Xml)]
    public void Validation_Works(InputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InputType.Csv)]
    [InlineData(InputType.Docx)]
    [InlineData(InputType.Email)]
    [InlineData(InputType.Heic)]
    [InlineData(InputType.Html)]
    [InlineData(InputType.Jpeg)]
    [InlineData(InputType.Json)]
    [InlineData(InputType.Heif)]
    [InlineData(InputType.M4a)]
    [InlineData(InputType.Mp3)]
    [InlineData(InputType.Pdf)]
    [InlineData(InputType.Png)]
    [InlineData(InputType.Text)]
    [InlineData(InputType.Wav)]
    [InlineData(InputType.Webp)]
    [InlineData(InputType.Xls)]
    [InlineData(InputType.Xlsx)]
    [InlineData(InputType.Xml)]
    public void SerializationRoundtrip_Works(InputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

public class MetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metrics
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
            MetricsValue = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        List<Difference> expectedDifferences =
        [
            new()
            {
                Category = "category",
                CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonPointer = "jsonPointer",
            },
        ];
        MetricsMetrics expectedMetricsValue = new()
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
        Assert.Equal(expectedMetricsValue, model.MetricsValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metrics
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
            MetricsValue = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metrics>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metrics
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
            MetricsValue = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Difference> expectedDifferences =
        [
            new()
            {
                Category = "category",
                CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonPointer = "jsonPointer",
            },
        ];
        MetricsMetrics expectedMetricsValue = new()
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
        Assert.Equal(expectedMetricsValue, deserialized.MetricsValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metrics
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
            MetricsValue = new()
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
        var model = new Metrics { };

        Assert.Null(model.Differences);
        Assert.False(model.RawData.ContainsKey("differences"));
        Assert.Null(model.MetricsValue);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metrics { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Metrics
        {
            // Null should be interpreted as omitted for these properties
            Differences = null,
            MetricsValue = null,
        };

        Assert.Null(model.Differences);
        Assert.False(model.RawData.ContainsKey("differences"));
        Assert.Null(model.MetricsValue);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metrics
        {
            // Null should be interpreted as omitted for these properties
            Differences = null,
            MetricsValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metrics
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
            MetricsValue = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Precision = 0,
                Recall = 0,
            },
        };

        Metrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DifferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Difference
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
        var model = new Difference
        {
            Category = "category",
            CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonPointer = "jsonPointer",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Difference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Difference
        {
            Category = "category",
            CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonPointer = "jsonPointer",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Difference>(
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
        var model = new Difference
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
        var model = new Difference { };

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
        var model = new Difference { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Difference
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
        var model = new Difference
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
        var model = new Difference
        {
            Category = "category",
            CorrectedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            ExtractedVal = JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonPointer = "jsonPointer",
        };

        Difference copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetricsMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetricsMetrics
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
        var model = new MetricsMetrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetricsMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MetricsMetrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetricsMetrics>(
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
        var model = new MetricsMetrics
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
        var model = new MetricsMetrics { };

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
        var model = new MetricsMetrics { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MetricsMetrics
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
        var model = new MetricsMetrics
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
        var model = new MetricsMetrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        MetricsMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RouteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Route
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = RouteEventType.Route,
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
        ApiEnum<string, RouteEventType> expectedEventType = RouteEventType.Route;
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
        RouteMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
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
        var model = new Route
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = RouteEventType.Route,
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
        var deserialized = JsonSerializer.Deserialize<Route>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Route
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = RouteEventType.Route,
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
        var deserialized = JsonSerializer.Deserialize<Route>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedChoice = "choice";
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RouteEventType> expectedEventType = RouteEventType.Route;
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
        RouteMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
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
        var model = new Route
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = RouteEventType.Route,
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
        var model = new Route
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
        var model = new Route
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
        var model = new Route
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
        var model = new Route
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
        var model = new Route
        {
            Choice = "choice",
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = RouteEventType.Route,
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

        Route copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RouteEventTypeTest : TestBase
{
    [Theory]
    [InlineData(RouteEventType.Route)]
    public void Validation_Works(RouteEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RouteEventType.Route)]
    public void SerializationRoundtrip_Works(RouteEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RouteMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RouteMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RouteMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RouteMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteMetadata>(
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
        var model = new RouteMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RouteMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RouteMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RouteMetadata
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
        var model = new RouteMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RouteMetadata { DurationFunctionToEventSeconds = 0 };

        RouteMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitCollectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitCollection
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
            EventType = SplitCollectionEventType.SplitCollection,
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
        ApiEnum<string, OutputType> expectedOutputType = OutputType.PrintPage;
        PrintPageOutput expectedPrintPageOutput = new()
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
        SemanticPageOutput expectedSemanticPageOutput = new()
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
        ApiEnum<string, SplitCollectionEventType> expectedEventType =
            SplitCollectionEventType.SplitCollection;
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
        SplitCollectionMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
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
        var model = new SplitCollection
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
            EventType = SplitCollectionEventType.SplitCollection,
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
        var deserialized = JsonSerializer.Deserialize<SplitCollection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitCollection
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
            EventType = SplitCollectionEventType.SplitCollection,
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
        var deserialized = JsonSerializer.Deserialize<SplitCollection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, OutputType> expectedOutputType = OutputType.PrintPage;
        PrintPageOutput expectedPrintPageOutput = new()
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
        SemanticPageOutput expectedSemanticPageOutput = new()
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
        ApiEnum<string, SplitCollectionEventType> expectedEventType =
            SplitCollectionEventType.SplitCollection;
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
        SplitCollectionMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
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
        var model = new SplitCollection
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
            EventType = SplitCollectionEventType.SplitCollection,
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
        var model = new SplitCollection
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
        var model = new SplitCollection
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitCollection
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
        var model = new SplitCollection
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
        var model = new SplitCollection
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
            EventType = SplitCollectionEventType.SplitCollection,
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

        SplitCollection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputType.PrintPage)]
    [InlineData(OutputType.SemanticPage)]
    public void Validation_Works(OutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputType.PrintPage)]
    [InlineData(OutputType.SemanticPage)]
    public void SerializationRoundtrip_Works(OutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PrintPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PrintPageOutput
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
        List<Item> expectedItems =
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
        var model = new PrintPageOutput
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
        var deserialized = JsonSerializer.Deserialize<PrintPageOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PrintPageOutput
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
        var deserialized = JsonSerializer.Deserialize<PrintPageOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedItemCount = 0;
        List<Item> expectedItems =
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
        var model = new PrintPageOutput
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
        var model = new PrintPageOutput { };

        Assert.Null(model.ItemCount);
        Assert.False(model.RawData.ContainsKey("itemCount"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PrintPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PrintPageOutput
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
        var model = new PrintPageOutput
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
        var model = new PrintPageOutput
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

        PrintPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
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
        var model = new Item
        {
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
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
        var model = new Item
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
        var model = new Item { };

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
        var model = new Item { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Item
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
        var model = new Item
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
        var model = new Item
        {
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SemanticPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SemanticPageOutput
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
        List<SemanticPageOutputItem> expectedItems =
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
        var model = new SemanticPageOutput
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
        var deserialized = JsonSerializer.Deserialize<SemanticPageOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SemanticPageOutput
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
        var deserialized = JsonSerializer.Deserialize<SemanticPageOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedItemCount = 0;
        List<SemanticPageOutputItem> expectedItems =
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
        var model = new SemanticPageOutput
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
        var model = new SemanticPageOutput { };

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
        var model = new SemanticPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SemanticPageOutput
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
        var model = new SemanticPageOutput
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
        var model = new SemanticPageOutput
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

        SemanticPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SemanticPageOutputItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SemanticPageOutputItem
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
        var model = new SemanticPageOutputItem
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
        var deserialized = JsonSerializer.Deserialize<SemanticPageOutputItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SemanticPageOutputItem
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
        var deserialized = JsonSerializer.Deserialize<SemanticPageOutputItem>(
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
        var model = new SemanticPageOutputItem
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
        var model = new SemanticPageOutputItem { };

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
        var model = new SemanticPageOutputItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SemanticPageOutputItem
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
        var model = new SemanticPageOutputItem
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
        var model = new SemanticPageOutputItem
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

        SemanticPageOutputItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitCollectionEventTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitCollectionEventType.SplitCollection)]
    public void Validation_Works(SplitCollectionEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCollectionEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitCollectionEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitCollectionEventType.SplitCollection)]
    public void SerializationRoundtrip_Works(SplitCollectionEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCollectionEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitCollectionEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitCollectionEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitCollectionEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SplitCollectionMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitCollectionMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitCollectionMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCollectionMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitCollectionMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCollectionMetadata>(
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
        var model = new SplitCollectionMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitCollectionMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitCollectionMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitCollectionMetadata
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
        var model = new SplitCollectionMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitCollectionMetadata { DurationFunctionToEventSeconds = 0 };

        SplitCollectionMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemEventType.SplitItem,
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
        ApiEnum<string, SplitItemOutputType> expectedOutputType = SplitItemOutputType.PrintPage;
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SplitItemEventType> expectedEventType = SplitItemEventType.SplitItem;
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
        SplitItemMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        SplitItemPrintPageOutput expectedPrintPageOutput = new()
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };
        SplitItemSemanticPageOutput expectedSemanticPageOutput = new()
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
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemEventType.SplitItem,
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
        var deserialized = JsonSerializer.Deserialize<SplitItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemEventType.SplitItem,
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
        var deserialized = JsonSerializer.Deserialize<SplitItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, SplitItemOutputType> expectedOutputType = SplitItemOutputType.PrintPage;
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SplitItemEventType> expectedEventType = SplitItemEventType.SplitItem;
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
        SplitItemMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
        SplitItemPrintPageOutput expectedPrintPageOutput = new()
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };
        SplitItemSemanticPageOutput expectedSemanticPageOutput = new()
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
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemEventType.SplitItem,
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
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
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
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
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
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
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
        var model = new SplitItem
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemEventType.SplitItem,
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

        SplitItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitItemOutputTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitItemOutputType.PrintPage)]
    [InlineData(SplitItemOutputType.SemanticPage)]
    public void Validation_Works(SplitItemOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitItemOutputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitItemOutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitItemOutputType.PrintPage)]
    [InlineData(SplitItemOutputType.SemanticPage)]
    public void SerializationRoundtrip_Works(SplitItemOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitItemOutputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitItemOutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitItemOutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitItemOutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SplitItemEventTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitItemEventType.SplitItem)]
    public void Validation_Works(SplitItemEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitItemEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitItemEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitItemEventType.SplitItem)]
    public void SerializationRoundtrip_Works(SplitItemEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitItemEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitItemEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitItemEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitItemEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SplitItemMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitItemMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitItemMetadata>(
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
        var model = new SplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitItemMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitItemMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitItemMetadata
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
        var model = new SplitItemMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitItemMetadata { DurationFunctionToEventSeconds = 0 };

        SplitItemMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitItemPrintPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitItemPrintPageOutput
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
        var model = new SplitItemPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitItemPrintPageOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitItemPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitItemPrintPageOutput>(
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
        var model = new SplitItemPrintPageOutput
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
        var model = new SplitItemPrintPageOutput { };

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
        var model = new SplitItemPrintPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitItemPrintPageOutput
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
        var model = new SplitItemPrintPageOutput
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
        var model = new SplitItemPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        SplitItemPrintPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitItemSemanticPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitItemSemanticPageOutput
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
        var model = new SplitItemSemanticPageOutput
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
        var deserialized = JsonSerializer.Deserialize<SplitItemSemanticPageOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitItemSemanticPageOutput
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
        var deserialized = JsonSerializer.Deserialize<SplitItemSemanticPageOutput>(
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
        var model = new SplitItemSemanticPageOutput
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
        var model = new SplitItemSemanticPageOutput { };

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
        var model = new SplitItemSemanticPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitItemSemanticPageOutput
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
        var model = new SplitItemSemanticPageOutput
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
        var model = new SplitItemSemanticPageOutput
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

        SplitItemSemanticPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JoinTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Join
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
            EventType = JoinEventType.Join,
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
        List<JoinItem> expectedItems =
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
        ApiEnum<string, JoinEventType> expectedEventType = JoinEventType.Join;
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
        JoinMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
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
        var model = new Join
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
            EventType = JoinEventType.Join,
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
        var deserialized = JsonSerializer.Deserialize<Join>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Join
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
            EventType = JoinEventType.Join,
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
        var deserialized = JsonSerializer.Deserialize<Join>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        List<string> expectedInvalidProperties = ["string"];
        List<JoinItem> expectedItems =
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
        ApiEnum<string, JoinEventType> expectedEventType = JoinEventType.Join;
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
        JoinMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
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
        var model = new Join
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
            EventType = JoinEventType.Join,
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
        var model = new Join
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
        var model = new Join
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
        var model = new Join
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
        var model = new Join
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
        var model = new Join
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
            EventType = JoinEventType.Join,
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
        var model = new Join
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
            EventType = JoinEventType.Join,
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
        var model = new Join
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
            EventType = JoinEventType.Join,
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
        var model = new Join
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
            EventType = JoinEventType.Join,
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
        var model = new Join
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
            EventType = JoinEventType.Join,
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

        Join copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JoinItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JoinItem
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
        var model = new JoinItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JoinItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinItem>(
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
        var model = new JoinItem
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
        var model = new JoinItem
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
        var model = new JoinItem
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
        var model = new JoinItem
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
        var model = new JoinItem
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
        var model = new JoinItem
        {
            ItemCount = 0,
            ItemOffset = 0,
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        JoinItem copied = new(model);

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

public class JoinEventTypeTest : TestBase
{
    [Theory]
    [InlineData(JoinEventType.Join)]
    public void Validation_Works(JoinEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JoinEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JoinEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JoinEventType.Join)]
    public void SerializationRoundtrip_Works(JoinEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JoinEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JoinEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JoinEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JoinEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JoinMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JoinMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JoinMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JoinMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinMetadata>(
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
        var model = new JoinMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JoinMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JoinMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JoinMetadata
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
        var model = new JoinMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JoinMetadata { DurationFunctionToEventSeconds = 0 };

        JoinMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EnrichTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Enrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichEventType.Enrich,
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
        ApiEnum<string, EnrichEventType> expectedEventType = EnrichEventType.Enrich;
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
        EnrichMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
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
        var model = new Enrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichEventType.Enrich,
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
        var deserialized = JsonSerializer.Deserialize<Enrich>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Enrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichEventType.Enrich,
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
        var deserialized = JsonSerializer.Deserialize<Enrich>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedEnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EnrichEventType> expectedEventType = EnrichEventType.Enrich;
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
        EnrichMetadata expectedMetadata = new() { DurationFunctionToEventSeconds = 0 };
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
        var model = new Enrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichEventType.Enrich,
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
        var model = new Enrich
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
        var model = new Enrich
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
        var model = new Enrich
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
        var model = new Enrich
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
        var model = new Enrich
        {
            EnrichedContent = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = EnrichEventType.Enrich,
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

        Enrich copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EnrichEventTypeTest : TestBase
{
    [Theory]
    [InlineData(EnrichEventType.Enrich)]
    public void Validation_Works(EnrichEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EnrichEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EnrichEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EnrichEventType.Enrich)]
    public void SerializationRoundtrip_Works(EnrichEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EnrichEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EnrichEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EnrichEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EnrichEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EnrichMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnrichMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnrichMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EnrichMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnrichMetadata>(
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
        var model = new EnrichMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EnrichMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EnrichMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EnrichMetadata
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
        var model = new EnrichMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EnrichMetadata { DurationFunctionToEventSeconds = 0 };

        EnrichMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CollectionProcessingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingEventType.CollectionProcessing,
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
        ApiEnum<string, Status> expectedStatus = Status.Success;
        List<string> expectedCollectionItemIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        ApiEnum<string, CollectionProcessingEventType> expectedEventType =
            CollectionProcessingEventType.CollectionProcessing;
        long expectedFunctionCallTryNumber = 0;
        Errors::InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        CollectionProcessingMetadata expectedMetadata = new()
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
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingEventType.CollectionProcessing,
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
        var deserialized = JsonSerializer.Deserialize<CollectionProcessing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingEventType.CollectionProcessing,
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
        var deserialized = JsonSerializer.Deserialize<CollectionProcessing>(
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
        ApiEnum<string, Status> expectedStatus = Status.Success;
        List<string> expectedCollectionItemIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        ApiEnum<string, CollectionProcessingEventType> expectedEventType =
            CollectionProcessingEventType.CollectionProcessing;
        long expectedFunctionCallTryNumber = 0;
        Errors::InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        CollectionProcessingMetadata expectedMetadata = new()
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
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingEventType.CollectionProcessing,
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
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
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
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,

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
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,

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
        var model = new CollectionProcessing
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            EventID = "eventID",
            Operation = Operation.Add,
            ProcessedCount = 0,
            ReferenceID = "referenceID",
            Status = Status.Success,
            CollectionItemIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventType = CollectionProcessingEventType.CollectionProcessing,
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

        CollectionProcessing copied = new(model);

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

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Success)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Success)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CollectionProcessingEventTypeTest : TestBase
{
    [Theory]
    [InlineData(CollectionProcessingEventType.CollectionProcessing)]
    public void Validation_Works(CollectionProcessingEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CollectionProcessingEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CollectionProcessingEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CollectionProcessingEventType.CollectionProcessing)]
    public void SerializationRoundtrip_Works(CollectionProcessingEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CollectionProcessingEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CollectionProcessingEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CollectionProcessingEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CollectionProcessingMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CollectionProcessingMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CollectionProcessingMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionProcessingMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CollectionProcessingMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionProcessingMetadata>(
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
        var model = new CollectionProcessingMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CollectionProcessingMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CollectionProcessingMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CollectionProcessingMetadata
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
        var model = new CollectionProcessingMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CollectionProcessingMetadata { DurationFunctionToEventSeconds = 0 };

        CollectionProcessingMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
