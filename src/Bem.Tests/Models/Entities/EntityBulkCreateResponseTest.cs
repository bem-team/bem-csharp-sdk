using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityBulkCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityBulkCreateResponse
        {
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
            Summary = new()
            {
                Created = 0,
                Merged = 0,
                Rejected = 0,
            },
        };

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
        Summary expectedSummary = new()
        {
            Created = 0,
            Merged = 0,
            Rejected = 0,
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
        var model = new EntityBulkCreateResponse
        {
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
            Summary = new()
            {
                Created = 0,
                Merged = 0,
                Rejected = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityBulkCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityBulkCreateResponse
        {
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
            Summary = new()
            {
                Created = 0,
                Merged = 0,
                Rejected = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityBulkCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        Summary expectedSummary = new()
        {
            Created = 0,
            Merged = 0,
            Rejected = 0,
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
        var model = new EntityBulkCreateResponse
        {
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
            Summary = new()
            {
                Created = 0,
                Merged = 0,
                Rejected = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityBulkCreateResponse
        {
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
            Summary = new()
            {
                Created = 0,
                Merged = 0,
                Rejected = 0,
            },
        };

        EntityBulkCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Summary
        {
            Created = 0,
            Merged = 0,
            Rejected = 0,
        };

        int expectedCreated = 0;
        int expectedMerged = 0;
        int expectedRejected = 0;

        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedMerged, model.Merged);
        Assert.Equal(expectedRejected, model.Rejected);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Summary
        {
            Created = 0,
            Merged = 0,
            Rejected = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Summary
        {
            Created = 0,
            Merged = 0,
            Rejected = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedCreated = 0;
        int expectedMerged = 0;
        int expectedRejected = 0;

        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedMerged, deserialized.Merged);
        Assert.Equal(expectedRejected, deserialized.Rejected);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Summary
        {
            Created = 0,
            Merged = 0,
            Rejected = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Summary
        {
            Created = 0,
            Merged = 0,
            Rejected = 0,
        };

        Summary copied = new(model);

        Assert.Equal(model, copied);
    }
}
