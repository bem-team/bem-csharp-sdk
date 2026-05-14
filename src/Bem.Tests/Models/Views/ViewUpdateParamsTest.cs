using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ViewUpdateParams
        {
            ViewID = "view_id",
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateParamsAggregationFunction.Count,
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
                    FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
        };

        string expectedViewID = "view_id";
        List<ViewUpdateParamsAggregation> expectedAggregations =
        [
            new()
            {
                Function = ViewUpdateParamsAggregationFunction.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
                GroupByColumnName = "groupByColumnName",
            },
        ];
        List<ViewUpdateParamsColumn> expectedColumns =
        [
            new()
            {
                DisplayOrderIndex = 0,
                Name = "name",
                ValueSchemaPath = ["string"],
            },
        ];
        List<ViewUpdateParamsFilter> expectedFilters =
        [
            new()
            {
                ColumnName = "columnName",
                FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<ViewUpdateParamsFunction> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";

        Assert.Equal(expectedViewID, parameters.ViewID);
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
    }

    [Fact]
    public void Url_Works()
    {
        ViewUpdateParams parameters = new()
        {
            ViewID = "view_id",
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateParamsAggregationFunction.Count,
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
                    FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/views/view_id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ViewUpdateParams
        {
            ViewID = "view_id",
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateParamsAggregationFunction.Count,
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
                    FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
        };

        ViewUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ViewUpdateParamsAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ApiEnum<string, ViewUpdateParamsAggregationFunction> expectedFunction =
            ViewUpdateParamsAggregationFunction.Count;
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
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateParamsAggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateParamsAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ViewUpdateParamsAggregationFunction> expectedFunction =
            ViewUpdateParamsAggregationFunction.Count;
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
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
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
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
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
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
            Name = "name",

            AggregateColumnName = null,
            GroupByColumnName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewUpdateParamsAggregation
        {
            Function = ViewUpdateParamsAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ViewUpdateParamsAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewUpdateParamsAggregationFunctionTest : TestBase
{
    [Theory]
    [InlineData(ViewUpdateParamsAggregationFunction.Count)]
    [InlineData(ViewUpdateParamsAggregationFunction.CountDistinct)]
    [InlineData(ViewUpdateParamsAggregationFunction.Sum)]
    [InlineData(ViewUpdateParamsAggregationFunction.Average)]
    [InlineData(ViewUpdateParamsAggregationFunction.Min)]
    [InlineData(ViewUpdateParamsAggregationFunction.Max)]
    public void Validation_Works(ViewUpdateParamsAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateParamsAggregationFunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateParamsAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewUpdateParamsAggregationFunction.Count)]
    [InlineData(ViewUpdateParamsAggregationFunction.CountDistinct)]
    [InlineData(ViewUpdateParamsAggregationFunction.Sum)]
    [InlineData(ViewUpdateParamsAggregationFunction.Average)]
    [InlineData(ViewUpdateParamsAggregationFunction.Min)]
    [InlineData(ViewUpdateParamsAggregationFunction.Max)]
    public void SerializationRoundtrip_Works(ViewUpdateParamsAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateParamsAggregationFunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateParamsAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateParamsAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateParamsAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ViewUpdateParamsColumnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateParamsColumn
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
        var model = new ViewUpdateParamsColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateParamsColumn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateParamsColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateParamsColumn>(
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
        var model = new ViewUpdateParamsColumn
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
        var model = new ViewUpdateParamsColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        ViewUpdateParamsColumn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewUpdateParamsFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewUpdateParamsFilterFilterType> expectedFilterType =
            ViewUpdateParamsFilterFilterType.EqualsString;
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
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateParamsFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateParamsFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewUpdateParamsFilterFilterType> expectedFilterType =
            ViewUpdateParamsFilterFilterType.EqualsString;
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
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
        };

        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.String);
        Assert.False(model.RawData.ContainsKey("string"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,

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
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,

            Number = null,
            String = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewUpdateParamsFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateParamsFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        ViewUpdateParamsFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewUpdateParamsFilterFilterTypeTest : TestBase
{
    [Theory]
    [InlineData(ViewUpdateParamsFilterFilterType.EqualsString)]
    [InlineData(ViewUpdateParamsFilterFilterType.EqualsNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.LessThanNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.IsNull)]
    [InlineData(ViewUpdateParamsFilterFilterType.IsNotNull)]
    public void Validation_Works(ViewUpdateParamsFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateParamsFilterFilterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewUpdateParamsFilterFilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewUpdateParamsFilterFilterType.EqualsString)]
    [InlineData(ViewUpdateParamsFilterFilterType.EqualsNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.LessThanNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewUpdateParamsFilterFilterType.IsNull)]
    [InlineData(ViewUpdateParamsFilterFilterType.IsNotNull)]
    public void SerializationRoundtrip_Works(ViewUpdateParamsFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateParamsFilterFilterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateParamsFilterFilterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewUpdateParamsFilterFilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateParamsFilterFilterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ViewUpdateParamsFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateParamsFunction { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewUpdateParamsFunction { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateParamsFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateParamsFunction { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateParamsFunction>(
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
        var model = new ViewUpdateParamsFunction { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewUpdateParamsFunction { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewUpdateParamsFunction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewUpdateParamsFunction
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
        var model = new ViewUpdateParamsFunction
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
        var model = new ViewUpdateParamsFunction { ID = "id", Name = "name" };

        ViewUpdateParamsFunction copied = new(model);

        Assert.Equal(model, copied);
    }
}
