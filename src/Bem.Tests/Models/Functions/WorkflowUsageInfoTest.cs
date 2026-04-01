using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class WorkflowUsageInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowUsageInfo
        {
            CurrentVersionNum = 0,
            UsedInWorkflowVersionNums = [0],
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        long expectedCurrentVersionNum = 0;
        List<long> expectedUsedInWorkflowVersionNums = [0];
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";

        Assert.Equal(expectedCurrentVersionNum, model.CurrentVersionNum);
        Assert.Equal(
            expectedUsedInWorkflowVersionNums.Count,
            model.UsedInWorkflowVersionNums.Count
        );
        for (int i = 0; i < expectedUsedInWorkflowVersionNums.Count; i++)
        {
            Assert.Equal(expectedUsedInWorkflowVersionNums[i], model.UsedInWorkflowVersionNums[i]);
        }
        Assert.Equal(expectedWorkflowID, model.WorkflowID);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowUsageInfo
        {
            CurrentVersionNum = 0,
            UsedInWorkflowVersionNums = [0],
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUsageInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowUsageInfo
        {
            CurrentVersionNum = 0,
            UsedInWorkflowVersionNums = [0],
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowUsageInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCurrentVersionNum = 0;
        List<long> expectedUsedInWorkflowVersionNums = [0];
        string expectedWorkflowID = "workflowID";
        string expectedWorkflowName = "workflowName";

        Assert.Equal(expectedCurrentVersionNum, deserialized.CurrentVersionNum);
        Assert.Equal(
            expectedUsedInWorkflowVersionNums.Count,
            deserialized.UsedInWorkflowVersionNums.Count
        );
        for (int i = 0; i < expectedUsedInWorkflowVersionNums.Count; i++)
        {
            Assert.Equal(
                expectedUsedInWorkflowVersionNums[i],
                deserialized.UsedInWorkflowVersionNums[i]
            );
        }
        Assert.Equal(expectedWorkflowID, deserialized.WorkflowID);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowUsageInfo
        {
            CurrentVersionNum = 0,
            UsedInWorkflowVersionNums = [0],
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowUsageInfo
        {
            CurrentVersionNum = 0,
            UsedInWorkflowVersionNums = [0],
            WorkflowID = "workflowID",
            WorkflowName = "workflowName",
        };

        WorkflowUsageInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
