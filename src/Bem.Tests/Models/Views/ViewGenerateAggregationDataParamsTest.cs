using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewGenerateAggregationDataParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ViewGenerateAggregationDataParams
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    GroupByColumnName = "groupByColumnName",
                },
            ],
            Columns =
            [
                new()
                {
                    DisplayOrderIndex = 0,
                    Name = "name",
                    ValueSchemaPath = ["string"],
                },
            ],
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            TimeWindow = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        List<ViewGenerateAggregationDataParamsAggregation> expectedAggregations =
        [
            new()
            {
                Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
                GroupByColumnName = "groupByColumnName",
            },
        ];
        List<ViewGenerateAggregationDataParamsColumn> expectedColumns =
        [
            new()
            {
                DisplayOrderIndex = 0,
                Name = "name",
                ValueSchemaPath = ["string"],
            },
        ];
        List<ViewGenerateAggregationDataParamsFilter> expectedFilters =
        [
            new()
            {
                ColumnName = "columnName",
                FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<ViewGenerateAggregationDataParamsFunction> expectedFunctions =
        [
            new() { ID = "id", Name = "name" },
        ];
        string expectedName = "name";
        TimeWindow expectedTimeWindow = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAggregations.Count, parameters.Aggregations.Count);
        for (int i = 0; i < expectedAggregations.Count; i++)
        {
            Assert.Equal(expectedAggregations[i], parameters.Aggregations[i]);
        }
        Assert.Equal(expectedColumns.Count, parameters.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], parameters.Columns[i]);
        }
        Assert.Equal(expectedFilters.Count, parameters.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], parameters.Filters[i]);
        }
        Assert.Equal(expectedFunctions.Count, parameters.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], parameters.Functions[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedTimeWindow, parameters.TimeWindow);
    }

    [Fact]
    public void Url_Works()
    {
        ViewGenerateAggregationDataParams parameters = new()
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    GroupByColumnName = "groupByColumnName",
                },
            ],
            Columns =
            [
                new()
                {
                    DisplayOrderIndex = 0,
                    Name = "name",
                    ValueSchemaPath = ["string"],
                },
            ],
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            TimeWindow = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/views/aggregation-data"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ViewGenerateAggregationDataParams
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    GroupByColumnName = "groupByColumnName",
                },
            ],
            Columns =
            [
                new()
                {
                    DisplayOrderIndex = 0,
                    Name = "name",
                    ValueSchemaPath = ["string"],
                },
            ],
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            TimeWindow = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        ViewGenerateAggregationDataParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ViewGenerateAggregationDataParamsAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction> expectedFunction =
            ViewGenerateAggregationDataParamsAggregationFunction.Count;
        string expectedName = "name";
        string expectedAggregateColumnName = "aggregateColumnName";
        string expectedGroupByColumnName = "groupByColumnName";

        Assert.Equal(expectedFunction, model.Function);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAggregateColumnName, model.AggregateColumnName);
        Assert.Equal(expectedGroupByColumnName, model.GroupByColumnName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataParamsAggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataParamsAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction> expectedFunction =
            ViewGenerateAggregationDataParamsAggregationFunction.Count;
        string expectedName = "name";
        string expectedAggregateColumnName = "aggregateColumnName";
        string expectedGroupByColumnName = "groupByColumnName";

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAggregateColumnName, deserialized.AggregateColumnName);
        Assert.Equal(expectedGroupByColumnName, deserialized.GroupByColumnName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",
        };

        Assert.Null(model.AggregateColumnName);
        Assert.False(model.RawData.ContainsKey("aggregateColumnName"));
        Assert.Null(model.GroupByColumnName);
        Assert.False(model.RawData.ContainsKey("groupByColumnName"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",

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
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",

            AggregateColumnName = null,
            GroupByColumnName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewGenerateAggregationDataParamsAggregation
        {
            Function = ViewGenerateAggregationDataParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ViewGenerateAggregationDataParamsAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewGenerateAggregationDataParamsAggregationFunctionTest : TestBase
{
    [Theory]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Count)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.CountDistinct)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Sum)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Average)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Min)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Max)]
    public void Validation_Works(ViewGenerateAggregationDataParamsAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Count)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.CountDistinct)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Sum)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Average)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Min)]
    [InlineData(ViewGenerateAggregationDataParamsAggregationFunction.Max)]
    public void SerializationRoundtrip_Works(
        ViewGenerateAggregationDataParamsAggregationFunction rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewGenerateAggregationDataParamsAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ViewGenerateAggregationDataParamsColumnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataParamsColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        long expectedDisplayOrderIndex = 0;
        string expectedName = "name";
        List<string> expectedValueSchemaPath = ["string"];

        Assert.Equal(expectedDisplayOrderIndex, model.DisplayOrderIndex);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedValueSchemaPath.Count, model.ValueSchemaPath.Count);
        for (int i = 0; i < expectedValueSchemaPath.Count; i++)
        {
            Assert.Equal(expectedValueSchemaPath[i], model.ValueSchemaPath[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataParamsColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataParamsColumn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewGenerateAggregationDataParamsColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataParamsColumn>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDisplayOrderIndex = 0;
        string expectedName = "name";
        List<string> expectedValueSchemaPath = ["string"];

        Assert.Equal(expectedDisplayOrderIndex, deserialized.DisplayOrderIndex);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedValueSchemaPath.Count, deserialized.ValueSchemaPath.Count);
        for (int i = 0; i < expectedValueSchemaPath.Count; i++)
        {
            Assert.Equal(expectedValueSchemaPath[i], deserialized.ValueSchemaPath[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewGenerateAggregationDataParamsColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewGenerateAggregationDataParamsColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        ViewGenerateAggregationDataParamsColumn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewGenerateAggregationDataParamsFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType> expectedFilterType =
            ViewGenerateAggregationDataParamsFilterFilterType.EqualsString;
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
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataParamsFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataParamsFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType> expectedFilterType =
            ViewGenerateAggregationDataParamsFilterFilterType.EqualsString;
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
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
        };

        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.String);
        Assert.False(model.RawData.ContainsKey("string"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,

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
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,

            Number = null,
            String = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewGenerateAggregationDataParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        ViewGenerateAggregationDataParamsFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewGenerateAggregationDataParamsFilterFilterTypeTest : TestBase
{
    [Theory]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.EqualsString)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.EqualsNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.LessThanNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.IsNull)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.IsNotNull)]
    public void Validation_Works(ViewGenerateAggregationDataParamsFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.EqualsString)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.EqualsNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.LessThanNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.IsNull)]
    [InlineData(ViewGenerateAggregationDataParamsFilterFilterType.IsNotNull)]
    public void SerializationRoundtrip_Works(
        ViewGenerateAggregationDataParamsFilterFilterType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewGenerateAggregationDataParamsFilterFilterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ViewGenerateAggregationDataParamsFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataParamsFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateAggregationDataParamsFunction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewGenerateAggregationDataParamsFunction { ID = "id", Name = "name" };

        ViewGenerateAggregationDataParamsFunction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TimeWindowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TimeWindow
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TimeWindow
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TimeWindow>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TimeWindow
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TimeWindow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TimeWindow
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TimeWindow
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        TimeWindow copied = new(model);

        Assert.Equal(model, copied);
    }
}
