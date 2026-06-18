using System;
using System.Text.Json;
using Bem.Models.EntityTypes;

namespace Bem.Tests.Models.EntityTypes;

public class EntityTypeUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityTypeUpdateParams
        {
            TypeID = "typeID",
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            ParentTypeID = "parentTypeID",
        };

        string expectedTypeID = "typeID";
        JsonElement expectedAttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        string expectedParentTypeID = "parentTypeID";

        Assert.Equal(expectedTypeID, parameters.TypeID);
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
        var parameters = new EntityTypeUpdateParams { TypeID = "typeID" };

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
        var parameters = new EntityTypeUpdateParams
        {
            TypeID = "typeID",

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
        EntityTypeUpdateParams parameters = new() { TypeID = "typeID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/entity-types/typeID"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityTypeUpdateParams
        {
            TypeID = "typeID",
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            ParentTypeID = "parentTypeID",
        };

        EntityTypeUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
