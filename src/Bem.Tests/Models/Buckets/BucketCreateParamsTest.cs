using System;
using Bem.Models.Buckets;

namespace Bem.Tests.Models.Buckets;

public class BucketCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BucketCreateParams
        {
            Name = "invoices",
            Description = "Knowledge graph for invoice documents",
        };

        string expectedName = "invoices";
        string expectedDescription = "Knowledge graph for invoice documents";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BucketCreateParams { Name = "invoices" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BucketCreateParams
        {
            Name = "invoices",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        BucketCreateParams parameters = new() { Name = "invoices" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/buckets"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BucketCreateParams
        {
            Name = "invoices",
            Description = "Knowledge graph for invoice documents",
        };

        BucketCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
