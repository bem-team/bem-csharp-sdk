using System.Threading.Tasks;

namespace Bem.Tests.Services.Eval;

public class ResultServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveResults_Works()
    {
        var evaluationResults = await this.client.Eval.Results.RetrieveResults(
            new(),
            TestContext.Current.CancellationToken
        );
        evaluationResults.Validate();
    }
}
