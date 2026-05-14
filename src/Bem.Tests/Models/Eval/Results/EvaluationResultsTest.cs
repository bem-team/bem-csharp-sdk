using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Eval.Results;

namespace Bem.Tests.Models.Eval.Results;

public class EvaluationResultsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    EventID = "eventID",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "eventID",
                },
            ],
        };

        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedErrors = JsonSerializer.Deserialize<JsonElement>("{}");
        List<Failed> expectedFailed =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                EventID = "eventID",
            },
        ];
        List<Pending> expectedPending =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventID = "eventID",
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedResults, model.Results));
        Assert.NotNull(model.Errors);
        Assert.True(JsonElement.DeepEquals(expectedErrors, model.Errors.Value));
        Assert.NotNull(model.Failed);
        Assert.Equal(expectedFailed.Count, model.Failed.Count);
        for (int i = 0; i < expectedFailed.Count; i++)
        {
            Assert.Equal(expectedFailed[i], model.Failed[i]);
        }
        Assert.NotNull(model.Pending);
        Assert.Equal(expectedPending.Count, model.Pending.Count);
        for (int i = 0; i < expectedPending.Count; i++)
        {
            Assert.Equal(expectedPending[i], model.Pending[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    EventID = "eventID",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "eventID",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EvaluationResults>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    EventID = "eventID",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "eventID",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EvaluationResults>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedErrors = JsonSerializer.Deserialize<JsonElement>("{}");
        List<Failed> expectedFailed =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                EventID = "eventID",
            },
        ];
        List<Pending> expectedPending =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventID = "eventID",
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedResults, deserialized.Results));
        Assert.NotNull(deserialized.Errors);
        Assert.True(JsonElement.DeepEquals(expectedErrors, deserialized.Errors.Value));
        Assert.NotNull(deserialized.Failed);
        Assert.Equal(expectedFailed.Count, deserialized.Failed.Count);
        for (int i = 0; i < expectedFailed.Count; i++)
        {
            Assert.Equal(expectedFailed[i], deserialized.Failed[i]);
        }
        Assert.NotNull(deserialized.Pending);
        Assert.Equal(expectedPending.Count, deserialized.Pending.Count);
        for (int i = 0; i < expectedPending.Count; i++)
        {
            Assert.Equal(expectedPending[i], deserialized.Pending[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    EventID = "eventID",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "eventID",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Errors);
        Assert.False(model.RawData.ContainsKey("errors"));
        Assert.Null(model.Failed);
        Assert.False(model.RawData.ContainsKey("failed"));
        Assert.Null(model.Pending);
        Assert.False(model.RawData.ContainsKey("pending"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            Errors = null,
            Failed = null,
            Pending = null,
        };

        Assert.Null(model.Errors);
        Assert.False(model.RawData.ContainsKey("errors"));
        Assert.Null(model.Failed);
        Assert.False(model.RawData.ContainsKey("failed"));
        Assert.Null(model.Pending);
        Assert.False(model.RawData.ContainsKey("pending"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            Errors = null,
            Failed = null,
            Pending = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EvaluationResults
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    EventID = "eventID",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "eventID",
                },
            ],
        };

        EvaluationResults copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FailedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Failed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventID = "eventID",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        string expectedEventID = "eventID";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Failed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventID = "eventID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Failed>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Failed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventID = "eventID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Failed>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        string expectedEventID = "eventID";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Failed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventID = "eventID",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Failed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            EventID = "eventID",
        };

        Failed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PendingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventID = "eventID";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pending>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pending>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventID = "eventID";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "eventID",
        };

        Pending copied = new(model);

        Assert.Equal(model, copied);
    }
}
