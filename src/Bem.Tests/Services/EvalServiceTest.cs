using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class EvalServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TriggerEvaluation_Works()
    {
        var response = await this.client.Eval.TriggerEvaluation(
            new() { TransformationIds = ["tr_01HXAB...", "tr_01HXCD..."] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
