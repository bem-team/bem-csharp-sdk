using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Collections.Items;

namespace Bem.Tests.Models.Collections.Items;

public class ItemUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemUpdateParams
        {
            CollectionName = "product_catalog",
            Items =
            [
                new()
                {
                    CollectionItemID = "clitm_2N6gH8ZKCmvb6BnFcGqhKJ98VzP",
                    Data = "SKU-12345: Updated Industrial Widget - Premium Edition",
                },
                new()
                {
                    CollectionItemID = "clitm_3M7hI9ALDnwc7CoGdHriLK09WaQ",
                    Data = JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "sku": "SKU-67890",
                          "name": "Updated Premium Gear",
                          "category": "Hardware",
                          "price": 399.99
                        }
                        """
                    ),
                },
            ],
        };

        string expectedCollectionName = "product_catalog";
        List<Item> expectedItems =
        [
            new()
            {
                CollectionItemID = "clitm_2N6gH8ZKCmvb6BnFcGqhKJ98VzP",
                Data = "SKU-12345: Updated Industrial Widget - Premium Edition",
            },
            new()
            {
                CollectionItemID = "clitm_3M7hI9ALDnwc7CoGdHriLK09WaQ",
                Data = JsonSerializer.Deserialize<JsonElement>(
                    """
                    {
                      "sku": "SKU-67890",
                      "name": "Updated Premium Gear",
                      "category": "Hardware",
                      "price": 399.99
                    }
                    """
                ),
            },
        ];

        Assert.Equal(expectedCollectionName, parameters.CollectionName);
        Assert.Equal(expectedItems.Count, parameters.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], parameters.Items[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        ItemUpdateParams parameters = new()
        {
            CollectionName = "product_catalog",
            Items =
            [
                new()
                {
                    CollectionItemID = "clitm_2N6gH8ZKCmvb6BnFcGqhKJ98VzP",
                    Data = "SKU-12345: Updated Industrial Widget - Premium Edition",
                },
                new()
                {
                    CollectionItemID = "clitm_3M7hI9ALDnwc7CoGdHriLK09WaQ",
                    Data = JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "sku": "SKU-67890",
                          "name": "Updated Premium Gear",
                          "category": "Hardware",
                          "price": 399.99
                        }
                        """
                    ),
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/collections/items"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemUpdateParams
        {
            CollectionName = "product_catalog",
            Items =
            [
                new()
                {
                    CollectionItemID = "clitm_2N6gH8ZKCmvb6BnFcGqhKJ98VzP",
                    Data = "SKU-12345: Updated Industrial Widget - Premium Edition",
                },
                new()
                {
                    CollectionItemID = "clitm_3M7hI9ALDnwc7CoGdHriLK09WaQ",
                    Data = JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "sku": "SKU-67890",
                          "name": "Updated Premium Gear",
                          "category": "Hardware",
                          "price": 399.99
                        }
                        """
                    ),
                },
            ],
        };

        ItemUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item { CollectionItemID = "collectionItemID", Data = "string" };

        string expectedCollectionItemID = "collectionItemID";
        Data expectedData = "string";

        Assert.Equal(expectedCollectionItemID, model.CollectionItemID);
        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item { CollectionItemID = "collectionItemID", Data = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item { CollectionItemID = "collectionItemID", Data = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCollectionItemID = "collectionItemID";
        Data expectedData = "string";

        Assert.Equal(expectedCollectionItemID, deserialized.CollectionItemID);
        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item { CollectionItemID = "collectionItemID", Data = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item { CollectionItemID = "collectionItemID", Data = "string" };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Data value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        Data value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Data value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        Data value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
