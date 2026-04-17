using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowEdgeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedDestinationNodeName = "destinationNodeName";
        string expectedSourceNodeName = "sourceNodeName";
        string expectedDestinationName = "destinationName";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedDestinationNodeName, model.DestinationNodeName);
        Assert.Equal(expectedSourceNodeName, model.SourceNodeName);
        Assert.Equal(expectedDestinationName, model.DestinationName);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowEdgeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowEdgeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDestinationNodeName = "destinationNodeName";
        string expectedSourceNodeName = "sourceNodeName";
        string expectedDestinationName = "destinationName";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedDestinationNodeName, deserialized.DestinationNodeName);
        Assert.Equal(expectedSourceNodeName, deserialized.SourceNodeName);
        Assert.Equal(expectedDestinationName, deserialized.DestinationName);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",

            // Null should be interpreted as omitted for these properties
            DestinationName = null,
            Metadata = null,
        };

        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destinationName"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",

            // Null should be interpreted as omitted for these properties
            DestinationName = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowEdgeResponse
        {
            DestinationNodeName = "destinationNodeName",
            SourceNodeName = "sourceNodeName",
            DestinationName = "destinationName",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        WorkflowEdgeResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
