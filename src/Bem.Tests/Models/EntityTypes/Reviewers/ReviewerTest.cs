using System;
using System.Text.Json;
using Bem.Core;
using Bem.Models.EntityTypes.Reviewers;

namespace Bem.Tests.Models.EntityTypes.Reviewers;

public class ReviewerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Reviewer
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "email",
            ReviewerID = "reviewerID",
            Role = "role",
            UserID = "userID",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEmail = "email";
        string expectedReviewerID = "reviewerID";
        string expectedRole = "role";
        string expectedUserID = "userID";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedReviewerID, model.ReviewerID);
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Reviewer
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "email",
            ReviewerID = "reviewerID",
            Role = "role",
            UserID = "userID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Reviewer>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Reviewer
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "email",
            ReviewerID = "reviewerID",
            Role = "role",
            UserID = "userID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Reviewer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEmail = "email";
        string expectedReviewerID = "reviewerID";
        string expectedRole = "role";
        string expectedUserID = "userID";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedReviewerID, deserialized.ReviewerID);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Reviewer
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "email",
            ReviewerID = "reviewerID",
            Role = "role",
            UserID = "userID",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Reviewer
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "email",
            ReviewerID = "reviewerID",
            Role = "role",
            UserID = "userID",
        };

        Reviewer copied = new(model);

        Assert.Equal(model, copied);
    }
}
