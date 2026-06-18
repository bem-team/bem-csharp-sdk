using System.Threading.Tasks;

namespace Bem.Tests.Services.Entities;

public class SynonymServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.Entities.Synonyms.Add(
            "id",
            new() { Text = "ACME Corporation" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Entities.Synonyms.Remove(
            "synonymID",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
