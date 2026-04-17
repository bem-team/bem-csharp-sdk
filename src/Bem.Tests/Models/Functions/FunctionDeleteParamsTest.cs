using System;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionDeleteParams { FunctionName = "functionName" };

        string expectedFunctionName = "functionName";

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionDeleteParams parameters = new() { FunctionName = "functionName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions/functionName"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionDeleteParams { FunctionName = "functionName" };

        FunctionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
