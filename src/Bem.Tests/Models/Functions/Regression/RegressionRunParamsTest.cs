using System;
using Bem.Models.Functions.Regression;

namespace Bem.Tests.Models.Functions.Regression;

public class RegressionRunParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RegressionRunParams
        {
            FunctionName = "invoice-extractor",
            BaselineVersionNum = 3,
            ComparisonVersionNum = 5,
            OnlyCorrectedData = true,
            SampleSize = 100,
        };

        string expectedFunctionName = "invoice-extractor";
        long expectedBaselineVersionNum = 3;
        long expectedComparisonVersionNum = 5;
        bool expectedOnlyCorrectedData = true;
        long expectedSampleSize = 100;

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedBaselineVersionNum, parameters.BaselineVersionNum);
        Assert.Equal(expectedComparisonVersionNum, parameters.ComparisonVersionNum);
        Assert.Equal(expectedOnlyCorrectedData, parameters.OnlyCorrectedData);
        Assert.Equal(expectedSampleSize, parameters.SampleSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RegressionRunParams { FunctionName = "invoice-extractor" };

        Assert.Null(parameters.BaselineVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("baselineVersionNum"));
        Assert.Null(parameters.ComparisonVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("comparisonVersionNum"));
        Assert.Null(parameters.OnlyCorrectedData);
        Assert.False(parameters.RawBodyData.ContainsKey("onlyCorrectedData"));
        Assert.Null(parameters.SampleSize);
        Assert.False(parameters.RawBodyData.ContainsKey("sampleSize"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RegressionRunParams
        {
            FunctionName = "invoice-extractor",

            // Null should be interpreted as omitted for these properties
            BaselineVersionNum = null,
            ComparisonVersionNum = null,
            OnlyCorrectedData = null,
            SampleSize = null,
        };

        Assert.Null(parameters.BaselineVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("baselineVersionNum"));
        Assert.Null(parameters.ComparisonVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("comparisonVersionNum"));
        Assert.Null(parameters.OnlyCorrectedData);
        Assert.False(parameters.RawBodyData.ContainsKey("onlyCorrectedData"));
        Assert.Null(parameters.SampleSize);
        Assert.False(parameters.RawBodyData.ContainsKey("sampleSize"));
    }

    [Fact]
    public void Url_Works()
    {
        RegressionRunParams parameters = new() { FunctionName = "invoice-extractor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions/regression"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RegressionRunParams
        {
            FunctionName = "invoice-extractor",
            BaselineVersionNum = 3,
            ComparisonVersionNum = 5,
            OnlyCorrectedData = true,
            SampleSize = 100,
        };

        RegressionRunParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
