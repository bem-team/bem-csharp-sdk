using System;
using Bem.Models.Collections;

namespace Bem.Tests.Models.Collections;

public class CollectionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CollectionDeleteParams { CollectionName = "collectionName" };

        string expectedCollectionName = "collectionName";

        Assert.Equal(expectedCollectionName, parameters.CollectionName);
    }

    [Fact]
    public void Url_Works()
    {
        CollectionDeleteParams parameters = new() { CollectionName = "collectionName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.bem.ai/v3/collections?collectionName=collectionName"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CollectionDeleteParams { CollectionName = "collectionName" };

        CollectionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
