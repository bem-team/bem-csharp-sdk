using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ViewListParams
        {
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            ViewIds = ["string"],
            ViewNameSubstring = "viewNameSubstring",
        };

        string expectedEndingBefore = "endingBefore";
        List<string> expectedFunctionIds = ["string"];
        List<string> expectedFunctionNames = ["string"];
        long expectedLimit = 1;
        ApiEnum<string, SortOrder> expectedSortOrder = SortOrder.Asc;
        string expectedStartingAfter = "startingAfter";
        List<string> expectedViewIds = ["string"];
        string expectedViewNameSubstring = "viewNameSubstring";

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
        Assert.NotNull(parameters.ViewIds);
        Assert.Equal(expectedViewIds.Count, parameters.ViewIds.Count);
        for (int i = 0; i < expectedViewIds.Count; i++)
        {
            Assert.Equal(expectedViewIds[i], parameters.ViewIds[i]);
        }
        Assert.Equal(expectedViewNameSubstring, parameters.ViewNameSubstring);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ViewListParams { };

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
        Assert.Null(parameters.ViewIds);
        Assert.False(parameters.RawQueryData.ContainsKey("viewIDs"));
        Assert.Null(parameters.ViewNameSubstring);
        Assert.False(parameters.RawQueryData.ContainsKey("viewNameSubstring"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ViewListParams
        {
            // Null should be interpreted as omitted for these properties
            EndingBefore = null,
            FunctionIds = null,
            FunctionNames = null,
            Limit = null,
            SortOrder = null,
            StartingAfter = null,
            ViewIds = null,
            ViewNameSubstring = null,
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
        Assert.Null(parameters.ViewIds);
        Assert.False(parameters.RawQueryData.ContainsKey("viewIDs"));
        Assert.Null(parameters.ViewNameSubstring);
        Assert.False(parameters.RawQueryData.ContainsKey("viewNameSubstring"));
    }

    [Fact]
    public void Url_Works()
    {
        ViewListParams parameters = new()
        {
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            ViewIds = ["string"],
            ViewNameSubstring = "viewNameSubstring",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/views?endingBefore=endingBefore&functionIDs=string&functionNames=string&limit=1&sortOrder=asc&startingAfter=startingAfter&viewIDs=string&viewNameSubstring=viewNameSubstring"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ViewListParams
        {
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            ViewIds = ["string"],
            ViewNameSubstring = "viewNameSubstring",
        };

        ViewListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SortOrderTest : TestBase
{
    [Theory]
    [InlineData(SortOrder.Asc)]
    [InlineData(SortOrder.Desc)]
    public void Validation_Works(SortOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortOrder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortOrder.Asc)]
    [InlineData(SortOrder.Desc)]
    public void SerializationRoundtrip_Works(SortOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortOrder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
