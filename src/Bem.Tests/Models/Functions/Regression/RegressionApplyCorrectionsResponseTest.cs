using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions.Regression;

namespace Bem.Tests.Models.Functions.Regression;

public class RegressionApplyCorrectionsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RegressionApplyCorrectionsResponse
        {
            Applied = 0,
            AppliedEventIds = ["string"],
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Skipped = 0,
        };

        long expectedApplied = 0;
        List<string> expectedAppliedEventIds = ["string"];
        JsonElement expectedErrors = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedSkipped = 0;

        Assert.Equal(expectedApplied, model.Applied);
        Assert.Equal(expectedAppliedEventIds.Count, model.AppliedEventIds.Count);
        for (int i = 0; i < expectedAppliedEventIds.Count; i++)
        {
            Assert.Equal(expectedAppliedEventIds[i], model.AppliedEventIds[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedErrors, model.Errors));
        Assert.Equal(expectedSkipped, model.Skipped);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RegressionApplyCorrectionsResponse
        {
            Applied = 0,
            AppliedEventIds = ["string"],
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Skipped = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegressionApplyCorrectionsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RegressionApplyCorrectionsResponse
        {
            Applied = 0,
            AppliedEventIds = ["string"],
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Skipped = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegressionApplyCorrectionsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedApplied = 0;
        List<string> expectedAppliedEventIds = ["string"];
        JsonElement expectedErrors = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedSkipped = 0;

        Assert.Equal(expectedApplied, deserialized.Applied);
        Assert.Equal(expectedAppliedEventIds.Count, deserialized.AppliedEventIds.Count);
        for (int i = 0; i < expectedAppliedEventIds.Count; i++)
        {
            Assert.Equal(expectedAppliedEventIds[i], deserialized.AppliedEventIds[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedErrors, deserialized.Errors));
        Assert.Equal(expectedSkipped, deserialized.Skipped);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RegressionApplyCorrectionsResponse
        {
            Applied = 0,
            AppliedEventIds = ["string"],
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Skipped = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RegressionApplyCorrectionsResponse
        {
            Applied = 0,
            AppliedEventIds = ["string"],
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
            Skipped = 0,
        };

        RegressionApplyCorrectionsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
