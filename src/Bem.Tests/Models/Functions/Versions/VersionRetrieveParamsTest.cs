using System;
using Bem.Models.Functions.Versions;

namespace Bem.Tests.Models.Functions.Versions;

public class VersionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionRetrieveParams
        {
            FunctionName = "functionName",
            VersionNum = 0,
        };

        string expectedFunctionName = "functionName";
        long expectedVersionNum = 0;

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedVersionNum, parameters.VersionNum);
    }

    [Fact]
    public void Url_Works()
    {
        VersionRetrieveParams parameters = new() { FunctionName = "functionName", VersionNum = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/functions/functionName/versions/0"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionRetrieveParams
        {
            FunctionName = "functionName",
            VersionNum = 0,
        };

        VersionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
