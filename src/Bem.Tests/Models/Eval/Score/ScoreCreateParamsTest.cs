using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Eval.Score;
using Outputs = Bem.Models.Outputs;

namespace Bem.Tests.Models.Eval.Score;

public class ScoreCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ScoreCreateParams
        {
            FunctionName = "functionName",
            Pairs =
            [
                new()
                {
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Input = new()
                    {
                        InputContent = "inputContent",
                        InputType = Outputs::InputType.Csv,
                    },
                },
            ],
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
        };

        string expectedFunctionName = "functionName";
        List<Pair> expectedPairs =
        [
            new()
            {
                Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                Input = new() { InputContent = "inputContent", InputType = Outputs::InputType.Csv },
            },
        ];
        long expectedFunctionVersionNum = 0;
        MatchConfig expectedMatchConfig = new()
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedPairs.Count, parameters.Pairs.Count);
        for (int i = 0; i < expectedPairs.Count; i++)
        {
            Assert.Equal(expectedPairs[i], parameters.Pairs[i]);
        }
        Assert.Equal(expectedFunctionVersionNum, parameters.FunctionVersionNum);
        Assert.Equal(expectedMatchConfig, parameters.MatchConfig);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ScoreCreateParams
        {
            FunctionName = "functionName",
            Pairs =
            [
                new()
                {
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Input = new()
                    {
                        InputContent = "inputContent",
                        InputType = Outputs::InputType.Csv,
                    },
                },
            ],
        };

        Assert.Null(parameters.FunctionVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("functionVersionNum"));
        Assert.Null(parameters.MatchConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("matchConfig"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ScoreCreateParams
        {
            FunctionName = "functionName",
            Pairs =
            [
                new()
                {
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Input = new()
                    {
                        InputContent = "inputContent",
                        InputType = Outputs::InputType.Csv,
                    },
                },
            ],

            // Null should be interpreted as omitted for these properties
            FunctionVersionNum = null,
            MatchConfig = null,
        };

        Assert.Null(parameters.FunctionVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("functionVersionNum"));
        Assert.Null(parameters.MatchConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("matchConfig"));
    }

    [Fact]
    public void Url_Works()
    {
        ScoreCreateParams parameters = new()
        {
            FunctionName = "functionName",
            Pairs =
            [
                new()
                {
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Input = new()
                    {
                        InputContent = "inputContent",
                        InputType = Outputs::InputType.Csv,
                    },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/eval/score"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ScoreCreateParams
        {
            FunctionName = "functionName",
            Pairs =
            [
                new()
                {
                    Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Input = new()
                    {
                        InputContent = "inputContent",
                        InputType = Outputs::InputType.Csv,
                    },
                },
            ],
            FunctionVersionNum = 0,
            MatchConfig = new()
            {
                ArrayMatch = ArrayMatch.ByIndex,
                FuzzyThreshold = 0,
                IgnorePaths = ["string"],
                NumericTolerance = 0,
                StringMatch = StringMatch.Exact,
            },
        };

        ScoreCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PairTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pair
        {
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
            Input = new() { InputContent = "inputContent", InputType = Outputs::InputType.Csv },
        };

        JsonElement expectedExpected = JsonSerializer.Deserialize<JsonElement>("{}");
        Input expectedInput = new()
        {
            InputContent = "inputContent",
            InputType = Outputs::InputType.Csv,
        };

        Assert.True(JsonElement.DeepEquals(expectedExpected, model.Expected));
        Assert.Equal(expectedInput, model.Input);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pair
        {
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
            Input = new() { InputContent = "inputContent", InputType = Outputs::InputType.Csv },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pair>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pair
        {
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
            Input = new() { InputContent = "inputContent", InputType = Outputs::InputType.Csv },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pair>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedExpected = JsonSerializer.Deserialize<JsonElement>("{}");
        Input expectedInput = new()
        {
            InputContent = "inputContent",
            InputType = Outputs::InputType.Csv,
        };

        Assert.True(JsonElement.DeepEquals(expectedExpected, deserialized.Expected));
        Assert.Equal(expectedInput, deserialized.Input);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pair
        {
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
            Input = new() { InputContent = "inputContent", InputType = Outputs::InputType.Csv },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pair
        {
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
            Input = new() { InputContent = "inputContent", InputType = Outputs::InputType.Csv },
        };

        Pair copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Input { InputContent = "inputContent", InputType = Outputs::InputType.Csv };

        string expectedInputContent = "inputContent";
        ApiEnum<string, Outputs::InputType> expectedInputType = Outputs::InputType.Csv;

        Assert.Equal(expectedInputContent, model.InputContent);
        Assert.Equal(expectedInputType, model.InputType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Input { InputContent = "inputContent", InputType = Outputs::InputType.Csv };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Input { InputContent = "inputContent", InputType = Outputs::InputType.Csv };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedInputContent = "inputContent";
        ApiEnum<string, Outputs::InputType> expectedInputType = Outputs::InputType.Csv;

        Assert.Equal(expectedInputContent, deserialized.InputContent);
        Assert.Equal(expectedInputType, deserialized.InputType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Input { InputContent = "inputContent", InputType = Outputs::InputType.Csv };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Input { InputContent = "inputContent", InputType = Outputs::InputType.Csv };

        Input copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MatchConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatchConfig
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        ApiEnum<string, ArrayMatch> expectedArrayMatch = ArrayMatch.ByIndex;
        double expectedFuzzyThreshold = 0;
        List<string> expectedIgnorePaths = ["string"];
        double expectedNumericTolerance = 0;
        ApiEnum<string, StringMatch> expectedStringMatch = StringMatch.Exact;

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
        var model = new MatchConfig
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatchConfig
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ArrayMatch> expectedArrayMatch = ArrayMatch.ByIndex;
        double expectedFuzzyThreshold = 0;
        List<string> expectedIgnorePaths = ["string"];
        double expectedNumericTolerance = 0;
        ApiEnum<string, StringMatch> expectedStringMatch = StringMatch.Exact;

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
        var model = new MatchConfig
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MatchConfig { };

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
        var model = new MatchConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MatchConfig
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
        var model = new MatchConfig
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
        var model = new MatchConfig
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        MatchConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ArrayMatchTest : TestBase
{
    [Theory]
    [InlineData(ArrayMatch.ByIndex)]
    public void Validation_Works(ArrayMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ArrayMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ArrayMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ArrayMatch.ByIndex)]
    public void SerializationRoundtrip_Works(ArrayMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ArrayMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ArrayMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ArrayMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ArrayMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StringMatchTest : TestBase
{
    [Theory]
    [InlineData(StringMatch.Exact)]
    [InlineData(StringMatch.Fuzzy)]
    public void Validation_Works(StringMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StringMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StringMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StringMatch.Exact)]
    [InlineData(StringMatch.Fuzzy)]
    public void SerializationRoundtrip_Works(StringMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StringMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StringMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StringMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StringMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
