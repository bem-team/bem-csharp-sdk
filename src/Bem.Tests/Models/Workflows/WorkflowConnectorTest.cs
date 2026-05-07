using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowConnectorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowConnector
        {
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        string expectedName = "name";
        ApiEnum<string, WorkflowConnectorType> expectedType = WorkflowConnectorType.Paragon;
        string expectedConnectorID = "connectorID";
        WorkflowConnectorParagon expectedParagon = new()
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedConnectorID, model.ConnectorID);
        Assert.Equal(expectedParagon, model.Paragon);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowConnector
        {
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnector>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowConnector
        {
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnector>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        ApiEnum<string, WorkflowConnectorType> expectedType = WorkflowConnectorType.Paragon;
        string expectedConnectorID = "connectorID";
        WorkflowConnectorParagon expectedParagon = new()
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedConnectorID, deserialized.ConnectorID);
        Assert.Equal(expectedParagon, deserialized.Paragon);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowConnector
        {
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowConnector { Name = "name", Type = WorkflowConnectorType.Paragon };

        Assert.Null(model.ConnectorID);
        Assert.False(model.RawData.ContainsKey("connectorID"));
        Assert.Null(model.Paragon);
        Assert.False(model.RawData.ContainsKey("paragon"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowConnector { Name = "name", Type = WorkflowConnectorType.Paragon };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowConnector
        {
            Name = "name",
            Type = WorkflowConnectorType.Paragon,

            // Null should be interpreted as omitted for these properties
            ConnectorID = null,
            Paragon = null,
        };

        Assert.Null(model.ConnectorID);
        Assert.False(model.RawData.ContainsKey("connectorID"));
        Assert.Null(model.Paragon);
        Assert.False(model.RawData.ContainsKey("paragon"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowConnector
        {
            Name = "name",
            Type = WorkflowConnectorType.Paragon,

            // Null should be interpreted as omitted for these properties
            ConnectorID = null,
            Paragon = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowConnector
        {
            Name = "name",
            Type = WorkflowConnectorType.Paragon,
            ConnectorID = "connectorID",
            Paragon = new()
            {
                Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
                Integration = "integration",
            },
        };

        WorkflowConnector copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowConnectorParagonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        JsonElement expectedConfiguration = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedIntegration = "integration";

        Assert.NotNull(model.Configuration);
        Assert.True(JsonElement.DeepEquals(expectedConfiguration, model.Configuration.Value));
        Assert.Equal(expectedIntegration, model.Integration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnectorParagon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnectorParagon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedConfiguration = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedIntegration = "integration";

        Assert.NotNull(deserialized.Configuration);
        Assert.True(
            JsonElement.DeepEquals(expectedConfiguration, deserialized.Configuration.Value)
        );
        Assert.Equal(expectedIntegration, deserialized.Integration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowConnectorParagon { };

        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.Integration);
        Assert.False(model.RawData.ContainsKey("integration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowConnectorParagon { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            // Null should be interpreted as omitted for these properties
            Configuration = null,
            Integration = null,
        };

        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.Integration);
        Assert.False(model.RawData.ContainsKey("integration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            // Null should be interpreted as omitted for these properties
            Configuration = null,
            Integration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowConnectorParagon
        {
            Configuration = JsonSerializer.Deserialize<JsonElement>("{}"),
            Integration = "integration",
        };

        WorkflowConnectorParagon copied = new(model);

        Assert.Equal(model, copied);
    }
}
