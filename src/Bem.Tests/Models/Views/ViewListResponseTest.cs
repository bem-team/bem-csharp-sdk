using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewListResponse
        {
            TotalCount = 0,
            Views =
            [
                new()
                {
                    Aggregations =
                    [
                        new()
                        {
                            Function = ViewAggregationFunction.Count,
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
                            FilterType = ViewFilterFilterType.EqualsString,
                            Number = 0,
                            String = "string",
                        },
                    ],
                    Functions = [new() { ID = "id", Name = "name" }],
                    Name = "name",
                    ViewID = "viewID",
                    Description = "description",
                    DisplayType = ViewDisplayType.Table,
                },
            ],
        };

        long expectedTotalCount = 0;
        List<View> expectedViews =
        [
            new()
            {
                Aggregations =
                [
                    new()
                    {
                        Function = ViewAggregationFunction.Count,
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
                        FilterType = ViewFilterFilterType.EqualsString,
                        Number = 0,
                        String = "string",
                    },
                ],
                Functions = [new() { ID = "id", Name = "name" }],
                Name = "name",
                ViewID = "viewID",
                Description = "description",
                DisplayType = ViewDisplayType.Table,
            },
        ];

        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedViews.Count, model.Views.Count);
        for (int i = 0; i < expectedViews.Count; i++)
        {
            Assert.Equal(expectedViews[i], model.Views[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewListResponse
        {
            TotalCount = 0,
            Views =
            [
                new()
                {
                    Aggregations =
                    [
                        new()
                        {
                            Function = ViewAggregationFunction.Count,
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
                            FilterType = ViewFilterFilterType.EqualsString,
                            Number = 0,
                            String = "string",
                        },
                    ],
                    Functions = [new() { ID = "id", Name = "name" }],
                    Name = "name",
                    ViewID = "viewID",
                    Description = "description",
                    DisplayType = ViewDisplayType.Table,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewListResponse
        {
            TotalCount = 0,
            Views =
            [
                new()
                {
                    Aggregations =
                    [
                        new()
                        {
                            Function = ViewAggregationFunction.Count,
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
                            FilterType = ViewFilterFilterType.EqualsString,
                            Number = 0,
                            String = "string",
                        },
                    ],
                    Functions = [new() { ID = "id", Name = "name" }],
                    Name = "name",
                    ViewID = "viewID",
                    Description = "description",
                    DisplayType = ViewDisplayType.Table,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTotalCount = 0;
        List<View> expectedViews =
        [
            new()
            {
                Aggregations =
                [
                    new()
                    {
                        Function = ViewAggregationFunction.Count,
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
                        FilterType = ViewFilterFilterType.EqualsString,
                        Number = 0,
                        String = "string",
                    },
                ],
                Functions = [new() { ID = "id", Name = "name" }],
                Name = "name",
                ViewID = "viewID",
                Description = "description",
                DisplayType = ViewDisplayType.Table,
            },
        ];

        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedViews.Count, deserialized.Views.Count);
        for (int i = 0; i < expectedViews.Count; i++)
        {
            Assert.Equal(expectedViews[i], deserialized.Views[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewListResponse
        {
            TotalCount = 0,
            Views =
            [
                new()
                {
                    Aggregations =
                    [
                        new()
                        {
                            Function = ViewAggregationFunction.Count,
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
                            FilterType = ViewFilterFilterType.EqualsString,
                            Number = 0,
                            String = "string",
                        },
                    ],
                    Functions = [new() { ID = "id", Name = "name" }],
                    Name = "name",
                    ViewID = "viewID",
                    Description = "description",
                    DisplayType = ViewDisplayType.Table,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewListResponse
        {
            TotalCount = 0,
            Views =
            [
                new()
                {
                    Aggregations =
                    [
                        new()
                        {
                            Function = ViewAggregationFunction.Count,
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
                            FilterType = ViewFilterFilterType.EqualsString,
                            Number = 0,
                            String = "string",
                        },
                    ],
                    Functions = [new() { ID = "id", Name = "name" }],
                    Name = "name",
                    ViewID = "viewID",
                    Description = "description",
                    DisplayType = ViewDisplayType.Table,
                },
            ],
        };

        ViewListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

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
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewDisplayType.Table,
        };

        List<ViewAggregation> expectedAggregations =
        [
            new()
            {
                Function = ViewAggregationFunction.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
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
                FilterType = ViewFilterFilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<ViewFunction> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";
        string expectedViewID = "viewID";
        string expectedDescription = "description";
        ApiEnum<string, ViewDisplayType> expectedDisplayType = ViewDisplayType.Table;

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
        var model = new View
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewDisplayType.Table,
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
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewDisplayType.Table,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<View>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ViewAggregation> expectedAggregations =
        [
            new()
            {
                Function = ViewAggregationFunction.Count,
                Name = "name",
                AggregateColumnName = "aggregateColumnName",
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
                FilterType = ViewFilterFilterType.EqualsString,
                Number = 0,
                String = "string",
            },
        ];
        List<ViewFunction> expectedFunctions = [new() { ID = "id", Name = "name" }];
        string expectedName = "name";
        string expectedViewID = "viewID";
        string expectedDescription = "description";
        ApiEnum<string, ViewDisplayType> expectedDisplayType = ViewDisplayType.Table;

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
        var model = new View
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewDisplayType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new View
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
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
        var model = new View
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
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
        var model = new View
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
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
        var model = new View
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
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
        var model = new View
        {
            Aggregations =
            [
                new()
                {
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = ViewDisplayType.Table,
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
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = ViewDisplayType.Table,
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
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = ViewDisplayType.Table,

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
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            DisplayType = ViewDisplayType.Table,

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
                    Function = ViewAggregationFunction.Count,
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
                    FilterType = ViewFilterFilterType.EqualsString,
                    Number = 0,
                    String = "string",
                },
            ],
            Functions = [new() { ID = "id", Name = "name" }],
            Name = "name",
            ViewID = "viewID",
            Description = "description",
            DisplayType = ViewDisplayType.Table,
        };

        View copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewAggregation
        {
            Function = ViewAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ApiEnum<string, ViewAggregationFunction> expectedFunction = ViewAggregationFunction.Count;
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
        var model = new ViewAggregation
        {
            Function = ViewAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
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
            Function = ViewAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ViewAggregationFunction> expectedFunction = ViewAggregationFunction.Count;
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
        var model = new ViewAggregation
        {
            Function = ViewAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewAggregation { Function = ViewAggregationFunction.Count, Name = "name" };

        Assert.Null(model.AggregateColumnName);
        Assert.False(model.RawData.ContainsKey("aggregateColumnName"));
        Assert.Null(model.GroupByColumnName);
        Assert.False(model.RawData.ContainsKey("groupByColumnName"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewAggregation { Function = ViewAggregationFunction.Count, Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewAggregation
        {
            Function = ViewAggregationFunction.Count,
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
        var model = new ViewAggregation
        {
            Function = ViewAggregationFunction.Count,
            Name = "name",

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
            Function = ViewAggregationFunction.Count,
            Name = "name",
            AggregateColumnName = "aggregateColumnName",
            GroupByColumnName = "groupByColumnName",
        };

        ViewAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewAggregationFunctionTest : TestBase
{
    [Theory]
    [InlineData(ViewAggregationFunction.Count)]
    [InlineData(ViewAggregationFunction.CountDistinct)]
    [InlineData(ViewAggregationFunction.Sum)]
    [InlineData(ViewAggregationFunction.Average)]
    [InlineData(ViewAggregationFunction.Min)]
    [InlineData(ViewAggregationFunction.Max)]
    public void Validation_Works(ViewAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewAggregationFunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewAggregationFunction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewAggregationFunction.Count)]
    [InlineData(ViewAggregationFunction.CountDistinct)]
    [InlineData(ViewAggregationFunction.Sum)]
    [InlineData(ViewAggregationFunction.Average)]
    [InlineData(ViewAggregationFunction.Min)]
    [InlineData(ViewAggregationFunction.Max)]
    public void SerializationRoundtrip_Works(ViewAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewAggregationFunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewAggregationFunction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewAggregationFunction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewAggregationFunction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ViewColumnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewColumn
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
        var model = new ViewColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewColumn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewColumn>(
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
        var model = new ViewColumn
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
        var model = new ViewColumn
        {
            DisplayOrderIndex = 0,
            Name = "name",
            ValueSchemaPath = ["string"],
        };

        ViewColumn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = ViewFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        string expectedColumnName = "columnName";
        ApiEnum<string, ViewFilterFilterType> expectedFilterType =
            ViewFilterFilterType.EqualsString;
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
            FilterType = ViewFilterFilterType.EqualsString,
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
            FilterType = ViewFilterFilterType.EqualsString,
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
        ApiEnum<string, ViewFilterFilterType> expectedFilterType =
            ViewFilterFilterType.EqualsString;
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
            FilterType = ViewFilterFilterType.EqualsString,
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
            FilterType = ViewFilterFilterType.EqualsString,
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
            FilterType = ViewFilterFilterType.EqualsString,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ViewFilter
        {
            ColumnName = "columnName",
            FilterType = ViewFilterFilterType.EqualsString,

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
            FilterType = ViewFilterFilterType.EqualsString,

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
            FilterType = ViewFilterFilterType.EqualsString,
            Number = 0,
            String = "string",
        };

        ViewFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewFilterFilterTypeTest : TestBase
{
    [Theory]
    [InlineData(ViewFilterFilterType.EqualsString)]
    [InlineData(ViewFilterFilterType.EqualsNumber)]
    [InlineData(ViewFilterFilterType.LessThanNumber)]
    [InlineData(ViewFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewFilterFilterType.IsNull)]
    [InlineData(ViewFilterFilterType.IsNotNull)]
    public void Validation_Works(ViewFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewFilterFilterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewFilterFilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewFilterFilterType.EqualsString)]
    [InlineData(ViewFilterFilterType.EqualsNumber)]
    [InlineData(ViewFilterFilterType.LessThanNumber)]
    [InlineData(ViewFilterFilterType.LessThanEqualNumber)]
    [InlineData(ViewFilterFilterType.GreaterThanNumber)]
    [InlineData(ViewFilterFilterType.GreaterThanEqualNumber)]
    [InlineData(ViewFilterFilterType.IsNull)]
    [InlineData(ViewFilterFilterType.IsNotNull)]
    public void SerializationRoundtrip_Works(ViewFilterFilterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewFilterFilterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewFilterFilterType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewFilterFilterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewFilterFilterType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ViewFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewFunction { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewFunction { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewFunction { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewFunction>(
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
        var model = new ViewFunction { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewFunction { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewFunction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewFunction
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
        var model = new ViewFunction
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
        var model = new ViewFunction { ID = "id", Name = "name" };

        ViewFunction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ViewDisplayTypeTest : TestBase
{
    [Theory]
    [InlineData(ViewDisplayType.Table)]
    [InlineData(ViewDisplayType.BarChart)]
    [InlineData(ViewDisplayType.PieChart)]
    public void Validation_Works(ViewDisplayType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewDisplayType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewDisplayType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewDisplayType.Table)]
    [InlineData(ViewDisplayType.BarChart)]
    [InlineData(ViewDisplayType.PieChart)]
    public void SerializationRoundtrip_Works(ViewDisplayType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewDisplayType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewDisplayType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewDisplayType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewDisplayType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
