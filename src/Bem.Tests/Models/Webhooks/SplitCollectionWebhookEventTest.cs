using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;
using Bem.Models.Webhooks;

namespace Bem.Tests.Models.Webhooks;

public class SplitCollectionWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitCollectionWebhookEvent
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
        ApiEnum<string, SplitCollectionWebhookEventEventType> expectedEventType =
            SplitCollectionWebhookEventEventType.SplitCollection;
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        SplitCollectionWebhookEventMetadata expectedMetadata = new()
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
        var model = new SplitCollectionWebhookEvent
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCollectionWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitCollectionWebhookEvent
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCollectionWebhookEvent>(
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
        ApiEnum<string, SplitCollectionWebhookEventEventType> expectedEventType =
            SplitCollectionWebhookEventEventType.SplitCollection;
        string expectedFunctionCallID = "functionCallID";
        long expectedFunctionCallTryNumber = 0;
        long expectedFunctionVersionNum = 0;
        InboundEmailEvent expectedInboundEmail = new()
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };
        SplitCollectionWebhookEventMetadata expectedMetadata = new()
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
        var model = new SplitCollectionWebhookEvent
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitCollectionWebhookEvent
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
        var model = new SplitCollectionWebhookEvent
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
        var model = new SplitCollectionWebhookEvent
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
        var model = new SplitCollectionWebhookEvent
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
        var model = new SplitCollectionWebhookEvent
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

        SplitCollectionWebhookEvent copied = new(model);

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

public class SplitCollectionWebhookEventEventTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitCollectionWebhookEventEventType.SplitCollection)]
    public void Validation_Works(SplitCollectionWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCollectionWebhookEventEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCollectionWebhookEventEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitCollectionWebhookEventEventType.SplitCollection)]
    public void SerializationRoundtrip_Works(SplitCollectionWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCollectionWebhookEventEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCollectionWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCollectionWebhookEventEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCollectionWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SplitCollectionWebhookEventMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitCollectionWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitCollectionWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCollectionWebhookEventMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitCollectionWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCollectionWebhookEventMetadata>(
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
        var model = new SplitCollectionWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitCollectionWebhookEventMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitCollectionWebhookEventMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitCollectionWebhookEventMetadata
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
        var model = new SplitCollectionWebhookEventMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitCollectionWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        SplitCollectionWebhookEventMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
