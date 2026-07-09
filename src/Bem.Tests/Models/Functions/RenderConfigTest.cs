using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class RenderConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RenderConfig
        {
            Template = new()
            {
                DownloadUrl = "https://example.com",
                ListKinds = [ListKind.Decimal],
                Name = "name",
                Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
                StyleIds = ["string"],
                TableStyleIds = ["string"],
            },
        };

        Template expectedTemplate = new()
        {
            DownloadUrl = "https://example.com",
            ListKinds = [ListKind.Decimal],
            Name = "name",
            Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
            StyleIds = ["string"],
            TableStyleIds = ["string"],
        };

        Assert.Equal(expectedTemplate, model.Template);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RenderConfig
        {
            Template = new()
            {
                DownloadUrl = "https://example.com",
                ListKinds = [ListKind.Decimal],
                Name = "name",
                Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
                StyleIds = ["string"],
                TableStyleIds = ["string"],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RenderConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RenderConfig
        {
            Template = new()
            {
                DownloadUrl = "https://example.com",
                ListKinds = [ListKind.Decimal],
                Name = "name",
                Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
                StyleIds = ["string"],
                TableStyleIds = ["string"],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RenderConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Template expectedTemplate = new()
        {
            DownloadUrl = "https://example.com",
            ListKinds = [ListKind.Decimal],
            Name = "name",
            Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
            StyleIds = ["string"],
            TableStyleIds = ["string"],
        };

        Assert.Equal(expectedTemplate, deserialized.Template);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RenderConfig
        {
            Template = new()
            {
                DownloadUrl = "https://example.com",
                ListKinds = [ListKind.Decimal],
                Name = "name",
                Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
                StyleIds = ["string"],
                TableStyleIds = ["string"],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RenderConfig { };

        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RenderConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RenderConfig
        {
            // Null should be interpreted as omitted for these properties
            Template = null,
        };

        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RenderConfig
        {
            // Null should be interpreted as omitted for these properties
            Template = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RenderConfig
        {
            Template = new()
            {
                DownloadUrl = "https://example.com",
                ListKinds = [ListKind.Decimal],
                Name = "name",
                Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
                StyleIds = ["string"],
                TableStyleIds = ["string"],
            },
        };

        RenderConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Template
        {
            DownloadUrl = "https://example.com",
            ListKinds = [ListKind.Decimal],
            Name = "name",
            Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
            StyleIds = ["string"],
            TableStyleIds = ["string"],
        };

        string expectedDownloadUrl = "https://example.com";
        List<ApiEnum<string, ListKind>> expectedListKinds = [ListKind.Decimal];
        string expectedName = "name";
        Placeholders expectedPlaceholders = new()
        {
            BlockKeys = ["string"],
            StringKeys = ["string"],
        };
        List<string> expectedStyleIds = ["string"];
        List<string> expectedTableStyleIds = ["string"];

        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.NotNull(model.ListKinds);
        Assert.Equal(expectedListKinds.Count, model.ListKinds.Count);
        for (int i = 0; i < expectedListKinds.Count; i++)
        {
            Assert.Equal(expectedListKinds[i], model.ListKinds[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlaceholders, model.Placeholders);
        Assert.NotNull(model.StyleIds);
        Assert.Equal(expectedStyleIds.Count, model.StyleIds.Count);
        for (int i = 0; i < expectedStyleIds.Count; i++)
        {
            Assert.Equal(expectedStyleIds[i], model.StyleIds[i]);
        }
        Assert.NotNull(model.TableStyleIds);
        Assert.Equal(expectedTableStyleIds.Count, model.TableStyleIds.Count);
        for (int i = 0; i < expectedTableStyleIds.Count; i++)
        {
            Assert.Equal(expectedTableStyleIds[i], model.TableStyleIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Template
        {
            DownloadUrl = "https://example.com",
            ListKinds = [ListKind.Decimal],
            Name = "name",
            Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
            StyleIds = ["string"],
            TableStyleIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Template
        {
            DownloadUrl = "https://example.com",
            ListKinds = [ListKind.Decimal],
            Name = "name",
            Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
            StyleIds = ["string"],
            TableStyleIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDownloadUrl = "https://example.com";
        List<ApiEnum<string, ListKind>> expectedListKinds = [ListKind.Decimal];
        string expectedName = "name";
        Placeholders expectedPlaceholders = new()
        {
            BlockKeys = ["string"],
            StringKeys = ["string"],
        };
        List<string> expectedStyleIds = ["string"];
        List<string> expectedTableStyleIds = ["string"];

        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.NotNull(deserialized.ListKinds);
        Assert.Equal(expectedListKinds.Count, deserialized.ListKinds.Count);
        for (int i = 0; i < expectedListKinds.Count; i++)
        {
            Assert.Equal(expectedListKinds[i], deserialized.ListKinds[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPlaceholders, deserialized.Placeholders);
        Assert.NotNull(deserialized.StyleIds);
        Assert.Equal(expectedStyleIds.Count, deserialized.StyleIds.Count);
        for (int i = 0; i < expectedStyleIds.Count; i++)
        {
            Assert.Equal(expectedStyleIds[i], deserialized.StyleIds[i]);
        }
        Assert.NotNull(deserialized.TableStyleIds);
        Assert.Equal(expectedTableStyleIds.Count, deserialized.TableStyleIds.Count);
        for (int i = 0; i < expectedTableStyleIds.Count; i++)
        {
            Assert.Equal(expectedTableStyleIds[i], deserialized.TableStyleIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Template
        {
            DownloadUrl = "https://example.com",
            ListKinds = [ListKind.Decimal],
            Name = "name",
            Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
            StyleIds = ["string"],
            TableStyleIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Template { };

        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("downloadURL"));
        Assert.Null(model.ListKinds);
        Assert.False(model.RawData.ContainsKey("listKinds"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Placeholders);
        Assert.False(model.RawData.ContainsKey("placeholders"));
        Assert.Null(model.StyleIds);
        Assert.False(model.RawData.ContainsKey("styleIds"));
        Assert.Null(model.TableStyleIds);
        Assert.False(model.RawData.ContainsKey("tableStyleIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Template { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Template
        {
            // Null should be interpreted as omitted for these properties
            DownloadUrl = null,
            ListKinds = null,
            Name = null,
            Placeholders = null,
            StyleIds = null,
            TableStyleIds = null,
        };

        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("downloadURL"));
        Assert.Null(model.ListKinds);
        Assert.False(model.RawData.ContainsKey("listKinds"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Placeholders);
        Assert.False(model.RawData.ContainsKey("placeholders"));
        Assert.Null(model.StyleIds);
        Assert.False(model.RawData.ContainsKey("styleIds"));
        Assert.Null(model.TableStyleIds);
        Assert.False(model.RawData.ContainsKey("tableStyleIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Template
        {
            // Null should be interpreted as omitted for these properties
            DownloadUrl = null,
            ListKinds = null,
            Name = null,
            Placeholders = null,
            StyleIds = null,
            TableStyleIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Template
        {
            DownloadUrl = "https://example.com",
            ListKinds = [ListKind.Decimal],
            Name = "name",
            Placeholders = new() { BlockKeys = ["string"], StringKeys = ["string"] },
            StyleIds = ["string"],
            TableStyleIds = ["string"],
        };

        Template copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ListKindTest : TestBase
{
    [Theory]
    [InlineData(ListKind.Decimal)]
    [InlineData(ListKind.Bullet)]
    public void Validation_Works(ListKind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ListKind> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ListKind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ListKind.Decimal)]
    [InlineData(ListKind.Bullet)]
    public void SerializationRoundtrip_Works(ListKind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ListKind> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ListKind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ListKind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ListKind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PlaceholdersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Placeholders { BlockKeys = ["string"], StringKeys = ["string"] };

        List<string> expectedBlockKeys = ["string"];
        List<string> expectedStringKeys = ["string"];

        Assert.Equal(expectedBlockKeys.Count, model.BlockKeys.Count);
        for (int i = 0; i < expectedBlockKeys.Count; i++)
        {
            Assert.Equal(expectedBlockKeys[i], model.BlockKeys[i]);
        }
        Assert.Equal(expectedStringKeys.Count, model.StringKeys.Count);
        for (int i = 0; i < expectedStringKeys.Count; i++)
        {
            Assert.Equal(expectedStringKeys[i], model.StringKeys[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Placeholders { BlockKeys = ["string"], StringKeys = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Placeholders>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Placeholders { BlockKeys = ["string"], StringKeys = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Placeholders>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedBlockKeys = ["string"];
        List<string> expectedStringKeys = ["string"];

        Assert.Equal(expectedBlockKeys.Count, deserialized.BlockKeys.Count);
        for (int i = 0; i < expectedBlockKeys.Count; i++)
        {
            Assert.Equal(expectedBlockKeys[i], deserialized.BlockKeys[i]);
        }
        Assert.Equal(expectedStringKeys.Count, deserialized.StringKeys.Count);
        for (int i = 0; i < expectedStringKeys.Count; i++)
        {
            Assert.Equal(expectedStringKeys[i], deserialized.StringKeys[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Placeholders { BlockKeys = ["string"], StringKeys = ["string"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Placeholders { BlockKeys = ["string"], StringKeys = ["string"] };

        Placeholders copied = new(model);

        Assert.Equal(model, copied);
    }
}
