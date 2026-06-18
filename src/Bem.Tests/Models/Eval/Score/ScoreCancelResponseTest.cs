using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Eval.Score;

namespace Bem.Tests.Models.Eval.Score;

public class ScoreCancelResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,
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
        ScoreCancelResponseMatchConfig expectedMatchConfig = new()
        {
            ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
        };
        List<ScoreCancelResponsePerPair> expectedPerPair =
        [
            new()
            {
                PairIndex = 0,
                Status = ScoreCancelResponsePerPairStatus.Pending,
                CallID = "callID",
                ErrorMessage = "errorMessage",
                FieldResults =
                [
                    new()
                    {
                        Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
                        Path = "path",
                        Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Delta = 0,
                        Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                ],
            },
        ];
        ScoreCancelResponseProgress expectedProgress = new()
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };
        string expectedScoreRunID = "scoreRunID";
        ApiEnum<string, ScoreCancelResponseStatus> expectedStatus =
            ScoreCancelResponseStatus.Pending;
        ScoreCancelResponseAggregate expectedAggregate = new()
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
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,
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
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,
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
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        long expectedFunctionVersionNum = 0;
        ScoreCancelResponseMatchConfig expectedMatchConfig = new()
        {
            ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
        };
        List<ScoreCancelResponsePerPair> expectedPerPair =
        [
            new()
            {
                PairIndex = 0,
                Status = ScoreCancelResponsePerPairStatus.Pending,
                CallID = "callID",
                ErrorMessage = "errorMessage",
                FieldResults =
                [
                    new()
                    {
                        Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
                        Path = "path",
                        Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Delta = 0,
                        Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                ],
            },
        ];
        ScoreCancelResponseProgress expectedProgress = new()
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };
        string expectedScoreRunID = "scoreRunID";
        ApiEnum<string, ScoreCancelResponseStatus> expectedStatus =
            ScoreCancelResponseStatus.Pending;
        ScoreCancelResponseAggregate expectedAggregate = new()
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
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,
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
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,
        };

        Assert.Null(model.Aggregate);
        Assert.False(model.RawData.ContainsKey("aggregate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,

            // Null should be interpreted as omitted for these properties
            Aggregate = null,
        };

        Assert.Null(model.Aggregate);
        Assert.False(model.RawData.ContainsKey("aggregate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,

            // Null should be interpreted as omitted for these properties
            Aggregate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ScoreCancelResponse
        {
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
            },
            PerPair =
            [
                new()
                {
                    PairIndex = 0,
                    Status = ScoreCancelResponsePerPairStatus.Pending,
                    CallID = "callID",
                    ErrorMessage = "errorMessage",
                    FieldResults =
                    [
                        new()
                        {
                            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
            Status = ScoreCancelResponseStatus.Pending,
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

        ScoreCancelResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScoreCancelResponseMatchConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScoreCancelResponseMatchConfig
        {
            ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
        };

        ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch> expectedArrayMatch =
            ScoreCancelResponseMatchConfigArrayMatch.ByIndex;
        double expectedFuzzyThreshold = 0;
        List<string> expectedIgnorePaths = ["string"];
        double expectedNumericTolerance = 0;
        ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch> expectedStringMatch =
            ScoreCancelResponseMatchConfigStringMatch.Exact;

        Assert.Equal(expectedArrayMatch, model.ArrayMatch);
        Assert.Equal(expectedFuzzyThreshold, model.FuzzyThreshold);
        Assert.NotNull(model.IgnorePaths);
        Assert.Equal(expectedIgnorePaths.Count, model.IgnorePaths.Count);
        for (int i = 0; i < expectedIgnorePaths.Count; i++)
        {
            Assert.Equal(expectedIgnorePaths[i], model.IgnorePaths[i]);
        }
        Assert.Equal(expectedNumericTolerance, model.NumericTolerance);
        Assert.Equal(expectedStringMatch, model.StringMatch);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ScoreCancelResponseMatchConfig
        {
            ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponseMatchConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScoreCancelResponseMatchConfig
        {
            ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponseMatchConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch> expectedArrayMatch =
            ScoreCancelResponseMatchConfigArrayMatch.ByIndex;
        double expectedFuzzyThreshold = 0;
        List<string> expectedIgnorePaths = ["string"];
        double expectedNumericTolerance = 0;
        ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch> expectedStringMatch =
            ScoreCancelResponseMatchConfigStringMatch.Exact;

        Assert.Equal(expectedArrayMatch, deserialized.ArrayMatch);
        Assert.Equal(expectedFuzzyThreshold, deserialized.FuzzyThreshold);
        Assert.NotNull(deserialized.IgnorePaths);
        Assert.Equal(expectedIgnorePaths.Count, deserialized.IgnorePaths.Count);
        for (int i = 0; i < expectedIgnorePaths.Count; i++)
        {
            Assert.Equal(expectedIgnorePaths[i], deserialized.IgnorePaths[i]);
        }
        Assert.Equal(expectedNumericTolerance, deserialized.NumericTolerance);
        Assert.Equal(expectedStringMatch, deserialized.StringMatch);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ScoreCancelResponseMatchConfig
        {
            ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ScoreCancelResponseMatchConfig { };

        Assert.Null(model.ArrayMatch);
        Assert.False(model.RawData.ContainsKey("arrayMatch"));
        Assert.Null(model.FuzzyThreshold);
        Assert.False(model.RawData.ContainsKey("fuzzyThreshold"));
        Assert.Null(model.IgnorePaths);
        Assert.False(model.RawData.ContainsKey("ignorePaths"));
        Assert.Null(model.NumericTolerance);
        Assert.False(model.RawData.ContainsKey("numericTolerance"));
        Assert.Null(model.StringMatch);
        Assert.False(model.RawData.ContainsKey("stringMatch"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ScoreCancelResponseMatchConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ScoreCancelResponseMatchConfig
        {
            // Null should be interpreted as omitted for these properties
            ArrayMatch = null,
            FuzzyThreshold = null,
            IgnorePaths = null,
            NumericTolerance = null,
            StringMatch = null,
        };

        Assert.Null(model.ArrayMatch);
        Assert.False(model.RawData.ContainsKey("arrayMatch"));
        Assert.Null(model.FuzzyThreshold);
        Assert.False(model.RawData.ContainsKey("fuzzyThreshold"));
        Assert.Null(model.IgnorePaths);
        Assert.False(model.RawData.ContainsKey("ignorePaths"));
        Assert.Null(model.NumericTolerance);
        Assert.False(model.RawData.ContainsKey("numericTolerance"));
        Assert.Null(model.StringMatch);
        Assert.False(model.RawData.ContainsKey("stringMatch"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ScoreCancelResponseMatchConfig
        {
            // Null should be interpreted as omitted for these properties
            ArrayMatch = null,
            FuzzyThreshold = null,
            IgnorePaths = null,
            NumericTolerance = null,
            StringMatch = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ScoreCancelResponseMatchConfig
        {
            ArrayMatch = ScoreCancelResponseMatchConfigArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = ScoreCancelResponseMatchConfigStringMatch.Exact,
        };

        ScoreCancelResponseMatchConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScoreCancelResponseMatchConfigArrayMatchTest : TestBase
{
    [Theory]
    [InlineData(ScoreCancelResponseMatchConfigArrayMatch.ByIndex)]
    public void Validation_Works(ScoreCancelResponseMatchConfigArrayMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScoreCancelResponseMatchConfigArrayMatch.ByIndex)]
    public void SerializationRoundtrip_Works(ScoreCancelResponseMatchConfigArrayMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponseMatchConfigArrayMatch>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ScoreCancelResponseMatchConfigStringMatchTest : TestBase
{
    [Theory]
    [InlineData(ScoreCancelResponseMatchConfigStringMatch.Exact)]
    [InlineData(ScoreCancelResponseMatchConfigStringMatch.Fuzzy)]
    public void Validation_Works(ScoreCancelResponseMatchConfigStringMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScoreCancelResponseMatchConfigStringMatch.Exact)]
    [InlineData(ScoreCancelResponseMatchConfigStringMatch.Fuzzy)]
    public void SerializationRoundtrip_Works(ScoreCancelResponseMatchConfigStringMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponseMatchConfigStringMatch>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ScoreCancelResponsePerPairTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        long expectedPairIndex = 0;
        ApiEnum<string, ScoreCancelResponsePerPairStatus> expectedStatus =
            ScoreCancelResponsePerPairStatus.Pending;
        string expectedCallID = "callID";
        string expectedErrorMessage = "errorMessage";
        List<ScoreCancelResponsePerPairFieldResult> expectedFieldResults =
        [
            new()
            {
                Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponsePerPair>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponsePerPair>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPairIndex = 0;
        ApiEnum<string, ScoreCancelResponsePerPairStatus> expectedStatus =
            ScoreCancelResponsePerPairStatus.Pending;
        string expectedCallID = "callID";
        string expectedErrorMessage = "errorMessage";
        List<ScoreCancelResponsePerPairFieldResult> expectedFieldResults =
        [
            new()
            {
                Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,
        };

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
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,

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
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,

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
        var model = new ScoreCancelResponsePerPair
        {
            PairIndex = 0,
            Status = ScoreCancelResponsePerPairStatus.Pending,
            CallID = "callID",
            ErrorMessage = "errorMessage",
            FieldResults =
            [
                new()
                {
                    Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
                    Path = "path",
                    Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Delta = 0,
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        ScoreCancelResponsePerPair copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScoreCancelResponsePerPairStatusTest : TestBase
{
    [Theory]
    [InlineData(ScoreCancelResponsePerPairStatus.Pending)]
    [InlineData(ScoreCancelResponsePerPairStatus.Running)]
    [InlineData(ScoreCancelResponsePerPairStatus.Completed)]
    [InlineData(ScoreCancelResponsePerPairStatus.Failed)]
    public void Validation_Works(ScoreCancelResponsePerPairStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponsePerPairStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScoreCancelResponsePerPairStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScoreCancelResponsePerPairStatus.Pending)]
    [InlineData(ScoreCancelResponsePerPairStatus.Running)]
    [InlineData(ScoreCancelResponsePerPairStatus.Completed)]
    [InlineData(ScoreCancelResponsePerPairStatus.Failed)]
    public void SerializationRoundtrip_Works(ScoreCancelResponsePerPairStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponsePerPairStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponsePerPairStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScoreCancelResponsePerPairStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponsePerPairStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ScoreCancelResponsePerPairFieldResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch> expectedMatch =
            ScoreCancelResponsePerPairFieldResultMatch.Exact;
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
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponsePerPairFieldResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponsePerPairFieldResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch> expectedMatch =
            ScoreCancelResponsePerPairFieldResultMatch.Exact;
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
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
            Path = "path",
        };

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
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
            Path = "path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
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
        var model = new ScoreCancelResponsePerPairFieldResult
        {
            Match = ScoreCancelResponsePerPairFieldResultMatch.Exact,
            Path = "path",
            Actual = JsonSerializer.Deserialize<JsonElement>("{}"),
            Delta = 0,
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ScoreCancelResponsePerPairFieldResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScoreCancelResponsePerPairFieldResultMatchTest : TestBase
{
    [Theory]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.Exact)]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.WithinTolerance)]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.FuzzyMatch)]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.Miss)]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.Extra)]
    public void Validation_Works(ScoreCancelResponsePerPairFieldResultMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.Exact)]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.WithinTolerance)]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.FuzzyMatch)]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.Miss)]
    [InlineData(ScoreCancelResponsePerPairFieldResultMatch.Extra)]
    public void SerializationRoundtrip_Works(ScoreCancelResponsePerPairFieldResultMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScoreCancelResponsePerPairFieldResultMatch>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ScoreCancelResponseProgressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScoreCancelResponseProgress
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
        var model = new ScoreCancelResponseProgress
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponseProgress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScoreCancelResponseProgress
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponseProgress>(
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
        var model = new ScoreCancelResponseProgress
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
        var model = new ScoreCancelResponseProgress
        {
            Completed = 0,
            Failed = 0,
            Total = 0,
        };

        ScoreCancelResponseProgress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScoreCancelResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(ScoreCancelResponseStatus.Pending)]
    [InlineData(ScoreCancelResponseStatus.Initializing)]
    [InlineData(ScoreCancelResponseStatus.Running)]
    [InlineData(ScoreCancelResponseStatus.Completed)]
    [InlineData(ScoreCancelResponseStatus.Error)]
    [InlineData(ScoreCancelResponseStatus.Cancelled)]
    public void Validation_Works(ScoreCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScoreCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScoreCancelResponseStatus.Pending)]
    [InlineData(ScoreCancelResponseStatus.Initializing)]
    [InlineData(ScoreCancelResponseStatus.Running)]
    [InlineData(ScoreCancelResponseStatus.Completed)]
    [InlineData(ScoreCancelResponseStatus.Error)]
    [InlineData(ScoreCancelResponseStatus.Cancelled)]
    public void SerializationRoundtrip_Works(ScoreCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScoreCancelResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScoreCancelResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScoreCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScoreCancelResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ScoreCancelResponseAggregateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScoreCancelResponseAggregate
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
        var model = new ScoreCancelResponseAggregate
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
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponseAggregate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScoreCancelResponseAggregate
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
        var deserialized = JsonSerializer.Deserialize<ScoreCancelResponseAggregate>(
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
        var model = new ScoreCancelResponseAggregate
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
        var model = new ScoreCancelResponseAggregate
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

        ScoreCancelResponseAggregate copied = new(model);

        Assert.Equal(model, copied);
    }
}
