using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Errors;

namespace Bem.Tests.Models.Errors;

public class ErrorListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ErrorListPageResponse
        {
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
            TotalCount = 0,
        };

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
        long expectedTotalCount = 0;

        Assert.Equal(expectedErrors.Count, model.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], model.Errors[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ErrorListPageResponse
        {
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
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ErrorListPageResponse
        {
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
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        long expectedTotalCount = 0;

        Assert.Equal(expectedErrors.Count, deserialized.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], deserialized.Errors[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ErrorListPageResponse
        {
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
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ErrorListPageResponse
        {
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
            TotalCount = 0,
        };

        ErrorListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
