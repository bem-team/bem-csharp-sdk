using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionGetMetricsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionGetMetricsParams
        {
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = FunctionGetMetricsParamsSortOrder.Asc,
            StartingAfter = "startingAfter",
            Types = [FunctionType.Transform],
        };

        string expectedEndingBefore = "endingBefore";
        List<string> expectedFunctionIds = ["string"];
        List<string> expectedFunctionNames = ["string"];
        long expectedLimit = 1;
        ApiEnum<string, FunctionGetMetricsParamsSortOrder> expectedSortOrder =
            FunctionGetMetricsParamsSortOrder.Asc;
        string expectedStartingAfter = "startingAfter";
        List<ApiEnum<string, FunctionType>> expectedTypes = [FunctionType.Transform];

        Assert.Equal(expectedEndingBefore, parameters.EndingBefore);
        Assert.NotNull(parameters.FunctionIds);
        Assert.Equal(expectedFunctionIds.Count, parameters.FunctionIds.Count);
        for (int i = 0; i < expectedFunctionIds.Count; i++)
        {
            Assert.Equal(expectedFunctionIds[i], parameters.FunctionIds[i]);
        }
        Assert.NotNull(parameters.FunctionNames);
        Assert.Equal(expectedFunctionNames.Count, parameters.FunctionNames.Count);
        for (int i = 0; i < expectedFunctionNames.Count; i++)
        {
            Assert.Equal(expectedFunctionNames[i], parameters.FunctionNames[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSortOrder, parameters.SortOrder);
        Assert.Equal(expectedStartingAfter, parameters.StartingAfter);
        Assert.NotNull(parameters.Types);
        Assert.Equal(expectedTypes.Count, parameters.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], parameters.Types[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionGetMetricsParams { };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.FunctionIds);
        Assert.False(parameters.RawQueryData.ContainsKey("functionIDs"));
        Assert.Null(parameters.FunctionNames);
        Assert.False(parameters.RawQueryData.ContainsKey("functionNames"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.SortOrder);
        Assert.False(parameters.RawQueryData.ContainsKey("sortOrder"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionGetMetricsParams
        {
            // Null should be interpreted as omitted for these properties
            EndingBefore = null,
            FunctionIds = null,
            FunctionNames = null,
            Limit = null,
            SortOrder = null,
            StartingAfter = null,
            Types = null,
        };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.FunctionIds);
        Assert.False(parameters.RawQueryData.ContainsKey("functionIDs"));
        Assert.Null(parameters.FunctionNames);
        Assert.False(parameters.RawQueryData.ContainsKey("functionNames"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.SortOrder);
        Assert.False(parameters.RawQueryData.ContainsKey("sortOrder"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionGetMetricsParams parameters = new()
        {
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = FunctionGetMetricsParamsSortOrder.Asc,
            StartingAfter = "startingAfter",
            Types = [FunctionType.Transform],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/functions/metrics?endingBefore=endingBefore&functionIDs=string&functionNames=string&limit=1&sortOrder=asc&startingAfter=startingAfter&types=transform"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionGetMetricsParams
        {
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = FunctionGetMetricsParamsSortOrder.Asc,
            StartingAfter = "startingAfter",
            Types = [FunctionType.Transform],
        };

        FunctionGetMetricsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FunctionGetMetricsParamsSortOrderTest : TestBase
{
    [Theory]
    [InlineData(FunctionGetMetricsParamsSortOrder.Asc)]
    [InlineData(FunctionGetMetricsParamsSortOrder.Desc)]
    public void Validation_Works(FunctionGetMetricsParamsSortOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionGetMetricsParamsSortOrder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionGetMetricsParamsSortOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionGetMetricsParamsSortOrder.Asc)]
    [InlineData(FunctionGetMetricsParamsSortOrder.Desc)]
    public void SerializationRoundtrip_Works(FunctionGetMetricsParamsSortOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionGetMetricsParamsSortOrder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionGetMetricsParamsSortOrder>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FunctionGetMetricsParamsSortOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionGetMetricsParamsSortOrder>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
