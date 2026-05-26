using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class ParseConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        bool expectedExtractEntities = true;
        bool expectedLinkAcrossDocuments = true;
        JsonElement expectedSchema = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedExtractEntities, model.ExtractEntities);
        Assert.Equal(expectedLinkAcrossDocuments, model.LinkAcrossDocuments);
        Assert.NotNull(model.Schema);
        Assert.True(JsonElement.DeepEquals(expectedSchema, model.Schema.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParseConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParseConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedExtractEntities = true;
        bool expectedLinkAcrossDocuments = true;
        JsonElement expectedSchema = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedExtractEntities, deserialized.ExtractEntities);
        Assert.Equal(expectedLinkAcrossDocuments, deserialized.LinkAcrossDocuments);
        Assert.NotNull(deserialized.Schema);
        Assert.True(JsonElement.DeepEquals(expectedSchema, deserialized.Schema.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ParseConfig { };

        Assert.Null(model.ExtractEntities);
        Assert.False(model.RawData.ContainsKey("extractEntities"));
        Assert.Null(model.LinkAcrossDocuments);
        Assert.False(model.RawData.ContainsKey("linkAcrossDocuments"));
        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ParseConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ParseConfig
        {
            // Null should be interpreted as omitted for these properties
            ExtractEntities = null,
            LinkAcrossDocuments = null,
            Schema = null,
        };

        Assert.Null(model.ExtractEntities);
        Assert.False(model.RawData.ContainsKey("extractEntities"));
        Assert.Null(model.LinkAcrossDocuments);
        Assert.False(model.RawData.ContainsKey("linkAcrossDocuments"));
        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ParseConfig
        {
            // Null should be interpreted as omitted for these properties
            ExtractEntities = null,
            LinkAcrossDocuments = null,
            Schema = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParseConfig
        {
            ExtractEntities = true,
            LinkAcrossDocuments = true,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ParseConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
