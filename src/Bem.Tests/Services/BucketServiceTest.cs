using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class BucketServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var bucketV3 = await this.client.Buckets.Create(
            new() { Name = "invoices" },
            TestContext.Current.CancellationToken
        );
        bucketV3.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var bucketV3 = await this.client.Buckets.Retrieve(
            "bucketID",
            new(),
            TestContext.Current.CancellationToken
        );
        bucketV3.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var bucketV3 = await this.client.Buckets.Update(
            "bucketID",
            new(),
            TestContext.Current.CancellationToken
        );
        bucketV3.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Buckets.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Buckets.Delete("bucketID", new(), TestContext.Current.CancellationToken);
    }
}
