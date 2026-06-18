using System;
using Bem.Models.Buckets;

namespace Bem.Tests.Models.Buckets;

public class BucketRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BucketRetrieveParams { BucketID = "bucketID" };

        string expectedBucketID = "bucketID";

        Assert.Equal(expectedBucketID, parameters.BucketID);
    }

    [Fact]
    public void Url_Works()
    {
        BucketRetrieveParams parameters = new() { BucketID = "bucketID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/buckets/bucketID"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BucketRetrieveParams { BucketID = "bucketID" };

        BucketRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
