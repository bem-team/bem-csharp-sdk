using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",
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
        long expectedCurrentVersionNum = 0;
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
        string expectedViewID = "viewID";
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<View>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<View>(element, ModelBase.SerializerOptions);
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
        long expectedCurrentVersionNum = 0;
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
        string expectedViewID = "viewID";
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new View
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
            CurrentVersionNum = 0,
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
            ViewID = "viewID",
            Description = "description",
        };

        View copied = new(model);

        Assert.Equal(model, copied);
    }
}
