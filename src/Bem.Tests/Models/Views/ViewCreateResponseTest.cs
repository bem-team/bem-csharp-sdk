using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = DisplayType.Table,
        };

        List<ViewCreateResponseAggregation> expectedAggregations =
        [
            new()
            {
                Function = ViewCreateResponseAggregationFunction.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
                GroupByColumnName = "groupByColumnName",
            },
        ];
        List<ViewCreateResponseColumn> expectedColumns =
        [
            new()
            {
                DisplayOrderIndex = 0,
                Name = "name",
                ValueSchemaPath = ["string"],
            },
        ];
        long expectedCurrentVersionNum = 0;
        List<ViewCreateResponseFilter> expectedFilters =
        [
            new()
            {
                ColumnName = "columnName",
                FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<ViewCreateResponseFunction> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";
        string expectedViewID = "viewID";
        string expectedDescription = "description";
        ApiEnum<string, DisplayType> expectedDisplayType = DisplayType.Table;

        Assert.Equal(expectedAggregations.Count, model.Aggregations.Count);
        for (int i = 0; i < expectedAggregations.Count; i++)
        {
            Assert.Equal(expectedAggregations[i], model.Aggregations[i]);
        }
        Assert.Equal(expectedColumns.Count, model.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], model.Columns[i]);
        }
        Assert.Equal(expectedCurrentVersionNum, model.CurrentVersionNum);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedFunctions.Count, model.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], model.Functions[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedViewID, model.ViewID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayType, model.DisplayType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = DisplayType.Table,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = DisplayType.Table,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ViewCreateResponseAggregation> expectedAggregations =
        [
            new()
            {
                Function = ViewCreateResponseAggregationFunction.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
                GroupByColumnName = "groupByColumnName",
            },
        ];
        List<ViewCreateResponseColumn> expectedColumns =
        [
            new()
            {
                DisplayOrderIndex = 0,
                Name = "name",
                ValueSchemaPath = ["string"],
            },
        ];
        long expectedCurrentVersionNum = 0;
        List<ViewCreateResponseFilter> expectedFilters =
        [
            new()
            {
                ColumnName = "columnName",
                FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<ViewCreateResponseFunction> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";
        string expectedViewID = "viewID";
        string expectedDescription = "description";
        ApiEnum<string, DisplayType> expectedDisplayType = DisplayType.Table;

        Assert.Equal(expectedAggregations.Count, deserialized.Aggregations.Count);
        for (int i = 0; i < expectedAggregations.Count; i++)
        {
            Assert.Equal(expectedAggregations[i], deserialized.Aggregations[i]);
        }
        Assert.Equal(expectedColumns.Count, deserialized.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], deserialized.Columns[i]);
        }
        Assert.Equal(expectedCurrentVersionNum, deserialized.CurrentVersionNum);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedFunctions.Count, deserialized.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], deserialized.Functions[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedViewID, deserialized.ViewID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayType, deserialized.DisplayType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = DisplayType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
        };

        Assert.Null(model.DisplayType);
        Assert.False(model.RawData.ContainsKey("displayType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            DisplayType = null,
        };

        Assert.Null(model.DisplayType);
        Assert.False(model.RawData.ContainsKey("displayType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            DisplayType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = DisplayType.Table,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = DisplayType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = DisplayType.Table,

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = DisplayType.Table,

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewCreateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewCreateResponseAggregationFunction.Count,
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
            CurrentVersionNum = 0,
            Filters =
            [
                new()
                {
                    ColumnName = "columnName",
                    FilterType = ViewCreateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = DisplayType.Table,
        };

        ViewCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewCreateResponseAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ApiEnum<string, ViewCreateResponseAggregationFunction> expectedFunction =
            ViewCreateResponseAggregationFunction.Count;
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
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponseAggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponseAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ViewCreateResponseAggregationFunction> expectedFunction =
            ViewCreateResponseAggregationFunction.Count;
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
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
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
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
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
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
            Name = "name",

            AggregateColumnName = null,
            GroupByColumnName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewCreateResponseAggregation
        {
            Function = ViewCreateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ViewCreateResponseAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewCreateResponseAggregationFunctionTest : TestBase
{
    [Theory]
    [InlineData(ViewCreateResponseAggregationFunction.Count)]
    [InlineData(ViewCreateResponseAggregationFunction.CountDistinct)]
    [InlineData(ViewCreateResponseAggregationFunction.Sum)]
    [InlineData(ViewCreateResponseAggregationFunction.Average)]
    [InlineData(ViewCreateResponseAggregationFunction.Min)]
    [InlineData(ViewCreateResponseAggregationFunction.Max)]
    public void Validation_Works(ViewCreateResponseAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewCreateResponseAggregationFunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewCreateResponseAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewCreateResponseAggregationFunction.Count)]
    [InlineData(ViewCreateResponseAggregationFunction.CountDistinct)]
    [InlineData(ViewCreateResponseAggregationFunction.Sum)]
    [InlineData(ViewCreateResponseAggregationFunction.Average)]
    [InlineData(ViewCreateResponseAggregationFunction.Min)]
    [InlineData(ViewCreateResponseAggregationFunction.Max)]
    public void SerializationRoundtrip_Works(ViewCreateResponseAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewCreateResponseAggregationFunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewCreateResponseAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewCreateResponseAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewCreateResponseAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ViewCreateResponseColumnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewCreateResponseColumn
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
        var model = new ViewCreateResponseColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponseColumn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewCreateResponseColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponseColumn>(
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
        var model = new ViewCreateResponseColumn
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
        var model = new ViewCreateResponseColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        ViewCreateResponseColumn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewCreateResponseFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewCreateResponseFilterFilterType> expectedFilterType =
            ViewCreateResponseFilterFilterType.EqualsString;
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
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponseFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponseFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewCreateResponseFilterFilterType> expectedFilterType =
            ViewCreateResponseFilterFilterType.EqualsString;
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
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,
        };

        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.String);
        Assert.False(model.RawData.ContainsKey("string"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,

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
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,

            Number = null,
            String = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewCreateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewCreateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        ViewCreateResponseFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewCreateResponseFilterFilterTypeTest : TestBase
{
    [Theory]
    [InlineData(ViewCreateResponseFilterFilterType.EqualsString)]
    [InlineData(ViewCreateResponseFilterFilterType.EqualsNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.LessThanNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.IsNull)]
    [InlineData(ViewCreateResponseFilterFilterType.IsNotNull)]
    public void Validation_Works(ViewCreateResponseFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewCreateResponseFilterFilterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewCreateResponseFilterFilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewCreateResponseFilterFilterType.EqualsString)]
    [InlineData(ViewCreateResponseFilterFilterType.EqualsNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.LessThanNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewCreateResponseFilterFilterType.IsNull)]
    [InlineData(ViewCreateResponseFilterFilterType.IsNotNull)]
    public void SerializationRoundtrip_Works(ViewCreateResponseFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewCreateResponseFilterFilterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewCreateResponseFilterFilterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewCreateResponseFilterFilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewCreateResponseFilterFilterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ViewCreateResponseFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewCreateResponseFunction { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewCreateResponseFunction { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponseFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewCreateResponseFunction { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreateResponseFunction>(
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
        var model = new ViewCreateResponseFunction { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewCreateResponseFunction { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewCreateResponseFunction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewCreateResponseFunction
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
        var model = new ViewCreateResponseFunction
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
        var model = new ViewCreateResponseFunction { ID = "id", Name = "name" };

        ViewCreateResponseFunction copied = new(model);

        Assert.Equal(model, copied);
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
