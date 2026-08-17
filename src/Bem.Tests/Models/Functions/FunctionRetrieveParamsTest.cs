using System;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionRetrieveParams
        {
            FunctionName = "functionName",
            IncludeExtraSettings = true,
        };

        string expectedFunctionName = "functionName";
        bool expectedIncludeExtraSettings = true;

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedIncludeExtraSettings, parameters.IncludeExtraSettings);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionRetrieveParams { FunctionName = "functionName" };

        Assert.Null(parameters.IncludeExtraSettings);
        Assert.False(parameters.RawQueryData.ContainsKey("includeExtraSettings"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionRetrieveParams
        {
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            IncludeExtraSettings = null,
        };

        Assert.Null(parameters.IncludeExtraSettings);
        Assert.False(parameters.RawQueryData.ContainsKey("includeExtraSettings"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionRetrieveParams parameters = new()
        {
            FunctionName = "functionName",
            IncludeExtraSettings = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.bem.ai/v3/functions/functionName?includeExtraSettings=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionRetrieveParams
        {
            FunctionName = "functionName",
            IncludeExtraSettings = true,
        };

        FunctionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
