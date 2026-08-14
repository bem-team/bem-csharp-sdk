using System;
using System.Collections.Generic;
using Bem.Models.ReviewQueue;

namespace Bem.Tests.Models.ReviewQueue;

public class ReviewQueueListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReviewQueueListParams
        {
            AssignedTo = "assignedTo",
            Bucket = "bucket",
            Cursor = "cursor",
            Limit = 1,
            Since = "since",
            Status = ["string"],
            Type = ["string"],
        };

        string expectedAssignedTo = "assignedTo";
        string expectedBucket = "bucket";
        string expectedCursor = "cursor";
        int expectedLimit = 1;
        string expectedSince = "since";
        List<string> expectedStatus = ["string"];
        List<string> expectedType = ["string"];

        Assert.Equal(expectedAssignedTo, parameters.AssignedTo);
        Assert.Equal(expectedBucket, parameters.Bucket);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSince, parameters.Since);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
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
        var parameters = new ReviewQueueListParams { };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawQueryData.ContainsKey("assignedTo"));
        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Since);
        Assert.False(parameters.RawQueryData.ContainsKey("since"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ReviewQueueListParams
        {
            // Null should be interpreted as omitted for these properties
            AssignedTo = null,
            Bucket = null,
            Cursor = null,
            Limit = null,
            Since = null,
            Status = null,
            Type = null,
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawQueryData.ContainsKey("assignedTo"));
        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Since);
        Assert.False(parameters.RawQueryData.ContainsKey("since"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        ReviewQueueListParams parameters = new()
        {
            AssignedTo = "assignedTo",
            Bucket = "bucket",
            Cursor = "cursor",
            Limit = 1,
            Since = "since",
            Status = ["string"],
            Type = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/review-queue?assignedTo=assignedTo&bucket=bucket&cursor=cursor&limit=1&since=since&status=string&type=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReviewQueueListParams
        {
            AssignedTo = "assignedTo",
            Bucket = "bucket",
            Cursor = "cursor",
            Limit = 1,
            Since = "since",
            Status = ["string"],
            Type = ["string"],
        };

        ReviewQueueListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
