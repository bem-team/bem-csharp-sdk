using System.Text.Json;
using System.Threading.Tasks;
using Bem.Models.Functions;

namespace Bem.Tests.Services;

public class FunctionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var functionResponse = await this.client.Functions.Create(
            new()
            {
                Body = new Extract()
                {
                    FunctionName = "functionName",
                    DisplayName = "displayName",
                    OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OutputSchemaName = "outputSchemaName",
                    TabularChunkingEnabled = true,
                    Tags = ["string"],
                },
            },
            TestContext.Current.CancellationToken
        );
        functionResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var functionResponse = await this.client.Functions.Retrieve(
            "functionName",
            new(),
            TestContext.Current.CancellationToken
        );
        functionResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var functionResponse = await this.client.Functions.Update(
            "functionName",
            new()
            {
                Body = new FunctionUpdateParamsBodyExtract()
                {
                    DisplayName = "displayName",
                    FunctionName = "functionName",
                    OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OutputSchemaName = "outputSchemaName",
                    TabularChunkingEnabled = true,
                    Tags = ["string"],
                },
            },
            TestContext.Current.CancellationToken
        );
        functionResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Functions.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Functions.Delete(
            "functionName",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
