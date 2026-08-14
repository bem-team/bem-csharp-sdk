using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Buckets;

namespace Bem.Tests.Models.Buckets;

public class BucketListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BucketListResponse
        {
            Buckets =
            [
                new()
                {
                    BucketID = "bucketID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsDefault = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalCount = 0,
        };

        List<BucketV3> expectedBuckets =
        [
            new()
            {
                BucketID = "bucketID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                IsDefault = true,
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedBuckets.Count, model.Buckets.Count);
        for (int i = 0; i < expectedBuckets.Count; i++)
        {
            Assert.Equal(expectedBuckets[i], model.Buckets[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BucketListResponse
        {
            Buckets =
            [
                new()
                {
                    BucketID = "bucketID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsDefault = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BucketListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BucketListResponse
        {
            Buckets =
            [
                new()
                {
                    BucketID = "bucketID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsDefault = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BucketListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BucketV3> expectedBuckets =
        [
            new()
            {
                BucketID = "bucketID",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                IsDefault = true,
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedBuckets.Count, deserialized.Buckets.Count);
        for (int i = 0; i < expectedBuckets.Count; i++)
        {
            Assert.Equal(expectedBuckets[i], deserialized.Buckets[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BucketListResponse
        {
            Buckets =
            [
                new()
                {
                    BucketID = "bucketID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsDefault = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BucketListResponse
        {
            Buckets =
            [
                new()
                {
                    BucketID = "bucketID",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsDefault = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalCount = 0,
        };

        BucketListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
