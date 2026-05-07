using System;
using Bem.Models.Subscriptions;

namespace Bem.Tests.Models.Subscriptions;

public class SubscriptionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionRetrieveParams { SubscriptionID = "subscriptionID" };

        string expectedSubscriptionID = "subscriptionID";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionRetrieveParams parameters = new() { SubscriptionID = "subscriptionID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/subscriptions/subscriptionID"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionRetrieveParams { SubscriptionID = "subscriptionID" };

        SubscriptionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
