using System.Threading.Tasks;

namespace Bem.Tests.Services.EntityTypes;

public class ReviewerServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var reviewers = await this.client.EntityTypes.Reviewers.List(
            "typeID",
            new(),
            TestContext.Current.CancellationToken
        );
        reviewers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Assign_Works()
    {
        var reviewer = await this.client.EntityTypes.Reviewers.Assign(
            "typeID",
            new() { UserID = "usr_2xyz..." },
            TestContext.Current.CancellationToken
        );
        reviewer.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.EntityTypes.Reviewers.Remove(
            "userID",
            new() { TypeID = "typeID" },
            TestContext.Current.CancellationToken
        );
    }
}
