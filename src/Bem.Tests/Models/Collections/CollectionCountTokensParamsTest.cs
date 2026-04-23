using System;
using System.Collections.Generic;
using Bem.Models.Collections;

namespace Bem.Tests.Models.Collections;

public class CollectionCountTokensParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CollectionCountTokensParams { Texts = ["string"] };

        List<string> expectedTexts = ["string"];

        Assert.Equal(expectedTexts.Count, parameters.Texts.Count);
        for (int i = 0; i < expectedTexts.Count; i++)
        {
            Assert.Equal(expectedTexts[i], parameters.Texts[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        CollectionCountTokensParams parameters = new() { Texts = ["string"] };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/collections/token-count"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CollectionCountTokensParams { Texts = ["string"] };

        CollectionCountTokensParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
