using System.Text.Json;
using System.Threading.Tasks;
using Bem.Models.Outputs;

namespace Bem.Tests.Services.Eval;

public class ScoreServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var score = await this.client.Eval.Score.Create(
            new()
            {
                FunctionName = "functionName",
                Pairs =
                [
                    new()
                    {
                        Expected = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Input = new() { InputContent = "inputContent", InputType = InputType.Csv },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        score.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var evalScoreRun = await this.client.Eval.Score.Retrieve(
            "scoreRunID",
            new(),
            TestContext.Current.CancellationToken
        );
        evalScoreRun.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var evalScoreRun = await this.client.Eval.Score.Cancel(
            "scoreRunID",
            new(),
            TestContext.Current.CancellationToken
        );
        evalScoreRun.Validate();
    }
}
