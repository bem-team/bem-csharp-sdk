using System;
using Bem.Models.Calls;

namespace Bem.Tests.Models.Calls;

public class CallRetrieveTraceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallRetrieveTraceParams { CallID = "callID" };

        string expectedCallID = "callID";

        Assert.Equal(expectedCallID, parameters.CallID);
    }

    [Fact]
    public void Url_Works()
    {
        CallRetrieveTraceParams parameters = new() { CallID = "callID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/calls/callID/trace"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CallRetrieveTraceParams { CallID = "callID" };

        CallRetrieveTraceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
