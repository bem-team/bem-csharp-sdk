using System;
using Bem.Models.Functions.Versions;

namespace Bem.Tests.Models.Functions.Versions;

public class VersionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionListParams { FunctionName = "functionName" };

        string expectedFunctionName = "functionName";

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
    }

    [Fact]
    public void Url_Works()
    {
        VersionListParams parameters = new() { FunctionName = "functionName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/functions/functionName/versions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionListParams { FunctionName = "functionName" };

        VersionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
