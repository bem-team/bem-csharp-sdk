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
        AggregateComparison expectedAggregateComparison = new()
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
        BaselineMetrics expectedBaselineMetrics = new()
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
        ComparisonMetrics expectedComparisonMetrics = new()
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
        AggregateComparison expectedAggregateComparison = new()
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
        BaselineMetrics expectedBaselineMetrics = new()
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
        ComparisonMetrics expectedComparisonMetrics = new()
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

public class AggregateComparisonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AggregateComparison
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

        Accuracy expectedAccuracy = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        F1Score expectedF1Score = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        Precision expectedPrecision = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        Recall expectedRecall = new()
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
        var model = new AggregateComparison
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
        var deserialized = JsonSerializer.Deserialize<AggregateComparison>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AggregateComparison
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
        var deserialized = JsonSerializer.Deserialize<AggregateComparison>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Accuracy expectedAccuracy = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        F1Score expectedF1Score = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        Precision expectedPrecision = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        Recall expectedRecall = new()
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
        var model = new AggregateComparison
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
        var model = new AggregateComparison { };

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
        var model = new AggregateComparison { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AggregateComparison
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
        var model = new AggregateComparison
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
        var model = new AggregateComparison
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

        AggregateComparison copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccuracyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Accuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Accuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Accuracy>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Accuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Accuracy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Accuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Accuracy { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Accuracy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Accuracy
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Accuracy
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Accuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        Accuracy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class F1ScoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new F1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new F1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<F1Score>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new F1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<F1Score>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new F1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new F1Score { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new F1Score { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new F1Score
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new F1Score
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new F1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        F1Score copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PrecisionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Precision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Precision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Precision>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Precision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Precision>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Precision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Precision { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Precision { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Precision
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Precision
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Precision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        Precision copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Recall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Recall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recall>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Recall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recall>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Recall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Recall { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Recall { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Recall
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Recall
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Recall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        Recall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BaselineMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BaselineMetrics
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

        AggregateMetrics expectedAggregateMetrics = new()
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
        var model = new BaselineMetrics
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
        var deserialized = JsonSerializer.Deserialize<BaselineMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BaselineMetrics
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
        var deserialized = JsonSerializer.Deserialize<BaselineMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AggregateMetrics expectedAggregateMetrics = new()
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
        var model = new BaselineMetrics
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
        var model = new BaselineMetrics { };

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
        var model = new BaselineMetrics { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BaselineMetrics
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
        var model = new BaselineMetrics
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
        var model = new BaselineMetrics
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

        BaselineMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AggregateMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var deserialized = JsonSerializer.Deserialize<AggregateMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AggregateMetrics
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
        var deserialized = JsonSerializer.Deserialize<AggregateMetrics>(
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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
        var model = new AggregateMetrics
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

        AggregateMetrics copied = new(model);

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

public class ComparisonMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComparisonMetrics
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

        ComparisonMetricsAggregateMetrics expectedAggregateMetrics = new()
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
        List<ComparisonMetricsFieldMetric> expectedFieldMetrics =
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
        var model = new ComparisonMetrics
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
        var deserialized = JsonSerializer.Deserialize<ComparisonMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComparisonMetrics
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
        var deserialized = JsonSerializer.Deserialize<ComparisonMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ComparisonMetricsAggregateMetrics expectedAggregateMetrics = new()
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
        List<ComparisonMetricsFieldMetric> expectedFieldMetrics =
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
        var model = new ComparisonMetrics
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
        var model = new ComparisonMetrics { };

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
        var model = new ComparisonMetrics { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComparisonMetrics
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
        var model = new ComparisonMetrics
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
        var model = new ComparisonMetrics
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

        ComparisonMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComparisonMetricsAggregateMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var deserialized = JsonSerializer.Deserialize<ComparisonMetricsAggregateMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComparisonMetricsAggregateMetrics
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
        var deserialized = JsonSerializer.Deserialize<ComparisonMetricsAggregateMetrics>(
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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
        var model = new ComparisonMetricsAggregateMetrics
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

        ComparisonMetricsAggregateMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComparisonMetricsFieldMetricTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComparisonMetricsFieldMetric
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
        ComparisonMetricsFieldMetricMetrics expectedMetrics = new()
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
        var model = new ComparisonMetricsFieldMetric
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
        var deserialized = JsonSerializer.Deserialize<ComparisonMetricsFieldMetric>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComparisonMetricsFieldMetric
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
        var deserialized = JsonSerializer.Deserialize<ComparisonMetricsFieldMetric>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFieldPath = "fieldPath";
        ComparisonMetricsFieldMetricMetrics expectedMetrics = new()
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
        var model = new ComparisonMetricsFieldMetric
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
        var model = new ComparisonMetricsFieldMetric { FieldPath = "fieldPath" };

        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComparisonMetricsFieldMetric { FieldPath = "fieldPath" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComparisonMetricsFieldMetric
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
        var model = new ComparisonMetricsFieldMetric
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
        var model = new ComparisonMetricsFieldMetric
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

        ComparisonMetricsFieldMetric copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComparisonMetricsFieldMetricMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var deserialized = JsonSerializer.Deserialize<ComparisonMetricsFieldMetricMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var deserialized = JsonSerializer.Deserialize<ComparisonMetricsFieldMetricMetrics>(
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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
        var model = new ComparisonMetricsFieldMetricMetrics
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

        ComparisonMetricsFieldMetricMetrics copied = new(model);

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

        Comparison expectedComparison = new()
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

        Comparison expectedComparison = new()
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

public class ComparisonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Comparison
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

        ComparisonAccuracy expectedAccuracy = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        ComparisonF1Score expectedF1Score = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        ComparisonPrecision expectedPrecision = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        ComparisonRecall expectedRecall = new()
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
        var model = new Comparison
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
        var deserialized = JsonSerializer.Deserialize<Comparison>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Comparison
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
        var deserialized = JsonSerializer.Deserialize<Comparison>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ComparisonAccuracy expectedAccuracy = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        ComparisonF1Score expectedF1Score = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        ComparisonPrecision expectedPrecision = new()
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };
        ComparisonRecall expectedRecall = new()
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
        var model = new Comparison
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
        var model = new Comparison { };

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
        var model = new Comparison { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Comparison
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
        var model = new Comparison
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
        var model = new Comparison
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

        Comparison copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComparisonAccuracyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComparisonAccuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComparisonAccuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComparisonAccuracy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComparisonAccuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComparisonAccuracy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComparisonAccuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComparisonAccuracy { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComparisonAccuracy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ComparisonAccuracy
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComparisonAccuracy
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComparisonAccuracy
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        ComparisonAccuracy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComparisonF1ScoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComparisonF1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComparisonF1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComparisonF1Score>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComparisonF1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComparisonF1Score>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComparisonF1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComparisonF1Score { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComparisonF1Score { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ComparisonF1Score
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComparisonF1Score
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComparisonF1Score
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        ComparisonF1Score copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComparisonPrecisionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComparisonPrecision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComparisonPrecision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComparisonPrecision>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComparisonPrecision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComparisonPrecision>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComparisonPrecision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComparisonPrecision { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComparisonPrecision { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ComparisonPrecision
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComparisonPrecision
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComparisonPrecision
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        ComparisonPrecision copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComparisonRecallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComparisonRecall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComparisonRecall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComparisonRecall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComparisonRecall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComparisonRecall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComparisonRecall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComparisonRecall { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComparisonRecall { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ComparisonRecall
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComparisonRecall
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComparisonRecall
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        ComparisonRecall copied = new(model);

        Assert.Equal(model, copied);
    }
}
