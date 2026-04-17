using System.Text.Json;
using System.Threading.Tasks;
using Bem.Models.Workflows;

namespace Bem.Tests.Services;

public class WorkflowServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var workflow = await this.client.Workflows.Create(
            new()
            {
                MainNodeName = "mainNodeName",
                Name = "name",
                Nodes =
                [
                    new()
                    {
                        Function = new()
                        {
                            ID = "id",
                            Name = "name",
                            VersionNum = 0,
                        },
                        Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Name = "name",
                    },
                ],
            },
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
            new()
            {
                Input = new()
                {
                    BatchFiles = new()
                    {
                        Inputs =
                        [
                            new()
                            {
                                InputContent = "inputContent",
                                InputType = InputType.Csv,
                                ItemReferenceID = "itemReferenceID",
                            },
                        ],
                    },
                    SingleFile = new()
                    {
                        InputContent = "inputContent",
                        InputType = SingleFileInputType.Csv,
                    },
                },
            },
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
