using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.EntityTypes;

namespace Bem.Tests.Models.EntityTypes;

public class EntityTypeListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityTypeListResponse
        {
            EntityTypes =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    ParentTypeID = "parentTypeID",
                    TypeID = "typeID",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            TotalCount = 0,
        };

        List<EntityType> expectedEntityTypes =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Name = "name",
                ParentTypeID = "parentTypeID",
                TypeID = "typeID",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedEntityTypes.Count, model.EntityTypes.Count);
        for (int i = 0; i < expectedEntityTypes.Count; i++)
        {
            Assert.Equal(expectedEntityTypes[i], model.EntityTypes[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityTypeListResponse
        {
            EntityTypes =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    ParentTypeID = "parentTypeID",
                    TypeID = "typeID",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypeListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityTypeListResponse
        {
            EntityTypes =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    ParentTypeID = "parentTypeID",
                    TypeID = "typeID",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypeListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EntityType> expectedEntityTypes =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Name = "name",
                ParentTypeID = "parentTypeID",
                TypeID = "typeID",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedEntityTypes.Count, deserialized.EntityTypes.Count);
        for (int i = 0; i < expectedEntityTypes.Count; i++)
        {
            Assert.Equal(expectedEntityTypes[i], deserialized.EntityTypes[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityTypeListResponse
        {
            EntityTypes =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    ParentTypeID = "parentTypeID",
                    TypeID = "typeID",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityTypeListResponse
        {
            EntityTypes =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    ParentTypeID = "parentTypeID",
                    TypeID = "typeID",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AttributeSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            TotalCount = 0,
        };

        EntityTypeListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
