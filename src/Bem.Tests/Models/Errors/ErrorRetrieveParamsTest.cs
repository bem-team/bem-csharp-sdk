using System;
using Bem.Models.Errors;

namespace Bem.Tests.Models.Errors;

public class ErrorRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ErrorRetrieveParams { EventID = "eventID" };

        string expectedEventID = "eventID";

        Assert.Equal(expectedEventID, parameters.EventID);
    }

    [Fact]
    public void Url_Works()
    {
        ErrorRetrieveParams parameters = new() { EventID = "eventID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/errors/eventID"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ErrorRetrieveParams { EventID = "eventID" };

        ErrorRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
