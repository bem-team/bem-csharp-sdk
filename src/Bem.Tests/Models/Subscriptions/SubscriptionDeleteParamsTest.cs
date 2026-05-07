using System;
using Bem.Models.Subscriptions;

namespace Bem.Tests.Models.Subscriptions;

public class SubscriptionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionDeleteParams { SubscriptionID = "subscriptionID" };

        string expectedSubscriptionID = "subscriptionID";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionDeleteParams parameters = new() { SubscriptionID = "subscriptionID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/subscriptions/subscriptionID"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionDeleteParams { SubscriptionID = "subscriptionID" };

        SubscriptionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
