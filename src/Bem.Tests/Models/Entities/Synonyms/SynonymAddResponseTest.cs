using System;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities.Synonyms;

namespace Bem.Tests.Models.Entities.Synonyms;

public class SynonymAddResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",
            Locale = "locale",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedNormalizedText = "normalizedText";
        ApiEnum<string, Source> expectedSource = Source.Extracted;
        string expectedSynonymID = "synonymID";
        string expectedText = "text";
        string expectedLocale = "locale";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedNormalizedText, model.NormalizedText);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedSynonymID, model.SynonymID);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedLocale, model.Locale);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",
            Locale = "locale",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SynonymAddResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",
            Locale = "locale",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SynonymAddResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedNormalizedText = "normalizedText";
        ApiEnum<string, Source> expectedSource = Source.Extracted;
        string expectedSynonymID = "synonymID";
        string expectedText = "text";
        string expectedLocale = "locale";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedNormalizedText, deserialized.NormalizedText);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedSynonymID, deserialized.SynonymID);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedLocale, deserialized.Locale);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",
            Locale = "locale",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",
        };

        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SynonymAddResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NormalizedText = "normalizedText",
            Source = Source.Extracted,
            SynonymID = "synonymID",
            Text = "text",
            Locale = "locale",
        };

        SynonymAddResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Extracted)]
    [InlineData(Source.CustomerDefined)]
    [InlineData(Source.SmeApproved)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Extracted)]
    [InlineData(Source.CustomerDefined)]
    [InlineData(Source.SmeApproved)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
