using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class CollectionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var collection = await this.client.Collections.Create(
            new() { CollectionName = "product_catalog" },
            TestContext.Current.CancellationToken
        );
        collection.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var collections = await this.client.Collections.List(
            new(),
            TestContext.Current.CancellationToken
        );
        collections.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Collections.Delete(
            new() { CollectionName = "collectionName" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CountTokens_Works()
    {
        var response = await this.client.Collections.CountTokens(
            new() { Texts = ["string"] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
