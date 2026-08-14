using System.Threading.Tasks;

namespace Bem.Tests.Services.Eval;

public class ScoreServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var score = await this.client.Eval.Score.Create(
            new() { FunctionName = "functionName" },
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
