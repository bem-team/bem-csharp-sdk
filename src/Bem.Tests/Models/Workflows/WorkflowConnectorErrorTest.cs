using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowConnectorErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,
            ConnectorID = "connectorID",
            Name = "name",
        };

        string expectedCode = "code";
        string expectedMessage = "message";
        ApiEnum<string, Operation> expectedOperation = Operation.Create;
        string expectedConnectorID = "connectorID";
        string expectedName = "name";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedOperation, model.Operation);
        Assert.Equal(expectedConnectorID, model.ConnectorID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,
            ConnectorID = "connectorID",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnectorError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,
            ConnectorID = "connectorID",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowConnectorError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        string expectedMessage = "message";
        ApiEnum<string, Operation> expectedOperation = Operation.Create;
        string expectedConnectorID = "connectorID";
        string expectedName = "name";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedOperation, deserialized.Operation);
        Assert.Equal(expectedConnectorID, deserialized.ConnectorID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,
            ConnectorID = "connectorID",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,
        };

        Assert.Null(model.ConnectorID);
        Assert.False(model.RawData.ContainsKey("connectorID"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,

            // Null should be interpreted as omitted for these properties
            ConnectorID = null,
            Name = null,
        };

        Assert.Null(model.ConnectorID);
        Assert.False(model.RawData.ContainsKey("connectorID"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,

            // Null should be interpreted as omitted for these properties
            ConnectorID = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowConnectorError
        {
            Code = "code",
            Message = "message",
            Operation = Operation.Create,
            ConnectorID = "connectorID",
            Name = "name",
        };

        WorkflowConnectorError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OperationTest : TestBase
{
    [Theory]
    [InlineData(Operation.Create)]
    [InlineData(Operation.Update)]
    [InlineData(Operation.Delete)]
    public void Validation_Works(Operation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operation.Create)]
    [InlineData(Operation.Update)]
    [InlineData(Operation.Delete)]
    public void SerializationRoundtrip_Works(Operation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
