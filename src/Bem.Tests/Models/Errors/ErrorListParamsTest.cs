using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Errors;

namespace Bem.Tests.Models.Errors;

public class ErrorListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ErrorListParams
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        List<string> expectedCallIds = ["string"];
        string expectedEndingBefore = "endingBefore";
        List<string> expectedFunctionIds = ["string"];
        List<string> expectedFunctionNames = ["string"];
        long expectedLimit = 1;
        List<string> expectedReferenceIds = ["string"];
        string expectedReferenceIDSubstring = "referenceIDSubstring";
        ApiEnum<string, SortOrder> expectedSortOrder = SortOrder.Asc;
        string expectedStartingAfter = "startingAfter";
        List<string> expectedWorkflowIds = ["string"];
        List<string> expectedWorkflowNames = ["string"];

        Assert.NotNull(parameters.CallIds);
        Assert.Equal(expectedCallIds.Count, parameters.CallIds.Count);
        for (int i = 0; i < expectedCallIds.Count; i++)
        {
            Assert.Equal(expectedCallIds[i], parameters.CallIds[i]);
        }
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
        Assert.NotNull(parameters.ReferenceIds);
        Assert.Equal(expectedReferenceIds.Count, parameters.ReferenceIds.Count);
        for (int i = 0; i < expectedReferenceIds.Count; i++)
        {
            Assert.Equal(expectedReferenceIds[i], parameters.ReferenceIds[i]);
        }
        Assert.Equal(expectedReferenceIDSubstring, parameters.ReferenceIDSubstring);
        Assert.Equal(expectedSortOrder, parameters.SortOrder);
        Assert.Equal(expectedStartingAfter, parameters.StartingAfter);
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
        var parameters = new ErrorListParams { };

        Assert.Null(parameters.CallIds);
        Assert.False(parameters.RawQueryData.ContainsKey("callIDs"));
        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.FunctionIds);
        Assert.False(parameters.RawQueryData.ContainsKey("functionIDs"));
        Assert.Null(parameters.FunctionNames);
        Assert.False(parameters.RawQueryData.ContainsKey("functionNames"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ReferenceIds);
        Assert.False(parameters.RawQueryData.ContainsKey("referenceIDs"));
        Assert.Null(parameters.ReferenceIDSubstring);
        Assert.False(parameters.RawQueryData.ContainsKey("referenceIDSubstring"));
        Assert.Null(parameters.SortOrder);
        Assert.False(parameters.RawQueryData.ContainsKey("sortOrder"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
        Assert.Null(parameters.WorkflowIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowIDs"));
        Assert.Null(parameters.WorkflowNames);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowNames"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ErrorListParams
        {
            // Null should be interpreted as omitted for these properties
            CallIds = null,
            EndingBefore = null,
            FunctionIds = null,
            FunctionNames = null,
            Limit = null,
            ReferenceIds = null,
            ReferenceIDSubstring = null,
            SortOrder = null,
            StartingAfter = null,
            WorkflowIds = null,
            WorkflowNames = null,
        };

        Assert.Null(parameters.CallIds);
        Assert.False(parameters.RawQueryData.ContainsKey("callIDs"));
        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.FunctionIds);
        Assert.False(parameters.RawQueryData.ContainsKey("functionIDs"));
        Assert.Null(parameters.FunctionNames);
        Assert.False(parameters.RawQueryData.ContainsKey("functionNames"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ReferenceIds);
        Assert.False(parameters.RawQueryData.ContainsKey("referenceIDs"));
        Assert.Null(parameters.ReferenceIDSubstring);
        Assert.False(parameters.RawQueryData.ContainsKey("referenceIDSubstring"));
        Assert.Null(parameters.SortOrder);
        Assert.False(parameters.RawQueryData.ContainsKey("sortOrder"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
        Assert.Null(parameters.WorkflowIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowIDs"));
        Assert.Null(parameters.WorkflowNames);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowNames"));
    }

    [Fact]
    public void Url_Works()
    {
        ErrorListParams parameters = new()
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/errors?callIDs=string&endingBefore=endingBefore&functionIDs=string&functionNames=string&limit=1&referenceIDs=string&referenceIDSubstring=referenceIDSubstring&sortOrder=asc&startingAfter=startingAfter&workflowIDs=string&workflowNames=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ErrorListParams
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        ErrorListParams copied = new(parameters);

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
