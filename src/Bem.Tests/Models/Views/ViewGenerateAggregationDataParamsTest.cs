using System;
using System.Collections.Generic;
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
            TimeWindow = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
        TimeWindow expectedTimeWindow = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedDescription = "description";

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
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ViewGenerateAggregationDataParams
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
            TimeWindow = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ViewGenerateAggregationDataParams
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
            TimeWindow = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
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
            TimeWindow = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Description = "description",
        };

        ViewGenerateAggregationDataParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
