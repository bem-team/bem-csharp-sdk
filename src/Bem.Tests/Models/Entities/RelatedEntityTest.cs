using System.Text.Json;
using Bem.Core;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class RelatedEntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RelatedEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string expectedID = "id";
        string expectedCanonical = "canonical";
        int expectedDepth = 0;
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCanonical, model.Canonical);
        Assert.Equal(expectedDepth, model.Depth);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RelatedEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RelatedEntity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RelatedEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RelatedEntity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCanonical = "canonical";
        int expectedDepth = 0;
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCanonical, deserialized.Canonical);
        Assert.Equal(expectedDepth, deserialized.Depth);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RelatedEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RelatedEntity
        {
            ID = "id",
            Canonical = "canonical",
            Depth = 0,
            Type = "type",
        };

        RelatedEntity copied = new(model);

        Assert.Equal(model, copied);
    }
}
