using System;
using Bem.Models.Calls;

namespace Bem.Tests.Models.Calls;

public class CallRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallRetrieveParams { CallID = "callID" };

        string expectedCallID = "callID";

        Assert.Equal(expectedCallID, parameters.CallID);
    }

    [Fact]
    public void Url_Works()
    {
        CallRetrieveParams parameters = new() { CallID = "callID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/calls/callID"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CallRetrieveParams { CallID = "callID" };

        CallRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
