using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        FunctionVersionIdentifier expectedFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";

        Assert.Equal(expectedFunction, model.Function);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FunctionVersionIdentifier expectedFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Name = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowNode
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        WorkflowNode copied = new(model);

        Assert.Equal(model, copied);
    }
}
