using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class MetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Fn = 0,
            Fp = 0,
            Precision = 0,
            Recall = 0,
            Tn = 0,
            Tp = 0,
        };

        float expectedAccuracy = 0;
        float expectedF1Score = 0;
        long expectedFn = 0;
        long expectedFp = 0;
        float expectedPrecision = 0;
        float expectedRecall = 0;
        long expectedTn = 0;
        long expectedTp = 0;

        Assert.Equal(expectedAccuracy, model.Accuracy);
        Assert.Equal(expectedF1Score, model.F1Score);
        Assert.Equal(expectedFn, model.Fn);
        Assert.Equal(expectedFp, model.Fp);
        Assert.Equal(expectedPrecision, model.Precision);
        Assert.Equal(expectedRecall, model.Recall);
        Assert.Equal(expectedTn, model.Tn);
        Assert.Equal(expectedTp, model.Tp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Fn = 0,
            Fp = 0,
            Precision = 0,
            Recall = 0,
            Tn = 0,
            Tp = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metrics>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Fn = 0,
            Fp = 0,
            Precision = 0,
            Recall = 0,
            Tn = 0,
            Tp = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        float expectedAccuracy = 0;
        float expectedF1Score = 0;
        long expectedFn = 0;
        long expectedFp = 0;
        float expectedPrecision = 0;
        float expectedRecall = 0;
        long expectedTn = 0;
        long expectedTp = 0;

        Assert.Equal(expectedAccuracy, deserialized.Accuracy);
        Assert.Equal(expectedF1Score, deserialized.F1Score);
        Assert.Equal(expectedFn, deserialized.Fn);
        Assert.Equal(expectedFp, deserialized.Fp);
        Assert.Equal(expectedPrecision, deserialized.Precision);
        Assert.Equal(expectedRecall, deserialized.Recall);
        Assert.Equal(expectedTn, deserialized.Tn);
        Assert.Equal(expectedTp, deserialized.Tp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Fn = 0,
            Fp = 0,
            Precision = 0,
            Recall = 0,
            Tn = 0,
            Tp = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        Assert.Null(model.Fn);
        Assert.False(model.RawData.ContainsKey("fn"));
        Assert.Null(model.Fp);
        Assert.False(model.RawData.ContainsKey("fp"));
        Assert.Null(model.Tn);
        Assert.False(model.RawData.ContainsKey("tn"));
        Assert.Null(model.Tp);
        Assert.False(model.RawData.ContainsKey("tp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,

            // Null should be interpreted as omitted for these properties
            Fn = null,
            Fp = null,
            Tn = null,
            Tp = null,
        };

        Assert.Null(model.Fn);
        Assert.False(model.RawData.ContainsKey("fn"));
        Assert.Null(model.Fp);
        Assert.False(model.RawData.ContainsKey("fp"));
        Assert.Null(model.Tn);
        Assert.False(model.RawData.ContainsKey("tn"));
        Assert.Null(model.Tp);
        Assert.False(model.RawData.ContainsKey("tp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Precision = 0,
            Recall = 0,

            // Null should be interpreted as omitted for these properties
            Fn = null,
            Fp = null,
            Tn = null,
            Tp = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metrics
        {
            Fn = 0,
            Fp = 0,
            Tn = 0,
            Tp = 0,
        };

        Assert.Null(model.Accuracy);
        Assert.False(model.RawData.ContainsKey("accuracy"));
        Assert.Null(model.F1Score);
        Assert.False(model.RawData.ContainsKey("f1Score"));
        Assert.Null(model.Precision);
        Assert.False(model.RawData.ContainsKey("precision"));
        Assert.Null(model.Recall);
        Assert.False(model.RawData.ContainsKey("recall"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metrics
        {
            Fn = 0,
            Fp = 0,
            Tn = 0,
            Tp = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Metrics
        {
            Fn = 0,
            Fp = 0,
            Tn = 0,
            Tp = 0,

            Accuracy = null,
            F1Score = null,
            Precision = null,
            Recall = null,
        };

        Assert.Null(model.Accuracy);
        Assert.True(model.RawData.ContainsKey("accuracy"));
        Assert.Null(model.F1Score);
        Assert.True(model.RawData.ContainsKey("f1Score"));
        Assert.Null(model.Precision);
        Assert.True(model.RawData.ContainsKey("precision"));
        Assert.Null(model.Recall);
        Assert.True(model.RawData.ContainsKey("recall"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metrics
        {
            Fn = 0,
            Fp = 0,
            Tn = 0,
            Tp = 0,

            Accuracy = null,
            F1Score = null,
            Precision = null,
            Recall = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metrics
        {
            Accuracy = 0,
            F1Score = 0,
            Fn = 0,
            Fp = 0,
            Precision = 0,
            Recall = 0,
            Tn = 0,
            Tp = 0,
        };

        Metrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
