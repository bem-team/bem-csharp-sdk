using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Eval.Score;
using Bem.Models.Outputs;

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
                    Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
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
                Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
            },
        ];
        long expectedFunctionVersionNum = 0;
        EvalMatchConfig expectedMatchConfig = new()
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
                    Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
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
                    Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
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
                    Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
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
                    Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
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
            Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
        };

        JsonElement expectedExpected = JsonSerializer.Deserialize<JsonElement>("{}");
        FileInput expectedInput = new()
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
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
            Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
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
            Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pair>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedExpected = JsonSerializer.Deserialize<JsonElement>("{}");
        FileInput expectedInput = new()
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
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
            Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pair
        {
            Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
            Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
        };

        Pair copied = new(model);

        Assert.Equal(model, copied);
    }
}
