using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class WorkflowServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var workflow = await this.client.Workflows.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        workflow.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var workflow = await this.client.Workflows.Retrieve(
            "workflowName",
            new(),
            TestContext.Current.CancellationToken
        );
        workflow.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var workflow = await this.client.Workflows.Update(
            "workflowName",
            new(),
            TestContext.Current.CancellationToken
        );
        workflow.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Workflows.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Workflows.Delete(
            "workflowName",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Call_Works()
    {
        var callGetResponse = await this.client.Workflows.Call(
            "workflowName",
            new(),
            TestContext.Current.CancellationToken
        );
        callGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Copy_Works()
    {
        var response = await this.client.Workflows.Copy(
            new()
            {
                SourceWorkflowName = "sourceWorkflowName",
                TargetWorkflowName = "targetWorkflowName",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
