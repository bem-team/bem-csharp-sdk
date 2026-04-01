using System.Text.Json;
using Bem.Core;
using Bem.Models.Errors;

namespace Bem.Tests.Models.Errors;

public class InboundEmailEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };

        string expectedFrom = "from";
        string expectedSubject = "subject";
        string expectedTo = "to";
        string expectedDeliveredTo = "deliveredTo";

        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedSubject, model.Subject);
        Assert.Equal(expectedTo, model.To);
        Assert.Equal(expectedDeliveredTo, model.DeliveredTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundEmailEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundEmailEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFrom = "from";
        string expectedSubject = "subject";
        string expectedTo = "to";
        string expectedDeliveredTo = "deliveredTo";

        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedSubject, deserialized.Subject);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.Equal(expectedDeliveredTo, deserialized.DeliveredTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",
        };

        Assert.Null(model.DeliveredTo);
        Assert.False(model.RawData.ContainsKey("deliveredTo"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",

            // Null should be interpreted as omitted for these properties
            DeliveredTo = null,
        };

        Assert.Null(model.DeliveredTo);
        Assert.False(model.RawData.ContainsKey("deliveredTo"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",

            // Null should be interpreted as omitted for these properties
            DeliveredTo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundEmailEvent
        {
            From = "from",
            Subject = "subject",
            To = "to",
            DeliveredTo = "deliveredTo",
        };

        InboundEmailEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
