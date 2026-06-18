using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class EntityTypeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var entityType = await this.client.EntityTypes.Create(
            new() { Name = "Drug" },
            TestContext.Current.CancellationToken
        );
        entityType.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var entityType = await this.client.EntityTypes.Retrieve(
            "typeID",
            new(),
            TestContext.Current.CancellationToken
        );
        entityType.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var entityType = await this.client.EntityTypes.Update(
            "typeID",
            new(),
            TestContext.Current.CancellationToken
        );
        entityType.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var entityTypes = await this.client.EntityTypes.List(
            new(),
            TestContext.Current.CancellationToken
        );
        entityTypes.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.EntityTypes.Delete(
            "typeID",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
