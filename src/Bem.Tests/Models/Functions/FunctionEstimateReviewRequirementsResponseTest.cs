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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                    AccuracyAboveThreshold = new()
                    {
                        A95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalseDiscoveryRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalsePositiveRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Precision = new()
                    {
                        P95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Recall = new()
                    {
                        R95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                    AccuracyAboveThreshold = new()
                    {
                        A95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalseDiscoveryRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalsePositiveRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Precision = new()
                    {
                        P95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Recall = new()
                    {
                        R95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                        AccuracyAboveThreshold = new()
                        {
                            A95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalseDiscoveryRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        FalsePositiveRate = new()
                        {
                            F95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Precision = new()
                        {
                            P95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
                            },
                        },
                        Recall = new()
                        {
                            R95 = new()
                            {
                                CurrentSample = 0,
                                SampleNeeded = 0,
                                CiLower = 0,
                                CiUpper = 0,
                                Mid = 0,
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
                    AccuracyAboveThreshold = new()
                    {
                        A95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalseDiscoveryRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalsePositiveRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Precision = new()
                    {
                        P95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Recall = new()
                    {
                        R95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
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
                AccuracyAboveThreshold = new()
                {
                    A95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    },
                },
                FalseDiscoveryRate = new()
                {
                    F95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    },
                },
                FalsePositiveRate = new()
                {
                    F95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    },
                },
                Precision = new()
                {
                    P95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    },
                },
                Recall = new()
                {
                    R95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
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
                    AccuracyAboveThreshold = new()
                    {
                        A95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalseDiscoveryRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalsePositiveRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Precision = new()
                    {
                        P95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Recall = new()
                    {
                        R95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
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
                    AccuracyAboveThreshold = new()
                    {
                        A95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalseDiscoveryRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalsePositiveRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Precision = new()
                    {
                        P95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Recall = new()
                    {
                        R95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
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
                AccuracyAboveThreshold = new()
                {
                    A95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    },
                },
                FalseDiscoveryRate = new()
                {
                    F95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    },
                },
                FalsePositiveRate = new()
                {
                    F95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    },
                },
                Precision = new()
                {
                    P95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
                    },
                },
                Recall = new()
                {
                    R95 = new()
                    {
                        CurrentSample = 0,
                        SampleNeeded = 0,
                        CiLower = 0,
                        CiUpper = 0,
                        Mid = 0,
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
                    AccuracyAboveThreshold = new()
                    {
                        A95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalseDiscoveryRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalsePositiveRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Precision = new()
                    {
                        P95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Recall = new()
                    {
                        R95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
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
                    AccuracyAboveThreshold = new()
                    {
                        A95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalseDiscoveryRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    FalsePositiveRate = new()
                    {
                        F95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Precision = new()
                    {
                        P95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
                        },
                    },
                    Recall = new()
                    {
                        R95 = new()
                        {
                            CurrentSample = 0,
                            SampleNeeded = 0,
                            CiLower = 0,
                            CiUpper = 0,
                            Mid = 0,
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
            AccuracyAboveThreshold = new()
            {
                A95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalseDiscoveryRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalsePositiveRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Precision = new()
            {
                P95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Recall = new()
            {
                R95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
        };

        long expectedFn = 0;
        long expectedFp = 0;
        float expectedThreshold = 0;
        long expectedTn = 0;
        long expectedTp = 0;
        AccuracyAboveThreshold expectedAccuracyAboveThreshold = new()
        {
            A95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };
        FalseDiscoveryRate expectedFalseDiscoveryRate = new()
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };
        FalsePositiveRate expectedFalsePositiveRate = new()
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };
        Precision expectedPrecision = new()
        {
            P95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };
        Recall expectedRecall = new()
        {
            R95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        Assert.Equal(expectedFn, model.Fn);
        Assert.Equal(expectedFp, model.Fp);
        Assert.Equal(expectedThreshold, model.Threshold);
        Assert.Equal(expectedTn, model.Tn);
        Assert.Equal(expectedTp, model.Tp);
        Assert.Equal(expectedAccuracyAboveThreshold, model.AccuracyAboveThreshold);
        Assert.Equal(expectedFalseDiscoveryRate, model.FalseDiscoveryRate);
        Assert.Equal(expectedFalsePositiveRate, model.FalsePositiveRate);
        Assert.Equal(expectedPrecision, model.Precision);
        Assert.Equal(expectedRecall, model.Recall);
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
            AccuracyAboveThreshold = new()
            {
                A95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalseDiscoveryRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalsePositiveRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Precision = new()
            {
                P95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Recall = new()
            {
                R95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
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
            AccuracyAboveThreshold = new()
            {
                A95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalseDiscoveryRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalsePositiveRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Precision = new()
            {
                P95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Recall = new()
            {
                R95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
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
        AccuracyAboveThreshold expectedAccuracyAboveThreshold = new()
        {
            A95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };
        FalseDiscoveryRate expectedFalseDiscoveryRate = new()
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };
        FalsePositiveRate expectedFalsePositiveRate = new()
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };
        Precision expectedPrecision = new()
        {
            P95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };
        Recall expectedRecall = new()
        {
            R95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        Assert.Equal(expectedFn, deserialized.Fn);
        Assert.Equal(expectedFp, deserialized.Fp);
        Assert.Equal(expectedThreshold, deserialized.Threshold);
        Assert.Equal(expectedTn, deserialized.Tn);
        Assert.Equal(expectedTp, deserialized.Tp);
        Assert.Equal(expectedAccuracyAboveThreshold, deserialized.AccuracyAboveThreshold);
        Assert.Equal(expectedFalseDiscoveryRate, deserialized.FalseDiscoveryRate);
        Assert.Equal(expectedFalsePositiveRate, deserialized.FalsePositiveRate);
        Assert.Equal(expectedPrecision, deserialized.Precision);
        Assert.Equal(expectedRecall, deserialized.Recall);
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
            AccuracyAboveThreshold = new()
            {
                A95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalseDiscoveryRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalsePositiveRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Precision = new()
            {
                P95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Recall = new()
            {
                R95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
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
            AccuracyAboveThreshold = new()
            {
                A95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalseDiscoveryRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            FalsePositiveRate = new()
            {
                F95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Precision = new()
            {
                P95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
            Recall = new()
            {
                R95 = new()
                {
                    CurrentSample = 0,
                    SampleNeeded = 0,
                    CiLower = 0,
                    CiUpper = 0,
                    Mid = 0,
                },
            },
        };

        ThresholdMatrix copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccuracyAboveThresholdTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccuracyAboveThreshold
        {
            A95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        RateConfidenceInterval expectedA95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedA95, model.A95);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccuracyAboveThreshold
        {
            A95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccuracyAboveThreshold>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccuracyAboveThreshold
        {
            A95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccuracyAboveThreshold>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RateConfidenceInterval expectedA95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedA95, deserialized.A95);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccuracyAboveThreshold
        {
            A95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccuracyAboveThreshold { };

        Assert.Null(model.A95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccuracyAboveThreshold { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccuracyAboveThreshold
        {
            // Null should be interpreted as omitted for these properties
            A95 = null,
        };

        Assert.Null(model.A95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccuracyAboveThreshold
        {
            // Null should be interpreted as omitted for these properties
            A95 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccuracyAboveThreshold
        {
            A95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        AccuracyAboveThreshold copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FalseDiscoveryRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FalseDiscoveryRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        RateConfidenceInterval expectedF95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedF95, model.F95);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FalseDiscoveryRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FalseDiscoveryRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FalseDiscoveryRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FalseDiscoveryRate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RateConfidenceInterval expectedF95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedF95, deserialized.F95);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FalseDiscoveryRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FalseDiscoveryRate { };

        Assert.Null(model.F95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FalseDiscoveryRate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FalseDiscoveryRate
        {
            // Null should be interpreted as omitted for these properties
            F95 = null,
        };

        Assert.Null(model.F95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FalseDiscoveryRate
        {
            // Null should be interpreted as omitted for these properties
            F95 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FalseDiscoveryRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        FalseDiscoveryRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FalsePositiveRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FalsePositiveRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        RateConfidenceInterval expectedF95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedF95, model.F95);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FalsePositiveRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FalsePositiveRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FalsePositiveRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FalsePositiveRate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RateConfidenceInterval expectedF95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedF95, deserialized.F95);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FalsePositiveRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FalsePositiveRate { };

        Assert.Null(model.F95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FalsePositiveRate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FalsePositiveRate
        {
            // Null should be interpreted as omitted for these properties
            F95 = null,
        };

        Assert.Null(model.F95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FalsePositiveRate
        {
            // Null should be interpreted as omitted for these properties
            F95 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FalsePositiveRate
        {
            F95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        FalsePositiveRate copied = new(model);

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
            P95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        RateConfidenceInterval expectedP95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedP95, model.P95);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Precision
        {
            P95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
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
            P95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Precision>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RateConfidenceInterval expectedP95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedP95, deserialized.P95);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Precision
        {
            P95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Precision { };

        Assert.Null(model.P95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Precision { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Precision
        {
            // Null should be interpreted as omitted for these properties
            P95 = null,
        };

        Assert.Null(model.P95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Precision
        {
            // Null should be interpreted as omitted for these properties
            P95 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Precision
        {
            P95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
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
            R95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        RateConfidenceInterval expectedR95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedR95, model.R95);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Recall
        {
            R95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
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
            R95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recall>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        RateConfidenceInterval expectedR95 = new()
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        Assert.Equal(expectedR95, deserialized.R95);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Recall
        {
            R95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Recall { };

        Assert.Null(model.R95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Recall { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Recall
        {
            // Null should be interpreted as omitted for these properties
            R95 = null,
        };

        Assert.Null(model.R95);
        Assert.False(model.RawData.ContainsKey("95"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Recall
        {
            // Null should be interpreted as omitted for these properties
            R95 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Recall
        {
            R95 = new()
            {
                CurrentSample = 0,
                SampleNeeded = 0,
                CiLower = 0,
                CiUpper = 0,
                Mid = 0,
            },
        };

        Recall copied = new(model);

        Assert.Equal(model, copied);
    }
}
