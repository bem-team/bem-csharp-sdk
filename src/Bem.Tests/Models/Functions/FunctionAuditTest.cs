using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class FunctionAuditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionAudit
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        UserActionSummary expectedFunctionCreatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };
        UserActionSummary expectedFunctionLastUpdatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };
        UserActionSummary expectedVersionCreatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        Assert.Equal(expectedFunctionCreatedBy, model.FunctionCreatedBy);
        Assert.Equal(expectedFunctionLastUpdatedBy, model.FunctionLastUpdatedBy);
        Assert.Equal(expectedVersionCreatedBy, model.VersionCreatedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionAudit
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionAudit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionAudit
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionAudit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        UserActionSummary expectedFunctionCreatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };
        UserActionSummary expectedFunctionLastUpdatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };
        UserActionSummary expectedVersionCreatedBy = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserActionID = "userActionID",
            ApiKeyName = "apiKeyName",
            EmailAddress = "emailAddress",
            UserEmail = "userEmail",
            UserID = "userID",
        };

        Assert.Equal(expectedFunctionCreatedBy, deserialized.FunctionCreatedBy);
        Assert.Equal(expectedFunctionLastUpdatedBy, deserialized.FunctionLastUpdatedBy);
        Assert.Equal(expectedVersionCreatedBy, deserialized.VersionCreatedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionAudit
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionAudit { };

        Assert.Null(model.FunctionCreatedBy);
        Assert.False(model.RawData.ContainsKey("functionCreatedBy"));
        Assert.Null(model.FunctionLastUpdatedBy);
        Assert.False(model.RawData.ContainsKey("functionLastUpdatedBy"));
        Assert.Null(model.VersionCreatedBy);
        Assert.False(model.RawData.ContainsKey("versionCreatedBy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionAudit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionAudit
        {
            // Null should be interpreted as omitted for these properties
            FunctionCreatedBy = null,
            FunctionLastUpdatedBy = null,
            VersionCreatedBy = null,
        };

        Assert.Null(model.FunctionCreatedBy);
        Assert.False(model.RawData.ContainsKey("functionCreatedBy"));
        Assert.Null(model.FunctionLastUpdatedBy);
        Assert.False(model.RawData.ContainsKey("functionLastUpdatedBy"));
        Assert.Null(model.VersionCreatedBy);
        Assert.False(model.RawData.ContainsKey("versionCreatedBy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionAudit
        {
            // Null should be interpreted as omitted for these properties
            FunctionCreatedBy = null,
            FunctionLastUpdatedBy = null,
            VersionCreatedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionAudit
        {
            FunctionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            FunctionLastUpdatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
            VersionCreatedBy = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserActionID = "userActionID",
                ApiKeyName = "apiKeyName",
                EmailAddress = "emailAddress",
                UserEmail = "userEmail",
                UserID = "userID",
            },
        };

        FunctionAudit copied = new(model);

        Assert.Equal(model, copied);
    }
}
