using System;
using Bem.Models.EntityTypes;

namespace Bem.Tests.Models.EntityTypes;

public class EntityTypeDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityTypeDeleteParams { TypeID = "typeID" };

        string expectedTypeID = "typeID";

        Assert.Equal(expectedTypeID, parameters.TypeID);
    }

    [Fact]
    public void Url_Works()
    {
        EntityTypeDeleteParams parameters = new() { TypeID = "typeID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/entity-types/typeID"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityTypeDeleteParams { TypeID = "typeID" };

        EntityTypeDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
