using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowDeleteResponse
        {
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        List<WorkflowConnectorError> expectedConnectorErrors =
        [
            new()
            {
                Code = "code",
                Message = "message",
                Operation = Operation.Create,
                ConnectorID = "connectorID",
                Name = "name",
            },
        ];
        string expectedError = "error";
        WorkflowDeleteResponseWorkflow expectedWorkflow = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        Assert.NotNull(model.ConnectorErrors);
        Assert.Equal(expectedConnectorErrors.Count, model.ConnectorErrors.Count);
        for (int i = 0; i < expectedConnectorErrors.Count; i++)
        {
            Assert.Equal(expectedConnectorErrors[i], model.ConnectorErrors[i]);
        }
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedWorkflow, model.Workflow);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowDeleteResponse
        {
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowDeleteResponse
        {
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WorkflowConnectorError> expectedConnectorErrors =
        [
            new()
            {
                Code = "code",
                Message = "message",
                Operation = Operation.Create,
                ConnectorID = "connectorID",
                Name = "name",
            },
        ];
        string expectedError = "error";
        WorkflowDeleteResponseWorkflow expectedWorkflow = new()
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        Assert.NotNull(deserialized.ConnectorErrors);
        Assert.Equal(expectedConnectorErrors.Count, deserialized.ConnectorErrors.Count);
        for (int i = 0; i < expectedConnectorErrors.Count; i++)
        {
            Assert.Equal(expectedConnectorErrors[i], deserialized.ConnectorErrors[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedWorkflow, deserialized.Workflow);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowDeleteResponse
        {
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkflowDeleteResponse { };

        Assert.Null(model.ConnectorErrors);
        Assert.False(model.RawData.ContainsKey("connectorErrors"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Workflow);
        Assert.False(model.RawData.ContainsKey("workflow"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkflowDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WorkflowDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            ConnectorErrors = null,
            Error = null,
            Workflow = null,
        };

        Assert.Null(model.ConnectorErrors);
        Assert.False(model.RawData.ContainsKey("connectorErrors"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Workflow);
        Assert.False(model.RawData.ContainsKey("workflow"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkflowDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            ConnectorErrors = null,
            Error = null,
            Workflow = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowDeleteResponse
        {
            ConnectorErrors =
            [
                new()
                {
                    Code = "code",
                    Message = "message",
                    Operation = Operation.Create,
                    ConnectorID = "connectorID",
                    Name = "name",
                },
            ],
            Error = "error",
            Workflow = new()
            {
                ID = "id",
                Name = "name",
                VersionNum = 0,
            },
        };

        WorkflowDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkflowDeleteResponseWorkflowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkflowDeleteResponseWorkflow
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        string expectedID = "id";
        string expectedName = "name";
        long expectedVersionNum = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedVersionNum, model.VersionNum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkflowDeleteResponseWorkflow
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowDeleteResponseWorkflow>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkflowDeleteResponseWorkflow
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkflowDeleteResponseWorkflow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        long expectedVersionNum = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedVersionNum, deserialized.VersionNum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkflowDeleteResponseWorkflow
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkflowDeleteResponseWorkflow
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        WorkflowDeleteResponseWorkflow copied = new(model);

        Assert.Equal(model, copied);
    }
}
