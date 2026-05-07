using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Subscriptions;

namespace Bem.Tests.Models.Subscriptions;

public class SubscriptionV3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,
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
        string expectedSubscriptionID = "subscriptionID";
        ApiEnum<string, SubscriptionV3Type> expectedType = SubscriptionV3Type.Transform;
        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        bool expectedDisabled = true;
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedGoogleDriveFolderID = "googleDriveFolderID";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3FilePath = "s3FilePath";
        string expectedWebhookUrl = "webhookURL";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCollectionID, model.CollectionID);
        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedDisabled, model.Disabled);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedGoogleDriveFolderID, model.GoogleDriveFolderID);
        Assert.Equal(expectedS3Bucket, model.S3Bucket);
        Assert.Equal(expectedS3FilePath, model.S3FilePath);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionV3>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionV3>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedSubscriptionID = "subscriptionID";
        ApiEnum<string, SubscriptionV3Type> expectedType = SubscriptionV3Type.Transform;
        string expectedCollectionID = "collectionID";
        string expectedCollectionName = "collectionName";
        bool expectedDisabled = true;
        string expectedFunctionID = "functionID";
        string expectedFunctionName = "functionName";
        string expectedGoogleDriveFolderID = "googleDriveFolderID";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3FilePath = "s3FilePath";
        string expectedWebhookUrl = "webhookURL";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCollectionID, deserialized.CollectionID);
        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedDisabled, deserialized.Disabled);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedGoogleDriveFolderID, deserialized.GoogleDriveFolderID);
        Assert.Equal(expectedS3Bucket, deserialized.S3Bucket);
        Assert.Equal(expectedS3FilePath, deserialized.S3FilePath);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,
        };

        Assert.Null(model.CollectionID);
        Assert.False(model.RawData.ContainsKey("collectionID"));
        Assert.Null(model.CollectionName);
        Assert.False(model.RawData.ContainsKey("collectionName"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.FunctionID);
        Assert.False(model.RawData.ContainsKey("functionID"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.GoogleDriveFolderID);
        Assert.False(model.RawData.ContainsKey("googleDriveFolderID"));
        Assert.Null(model.S3Bucket);
        Assert.False(model.RawData.ContainsKey("s3Bucket"));
        Assert.Null(model.S3FilePath);
        Assert.False(model.RawData.ContainsKey("s3FilePath"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookURL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,

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

        Assert.Null(model.CollectionID);
        Assert.False(model.RawData.ContainsKey("collectionID"));
        Assert.Null(model.CollectionName);
        Assert.False(model.RawData.ContainsKey("collectionName"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.FunctionID);
        Assert.False(model.RawData.ContainsKey("functionID"));
        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.GoogleDriveFolderID);
        Assert.False(model.RawData.ContainsKey("googleDriveFolderID"));
        Assert.Null(model.S3Bucket);
        Assert.False(model.RawData.ContainsKey("s3Bucket"));
        Assert.Null(model.S3FilePath);
        Assert.False(model.RawData.ContainsKey("s3FilePath"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookURL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,

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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionV3
        {
            Name = "name",
            SubscriptionID = "subscriptionID",
            Type = SubscriptionV3Type.Transform,
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

        SubscriptionV3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionV3TypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionV3Type.Transform)]
    [InlineData(SubscriptionV3Type.Analyze)]
    [InlineData(SubscriptionV3Type.Route)]
    [InlineData(SubscriptionV3Type.Join)]
    [InlineData(SubscriptionV3Type.SplitCollection)]
    [InlineData(SubscriptionV3Type.SplitItem)]
    [InlineData(SubscriptionV3Type.Evaluation)]
    [InlineData(SubscriptionV3Type.Error)]
    [InlineData(SubscriptionV3Type.PayloadShaping)]
    [InlineData(SubscriptionV3Type.Enrich)]
    [InlineData(SubscriptionV3Type.CollectionProcessing)]
    public void Validation_Works(SubscriptionV3Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionV3Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionV3Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionV3Type.Transform)]
    [InlineData(SubscriptionV3Type.Analyze)]
    [InlineData(SubscriptionV3Type.Route)]
    [InlineData(SubscriptionV3Type.Join)]
    [InlineData(SubscriptionV3Type.SplitCollection)]
    [InlineData(SubscriptionV3Type.SplitItem)]
    [InlineData(SubscriptionV3Type.Evaluation)]
    [InlineData(SubscriptionV3Type.Error)]
    [InlineData(SubscriptionV3Type.PayloadShaping)]
    [InlineData(SubscriptionV3Type.Enrich)]
    [InlineData(SubscriptionV3Type.CollectionProcessing)]
    public void SerializationRoundtrip_Works(SubscriptionV3Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionV3Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionV3Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionV3Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionV3Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
