using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class KnowledgeGraphServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var knowledgeGraph = await this.client.KnowledgeGraph.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        knowledgeGraph.Validate();
    }
}
