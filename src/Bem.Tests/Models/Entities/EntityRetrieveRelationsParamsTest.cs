using System;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityRetrieveRelationsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityRetrieveRelationsParams
        {
            ID = "id",
            Bucket = "bucket",
            Cursor = "cursor",
            Direction = Direction.Inbound,
            Limit = 0,
            RelationType = "relationType",
        };

        string expectedID = "id";
        string expectedBucket = "bucket";
        string expectedCursor = "cursor";
        ApiEnum<string, Direction> expectedDirection = Direction.Inbound;
        int expectedLimit = 0;
        string expectedRelationType = "relationType";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBucket, parameters.Bucket);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedDirection, parameters.Direction);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedRelationType, parameters.RelationType);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityRetrieveRelationsParams { ID = "id" };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Direction);
        Assert.False(parameters.RawQueryData.ContainsKey("direction"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.RelationType);
        Assert.False(parameters.RawQueryData.ContainsKey("relationType"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityRetrieveRelationsParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Bucket = null,
            Cursor = null,
            Direction = null,
            Limit = null,
            RelationType = null,
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Direction);
        Assert.False(parameters.RawQueryData.ContainsKey("direction"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.RelationType);
        Assert.False(parameters.RawQueryData.ContainsKey("relationType"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityRetrieveRelationsParams parameters = new()
        {
            ID = "id",
            Bucket = "bucket",
            Cursor = "cursor",
            Direction = Direction.Inbound,
            Limit = 0,
            RelationType = "relationType",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/entities/id/relations?bucket=bucket&cursor=cursor&direction=inbound&limit=0&relationType=relationType"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityRetrieveRelationsParams
        {
            ID = "id",
            Bucket = "bucket",
            Cursor = "cursor",
            Direction = Direction.Inbound,
            Limit = 0,
            RelationType = "relationType",
        };

        EntityRetrieveRelationsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DirectionTest : TestBase
{
    [Theory]
    [InlineData(Direction.Inbound)]
    [InlineData(Direction.Outbound)]
    [InlineData(Direction.Both)]
    public void Validation_Works(Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Direction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Direction.Inbound)]
    [InlineData(Direction.Outbound)]
    [InlineData(Direction.Both)]
    public void SerializationRoundtrip_Works(Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Direction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
