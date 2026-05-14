using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewGenerateAggregationDataResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataResponse
        {
            Aggregations =
            [
                new() { Groups = [new() { GroupName = "groupName", Value = 0 }], Name = "name" },
            ],
        };

        List<ViewGenerateAggregationDataResponseAggregation> expectedAggregations =
        [
            new() { Groups = [new() { GroupName = "groupName", Value = 0 }], Name = "name" },
        ];

        Assert.Equal(expectedAggregations.Count, model.Aggregations.Count);
        for (int i = 0; i < expectedAggregations.Count; i++)
        {
            Assert.Equal(expectedAggregations[i], model.Aggregations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataResponse
        {
            Aggregations =
            [
                new() { Groups = [new() { GroupName = "groupName", Value = 0 }], Name = "name" },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewGenerateAggregationDataResponse
        {
            Aggregations =
            [
                new() { Groups = [new() { GroupName = "groupName", Value = 0 }], Name = "name" },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ViewGenerateAggregationDataResponseAggregation> expectedAggregations =
        [
            new() { Groups = [new() { GroupName = "groupName", Value = 0 }], Name = "name" },
        ];

        Assert.Equal(expectedAggregations.Count, deserialized.Aggregations.Count);
        for (int i = 0; i < expectedAggregations.Count; i++)
        {
            Assert.Equal(expectedAggregations[i], deserialized.Aggregations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewGenerateAggregationDataResponse
        {
            Aggregations =
            [
                new() { Groups = [new() { GroupName = "groupName", Value = 0 }], Name = "name" },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewGenerateAggregationDataResponse
        {
            Aggregations =
            [
                new() { Groups = [new() { GroupName = "groupName", Value = 0 }], Name = "name" },
            ],
        };

        ViewGenerateAggregationDataResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewGenerateAggregationDataResponseAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataResponseAggregation
        {
            Groups = [new() { GroupName = "groupName", Value = 0 }],
            Name = "name",
        };

        List<Group> expectedGroups = [new() { GroupName = "groupName", Value = 0 }];
        string expectedName = "name";

        Assert.Equal(expectedGroups.Count, model.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], model.Groups[i]);
        }
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataResponseAggregation
        {
            Groups = [new() { GroupName = "groupName", Value = 0 }],
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ViewGenerateAggregationDataResponseAggregation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewGenerateAggregationDataResponseAggregation
        {
            Groups = [new() { GroupName = "groupName", Value = 0 }],
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ViewGenerateAggregationDataResponseAggregation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Group> expectedGroups = [new() { GroupName = "groupName", Value = 0 }];
        string expectedName = "name";

        Assert.Equal(expectedGroups.Count, deserialized.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], deserialized.Groups[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewGenerateAggregationDataResponseAggregation
        {
            Groups = [new() { GroupName = "groupName", Value = 0 }],
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewGenerateAggregationDataResponseAggregation
        {
            Groups = [new() { GroupName = "groupName", Value = 0 }],
            Name = "name",
        };

        ViewGenerateAggregationDataResponseAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Group { GroupName = "groupName", Value = 0 };

        string expectedGroupName = "groupName";
        float expectedValue = 0;

        Assert.Equal(expectedGroupName, model.GroupName);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Group { GroupName = "groupName", Value = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Group { GroupName = "groupName", Value = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedGroupName = "groupName";
        float expectedValue = 0;

        Assert.Equal(expectedGroupName, deserialized.GroupName);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Group { GroupName = "groupName", Value = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Group { GroupName = "groupName", Value = 0 };

        Group copied = new(model);

        Assert.Equal(model, copied);
    }
}
