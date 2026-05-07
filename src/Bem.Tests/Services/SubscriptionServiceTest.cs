using System.Threading.Tasks;
using Bem.Models.Subscriptions;

namespace Bem.Tests.Services;

public class SubscriptionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var subscriptionV3 = await this.client.Subscriptions.Create(
            new() { Name = "name", Type = Type.Transform },
            TestContext.Current.CancellationToken
        );
        subscriptionV3.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var subscriptionV3 = await this.client.Subscriptions.Retrieve(
            "subscriptionID",
            new(),
            TestContext.Current.CancellationToken
        );
        subscriptionV3.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var subscriptionV3 = await this.client.Subscriptions.Update(
            "subscriptionID",
            new(),
            TestContext.Current.CancellationToken
        );
        subscriptionV3.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var subscriptionV3s = await this.client.Subscriptions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in subscriptionV3s)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Subscriptions.Delete(
            "subscriptionID",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
