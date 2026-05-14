using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionGetMetricsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionGetMetricsResponse
        {
            Functions =
            [
                new()
                {
                    FunctionName = "functionName",
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
                    TotalLabeledResults = 0,
                    TotalResults = 0,
                },
            ],
            TotalCount = 0,
        };

        List<FunctionGetMetricsResponseFunction> expectedFunctions =
        [
            new()
            {
                FunctionName = "functionName",
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
                TotalLabeledResults = 0,
                TotalResults = 0,
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedFunctions.Count, model.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], model.Functions[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionGetMetricsResponse
        {
            Functions =
            [
                new()
                {
                    FunctionName = "functionName",
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
                    TotalLabeledResults = 0,
                    TotalResults = 0,
                },
            ],
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionGetMetricsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionGetMetricsResponse
        {
            Functions =
            [
                new()
                {
                    FunctionName = "functionName",
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
                    TotalLabeledResults = 0,
                    TotalResults = 0,
                },
            ],
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionGetMetricsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FunctionGetMetricsResponseFunction> expectedFunctions =
        [
            new()
            {
                FunctionName = "functionName",
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
                TotalLabeledResults = 0,
                TotalResults = 0,
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedFunctions.Count, deserialized.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], deserialized.Functions[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionGetMetricsResponse
        {
            Functions =
            [
                new()
                {
                    FunctionName = "functionName",
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
                    TotalLabeledResults = 0,
                    TotalResults = 0,
                },
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionGetMetricsResponse
        {
            Functions =
            [
                new()
                {
                    FunctionName = "functionName",
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
                    TotalLabeledResults = 0,
                    TotalResults = 0,
                },
            ],
            TotalCount = 0,
        };

        FunctionGetMetricsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionGetMetricsResponseFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionGetMetricsResponseFunction
        {
            FunctionName = "functionName",
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
            TotalLabeledResults = 0,
            TotalResults = 0,
        };

        string expectedFunctionName = "functionName";
        FunctionGetMetricsResponseFunctionMetrics expectedMetrics = new()
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
        long expectedTotalLabeledResults = 0;
        long expectedTotalResults = 0;

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedMetrics, model.Metrics);
        Assert.Equal(expectedTotalLabeledResults, model.TotalLabeledResults);
        Assert.Equal(expectedTotalResults, model.TotalResults);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionGetMetricsResponseFunction
        {
            FunctionName = "functionName",
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
            TotalLabeledResults = 0,
            TotalResults = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionGetMetricsResponseFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionGetMetricsResponseFunction
        {
            FunctionName = "functionName",
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
            TotalLabeledResults = 0,
            TotalResults = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionGetMetricsResponseFunction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        FunctionGetMetricsResponseFunctionMetrics expectedMetrics = new()
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
        long expectedTotalLabeledResults = 0;
        long expectedTotalResults = 0;

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedMetrics, deserialized.Metrics);
        Assert.Equal(expectedTotalLabeledResults, deserialized.TotalLabeledResults);
        Assert.Equal(expectedTotalResults, deserialized.TotalResults);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionGetMetricsResponseFunction
        {
            FunctionName = "functionName",
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
            TotalLabeledResults = 0,
            TotalResults = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionGetMetricsResponseFunction
        {
            FunctionName = "functionName",
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
            TotalLabeledResults = 0,
            TotalResults = 0,
        };

        FunctionGetMetricsResponseFunction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionGetMetricsResponseFunctionMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionGetMetricsResponseFunctionMetrics
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
        var model = new FunctionGetMetricsResponseFunctionMetrics
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
        var deserialized = JsonSerializer.Deserialize<FunctionGetMetricsResponseFunctionMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionGetMetricsResponseFunctionMetrics
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
        var deserialized = JsonSerializer.Deserialize<FunctionGetMetricsResponseFunctionMetrics>(
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
        var model = new FunctionGetMetricsResponseFunctionMetrics
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
    public void CopyConstructor_Works()
    {
        var model = new FunctionGetMetricsResponseFunctionMetrics
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

        FunctionGetMetricsResponseFunctionMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
