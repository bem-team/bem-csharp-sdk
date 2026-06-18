using System;
using Bem.Models.Buckets;

namespace Bem.Tests.Models.Buckets;

public class BucketUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BucketUpdateParams
        {
            BucketID = "bucketID",
            Description = "description",
            Name = "name",
        };

        string expectedBucketID = "bucketID";
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedBucketID, parameters.BucketID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BucketUpdateParams { BucketID = "bucketID" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BucketUpdateParams
        {
            BucketID = "bucketID",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Name = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        BucketUpdateParams parameters = new() { BucketID = "bucketID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/buckets/bucketID"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BucketUpdateParams
        {
            BucketID = "bucketID",
            Description = "description",
            Name = "name",
        };

        BucketUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
