using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionCompareMetricsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",
            AggregateComparison = new()
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
            },
            BaselineMetrics = new()
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
            },
            BaselineTransformationCount = 0,
            ComparisonMetrics = new()
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
            },
            ComparisonTransformationCount = 0,
            FieldMetricsChanges =
            [
                new()
                {
                    Comparison = new()
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
                    },
                    FieldPath = "fieldPath",
                },
            ],
            Message = "message",
        };

        long expectedBaselineVersionNum = 0;
        long expectedComparisonVersionNum = 0;
        string expectedFunctionName = "functionName";
        MetricsComparison expectedAggregateComparison = new()
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
        MetricsDetails expectedBaselineMetrics = new()
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
        long expectedBaselineTransformationCount = 0;
        MetricsDetails expectedComparisonMetrics = new()
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
        long expectedComparisonTransformationCount = 0;
        List<FieldMetricsChange> expectedFieldMetricsChanges =
        [
            new()
            {
                Comparison = new()
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
                },
                FieldPath = "fieldPath",
            },
        ];
        string expectedMessage = "message";

        Assert.Equal(expectedBaselineVersionNum, model.BaselineVersionNum);
        Assert.Equal(expectedComparisonVersionNum, model.ComparisonVersionNum);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedAggregateComparison, model.AggregateComparison);
        Assert.Equal(expectedBaselineMetrics, model.BaselineMetrics);
        Assert.Equal(expectedBaselineTransformationCount, model.BaselineTransformationCount);
        Assert.Equal(expectedComparisonMetrics, model.ComparisonMetrics);
        Assert.Equal(expectedComparisonTransformationCount, model.ComparisonTransformationCount);
        Assert.NotNull(model.FieldMetricsChanges);
        Assert.Equal(expectedFieldMetricsChanges.Count, model.FieldMetricsChanges.Count);
        for (int i = 0; i < expectedFieldMetricsChanges.Count; i++)
        {
            Assert.Equal(expectedFieldMetricsChanges[i], model.FieldMetricsChanges[i]);
        }
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",
            AggregateComparison = new()
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
            },
            BaselineMetrics = new()
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
            },
            BaselineTransformationCount = 0,
            ComparisonMetrics = new()
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
            },
            ComparisonTransformationCount = 0,
            FieldMetricsChanges =
            [
                new()
                {
                    Comparison = new()
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
                    },
                    FieldPath = "fieldPath",
                },
            ],
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCompareMetricsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",
            AggregateComparison = new()
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
            },
            BaselineMetrics = new()
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
            },
            BaselineTransformationCount = 0,
            ComparisonMetrics = new()
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
            },
            ComparisonTransformationCount = 0,
            FieldMetricsChanges =
            [
                new()
                {
                    Comparison = new()
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
                    },
                    FieldPath = "fieldPath",
                },
            ],
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCompareMetricsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBaselineVersionNum = 0;
        long expectedComparisonVersionNum = 0;
        string expectedFunctionName = "functionName";
        MetricsComparison expectedAggregateComparison = new()
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
        MetricsDetails expectedBaselineMetrics = new()
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
        long expectedBaselineTransformationCount = 0;
        MetricsDetails expectedComparisonMetrics = new()
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
        long expectedComparisonTransformationCount = 0;
        List<FieldMetricsChange> expectedFieldMetricsChanges =
        [
            new()
            {
                Comparison = new()
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
                },
                FieldPath = "fieldPath",
            },
        ];
        string expectedMessage = "message";

        Assert.Equal(expectedBaselineVersionNum, deserialized.BaselineVersionNum);
        Assert.Equal(expectedComparisonVersionNum, deserialized.ComparisonVersionNum);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedAggregateComparison, deserialized.AggregateComparison);
        Assert.Equal(expectedBaselineMetrics, deserialized.BaselineMetrics);
        Assert.Equal(expectedBaselineTransformationCount, deserialized.BaselineTransformationCount);
        Assert.Equal(expectedComparisonMetrics, deserialized.ComparisonMetrics);
        Assert.Equal(
            expectedComparisonTransformationCount,
            deserialized.ComparisonTransformationCount
        );
        Assert.NotNull(deserialized.FieldMetricsChanges);
        Assert.Equal(expectedFieldMetricsChanges.Count, deserialized.FieldMetricsChanges.Count);
        for (int i = 0; i < expectedFieldMetricsChanges.Count; i++)
        {
            Assert.Equal(expectedFieldMetricsChanges[i], deserialized.FieldMetricsChanges[i]);
        }
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",
            AggregateComparison = new()
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
            },
            BaselineMetrics = new()
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
            },
            BaselineTransformationCount = 0,
            ComparisonMetrics = new()
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
            },
            ComparisonTransformationCount = 0,
            FieldMetricsChanges =
            [
                new()
                {
                    Comparison = new()
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
                    },
                    FieldPath = "fieldPath",
                },
            ],
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",
        };

        Assert.Null(model.AggregateComparison);
        Assert.False(model.RawData.ContainsKey("aggregateComparison"));
        Assert.Null(model.BaselineMetrics);
        Assert.False(model.RawData.ContainsKey("baselineMetrics"));
        Assert.Null(model.BaselineTransformationCount);
        Assert.False(model.RawData.ContainsKey("baselineTransformationCount"));
        Assert.Null(model.ComparisonMetrics);
        Assert.False(model.RawData.ContainsKey("comparisonMetrics"));
        Assert.Null(model.ComparisonTransformationCount);
        Assert.False(model.RawData.ContainsKey("comparisonTransformationCount"));
        Assert.Null(model.FieldMetricsChanges);
        Assert.False(model.RawData.ContainsKey("fieldMetricsChanges"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            AggregateComparison = null,
            BaselineMetrics = null,
            BaselineTransformationCount = null,
            ComparisonMetrics = null,
            ComparisonTransformationCount = null,
            FieldMetricsChanges = null,
            Message = null,
        };

        Assert.Null(model.AggregateComparison);
        Assert.False(model.RawData.ContainsKey("aggregateComparison"));
        Assert.Null(model.BaselineMetrics);
        Assert.False(model.RawData.ContainsKey("baselineMetrics"));
        Assert.Null(model.BaselineTransformationCount);
        Assert.False(model.RawData.ContainsKey("baselineTransformationCount"));
        Assert.Null(model.ComparisonMetrics);
        Assert.False(model.RawData.ContainsKey("comparisonMetrics"));
        Assert.Null(model.ComparisonTransformationCount);
        Assert.False(model.RawData.ContainsKey("comparisonTransformationCount"));
        Assert.Null(model.FieldMetricsChanges);
        Assert.False(model.RawData.ContainsKey("fieldMetricsChanges"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",

            // Null should be interpreted as omitted for these properties
            AggregateComparison = null,
            BaselineMetrics = null,
            BaselineTransformationCount = null,
            ComparisonMetrics = null,
            ComparisonTransformationCount = null,
            FieldMetricsChanges = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionCompareMetricsResponse
        {
            BaselineVersionNum = 0,
            ComparisonVersionNum = 0,
            FunctionName = "functionName",
            AggregateComparison = new()
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
            },
            BaselineMetrics = new()
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
            },
            BaselineTransformationCount = 0,
            ComparisonMetrics = new()
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
            },
            ComparisonTransformationCount = 0,
            FieldMetricsChanges =
            [
                new()
                {
                    Comparison = new()
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
                    },
                    FieldPath = "fieldPath",
                },
            ],
            Message = "message",
        };

        FunctionCompareMetricsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldMetricsChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FieldMetricsChange
        {
            Comparison = new()
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
            },
            FieldPath = "fieldPath",
        };

        MetricsComparison expectedComparison = new()
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
        string expectedFieldPath = "fieldPath";

        Assert.Equal(expectedComparison, model.Comparison);
        Assert.Equal(expectedFieldPath, model.FieldPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FieldMetricsChange
        {
            Comparison = new()
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
            },
            FieldPath = "fieldPath",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FieldMetricsChange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FieldMetricsChange
        {
            Comparison = new()
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
            },
            FieldPath = "fieldPath",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FieldMetricsChange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MetricsComparison expectedComparison = new()
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
        string expectedFieldPath = "fieldPath";

        Assert.Equal(expectedComparison, deserialized.Comparison);
        Assert.Equal(expectedFieldPath, deserialized.FieldPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FieldMetricsChange
        {
            Comparison = new()
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
            },
            FieldPath = "fieldPath",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FieldMetricsChange
        {
            Comparison = new()
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
            },
            FieldPath = "fieldPath",
        };

        FieldMetricsChange copied = new(model);

        Assert.Equal(model, copied);
    }
}
