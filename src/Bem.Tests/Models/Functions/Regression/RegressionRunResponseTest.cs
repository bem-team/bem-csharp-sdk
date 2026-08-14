using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions.Regression;

namespace Bem.Tests.Models.Functions.Regression;

public class RegressionRunResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RegressionRunResponse
        {
            FunctionName = "functionName",
            Result = new()
            {
                FunctionName = "functionName",
                TotalSamples = 0,
                Calls =
                [
                    new()
                    {
                        CallID = "wc_sqF12lZ1VlBb",
                        OriginalReferenceID = "originalReferenceID",
                    },
                ],
            },
        };

        string expectedFunctionName = "functionName";
        Result expectedResult = new()
        {
            FunctionName = "functionName",
            TotalSamples = 0,
            Calls =
            [
                new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
            ],
        };

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RegressionRunResponse
        {
            FunctionName = "functionName",
            Result = new()
            {
                FunctionName = "functionName",
                TotalSamples = 0,
                Calls =
                [
                    new()
                    {
                        CallID = "wc_sqF12lZ1VlBb",
                        OriginalReferenceID = "originalReferenceID",
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegressionRunResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RegressionRunResponse
        {
            FunctionName = "functionName",
            Result = new()
            {
                FunctionName = "functionName",
                TotalSamples = 0,
                Calls =
                [
                    new()
                    {
                        CallID = "wc_sqF12lZ1VlBb",
                        OriginalReferenceID = "originalReferenceID",
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegressionRunResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        Result expectedResult = new()
        {
            FunctionName = "functionName",
            TotalSamples = 0,
            Calls =
            [
                new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
            ],
        };

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RegressionRunResponse
        {
            FunctionName = "functionName",
            Result = new()
            {
                FunctionName = "functionName",
                TotalSamples = 0,
                Calls =
                [
                    new()
                    {
                        CallID = "wc_sqF12lZ1VlBb",
                        OriginalReferenceID = "originalReferenceID",
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RegressionRunResponse
        {
            FunctionName = "functionName",
            Result = new()
            {
                FunctionName = "functionName",
                TotalSamples = 0,
                Calls =
                [
                    new()
                    {
                        CallID = "wc_sqF12lZ1VlBb",
                        OriginalReferenceID = "originalReferenceID",
                    },
                ],
            },
        };

        RegressionRunResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            FunctionName = "functionName",
            TotalSamples = 0,
            Calls =
            [
                new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
            ],
        };

        string expectedFunctionName = "functionName";
        long expectedTotalSamples = 0;
        List<Call> expectedCalls =
        [
            new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
        ];

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedTotalSamples, model.TotalSamples);
        Assert.NotNull(model.Calls);
        Assert.Equal(expectedCalls.Count, model.Calls.Count);
        for (int i = 0; i < expectedCalls.Count; i++)
        {
            Assert.Equal(expectedCalls[i], model.Calls[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            FunctionName = "functionName",
            TotalSamples = 0,
            Calls =
            [
                new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            FunctionName = "functionName",
            TotalSamples = 0,
            Calls =
            [
                new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        long expectedTotalSamples = 0;
        List<Call> expectedCalls =
        [
            new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
        ];

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedTotalSamples, deserialized.TotalSamples);
        Assert.NotNull(deserialized.Calls);
        Assert.Equal(expectedCalls.Count, deserialized.Calls.Count);
        for (int i = 0; i < expectedCalls.Count; i++)
        {
            Assert.Equal(expectedCalls[i], deserialized.Calls[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            FunctionName = "functionName",
            TotalSamples = 0,
            Calls =
            [
                new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { FunctionName = "functionName", TotalSamples = 0 };

        Assert.Null(model.Calls);
        Assert.False(model.RawData.ContainsKey("calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result { FunctionName = "functionName", TotalSamples = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            FunctionName = "functionName",
            TotalSamples = 0,

            // Null should be interpreted as omitted for these properties
            Calls = null,
        };

        Assert.Null(model.Calls);
        Assert.False(model.RawData.ContainsKey("calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            FunctionName = "functionName",
            TotalSamples = 0,

            // Null should be interpreted as omitted for these properties
            Calls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            FunctionName = "functionName",
            TotalSamples = 0,
            Calls =
            [
                new() { CallID = "wc_sqF12lZ1VlBb", OriginalReferenceID = "originalReferenceID" },
            ],
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Call
        {
            CallID = "wc_sqF12lZ1VlBb",
            OriginalReferenceID = "originalReferenceID",
        };

        string expectedCallID = "wc_sqF12lZ1VlBb";
        string expectedOriginalReferenceID = "originalReferenceID";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedOriginalReferenceID, model.OriginalReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Call
        {
            CallID = "wc_sqF12lZ1VlBb",
            OriginalReferenceID = "originalReferenceID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Call>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Call
        {
            CallID = "wc_sqF12lZ1VlBb",
            OriginalReferenceID = "originalReferenceID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Call>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCallID = "wc_sqF12lZ1VlBb";
        string expectedOriginalReferenceID = "originalReferenceID";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedOriginalReferenceID, deserialized.OriginalReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Call
        {
            CallID = "wc_sqF12lZ1VlBb",
            OriginalReferenceID = "originalReferenceID",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Call
        {
            CallID = "wc_sqF12lZ1VlBb",
            OriginalReferenceID = "originalReferenceID",
        };

        Call copied = new(model);

        Assert.Equal(model, copied);
    }
}
