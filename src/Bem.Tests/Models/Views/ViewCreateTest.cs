using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            Description = "description",
        };

        List<ViewAggregation> expectedAggregations =
        [
            new()
            {
                Function = Function.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
                DisplayType = DisplayType.Table,
                GroupByColumnName = "groupByColumnName",
            },
        ];
        List<ViewColumn> expectedColumns =
        [
            new()
            {
                DisplayOrderIndex = 0,
                Name = "name",
                ValueSchemaPath = ["string"],
            },
        ];
        List<ViewFilter> expectedFilters =
        [
            new()
            {
                ColumnName = "columnName",
                FilterType = FilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<FunctionIdentifier> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";
        string expectedDescription = "description";

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
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ViewAggregation> expectedAggregations =
        [
            new()
            {
                Function = Function.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
                DisplayType = DisplayType.Table,
                GroupByColumnName = "groupByColumnName",
            },
        ];
        List<ViewColumn> expectedColumns =
        [
            new()
            {
                DisplayOrderIndex = 0,
                Name = "name",
                ValueSchemaPath = ["string"],
            },
        ];
        List<ViewFilter> expectedFilters =
        [
            new()
            {
                ColumnName = "columnName",
                FilterType = FilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<FunctionIdentifier> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";
        string expectedDescription = "description";

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
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewCreate
        {
            Aggregations =
            [
                new()
                {
                    Function = Function.Count,
                    Name = "name",
                    AggregateColumnName = "aggregateColumnName",
                    DisplayType = DisplayType.Table,
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
                    FilterType = FilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            Description = "description",
        };

        ViewCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}
