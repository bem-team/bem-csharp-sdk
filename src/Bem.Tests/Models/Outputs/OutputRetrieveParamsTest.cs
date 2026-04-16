using System;
using Bem.Models.Outputs;

namespace Bem.Tests.Models.Outputs;

public class OutputRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OutputRetrieveParams { EventID = "eventID" };

        string expectedEventID = "eventID";

        Assert.Equal(expectedEventID, parameters.EventID);
    }

    [Fact]
    public void Url_Works()
    {
        OutputRetrieveParams parameters = new() { EventID = "eventID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/outputs/eventID"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OutputRetrieveParams { EventID = "eventID" };

        OutputRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
