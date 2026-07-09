using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            DisplayType = DisplayType.Table,
            GroupByColumnName = "groupByColumnName",
        };

        ApiEnum<string, Function> expectedFunction = Function.Count;
        string expectedName = "name";
        string expectedAggregateColumnName = "aggregateColumnName";
        ApiEnum<string, DisplayType> expectedDisplayType = DisplayType.Table;
        string expectedGroupByColumnName = "groupByColumnName";

        Assert.Equal(expectedFunction, model.Function);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAggregateColumnName, model.AggregateColumnName);
        Assert.Equal(expectedDisplayType, model.DisplayType);
        Assert.Equal(expectedGroupByColumnName, model.GroupByColumnName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            DisplayType = DisplayType.Table,
            GroupByColumnName = "groupByColumnName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewAggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            DisplayType = DisplayType.Table,
            GroupByColumnName = "groupByColumnName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Function> expectedFunction = Function.Count;
        string expectedName = "name";
        string expectedAggregateColumnName = "aggregateColumnName";
        ApiEnum<string, DisplayType> expectedDisplayType = DisplayType.Table;
        string expectedGroupByColumnName = "groupByColumnName";

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAggregateColumnName, deserialized.AggregateColumnName);
        Assert.Equal(expectedDisplayType, deserialized.DisplayType);
        Assert.Equal(expectedGroupByColumnName, deserialized.GroupByColumnName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            DisplayType = DisplayType.Table,
            GroupByColumnName = "groupByColumnName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        Assert.Null(model.DisplayType);
        Assert.False(model.RawData.ContainsKey("displayType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",

            // Null should be interpreted as omitted for these properties
            DisplayType = null,
        };

        Assert.Null(model.DisplayType);
        Assert.False(model.RawData.ContainsKey("displayType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",

            // Null should be interpreted as omitted for these properties
            DisplayType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            DisplayType = DisplayType.Table,
        };

        Assert.Null(model.AggregateColumnName);
        Assert.False(model.RawData.ContainsKey("aggregateColumnName"));
        Assert.Null(model.GroupByColumnName);
        Assert.False(model.RawData.ContainsKey("groupByColumnName"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            DisplayType = DisplayType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            DisplayType = DisplayType.Table,

            AggregateColumnName = null,
            GroupByColumnName = null,
        };

        Assert.Null(model.AggregateColumnName);
        Assert.True(model.RawData.ContainsKey("aggregateColumnName"));
        Assert.Null(model.GroupByColumnName);
        Assert.True(model.RawData.ContainsKey("groupByColumnName"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            DisplayType = DisplayType.Table,

            AggregateColumnName = null,
            GroupByColumnName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewAggregation
        {
            Function = Function.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            DisplayType = DisplayType.Table,
            GroupByColumnName = "groupByColumnName",
        };

        ViewAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionTest : TestBase
{
    [Theory]
    [InlineData(Function.Count)]
    [InlineData(Function.CountDistinct)]
    [InlineData(Function.Sum)]
    [InlineData(Function.Average)]
    [InlineData(Function.Min)]
    [InlineData(Function.Max)]
    public void Validation_Works(Function rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Function> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Function>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Function.Count)]
    [InlineData(Function.CountDistinct)]
    [InlineData(Function.Sum)]
    [InlineData(Function.Average)]
    [InlineData(Function.Min)]
    [InlineData(Function.Max)]
    public void SerializationRoundtrip_Works(Function rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Function> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Function>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Function>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Function>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DisplayTypeTest : TestBase
{
    [Theory]
    [InlineData(DisplayType.Table)]
    [InlineData(DisplayType.BarChart)]
    [InlineData(DisplayType.PieChart)]
    public void Validation_Works(DisplayType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisplayType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisplayType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisplayType.Table)]
    [InlineData(DisplayType.BarChart)]
    [InlineData(DisplayType.PieChart)]
    public void SerializationRoundtrip_Works(DisplayType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisplayType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisplayType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisplayType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisplayType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
