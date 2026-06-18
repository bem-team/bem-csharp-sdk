using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class ReviewQueueServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var reviewQueues = await this.client.ReviewQueue.List(
            new(),
            TestContext.Current.CancellationToken
        );
        reviewQueues.Validate();
    }
}
