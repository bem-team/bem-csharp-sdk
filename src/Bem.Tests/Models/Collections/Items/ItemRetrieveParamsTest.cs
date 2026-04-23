using System;
using Bem.Models.Collections.Items;

namespace Bem.Tests.Models.Collections.Items;

public class ItemRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            CollectionName = "collectionName",
            IncludeSubcollections = true,
            Limit = 1,
            Page = 1,
        };

        string expectedCollectionName = "collectionName";
        bool expectedIncludeSubcollections = true;
        long expectedLimit = 1;
        long expectedPage = 1;

        Assert.Equal(expectedCollectionName, parameters.CollectionName);
        Assert.Equal(expectedIncludeSubcollections, parameters.IncludeSubcollections);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ItemRetrieveParams { CollectionName = "collectionName" };

        Assert.Null(parameters.IncludeSubcollections);
        Assert.False(parameters.RawQueryData.ContainsKey("includeSubcollections"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            CollectionName = "collectionName",

            // Null should be interpreted as omitted for these properties
            IncludeSubcollections = null,
            Limit = null,
            Page = null,
        };

        Assert.Null(parameters.IncludeSubcollections);
        Assert.False(parameters.RawQueryData.ContainsKey("includeSubcollections"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        ItemRetrieveParams parameters = new()
        {
            CollectionName = "collectionName",
            IncludeSubcollections = true,
            Limit = 1,
            Page = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/collections/items?collectionName=collectionName&includeSubcollections=true&limit=1&page=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            CollectionName = "collectionName",
            IncludeSubcollections = true,
            Limit = 1,
            Page = 1,
        };

        ItemRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
