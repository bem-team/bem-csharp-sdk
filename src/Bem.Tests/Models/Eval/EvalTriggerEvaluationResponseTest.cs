using System.Text.Json;
using Bem.Core;
using Bem.Models.Eval;

namespace Bem.Tests.Models.Eval;

public class EvalTriggerEvaluationResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EvalTriggerEvaluationResponse
        {
            Queued = 0,
            Skipped = 0,
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        long expectedQueued = 0;
        long expectedSkipped = 0;
        JsonElement expectedErrors = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedQueued, model.Queued);
        Assert.Equal(expectedSkipped, model.Skipped);
        Assert.NotNull(model.Errors);
        Assert.True(JsonElement.DeepEquals(expectedErrors, model.Errors.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EvalTriggerEvaluationResponse
        {
            Queued = 0,
            Skipped = 0,
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EvalTriggerEvaluationResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EvalTriggerEvaluationResponse
        {
            Queued = 0,
            Skipped = 0,
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EvalTriggerEvaluationResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedQueued = 0;
        long expectedSkipped = 0;
        JsonElement expectedErrors = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedQueued, deserialized.Queued);
        Assert.Equal(expectedSkipped, deserialized.Skipped);
        Assert.NotNull(deserialized.Errors);
        Assert.True(JsonElement.DeepEquals(expectedErrors, deserialized.Errors.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EvalTriggerEvaluationResponse
        {
            Queued = 0,
            Skipped = 0,
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EvalTriggerEvaluationResponse { Queued = 0, Skipped = 0 };

        Assert.Null(model.Errors);
        Assert.False(model.RawData.ContainsKey("errors"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EvalTriggerEvaluationResponse { Queued = 0, Skipped = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EvalTriggerEvaluationResponse
        {
            Queued = 0,
            Skipped = 0,

            // Null should be interpreted as omitted for these properties
            Errors = null,
        };

        Assert.Null(model.Errors);
        Assert.False(model.RawData.ContainsKey("errors"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EvalTriggerEvaluationResponse
        {
            Queued = 0,
            Skipped = 0,

            // Null should be interpreted as omitted for these properties
            Errors = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EvalTriggerEvaluationResponse
        {
            Queued = 0,
            Skipped = 0,
            Errors = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        EvalTriggerEvaluationResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
