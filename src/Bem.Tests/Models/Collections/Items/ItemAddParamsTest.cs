using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Collections.Items;

namespace Bem.Tests.Models.Collections.Items;

public class ItemAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemAddParams
        {
            CollectionName = "product_catalog",
            Items =
            [
                new(
                    new ItemAddParamsItemData(
                        JsonSerializer.Deserialize<JsonElement>(
                            """
                            {
                              "sku": "SKU-11111",
                              "name": "Deluxe Component",
                              "category": "Hardware",
                              "price": 299.99
                            }
                            """
                        )
                    )
                ),
                new(
                    new ItemAddParamsItemData(
                        JsonSerializer.Deserialize<JsonElement>(
                            """
                            {
                              "sku": "SKU-22222",
                              "name": "Standard Part",
                              "category": "Tools",
                              "price": 49.99
                            }
                            """
                        )
                    )
                ),
            ],
        };

        string expectedCollectionName = "product_catalog";
        List<ItemAddParamsItem> expectedItems =
        [
            new(
                new ItemAddParamsItemData(
                    JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "sku": "SKU-11111",
                          "name": "Deluxe Component",
                          "category": "Hardware",
                          "price": 299.99
                        }
                        """
                    )
                )
            ),
            new(
                new ItemAddParamsItemData(
                    JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "sku": "SKU-22222",
                          "name": "Standard Part",
                          "category": "Tools",
                          "price": 49.99
                        }
                        """
                    )
                )
            ),
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
        ItemAddParams parameters = new()
        {
            CollectionName = "product_catalog",
            Items =
            [
                new(
                    new ItemAddParamsItemData(
                        JsonSerializer.Deserialize<JsonElement>(
                            """
                            {
                              "sku": "SKU-11111",
                              "name": "Deluxe Component",
                              "category": "Hardware",
                              "price": 299.99
                            }
                            """
                        )
                    )
                ),
                new(
                    new ItemAddParamsItemData(
                        JsonSerializer.Deserialize<JsonElement>(
                            """
                            {
                              "sku": "SKU-22222",
                              "name": "Standard Part",
                              "category": "Tools",
                              "price": 49.99
                            }
                            """
                        )
                    )
                ),
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/collections/items"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemAddParams
        {
            CollectionName = "product_catalog",
            Items =
            [
                new(
                    new ItemAddParamsItemData(
                        JsonSerializer.Deserialize<JsonElement>(
                            """
                            {
                              "sku": "SKU-11111",
                              "name": "Deluxe Component",
                              "category": "Hardware",
                              "price": 299.99
                            }
                            """
                        )
                    )
                ),
                new(
                    new ItemAddParamsItemData(
                        JsonSerializer.Deserialize<JsonElement>(
                            """
                            {
                              "sku": "SKU-22222",
                              "name": "Standard Part",
                              "category": "Tools",
                              "price": 49.99
                            }
                            """
                        )
                    )
                ),
            ],
        };

        ItemAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ItemAddParamsItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemAddParamsItem { Data = "string" };

        ItemAddParamsItemData expectedData = "string";

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemAddParamsItem { Data = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddParamsItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemAddParamsItem { Data = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddParamsItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ItemAddParamsItemData expectedData = "string";

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemAddParamsItem { Data = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ItemAddParamsItem { Data = "string" };

        ItemAddParamsItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemAddParamsItemDataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ItemAddParamsItemData value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        ItemAddParamsItemData value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ItemAddParamsItemData value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddParamsItemData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        ItemAddParamsItemData value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemAddParamsItemData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
