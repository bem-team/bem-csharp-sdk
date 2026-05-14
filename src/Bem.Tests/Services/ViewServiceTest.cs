using System;
using System.Threading.Tasks;
using Bem.Models.Views;

namespace Bem.Tests.Services;

public class ViewServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var view = await this.client.Views.Create(
            new()
            {
                Aggregations =
                [
                    new()
                    {
                        Function = Function.Count,
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
                        FilterType = FilterType.EqualsString,
                        Number = 0,
                        String = "string",
                    },
                ],
                Functions = [new() { ID = "id", Name = "name" }],
                Name = "name",
            },
            TestContext.Current.CancellationToken
        );
        view.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var view = await this.client.Views.Retrieve(
            "view_id",
            new(),
            TestContext.Current.CancellationToken
        );
        view.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var view = await this.client.Views.Update(
            "view_id",
            new()
            {
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
            },
            TestContext.Current.CancellationToken
        );
        view.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var views = await this.client.Views.List(new(), TestContext.Current.CancellationToken);
        views.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Views.Delete("view_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GenerateAggregationData_Works()
    {
        var response = await this.client.Views.GenerateAggregationData(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GenerateTableData_Works()
    {
        var response = await this.client.Views.GenerateTableData(
            new()
            {
                Aggregations =
                [
                    new()
                    {
                        Function = ViewGenerateTableDataParamsAggregationFunction.Count,
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
                        FilterType = ViewGenerateTableDataParamsFilterFilterType.EqualsString,
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
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
