using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionListParams
        {
            DisplayName = "displayName",
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            Tags = ["string"],
            Types = [FunctionType.Transform],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        string expectedDisplayName = "displayName";
        string expectedEndingBefore = "endingBefore";
        List<string> expectedFunctionIds = ["string"];
        List<string> expectedFunctionNames = ["string"];
        long expectedLimit = 1;
        ApiEnum<string, SortOrder> expectedSortOrder = SortOrder.Asc;
        string expectedStartingAfter = "startingAfter";
        List<string> expectedTags = ["string"];
        List<ApiEnum<string, FunctionType>> expectedTypes = [FunctionType.Transform];
        List<string> expectedWorkflowIds = ["string"];
        List<string> expectedWorkflowNames = ["string"];

        Assert.Equal(expectedDisplayName, parameters.DisplayName);
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
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
        Assert.NotNull(parameters.Types);
        Assert.Equal(expectedTypes.Count, parameters.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], parameters.Types[i]);
        }
        Assert.NotNull(parameters.WorkflowIds);
        Assert.Equal(expectedWorkflowIds.Count, parameters.WorkflowIds.Count);
        for (int i = 0; i < expectedWorkflowIds.Count; i++)
        {
            Assert.Equal(expectedWorkflowIds[i], parameters.WorkflowIds[i]);
        }
        Assert.NotNull(parameters.WorkflowNames);
        Assert.Equal(expectedWorkflowNames.Count, parameters.WorkflowNames.Count);
        for (int i = 0; i < expectedWorkflowNames.Count; i++)
        {
            Assert.Equal(expectedWorkflowNames[i], parameters.WorkflowNames[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionListParams { };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawQueryData.ContainsKey("displayName"));
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
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
        Assert.Null(parameters.WorkflowIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowIDs"));
        Assert.Null(parameters.WorkflowNames);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowNames"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionListParams
        {
            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            EndingBefore = null,
            FunctionIds = null,
            FunctionNames = null,
            Limit = null,
            SortOrder = null,
            StartingAfter = null,
            Tags = null,
            Types = null,
            WorkflowIds = null,
            WorkflowNames = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawQueryData.ContainsKey("displayName"));
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
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
        Assert.Null(parameters.WorkflowIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowIDs"));
        Assert.Null(parameters.WorkflowNames);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowNames"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionListParams parameters = new()
        {
            DisplayName = "displayName",
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            Tags = ["string"],
            Types = [FunctionType.Transform],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.bem.ai/v3/functions?displayName=displayName&endingBefore=endingBefore&functionIDs=string&functionNames=string&limit=1&sortOrder=asc&startingAfter=startingAfter&tags=string&types=transform&workflowIDs=string&workflowNames=string"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionListParams
        {
            DisplayName = "displayName",
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            Tags = ["string"],
            Types = [FunctionType.Transform],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        FunctionListParams copied = new(parameters);

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
