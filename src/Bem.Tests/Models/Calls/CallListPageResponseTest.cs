using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Calls;
using Bem.Models.Errors;
using Outputs = Bem.Models.Outputs;

namespace Bem.Tests.Models.Calls;

public class CallListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallListPageResponse
        {
            Calls =
            [
                new()
                {
                    CallID = "callID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Errors =
                    [
                        new()
                        {
                            EventID = "eventID",
                            FunctionID = "functionID",
                            FunctionName = "functionName",
                            Message = "message",
                            ReferenceID = "referenceID",
                            CallID = "callID",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = EventType.Error,
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
                        },
                    ],
                    Outputs =
                    [
                        new Outputs::Transform()
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
                            CorrectedContent = new Outputs::Output()
                            {
                                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = Outputs::EventType.Transform,
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
                                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>(
                                        "{}"
                                    ),
                                    S3Url = "s3URL",
                                },
                            ],
                            InputType = Outputs::InputType.Csv,
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
                                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
                                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
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
                        },
                    ],
                    TraceUrl = "traceUrl",
                    Url = "url",
                    CallReferenceID = "callReferenceID",
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Input = new()
                    {
                        BatchFiles = new()
                        {
                            Inputs =
                            [
                                new()
                                {
                                    InputType = "inputType",
                                    ItemReferenceID = "itemReferenceID",
                                    S3Url = "s3URL",
                                },
                            ],
                        },
                        SingleFile = new() { InputType = "inputType", S3Url = "s3URL" },
                    },
                    Status = CallStatus.Pending,
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                    WorkflowVersionNum = 0,
                },
            ],
            Error = "error",
            TotalCount = 0,
        };

        List<Call> expectedCalls =
        [
            new()
            {
                CallID = "callID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Errors =
                [
                    new()
                    {
                        EventID = "eventID",
                        FunctionID = "functionID",
                        FunctionName = "functionName",
                        Message = "message",
                        ReferenceID = "referenceID",
                        CallID = "callID",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        EventType = EventType.Error,
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
                    },
                ],
                Outputs =
                [
                    new Outputs::Transform()
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
                        CorrectedContent = new Outputs::Output()
                        {
                            OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        EventType = Outputs::EventType.Transform,
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
                    },
                ],
                TraceUrl = "traceUrl",
                Url = "url",
                CallReferenceID = "callReferenceID",
                FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Input = new()
                {
                    BatchFiles = new()
                    {
                        Inputs =
                        [
                            new()
                            {
                                InputType = "inputType",
                                ItemReferenceID = "itemReferenceID",
                                S3Url = "s3URL",
                            },
                        ],
                    },
                    SingleFile = new() { InputType = "inputType", S3Url = "s3URL" },
                },
                Status = CallStatus.Pending,
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
                WorkflowVersionNum = 0,
            },
        ];
        string expectedError = "error";
        long expectedTotalCount = 0;

        Assert.NotNull(model.Calls);
        Assert.Equal(expectedCalls.Count, model.Calls.Count);
        for (int i = 0; i < expectedCalls.Count; i++)
        {
            Assert.Equal(expectedCalls[i], model.Calls[i]);
        }
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallListPageResponse
        {
            Calls =
            [
                new()
                {
                    CallID = "callID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Errors =
                    [
                        new()
                        {
                            EventID = "eventID",
                            FunctionID = "functionID",
                            FunctionName = "functionName",
                            Message = "message",
                            ReferenceID = "referenceID",
                            CallID = "callID",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = EventType.Error,
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
                        },
                    ],
                    Outputs =
                    [
                        new Outputs::Transform()
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
                            CorrectedContent = new Outputs::Output()
                            {
                                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = Outputs::EventType.Transform,
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
                                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>(
                                        "{}"
                                    ),
                                    S3Url = "s3URL",
                                },
                            ],
                            InputType = Outputs::InputType.Csv,
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
                                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
                                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
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
                        },
                    ],
                    TraceUrl = "traceUrl",
                    Url = "url",
                    CallReferenceID = "callReferenceID",
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Input = new()
                    {
                        BatchFiles = new()
                        {
                            Inputs =
                            [
                                new()
                                {
                                    InputType = "inputType",
                                    ItemReferenceID = "itemReferenceID",
                                    S3Url = "s3URL",
                                },
                            ],
                        },
                        SingleFile = new() { InputType = "inputType", S3Url = "s3URL" },
                    },
                    Status = CallStatus.Pending,
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                    WorkflowVersionNum = 0,
                },
            ],
            Error = "error",
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallListPageResponse
        {
            Calls =
            [
                new()
                {
                    CallID = "callID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Errors =
                    [
                        new()
                        {
                            EventID = "eventID",
                            FunctionID = "functionID",
                            FunctionName = "functionName",
                            Message = "message",
                            ReferenceID = "referenceID",
                            CallID = "callID",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = EventType.Error,
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
                        },
                    ],
                    Outputs =
                    [
                        new Outputs::Transform()
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
                            CorrectedContent = new Outputs::Output()
                            {
                                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = Outputs::EventType.Transform,
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
                                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>(
                                        "{}"
                                    ),
                                    S3Url = "s3URL",
                                },
                            ],
                            InputType = Outputs::InputType.Csv,
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
                                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
                                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
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
                        },
                    ],
                    TraceUrl = "traceUrl",
                    Url = "url",
                    CallReferenceID = "callReferenceID",
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Input = new()
                    {
                        BatchFiles = new()
                        {
                            Inputs =
                            [
                                new()
                                {
                                    InputType = "inputType",
                                    ItemReferenceID = "itemReferenceID",
                                    S3Url = "s3URL",
                                },
                            ],
                        },
                        SingleFile = new() { InputType = "inputType", S3Url = "s3URL" },
                    },
                    Status = CallStatus.Pending,
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                    WorkflowVersionNum = 0,
                },
            ],
            Error = "error",
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Call> expectedCalls =
        [
            new()
            {
                CallID = "callID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Errors =
                [
                    new()
                    {
                        EventID = "eventID",
                        FunctionID = "functionID",
                        FunctionName = "functionName",
                        Message = "message",
                        ReferenceID = "referenceID",
                        CallID = "callID",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        EventType = EventType.Error,
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
                    },
                ],
                Outputs =
                [
                    new Outputs::Transform()
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
                        CorrectedContent = new Outputs::Output()
                        {
                            OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        EventType = Outputs::EventType.Transform,
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
                    },
                ],
                TraceUrl = "traceUrl",
                Url = "url",
                CallReferenceID = "callReferenceID",
                FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Input = new()
                {
                    BatchFiles = new()
                    {
                        Inputs =
                        [
                            new()
                            {
                                InputType = "inputType",
                                ItemReferenceID = "itemReferenceID",
                                S3Url = "s3URL",
                            },
                        ],
                    },
                    SingleFile = new() { InputType = "inputType", S3Url = "s3URL" },
                },
                Status = CallStatus.Pending,
                WorkflowID = "workflowID",
                WorkflowName = "workflowName",
                WorkflowVersionNum = 0,
            },
        ];
        string expectedError = "error";
        long expectedTotalCount = 0;

        Assert.NotNull(deserialized.Calls);
        Assert.Equal(expectedCalls.Count, deserialized.Calls.Count);
        for (int i = 0; i < expectedCalls.Count; i++)
        {
            Assert.Equal(expectedCalls[i], deserialized.Calls[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallListPageResponse
        {
            Calls =
            [
                new()
                {
                    CallID = "callID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Errors =
                    [
                        new()
                        {
                            EventID = "eventID",
                            FunctionID = "functionID",
                            FunctionName = "functionName",
                            Message = "message",
                            ReferenceID = "referenceID",
                            CallID = "callID",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = EventType.Error,
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
                        },
                    ],
                    Outputs =
                    [
                        new Outputs::Transform()
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
                            CorrectedContent = new Outputs::Output()
                            {
                                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = Outputs::EventType.Transform,
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
                                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>(
                                        "{}"
                                    ),
                                    S3Url = "s3URL",
                                },
                            ],
                            InputType = Outputs::InputType.Csv,
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
                                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
                                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
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
                        },
                    ],
                    TraceUrl = "traceUrl",
                    Url = "url",
                    CallReferenceID = "callReferenceID",
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Input = new()
                    {
                        BatchFiles = new()
                        {
                            Inputs =
                            [
                                new()
                                {
                                    InputType = "inputType",
                                    ItemReferenceID = "itemReferenceID",
                                    S3Url = "s3URL",
                                },
                            ],
                        },
                        SingleFile = new() { InputType = "inputType", S3Url = "s3URL" },
                    },
                    Status = CallStatus.Pending,
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                    WorkflowVersionNum = 0,
                },
            ],
            Error = "error",
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallListPageResponse { };

        Assert.Null(model.Calls);
        Assert.False(model.RawData.ContainsKey("calls"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallListPageResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallListPageResponse
        {
            // Null should be interpreted as omitted for these properties
            Calls = null,
            Error = null,
            TotalCount = null,
        };

        Assert.Null(model.Calls);
        Assert.False(model.RawData.ContainsKey("calls"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallListPageResponse
        {
            // Null should be interpreted as omitted for these properties
            Calls = null,
            Error = null,
            TotalCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallListPageResponse
        {
            Calls =
            [
                new()
                {
                    CallID = "callID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Errors =
                    [
                        new()
                        {
                            EventID = "eventID",
                            FunctionID = "functionID",
                            FunctionName = "functionName",
                            Message = "message",
                            ReferenceID = "referenceID",
                            CallID = "callID",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = EventType.Error,
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
                        },
                    ],
                    Outputs =
                    [
                        new Outputs::Transform()
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
                            CorrectedContent = new Outputs::Output()
                            {
                                OutputValue = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            EventType = Outputs::EventType.Transform,
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
                                    JsonInputContent = JsonSerializer.Deserialize<JsonElement>(
                                        "{}"
                                    ),
                                    S3Url = "s3URL",
                                },
                            ],
                            InputType = Outputs::InputType.Csv,
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
                                        CorrectedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
                                        ExtractedVal = JsonSerializer.Deserialize<JsonElement>(
                                            "{}"
                                        ),
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
                        },
                    ],
                    TraceUrl = "traceUrl",
                    Url = "url",
                    CallReferenceID = "callReferenceID",
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Input = new()
                    {
                        BatchFiles = new()
                        {
                            Inputs =
                            [
                                new()
                                {
                                    InputType = "inputType",
                                    ItemReferenceID = "itemReferenceID",
                                    S3Url = "s3URL",
                                },
                            ],
                        },
                        SingleFile = new() { InputType = "inputType", S3Url = "s3URL" },
                    },
                    Status = CallStatus.Pending,
                    WorkflowID = "workflowID",
                    WorkflowName = "workflowName",
                    WorkflowVersionNum = 0,
                },
            ],
            Error = "error",
            TotalCount = 0,
        };

        CallListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
