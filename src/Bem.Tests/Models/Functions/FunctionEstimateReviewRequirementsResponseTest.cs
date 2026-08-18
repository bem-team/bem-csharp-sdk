using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionEstimateReviewRequirementsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            Metrics = new()
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
        };

        Estimate expectedEstimate = new()
        {
            ConfidenceDistribution = new()
            {
                High = 0,
                Low = 0,
                Medium = 0,
            },
            LabeledTransformations = 0,
            MissingEvaluations = 0,
            ThresholdMatrix =
            [
                new()
                {
                    Fn = 0,
                    Fp = 0,
                    Threshold = 0,
                    Tn = 0,
                    Tp = 0,
                    AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Precision = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Recall = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                },
            ],
            TotalTransformations = 0,
            UnlabeledTransformations = 0,
        };
        string expectedFunctionName = "functionName";
        long expectedFunctionVersionNum = 0;
        MetricsDetails expectedMetrics = new()
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

        Assert.Equal(expectedEstimate, model.Estimate);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedFunctionVersionNum, model.FunctionVersionNum);
        Assert.Equal(expectedMetrics, model.Metrics);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            Metrics = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionEstimateReviewRequirementsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            Metrics = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionEstimateReviewRequirementsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Estimate expectedEstimate = new()
        {
            ConfidenceDistribution = new()
            {
                High = 0,
                Low = 0,
                Medium = 0,
            },
            LabeledTransformations = 0,
            MissingEvaluations = 0,
            ThresholdMatrix =
            [
                new()
                {
                    Fn = 0,
                    Fp = 0,
                    Threshold = 0,
                    Tn = 0,
                    Tp = 0,
                    AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Precision = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Recall = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                },
            ],
            TotalTransformations = 0,
            UnlabeledTransformations = 0,
        };
        string expectedFunctionName = "functionName";
        long expectedFunctionVersionNum = 0;
        MetricsDetails expectedMetrics = new()
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

        Assert.Equal(expectedEstimate, deserialized.Estimate);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedFunctionVersionNum, deserialized.FunctionVersionNum);
        Assert.Equal(expectedMetrics, deserialized.Metrics);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            Metrics = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,
        };

        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Metrics = null,
        };

        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,

            // Null should be interpreted as omitted for these properties
            Metrics = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionEstimateReviewRequirementsResponse
        {
            Estimate = new()
            {
                ConfidenceDistribution = new()
                {
                    High = 0,
                    Low = 0,
                    Medium = 0,
                },
                LabeledTransformations = 0,
                MissingEvaluations = 0,
                ThresholdMatrix =
                [
                    new()
                    {
                        Fn = 0,
                        Fp = 0,
                        Threshold = 0,
                        Tn = 0,
                        Tp = 0,
                        AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Precision = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                        Recall = new Dictionary<string, RateConfidenceInterval>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    CurrentSample = 0,
                                    SampleNeeded = 0,
                                    CiLower = 0,
                                    CiUpper = 0,
                                    Mid = 0,
                                }
                            },
                        },
                    },
                ],
                TotalTransformations = 0,
                UnlabeledTransformations = 0,
            },
            FunctionName = "functionName",
            FunctionVersionNum = 0,
            Metrics = new()
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
        };

        FunctionEstimateReviewRequirementsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EstimateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Estimate
        {
            ConfidenceDistribution = new()
            {
                High = 0,
                Low = 0,
                Medium = 0,
            },
            LabeledTransformations = 0,
            MissingEvaluations = 0,
            ThresholdMatrix =
            [
                new()
                {
                    Fn = 0,
                    Fp = 0,
                    Threshold = 0,
                    Tn = 0,
                    Tp = 0,
                    AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Precision = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Recall = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                },
            ],
            TotalTransformations = 0,
            UnlabeledTransformations = 0,
        };

        ConfidenceDistribution expectedConfidenceDistribution = new()
        {
            High = 0,
            Low = 0,
            Medium = 0,
        };
        long expectedLabeledTransformations = 0;
        long expectedMissingEvaluations = 0;
        List<ThresholdMatrix> expectedThresholdMatrix =
        [
            new()
            {
                Fn = 0,
                Fp = 0,
                Threshold = 0,
                Tn = 0,
                Tp = 0,
                AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
                FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
                FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
                Precision = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
                Recall = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
            },
        ];
        long expectedTotalTransformations = 0;
        long expectedUnlabeledTransformations = 0;

        Assert.Equal(expectedConfidenceDistribution, model.ConfidenceDistribution);
        Assert.Equal(expectedLabeledTransformations, model.LabeledTransformations);
        Assert.Equal(expectedMissingEvaluations, model.MissingEvaluations);
        Assert.Equal(expectedThresholdMatrix.Count, model.ThresholdMatrix.Count);
        for (int i = 0; i < expectedThresholdMatrix.Count; i++)
        {
            Assert.Equal(expectedThresholdMatrix[i], model.ThresholdMatrix[i]);
        }
        Assert.Equal(expectedTotalTransformations, model.TotalTransformations);
        Assert.Equal(expectedUnlabeledTransformations, model.UnlabeledTransformations);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Estimate
        {
            ConfidenceDistribution = new()
            {
                High = 0,
                Low = 0,
                Medium = 0,
            },
            LabeledTransformations = 0,
            MissingEvaluations = 0,
            ThresholdMatrix =
            [
                new()
                {
                    Fn = 0,
                    Fp = 0,
                    Threshold = 0,
                    Tn = 0,
                    Tp = 0,
                    AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Precision = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Recall = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                },
            ],
            TotalTransformations = 0,
            UnlabeledTransformations = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Estimate>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Estimate
        {
            ConfidenceDistribution = new()
            {
                High = 0,
                Low = 0,
                Medium = 0,
            },
            LabeledTransformations = 0,
            MissingEvaluations = 0,
            ThresholdMatrix =
            [
                new()
                {
                    Fn = 0,
                    Fp = 0,
                    Threshold = 0,
                    Tn = 0,
                    Tp = 0,
                    AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Precision = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Recall = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                },
            ],
            TotalTransformations = 0,
            UnlabeledTransformations = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Estimate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ConfidenceDistribution expectedConfidenceDistribution = new()
        {
            High = 0,
            Low = 0,
            Medium = 0,
        };
        long expectedLabeledTransformations = 0;
        long expectedMissingEvaluations = 0;
        List<ThresholdMatrix> expectedThresholdMatrix =
        [
            new()
            {
                Fn = 0,
                Fp = 0,
                Threshold = 0,
                Tn = 0,
                Tp = 0,
                AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
                FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
                FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
                Precision = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
                Recall = new Dictionary<string, RateConfidenceInterval>()
                {
                    {
                        "foo",
                        new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        }
                    },
                },
            },
        ];
        long expectedTotalTransformations = 0;
        long expectedUnlabeledTransformations = 0;

        Assert.Equal(expectedConfidenceDistribution, deserialized.ConfidenceDistribution);
        Assert.Equal(expectedLabeledTransformations, deserialized.LabeledTransformations);
        Assert.Equal(expectedMissingEvaluations, deserialized.MissingEvaluations);
        Assert.Equal(expectedThresholdMatrix.Count, deserialized.ThresholdMatrix.Count);
        for (int i = 0; i < expectedThresholdMatrix.Count; i++)
        {
            Assert.Equal(expectedThresholdMatrix[i], deserialized.ThresholdMatrix[i]);
        }
        Assert.Equal(expectedTotalTransformations, deserialized.TotalTransformations);
        Assert.Equal(expectedUnlabeledTransformations, deserialized.UnlabeledTransformations);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Estimate
        {
            ConfidenceDistribution = new()
            {
                High = 0,
                Low = 0,
                Medium = 0,
            },
            LabeledTransformations = 0,
            MissingEvaluations = 0,
            ThresholdMatrix =
            [
                new()
                {
                    Fn = 0,
                    Fp = 0,
                    Threshold = 0,
                    Tn = 0,
                    Tp = 0,
                    AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Precision = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Recall = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                },
            ],
            TotalTransformations = 0,
            UnlabeledTransformations = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Estimate
        {
            ConfidenceDistribution = new()
            {
                High = 0,
                Low = 0,
                Medium = 0,
            },
            LabeledTransformations = 0,
            MissingEvaluations = 0,
            ThresholdMatrix =
            [
                new()
                {
                    Fn = 0,
                    Fp = 0,
                    Threshold = 0,
                    Tn = 0,
                    Tp = 0,
                    AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Precision = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                    Recall = new Dictionary<string, RateConfidenceInterval>()
                    {
                        {
                            "foo",
                            new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            }
                        },
                    },
                },
            ],
            TotalTransformations = 0,
            UnlabeledTransformations = 0,
        };

        Estimate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfidenceDistributionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConfidenceDistribution
        {
            High = 0,
            Low = 0,
            Medium = 0,
        };

        long expectedHigh = 0;
        long expectedLow = 0;
        long expectedMedium = 0;

        Assert.Equal(expectedHigh, model.High);
        Assert.Equal(expectedLow, model.Low);
        Assert.Equal(expectedMedium, model.Medium);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConfidenceDistribution
        {
            High = 0,
            Low = 0,
            Medium = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfidenceDistribution>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConfidenceDistribution
        {
            High = 0,
            Low = 0,
            Medium = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfidenceDistribution>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedHigh = 0;
        long expectedLow = 0;
        long expectedMedium = 0;

        Assert.Equal(expectedHigh, deserialized.High);
        Assert.Equal(expectedLow, deserialized.Low);
        Assert.Equal(expectedMedium, deserialized.Medium);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConfidenceDistribution
        {
            High = 0,
            Low = 0,
            Medium = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConfidenceDistribution { };

        Assert.Null(model.High);
        Assert.False(model.RawData.ContainsKey("high"));
        Assert.Null(model.Low);
        Assert.False(model.RawData.ContainsKey("low"));
        Assert.Null(model.Medium);
        Assert.False(model.RawData.ContainsKey("medium"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConfidenceDistribution { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConfidenceDistribution
        {
            // Null should be interpreted as omitted for these properties
            High = null,
            Low = null,
            Medium = null,
        };

        Assert.Null(model.High);
        Assert.False(model.RawData.ContainsKey("high"));
        Assert.Null(model.Low);
        Assert.False(model.RawData.ContainsKey("low"));
        Assert.Null(model.Medium);
        Assert.False(model.RawData.ContainsKey("medium"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConfidenceDistribution
        {
            // Null should be interpreted as omitted for these properties
            High = null,
            Low = null,
            Medium = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConfidenceDistribution
        {
            High = 0,
            Low = 0,
            Medium = 0,
        };

        ConfidenceDistribution copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThresholdMatrixTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,
            AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Precision = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Recall = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
        };

        long expectedFn = 0;
        long expectedFp = 0;
        float expectedThreshold = 0;
        long expectedTn = 0;
        long expectedTp = 0;
        Dictionary<string, RateConfidenceInterval> expectedAccuracyAboveThreshold = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };
        Dictionary<string, RateConfidenceInterval> expectedFalseDiscoveryRate = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };
        Dictionary<string, RateConfidenceInterval> expectedFalsePositiveRate = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };
        Dictionary<string, RateConfidenceInterval> expectedPrecision = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };
        Dictionary<string, RateConfidenceInterval> expectedRecall = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };

        Assert.Equal(expectedFn, model.Fn);
        Assert.Equal(expectedFp, model.Fp);
        Assert.Equal(expectedThreshold, model.Threshold);
        Assert.Equal(expectedTn, model.Tn);
        Assert.Equal(expectedTp, model.Tp);
        Assert.NotNull(model.AccuracyAboveThreshold);
        Assert.Equal(expectedAccuracyAboveThreshold.Count, model.AccuracyAboveThreshold.Count);
        foreach (var item in expectedAccuracyAboveThreshold)
        {
            Assert.True(model.AccuracyAboveThreshold.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.AccuracyAboveThreshold[item.Key]);
        }
        Assert.NotNull(model.FalseDiscoveryRate);
        Assert.Equal(expectedFalseDiscoveryRate.Count, model.FalseDiscoveryRate.Count);
        foreach (var item in expectedFalseDiscoveryRate)
        {
            Assert.True(model.FalseDiscoveryRate.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.FalseDiscoveryRate[item.Key]);
        }
        Assert.NotNull(model.FalsePositiveRate);
        Assert.Equal(expectedFalsePositiveRate.Count, model.FalsePositiveRate.Count);
        foreach (var item in expectedFalsePositiveRate)
        {
            Assert.True(model.FalsePositiveRate.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.FalsePositiveRate[item.Key]);
        }
        Assert.NotNull(model.Precision);
        Assert.Equal(expectedPrecision.Count, model.Precision.Count);
        foreach (var item in expectedPrecision)
        {
            Assert.True(model.Precision.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Precision[item.Key]);
        }
        Assert.NotNull(model.Recall);
        Assert.Equal(expectedRecall.Count, model.Recall.Count);
        foreach (var item in expectedRecall)
        {
            Assert.True(model.Recall.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Recall[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,
            AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Precision = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Recall = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThresholdMatrix>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,
            AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Precision = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Recall = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThresholdMatrix>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedFn = 0;
        long expectedFp = 0;
        float expectedThreshold = 0;
        long expectedTn = 0;
        long expectedTp = 0;
        Dictionary<string, RateConfidenceInterval> expectedAccuracyAboveThreshold = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };
        Dictionary<string, RateConfidenceInterval> expectedFalseDiscoveryRate = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };
        Dictionary<string, RateConfidenceInterval> expectedFalsePositiveRate = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };
        Dictionary<string, RateConfidenceInterval> expectedPrecision = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };
        Dictionary<string, RateConfidenceInterval> expectedRecall = new()
        {
            {
                "foo",
                new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                }
            },
        };

        Assert.Equal(expectedFn, deserialized.Fn);
        Assert.Equal(expectedFp, deserialized.Fp);
        Assert.Equal(expectedThreshold, deserialized.Threshold);
        Assert.Equal(expectedTn, deserialized.Tn);
        Assert.Equal(expectedTp, deserialized.Tp);
        Assert.NotNull(deserialized.AccuracyAboveThreshold);
        Assert.Equal(
            expectedAccuracyAboveThreshold.Count,
            deserialized.AccuracyAboveThreshold.Count
        );
        foreach (var item in expectedAccuracyAboveThreshold)
        {
            Assert.True(deserialized.AccuracyAboveThreshold.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.AccuracyAboveThreshold[item.Key]);
        }
        Assert.NotNull(deserialized.FalseDiscoveryRate);
        Assert.Equal(expectedFalseDiscoveryRate.Count, deserialized.FalseDiscoveryRate.Count);
        foreach (var item in expectedFalseDiscoveryRate)
        {
            Assert.True(deserialized.FalseDiscoveryRate.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.FalseDiscoveryRate[item.Key]);
        }
        Assert.NotNull(deserialized.FalsePositiveRate);
        Assert.Equal(expectedFalsePositiveRate.Count, deserialized.FalsePositiveRate.Count);
        foreach (var item in expectedFalsePositiveRate)
        {
            Assert.True(deserialized.FalsePositiveRate.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.FalsePositiveRate[item.Key]);
        }
        Assert.NotNull(deserialized.Precision);
        Assert.Equal(expectedPrecision.Count, deserialized.Precision.Count);
        foreach (var item in expectedPrecision)
        {
            Assert.True(deserialized.Precision.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Precision[item.Key]);
        }
        Assert.NotNull(deserialized.Recall);
        Assert.Equal(expectedRecall.Count, deserialized.Recall.Count);
        foreach (var item in expectedRecall)
        {
            Assert.True(deserialized.Recall.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Recall[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,
            AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Precision = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Recall = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,
        };

        Assert.Null(model.AccuracyAboveThreshold);
        Assert.False(model.RawData.ContainsKey("accuracyAboveThreshold"));
        Assert.Null(model.FalseDiscoveryRate);
        Assert.False(model.RawData.ContainsKey("falseDiscoveryRate"));
        Assert.Null(model.FalsePositiveRate);
        Assert.False(model.RawData.ContainsKey("falsePositiveRate"));
        Assert.Null(model.Precision);
        Assert.False(model.RawData.ContainsKey("precision"));
        Assert.Null(model.Recall);
        Assert.False(model.RawData.ContainsKey("recall"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,

            // Null should be interpreted as omitted for these properties
            AccuracyAboveThreshold = null,
            FalseDiscoveryRate = null,
            FalsePositiveRate = null,
            Precision = null,
            Recall = null,
        };

        Assert.Null(model.AccuracyAboveThreshold);
        Assert.False(model.RawData.ContainsKey("accuracyAboveThreshold"));
        Assert.Null(model.FalseDiscoveryRate);
        Assert.False(model.RawData.ContainsKey("falseDiscoveryRate"));
        Assert.Null(model.FalsePositiveRate);
        Assert.False(model.RawData.ContainsKey("falsePositiveRate"));
        Assert.Null(model.Precision);
        Assert.False(model.RawData.ContainsKey("precision"));
        Assert.Null(model.Recall);
        Assert.False(model.RawData.ContainsKey("recall"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,

            // Null should be interpreted as omitted for these properties
            AccuracyAboveThreshold = null,
            FalseDiscoveryRate = null,
            FalsePositiveRate = null,
            Precision = null,
            Recall = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThresholdMatrix
        {
            Fn = 0,
            Fp = 0,
            Threshold = 0,
            Tn = 0,
            Tp = 0,
            AccuracyAboveThreshold = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalseDiscoveryRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            FalsePositiveRate = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Precision = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
            Recall = new Dictionary<string, RateConfidenceInterval>()
            {
                {
                    "foo",
                    new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    }
                },
            },
        };

        ThresholdMatrix copied = new(model);

        Assert.Equal(model, copied);
    }
}
