using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.EntityTypes;

namespace Bem.Tests.Models.EntityTypes;

public class EntityTypeUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedParentTypeID = "parentTypeID";
        string expectedTypeID = "typeID";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedAttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedParentTypeID, model.ParentTypeID);
        Assert.Equal(expectedTypeID, model.TypeID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.NotNull(model.AttributeSchema);
        Assert.True(JsonElement.DeepEquals(expectedAttributeSchema, model.AttributeSchema.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypeUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypeUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedParentTypeID = "parentTypeID";
        string expectedTypeID = "typeID";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedAttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedParentTypeID, deserialized.ParentTypeID);
        Assert.Equal(expectedTypeID, deserialized.TypeID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.NotNull(deserialized.AttributeSchema);
        Assert.True(
            JsonElement.DeepEquals(expectedAttributeSchema, deserialized.AttributeSchema.Value)
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.AttributeSchema);
        Assert.False(model.RawData.ContainsKey("attributeSchema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            AttributeSchema = null,
        };

        Assert.Null(model.AttributeSchema);
        Assert.False(model.RawData.ContainsKey("attributeSchema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            AttributeSchema = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityTypeUpdateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            ParentTypeID = "parentTypeID",
            TypeID = "typeID",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        EntityTypeUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
