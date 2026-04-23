using System;
using Bem.Models.Collections.Items;

namespace Bem.Tests.Models.Collections.Items;

public class ItemDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemDeleteParams
        {
            CollectionItemID = "collectionItemID",
            CollectionName = "collectionName",
        };

        string expectedCollectionItemID = "collectionItemID";
        string expectedCollectionName = "collectionName";

        Assert.Equal(expectedCollectionItemID, parameters.CollectionItemID);
        Assert.Equal(expectedCollectionName, parameters.CollectionName);
    }

    [Fact]
    public void Url_Works()
    {
        ItemDeleteParams parameters = new()
        {
            CollectionItemID = "collectionItemID",
            CollectionName = "collectionName",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/collections/items?collectionItemID=collectionItemID&collectionName=collectionName"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemDeleteParams
        {
            CollectionItemID = "collectionItemID",
            CollectionName = "collectionName",
        };

        ItemDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
