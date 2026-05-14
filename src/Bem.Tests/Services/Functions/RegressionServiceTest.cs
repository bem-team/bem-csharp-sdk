using System.Threading.Tasks;

namespace Bem.Tests.Services.Functions;

public class RegressionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ApplyCorrections_Works()
    {
        var response = await this.client.Functions.Regression.ApplyCorrections(
            new()
            {
                BaselineVersionNum = 3,
                ComparisonVersionNum = 4,
                FunctionName = "invoice-extractor",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Functions.Regression.Run(
            new() { FunctionName = "invoice-extractor" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
