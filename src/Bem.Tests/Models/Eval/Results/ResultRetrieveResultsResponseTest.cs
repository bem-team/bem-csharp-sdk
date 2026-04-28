using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Eval.Results;

namespace Bem.Tests.Models.Eval.Results;

public class ResultRetrieveResultsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResultRetrieveResultsResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    TransformationID = "transformationId",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransformationID = "transformationId",
                },
            ],
        };

        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedErrors = JsonSerializer.Deserialize<JsonElement>("{}");
        List<ResultRetrieveResultsResponseFailed> expectedFailed =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                TransformationID = "transformationId",
            },
        ];
        List<ResultRetrieveResultsResponsePending> expectedPending =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TransformationID = "transformationId",
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
        var model = new ResultRetrieveResultsResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    TransformationID = "transformationId",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransformationID = "transformationId",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResultRetrieveResultsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResultRetrieveResultsResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    TransformationID = "transformationId",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransformationID = "transformationId",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResultRetrieveResultsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedErrors = JsonSerializer.Deserialize<JsonElement>("{}");
        List<ResultRetrieveResultsResponseFailed> expectedFailed =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                TransformationID = "transformationId",
            },
        ];
        List<ResultRetrieveResultsResponsePending> expectedPending =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TransformationID = "transformationId",
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
        var model = new ResultRetrieveResultsResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    TransformationID = "transformationId",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransformationID = "transformationId",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResultRetrieveResultsResponse
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
        var model = new ResultRetrieveResultsResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ResultRetrieveResultsResponse
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
        var model = new ResultRetrieveResultsResponse
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
        var model = new ResultRetrieveResultsResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Failed =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    TransformationID = "transformationId",
                },
            ],
            Pending =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransformationID = "transformationId",
                },
            ],
        };

        ResultRetrieveResultsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultRetrieveResultsResponseFailedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResultRetrieveResultsResponseFailed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            TransformationID = "transformationId",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        string expectedTransformationID = "transformationId";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedTransformationID, model.TransformationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResultRetrieveResultsResponseFailed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            TransformationID = "transformationId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResultRetrieveResultsResponseFailed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResultRetrieveResultsResponseFailed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            TransformationID = "transformationId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResultRetrieveResultsResponseFailed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        string expectedTransformationID = "transformationId";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedTransformationID, deserialized.TransformationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResultRetrieveResultsResponseFailed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            TransformationID = "transformationId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResultRetrieveResultsResponseFailed
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            TransformationID = "transformationId",
        };

        ResultRetrieveResultsResponseFailed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultRetrieveResultsResponsePendingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResultRetrieveResultsResponsePending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransformationID = "transformationId",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransformationID = "transformationId";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedTransformationID, model.TransformationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResultRetrieveResultsResponsePending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransformationID = "transformationId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResultRetrieveResultsResponsePending>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResultRetrieveResultsResponsePending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransformationID = "transformationId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResultRetrieveResultsResponsePending>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransformationID = "transformationId";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedTransformationID, deserialized.TransformationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResultRetrieveResultsResponsePending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransformationID = "transformationId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResultRetrieveResultsResponsePending
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransformationID = "transformationId",
        };

        ResultRetrieveResultsResponsePending copied = new(model);

        Assert.Equal(model, copied);
    }
}
