using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class OutputServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var output = await this.client.Outputs.Retrieve(
            "eventID",
            new(),
            TestContext.Current.CancellationToken
        );
        output.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Outputs.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
