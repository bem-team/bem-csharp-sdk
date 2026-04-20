using System;
using System.Text.Json;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionCreateParams
        {
            CreateFunction = new Extract()
            {
                FunctionName = "functionName",
                DisplayName = "displayName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        CreateFunction expectedCreateFunction = new Extract()
        {
            FunctionName = "functionName",
            DisplayName = "displayName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        Assert.Equal(expectedCreateFunction, parameters.CreateFunction);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionCreateParams parameters = new()
        {
            CreateFunction = new Extract()
            {
                FunctionName = "functionName",
                DisplayName = "displayName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionCreateParams
        {
            CreateFunction = new Extract()
            {
                FunctionName = "functionName",
                DisplayName = "displayName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        FunctionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
