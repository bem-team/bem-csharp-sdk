using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Outputs;

namespace Bem.Tests.Models.Outputs;

public class OutputListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OutputListParams
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            EventIds = ["string"],
            EventTypes = ["string"],
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            FunctionVersionNums = [0],
            IncludeIntermediate = true,
            IsLabelled = true,
            IsRegression = true,
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            TransformationIds = ["string"],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        List<string> expectedCallIds = ["string"];
        string expectedEndingBefore = "endingBefore";
        List<string> expectedEventIds = ["string"];
        List<string> expectedEventTypes = ["string"];
        List<string> expectedFunctionIds = ["string"];
        List<string> expectedFunctionNames = ["string"];
        List<long> expectedFunctionVersionNums = [0];
        bool expectedIncludeIntermediate = true;
        bool expectedIsLabelled = true;
        bool expectedIsRegression = true;
        long expectedLimit = 1;
        List<string> expectedReferenceIds = ["string"];
        string expectedReferenceIDSubstring = "referenceIDSubstring";
        ApiEnum<string, SortOrder> expectedSortOrder = SortOrder.Asc;
        string expectedStartingAfter = "startingAfter";
        List<string> expectedTransformationIds = ["string"];
        List<string> expectedWorkflowIds = ["string"];
        List<string> expectedWorkflowNames = ["string"];

        Assert.NotNull(parameters.CallIds);
        Assert.Equal(expectedCallIds.Count, parameters.CallIds.Count);
        for (int i = 0; i < expectedCallIds.Count; i++)
        {
            Assert.Equal(expectedCallIds[i], parameters.CallIds[i]);
        }
        Assert.Equal(expectedEndingBefore, parameters.EndingBefore);
        Assert.NotNull(parameters.EventIds);
        Assert.Equal(expectedEventIds.Count, parameters.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], parameters.EventIds[i]);
        }
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
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
        Assert.NotNull(parameters.FunctionVersionNums);
        Assert.Equal(expectedFunctionVersionNums.Count, parameters.FunctionVersionNums.Count);
        for (int i = 0; i < expectedFunctionVersionNums.Count; i++)
        {
            Assert.Equal(expectedFunctionVersionNums[i], parameters.FunctionVersionNums[i]);
        }
        Assert.Equal(expectedIncludeIntermediate, parameters.IncludeIntermediate);
        Assert.Equal(expectedIsLabelled, parameters.IsLabelled);
        Assert.Equal(expectedIsRegression, parameters.IsRegression);
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
        Assert.NotNull(parameters.TransformationIds);
        Assert.Equal(expectedTransformationIds.Count, parameters.TransformationIds.Count);
        for (int i = 0; i < expectedTransformationIds.Count; i++)
        {
            Assert.Equal(expectedTransformationIds[i], parameters.TransformationIds[i]);
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
        var parameters = new OutputListParams { };

        Assert.Null(parameters.CallIds);
        Assert.False(parameters.RawQueryData.ContainsKey("callIDs"));
        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.EventIds);
        Assert.False(parameters.RawQueryData.ContainsKey("eventIDs"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("eventTypes"));
        Assert.Null(parameters.FunctionIds);
        Assert.False(parameters.RawQueryData.ContainsKey("functionIDs"));
        Assert.Null(parameters.FunctionNames);
        Assert.False(parameters.RawQueryData.ContainsKey("functionNames"));
        Assert.Null(parameters.FunctionVersionNums);
        Assert.False(parameters.RawQueryData.ContainsKey("functionVersionNums"));
        Assert.Null(parameters.IncludeIntermediate);
        Assert.False(parameters.RawQueryData.ContainsKey("includeIntermediate"));
        Assert.Null(parameters.IsLabelled);
        Assert.False(parameters.RawQueryData.ContainsKey("isLabelled"));
        Assert.Null(parameters.IsRegression);
        Assert.False(parameters.RawQueryData.ContainsKey("isRegression"));
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
        Assert.Null(parameters.TransformationIds);
        Assert.False(parameters.RawQueryData.ContainsKey("transformationIDs"));
        Assert.Null(parameters.WorkflowIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowIDs"));
        Assert.Null(parameters.WorkflowNames);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowNames"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new OutputListParams
        {
            // Null should be interpreted as omitted for these properties
            CallIds = null,
            EndingBefore = null,
            EventIds = null,
            EventTypes = null,
            FunctionIds = null,
            FunctionNames = null,
            FunctionVersionNums = null,
            IncludeIntermediate = null,
            IsLabelled = null,
            IsRegression = null,
            Limit = null,
            ReferenceIds = null,
            ReferenceIDSubstring = null,
            SortOrder = null,
            StartingAfter = null,
            TransformationIds = null,
            WorkflowIds = null,
            WorkflowNames = null,
        };

        Assert.Null(parameters.CallIds);
        Assert.False(parameters.RawQueryData.ContainsKey("callIDs"));
        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.EventIds);
        Assert.False(parameters.RawQueryData.ContainsKey("eventIDs"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("eventTypes"));
        Assert.Null(parameters.FunctionIds);
        Assert.False(parameters.RawQueryData.ContainsKey("functionIDs"));
        Assert.Null(parameters.FunctionNames);
        Assert.False(parameters.RawQueryData.ContainsKey("functionNames"));
        Assert.Null(parameters.FunctionVersionNums);
        Assert.False(parameters.RawQueryData.ContainsKey("functionVersionNums"));
        Assert.Null(parameters.IncludeIntermediate);
        Assert.False(parameters.RawQueryData.ContainsKey("includeIntermediate"));
        Assert.Null(parameters.IsLabelled);
        Assert.False(parameters.RawQueryData.ContainsKey("isLabelled"));
        Assert.Null(parameters.IsRegression);
        Assert.False(parameters.RawQueryData.ContainsKey("isRegression"));
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
        Assert.Null(parameters.TransformationIds);
        Assert.False(parameters.RawQueryData.ContainsKey("transformationIDs"));
        Assert.Null(parameters.WorkflowIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowIDs"));
        Assert.Null(parameters.WorkflowNames);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowNames"));
    }

    [Fact]
    public void Url_Works()
    {
        OutputListParams parameters = new()
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            EventIds = ["string"],
            EventTypes = ["string"],
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            FunctionVersionNums = [0],
            IncludeIntermediate = true,
            IsLabelled = true,
            IsRegression = true,
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            TransformationIds = ["string"],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/outputs?callIDs=string&endingBefore=endingBefore&eventIDs=string&eventTypes=string&functionIDs=string&functionNames=string&functionVersionNums=0&includeIntermediate=true&isLabelled=true&isRegression=true&limit=1&referenceIDs=string&referenceIDSubstring=referenceIDSubstring&sortOrder=asc&startingAfter=startingAfter&transformationIDs=string&workflowIDs=string&workflowNames=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OutputListParams
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            EventIds = ["string"],
            EventTypes = ["string"],
            FunctionIds = ["string"],
            FunctionNames = ["string"],
            FunctionVersionNums = [0],
            IncludeIntermediate = true,
            IsLabelled = true,
            IsRegression = true,
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            TransformationIds = ["string"],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        OutputListParams copied = new(parameters);

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
