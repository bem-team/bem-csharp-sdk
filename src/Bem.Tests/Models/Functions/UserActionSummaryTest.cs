using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class UserActionSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserActionID = "userActionID";
        string expectedApiKeyName = "apiKeyName";
        string expectedEmailAddress = "emailAddress";
        string expectedUserEmail = "userEmail";
        string expectedUserID = "userID";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUserActionID, model.UserActionID);
        Assert.Equal(expectedApiKeyName, model.ApiKeyName);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.Equal(expectedUserEmail, model.UserEmail);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserActionSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserActionSummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserActionID = "userActionID";
        string expectedApiKeyName = "apiKeyName";
        string expectedEmailAddress = "emailAddress";
        string expectedUserEmail = "userEmail";
        string expectedUserID = "userID";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUserActionID, deserialized.UserActionID);
        Assert.Equal(expectedApiKeyName, deserialized.ApiKeyName);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.Equal(expectedUserEmail, deserialized.UserEmail);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
        };

        Assert.Null(model.ApiKeyName);
        Assert.False(model.RawData.ContainsKey("apiKeyName"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("emailAddress"));
        Assert.Null(model.UserEmail);
        Assert.False(model.RawData.ContainsKey("userEmail"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("userID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",

            // Null should be interpreted as omitted for these properties
            ApiKeyName = null,
            EmailAddress = null,
            UserEmail = null,
            UserID = null,
        };

        Assert.Null(model.ApiKeyName);
        Assert.False(model.RawData.ContainsKey("apiKeyName"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("emailAddress"));
        Assert.Null(model.UserEmail);
        Assert.False(model.RawData.ContainsKey("userEmail"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("userID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",

            // Null should be interpreted as omitted for these properties
            ApiKeyName = null,
            EmailAddress = null,
            UserEmail = null,
            UserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserActionSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        UserActionSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}
