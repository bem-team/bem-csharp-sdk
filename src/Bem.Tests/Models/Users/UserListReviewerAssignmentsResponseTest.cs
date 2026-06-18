using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Users;

namespace Bem.Tests.Models.Users;

public class UserListReviewerAssignmentsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserListReviewerAssignmentsResponse
        {
            Assignments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    TypeID = "typeID",
                },
            ],
        };

        List<Assignment> expectedAssignments =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Name = "name",
                TypeID = "typeID",
            },
        ];

        Assert.Equal(expectedAssignments.Count, model.Assignments.Count);
        for (int i = 0; i < expectedAssignments.Count; i++)
        {
            Assert.Equal(expectedAssignments[i], model.Assignments[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserListReviewerAssignmentsResponse
        {
            Assignments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    TypeID = "typeID",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListReviewerAssignmentsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserListReviewerAssignmentsResponse
        {
            Assignments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    TypeID = "typeID",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListReviewerAssignmentsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Assignment> expectedAssignments =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Name = "name",
                TypeID = "typeID",
            },
        ];

        Assert.Equal(expectedAssignments.Count, deserialized.Assignments.Count);
        for (int i = 0; i < expectedAssignments.Count; i++)
        {
            Assert.Equal(expectedAssignments[i], deserialized.Assignments[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserListReviewerAssignmentsResponse
        {
            Assignments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    TypeID = "typeID",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserListReviewerAssignmentsResponse
        {
            Assignments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    TypeID = "typeID",
                },
            ],
        };

        UserListReviewerAssignmentsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AssignmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Assignment
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            TypeID = "typeID",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedTypeID = "typeID";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTypeID, model.TypeID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Assignment
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            TypeID = "typeID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Assignment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Assignment
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            TypeID = "typeID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Assignment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedTypeID = "typeID";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTypeID, deserialized.TypeID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Assignment
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            TypeID = "typeID",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Assignment
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Name = "name",
            TypeID = "typeID",
        };

        Assignment copied = new(model);

        Assert.Equal(model, copied);
    }
}
