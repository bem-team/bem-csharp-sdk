using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Eval.Score;

namespace Bem.Tests.Models.Eval.Score;

public class EvalScoreRunTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
            Aggregate = new()
            {
                ExactMatches = 0,
                Extras = 0,
                F1 = 0,
                FuzzyMatches = 0,
                Misses = 0,
                Precision = 0,
                Recall = 0,
                TotalFieldsActual = 0,
                TotalFieldsExpected = 0,
                WithinTolerance = 0,
            },
        };

        string expectedFunctionName = "functionName";
        long expectedFunctionVersionNum = 0;
        EvalMatchConfig expectedMatchConfig = new()
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };
        List<PerPair> expectedPerPair =
        [
            new()
            {
                PairIndex = 0,
                Status = Status.Pending,
                CallID = "callID",
                ErrorMessage = "errorMessage",
                FieldResults =
                [
                    new()
                    {
                        Match = Match.Exact,
                        Path = "path",
                        Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Delta = 0,
                        Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                ],
            },
        ];
        Progress expectedProgress = new()
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };
        string expectedScoreRunID = "scoreRunID";
        ApiEnum<string, EvalScoreRunStatus> expectedStatus = EvalScoreRunStatus.Pending;
        Aggregate expectedAggregate = new()
        {
            ExactMatches = 0,
            Extras = 0,
            F1 = 0,
            FuzzyMatches = 0,
            Misses = 0,
            Precision = 0,
            Recall = 0,
            TotalFieldsActual = 0,
            TotalFieldsExpected = 0,
            WithinTolerance = 0,
        };

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedFunctionVersionNum, model.FunctionVersionNum);
        Assert.Equal(expectedMatchConfig, model.MatchConfig);
        Assert.Equal(expectedPerPair.Count, model.PerPair.Count);
        for (int i = 0; i < expectedPerPair.Count; i++)
        {
            Assert.Equal(expectedPerPair[i], model.PerPair[i]);
        }
        Assert.Equal(expectedProgress, model.Progress);
        Assert.Equal(expectedScoreRunID, model.ScoreRunID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAggregate, model.Aggregate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
            Aggregate = new()
            {
                ExactMatches = 0,
                Extras = 0,
                F1 = 0,
                FuzzyMatches = 0,
                Misses = 0,
                Precision = 0,
                Recall = 0,
                TotalFieldsActual = 0,
                TotalFieldsExpected = 0,
                WithinTolerance = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EvalScoreRun>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
            Aggregate = new()
            {
                ExactMatches = 0,
                Extras = 0,
                F1 = 0,
                FuzzyMatches = 0,
                Misses = 0,
                Precision = 0,
                Recall = 0,
                TotalFieldsActual = 0,
                TotalFieldsExpected = 0,
                WithinTolerance = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EvalScoreRun>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        long expectedFunctionVersionNum = 0;
        EvalMatchConfig expectedMatchConfig = new()
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };
        List<PerPair> expectedPerPair =
        [
            new()
            {
                PairIndex = 0,
                Status = Status.Pending,
                CallID = "callID",
                ErrorMessage = "errorMessage",
                FieldResults =
                [
                    new()
                    {
                        Match = Match.Exact,
                        Path = "path",
                        Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Delta = 0,
                        Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                ],
            },
        ];
        Progress expectedProgress = new()
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };
        string expectedScoreRunID = "scoreRunID";
        ApiEnum<string, EvalScoreRunStatus> expectedStatus = EvalScoreRunStatus.Pending;
        Aggregate expectedAggregate = new()
        {
            ExactMatches = 0,
            Extras = 0,
            F1 = 0,
            FuzzyMatches = 0,
            Misses = 0,
            Precision = 0,
            Recall = 0,
            TotalFieldsActual = 0,
            TotalFieldsExpected = 0,
            WithinTolerance = 0,
        };

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedFunctionVersionNum, deserialized.FunctionVersionNum);
        Assert.Equal(expectedMatchConfig, deserialized.MatchConfig);
        Assert.Equal(expectedPerPair.Count, deserialized.PerPair.Count);
        for (int i = 0; i < expectedPerPair.Count; i++)
        {
            Assert.Equal(expectedPerPair[i], deserialized.PerPair[i]);
        }
        Assert.Equal(expectedProgress, deserialized.Progress);
        Assert.Equal(expectedScoreRunID, deserialized.ScoreRunID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAggregate, deserialized.Aggregate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
            Aggregate = new()
            {
                ExactMatches = 0,
                Extras = 0,
                F1 = 0,
                FuzzyMatches = 0,
                Misses = 0,
                Precision = 0,
                Recall = 0,
                TotalFieldsActual = 0,
                TotalFieldsExpected = 0,
                WithinTolerance = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
        };

        Assert.Null(model.Aggregate);
        Assert.False(model.RawData.ContainsKey("aggregate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,

            // Null should be interpreted as omitted for these properties
            Aggregate = null,
        };

        Assert.Null(model.Aggregate);
        Assert.False(model.RawData.ContainsKey("aggregate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,

            // Null should be interpreted as omitted for these properties
            Aggregate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EvalScoreRun
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = Status.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = Match.Exact,
                            Path = "path",
                            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Delta = 0,
                            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        },
                    ],
                },
            ],
            Progress = new()
            {
                Completed = 0,
                Failed = 0,
                Total = 0,
            },
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
            Aggregate = new()
            {
                ExactMatches = 0,
                Extras = 0,
                F1 = 0,
                FuzzyMatches = 0,
                Misses = 0,
                Precision = 0,
                Recall = 0,
                TotalFieldsActual = 0,
                TotalFieldsExpected = 0,
                WithinTolerance = 0,
            },
        };

        EvalScoreRun copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PerPairTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PerPair
        {
            PairIndex = 0,
            Status = Status.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = Match.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        long expectedPairIndex = 0;
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedCallID = "callID";
        string expectedErrorMessage = "errorMessage";
        List<FieldResult> expectedFieldResults =
        [
            new()
            {
                Match = Match.Exact,
                Path = "path",
                Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                Delta = 0,
                Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];

        Assert.Equal(expectedPairIndex, model.PairIndex);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.NotNull(model.FieldResults);
        Assert.Equal(expectedFieldResults.Count, model.FieldResults.Count);
        for (int i = 0; i < expectedFieldResults.Count; i++)
        {
            Assert.Equal(expectedFieldResults[i], model.FieldResults[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PerPair
        {
            PairIndex = 0,
            Status = Status.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = Match.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PerPair>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PerPair
        {
            PairIndex = 0,
            Status = Status.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = Match.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PerPair>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPairIndex = 0;
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedCallID = "callID";
        string expectedErrorMessage = "errorMessage";
        List<FieldResult> expectedFieldResults =
        [
            new()
            {
                Match = Match.Exact,
                Path = "path",
                Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                Delta = 0,
                Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];

        Assert.Equal(expectedPairIndex, deserialized.PairIndex);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.NotNull(deserialized.FieldResults);
        Assert.Equal(expectedFieldResults.Count, deserialized.FieldResults.Count);
        for (int i = 0; i < expectedFieldResults.Count; i++)
        {
            Assert.Equal(expectedFieldResults[i], deserialized.FieldResults[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PerPair
        {
            PairIndex = 0,
            Status = Status.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = Match.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PerPair { PairIndex = 0, Status = Status.Pending };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("callID"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.FieldResults);
        Assert.False(model.RawData.ContainsKey("fieldResults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PerPair { PairIndex = 0, Status = Status.Pending };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PerPair
        {
            PairIndex = 0,
            Status = Status.Pending,

            // Null should be interpreted as omitted for these properties
            CallID = null,
            ErrorMessage = null,
            FieldResults = null,
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("callID"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.FieldResults);
        Assert.False(model.RawData.ContainsKey("fieldResults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PerPair
        {
            PairIndex = 0,
            Status = Status.Pending,

            // Null should be interpreted as omitted for these properties
            CallID = null,
            ErrorMessage = null,
            FieldResults = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PerPair
        {
            PairIndex = 0,
            Status = Status.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = Match.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        PerPair copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FieldResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FieldResult
        {
            Match = Match.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ApiEnum<string, Match> expectedMatch = Match.Exact;
        string expectedPath = "path";
        JsonElement expectedActual = JsonSerializer.Deserialize<JsonElement>("{}");
        double expectedDelta = 0;
        JsonElement expectedExpected = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedMatch, model.Match);
        Assert.Equal(expectedPath, model.Path);
        Assert.NotNull(model.Actual);
        Assert.True(JsonElement.DeepEquals(expectedActual, model.Actual.Value));
        Assert.Equal(expectedDelta, model.Delta);
        Assert.NotNull(model.Expected);
        Assert.True(JsonElement.DeepEquals(expectedExpected, model.Expected.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FieldResult
        {
            Match = Match.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FieldResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FieldResult
        {
            Match = Match.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FieldResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Match> expectedMatch = Match.Exact;
        string expectedPath = "path";
        JsonElement expectedActual = JsonSerializer.Deserialize<JsonElement>("{}");
        double expectedDelta = 0;
        JsonElement expectedExpected = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedMatch, deserialized.Match);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.NotNull(deserialized.Actual);
        Assert.True(JsonElement.DeepEquals(expectedActual, deserialized.Actual.Value));
        Assert.Equal(expectedDelta, deserialized.Delta);
        Assert.NotNull(deserialized.Expected);
        Assert.True(JsonElement.DeepEquals(expectedExpected, deserialized.Expected.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FieldResult
        {
            Match = Match.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FieldResult { Match = Match.Exact, Path = "path" };

        Assert.Null(model.Actual);
        Assert.False(model.RawData.ContainsKey("actual"));
        Assert.Null(model.Delta);
        Assert.False(model.RawData.ContainsKey("delta"));
        Assert.Null(model.Expected);
        Assert.False(model.RawData.ContainsKey("expected"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FieldResult { Match = Match.Exact, Path = "path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FieldResult
        {
            Match = Match.Exact,
            Path = "path",

            // Null should be interpreted as omitted for these properties
            Actual = null,
            Delta = null,
            Expected = null,
        };

        Assert.Null(model.Actual);
        Assert.False(model.RawData.ContainsKey("actual"));
        Assert.Null(model.Delta);
        Assert.False(model.RawData.ContainsKey("delta"));
        Assert.Null(model.Expected);
        Assert.False(model.RawData.ContainsKey("expected"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FieldResult
        {
            Match = Match.Exact,
            Path = "path",

            // Null should be interpreted as omitted for these properties
            Actual = null,
            Delta = null,
            Expected = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FieldResult
        {
            Match = Match.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        FieldResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MatchTest : TestBase
{
    [Theory]
    [InlineData(Match.Exact)]
    [InlineData(Match.WithinTolerance)]
    [InlineData(Match.FuzzyMatch)]
    [InlineData(Match.Miss)]
    [InlineData(Match.Extra)]
    public void Validation_Works(Match rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Match> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Match>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Match.Exact)]
    [InlineData(Match.WithinTolerance)]
    [InlineData(Match.FuzzyMatch)]
    [InlineData(Match.Miss)]
    [InlineData(Match.Extra)]
    public void SerializationRoundtrip_Works(Match rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Match> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Match>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Match>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Match>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProgressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Progress
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };

        long expectedCompleted = 0;
        long expectedFailed = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedCompleted, model.Completed);
        Assert.Equal(expectedFailed, model.Failed);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Progress
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Progress>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Progress
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Progress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCompleted = 0;
        long expectedFailed = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedCompleted, deserialized.Completed);
        Assert.Equal(expectedFailed, deserialized.Failed);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Progress
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Progress
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };

        Progress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AggregateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Aggregate
        {
            ExactMatches = 0,
            Extras = 0,
            F1 = 0,
            FuzzyMatches = 0,
            Misses = 0,
            Precision = 0,
            Recall = 0,
            TotalFieldsActual = 0,
            TotalFieldsExpected = 0,
            WithinTolerance = 0,
        };

        long expectedExactMatches = 0;
        long expectedExtras = 0;
        double expectedF1 = 0;
        long expectedFuzzyMatches = 0;
        long expectedMisses = 0;
        double expectedPrecision = 0;
        double expectedRecall = 0;
        long expectedTotalFieldsActual = 0;
        long expectedTotalFieldsExpected = 0;
        long expectedWithinTolerance = 0;

        Assert.Equal(expectedExactMatches, model.ExactMatches);
        Assert.Equal(expectedExtras, model.Extras);
        Assert.Equal(expectedF1, model.F1);
        Assert.Equal(expectedFuzzyMatches, model.FuzzyMatches);
        Assert.Equal(expectedMisses, model.Misses);
        Assert.Equal(expectedPrecision, model.Precision);
        Assert.Equal(expectedRecall, model.Recall);
        Assert.Equal(expectedTotalFieldsActual, model.TotalFieldsActual);
        Assert.Equal(expectedTotalFieldsExpected, model.TotalFieldsExpected);
        Assert.Equal(expectedWithinTolerance, model.WithinTolerance);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Aggregate
        {
            ExactMatches = 0,
            Extras = 0,
            F1 = 0,
            FuzzyMatches = 0,
            Misses = 0,
            Precision = 0,
            Recall = 0,
            TotalFieldsActual = 0,
            TotalFieldsExpected = 0,
            WithinTolerance = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Aggregate>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Aggregate
        {
            ExactMatches = 0,
            Extras = 0,
            F1 = 0,
            FuzzyMatches = 0,
            Misses = 0,
            Precision = 0,
            Recall = 0,
            TotalFieldsActual = 0,
            TotalFieldsExpected = 0,
            WithinTolerance = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Aggregate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedExactMatches = 0;
        long expectedExtras = 0;
        double expectedF1 = 0;
        long expectedFuzzyMatches = 0;
        long expectedMisses = 0;
        double expectedPrecision = 0;
        double expectedRecall = 0;
        long expectedTotalFieldsActual = 0;
        long expectedTotalFieldsExpected = 0;
        long expectedWithinTolerance = 0;

        Assert.Equal(expectedExactMatches, deserialized.ExactMatches);
        Assert.Equal(expectedExtras, deserialized.Extras);
        Assert.Equal(expectedF1, deserialized.F1);
        Assert.Equal(expectedFuzzyMatches, deserialized.FuzzyMatches);
        Assert.Equal(expectedMisses, deserialized.Misses);
        Assert.Equal(expectedPrecision, deserialized.Precision);
        Assert.Equal(expectedRecall, deserialized.Recall);
        Assert.Equal(expectedTotalFieldsActual, deserialized.TotalFieldsActual);
        Assert.Equal(expectedTotalFieldsExpected, deserialized.TotalFieldsExpected);
        Assert.Equal(expectedWithinTolerance, deserialized.WithinTolerance);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Aggregate
        {
            ExactMatches = 0,
            Extras = 0,
            F1 = 0,
            FuzzyMatches = 0,
            Misses = 0,
            Precision = 0,
            Recall = 0,
            TotalFieldsActual = 0,
            TotalFieldsExpected = 0,
            WithinTolerance = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Aggregate
        {
            ExactMatches = 0,
            Extras = 0,
            F1 = 0,
            FuzzyMatches = 0,
            Misses = 0,
            Precision = 0,
            Recall = 0,
            TotalFieldsActual = 0,
            TotalFieldsExpected = 0,
            WithinTolerance = 0,
        };

        Aggregate copied = new(model);

        Assert.Equal(model, copied);
    }
}
