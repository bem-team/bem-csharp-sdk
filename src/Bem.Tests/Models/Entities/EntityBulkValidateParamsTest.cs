using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityBulkValidateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityBulkValidateParams
        {
            EntityIds = ["ent_2abc", "ent_2def"],
            Status = EntityBulkValidateParamsStatus.Approved,
            Bucket = "bucket",
        };

        List<string> expectedEntityIds = ["ent_2abc", "ent_2def"];
        ApiEnum<string, EntityBulkValidateParamsStatus> expectedStatus =
            EntityBulkValidateParamsStatus.Approved;
        string expectedBucket = "bucket";

        Assert.Equal(expectedEntityIds.Count, parameters.EntityIds.Count);
        for (int i = 0; i < expectedEntityIds.Count; i++)
        {
            Assert.Equal(expectedEntityIds[i], parameters.EntityIds[i]);
        }
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedBucket, parameters.Bucket);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityBulkValidateParams
        {
            EntityIds = ["ent_2abc", "ent_2def"],
            Status = EntityBulkValidateParamsStatus.Approved,
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityBulkValidateParams
        {
            EntityIds = ["ent_2abc", "ent_2def"],
            Status = EntityBulkValidateParamsStatus.Approved,

            // Null should be interpreted as omitted for these properties
            Bucket = null,
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityBulkValidateParams parameters = new()
        {
            EntityIds = ["ent_2abc", "ent_2def"],
            Status = EntityBulkValidateParamsStatus.Approved,
            Bucket = "bucket",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.bem.ai/v3/entities/bulk-validate?bucket=bucket"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityBulkValidateParams
        {
            EntityIds = ["ent_2abc", "ent_2def"],
            Status = EntityBulkValidateParamsStatus.Approved,
            Bucket = "bucket",
        };

        EntityBulkValidateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntityBulkValidateParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(EntityBulkValidateParamsStatus.Approved)]
    [InlineData(EntityBulkValidateParamsStatus.Rejected)]
    public void Validation_Works(EntityBulkValidateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityBulkValidateParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityBulkValidateParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityBulkValidateParamsStatus.Approved)]
    [InlineData(EntityBulkValidateParamsStatus.Rejected)]
    public void SerializationRoundtrip_Works(EntityBulkValidateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityBulkValidateParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityBulkValidateParamsStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityBulkValidateParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityBulkValidateParamsStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
