using System;
using Bem.Models.Users;

namespace Bem.Tests.Models.Users;

public class UserListReviewerAssignmentsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserListReviewerAssignmentsParams { UserID = "userID" };

        string expectedUserID = "userID";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        UserListReviewerAssignmentsParams parameters = new() { UserID = "userID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.bem.ai/v3/users/userID/reviewer-assignments"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserListReviewerAssignmentsParams { UserID = "userID" };

        UserListReviewerAssignmentsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
