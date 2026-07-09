using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Eval.Score;

namespace Bem.Tests.Models.Eval.Score;

public class EvalMatchConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EvalMatchConfig
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
        var model = new EvalMatchConfig
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EvalMatchConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EvalMatchConfig
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EvalMatchConfig>(
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
        var model = new EvalMatchConfig
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
        var model = new EvalMatchConfig { };

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
        var model = new EvalMatchConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EvalMatchConfig
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
        var model = new EvalMatchConfig
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
        var model = new EvalMatchConfig
        {
            ArrayMatch = ArrayMatch.ByIndex,
            FuzzyThreshold = 0,
            IgnorePaths = ["string"],
            NumericTolerance = 0,
            StringMatch = StringMatch.Exact,
        };

        EvalMatchConfig copied = new(model);

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
