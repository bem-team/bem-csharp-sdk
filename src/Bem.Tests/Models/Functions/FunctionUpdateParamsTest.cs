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
            FunctionName = "functionName",
            UpdateFunction = new UpdateFunctionExtract()
            {
                DisplayName = "displayName",
                EnableBoundingBoxes = true,
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                PreCount = true,
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        string expectedFunctionName = "functionName";
        UpdateFunction expectedUpdateFunction = new UpdateFunctionExtract()
        {
            DisplayName = "displayName",
            EnableBoundingBoxes = true,
            FunctionName = "functionName",
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            OutputSchemaName = "outputSchemaName",
            PreCount = true,
            TabularChunkingEnabled = true,
            Tags = ["string"],
        };

        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedUpdateFunction, parameters.UpdateFunction);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionUpdateParams parameters = new()
        {
            FunctionName = "functionName",
            UpdateFunction = new UpdateFunctionExtract()
            {
                DisplayName = "displayName",
                EnableBoundingBoxes = true,
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                PreCount = true,
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/functions/functionName"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionUpdateParams
        {
            FunctionName = "functionName",
            UpdateFunction = new UpdateFunctionExtract()
            {
                DisplayName = "displayName",
                EnableBoundingBoxes = true,
                FunctionName = "functionName",
                OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
                OutputSchemaName = "outputSchemaName",
                PreCount = true,
                TabularChunkingEnabled = true,
                Tags = ["string"],
            },
        };

        FunctionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
