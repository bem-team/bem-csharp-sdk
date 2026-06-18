using System;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityRetrieveSeedStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityRetrieveSeedStatusParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        EntityRetrieveSeedStatusParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/entities/seed/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityRetrieveSeedStatusParams { ID = "id" };

        EntityRetrieveSeedStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
