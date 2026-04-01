using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Calls;

namespace Bem.Tests.Models.Calls;

public class CallListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallListParams
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            Statuses = [Status.Pending],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        List<string> expectedCallIds = ["string"];
        string expectedEndingBefore = "endingBefore";
        long expectedLimit = 1;
        List<string> expectedReferenceIds = ["string"];
        string expectedReferenceIDSubstring = "referenceIDSubstring";
        ApiEnum<string, SortOrder> expectedSortOrder = SortOrder.Asc;
        string expectedStartingAfter = "startingAfter";
        List<ApiEnum<string, Status>> expectedStatuses = [Status.Pending];
        List<string> expectedWorkflowIds = ["string"];
        List<string> expectedWorkflowNames = ["string"];

        Assert.NotNull(parameters.CallIds);
        Assert.Equal(expectedCallIds.Count, parameters.CallIds.Count);
        for (int i = 0; i < expectedCallIds.Count; i++)
        {
            Assert.Equal(expectedCallIds[i], parameters.CallIds[i]);
        }
        Assert.Equal(expectedEndingBefore, parameters.EndingBefore);
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
        Assert.NotNull(parameters.Statuses);
        Assert.Equal(expectedStatuses.Count, parameters.Statuses.Count);
        for (int i = 0; i < expectedStatuses.Count; i++)
        {
            Assert.Equal(expectedStatuses[i], parameters.Statuses[i]);
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
        var parameters = new CallListParams { };

        Assert.Null(parameters.CallIds);
        Assert.False(parameters.RawQueryData.ContainsKey("callIDs"));
        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
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
        Assert.Null(parameters.Statuses);
        Assert.False(parameters.RawQueryData.ContainsKey("statuses"));
        Assert.Null(parameters.WorkflowIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowIDs"));
        Assert.Null(parameters.WorkflowNames);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowNames"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CallListParams
        {
            // Null should be interpreted as omitted for these properties
            CallIds = null,
            EndingBefore = null,
            Limit = null,
            ReferenceIds = null,
            ReferenceIDSubstring = null,
            SortOrder = null,
            StartingAfter = null,
            Statuses = null,
            WorkflowIds = null,
            WorkflowNames = null,
        };

        Assert.Null(parameters.CallIds);
        Assert.False(parameters.RawQueryData.ContainsKey("callIDs"));
        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
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
        Assert.Null(parameters.Statuses);
        Assert.False(parameters.RawQueryData.ContainsKey("statuses"));
        Assert.Null(parameters.WorkflowIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowIDs"));
        Assert.Null(parameters.WorkflowNames);
        Assert.False(parameters.RawQueryData.ContainsKey("workflowNames"));
    }

    [Fact]
    public void Url_Works()
    {
        CallListParams parameters = new()
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            Statuses = [Status.Pending],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.bem.ai/v3/calls?callIDs=string&endingBefore=endingBefore&limit=1&referenceIDs=string&referenceIDSubstring=referenceIDSubstring&sortOrder=asc&startingAfter=startingAfter&statuses=pending&workflowIDs=string&workflowNames=string"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CallListParams
        {
            CallIds = ["string"],
            EndingBefore = "endingBefore",
            Limit = 1,
            ReferenceIds = ["string"],
            ReferenceIDSubstring = "referenceIDSubstring",
            SortOrder = SortOrder.Asc,
            StartingAfter = "startingAfter",
            Statuses = [Status.Pending],
            WorkflowIds = ["string"],
            WorkflowNames = ["string"],
        };

        CallListParams copied = new(parameters);

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

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
