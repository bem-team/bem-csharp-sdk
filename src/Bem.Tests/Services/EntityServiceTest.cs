using System.Text.Json;
using System.Threading.Tasks;
using Bem.Models.Entities;

namespace Bem.Tests.Services;

public class EntityServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var entity = await this.client.Entities.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        entity.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task BulkCreate_Works()
    {
        var response = await this.client.Entities.BulkCreate(
            new()
            {
                Entities =
                [
                    new()
                    {
                        Canonical = "Acme Corporation",
                        Type = "organization",
                        Attributes = JsonSerializer.Deserialize<JsonElement>(
                            """
                            {
                              "headquarters": "Springfield"
                            }
                            """
                        ),
                        Description = "Industrial conglomerate",
                        Synonyms = ["ACME", "Acme Corp"],
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task BulkValidate_Works()
    {
        var response = await this.client.Entities.BulkValidate(
            new()
            {
                EntityIds = ["ent_2abc", "ent_2def"],
                Status = EntityBulkValidateParamsStatus.Approved,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveRelations_Works()
    {
        var response = await this.client.Entities.RetrieveRelations(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveSeedStatus_Works()
    {
        var response = await this.client.Entities.RetrieveSeedStatus(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
