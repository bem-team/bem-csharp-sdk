using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowNodeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        FunctionVersionIdentifier expectedFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedName = "name";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedFunction, model.Function);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowNodeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowNodeResponse>(
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
        string expectedName = "name";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowNodeResponse
        {
            Function = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
            Name = "name",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        WorkflowNodeResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
