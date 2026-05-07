using System.Threading.Tasks;
using Bem.Models.Connectors;

namespace Bem.Tests.Services;

public class ConnectorServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var connector = await this.client.Connectors.Create(
            new() { Name = "Box → Invoice workflow", Type = ConnectorType.Paragon },
            TestContext.Current.CancellationToken
        );
        connector.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var connectors = await this.client.Connectors.List(
            new(),
            TestContext.Current.CancellationToken
        );
        connectors.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Connectors.Delete(
            "connectorID",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
