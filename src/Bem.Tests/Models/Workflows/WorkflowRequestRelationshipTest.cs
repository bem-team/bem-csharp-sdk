using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowRequestRelationshipTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowRequestRelationship
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
        };

        FunctionVersionIdentifier expectedDestinationFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        FunctionVersionIdentifier expectedSourceFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedDestinationName = "destinationName";

        Assert.Equal(expectedDestinationFunction, model.DestinationFunction);
        Assert.Equal(expectedSourceFunction, model.SourceFunction);
        Assert.Equal(expectedDestinationName, model.DestinationName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowRequestRelationship
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowRequestRelationship>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowRequestRelationship
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowRequestRelationship>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FunctionVersionIdentifier expectedDestinationFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        FunctionVersionIdentifier expectedSourceFunction = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };
        string expectedDestinationName = "destinationName";

        Assert.Equal(expectedDestinationFunction, deserialized.DestinationFunction);
        Assert.Equal(expectedSourceFunction, deserialized.SourceFunction);
        Assert.Equal(expectedDestinationName, deserialized.DestinationName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowRequestRelationship
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowRequestRelationship
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
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowRequestRelationship
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowRequestRelationship
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

            // Null should be interpreted as omitted for these properties
            DestinationName = null,
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowRequestRelationship
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

            // Null should be interpreted as omitted for these properties
            DestinationName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowRequestRelationship
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
        };

        WorkflowRequestRelationship copied = new(model);

        Assert.Equal(model, copied);
    }
}
