using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Errors;

namespace Bem.Tests.Models.Errors;

public class ErrorRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ErrorRetrieveResponse
        {
            Error = new()
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
        };

        ErrorEvent expectedError = new()
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
        };

        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ErrorRetrieveResponse
        {
            Error = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ErrorRetrieveResponse
        {
            Error = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ErrorEvent expectedError = new()
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
        };

        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ErrorRetrieveResponse
        {
            Error = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ErrorRetrieveResponse
        {
            Error = new()
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
        };

        ErrorRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
