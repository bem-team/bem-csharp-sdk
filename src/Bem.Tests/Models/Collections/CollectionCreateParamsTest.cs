using System;
using Bem.Models.Collections;

namespace Bem.Tests.Models.Collections;

public class CollectionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CollectionCreateParams { CollectionName = "product_catalog" };

        string expectedCollectionName = "product_catalog";

        Assert.Equal(expectedCollectionName, parameters.CollectionName);
    }

    [Fact]
    public void Url_Works()
    {
        CollectionCreateParams parameters = new() { CollectionName = "product_catalog" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/collections"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CollectionCreateParams { CollectionName = "product_catalog" };

        CollectionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
