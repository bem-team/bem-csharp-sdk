using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Outputs;

namespace Bem.Tests.Models.Outputs;

public class OutputListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputListPageResponse
        {
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
                },
            ],
            TotalCount = 0,
        };

        List<Event> expectedOutputs =
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
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedOutputs.Count, model.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], model.Outputs[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputListPageResponse
        {
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
                },
            ],
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputListPageResponse
        {
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
                },
            ],
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Event> expectedOutputs =
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
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedOutputs.Count, deserialized.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], deserialized.Outputs[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputListPageResponse
        {
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
                },
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputListPageResponse
        {
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
                },
            ],
            TotalCount = 0,
        };

        OutputListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
