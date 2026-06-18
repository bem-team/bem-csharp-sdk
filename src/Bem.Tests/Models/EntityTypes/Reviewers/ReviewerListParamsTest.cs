using System;
using Bem.Models.EntityTypes.Reviewers;

namespace Bem.Tests.Models.EntityTypes.Reviewers;

public class ReviewerListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReviewerListParams { TypeID = "typeID" };

        string expectedTypeID = "typeID";

        Assert.Equal(expectedTypeID, parameters.TypeID);
    }

    [Fact]
    public void Url_Works()
    {
        ReviewerListParams parameters = new() { TypeID = "typeID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/entity-types/typeID/reviewers"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReviewerListParams { TypeID = "typeID" };

        ReviewerListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
