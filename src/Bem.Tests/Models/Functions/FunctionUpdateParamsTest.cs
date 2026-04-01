using System;
using System.Text.Json;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionUpdateParams
        {
            PathFunctionName = "functionName",
            UpdateFunction = new UpdateFunctionTransform()
            {
                DisplayName = "displayName",
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        string expectedPathFunctionName = "functionName";
        UpdateFunction expectedUpdateFunction = new UpdateFunctionTransform()
        {
            DisplayName = "displayName",
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        Assert.Equal(expectedPathFunctionName, parameters.PathFunctionName);
        Assert.Equal(expectedUpdateFunction, parameters.UpdateFunction);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionUpdateParams parameters = new()
        {
            PathFunctionName = "functionName",
            UpdateFunction = new UpdateFunctionTransform()
            {
                DisplayName = "displayName",
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/functions/functionName"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionUpdateParams
        {
            PathFunctionName = "functionName",
            UpdateFunction = new UpdateFunctionTransform()
            {
                DisplayName = "displayName",
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        FunctionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
