using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string expectedColumnName = "columnName";
        ApiEnum<string, FilterType> expectedFilterType = FilterType.EqualsString;
        float expectedNumber = 0;
        string expectedString = "string";

        Assert.Equal(expectedColumnName, model.ColumnName);
        Assert.Equal(expectedFilterType, model.FilterType);
        Assert.Equal(expectedNumber, model.Number);
        Assert.Equal(expectedString, model.String);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedColumnName = "columnName";
        ApiEnum<string, FilterType> expectedFilterType = FilterType.EqualsString;
        float expectedNumber = 0;
        string expectedString = "string";

        Assert.Equal(expectedColumnName, deserialized.ColumnName);
        Assert.Equal(expectedFilterType, deserialized.FilterType);
        Assert.Equal(expectedNumber, deserialized.Number);
        Assert.Equal(expectedString, deserialized.String);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,
        };

        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.String);
        Assert.False(model.RawData.ContainsKey("string"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,

            Number = null,
            String = null,
        };

        Assert.Null(model.Number);
        Assert.True(model.RawData.ContainsKey("number"));
        Assert.Null(model.String);
        Assert.True(model.RawData.ContainsKey("string"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,

            Number = null,
            String = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = FilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        ViewFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FilterTypeTest : TestBase
{
    [Theory]
    [InlineData(FilterType.EqualsString)]
    [InlineData(FilterType.EqualsNumber)]
    [InlineData(FilterType.LessThanNumber)]
    [InlineData(FilterType.LessThanEqualNumber)]
    [InlineData(FilterType.GreaterThanNumber)]
    [InlineData(FilterType.GreaterThanEqualNumber)]
    [InlineData(FilterType.IsNull)]
    [InlineData(FilterType.IsNotNull)]
    public void Validation_Works(FilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FilterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FilterType.EqualsString)]
    [InlineData(FilterType.EqualsNumber)]
    [InlineData(FilterType.LessThanNumber)]
    [InlineData(FilterType.LessThanEqualNumber)]
    [InlineData(FilterType.GreaterThanNumber)]
    [InlineData(FilterType.GreaterThanEqualNumber)]
    [InlineData(FilterType.IsNull)]
    [InlineData(FilterType.IsNotNull)]
    public void SerializationRoundtrip_Works(FilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FilterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FilterType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FilterType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
