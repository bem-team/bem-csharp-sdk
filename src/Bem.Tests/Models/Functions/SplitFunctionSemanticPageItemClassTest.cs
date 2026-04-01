using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class SplitFunctionSemanticPageItemClassTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass
        {
            Name = "name",
            Description = "description",
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedNextFunctionID = "nextFunctionID";
        string expectedNextFunctionName = "nextFunctionName";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedNextFunctionID, model.NextFunctionID);
        Assert.Equal(expectedNextFunctionName, model.NextFunctionName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass
        {
            Name = "name",
            Description = "description",
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitFunctionSemanticPageItemClass>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass
        {
            Name = "name",
            Description = "description",
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitFunctionSemanticPageItemClass>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedNextFunctionID = "nextFunctionID";
        string expectedNextFunctionName = "nextFunctionName";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedNextFunctionID, deserialized.NextFunctionID);
        Assert.Equal(expectedNextFunctionName, deserialized.NextFunctionName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass
        {
            Name = "name",
            Description = "description",
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass { Name = "name" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
        Assert.Null(model.NextFunctionName);
        Assert.False(model.RawData.ContainsKey("nextFunctionName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            NextFunctionID = null,
            NextFunctionName = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.NextFunctionID);
        Assert.False(model.RawData.ContainsKey("nextFunctionID"));
        Assert.Null(model.NextFunctionName);
        Assert.False(model.RawData.ContainsKey("nextFunctionName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            NextFunctionID = null,
            NextFunctionName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitFunctionSemanticPageItemClass
        {
            Name = "name",
            Description = "description",
            NextFunctionID = "nextFunctionID",
            NextFunctionName = "nextFunctionName",
        };

        SplitFunctionSemanticPageItemClass copied = new(model);

        Assert.Equal(model, copied);
    }
}
