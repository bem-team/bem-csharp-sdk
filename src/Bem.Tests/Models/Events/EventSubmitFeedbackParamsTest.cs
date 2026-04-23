using System;
using System.Text.Json;
using Bem.Models.Events;

namespace Bem.Tests.Models.Events;

public class EventSubmitFeedbackParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventSubmitFeedbackParams
        {
            EventID = "eventID",
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
            OrderMatching = true,
        };

        string expectedEventID = "eventID";
        JsonElement expectedCorrection = JsonSerializer.Deserialize<JsonElement>("{}");
        bool expectedOrderMatching = true;

        Assert.Equal(expectedEventID, parameters.EventID);
        Assert.True(JsonElement.DeepEquals(expectedCorrection, parameters.Correction));
        Assert.Equal(expectedOrderMatching, parameters.OrderMatching);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventSubmitFeedbackParams
        {
            EventID = "eventID",
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(parameters.OrderMatching);
        Assert.False(parameters.RawBodyData.ContainsKey("orderMatching"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventSubmitFeedbackParams
        {
            EventID = "eventID",
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            OrderMatching = null,
        };

        Assert.Null(parameters.OrderMatching);
        Assert.False(parameters.RawBodyData.ContainsKey("orderMatching"));
    }

    [Fact]
    public void Url_Works()
    {
        EventSubmitFeedbackParams parameters = new()
        {
            EventID = "eventID",
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/events/eventID/feedback"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventSubmitFeedbackParams
        {
            EventID = "eventID",
            Correction = JsonSerializer.Deserialize<JsonElement>("{}"),
            OrderMatching = true,
        };

        EventSubmitFeedbackParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
