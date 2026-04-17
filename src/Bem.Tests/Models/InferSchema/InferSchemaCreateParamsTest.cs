using System;
using System.Text.Json;
using Bem.Models.InferSchema;

namespace Bem.Tests.Models.InferSchema;

public class InferSchemaCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InferSchemaCreateParams
        {
            File = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        JsonElement expectedFile = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.True(JsonElement.DeepEquals(expectedFile, parameters.File));
    }

    [Fact]
    public void Url_Works()
    {
        InferSchemaCreateParams parameters = new()
        {
            File = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/infer-schema"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InferSchemaCreateParams
        {
            File = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        InferSchemaCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
