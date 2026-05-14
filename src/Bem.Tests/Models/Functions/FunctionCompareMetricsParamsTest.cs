using System;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionCompareMetricsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionCompareMetricsParams
        {
            FunctionName = "invoice-extractor",
            BaselineVersionNum = 2,
            ComparisonVersionNum = 3,
            IsRegression = true,
        };

        string expectedFunctionName = "invoice-extractor";
        long expectedBaselineVersionNum = 2;
        long expectedComparisonVersionNum = 3;
        bool expectedIsRegression = true;

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedBaselineVersionNum, parameters.BaselineVersionNum);
        Assert.Equal(expectedComparisonVersionNum, parameters.ComparisonVersionNum);
        Assert.Equal(expectedIsRegression, parameters.IsRegression);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionCompareMetricsParams { FunctionName = "invoice-extractor" };

        Assert.Null(parameters.BaselineVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("baselineVersionNum"));
        Assert.Null(parameters.ComparisonVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("comparisonVersionNum"));
        Assert.Null(parameters.IsRegression);
        Assert.False(parameters.RawBodyData.ContainsKey("isRegression"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionCompareMetricsParams
        {
            FunctionName = "invoice-extractor",

            // Null should be interpreted as omitted for these properties
            BaselineVersionNum = null,
            ComparisonVersionNum = null,
            IsRegression = null,
        };

        Assert.Null(parameters.BaselineVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("baselineVersionNum"));
        Assert.Null(parameters.ComparisonVersionNum);
        Assert.False(parameters.RawBodyData.ContainsKey("comparisonVersionNum"));
        Assert.Null(parameters.IsRegression);
        Assert.False(parameters.RawBodyData.ContainsKey("isRegression"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionCompareMetricsParams parameters = new() { FunctionName = "invoice-extractor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions/compare"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionCompareMetricsParams
        {
            FunctionName = "invoice-extractor",
            BaselineVersionNum = 2,
            ComparisonVersionNum = 3,
            IsRegression = true,
        };

        FunctionCompareMetricsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
