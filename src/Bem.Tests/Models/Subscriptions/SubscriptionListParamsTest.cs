using System;
using System.Collections.Generic;
using Bem.Models.Subscriptions;

namespace Bem.Tests.Models.Subscriptions;

public class SubscriptionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionListParams
        {
            EndingBefore = "endingBefore",
            FunctionNames = ["string"],
            Limit = 1,
            StartingAfter = "startingAfter",
        };

        string expectedEndingBefore = "endingBefore";
        List<string> expectedFunctionNames = ["string"];
        long expectedLimit = 1;
        string expectedStartingAfter = "startingAfter";

        Assert.Equal(expectedEndingBefore, parameters.EndingBefore);
        Assert.NotNull(parameters.FunctionNames);
        Assert.Equal(expectedFunctionNames.Count, parameters.FunctionNames.Count);
        for (int i = 0; i < expectedFunctionNames.Count; i++)
        {
            Assert.Equal(expectedFunctionNames[i], parameters.FunctionNames[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStartingAfter, parameters.StartingAfter);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams { };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.FunctionNames);
        Assert.False(parameters.RawQueryData.ContainsKey("functionNames"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams
        {
            // Null should be interpreted as omitted for these properties
            EndingBefore = null,
            FunctionNames = null,
            Limit = null,
            StartingAfter = null,
        };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.FunctionNames);
        Assert.False(parameters.RawQueryData.ContainsKey("functionNames"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionListParams parameters = new()
        {
            EndingBefore = "endingBefore",
            FunctionNames = ["string"],
            Limit = 1,
            StartingAfter = "startingAfter",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/subscriptions?endingBefore=endingBefore&functionNames=string&limit=1&startingAfter=startingAfter"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionListParams
        {
            EndingBefore = "endingBefore",
            FunctionNames = ["string"],
            Limit = 1,
            StartingAfter = "startingAfter",
        };

        SubscriptionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
