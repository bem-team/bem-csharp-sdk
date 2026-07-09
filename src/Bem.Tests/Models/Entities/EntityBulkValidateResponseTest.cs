using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityBulkValidateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityBulkValidateResponse
        {
            Results =
            [
                new()
                {
                    EntityID = "entityID",
                    Outcome = ResultOutcome.Validated,
                    Reason = "reason",
                },
            ],
            Summary = new()
            {
                RejectedRow = 0,
                Skipped = 0,
                Validated = 0,
            },
        };

        List<Result> expectedResults =
        [
            new()
            {
                EntityID = "entityID",
                Outcome = ResultOutcome.Validated,
                Reason = "reason",
            },
        ];
        EntityBulkValidateResponseSummary expectedSummary = new()
        {
            RejectedRow = 0,
            Skipped = 0,
            Validated = 0,
        };

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedSummary, model.Summary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityBulkValidateResponse
        {
            Results =
            [
                new()
                {
                    EntityID = "entityID",
                    Outcome = ResultOutcome.Validated,
                    Reason = "reason",
                },
            ],
            Summary = new()
            {
                RejectedRow = 0,
                Skipped = 0,
                Validated = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityBulkValidateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityBulkValidateResponse
        {
            Results =
            [
                new()
                {
                    EntityID = "entityID",
                    Outcome = ResultOutcome.Validated,
                    Reason = "reason",
                },
            ],
            Summary = new()
            {
                RejectedRow = 0,
                Skipped = 0,
                Validated = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityBulkValidateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Result> expectedResults =
        [
            new()
            {
                EntityID = "entityID",
                Outcome = ResultOutcome.Validated,
                Reason = "reason",
            },
        ];
        EntityBulkValidateResponseSummary expectedSummary = new()
        {
            RejectedRow = 0,
            Skipped = 0,
            Validated = 0,
        };

        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
        Assert.Equal(expectedSummary, deserialized.Summary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityBulkValidateResponse
        {
            Results =
            [
                new()
                {
                    EntityID = "entityID",
                    Outcome = ResultOutcome.Validated,
                    Reason = "reason",
                },
            ],
            Summary = new()
            {
                RejectedRow = 0,
                Skipped = 0,
                Validated = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityBulkValidateResponse
        {
            Results =
            [
                new()
                {
                    EntityID = "entityID",
                    Outcome = ResultOutcome.Validated,
                    Reason = "reason",
                },
            ],
            Summary = new()
            {
                RejectedRow = 0,
                Skipped = 0,
                Validated = 0,
            },
        };

        EntityBulkValidateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            EntityID = "entityID",
            Outcome = ResultOutcome.Validated,
            Reason = "reason",
        };

        string expectedEntityID = "entityID";
        ApiEnum<string, ResultOutcome> expectedOutcome = ResultOutcome.Validated;
        string expectedReason = "reason";

        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedOutcome, model.Outcome);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            EntityID = "entityID",
            Outcome = ResultOutcome.Validated,
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            EntityID = "entityID",
            Outcome = ResultOutcome.Validated,
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedEntityID = "entityID";
        ApiEnum<string, ResultOutcome> expectedOutcome = ResultOutcome.Validated;
        string expectedReason = "reason";

        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedOutcome, deserialized.Outcome);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            EntityID = "entityID",
            Outcome = ResultOutcome.Validated,
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { EntityID = "entityID", Outcome = ResultOutcome.Validated };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result { EntityID = "entityID", Outcome = ResultOutcome.Validated };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            EntityID = "entityID",
            Outcome = ResultOutcome.Validated,

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            EntityID = "entityID",
            Outcome = ResultOutcome.Validated,

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            EntityID = "entityID",
            Outcome = ResultOutcome.Validated,
            Reason = "reason",
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultOutcomeTest : TestBase
{
    [Theory]
    [InlineData(ResultOutcome.Validated)]
    [InlineData(ResultOutcome.Skipped)]
    [InlineData(ResultOutcome.RejectedRow)]
    public void Validation_Works(ResultOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResultOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResultOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResultOutcome.Validated)]
    [InlineData(ResultOutcome.Skipped)]
    [InlineData(ResultOutcome.RejectedRow)]
    public void SerializationRoundtrip_Works(ResultOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResultOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResultOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResultOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResultOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntityBulkValidateResponseSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityBulkValidateResponseSummary
        {
            RejectedRow = 0,
            Skipped = 0,
            Validated = 0,
        };

        int expectedRejectedRow = 0;
        int expectedSkipped = 0;
        int expectedValidated = 0;

        Assert.Equal(expectedRejectedRow, model.RejectedRow);
        Assert.Equal(expectedSkipped, model.Skipped);
        Assert.Equal(expectedValidated, model.Validated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityBulkValidateResponseSummary
        {
            RejectedRow = 0,
            Skipped = 0,
            Validated = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityBulkValidateResponseSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityBulkValidateResponseSummary
        {
            RejectedRow = 0,
            Skipped = 0,
            Validated = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityBulkValidateResponseSummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedRejectedRow = 0;
        int expectedSkipped = 0;
        int expectedValidated = 0;

        Assert.Equal(expectedRejectedRow, deserialized.RejectedRow);
        Assert.Equal(expectedSkipped, deserialized.Skipped);
        Assert.Equal(expectedValidated, deserialized.Validated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityBulkValidateResponseSummary
        {
            RejectedRow = 0,
            Skipped = 0,
            Validated = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityBulkValidateResponseSummary
        {
            RejectedRow = 0,
            Skipped = 0,
            Validated = 0,
        };

        EntityBulkValidateResponseSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}
