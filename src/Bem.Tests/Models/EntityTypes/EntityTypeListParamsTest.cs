using System;
using Bem.Models.EntityTypes;

namespace Bem.Tests.Models.EntityTypes;

public class EntityTypeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityTypeListParams
        {
            EndingBefore = "endingBefore",
            Limit = 0,
            ParentTypeID = "parentTypeId",
            StartingAfter = "startingAfter",
        };

        string expectedEndingBefore = "endingBefore";
        int expectedLimit = 0;
        string expectedParentTypeID = "parentTypeId";
        string expectedStartingAfter = "startingAfter";

        Assert.Equal(expectedEndingBefore, parameters.EndingBefore);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedParentTypeID, parameters.ParentTypeID);
        Assert.Equal(expectedStartingAfter, parameters.StartingAfter);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityTypeListParams { };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ParentTypeID);
        Assert.False(parameters.RawQueryData.ContainsKey("parentTypeId"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityTypeListParams
        {
            // Null should be interpreted as omitted for these properties
            EndingBefore = null,
            Limit = null,
            ParentTypeID = null,
            StartingAfter = null,
        };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ParentTypeID);
        Assert.False(parameters.RawQueryData.ContainsKey("parentTypeId"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityTypeListParams parameters = new()
        {
            EndingBefore = "endingBefore",
            Limit = 0,
            ParentTypeID = "parentTypeId",
            StartingAfter = "startingAfter",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/entity-types?endingBefore=endingBefore&limit=0&parentTypeId=parentTypeId&startingAfter=startingAfter"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityTypeListParams
        {
            EndingBefore = "endingBefore",
            Limit = 0,
            ParentTypeID = "parentTypeId",
            StartingAfter = "startingAfter",
        };

        EntityTypeListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
