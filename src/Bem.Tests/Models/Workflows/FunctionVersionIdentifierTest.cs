using System.Text.Json;
using Bem.Core;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class FunctionVersionIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionVersionIdentifier
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
        var model = new FunctionVersionIdentifier
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionVersionIdentifier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionVersionIdentifier
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionVersionIdentifier>(
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
        var model = new FunctionVersionIdentifier
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionVersionIdentifier { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.VersionNum);
        Assert.False(model.RawData.ContainsKey("versionNum"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionVersionIdentifier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionVersionIdentifier
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
            VersionNum = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.VersionNum);
        Assert.False(model.RawData.ContainsKey("versionNum"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionVersionIdentifier
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
            VersionNum = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionVersionIdentifier
        {
            ID = "id",
            Name = "name",
            VersionNum = 0,
        };

        FunctionVersionIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}
