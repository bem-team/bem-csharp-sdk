using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Calls;
using Bem.Models.Errors;
using Outputs = Bem.Models.Outputs;

namespace Bem.Tests.Models.Calls;

public class CallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Call
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
        };

        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ErrorEvent> expectedErrors =
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
        ];
        List<Outputs::Event> expectedOutputs =
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
        ];
        string expectedTraceUrl = "traceUrl";
        string expectedUrl = "url";
        string expectedCallReferenceID = "callReferenceID";
        DateTimeOffset expectedFinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Input expectedInput = new()
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
        };
        ApiEnum<string, CallStatus> expectedStatus = CallStatus.Pending;
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrors.Count, model.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], model.Errors[i]);
        }
        Assert.Equal(expectedOutputs.Count, model.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], model.Outputs[i]);
        }
        Assert.Equal(expectedTraceUrl, model.TraceUrl);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedCallReferenceID, model.CallReferenceID);
        Assert.Equal(expectedFinishedAt, model.FinishedAt);
        Assert.Equal(expectedInput, model.Input);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, model.WorkflowVersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Call
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Call>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Call
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Call>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ErrorEvent> expectedErrors =
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
        ];
        List<Outputs::Event> expectedOutputs =
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
        ];
        string expectedTraceUrl = "traceUrl";
        string expectedUrl = "url";
        string expectedCallReferenceID = "callReferenceID";
        DateTimeOffset expectedFinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Input expectedInput = new()
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
        };
        ApiEnum<string, CallStatus> expectedStatus = CallStatus.Pending;
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";
        long expectedWorkflowVersionNum = 0;

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrors.Count, deserialized.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], deserialized.Errors[i]);
        }
        Assert.Equal(expectedOutputs.Count, deserialized.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], deserialized.Outputs[i]);
        }
        Assert.Equal(expectedTraceUrl, deserialized.TraceUrl);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedCallReferenceID, deserialized.CallReferenceID);
        Assert.Equal(expectedFinishedAt, deserialized.FinishedAt);
        Assert.Equal(expectedInput, deserialized.Input);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
        Assert.Equal(expectedWorkflowVersionNum, deserialized.WorkflowVersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Call
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Call
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
        };

        Assert.Null(model.CallReferenceID);
        Assert.False(model.RawData.ContainsKey("callReferenceID"));
        Assert.Null(model.FinishedAt);
        Assert.False(model.RawData.ContainsKey("finishedAt"));
        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
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
        var model = new Call
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Call
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

            // Null should be interpreted as omitted for these properties
            CallReferenceID = null,
            FinishedAt = null,
            Input = null,
            Status = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        Assert.Null(model.CallReferenceID);
        Assert.False(model.RawData.ContainsKey("callReferenceID"));
        Assert.Null(model.FinishedAt);
        Assert.False(model.RawData.ContainsKey("finishedAt"));
        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
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
        var model = new Call
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

            // Null should be interpreted as omitted for these properties
            CallReferenceID = null,
            FinishedAt = null,
            Input = null,
            Status = null,
            WorkflowID = null,
            WorkflowName = null,
            WorkflowVersionNum = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Call
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
        };

        Call copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Input
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
        };

        BatchFiles expectedBatchFiles = new()
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
        };
        SingleFile expectedSingleFile = new() { InputType = "inputType", S3Url = "s3URL" };

        Assert.Equal(expectedBatchFiles, model.BatchFiles);
        Assert.Equal(expectedSingleFile, model.SingleFile);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Input
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        BatchFiles expectedBatchFiles = new()
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
        };
        SingleFile expectedSingleFile = new() { InputType = "inputType", S3Url = "s3URL" };

        Assert.Equal(expectedBatchFiles, deserialized.BatchFiles);
        Assert.Equal(expectedSingleFile, deserialized.SingleFile);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Input
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Input { };

        Assert.Null(model.BatchFiles);
        Assert.False(model.RawData.ContainsKey("batchFiles"));
        Assert.Null(model.SingleFile);
        Assert.False(model.RawData.ContainsKey("singleFile"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Input { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Input
        {
            // Null should be interpreted as omitted for these properties
            BatchFiles = null,
            SingleFile = null,
        };

        Assert.Null(model.BatchFiles);
        Assert.False(model.RawData.ContainsKey("batchFiles"));
        Assert.Null(model.SingleFile);
        Assert.False(model.RawData.ContainsKey("singleFile"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Input
        {
            // Null should be interpreted as omitted for these properties
            BatchFiles = null,
            SingleFile = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Input
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
        };

        Input copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchFilesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchFiles
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
        };

        List<BatchFilesInput> expectedInputs =
        [
            new()
            {
                InputType = "inputType",
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];

        Assert.NotNull(model.Inputs);
        Assert.Equal(expectedInputs.Count, model.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], model.Inputs[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchFiles
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchFiles>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchFiles
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchFiles>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BatchFilesInput> expectedInputs =
        [
            new()
            {
                InputType = "inputType",
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];

        Assert.NotNull(deserialized.Inputs);
        Assert.Equal(expectedInputs.Count, deserialized.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], deserialized.Inputs[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchFiles
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchFiles { };

        Assert.Null(model.Inputs);
        Assert.False(model.RawData.ContainsKey("inputs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BatchFiles { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BatchFiles
        {
            // Null should be interpreted as omitted for these properties
            Inputs = null,
        };

        Assert.Null(model.Inputs);
        Assert.False(model.RawData.ContainsKey("inputs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BatchFiles
        {
            // Null should be interpreted as omitted for these properties
            Inputs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchFiles
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
        };

        BatchFiles copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchFilesInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchFilesInput
        {
            InputType = "inputType",
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string expectedInputType = "inputType";
        string expectedItemReferenceID = "itemReferenceID";
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedInputType, model.InputType);
        Assert.Equal(expectedItemReferenceID, model.ItemReferenceID);
        Assert.Equal(expectedS3Url, model.S3Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchFilesInput
        {
            InputType = "inputType",
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchFilesInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchFilesInput
        {
            InputType = "inputType",
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchFilesInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInputType = "inputType";
        string expectedItemReferenceID = "itemReferenceID";
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedInputType, deserialized.InputType);
        Assert.Equal(expectedItemReferenceID, deserialized.ItemReferenceID);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchFilesInput
        {
            InputType = "inputType",
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchFilesInput { };

        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.ItemReferenceID);
        Assert.False(model.RawData.ContainsKey("itemReferenceID"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BatchFilesInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BatchFilesInput
        {
            // Null should be interpreted as omitted for these properties
            InputType = null,
            ItemReferenceID = null,
            S3Url = null,
        };

        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.ItemReferenceID);
        Assert.False(model.RawData.ContainsKey("itemReferenceID"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BatchFilesInput
        {
            // Null should be interpreted as omitted for these properties
            InputType = null,
            ItemReferenceID = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchFilesInput
        {
            InputType = "inputType",
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        BatchFilesInput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SingleFileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SingleFile { InputType = "inputType", S3Url = "s3URL" };

        string expectedInputType = "inputType";
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedInputType, model.InputType);
        Assert.Equal(expectedS3Url, model.S3Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SingleFile { InputType = "inputType", S3Url = "s3URL" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SingleFile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SingleFile { InputType = "inputType", S3Url = "s3URL" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SingleFile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInputType = "inputType";
        string expectedS3Url = "s3URL";

        Assert.Equal(expectedInputType, deserialized.InputType);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SingleFile { InputType = "inputType", S3Url = "s3URL" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SingleFile { };

        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SingleFile { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SingleFile
        {
            // Null should be interpreted as omitted for these properties
            InputType = null,
            S3Url = null,
        };

        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SingleFile
        {
            // Null should be interpreted as omitted for these properties
            InputType = null,
            S3Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SingleFile { InputType = "inputType", S3Url = "s3URL" };

        SingleFile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallStatusTest : TestBase
{
    [Theory]
    [InlineData(CallStatus.Pending)]
    [InlineData(CallStatus.Running)]
    [InlineData(CallStatus.Completed)]
    [InlineData(CallStatus.Failed)]
    public void Validation_Works(CallStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallStatus.Pending)]
    [InlineData(CallStatus.Running)]
    [InlineData(CallStatus.Completed)]
    [InlineData(CallStatus.Failed)]
    public void SerializationRoundtrip_Works(CallStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
