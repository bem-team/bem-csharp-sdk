using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Collections;

namespace Bem.Tests.Models.Collections;

public class CollectionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CollectionListResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        List<Collection> expectedCollections =
        [
            new()
            {
                CollectionID = "collectionID",
                CollectionName = "collectionName",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ItemCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotalCount = 0;
        long expectedTotalPages = 0;

        Assert.Equal(expectedCollections.Count, model.Collections.Count);
        for (int i = 0; i < expectedCollections.Count; i++)
        {
            Assert.Equal(expectedCollections[i], model.Collections[i]);
        }
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CollectionListResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CollectionListResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Collection> expectedCollections =
        [
            new()
            {
                CollectionID = "collectionID",
                CollectionName = "collectionName",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ItemCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotalCount = 0;
        long expectedTotalPages = 0;

        Assert.Equal(expectedCollections.Count, deserialized.Collections.Count);
        for (int i = 0; i < expectedCollections.Count; i++)
        {
            Assert.Equal(expectedCollections[i], deserialized.Collections[i]);
        }
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CollectionListResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CollectionListResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        CollectionListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CollectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedItemCount = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionID, model.CollectionID);
        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedItemCount, model.ItemCount);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Collection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Collection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedItemCount = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionID, deserialized.CollectionID);
        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedItemCount, deserialized.ItemCount);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
        };

        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,

            // Null should be interpreted as omitted for these properties
            UpdatedAt = null,
        };

        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,

            // Null should be interpreted as omitted for these properties
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Collection
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Collection copied = new(model);

        Assert.Equal(model, copied);
    }
}
