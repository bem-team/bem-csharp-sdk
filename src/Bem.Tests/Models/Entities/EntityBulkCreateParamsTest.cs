using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityBulkCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityBulkCreateParams
        {
            Entities =
            [
                new()
                {
                    Canonical = "Acme Corporation",
                    Type = "organization",
                    Attributes = JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "headquarters": "Springfield"
                        }
                        """
                    ),
                    Description = "Industrial conglomerate",
                    Synonyms = ["ACME", "Acme Corp"],
                },
            ],
            Bucket = "bucket",
            OnConflict = OnConflict.Merge,
        };

        List<Entity> expectedEntities =
        [
            new()
            {
                Canonical = "Acme Corporation",
                Type = "organization",
                Attributes = JsonSerializer.Deserialize<JsonElement>(
                    """
                    {
                      "headquarters": "Springfield"
                    }
                    """
                ),
                Description = "Industrial conglomerate",
                Synonyms = ["ACME", "Acme Corp"],
            },
        ];
        string expectedBucket = "bucket";
        ApiEnum<string, OnConflict> expectedOnConflict = OnConflict.Merge;

        Assert.Equal(expectedEntities.Count, parameters.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], parameters.Entities[i]);
        }
        Assert.Equal(expectedBucket, parameters.Bucket);
        Assert.Equal(expectedOnConflict, parameters.OnConflict);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityBulkCreateParams
        {
            Entities =
            [
                new()
                {
                    Canonical = "Acme Corporation",
                    Type = "organization",
                    Attributes = JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "headquarters": "Springfield"
                        }
                        """
                    ),
                    Description = "Industrial conglomerate",
                    Synonyms = ["ACME", "Acme Corp"],
                },
            ],
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawBodyData.ContainsKey("bucket"));
        Assert.Null(parameters.OnConflict);
        Assert.False(parameters.RawBodyData.ContainsKey("onConflict"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityBulkCreateParams
        {
            Entities =
            [
                new()
                {
                    Canonical = "Acme Corporation",
                    Type = "organization",
                    Attributes = JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "headquarters": "Springfield"
                        }
                        """
                    ),
                    Description = "Industrial conglomerate",
                    Synonyms = ["ACME", "Acme Corp"],
                },
            ],

            // Null should be interpreted as omitted for these properties
            Bucket = null,
            OnConflict = null,
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawBodyData.ContainsKey("bucket"));
        Assert.Null(parameters.OnConflict);
        Assert.False(parameters.RawBodyData.ContainsKey("onConflict"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityBulkCreateParams parameters = new()
        {
            Entities =
            [
                new()
                {
                    Canonical = "Acme Corporation",
                    Type = "organization",
                    Attributes = JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "headquarters": "Springfield"
                        }
                        """
                    ),
                    Description = "Industrial conglomerate",
                    Synonyms = ["ACME", "Acme Corp"],
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/entities/bulk"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityBulkCreateParams
        {
            Entities =
            [
                new()
                {
                    Canonical = "Acme Corporation",
                    Type = "organization",
                    Attributes = JsonSerializer.Deserialize<JsonElement>(
                        """
                        {
                          "headquarters": "Springfield"
                        }
                        """
                    ),
                    Description = "Industrial conglomerate",
                    Synonyms = ["ACME", "Acme Corp"],
                },
            ],
            Bucket = "bucket",
            OnConflict = OnConflict.Merge,
        };

        EntityBulkCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            Type = "type",
            Attributes = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            Synonyms = ["string"],
        };

        string expectedCanonical = "canonical";
        string expectedType = "type";
        JsonElement expectedAttributes = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        List<string> expectedSynonyms = ["string"];

        Assert.Equal(expectedCanonical, model.Canonical);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Attributes);
        Assert.True(JsonElement.DeepEquals(expectedAttributes, model.Attributes.Value));
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Synonyms);
        Assert.Equal(expectedSynonyms.Count, model.Synonyms.Count);
        for (int i = 0; i < expectedSynonyms.Count; i++)
        {
            Assert.Equal(expectedSynonyms[i], model.Synonyms[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            Type = "type",
            Attributes = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            Synonyms = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            Type = "type",
            Attributes = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            Synonyms = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCanonical = "canonical";
        string expectedType = "type";
        JsonElement expectedAttributes = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        List<string> expectedSynonyms = ["string"];

        Assert.Equal(expectedCanonical, deserialized.Canonical);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Attributes);
        Assert.True(JsonElement.DeepEquals(expectedAttributes, deserialized.Attributes.Value));
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Synonyms);
        Assert.Equal(expectedSynonyms.Count, deserialized.Synonyms.Count);
        for (int i = 0; i < expectedSynonyms.Count; i++)
        {
            Assert.Equal(expectedSynonyms[i], deserialized.Synonyms[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            Type = "type",
            Attributes = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            Synonyms = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entity { Canonical = "canonical", Type = "type" };

        Assert.Null(model.Attributes);
        Assert.False(model.RawData.ContainsKey("attributes"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Synonyms);
        Assert.False(model.RawData.ContainsKey("synonyms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entity { Canonical = "canonical", Type = "type" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            Type = "type",

            // Null should be interpreted as omitted for these properties
            Attributes = null,
            Description = null,
            Synonyms = null,
        };

        Assert.Null(model.Attributes);
        Assert.False(model.RawData.ContainsKey("attributes"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Synonyms);
        Assert.False(model.RawData.ContainsKey("synonyms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            Type = "type",

            // Null should be interpreted as omitted for these properties
            Attributes = null,
            Description = null,
            Synonyms = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entity
        {
            Canonical = "canonical",
            Type = "type",
            Attributes = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            Synonyms = ["string"],
        };

        Entity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnConflictTest : TestBase
{
    [Theory]
    [InlineData(OnConflict.Merge)]
    public void Validation_Works(OnConflict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OnConflict> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OnConflict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OnConflict.Merge)]
    public void SerializationRoundtrip_Works(OnConflict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OnConflict> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OnConflict>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OnConflict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OnConflict>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
