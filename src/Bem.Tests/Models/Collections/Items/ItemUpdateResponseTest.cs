using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Collections.Items;

namespace Bem.Tests.Models.Collections.Items;

public class ItemUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,
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
            UpdatedCount = 0,
        };

        string expectedEventID = "eventID";
        string expectedMessage = "message";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        List<ItemUpdateResponseItem> expectedItems =
        [
            new()
            {
                CollectionItemID = "collectionItemID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = "string",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedUpdatedCount = 0;

        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedUpdatedCount, model.UpdatedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,
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
            UpdatedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,
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
            UpdatedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "eventID";
        string expectedMessage = "message";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        List<ItemUpdateResponseItem> expectedItems =
        [
            new()
            {
                CollectionItemID = "collectionItemID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = "string",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedUpdatedCount = 0;

        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedUpdatedCount, deserialized.UpdatedCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,
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
            UpdatedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.UpdatedCount);
        Assert.False(model.RawData.ContainsKey("updatedCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,

            // Null should be interpreted as omitted for these properties
            Items = null,
            UpdatedCount = null,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.UpdatedCount);
        Assert.False(model.RawData.ContainsKey("updatedCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,

            // Null should be interpreted as omitted for these properties
            Items = null,
            UpdatedCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ItemUpdateResponse
        {
            EventID = "eventID",
            Message = "message",
            Status = Status.Pending,
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
            UpdatedCount = 0,
        };

        ItemUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ItemUpdateResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemUpdateResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCollectionItemID = "collectionItemID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ItemUpdateResponseItemData expectedData = "string";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionItemID, model.CollectionItemID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemUpdateResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemUpdateResponseItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemUpdateResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemUpdateResponseItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionItemID = "collectionItemID";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ItemUpdateResponseItemData expectedData = "string";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCollectionItemID, deserialized.CollectionItemID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemUpdateResponseItem
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
        var model = new ItemUpdateResponseItem
        {
            CollectionItemID = "collectionItemID",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = "string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ItemUpdateResponseItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemUpdateResponseItemDataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ItemUpdateResponseItemData value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        ItemUpdateResponseItemData value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ItemUpdateResponseItemData value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemUpdateResponseItemData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        ItemUpdateResponseItemData value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemUpdateResponseItemData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
