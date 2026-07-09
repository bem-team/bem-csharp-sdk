using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class MetricsComparisonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetricsComparison
        {
            Accuracy = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            F1Score = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Precision = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Recall = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
        };

        MetricComparison expectedAccuracy = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        MetricComparison expectedF1Score = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        MetricComparison expectedPrecision = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        MetricComparison expectedRecall = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        Assert.Equal(expectedAccuracy, model.Accuracy);
        Assert.Equal(expectedF1Score, model.F1Score);
        Assert.Equal(expectedPrecision, model.Precision);
        Assert.Equal(expectedRecall, model.Recall);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MetricsComparison
        {
            Accuracy = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            F1Score = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Precision = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Recall = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetricsComparison>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MetricsComparison
        {
            Accuracy = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            F1Score = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Precision = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Recall = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetricsComparison>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MetricComparison expectedAccuracy = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        MetricComparison expectedF1Score = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        MetricComparison expectedPrecision = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        MetricComparison expectedRecall = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        Assert.Equal(expectedAccuracy, deserialized.Accuracy);
        Assert.Equal(expectedF1Score, deserialized.F1Score);
        Assert.Equal(expectedPrecision, deserialized.Precision);
        Assert.Equal(expectedRecall, deserialized.Recall);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MetricsComparison
        {
            Accuracy = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            F1Score = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Precision = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Recall = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MetricsComparison { };

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
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MetricsComparison { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MetricsComparison
        {
            // Null should be interpreted as omitted for these properties
            Accuracy = null,
            F1Score = null,
            Precision = null,
            Recall = null,
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
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MetricsComparison
        {
            // Null should be interpreted as omitted for these properties
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
        var model = new MetricsComparison
        {
            Accuracy = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            F1Score = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Precision = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
            Recall = new()
            {
                BaselineValue = 0,
                ComparisonValue = 0,
                Difference = 0,
                LiftPercent = 0,
            },
        };

        MetricsComparison copied = new(model);

        Assert.Equal(model, copied);
    }
}
