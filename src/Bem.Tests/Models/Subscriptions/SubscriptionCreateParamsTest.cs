using System;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Subscriptions = Bem.Models.Subscriptions;

namespace Bem.Tests.Models.Subscriptions;

public class SubscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            Name = "name",
            Type = Subscriptions::Type.Transform,
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            Disabled = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderID",
            S3Bucket = "s3Bucket",
            S3FilePath = "s3FilePath",
            WebhookUrl = "webhookURL",
        };

        string expectedName = "name";
        ApiEnum<string, Subscriptions::Type> expectedType = Subscriptions::Type.Transform;
        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        bool expectedDisabled = true;
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedGoogleDriveFolderID = "googleDriveFolderID";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3FilePath = "s3FilePath";
        string expectedWebhookUrl = "webhookURL";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedCollectionID, parameters.CollectionID);
        Assert.Equal(expectedCollectionName, parameters.CollectionName);
        Assert.Equal(expectedDisabled, parameters.Disabled);
        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedGoogleDriveFolderID, parameters.GoogleDriveFolderID);
        Assert.Equal(expectedS3Bucket, parameters.S3Bucket);
        Assert.Equal(expectedS3FilePath, parameters.S3FilePath);
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            Name = "name",
            Type = Subscriptions::Type.Transform,
        };

        Assert.Null(parameters.CollectionID);
        Assert.False(parameters.RawBodyData.ContainsKey("collectionID"));
        Assert.Null(parameters.CollectionName);
        Assert.False(parameters.RawBodyData.ContainsKey("collectionName"));
        Assert.Null(parameters.Disabled);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.FunctionID);
        Assert.False(parameters.RawBodyData.ContainsKey("functionID"));
        Assert.Null(parameters.FunctionName);
        Assert.False(parameters.RawBodyData.ContainsKey("functionName"));
        Assert.Null(parameters.GoogleDriveFolderID);
        Assert.False(parameters.RawBodyData.ContainsKey("googleDriveFolderID"));
        Assert.Null(parameters.S3Bucket);
        Assert.False(parameters.RawBodyData.ContainsKey("s3Bucket"));
        Assert.Null(parameters.S3FilePath);
        Assert.False(parameters.RawBodyData.ContainsKey("s3FilePath"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookURL"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            Name = "name",
            Type = Subscriptions::Type.Transform,

            // Null should be interpreted as omitted for these properties
            CollectionID = null,
            CollectionName = null,
            Disabled = null,
            FunctionID = null,
            FunctionName = null,
            GoogleDriveFolderID = null,
            S3Bucket = null,
            S3FilePath = null,
            WebhookUrl = null,
        };

        Assert.Null(parameters.CollectionID);
        Assert.False(parameters.RawBodyData.ContainsKey("collectionID"));
        Assert.Null(parameters.CollectionName);
        Assert.False(parameters.RawBodyData.ContainsKey("collectionName"));
        Assert.Null(parameters.Disabled);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.FunctionID);
        Assert.False(parameters.RawBodyData.ContainsKey("functionID"));
        Assert.Null(parameters.FunctionName);
        Assert.False(parameters.RawBodyData.ContainsKey("functionName"));
        Assert.Null(parameters.GoogleDriveFolderID);
        Assert.False(parameters.RawBodyData.ContainsKey("googleDriveFolderID"));
        Assert.Null(parameters.S3Bucket);
        Assert.False(parameters.RawBodyData.ContainsKey("s3Bucket"));
        Assert.Null(parameters.S3FilePath);
        Assert.False(parameters.RawBodyData.ContainsKey("s3FilePath"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookURL"));
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionCreateParams parameters = new()
        {
            Name = "name",
            Type = Subscriptions::Type.Transform,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/subscriptions"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            Name = "name",
            Type = Subscriptions::Type.Transform,
            CollectionID = "collectionID",
            CollectionName = "collectionName",
            Disabled = true,
            FunctionID = "functionID",
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderID",
            S3Bucket = "s3Bucket",
            S3FilePath = "s3FilePath",
            WebhookUrl = "webhookURL",
        };

        Subscriptions::SubscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::Type.Transform)]
    [InlineData(Subscriptions::Type.Analyze)]
    [InlineData(Subscriptions::Type.Route)]
    [InlineData(Subscriptions::Type.Join)]
    [InlineData(Subscriptions::Type.SplitCollection)]
    [InlineData(Subscriptions::Type.SplitItem)]
    [InlineData(Subscriptions::Type.Evaluation)]
    [InlineData(Subscriptions::Type.Error)]
    [InlineData(Subscriptions::Type.PayloadShaping)]
    [InlineData(Subscriptions::Type.Enrich)]
    [InlineData(Subscriptions::Type.CollectionProcessing)]
    public void Validation_Works(Subscriptions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::Type.Transform)]
    [InlineData(Subscriptions::Type.Analyze)]
    [InlineData(Subscriptions::Type.Route)]
    [InlineData(Subscriptions::Type.Join)]
    [InlineData(Subscriptions::Type.SplitCollection)]
    [InlineData(Subscriptions::Type.SplitItem)]
    [InlineData(Subscriptions::Type.Evaluation)]
    [InlineData(Subscriptions::Type.Error)]
    [InlineData(Subscriptions::Type.PayloadShaping)]
    [InlineData(Subscriptions::Type.Enrich)]
    [InlineData(Subscriptions::Type.CollectionProcessing)]
    public void SerializationRoundtrip_Works(Subscriptions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
