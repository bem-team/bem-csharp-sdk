using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        string expectedCanonical = "canonical";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityID";
        int expectedMentionCount = 0;
        ApiEnum<string, EntityUpdateResponseStatus> expectedStatus =
            EntityUpdateResponseStatus.Extracted;
        List<string> expectedSurfaceForms = ["string"];
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedTypeID = "typeID";
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedValidatedByUserID = "validatedByUserID";

        Assert.Equal(expectedCanonical, model.Canonical);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedMentionCount, model.MentionCount);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSurfaceForms.Count, model.SurfaceForms.Count);
        for (int i = 0; i < expectedSurfaceForms.Count; i++)
        {
            Assert.Equal(expectedSurfaceForms[i], model.SurfaceForms[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedTypeID, model.TypeID);
        Assert.Equal(expectedValidatedAt, model.ValidatedAt);
        Assert.Equal(expectedValidatedByUserID, model.ValidatedByUserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCanonical = "canonical";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityID";
        int expectedMentionCount = 0;
        ApiEnum<string, EntityUpdateResponseStatus> expectedStatus =
            EntityUpdateResponseStatus.Extracted;
        List<string> expectedSurfaceForms = ["string"];
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedTypeID = "typeID";
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedValidatedByUserID = "validatedByUserID";

        Assert.Equal(expectedCanonical, deserialized.Canonical);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedMentionCount, deserialized.MentionCount);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSurfaceForms.Count, deserialized.SurfaceForms.Count);
        for (int i = 0; i < expectedSurfaceForms.Count; i++)
        {
            Assert.Equal(expectedSurfaceForms[i], deserialized.SurfaceForms[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedTypeID, deserialized.TypeID);
        Assert.Equal(expectedValidatedAt, deserialized.ValidatedAt);
        Assert.Equal(expectedValidatedByUserID, deserialized.ValidatedByUserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.TypeID);
        Assert.False(model.RawData.ContainsKey("typeID"));
        Assert.Null(model.ValidatedAt);
        Assert.False(model.RawData.ContainsKey("validatedAt"));
        Assert.Null(model.ValidatedByUserID);
        Assert.False(model.RawData.ContainsKey("validatedByUserID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Description = null,
            TypeID = null,
            ValidatedAt = null,
            ValidatedByUserID = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.TypeID);
        Assert.False(model.RawData.ContainsKey("typeID"));
        Assert.Null(model.ValidatedAt);
        Assert.False(model.RawData.ContainsKey("validatedAt"));
        Assert.Null(model.ValidatedByUserID);
        Assert.False(model.RawData.ContainsKey("validatedByUserID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Description = null,
            TypeID = null,
            ValidatedAt = null,
            ValidatedByUserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateResponse
        {
            Canonical = "canonical",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityID",
            MentionCount = 0,
            Status = EntityUpdateResponseStatus.Extracted,
            SurfaceForms = ["string"],
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            TypeID = "typeID",
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedByUserID = "validatedByUserID",
        };

        EntityUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(EntityUpdateResponseStatus.Extracted)]
    [InlineData(EntityUpdateResponseStatus.Proposed)]
    [InlineData(EntityUpdateResponseStatus.Approved)]
    [InlineData(EntityUpdateResponseStatus.Rejected)]
    public void Validation_Works(EntityUpdateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityUpdateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityUpdateResponseStatus.Extracted)]
    [InlineData(EntityUpdateResponseStatus.Proposed)]
    [InlineData(EntityUpdateResponseStatus.Approved)]
    [InlineData(EntityUpdateResponseStatus.Rejected)]
    public void SerializationRoundtrip_Works(EntityUpdateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntityUpdateResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityUpdateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntityUpdateResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
