using System.Threading.Tasks;

namespace Bem.Tests.Services.Eval;

public class ResultServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task FetchResults_Works()
    {
        var evaluationResults = await this.client.Eval.Results.FetchResults(
            new() { TransformationIds = ["tr_01HXAB...", "tr_01HXCD..."] },
            TestContext.Current.CancellationToken
        );
        evaluationResults.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveResults_Works()
    {
        var evaluationResults = await this.client.Eval.Results.RetrieveResults(
            new() { TransformationIds = "transformationIDs" },
            TestContext.Current.CancellationToken
        );
        evaluationResults.Validate();
    }
}
