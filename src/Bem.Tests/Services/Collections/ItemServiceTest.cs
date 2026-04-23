using System.Text.Json;
using System.Threading.Tasks;
using Bem.Models.Collections.Items;

namespace Bem.Tests.Services.Collections;

public class ItemServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var item = await this.client.Collections.Items.Retrieve(
            new() { CollectionName = "collectionName" },
            TestContext.Current.CancellationToken
        );
        item.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var item = await this.client.Collections.Items.Update(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        item.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Collections.Items.Delete(
            new() { CollectionItemID = "collectionItemID", CollectionName = "collectionName" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.Collections.Items.Add(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
