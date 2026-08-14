using System;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ViewDeleteParams { ViewID = "view_id" };

        string expectedViewID = "view_id";

        Assert.Equal(expectedViewID, parameters.ViewID);
    }

    [Fact]
    public void Url_Works()
    {
        ViewDeleteParams parameters = new() { ViewID = "view_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/views/view_id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ViewDeleteParams { ViewID = "view_id" };

        ViewDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
