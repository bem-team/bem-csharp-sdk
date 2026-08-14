using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.EntityTypes.Reviewers;

namespace Bem.Tests.Models.EntityTypes.Reviewers;

public class ReviewerListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReviewerListResponse
        {
            Reviewers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "email",
                    ReviewerID = "reviewerID",
                    Role = "role",
                    UserID = "userID",
                },
            ],
        };

        List<Reviewer> expectedReviewers =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Email = "email",
                ReviewerID = "reviewerID",
                Role = "role",
                UserID = "userID",
            },
        ];

        Assert.Equal(expectedReviewers.Count, model.Reviewers.Count);
        for (int i = 0; i < expectedReviewers.Count; i++)
        {
            Assert.Equal(expectedReviewers[i], model.Reviewers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReviewerListResponse
        {
            Reviewers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "email",
                    ReviewerID = "reviewerID",
                    Role = "role",
                    UserID = "userID",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewerListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReviewerListResponse
        {
            Reviewers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "email",
                    ReviewerID = "reviewerID",
                    Role = "role",
                    UserID = "userID",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewerListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Reviewer> expectedReviewers =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Email = "email",
                ReviewerID = "reviewerID",
                Role = "role",
                UserID = "userID",
            },
        ];

        Assert.Equal(expectedReviewers.Count, deserialized.Reviewers.Count);
        for (int i = 0; i < expectedReviewers.Count; i++)
        {
            Assert.Equal(expectedReviewers[i], deserialized.Reviewers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReviewerListResponse
        {
            Reviewers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "email",
                    ReviewerID = "reviewerID",
                    Role = "role",
                    UserID = "userID",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReviewerListResponse
        {
            Reviewers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "email",
                    ReviewerID = "reviewerID",
                    Role = "role",
                    UserID = "userID",
                },
            ],
        };

        ReviewerListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
