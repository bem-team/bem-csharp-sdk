using System;
using System.Text.Json;
using Bem.Models.EntityTypes;

namespace Bem.Tests.Models.EntityTypes;

public class EntityTypeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityTypeCreateParams
        {
            Name = "Drug",
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "A pharmaceutical compound",
            ParentTypeID = "parentTypeID",
        };

        string expectedName = "Drug";
        JsonElement expectedAttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "A pharmaceutical compound";
        string expectedParentTypeID = "parentTypeID";

        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.AttributeSchema);
        Assert.True(
            JsonElement.DeepEquals(expectedAttributeSchema, parameters.AttributeSchema.Value)
        );
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedParentTypeID, parameters.ParentTypeID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityTypeCreateParams { Name = "Drug" };

        Assert.Null(parameters.AttributeSchema);
        Assert.False(parameters.RawBodyData.ContainsKey("attributeSchema"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("parentTypeID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityTypeCreateParams
        {
            Name = "Drug",

            // Null should be interpreted as omitted for these properties
            AttributeSchema = null,
            Description = null,
            ParentTypeID = null,
        };

        Assert.Null(parameters.AttributeSchema);
        Assert.False(parameters.RawBodyData.ContainsKey("attributeSchema"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("parentTypeID"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityTypeCreateParams parameters = new() { Name = "Drug" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/entity-types"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityTypeCreateParams
        {
            Name = "Drug",
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "A pharmaceutical compound",
            ParentTypeID = "parentTypeID",
        };

        EntityTypeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
