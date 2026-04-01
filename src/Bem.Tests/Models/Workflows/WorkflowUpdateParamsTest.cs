using System;
using System.Collections.Generic;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkflowUpdateParams
        {
            WorkflowName = "workflowName",
            DisplayName = "displayName",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            Relationships =
            [
                new()
                {
                    DestinationFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    SourceFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    DestinationName = "destinationName",
                },
            ],
            Tags = ["string"],
        };

        string expectedWorkflowName = "workflowName";
        string expectedDisplayName = "displayName";
        FunctionVersionIdentifier expectedMainFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedName = "name";
        List<WorkflowRequestRelationship> expectedRelationships =
        [
            new()
            {
                DestinationFunction = new()
                {
                    ID = "id",
                    Name = "name",
                    VersionNum = 0,
                },
                SourceFunction = new()
                {
                    ID = "id",
                    Name = "name",
                    VersionNum = 0,
                },
                DestinationName = "destinationName",
            },
        ];
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedMainFunction, parameters.MainFunction);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Relationships);
        Assert.Equal(expectedRelationships.Count, parameters.Relationships.Count);
        for (int i = 0; i < expectedRelationships.Count; i++)
        {
            Assert.Equal(expectedRelationships[i], parameters.Relationships[i]);
        }
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkflowUpdateParams { WorkflowName = "workflowName" };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.MainFunction);
        Assert.False(parameters.RawBodyData.ContainsKey("mainFunction"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Relationships);
        Assert.False(parameters.RawBodyData.ContainsKey("relationships"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkflowUpdateParams
        {
            WorkflowName = "workflowName",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            MainFunction = null,
            Name = null,
            Relationships = null,
            Tags = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.MainFunction);
        Assert.False(parameters.RawBodyData.ContainsKey("mainFunction"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Relationships);
        Assert.False(parameters.RawBodyData.ContainsKey("relationships"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkflowUpdateParams parameters = new() { WorkflowName = "workflowName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/workflows/workflowName"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkflowUpdateParams
        {
            WorkflowName = "workflowName",
            DisplayName = "displayName",
            MainFunction = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            Relationships =
            [
                new()
                {
                    DestinationFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    SourceFunction = new()
                    {
                        ID = "id",
                        Name = "name",
                        VersionNum = 0,
                    },
                    DestinationName = "destinationName",
                },
            ],
            Tags = ["string"],
        };

        WorkflowUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
