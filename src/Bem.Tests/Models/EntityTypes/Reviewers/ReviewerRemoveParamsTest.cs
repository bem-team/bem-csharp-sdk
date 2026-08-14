using System;
using Bem.Models.EntityTypes.Reviewers;

namespace Bem.Tests.Models.EntityTypes.Reviewers;

public class ReviewerRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReviewerRemoveParams { TypeID = "typeID", UserID = "userID" };

        string expectedTypeID = "typeID";
        string expectedUserID = "userID";

        Assert.Equal(expectedTypeID, parameters.TypeID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        ReviewerRemoveParams parameters = new() { TypeID = "typeID", UserID = "userID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.bem.ai/v3/entity-types/typeID/reviewers/userID"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReviewerRemoveParams { TypeID = "typeID", UserID = "userID" };

        ReviewerRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
