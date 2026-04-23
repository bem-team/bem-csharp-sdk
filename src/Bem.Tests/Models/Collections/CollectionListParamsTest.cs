using System;
using Bem.Models.Collections;

namespace Bem.Tests.Models.Collections;

public class CollectionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CollectionListParams
        {
            CollectionNameSearch = "collectionNameSearch",
            Limit = 1,
            Page = 1,
            ParentCollectionName = "parentCollectionName",
        };

        string expectedCollectionNameSearch = "collectionNameSearch";
        long expectedLimit = 1;
        long expectedPage = 1;
        string expectedParentCollectionName = "parentCollectionName";

        Assert.Equal(expectedCollectionNameSearch, parameters.CollectionNameSearch);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedParentCollectionName, parameters.ParentCollectionName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CollectionListParams { };

        Assert.Null(parameters.CollectionNameSearch);
        Assert.False(parameters.RawQueryData.ContainsKey("collectionNameSearch"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.ParentCollectionName);
        Assert.False(parameters.RawQueryData.ContainsKey("parentCollectionName"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CollectionListParams
        {
            // Null should be interpreted as omitted for these properties
            CollectionNameSearch = null,
            Limit = null,
            Page = null,
            ParentCollectionName = null,
        };

        Assert.Null(parameters.CollectionNameSearch);
        Assert.False(parameters.RawQueryData.ContainsKey("collectionNameSearch"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.ParentCollectionName);
        Assert.False(parameters.RawQueryData.ContainsKey("parentCollectionName"));
    }

    [Fact]
    public void Url_Works()
    {
        CollectionListParams parameters = new()
        {
            CollectionNameSearch = "collectionNameSearch",
            Limit = 1,
            Page = 1,
            ParentCollectionName = "parentCollectionName",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/collections?collectionNameSearch=collectionNameSearch&limit=1&page=1&parentCollectionName=parentCollectionName"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CollectionListParams
        {
            CollectionNameSearch = "collectionNameSearch",
            Limit = 1,
            Page = 1,
            ParentCollectionName = "parentCollectionName",
        };

        CollectionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
