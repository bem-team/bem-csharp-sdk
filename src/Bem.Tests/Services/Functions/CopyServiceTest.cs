using System.Threading.Tasks;

namespace Bem.Tests.Services.Functions;

public class CopyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var functionResponse = await this.client.Functions.Copy.Create(
            new()
            {
                SourceFunctionName = "sourceFunctionName",
                TargetFunctionName = "targetFunctionName",
            },
            TestContext.Current.CancellationToken
        );
        functionResponse.Validate();
    }
}
