using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Collections;

namespace Bem.Tests.Models.Collections;

public class CollectionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CollectionListPageResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        List<CollectionListResponse> expectedCollections =
        [
            new()
            {
                CollectionID = "collectionID",
                CollectionName = "collectionName",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ItemCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotalCount = 0;
        long expectedTotalPages = 0;

        Assert.Equal(expectedCollections.Count, model.Collections.Count);
        for (int i = 0; i < expectedCollections.Count; i++)
        {
            Assert.Equal(expectedCollections[i], model.Collections[i]);
        }
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CollectionListPageResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CollectionListPageResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CollectionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CollectionListResponse> expectedCollections =
        [
            new()
            {
                CollectionID = "collectionID",
                CollectionName = "collectionName",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ItemCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotalCount = 0;
        long expectedTotalPages = 0;

        Assert.Equal(expectedCollections.Count, deserialized.Collections.Count);
        for (int i = 0; i < expectedCollections.Count; i++)
        {
            Assert.Equal(expectedCollections[i], deserialized.Collections[i]);
        }
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CollectionListPageResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CollectionListPageResponse
        {
            Collections =
            [
                new()
                {
                    CollectionID = "collectionID",
                    CollectionName = "collectionName",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ItemCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Limit = 0,
            Page = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        CollectionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
