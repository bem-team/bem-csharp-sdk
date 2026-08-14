using System;
using Bem.Models.Buckets;

namespace Bem.Tests.Models.Buckets;

public class BucketDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BucketDeleteParams { BucketID = "bucketID", Cascade = true };

        string expectedBucketID = "bucketID";
        bool expectedCascade = true;

        Assert.Equal(expectedBucketID, parameters.BucketID);
        Assert.Equal(expectedCascade, parameters.Cascade);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BucketDeleteParams { BucketID = "bucketID" };

        Assert.Null(parameters.Cascade);
        Assert.False(parameters.RawQueryData.ContainsKey("cascade"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BucketDeleteParams
        {
            BucketID = "bucketID",

            // Null should be interpreted as omitted for these properties
            Cascade = null,
        };

        Assert.Null(parameters.Cascade);
        Assert.False(parameters.RawQueryData.ContainsKey("cascade"));
    }

    [Fact]
    public void Url_Works()
    {
        BucketDeleteParams parameters = new() { BucketID = "bucketID", Cascade = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/buckets/bucketID?cascade=true"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BucketDeleteParams { BucketID = "bucketID", Cascade = true };

        BucketDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
