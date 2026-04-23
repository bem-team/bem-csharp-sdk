using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class CallServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var callGetResponse = await this.client.Calls.Retrieve(
            "callID",
            new(),
            TestContext.Current.CancellationToken
        );
        callGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Calls.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveTrace_Works()
    {
        var response = await this.client.Calls.RetrieveTrace(
            "callID",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
