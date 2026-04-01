using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class ErrorServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var error = await this.client.Errors.Retrieve(
            "eventID",
            new(),
            TestContext.Current.CancellationToken
        );
        error.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Errors.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
