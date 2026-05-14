using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewUpdateResponseDisplayType.Table,
        };

        List<ViewUpdateResponseAggregation> expectedAggregations =
        [
            new()
            {
                Function = ViewUpdateResponseAggregationFunction.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
                GroupByColumnName = "groupByColumnName",
            },
        ];
        List<ViewUpdateResponseColumn> expectedColumns =
        [
            new()
            {
                DisplayOrderIndex = 0,
                Name = "name",
                ValueSchemaPath = ["string"],
            },
        ];
        long expectedCurrentVersionNum = 0;
        List<ViewUpdateResponseFilter> expectedFilters =
        [
            new()
            {
                ColumnName = "columnName",
                FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<ViewUpdateResponseFunction> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";
        string expectedViewID = "viewID";
        string expectedDescription = "description";
        ApiEnum<string, ViewUpdateResponseDisplayType> expectedDisplayType =
            ViewUpdateResponseDisplayType.Table;

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
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewUpdateResponseDisplayType.Table,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewUpdateResponseDisplayType.Table,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ViewUpdateResponseAggregation> expectedAggregations =
        [
            new()
            {
                Function = ViewUpdateResponseAggregationFunction.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
                GroupByColumnName = "groupByColumnName",
            },
        ];
        List<ViewUpdateResponseColumn> expectedColumns =
        [
            new()
            {
                DisplayOrderIndex = 0,
                Name = "name",
                ValueSchemaPath = ["string"],
            },
        ];
        long expectedCurrentVersionNum = 0;
        List<ViewUpdateResponseFilter> expectedFilters =
        [
            new()
            {
                ColumnName = "columnName",
                FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<ViewUpdateResponseFunction> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";
        string expectedViewID = "viewID";
        string expectedDescription = "description";
        ApiEnum<string, ViewUpdateResponseDisplayType> expectedDisplayType =
            ViewUpdateResponseDisplayType.Table;

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
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewUpdateResponseDisplayType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
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
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
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
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
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
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
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
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = ViewUpdateResponseDisplayType.Table,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = ViewUpdateResponseDisplayType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = ViewUpdateResponseDisplayType.Table,

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = ViewUpdateResponseDisplayType.Table,

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewUpdateResponse
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewUpdateResponseAggregationFunction.Count,
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
                    FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewUpdateResponseDisplayType.Table,
        };

        ViewUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewUpdateResponseAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ApiEnum<string, ViewUpdateResponseAggregationFunction> expectedFunction =
            ViewUpdateResponseAggregationFunction.Count;
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
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponseAggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponseAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ViewUpdateResponseAggregationFunction> expectedFunction =
            ViewUpdateResponseAggregationFunction.Count;
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
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
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
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
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
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
            Name = "name",

            AggregateColumnName = null,
            GroupByColumnName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewUpdateResponseAggregation
        {
            Function = ViewUpdateResponseAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ViewUpdateResponseAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewUpdateResponseAggregationFunctionTest : TestBase
{
    [Theory]
    [InlineData(ViewUpdateResponseAggregationFunction.Count)]
    [InlineData(ViewUpdateResponseAggregationFunction.CountDistinct)]
    [InlineData(ViewUpdateResponseAggregationFunction.Sum)]
    [InlineData(ViewUpdateResponseAggregationFunction.Average)]
    [InlineData(ViewUpdateResponseAggregationFunction.Min)]
    [InlineData(ViewUpdateResponseAggregationFunction.Max)]
    public void Validation_Works(ViewUpdateResponseAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateResponseAggregationFunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateResponseAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewUpdateResponseAggregationFunction.Count)]
    [InlineData(ViewUpdateResponseAggregationFunction.CountDistinct)]
    [InlineData(ViewUpdateResponseAggregationFunction.Sum)]
    [InlineData(ViewUpdateResponseAggregationFunction.Average)]
    [InlineData(ViewUpdateResponseAggregationFunction.Min)]
    [InlineData(ViewUpdateResponseAggregationFunction.Max)]
    public void SerializationRoundtrip_Works(ViewUpdateResponseAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateResponseAggregationFunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateResponseAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateResponseAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateResponseAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ViewUpdateResponseColumnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateResponseColumn
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
        var model = new ViewUpdateResponseColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponseColumn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateResponseColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponseColumn>(
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
        var model = new ViewUpdateResponseColumn
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
        var model = new ViewUpdateResponseColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        ViewUpdateResponseColumn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewUpdateResponseFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewUpdateResponseFilterFilterType> expectedFilterType =
            ViewUpdateResponseFilterFilterType.EqualsString;
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
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponseFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponseFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewUpdateResponseFilterFilterType> expectedFilterType =
            ViewUpdateResponseFilterFilterType.EqualsString;
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
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
        };

        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.String);
        Assert.False(model.RawData.ContainsKey("string"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,

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
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,

            Number = null,
            String = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewUpdateResponseFilter
        {
            ColumnName = "columnName",
            FilterType = ViewUpdateResponseFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        ViewUpdateResponseFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewUpdateResponseFilterFilterTypeTest : TestBase
{
    [Theory]
    [InlineData(ViewUpdateResponseFilterFilterType.EqualsString)]
    [InlineData(ViewUpdateResponseFilterFilterType.EqualsNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.LessThanNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.IsNull)]
    [InlineData(ViewUpdateResponseFilterFilterType.IsNotNull)]
    public void Validation_Works(ViewUpdateResponseFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateResponseFilterFilterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewUpdateResponseFilterFilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewUpdateResponseFilterFilterType.EqualsString)]
    [InlineData(ViewUpdateResponseFilterFilterType.EqualsNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.LessThanNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewUpdateResponseFilterFilterType.IsNull)]
    [InlineData(ViewUpdateResponseFilterFilterType.IsNotNull)]
    public void SerializationRoundtrip_Works(ViewUpdateResponseFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateResponseFilterFilterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateResponseFilterFilterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewUpdateResponseFilterFilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateResponseFilterFilterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ViewUpdateResponseFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewUpdateResponseFunction { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewUpdateResponseFunction { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponseFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewUpdateResponseFunction { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewUpdateResponseFunction>(
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
        var model = new ViewUpdateResponseFunction { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewUpdateResponseFunction { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewUpdateResponseFunction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewUpdateResponseFunction
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
        var model = new ViewUpdateResponseFunction
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
        var model = new ViewUpdateResponseFunction { ID = "id", Name = "name" };

        ViewUpdateResponseFunction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewUpdateResponseDisplayTypeTest : TestBase
{
    [Theory]
    [InlineData(ViewUpdateResponseDisplayType.Table)]
    [InlineData(ViewUpdateResponseDisplayType.BarChart)]
    [InlineData(ViewUpdateResponseDisplayType.PieChart)]
    public void Validation_Works(ViewUpdateResponseDisplayType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateResponseDisplayType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewUpdateResponseDisplayType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewUpdateResponseDisplayType.Table)]
    [InlineData(ViewUpdateResponseDisplayType.BarChart)]
    [InlineData(ViewUpdateResponseDisplayType.PieChart)]
    public void SerializationRoundtrip_Works(ViewUpdateResponseDisplayType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewUpdateResponseDisplayType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateResponseDisplayType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewUpdateResponseDisplayType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ViewUpdateResponseDisplayType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
