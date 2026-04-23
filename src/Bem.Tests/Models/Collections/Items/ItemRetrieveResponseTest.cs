using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Collections.Items;

namespace Bem.Tests.Models.Collections.Items;

public class ItemRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemRetrieveResponse
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            Items =
            [
                new()
                {
                    CollectionItemID = "collectionItemID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = "string",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalPages = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedItemCount = 0;
        List<ItemRetrieveResponseItem> expectedItems =
        [
            new()
            {
                CollectionItemID = "collectionItemID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = "string",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotalPages = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionID, model.CollectionID);
        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedItemCount, model.ItemCount);
        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedTotalPages, model.TotalPages);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemRetrieveResponse
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            Items =
            [
                new()
                {
                    CollectionItemID = "collectionItemID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = "string",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalPages = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemRetrieveResponse
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            Items =
            [
                new()
                {
                    CollectionItemID = "collectionItemID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = "string",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalPages = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedItemCount = 0;
        List<ItemRetrieveResponseItem> expectedItems =
        [
            new()
            {
                CollectionItemID = "collectionItemID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = "string",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotalPages = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionID, deserialized.CollectionID);
        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedItemCount, deserialized.ItemCount);
        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemRetrieveResponse
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            Items =
            [
                new()
                {
                    CollectionItemID = "collectionItemID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = "string",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalPages = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ItemRetrieveResponse
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("totalPages"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ItemRetrieveResponse
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
        var model = new ItemRetrieveResponse
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,

            // Null should be interpreted as omitted for these properties
            Items = null,
            Limit = null,
            Page = null,
            TotalPages = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("totalPages"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ItemRetrieveResponse
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,

            // Null should be interpreted as omitted for these properties
            Items = null,
            Limit = null,
            Page = null,
            TotalPages = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ItemRetrieveResponse
        {
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ItemCount = 0,
            Items =
            [
                new()
                {
                    CollectionItemID = "collectionItemID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = "string",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalPages = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ItemRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemRetrieveResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemRetrieveResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCollectionItemID = "collectionItemID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ItemRetrieveResponseItemData expectedData = "string";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionItemID, model.CollectionItemID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemRetrieveResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemRetrieveResponseItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemRetrieveResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemRetrieveResponseItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionItemID = "collectionItemID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ItemRetrieveResponseItemData expectedData = "string";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionItemID, deserialized.CollectionItemID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemRetrieveResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ItemRetrieveResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ItemRetrieveResponseItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemRetrieveResponseItemDataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ItemRetrieveResponseItemData value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        ItemRetrieveResponseItemData value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ItemRetrieveResponseItemData value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemRetrieveResponseItemData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        ItemRetrieveResponseItemData value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemRetrieveResponseItemData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
