using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
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
                },
            ],
        };

        ViewListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
