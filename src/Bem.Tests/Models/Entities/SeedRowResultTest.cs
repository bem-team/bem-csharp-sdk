using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class SeedRowResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SeedRowResult
        {
            Canonical = "canonical",
            Outcome = Outcome.Created,
            EntityID = "entityID",
            Reason = "reason",
        };

        string expectedCanonical = "canonical";
        ApiEnum<string, Outcome> expectedOutcome = Outcome.Created;
        string expectedEntityID = "entityID";
        string expectedReason = "reason";

        Assert.Equal(expectedCanonical, model.Canonical);
        Assert.Equal(expectedOutcome, model.Outcome);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SeedRowResult
        {
            Canonical = "canonical",
            Outcome = Outcome.Created,
            EntityID = "entityID",
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SeedRowResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SeedRowResult
        {
            Canonical = "canonical",
            Outcome = Outcome.Created,
            EntityID = "entityID",
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SeedRowResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCanonical = "canonical";
        ApiEnum<string, Outcome> expectedOutcome = Outcome.Created;
        string expectedEntityID = "entityID";
        string expectedReason = "reason";

        Assert.Equal(expectedCanonical, deserialized.Canonical);
        Assert.Equal(expectedOutcome, deserialized.Outcome);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SeedRowResult
        {
            Canonical = "canonical",
            Outcome = Outcome.Created,
            EntityID = "entityID",
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SeedRowResult { Canonical = "canonical", Outcome = Outcome.Created };

        Assert.Null(model.EntityID);
        Assert.False(model.RawData.ContainsKey("entityID"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SeedRowResult { Canonical = "canonical", Outcome = Outcome.Created };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SeedRowResult
        {
            Canonical = "canonical",
            Outcome = Outcome.Created,

            // Null should be interpreted as omitted for these properties
            EntityID = null,
            Reason = null,
        };

        Assert.Null(model.EntityID);
        Assert.False(model.RawData.ContainsKey("entityID"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SeedRowResult
        {
            Canonical = "canonical",
            Outcome = Outcome.Created,

            // Null should be interpreted as omitted for these properties
            EntityID = null,
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SeedRowResult
        {
            Canonical = "canonical",
            Outcome = Outcome.Created,
            EntityID = "entityID",
            Reason = "reason",
        };

        SeedRowResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutcomeTest : TestBase
{
    [Theory]
    [InlineData(Outcome.Created)]
    [InlineData(Outcome.MergedWith)]
    [InlineData(Outcome.Rejected)]
    public void Validation_Works(Outcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Outcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Outcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Outcome.Created)]
    [InlineData(Outcome.MergedWith)]
    [InlineData(Outcome.Rejected)]
    public void SerializationRoundtrip_Works(Outcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Outcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Outcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Outcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Outcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
