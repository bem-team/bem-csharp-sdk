using System.Threading.Tasks;

namespace Bem.Tests.Services.Workflows;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var version = await this.client.Workflows.Versions.Retrieve(
            0,
            new() { WorkflowName = "workflowName" },
            TestContext.Current.CancellationToken
        );
        version.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Workflows.Versions.List(
            "workflowName",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
