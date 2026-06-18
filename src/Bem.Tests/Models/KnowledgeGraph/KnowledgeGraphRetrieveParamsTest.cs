using System;
using System.Collections.Generic;
using Bem.Models.KnowledgeGraph;

namespace Bem.Tests.Models.KnowledgeGraph;

public class KnowledgeGraphRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KnowledgeGraphRetrieveParams
        {
            Bucket = "bucket",
            Cursor = "cursor",
            Limit = 0,
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = ["string"],
        };

        string expectedBucket = "bucket";
        string expectedCursor = "cursor";
        int expectedLimit = 0;
        string expectedSearch = "search";
        DateTimeOffset expectedSince = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedType = ["string"];

        Assert.Equal(expectedBucket, parameters.Bucket);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedSince, parameters.Since);
        Assert.NotNull(parameters.Type);
        Assert.Equal(expectedType.Count, parameters.Type.Count);
        for (int i = 0; i < expectedType.Count; i++)
        {
            Assert.Equal(expectedType[i], parameters.Type[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new KnowledgeGraphRetrieveParams { };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Since);
        Assert.False(parameters.RawQueryData.ContainsKey("since"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new KnowledgeGraphRetrieveParams
        {
            // Null should be interpreted as omitted for these properties
            Bucket = null,
            Cursor = null,
            Limit = null,
            Search = null,
            Since = null,
            Type = null,
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Since);
        Assert.False(parameters.RawQueryData.ContainsKey("since"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        KnowledgeGraphRetrieveParams parameters = new()
        {
            Bucket = "bucket",
            Cursor = "cursor",
            Limit = 0,
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Type = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/knowledge-graph?bucket=bucket&cursor=cursor&limit=0&search=search&since=2019-12-27T18%3a11%3a19.117%2b00%3a00&type=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new KnowledgeGraphRetrieveParams
        {
            Bucket = "bucket",
            Cursor = "cursor",
            Limit = 0,
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = ["string"],
        };

        KnowledgeGraphRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
