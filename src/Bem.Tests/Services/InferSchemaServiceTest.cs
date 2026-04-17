using System.Text.Json;
using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class InferSchemaServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var inferSchema = await this.client.InferSchema.Create(
            new() { File = JsonSerializer.Deserialize<JsonElement>("{}") },
            TestContext.Current.CancellationToken
        );
        inferSchema.Validate();
    }
}
