using System;
using Bem.Models.EntityTypes.Reviewers;

namespace Bem.Tests.Models.EntityTypes.Reviewers;

public class ReviewerAssignParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReviewerAssignParams { TypeID = "typeID", UserID = "usr_2xyz..." };

        string expectedTypeID = "typeID";
        string expectedUserID = "usr_2xyz...";

        Assert.Equal(expectedTypeID, parameters.TypeID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        ReviewerAssignParams parameters = new() { TypeID = "typeID", UserID = "usr_2xyz..." };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/entity-types/typeID/reviewers"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReviewerAssignParams { TypeID = "typeID", UserID = "usr_2xyz..." };

        ReviewerAssignParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
