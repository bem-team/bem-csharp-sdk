using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Calls;
using Errors = Bem.Models.Errors;

namespace Bem.Tests.Models.Calls;

public class CallGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallGetResponse
        {
            Call = new()
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
                    },
                ],
                Outputs =
                [
                    new Transform()
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
                        CorrectedContent = new CorrectedContentOutput()
                        {
                            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            Error = "error",
        };

        Call expectedCall = new()
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
                },
            ],
            Outputs =
            [
                new Transform()
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
                    CorrectedContent = new CorrectedContentOutput()
                    {
                        Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
        };
        string expectedError = "error";

        Assert.Equal(expectedCall, model.Call);
        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallGetResponse
        {
            Call = new()
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
                    },
                ],
                Outputs =
                [
                    new Transform()
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
                        CorrectedContent = new CorrectedContentOutput()
                        {
                            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            Error = "error",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallGetResponse
        {
            Call = new()
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
                    },
                ],
                Outputs =
                [
                    new Transform()
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
                        CorrectedContent = new CorrectedContentOutput()
                        {
                            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            Error = "error",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Call expectedCall = new()
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
                },
            ],
            Outputs =
            [
                new Transform()
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
                    CorrectedContent = new CorrectedContentOutput()
                    {
                        Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
        };
        string expectedError = "error";

        Assert.Equal(expectedCall, deserialized.Call);
        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallGetResponse
        {
            Call = new()
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
                    },
                ],
                Outputs =
                [
                    new Transform()
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
                        CorrectedContent = new CorrectedContentOutput()
                        {
                            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            Error = "error",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallGetResponse { };

        Assert.Null(model.Call);
        Assert.False(model.RawData.ContainsKey("call"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallGetResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallGetResponse
        {
            // Null should be interpreted as omitted for these properties
            Call = null,
            Error = null,
        };

        Assert.Null(model.Call);
        Assert.False(model.RawData.ContainsKey("call"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallGetResponse
        {
            // Null should be interpreted as omitted for these properties
            Call = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallGetResponse
        {
            Call = new()
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
                    },
                ],
                Outputs =
                [
                    new Transform()
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
                        CorrectedContent = new CorrectedContentOutput()
                        {
                            Output = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            Error = "error",
        };

        CallGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
