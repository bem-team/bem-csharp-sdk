using System;
using Bem.Models.Connectors;

namespace Bem.Tests.Models.Connectors;

public class ConnectorDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConnectorDeleteParams { ConnectorID = "connectorID" };

        string expectedConnectorID = "connectorID";

        Assert.Equal(expectedConnectorID, parameters.ConnectorID);
    }

    [Fact]
    public void Url_Works()
    {
        ConnectorDeleteParams parameters = new() { ConnectorID = "connectorID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/connectors/connectorID"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConnectorDeleteParams { ConnectorID = "connectorID" };

        ConnectorDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
