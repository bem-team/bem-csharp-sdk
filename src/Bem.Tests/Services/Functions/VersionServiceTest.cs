using System.Threading.Tasks;

namespace Bem.Tests.Services.Functions;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var version = await this.client.Functions.Versions.Retrieve(
            0,
            new() { FunctionName = "functionName" },
            TestContext.Current.CancellationToken
        );
        version.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var listFunctionVersionsResponse = await this.client.Functions.Versions.List(
            "functionName",
            new(),
            TestContext.Current.CancellationToken
        );
        listFunctionVersionsResponse.Validate();
    }
}
