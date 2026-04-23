using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Collections.Items;

namespace Bem.Tests.Models.Collections.Items;

public class ItemAddResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,
            AddedCount = 0,
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
        };

        string expectedEventID = "eventID";
        string expectedMessage = "message";
        ApiEnum<string, ItemAddResponseStatus> expectedStatus = ItemAddResponseStatus.Pending;
        long expectedAddedCount = 0;
        List<ItemAddResponseItem> expectedItems =
        [
            new()
            {
                CollectionItemID = "collectionItemID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = "string",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAddedCount, model.AddedCount);
        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,
            AddedCount = 0,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,
            AddedCount = 0,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedMessage = "message";
        ApiEnum<string, ItemAddResponseStatus> expectedStatus = ItemAddResponseStatus.Pending;
        long expectedAddedCount = 0;
        List<ItemAddResponseItem> expectedItems =
        [
            new()
            {
                CollectionItemID = "collectionItemID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = "string",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAddedCount, deserialized.AddedCount);
        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,
            AddedCount = 0,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,
        };

        Assert.Null(model.AddedCount);
        Assert.False(model.RawData.ContainsKey("addedCount"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,

            // Null should be interpreted as omitted for these properties
            AddedCount = null,
            Items = null,
        };

        Assert.Null(model.AddedCount);
        Assert.False(model.RawData.ContainsKey("addedCount"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,

            // Null should be interpreted as omitted for these properties
            AddedCount = null,
            Items = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ItemAddResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = ItemAddResponseStatus.Pending,
            AddedCount = 0,
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
        };

        ItemAddResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemAddResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(ItemAddResponseStatus.Pending)]
    public void Validation_Works(ItemAddResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ItemAddResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ItemAddResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ItemAddResponseStatus.Pending)]
    public void SerializationRoundtrip_Works(ItemAddResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ItemAddResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ItemAddResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ItemAddResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ItemAddResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ItemAddResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemAddResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCollectionItemID = "collectionItemID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ItemAddResponseItemData expectedData = "string";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionItemID, model.CollectionItemID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemAddResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddResponseItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemAddResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddResponseItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionItemID = "collectionItemID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ItemAddResponseItemData expectedData = "string";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionItemID, deserialized.CollectionItemID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemAddResponseItem
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
        var model = new ItemAddResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ItemAddResponseItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemAddResponseItemDataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ItemAddResponseItemData value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        ItemAddResponseItemData value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ItemAddResponseItemData value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddResponseItemData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        ItemAddResponseItemData value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddResponseItemData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
