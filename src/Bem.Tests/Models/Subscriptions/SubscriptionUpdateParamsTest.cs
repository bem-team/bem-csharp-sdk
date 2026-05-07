using System;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Subscriptions;

namespace Bem.Tests.Models.Subscriptions;

public class SubscriptionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscriptionID",
            Disabled = true,
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderID",
            Name = "name",
            S3Bucket = "s3Bucket",
            S3FilePath = "s3FilePath",
            Type = SubscriptionUpdateParamsType.Transform,
            WebhookUrl = "webhookURL",
        };

        string expectedSubscriptionID = "subscriptionID";
        bool expectedDisabled = true;
        string expectedFunctionName = "functionName";
        string expectedGoogleDriveFolderID = "googleDriveFolderID";
        string expectedName = "name";
        string expectedS3Bucket = "s3Bucket";
        string expectedS3FilePath = "s3FilePath";
        ApiEnum<string, SubscriptionUpdateParamsType> expectedType =
            SubscriptionUpdateParamsType.Transform;
        string expectedWebhookUrl = "webhookURL";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedDisabled, parameters.Disabled);
        Assert.Equal(expectedFunctionName, parameters.FunctionName);
        Assert.Equal(expectedGoogleDriveFolderID, parameters.GoogleDriveFolderID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedS3Bucket, parameters.S3Bucket);
        Assert.Equal(expectedS3FilePath, parameters.S3FilePath);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateParams { SubscriptionID = "subscriptionID" };

        Assert.Null(parameters.Disabled);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.FunctionName);
        Assert.False(parameters.RawBodyData.ContainsKey("functionName"));
        Assert.Null(parameters.GoogleDriveFolderID);
        Assert.False(parameters.RawBodyData.ContainsKey("googleDriveFolderID"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.S3Bucket);
        Assert.False(parameters.RawBodyData.ContainsKey("s3Bucket"));
        Assert.Null(parameters.S3FilePath);
        Assert.False(parameters.RawBodyData.ContainsKey("s3FilePath"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookURL"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscriptionID",

            // Null should be interpreted as omitted for these properties
            Disabled = null,
            FunctionName = null,
            GoogleDriveFolderID = null,
            Name = null,
            S3Bucket = null,
            S3FilePath = null,
            Type = null,
            WebhookUrl = null,
        };

        Assert.Null(parameters.Disabled);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.FunctionName);
        Assert.False(parameters.RawBodyData.ContainsKey("functionName"));
        Assert.Null(parameters.GoogleDriveFolderID);
        Assert.False(parameters.RawBodyData.ContainsKey("googleDriveFolderID"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.S3Bucket);
        Assert.False(parameters.RawBodyData.ContainsKey("s3Bucket"));
        Assert.Null(parameters.S3FilePath);
        Assert.False(parameters.RawBodyData.ContainsKey("s3FilePath"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookURL"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUpdateParams parameters = new() { SubscriptionID = "subscriptionID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/subscriptions/subscriptionID"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscriptionID",
            Disabled = true,
            FunctionName = "functionName",
            GoogleDriveFolderID = "googleDriveFolderID",
            Name = "name",
            S3Bucket = "s3Bucket",
            S3FilePath = "s3FilePath",
            Type = SubscriptionUpdateParamsType.Transform,
            WebhookUrl = "webhookURL",
        };

        SubscriptionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SubscriptionUpdateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionUpdateParamsType.Transform)]
    [InlineData(SubscriptionUpdateParamsType.Analyze)]
    [InlineData(SubscriptionUpdateParamsType.Route)]
    [InlineData(SubscriptionUpdateParamsType.Join)]
    [InlineData(SubscriptionUpdateParamsType.SplitCollection)]
    [InlineData(SubscriptionUpdateParamsType.SplitItem)]
    [InlineData(SubscriptionUpdateParamsType.Evaluation)]
    [InlineData(SubscriptionUpdateParamsType.Error)]
    [InlineData(SubscriptionUpdateParamsType.PayloadShaping)]
    [InlineData(SubscriptionUpdateParamsType.Enrich)]
    [InlineData(SubscriptionUpdateParamsType.CollectionProcessing)]
    public void Validation_Works(SubscriptionUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionUpdateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionUpdateParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionUpdateParamsType.Transform)]
    [InlineData(SubscriptionUpdateParamsType.Analyze)]
    [InlineData(SubscriptionUpdateParamsType.Route)]
    [InlineData(SubscriptionUpdateParamsType.Join)]
    [InlineData(SubscriptionUpdateParamsType.SplitCollection)]
    [InlineData(SubscriptionUpdateParamsType.SplitItem)]
    [InlineData(SubscriptionUpdateParamsType.Evaluation)]
    [InlineData(SubscriptionUpdateParamsType.Error)]
    [InlineData(SubscriptionUpdateParamsType.PayloadShaping)]
    [InlineData(SubscriptionUpdateParamsType.Enrich)]
    [InlineData(SubscriptionUpdateParamsType.CollectionProcessing)]
    public void SerializationRoundtrip_Works(SubscriptionUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionUpdateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionUpdateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionUpdateParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionUpdateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
