using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionEstimateReviewRequirementsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionEstimateReviewRequirementsParams
        {
            FunctionName = "invoice-extractor",
            ConfidenceLevels = [0],
            ConfidenceMethod = ConfidenceMethod.Wald,
            EvaluationVersion = EvaluationVersion.V0_1_0Gemini,
            FunctionVersionNum = 2,
            IsRegression = true,
            MarginOfError = 0.05f,
            ThresholdMax = 0,
            ThresholdMin = 0,
            ThresholdStep = 0.001f,
        };

        string expectedFunctionName = "invoice-extractor";
        List<long> expectedConfidenceLevels = [0];
        ApiEnum<string, ConfidenceMethod> expectedConfidenceMethod = ConfidenceMethod.Wald;
        ApiEnum<string, EvaluationVersion> expectedEvaluationVersion =
            EvaluationVersion.V0_1_0Gemini;
        long expectedFunctionVersionNum = 2;
        bool expectedIsRegression = true;
        float expectedMarginOfError = 0.05f;
        float expectedThresholdMax = 0;
        float expectedThresholdMin = 0;
        float expectedThresholdStep = 0.001f;

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.NotNull(parameters.ConfidenceLevels);
        Assert.Equal(expectedConfidenceLevels.Count, parameters.ConfidenceLevels.Count);
        for (int i = 0; i < expectedConfidenceLevels.Count; i++)
        {
            Assert.Equal(expectedConfidenceLevels[i], parameters.ConfidenceLevels[i]);
        }
        Assert.Equal(expectedConfidenceMethod, parameters.ConfidenceMethod);
        Assert.Equal(expectedEvaluationVersion, parameters.EvaluationVersion);
        Assert.Equal(expectedFunctionVersionNum, parameters.FunctionVersionNum);
        Assert.Equal(expectedIsRegression, parameters.IsRegression);
        Assert.Equal(expectedMarginOfError, parameters.MarginOfError);
        Assert.Equal(expectedThresholdMax, parameters.ThresholdMax);
        Assert.Equal(expectedThresholdMin, parameters.ThresholdMin);
        Assert.Equal(expectedThresholdStep, parameters.ThresholdStep);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionEstimateReviewRequirementsParams
        {
            FunctionName = "invoice-extractor",
        };

        Assert.Null(parameters.ConfidenceLevels);
        Assert.False(parameters.RawBodyData.ContainsKey("confidenceLevels"));
        Assert.Null(parameters.ConfidenceMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("confidenceMethod"));
        Assert.Null(parameters.EvaluationVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("evaluationVersion"));
        Assert.Null(parameters.FunctionVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("functionVersionNum"));
        Assert.Null(parameters.IsRegression);
        Assert.False(parameters.RawBodyData.ContainsKey("isRegression"));
        Assert.Null(parameters.MarginOfError);
        Assert.False(parameters.RawBodyData.ContainsKey("marginOfError"));
        Assert.Null(parameters.ThresholdMax);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholdMax"));
        Assert.Null(parameters.ThresholdMin);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholdMin"));
        Assert.Null(parameters.ThresholdStep);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholdStep"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionEstimateReviewRequirementsParams
        {
            FunctionName = "invoice-extractor",

            // Null should be interpreted as omitted for these properties
            ConfidenceLevels = null,
            ConfidenceMethod = null,
            EvaluationVersion = null,
            FunctionVersionNum = null,
            IsRegression = null,
            MarginOfError = null,
            ThresholdMax = null,
            ThresholdMin = null,
            ThresholdStep = null,
        };

        Assert.Null(parameters.ConfidenceLevels);
        Assert.False(parameters.RawBodyData.ContainsKey("confidenceLevels"));
        Assert.Null(parameters.ConfidenceMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("confidenceMethod"));
        Assert.Null(parameters.EvaluationVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("evaluationVersion"));
        Assert.Null(parameters.FunctionVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("functionVersionNum"));
        Assert.Null(parameters.IsRegression);
        Assert.False(parameters.RawBodyData.ContainsKey("isRegression"));
        Assert.Null(parameters.MarginOfError);
        Assert.False(parameters.RawBodyData.ContainsKey("marginOfError"));
        Assert.Null(parameters.ThresholdMax);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholdMax"));
        Assert.Null(parameters.ThresholdMin);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholdMin"));
        Assert.Null(parameters.ThresholdStep);
        Assert.False(parameters.RawBodyData.ContainsKey("thresholdStep"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionEstimateReviewRequirementsParams parameters = new()
        {
            FunctionName = "invoice-extractor",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions/review"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionEstimateReviewRequirementsParams
        {
            FunctionName = "invoice-extractor",
            ConfidenceLevels = [0],
            ConfidenceMethod = ConfidenceMethod.Wald,
            EvaluationVersion = EvaluationVersion.V0_1_0Gemini,
            FunctionVersionNum = 2,
            IsRegression = true,
            MarginOfError = 0.05f,
            ThresholdMax = 0,
            ThresholdMin = 0,
            ThresholdStep = 0.001f,
        };

        FunctionEstimateReviewRequirementsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConfidenceMethodTest : TestBase
{
    [Theory]
    [InlineData(ConfidenceMethod.Wald)]
    [InlineData(ConfidenceMethod.Wilson)]
    public void Validation_Works(ConfidenceMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConfidenceMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConfidenceMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConfidenceMethod.Wald)]
    [InlineData(ConfidenceMethod.Wilson)]
    public void SerializationRoundtrip_Works(ConfidenceMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConfidenceMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConfidenceMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConfidenceMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConfidenceMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EvaluationVersionTest : TestBase
{
    [Theory]
    [InlineData(EvaluationVersion.V0_1_0Gemini)]
    public void Validation_Works(EvaluationVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EvaluationVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EvaluationVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EvaluationVersion.V0_1_0Gemini)]
    public void SerializationRoundtrip_Works(EvaluationVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EvaluationVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EvaluationVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EvaluationVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EvaluationVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
