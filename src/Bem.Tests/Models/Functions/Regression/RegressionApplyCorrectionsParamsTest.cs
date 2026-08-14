using System;
using Bem.Models.Functions.Regression;

namespace Bem.Tests.Models.Functions.Regression;

public class RegressionApplyCorrectionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RegressionApplyCorrectionsParams
        {
            BaselineVersionNum = 3,
            ComparisonVersionNum = 4,
            FunctionName = "invoice-extractor",
        };

        long expectedBaselineVersionNum = 3;
        long expectedComparisonVersionNum = 4;
        string expectedFunctionName = "invoice-extractor";

        Assert.Equal(expectedBaselineVersionNum, parameters.BaselineVersionNum);
        Assert.Equal(expectedComparisonVersionNum, parameters.ComparisonVersionNum);
        Assert.Equal(expectedFunctionName, parameters.FunctionName);
    }

    [Fact]
    public void Url_Works()
    {
        RegressionApplyCorrectionsParams parameters = new()
        {
            BaselineVersionNum = 3,
            ComparisonVersionNum = 4,
            FunctionName = "invoice-extractor",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.bem.ai/v3/functions/regression/corrections"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RegressionApplyCorrectionsParams
        {
            BaselineVersionNum = 3,
            ComparisonVersionNum = 4,
            FunctionName = "invoice-extractor",
        };

        RegressionApplyCorrectionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
