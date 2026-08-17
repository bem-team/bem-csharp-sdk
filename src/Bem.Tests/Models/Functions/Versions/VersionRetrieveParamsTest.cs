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
            IncludeExtraSettings = true,
        };

        string expectedFunctionName = "functionName";
        long expectedVersionNum = 0;
        bool expectedIncludeExtraSettings = true;

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedVersionNum, parameters.VersionNum);
        Assert.Equal(expectedIncludeExtraSettings, parameters.IncludeExtraSettings);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VersionRetrieveParams
        {
            FunctionName = "functionName",
            VersionNum = 0,
        };

        Assert.Null(parameters.IncludeExtraSettings);
        Assert.False(parameters.RawQueryData.ContainsKey("includeExtraSettings"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VersionRetrieveParams
        {
            FunctionName = "functionName",
            VersionNum = 0,

            // Null should be interpreted as omitted for these properties
            IncludeExtraSettings = null,
        };

        Assert.Null(parameters.IncludeExtraSettings);
        Assert.False(parameters.RawQueryData.ContainsKey("includeExtraSettings"));
    }

    [Fact]
    public void Url_Works()
    {
        VersionRetrieveParams parameters = new()
        {
            FunctionName = "functionName",
            VersionNum = 0,
            IncludeExtraSettings = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/functions/functionName/versions/0?includeExtraSettings=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionRetrieveParams
        {
            FunctionName = "functionName",
            VersionNum = 0,
            IncludeExtraSettings = true,
        };

        VersionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
