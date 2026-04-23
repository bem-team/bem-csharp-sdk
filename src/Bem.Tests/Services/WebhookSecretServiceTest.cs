using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class WebhookSecretServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var webhookSecret = await this.client.WebhookSecret.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        webhookSecret.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var webhookSecret = await this.client.WebhookSecret.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        webhookSecret.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Revoke_Works()
    {
        await this.client.WebhookSecret.Revoke(new(), TestContext.Current.CancellationToken);
    }
}
