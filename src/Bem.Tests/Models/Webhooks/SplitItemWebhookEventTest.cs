using System;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;
using Bem.Models.Webhooks;

namespace Bem.Tests.Models.Webhooks;

public class SplitItemWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemWebhookEventEventType.SplitItem,
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
        ApiEnum<string, SplitItemWebhookEventOutputType> expectedOutputType =
            SplitItemWebhookEventOutputType.PrintPage;
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SplitItemWebhookEventEventType> expectedEventType =
            SplitItemWebhookEventEventType.SplitItem;
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
        SplitItemWebhookEventMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        SplitItemWebhookEventPrintPageOutput expectedPrintPageOutput = new()
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };
        SplitItemWebhookEventSemanticPageOutput expectedSemanticPageOutput = new()
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
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemWebhookEventEventType.SplitItem,
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
        var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemWebhookEventEventType.SplitItem,
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
        var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        ApiEnum<string, SplitItemWebhookEventOutputType> expectedOutputType =
            SplitItemWebhookEventOutputType.PrintPage;
        string expectedReferenceID = "referenceID";
        string expectedCallID = "callID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SplitItemWebhookEventEventType> expectedEventType =
            SplitItemWebhookEventEventType.SplitItem;
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
        SplitItemWebhookEventMetadata expectedMetadata = new()
        {
            DurationFunctionToEventSeconds = 0,
        };
        SplitItemWebhookEventPrintPageOutput expectedPrintPageOutput = new()
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };
        SplitItemWebhookEventSemanticPageOutput expectedSemanticPageOutput = new()
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
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemWebhookEventEventType.SplitItem,
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
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
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
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
            ReferenceID = "referenceID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
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
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
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
        var model = new SplitItemWebhookEvent
        {
            EventID = "eventID",
            FunctionID = "functionID",
            FunctionName = "functionName",
            OutputType = SplitItemWebhookEventOutputType.PrintPage,
            ReferenceID = "referenceID",
            CallID = "callID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = SplitItemWebhookEventEventType.SplitItem,
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

        SplitItemWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitItemWebhookEventOutputTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitItemWebhookEventOutputType.PrintPage)]
    [InlineData(SplitItemWebhookEventOutputType.SemanticPage)]
    public void Validation_Works(SplitItemWebhookEventOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitItemWebhookEventOutputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitItemWebhookEventOutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitItemWebhookEventOutputType.PrintPage)]
    [InlineData(SplitItemWebhookEventOutputType.SemanticPage)]
    public void SerializationRoundtrip_Works(SplitItemWebhookEventOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitItemWebhookEventOutputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitItemWebhookEventOutputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitItemWebhookEventOutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitItemWebhookEventOutputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SplitItemWebhookEventEventTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitItemWebhookEventEventType.SplitItem)]
    public void Validation_Works(SplitItemWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitItemWebhookEventEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitItemWebhookEventEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitItemWebhookEventEventType.SplitItem)]
    public void SerializationRoundtrip_Works(SplitItemWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitItemWebhookEventEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitItemWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitItemWebhookEventEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitItemWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SplitItemWebhookEventMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitItemWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        double expectedDurationFunctionToEventSeconds = 0;

        Assert.Equal(expectedDurationFunctionToEventSeconds, model.DurationFunctionToEventSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitItemWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEventMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitItemWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEventMetadata>(
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
        var model = new SplitItemWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitItemWebhookEventMetadata { };

        Assert.Null(model.DurationFunctionToEventSeconds);
        Assert.False(model.RawData.ContainsKey("durationFunctionToEventSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitItemWebhookEventMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitItemWebhookEventMetadata
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
        var model = new SplitItemWebhookEventMetadata
        {
            // Null should be interpreted as omitted for these properties
            DurationFunctionToEventSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitItemWebhookEventMetadata { DurationFunctionToEventSeconds = 0 };

        SplitItemWebhookEventMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitItemWebhookEventPrintPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitItemWebhookEventPrintPageOutput
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
        var model = new SplitItemWebhookEventPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEventPrintPageOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitItemWebhookEventPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEventPrintPageOutput>(
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
        var model = new SplitItemWebhookEventPrintPageOutput
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
        var model = new SplitItemWebhookEventPrintPageOutput { };

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
        var model = new SplitItemWebhookEventPrintPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitItemWebhookEventPrintPageOutput
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
        var model = new SplitItemWebhookEventPrintPageOutput
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
        var model = new SplitItemWebhookEventPrintPageOutput
        {
            CollectionReferenceID = "collectionReferenceID",
            ItemCount = 0,
            ItemOffset = 0,
            S3Url = "s3URL",
        };

        SplitItemWebhookEventPrintPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitItemWebhookEventSemanticPageOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitItemWebhookEventSemanticPageOutput
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
        var model = new SplitItemWebhookEventSemanticPageOutput
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
        var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEventSemanticPageOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitItemWebhookEventSemanticPageOutput
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
        var deserialized = JsonSerializer.Deserialize<SplitItemWebhookEventSemanticPageOutput>(
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
        var model = new SplitItemWebhookEventSemanticPageOutput
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
        var model = new SplitItemWebhookEventSemanticPageOutput { };

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
        var model = new SplitItemWebhookEventSemanticPageOutput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitItemWebhookEventSemanticPageOutput
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
        var model = new SplitItemWebhookEventSemanticPageOutput
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
        var model = new SplitItemWebhookEventSemanticPageOutput
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

        SplitItemWebhookEventSemanticPageOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}
