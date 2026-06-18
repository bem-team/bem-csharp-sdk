using System.Threading.Tasks;

namespace Bem.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListReviewerAssignments_Works()
    {
        var response = await this.client.Users.ListReviewerAssignments(
            "userID",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
