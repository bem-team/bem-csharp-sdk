using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class MetricsDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetricsDetails
        {
            AggregateMetrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
            FieldMetrics =
            [
                new()
                {
                    FieldPath = "fieldPath",
                    Metrics = new()
                    {
                        Accuracy = 0,
                        F1Score = 0,
                        Fn = 0,
                        Fp = 0,
                        Precision = 0,
                        Recall = 0,
                        Tn = 0,
                        Tp = 0,
                    },
                },
            ],
            PrecisionRecallAuc = 0,
        };

        Metrics expectedAggregateMetrics = new()
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
        List<FieldMetric> expectedFieldMetrics =
        [
            new()
            {
                FieldPath = "fieldPath",
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Fn = 0,
                    Fp = 0,
                    Precision = 0,
                    Recall = 0,
                    Tn = 0,
                    Tp = 0,
                },
            },
        ];
        float expectedPrecisionRecallAuc = 0;

        Assert.Equal(expectedAggregateMetrics, model.AggregateMetrics);
        Assert.NotNull(model.FieldMetrics);
        Assert.Equal(expectedFieldMetrics.Count, model.FieldMetrics.Count);
        for (int i = 0; i < expectedFieldMetrics.Count; i++)
        {
            Assert.Equal(expectedFieldMetrics[i], model.FieldMetrics[i]);
        }
        Assert.Equal(expectedPrecisionRecallAuc, model.PrecisionRecallAuc);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MetricsDetails
        {
            AggregateMetrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
            FieldMetrics =
            [
                new()
                {
                    FieldPath = "fieldPath",
                    Metrics = new()
                    {
                        Accuracy = 0,
                        F1Score = 0,
                        Fn = 0,
                        Fp = 0,
                        Precision = 0,
                        Recall = 0,
                        Tn = 0,
                        Tp = 0,
                    },
                },
            ],
            PrecisionRecallAuc = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetricsDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MetricsDetails
        {
            AggregateMetrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
            FieldMetrics =
            [
                new()
                {
                    FieldPath = "fieldPath",
                    Metrics = new()
                    {
                        Accuracy = 0,
                        F1Score = 0,
                        Fn = 0,
                        Fp = 0,
                        Precision = 0,
                        Recall = 0,
                        Tn = 0,
                        Tp = 0,
                    },
                },
            ],
            PrecisionRecallAuc = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetricsDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Metrics expectedAggregateMetrics = new()
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
        List<FieldMetric> expectedFieldMetrics =
        [
            new()
            {
                FieldPath = "fieldPath",
                Metrics = new()
                {
                    Accuracy = 0,
                    F1Score = 0,
                    Fn = 0,
                    Fp = 0,
                    Precision = 0,
                    Recall = 0,
                    Tn = 0,
                    Tp = 0,
                },
            },
        ];
        float expectedPrecisionRecallAuc = 0;

        Assert.Equal(expectedAggregateMetrics, deserialized.AggregateMetrics);
        Assert.NotNull(deserialized.FieldMetrics);
        Assert.Equal(expectedFieldMetrics.Count, deserialized.FieldMetrics.Count);
        for (int i = 0; i < expectedFieldMetrics.Count; i++)
        {
            Assert.Equal(expectedFieldMetrics[i], deserialized.FieldMetrics[i]);
        }
        Assert.Equal(expectedPrecisionRecallAuc, deserialized.PrecisionRecallAuc);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MetricsDetails
        {
            AggregateMetrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
            FieldMetrics =
            [
                new()
                {
                    FieldPath = "fieldPath",
                    Metrics = new()
                    {
                        Accuracy = 0,
                        F1Score = 0,
                        Fn = 0,
                        Fp = 0,
                        Precision = 0,
                        Recall = 0,
                        Tn = 0,
                        Tp = 0,
                    },
                },
            ],
            PrecisionRecallAuc = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MetricsDetails { };

        Assert.Null(model.AggregateMetrics);
        Assert.False(model.RawData.ContainsKey("aggregateMetrics"));
        Assert.Null(model.FieldMetrics);
        Assert.False(model.RawData.ContainsKey("fieldMetrics"));
        Assert.Null(model.PrecisionRecallAuc);
        Assert.False(model.RawData.ContainsKey("precisionRecallAuc"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MetricsDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MetricsDetails
        {
            // Null should be interpreted as omitted for these properties
            AggregateMetrics = null,
            FieldMetrics = null,
            PrecisionRecallAuc = null,
        };

        Assert.Null(model.AggregateMetrics);
        Assert.False(model.RawData.ContainsKey("aggregateMetrics"));
        Assert.Null(model.FieldMetrics);
        Assert.False(model.RawData.ContainsKey("fieldMetrics"));
        Assert.Null(model.PrecisionRecallAuc);
        Assert.False(model.RawData.ContainsKey("precisionRecallAuc"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MetricsDetails
        {
            // Null should be interpreted as omitted for these properties
            AggregateMetrics = null,
            FieldMetrics = null,
            PrecisionRecallAuc = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MetricsDetails
        {
            AggregateMetrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
            FieldMetrics =
            [
                new()
                {
                    FieldPath = "fieldPath",
                    Metrics = new()
                    {
                        Accuracy = 0,
                        F1Score = 0,
                        Fn = 0,
                        Fp = 0,
                        Precision = 0,
                        Recall = 0,
                        Tn = 0,
                        Tp = 0,
                    },
                },
            ],
            PrecisionRecallAuc = 0,
        };

        MetricsDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldMetricTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FieldMetric
        {
            FieldPath = "fieldPath",
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
        };

        string expectedFieldPath = "fieldPath";
        Metrics expectedMetrics = new()
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

        Assert.Equal(expectedFieldPath, model.FieldPath);
        Assert.Equal(expectedMetrics, model.Metrics);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FieldMetric
        {
            FieldPath = "fieldPath",
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FieldMetric>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FieldMetric
        {
            FieldPath = "fieldPath",
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FieldMetric>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFieldPath = "fieldPath";
        Metrics expectedMetrics = new()
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

        Assert.Equal(expectedFieldPath, deserialized.FieldPath);
        Assert.Equal(expectedMetrics, deserialized.Metrics);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FieldMetric
        {
            FieldPath = "fieldPath",
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FieldMetric { FieldPath = "fieldPath" };

        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FieldMetric { FieldPath = "fieldPath" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FieldMetric
        {
            FieldPath = "fieldPath",

            // Null should be interpreted as omitted for these properties
            Metrics = null,
        };

        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FieldMetric
        {
            FieldPath = "fieldPath",

            // Null should be interpreted as omitted for these properties
            Metrics = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FieldMetric
        {
            FieldPath = "fieldPath",
            Metrics = new()
            {
                Accuracy = 0,
                F1Score = 0,
                Fn = 0,
                Fp = 0,
                Precision = 0,
                Recall = 0,
                Tn = 0,
                Tp = 0,
            },
        };

        FieldMetric copied = new(model);

        Assert.Equal(model, copied);
    }
}
