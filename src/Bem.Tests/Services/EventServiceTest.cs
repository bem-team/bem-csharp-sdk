using System.Text.Json;
using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class EventServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SubmitFeedback_Works()
    {
        var response = await this.client.Events.SubmitFeedback(
            "eventID",
            new() { Correction = JsonSerializer.Deserialize<JsonElement>("{}") },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
