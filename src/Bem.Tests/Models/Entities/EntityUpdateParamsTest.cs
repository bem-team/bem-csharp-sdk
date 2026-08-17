using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Entities;

namespace Bem.Tests.Models.Entities;

public class EntityUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityUpdateParams
        {
            ID = "id",
            Bucket = "bucket",
            AddSynonyms = ["string"],
            AssignedTypeID = "assignedTypeID",
            Canonical = "canonical",
            Locale = "locale",
            RemoveSynonymIds = ["string"],
            Status = Status.Approved,
        };

        string expectedID = "id";
        string expectedBucket = "bucket";
        List<string> expectedAddSynonyms = ["string"];
        string expectedAssignedTypeID = "assignedTypeID";
        string expectedCanonical = "canonical";
        string expectedLocale = "locale";
        List<string> expectedRemoveSynonymIds = ["string"];
        ApiEnum<string, Status> expectedStatus = Status.Approved;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBucket, parameters.Bucket);
        Assert.NotNull(parameters.AddSynonyms);
        Assert.Equal(expectedAddSynonyms.Count, parameters.AddSynonyms.Count);
        for (int i = 0; i < expectedAddSynonyms.Count; i++)
        {
            Assert.Equal(expectedAddSynonyms[i], parameters.AddSynonyms[i]);
        }
        Assert.Equal(expectedAssignedTypeID, parameters.AssignedTypeID);
        Assert.Equal(expectedCanonical, parameters.Canonical);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.NotNull(parameters.RemoveSynonymIds);
        Assert.Equal(expectedRemoveSynonymIds.Count, parameters.RemoveSynonymIds.Count);
        for (int i = 0; i < expectedRemoveSynonymIds.Count; i++)
        {
            Assert.Equal(expectedRemoveSynonymIds[i], parameters.RemoveSynonymIds[i]);
        }
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityUpdateParams { ID = "id" };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.AddSynonyms);
        Assert.False(parameters.RawBodyData.ContainsKey("addSynonyms"));
        Assert.Null(parameters.AssignedTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTypeID"));
        Assert.Null(parameters.Canonical);
        Assert.False(parameters.RawBodyData.ContainsKey("canonical"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
        Assert.Null(parameters.RemoveSynonymIds);
        Assert.False(parameters.RawBodyData.ContainsKey("removeSynonymIDs"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Bucket = null,
            AddSynonyms = null,
            AssignedTypeID = null,
            Canonical = null,
            Locale = null,
            RemoveSynonymIds = null,
            Status = null,
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.AddSynonyms);
        Assert.False(parameters.RawBodyData.ContainsKey("addSynonyms"));
        Assert.Null(parameters.AssignedTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTypeID"));
        Assert.Null(parameters.Canonical);
        Assert.False(parameters.RawBodyData.ContainsKey("canonical"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
        Assert.Null(parameters.RemoveSynonymIds);
        Assert.False(parameters.RawBodyData.ContainsKey("removeSynonymIDs"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityUpdateParams parameters = new() { ID = "id", Bucket = "bucket" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/entities/id?bucket=bucket"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityUpdateParams
        {
            ID = "id",
            Bucket = "bucket",
            AddSynonyms = ["string"],
            AssignedTypeID = "assignedTypeID",
            Canonical = "canonical",
            Locale = "locale",
            RemoveSynonymIds = ["string"],
            Status = Status.Approved,
        };

        EntityUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Approved)]
    [InlineData(Status.Rejected)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Approved)]
    [InlineData(Status.Rejected)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
