using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.InferSchema;

namespace Bem.Tests.Models.InferSchema;

public class InferSchemaCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InferSchemaCreateResponse
        {
            Analysis = new()
            {
                ContentNature = "contentNature",
                ContentType = "contentType",
                Description = "description",
                DocumentTypes =
                [
                    new()
                    {
                        Count = 0,
                        Description = "description",
                        Name = "name",
                    },
                ],
                FileName = "fileName",
                FileType = "fileType",
                IsMultiDocument = true,
                SizeBytes = 0,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Filename = "filename",
        };

        Analysis expectedAnalysis = new()
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        string expectedFilename = "filename";

        Assert.Equal(expectedAnalysis, model.Analysis);
        Assert.Equal(expectedFilename, model.Filename);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InferSchemaCreateResponse
        {
            Analysis = new()
            {
                ContentNature = "contentNature",
                ContentType = "contentType",
                Description = "description",
                DocumentTypes =
                [
                    new()
                    {
                        Count = 0,
                        Description = "description",
                        Name = "name",
                    },
                ],
                FileName = "fileName",
                FileType = "fileType",
                IsMultiDocument = true,
                SizeBytes = 0,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Filename = "filename",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InferSchemaCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InferSchemaCreateResponse
        {
            Analysis = new()
            {
                ContentNature = "contentNature",
                ContentType = "contentType",
                Description = "description",
                DocumentTypes =
                [
                    new()
                    {
                        Count = 0,
                        Description = "description",
                        Name = "name",
                    },
                ],
                FileName = "fileName",
                FileType = "fileType",
                IsMultiDocument = true,
                SizeBytes = 0,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Filename = "filename",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InferSchemaCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Analysis expectedAnalysis = new()
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        string expectedFilename = "filename";

        Assert.Equal(expectedAnalysis, deserialized.Analysis);
        Assert.Equal(expectedFilename, deserialized.Filename);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InferSchemaCreateResponse
        {
            Analysis = new()
            {
                ContentNature = "contentNature",
                ContentType = "contentType",
                Description = "description",
                DocumentTypes =
                [
                    new()
                    {
                        Count = 0,
                        Description = "description",
                        Name = "name",
                    },
                ],
                FileName = "fileName",
                FileType = "fileType",
                IsMultiDocument = true,
                SizeBytes = 0,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Filename = "filename",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InferSchemaCreateResponse
        {
            Analysis = new()
            {
                ContentNature = "contentNature",
                ContentType = "contentType",
                Description = "description",
                DocumentTypes =
                [
                    new()
                    {
                        Count = 0,
                        Description = "description",
                        Name = "name",
                    },
                ],
                FileName = "fileName",
                FileType = "fileType",
                IsMultiDocument = true,
                SizeBytes = 0,
                Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Filename = "filename",
        };

        InferSchemaCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AnalysisTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedContentNature = "contentNature";
        string expectedContentType = "contentType";
        string expectedDescription = "description";
        List<DocumentType> expectedDocumentTypes =
        [
            new()
            {
                Count = 0,
                Description = "description",
                Name = "name",
            },
        ];
        string expectedFileName = "fileName";
        string expectedFileType = "fileType";
        bool expectedIsMultiDocument = true;
        long expectedSizeBytes = 0;
        JsonElement expectedSchema = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedContentNature, model.ContentNature);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDocumentTypes.Count, model.DocumentTypes.Count);
        for (int i = 0; i < expectedDocumentTypes.Count; i++)
        {
            Assert.Equal(expectedDocumentTypes[i], model.DocumentTypes[i]);
        }
        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedIsMultiDocument, model.IsMultiDocument);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.NotNull(model.Schema);
        Assert.True(JsonElement.DeepEquals(expectedSchema, model.Schema.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Analysis>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Analysis>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContentNature = "contentNature";
        string expectedContentType = "contentType";
        string expectedDescription = "description";
        List<DocumentType> expectedDocumentTypes =
        [
            new()
            {
                Count = 0,
                Description = "description",
                Name = "name",
            },
        ];
        string expectedFileName = "fileName";
        string expectedFileType = "fileType";
        bool expectedIsMultiDocument = true;
        long expectedSizeBytes = 0;
        JsonElement expectedSchema = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedContentNature, deserialized.ContentNature);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDocumentTypes.Count, deserialized.DocumentTypes.Count);
        for (int i = 0; i < expectedDocumentTypes.Count; i++)
        {
            Assert.Equal(expectedDocumentTypes[i], deserialized.DocumentTypes[i]);
        }
        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.Equal(expectedIsMultiDocument, deserialized.IsMultiDocument);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.NotNull(deserialized.Schema);
        Assert.True(JsonElement.DeepEquals(expectedSchema, deserialized.Schema.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
        };

        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,

            // Null should be interpreted as omitted for these properties
            Schema = null,
        };

        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,

            // Null should be interpreted as omitted for these properties
            Schema = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Analysis
        {
            ContentNature = "contentNature",
            ContentType = "contentType",
            Description = "description",
            DocumentTypes =
            [
                new()
                {
                    Count = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
            FileName = "fileName",
            FileType = "fileType",
            IsMultiDocument = true,
            SizeBytes = 0,
            Schema = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Analysis copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DocumentTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentType
        {
            Count = 0,
            Description = "description",
            Name = "name",
        };

        long expectedCount = 0;
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DocumentType
        {
            Count = 0,
            Description = "description",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentType>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocumentType
        {
            Count = 0,
            Description = "description",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCount = 0;
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DocumentType
        {
            Count = 0,
            Description = "description",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DocumentType
        {
            Count = 0,
            Description = "description",
            Name = "name",
        };

        DocumentType copied = new(model);

        Assert.Equal(model, copied);
    }
}
