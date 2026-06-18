using System;
using Bem.Models.Buckets;

namespace Bem.Tests.Models.Buckets;

public class BucketListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BucketListParams
        {
            EndingBefore = "endingBefore",
            Limit = 0,
            NameSubstring = "nameSubstring",
            StartingAfter = "startingAfter",
        };

        string expectedEndingBefore = "endingBefore";
        int expectedLimit = 0;
        string expectedNameSubstring = "nameSubstring";
        string expectedStartingAfter = "startingAfter";

        Assert.Equal(expectedEndingBefore, parameters.EndingBefore);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedNameSubstring, parameters.NameSubstring);
        Assert.Equal(expectedStartingAfter, parameters.StartingAfter);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BucketListParams { };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.NameSubstring);
        Assert.False(parameters.RawQueryData.ContainsKey("nameSubstring"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BucketListParams
        {
            // Null should be interpreted as omitted for these properties
            EndingBefore = null,
            Limit = null,
            NameSubstring = null,
            StartingAfter = null,
        };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.NameSubstring);
        Assert.False(parameters.RawQueryData.ContainsKey("nameSubstring"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
    }

    [Fact]
    public void Url_Works()
    {
        BucketListParams parameters = new()
        {
            EndingBefore = "endingBefore",
            Limit = 0,
            NameSubstring = "nameSubstring",
            StartingAfter = "startingAfter",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/buckets?endingBefore=endingBefore&limit=0&nameSubstring=nameSubstring&startingAfter=startingAfter"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BucketListParams
        {
            EndingBefore = "endingBefore",
            Limit = 0,
            NameSubstring = "nameSubstring",
            StartingAfter = "startingAfter",
        };

        BucketListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
