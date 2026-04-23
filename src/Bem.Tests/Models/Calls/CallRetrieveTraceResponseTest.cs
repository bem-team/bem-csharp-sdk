using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Calls;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Calls;

public class CallRetrieveTraceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallRetrieveTraceResponse
        {
            Error = "error",
            Trace = new()
            {
                Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
                FunctionCalls =
                [
                    new()
                    {
                        FunctionCallID = "functionCallID",
                        FunctionID = "functionID",
                        FunctionName = "functionName",
                        ReferenceID = "referenceID",
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = FunctionCallStatus.Pending,
                        Type = FunctionType.Transform,
                        Activity =
                        [
                            new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                        ],
                        FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FunctionVersionNum = 0,
                        IncomingDestinationName = "incomingDestinationName",
                        Inputs =
                        [
                            new()
                            {
                                InputType = "inputType",
                                ItemReferenceID = "itemReferenceID",
                                S3Url = "s3URL",
                            },
                        ],
                        InputType = "inputType",
                        S3Url = "s3URL",
                        SourceEventID = "sourceEventID",
                        SourceFunctionCallID = "sourceFunctionCallID",
                        WorkflowCallID = "workflowCallID",
                        WorkflowNodeName = "workflowNodeName",
                    },
                ],
            },
        };

        string expectedError = "error";
        Trace expectedTrace = new()
        {
            Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
            FunctionCalls =
            [
                new()
                {
                    FunctionCallID = "functionCallID",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    ReferenceID = "referenceID",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = FunctionCallStatus.Pending,
                    Type = FunctionType.Transform,
                    Activity =
                    [
                        new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                    ],
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FunctionVersionNum = 0,
                    IncomingDestinationName = "incomingDestinationName",
                    Inputs =
                    [
                        new()
                        {
                            InputType = "inputType",
                            ItemReferenceID = "itemReferenceID",
                            S3Url = "s3URL",
                        },
                    ],
                    InputType = "inputType",
                    S3Url = "s3URL",
                    SourceEventID = "sourceEventID",
                    SourceFunctionCallID = "sourceFunctionCallID",
                    WorkflowCallID = "workflowCallID",
                    WorkflowNodeName = "workflowNodeName",
                },
            ],
        };

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedTrace, model.Trace);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallRetrieveTraceResponse
        {
            Error = "error",
            Trace = new()
            {
                Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
                FunctionCalls =
                [
                    new()
                    {
                        FunctionCallID = "functionCallID",
                        FunctionID = "functionID",
                        FunctionName = "functionName",
                        ReferenceID = "referenceID",
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = FunctionCallStatus.Pending,
                        Type = FunctionType.Transform,
                        Activity =
                        [
                            new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                        ],
                        FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FunctionVersionNum = 0,
                        IncomingDestinationName = "incomingDestinationName",
                        Inputs =
                        [
                            new()
                            {
                                InputType = "inputType",
                                ItemReferenceID = "itemReferenceID",
                                S3Url = "s3URL",
                            },
                        ],
                        InputType = "inputType",
                        S3Url = "s3URL",
                        SourceEventID = "sourceEventID",
                        SourceFunctionCallID = "sourceFunctionCallID",
                        WorkflowCallID = "workflowCallID",
                        WorkflowNodeName = "workflowNodeName",
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallRetrieveTraceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallRetrieveTraceResponse
        {
            Error = "error",
            Trace = new()
            {
                Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
                FunctionCalls =
                [
                    new()
                    {
                        FunctionCallID = "functionCallID",
                        FunctionID = "functionID",
                        FunctionName = "functionName",
                        ReferenceID = "referenceID",
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = FunctionCallStatus.Pending,
                        Type = FunctionType.Transform,
                        Activity =
                        [
                            new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                        ],
                        FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FunctionVersionNum = 0,
                        IncomingDestinationName = "incomingDestinationName",
                        Inputs =
                        [
                            new()
                            {
                                InputType = "inputType",
                                ItemReferenceID = "itemReferenceID",
                                S3Url = "s3URL",
                            },
                        ],
                        InputType = "inputType",
                        S3Url = "s3URL",
                        SourceEventID = "sourceEventID",
                        SourceFunctionCallID = "sourceFunctionCallID",
                        WorkflowCallID = "workflowCallID",
                        WorkflowNodeName = "workflowNodeName",
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallRetrieveTraceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        Trace expectedTrace = new()
        {
            Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
            FunctionCalls =
            [
                new()
                {
                    FunctionCallID = "functionCallID",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    ReferenceID = "referenceID",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = FunctionCallStatus.Pending,
                    Type = FunctionType.Transform,
                    Activity =
                    [
                        new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                    ],
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FunctionVersionNum = 0,
                    IncomingDestinationName = "incomingDestinationName",
                    Inputs =
                    [
                        new()
                        {
                            InputType = "inputType",
                            ItemReferenceID = "itemReferenceID",
                            S3Url = "s3URL",
                        },
                    ],
                    InputType = "inputType",
                    S3Url = "s3URL",
                    SourceEventID = "sourceEventID",
                    SourceFunctionCallID = "sourceFunctionCallID",
                    WorkflowCallID = "workflowCallID",
                    WorkflowNodeName = "workflowNodeName",
                },
            ],
        };

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedTrace, deserialized.Trace);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallRetrieveTraceResponse
        {
            Error = "error",
            Trace = new()
            {
                Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
                FunctionCalls =
                [
                    new()
                    {
                        FunctionCallID = "functionCallID",
                        FunctionID = "functionID",
                        FunctionName = "functionName",
                        ReferenceID = "referenceID",
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = FunctionCallStatus.Pending,
                        Type = FunctionType.Transform,
                        Activity =
                        [
                            new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                        ],
                        FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FunctionVersionNum = 0,
                        IncomingDestinationName = "incomingDestinationName",
                        Inputs =
                        [
                            new()
                            {
                                InputType = "inputType",
                                ItemReferenceID = "itemReferenceID",
                                S3Url = "s3URL",
                            },
                        ],
                        InputType = "inputType",
                        S3Url = "s3URL",
                        SourceEventID = "sourceEventID",
                        SourceFunctionCallID = "sourceFunctionCallID",
                        WorkflowCallID = "workflowCallID",
                        WorkflowNodeName = "workflowNodeName",
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallRetrieveTraceResponse { };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Trace);
        Assert.False(model.RawData.ContainsKey("trace"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallRetrieveTraceResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallRetrieveTraceResponse
        {
            // Null should be interpreted as omitted for these properties
            Error = null,
            Trace = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Trace);
        Assert.False(model.RawData.ContainsKey("trace"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallRetrieveTraceResponse
        {
            // Null should be interpreted as omitted for these properties
            Error = null,
            Trace = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallRetrieveTraceResponse
        {
            Error = "error",
            Trace = new()
            {
                Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
                FunctionCalls =
                [
                    new()
                    {
                        FunctionCallID = "functionCallID",
                        FunctionID = "functionID",
                        FunctionName = "functionName",
                        ReferenceID = "referenceID",
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = FunctionCallStatus.Pending,
                        Type = FunctionType.Transform,
                        Activity =
                        [
                            new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                        ],
                        FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FunctionVersionNum = 0,
                        IncomingDestinationName = "incomingDestinationName",
                        Inputs =
                        [
                            new()
                            {
                                InputType = "inputType",
                                ItemReferenceID = "itemReferenceID",
                                S3Url = "s3URL",
                            },
                        ],
                        InputType = "inputType",
                        S3Url = "s3URL",
                        SourceEventID = "sourceEventID",
                        SourceFunctionCallID = "sourceFunctionCallID",
                        WorkflowCallID = "workflowCallID",
                        WorkflowNodeName = "workflowNodeName",
                    },
                ],
            },
        };

        CallRetrieveTraceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TraceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Trace
        {
            Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
            FunctionCalls =
            [
                new()
                {
                    FunctionCallID = "functionCallID",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    ReferenceID = "referenceID",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = FunctionCallStatus.Pending,
                    Type = FunctionType.Transform,
                    Activity =
                    [
                        new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                    ],
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FunctionVersionNum = 0,
                    IncomingDestinationName = "incomingDestinationName",
                    Inputs =
                    [
                        new()
                        {
                            InputType = "inputType",
                            ItemReferenceID = "itemReferenceID",
                            S3Url = "s3URL",
                        },
                    ],
                    InputType = "inputType",
                    S3Url = "s3URL",
                    SourceEventID = "sourceEventID",
                    SourceFunctionCallID = "sourceFunctionCallID",
                    WorkflowCallID = "workflowCallID",
                    WorkflowNodeName = "workflowNodeName",
                },
            ],
        };

        List<JsonElement> expectedEvents = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<FunctionCall> expectedFunctionCalls =
        [
            new()
            {
                FunctionCallID = "functionCallID",
                FunctionID = "functionID",
                FunctionName = "functionName",
                ReferenceID = "referenceID",
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = FunctionCallStatus.Pending,
                Type = FunctionType.Transform,
                Activity = [new() { DisplayName = "displayName", Status = ActivityStatus.Pending }],
                FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionVersionNum = 0,
                IncomingDestinationName = "incomingDestinationName",
                Inputs =
                [
                    new()
                    {
                        InputType = "inputType",
                        ItemReferenceID = "itemReferenceID",
                        S3Url = "s3URL",
                    },
                ],
                InputType = "inputType",
                S3Url = "s3URL",
                SourceEventID = "sourceEventID",
                SourceFunctionCallID = "sourceFunctionCallID",
                WorkflowCallID = "workflowCallID",
                WorkflowNodeName = "workflowNodeName",
            },
        ];

        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedEvents[i], model.Events[i]));
        }
        Assert.Equal(expectedFunctionCalls.Count, model.FunctionCalls.Count);
        for (int i = 0; i < expectedFunctionCalls.Count; i++)
        {
            Assert.Equal(expectedFunctionCalls[i], model.FunctionCalls[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Trace
        {
            Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
            FunctionCalls =
            [
                new()
                {
                    FunctionCallID = "functionCallID",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    ReferenceID = "referenceID",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = FunctionCallStatus.Pending,
                    Type = FunctionType.Transform,
                    Activity =
                    [
                        new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                    ],
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FunctionVersionNum = 0,
                    IncomingDestinationName = "incomingDestinationName",
                    Inputs =
                    [
                        new()
                        {
                            InputType = "inputType",
                            ItemReferenceID = "itemReferenceID",
                            S3Url = "s3URL",
                        },
                    ],
                    InputType = "inputType",
                    S3Url = "s3URL",
                    SourceEventID = "sourceEventID",
                    SourceFunctionCallID = "sourceFunctionCallID",
                    WorkflowCallID = "workflowCallID",
                    WorkflowNodeName = "workflowNodeName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trace>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Trace
        {
            Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
            FunctionCalls =
            [
                new()
                {
                    FunctionCallID = "functionCallID",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    ReferenceID = "referenceID",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = FunctionCallStatus.Pending,
                    Type = FunctionType.Transform,
                    Activity =
                    [
                        new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                    ],
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FunctionVersionNum = 0,
                    IncomingDestinationName = "incomingDestinationName",
                    Inputs =
                    [
                        new()
                        {
                            InputType = "inputType",
                            ItemReferenceID = "itemReferenceID",
                            S3Url = "s3URL",
                        },
                    ],
                    InputType = "inputType",
                    S3Url = "s3URL",
                    SourceEventID = "sourceEventID",
                    SourceFunctionCallID = "sourceFunctionCallID",
                    WorkflowCallID = "workflowCallID",
                    WorkflowNodeName = "workflowNodeName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trace>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<JsonElement> expectedEvents = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<FunctionCall> expectedFunctionCalls =
        [
            new()
            {
                FunctionCallID = "functionCallID",
                FunctionID = "functionID",
                FunctionName = "functionName",
                ReferenceID = "referenceID",
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = FunctionCallStatus.Pending,
                Type = FunctionType.Transform,
                Activity = [new() { DisplayName = "displayName", Status = ActivityStatus.Pending }],
                FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionVersionNum = 0,
                IncomingDestinationName = "incomingDestinationName",
                Inputs =
                [
                    new()
                    {
                        InputType = "inputType",
                        ItemReferenceID = "itemReferenceID",
                        S3Url = "s3URL",
                    },
                ],
                InputType = "inputType",
                S3Url = "s3URL",
                SourceEventID = "sourceEventID",
                SourceFunctionCallID = "sourceFunctionCallID",
                WorkflowCallID = "workflowCallID",
                WorkflowNodeName = "workflowNodeName",
            },
        ];

        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedEvents[i], deserialized.Events[i]));
        }
        Assert.Equal(expectedFunctionCalls.Count, deserialized.FunctionCalls.Count);
        for (int i = 0; i < expectedFunctionCalls.Count; i++)
        {
            Assert.Equal(expectedFunctionCalls[i], deserialized.FunctionCalls[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Trace
        {
            Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
            FunctionCalls =
            [
                new()
                {
                    FunctionCallID = "functionCallID",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    ReferenceID = "referenceID",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = FunctionCallStatus.Pending,
                    Type = FunctionType.Transform,
                    Activity =
                    [
                        new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                    ],
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FunctionVersionNum = 0,
                    IncomingDestinationName = "incomingDestinationName",
                    Inputs =
                    [
                        new()
                        {
                            InputType = "inputType",
                            ItemReferenceID = "itemReferenceID",
                            S3Url = "s3URL",
                        },
                    ],
                    InputType = "inputType",
                    S3Url = "s3URL",
                    SourceEventID = "sourceEventID",
                    SourceFunctionCallID = "sourceFunctionCallID",
                    WorkflowCallID = "workflowCallID",
                    WorkflowNodeName = "workflowNodeName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Trace
        {
            Events = [JsonSerializer.Deserialize<JsonElement>("{}")],
            FunctionCalls =
            [
                new()
                {
                    FunctionCallID = "functionCallID",
                    FunctionID = "functionID",
                    FunctionName = "functionName",
                    ReferenceID = "referenceID",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = FunctionCallStatus.Pending,
                    Type = FunctionType.Transform,
                    Activity =
                    [
                        new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
                    ],
                    FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FunctionVersionNum = 0,
                    IncomingDestinationName = "incomingDestinationName",
                    Inputs =
                    [
                        new()
                        {
                            InputType = "inputType",
                            ItemReferenceID = "itemReferenceID",
                            S3Url = "s3URL",
                        },
                    ],
                    InputType = "inputType",
                    S3Url = "s3URL",
                    SourceEventID = "sourceEventID",
                    SourceFunctionCallID = "sourceFunctionCallID",
                    WorkflowCallID = "workflowCallID",
                    WorkflowNodeName = "workflowNodeName",
                },
            ],
        };

        Trace copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,
            Activity = [new() { DisplayName = "displayName", Status = ActivityStatus.Pending }],
            FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionVersionNum = 0,
            IncomingDestinationName = "incomingDestinationName",
            Inputs =
            [
                new()
                {
                    InputType = "inputType",
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            InputType = "inputType",
            S3Url = "s3URL",
            SourceEventID = "sourceEventID",
            SourceFunctionCallID = "sourceFunctionCallID",
            WorkflowCallID = "workflowCallID",
            WorkflowNodeName = "workflowNodeName",
        };

        string expectedFunctionCallID = "functionCallID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, FunctionCallStatus> expectedStatus = FunctionCallStatus.Pending;
        ApiEnum<string, FunctionType> expectedType = FunctionType.Transform;
        List<Activity> expectedActivity =
        [
            new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
        ];
        DateTimeOffset expectedFinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedFunctionVersionNum = 0;
        string expectedIncomingDestinationName = "incomingDestinationName";
        List<FunctionCallInput> expectedInputs =
        [
            new()
            {
                InputType = "inputType",
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];
        string expectedInputType = "inputType";
        string expectedS3Url = "s3URL";
        string expectedSourceEventID = "sourceEventID";
        string expectedSourceFunctionCallID = "sourceFunctionCallID";
        string expectedWorkflowCallID = "workflowCallID";
        string expectedWorkflowNodeName = "workflowNodeName";

        Assert.Equal(expectedFunctionCallID, model.FunctionCallID);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Activity);
        Assert.Equal(expectedActivity.Count, model.Activity.Count);
        for (int i = 0; i < expectedActivity.Count; i++)
        {
            Assert.Equal(expectedActivity[i], model.Activity[i]);
        }
        Assert.Equal(expectedFinishedAt, model.FinishedAt);
        Assert.Equal(expectedFunctionVersionNum, model.FunctionVersionNum);
        Assert.Equal(expectedIncomingDestinationName, model.IncomingDestinationName);
        Assert.NotNull(model.Inputs);
        Assert.Equal(expectedInputs.Count, model.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], model.Inputs[i]);
        }
        Assert.Equal(expectedInputType, model.InputType);
        Assert.Equal(expectedS3Url, model.S3Url);
        Assert.Equal(expectedSourceEventID, model.SourceEventID);
        Assert.Equal(expectedSourceFunctionCallID, model.SourceFunctionCallID);
        Assert.Equal(expectedWorkflowCallID, model.WorkflowCallID);
        Assert.Equal(expectedWorkflowNodeName, model.WorkflowNodeName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,
            Activity = [new() { DisplayName = "displayName", Status = ActivityStatus.Pending }],
            FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionVersionNum = 0,
            IncomingDestinationName = "incomingDestinationName",
            Inputs =
            [
                new()
                {
                    InputType = "inputType",
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            InputType = "inputType",
            S3Url = "s3URL",
            SourceEventID = "sourceEventID",
            SourceFunctionCallID = "sourceFunctionCallID",
            WorkflowCallID = "workflowCallID",
            WorkflowNodeName = "workflowNodeName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,
            Activity = [new() { DisplayName = "displayName", Status = ActivityStatus.Pending }],
            FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionVersionNum = 0,
            IncomingDestinationName = "incomingDestinationName",
            Inputs =
            [
                new()
                {
                    InputType = "inputType",
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            InputType = "inputType",
            S3Url = "s3URL",
            SourceEventID = "sourceEventID",
            SourceFunctionCallID = "sourceFunctionCallID",
            WorkflowCallID = "workflowCallID",
            WorkflowNodeName = "workflowNodeName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionCallID = "functionCallID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedReferenceID = "referenceID";
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, FunctionCallStatus> expectedStatus = FunctionCallStatus.Pending;
        ApiEnum<string, FunctionType> expectedType = FunctionType.Transform;
        List<Activity> expectedActivity =
        [
            new() { DisplayName = "displayName", Status = ActivityStatus.Pending },
        ];
        DateTimeOffset expectedFinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedFunctionVersionNum = 0;
        string expectedIncomingDestinationName = "incomingDestinationName";
        List<FunctionCallInput> expectedInputs =
        [
            new()
            {
                InputType = "inputType",
                ItemReferenceID = "itemReferenceID",
                S3Url = "s3URL",
            },
        ];
        string expectedInputType = "inputType";
        string expectedS3Url = "s3URL";
        string expectedSourceEventID = "sourceEventID";
        string expectedSourceFunctionCallID = "sourceFunctionCallID";
        string expectedWorkflowCallID = "workflowCallID";
        string expectedWorkflowNodeName = "workflowNodeName";

        Assert.Equal(expectedFunctionCallID, deserialized.FunctionCallID);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Activity);
        Assert.Equal(expectedActivity.Count, deserialized.Activity.Count);
        for (int i = 0; i < expectedActivity.Count; i++)
        {
            Assert.Equal(expectedActivity[i], deserialized.Activity[i]);
        }
        Assert.Equal(expectedFinishedAt, deserialized.FinishedAt);
        Assert.Equal(expectedFunctionVersionNum, deserialized.FunctionVersionNum);
        Assert.Equal(expectedIncomingDestinationName, deserialized.IncomingDestinationName);
        Assert.NotNull(deserialized.Inputs);
        Assert.Equal(expectedInputs.Count, deserialized.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], deserialized.Inputs[i]);
        }
        Assert.Equal(expectedInputType, deserialized.InputType);
        Assert.Equal(expectedS3Url, deserialized.S3Url);
        Assert.Equal(expectedSourceEventID, deserialized.SourceEventID);
        Assert.Equal(expectedSourceFunctionCallID, deserialized.SourceFunctionCallID);
        Assert.Equal(expectedWorkflowCallID, deserialized.WorkflowCallID);
        Assert.Equal(expectedWorkflowNodeName, deserialized.WorkflowNodeName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,
            Activity = [new() { DisplayName = "displayName", Status = ActivityStatus.Pending }],
            FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionVersionNum = 0,
            IncomingDestinationName = "incomingDestinationName",
            Inputs =
            [
                new()
                {
                    InputType = "inputType",
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            InputType = "inputType",
            S3Url = "s3URL",
            SourceEventID = "sourceEventID",
            SourceFunctionCallID = "sourceFunctionCallID",
            WorkflowCallID = "workflowCallID",
            WorkflowNodeName = "workflowNodeName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,
        };

        Assert.Null(model.Activity);
        Assert.False(model.RawData.ContainsKey("activity"));
        Assert.Null(model.FinishedAt);
        Assert.False(model.RawData.ContainsKey("finishedAt"));
        Assert.Null(model.FunctionVersionNum);
        Assert.False(model.RawData.ContainsKey("functionVersionNum"));
        Assert.Null(model.IncomingDestinationName);
        Assert.False(model.RawData.ContainsKey("incomingDestinationName"));
        Assert.Null(model.Inputs);
        Assert.False(model.RawData.ContainsKey("inputs"));
        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
        Assert.Null(model.SourceEventID);
        Assert.False(model.RawData.ContainsKey("sourceEventID"));
        Assert.Null(model.SourceFunctionCallID);
        Assert.False(model.RawData.ContainsKey("sourceFunctionCallID"));
        Assert.Null(model.WorkflowCallID);
        Assert.False(model.RawData.ContainsKey("workflowCallID"));
        Assert.Null(model.WorkflowNodeName);
        Assert.False(model.RawData.ContainsKey("workflowNodeName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,

            // Null should be interpreted as omitted for these properties
            Activity = null,
            FinishedAt = null,
            FunctionVersionNum = null,
            IncomingDestinationName = null,
            Inputs = null,
            InputType = null,
            S3Url = null,
            SourceEventID = null,
            SourceFunctionCallID = null,
            WorkflowCallID = null,
            WorkflowNodeName = null,
        };

        Assert.Null(model.Activity);
        Assert.False(model.RawData.ContainsKey("activity"));
        Assert.Null(model.FinishedAt);
        Assert.False(model.RawData.ContainsKey("finishedAt"));
        Assert.Null(model.FunctionVersionNum);
        Assert.False(model.RawData.ContainsKey("functionVersionNum"));
        Assert.Null(model.IncomingDestinationName);
        Assert.False(model.RawData.ContainsKey("incomingDestinationName"));
        Assert.Null(model.Inputs);
        Assert.False(model.RawData.ContainsKey("inputs"));
        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("inputType"));
        Assert.Null(model.S3Url);
        Assert.False(model.RawData.ContainsKey("s3URL"));
        Assert.Null(model.SourceEventID);
        Assert.False(model.RawData.ContainsKey("sourceEventID"));
        Assert.Null(model.SourceFunctionCallID);
        Assert.False(model.RawData.ContainsKey("sourceFunctionCallID"));
        Assert.Null(model.WorkflowCallID);
        Assert.False(model.RawData.ContainsKey("workflowCallID"));
        Assert.Null(model.WorkflowNodeName);
        Assert.False(model.RawData.ContainsKey("workflowNodeName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,

            // Null should be interpreted as omitted for these properties
            Activity = null,
            FinishedAt = null,
            FunctionVersionNum = null,
            IncomingDestinationName = null,
            Inputs = null,
            InputType = null,
            S3Url = null,
            SourceEventID = null,
            SourceFunctionCallID = null,
            WorkflowCallID = null,
            WorkflowNodeName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionCall
        {
            FunctionCallID = "functionCallID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            ReferenceID = "referenceID",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = FunctionCallStatus.Pending,
            Type = FunctionType.Transform,
            Activity = [new() { DisplayName = "displayName", Status = ActivityStatus.Pending }],
            FinishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionVersionNum = 0,
            IncomingDestinationName = "incomingDestinationName",
            Inputs =
            [
                new()
                {
                    InputType = "inputType",
                    ItemReferenceID = "itemReferenceID",
                    S3Url = "s3URL",
                },
            ],
            InputType = "inputType",
            S3Url = "s3URL",
            SourceEventID = "sourceEventID",
            SourceFunctionCallID = "sourceFunctionCallID",
            WorkflowCallID = "workflowCallID",
            WorkflowNodeName = "workflowNodeName",
        };

        FunctionCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionCallStatusTest : TestBase
{
    [Theory]
    [InlineData(FunctionCallStatus.Pending)]
    [InlineData(FunctionCallStatus.Running)]
    [InlineData(FunctionCallStatus.Completed)]
    [InlineData(FunctionCallStatus.Failed)]
    public void Validation_Works(FunctionCallStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionCallStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionCallStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionCallStatus.Pending)]
    [InlineData(FunctionCallStatus.Running)]
    [InlineData(FunctionCallStatus.Completed)]
    [InlineData(FunctionCallStatus.Failed)]
    public void SerializationRoundtrip_Works(FunctionCallStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionCallStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionCallStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionCallStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FunctionCallStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Activity { DisplayName = "displayName", Status = ActivityStatus.Pending };

        string expectedDisplayName = "displayName";
        ApiEnum<string, ActivityStatus> expectedStatus = ActivityStatus.Pending;

        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Activity { DisplayName = "displayName", Status = ActivityStatus.Pending };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Activity>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Activity { DisplayName = "displayName", Status = ActivityStatus.Pending };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Activity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDisplayName = "displayName";
        ApiEnum<string, ActivityStatus> expectedStatus = ActivityStatus.Pending;

        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Activity { DisplayName = "displayName", Status = ActivityStatus.Pending };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Activity { };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Activity { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Activity
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            Status = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Activity
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Activity { DisplayName = "displayName", Status = ActivityStatus.Pending };

        Activity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActivityStatusTest : TestBase
{
    [Theory]
    [InlineData(ActivityStatus.Pending)]
    [InlineData(ActivityStatus.Running)]
    [InlineData(ActivityStatus.Completed)]
    [InlineData(ActivityStatus.Failed)]
    public void Validation_Works(ActivityStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ActivityStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ActivityStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ActivityStatus.Pending)]
    [InlineData(ActivityStatus.Running)]
    [InlineData(ActivityStatus.Completed)]
    [InlineData(ActivityStatus.Failed)]
    public void SerializationRoundtrip_Works(ActivityStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ActivityStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ActivityStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ActivityStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ActivityStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FunctionCallInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionCallInput
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
        var model = new FunctionCallInput
        {
            InputType = "inputType",
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCallInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionCallInput
        {
            InputType = "inputType",
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCallInput>(
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
        var model = new FunctionCallInput
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
        var model = new FunctionCallInput { };

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
        var model = new FunctionCallInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionCallInput
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
        var model = new FunctionCallInput
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
        var model = new FunctionCallInput
        {
            InputType = "inputType",
            ItemReferenceID = "itemReferenceID",
            S3Url = "s3URL",
        };

        FunctionCallInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
