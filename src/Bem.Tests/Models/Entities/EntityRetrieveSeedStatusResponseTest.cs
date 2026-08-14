using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityRetrieveSeedStatusResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,
            Error = "error",
            Results =
            [
                new()
                {
                    Canonical = "canonical",
                    Outcome = Outcome.Created,
                    EntityID = "entityID",
                    Reason = "reason",
                },
            ],
        };

        int expectedCreatedCount = 0;
        int expectedMergedCount = 0;
        int expectedRejectedCount = 0;
        string expectedSeedJobID = "seedJobID";
        ApiEnum<string, EntityRetrieveSeedStatusResponseStatus> expectedStatus =
            EntityRetrieveSeedStatusResponseStatus.Pending;
        int expectedTotalRows = 0;
        string expectedError = "error";
        List<SeedRowResult> expectedResults =
        [
            new()
            {
                Canonical = "canonical",
                Outcome = Outcome.Created,
                EntityID = "entityID",
                Reason = "reason",
            },
        ];

        Assert.Equal(expectedCreatedCount, model.CreatedCount);
        Assert.Equal(expectedMergedCount, model.MergedCount);
        Assert.Equal(expectedRejectedCount, model.RejectedCount);
        Assert.Equal(expectedSeedJobID, model.SeedJobID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTotalRows, model.TotalRows);
        Assert.Equal(expectedError, model.Error);
        Assert.NotNull(model.Results);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,
            Error = "error",
            Results =
            [
                new()
                {
                    Canonical = "canonical",
                    Outcome = Outcome.Created,
                    EntityID = "entityID",
                    Reason = "reason",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityRetrieveSeedStatusResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,
            Error = "error",
            Results =
            [
                new()
                {
                    Canonical = "canonical",
                    Outcome = Outcome.Created,
                    EntityID = "entityID",
                    Reason = "reason",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityRetrieveSeedStatusResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedCreatedCount = 0;
        int expectedMergedCount = 0;
        int expectedRejectedCount = 0;
        string expectedSeedJobID = "seedJobID";
        ApiEnum<string, EntityRetrieveSeedStatusResponseStatus> expectedStatus =
            EntityRetrieveSeedStatusResponseStatus.Pending;
        int expectedTotalRows = 0;
        string expectedError = "error";
        List<SeedRowResult> expectedResults =
        [
            new()
            {
                Canonical = "canonical",
                Outcome = Outcome.Created,
                EntityID = "entityID",
                Reason = "reason",
            },
        ];

        Assert.Equal(expectedCreatedCount, deserialized.CreatedCount);
        Assert.Equal(expectedMergedCount, deserialized.MergedCount);
        Assert.Equal(expectedRejectedCount, deserialized.RejectedCount);
        Assert.Equal(expectedSeedJobID, deserialized.SeedJobID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTotalRows, deserialized.TotalRows);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.NotNull(deserialized.Results);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,
            Error = "error",
            Results =
            [
                new()
                {
                    Canonical = "canonical",
                    Outcome = Outcome.Created,
                    EntityID = "entityID",
                    Reason = "reason",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Results = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Results = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityRetrieveSeedStatusResponse
        {
            CreatedCount = 0,
            MergedCount = 0,
            RejectedCount = 0,
            SeedJobID = "seedJobID",
            Status = EntityRetrieveSeedStatusResponseStatus.Pending,
            TotalRows = 0,
            Error = "error",
            Results =
            [
                new()
                {
                    Canonical = "canonical",
                    Outcome = Outcome.Created,
                    EntityID = "entityID",
                    Reason = "reason",
                },
            ],
        };

        EntityRetrieveSeedStatusResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityRetrieveSeedStatusResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(EntityRetrieveSeedStatusResponseStatus.Pending)]
    [InlineData(EntityRetrieveSeedStatusResponseStatus.Processing)]
    [InlineData(EntityRetrieveSeedStatusResponseStatus.Completed)]
    [InlineData(EntityRetrieveSeedStatusResponseStatus.Failed)]
    public void Validation_Works(EntityRetrieveSeedStatusResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityRetrieveSeedStatusResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityRetrieveSeedStatusResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityRetrieveSeedStatusResponseStatus.Pending)]
    [InlineData(EntityRetrieveSeedStatusResponseStatus.Processing)]
    [InlineData(EntityRetrieveSeedStatusResponseStatus.Completed)]
    [InlineData(EntityRetrieveSeedStatusResponseStatus.Failed)]
    public void SerializationRoundtrip_Works(EntityRetrieveSeedStatusResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityRetrieveSeedStatusResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityRetrieveSeedStatusResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityRetrieveSeedStatusResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityRetrieveSeedStatusResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
