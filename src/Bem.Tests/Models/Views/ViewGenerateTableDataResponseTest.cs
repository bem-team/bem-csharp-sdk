using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Models.Views;

namespace Bem.Tests.Models.Views;

public class ViewGenerateTableDataResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewGenerateTableDataResponse
        {
            Rows =
            [
                new()
                {
                    Columns = [new() { ColumnName = "columnName", Value = "string" }],
                    EventID = "eventID",
                },
            ],
            TotalCount = 0,
        };

        List<Row> expectedRows =
        [
            new()
            {
                Columns = [new() { ColumnName = "columnName", Value = "string" }],
                EventID = "eventID",
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedRows.Count, model.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i], model.Rows[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewGenerateTableDataResponse
        {
            Rows =
            [
                new()
                {
                    Columns = [new() { ColumnName = "columnName", Value = "string" }],
                    EventID = "eventID",
                },
            ],
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateTableDataResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewGenerateTableDataResponse
        {
            Rows =
            [
                new()
                {
                    Columns = [new() { ColumnName = "columnName", Value = "string" }],
                    EventID = "eventID",
                },
            ],
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ViewGenerateTableDataResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Row> expectedRows =
        [
            new()
            {
                Columns = [new() { ColumnName = "columnName", Value = "string" }],
                EventID = "eventID",
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedRows.Count, deserialized.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i], deserialized.Rows[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewGenerateTableDataResponse
        {
            Rows =
            [
                new()
                {
                    Columns = [new() { ColumnName = "columnName", Value = "string" }],
                    EventID = "eventID",
                },
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ViewGenerateTableDataResponse
        {
            Rows =
            [
                new()
                {
                    Columns = [new() { ColumnName = "columnName", Value = "string" }],
                    EventID = "eventID",
                },
            ],
            TotalCount = 0,
        };

        ViewGenerateTableDataResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Row
        {
            Columns = [new() { ColumnName = "columnName", Value = "string" }],
            EventID = "eventID",
        };

        List<Column> expectedColumns = [new() { ColumnName = "columnName", Value = "string" }];
        string expectedEventID = "eventID";

        Assert.Equal(expectedColumns.Count, model.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], model.Columns[i]);
        }
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Row
        {
            Columns = [new() { ColumnName = "columnName", Value = "string" }],
            EventID = "eventID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Row>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Row
        {
            Columns = [new() { ColumnName = "columnName", Value = "string" }],
            EventID = "eventID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Row>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Column> expectedColumns = [new() { ColumnName = "columnName", Value = "string" }];
        string expectedEventID = "eventID";

        Assert.Equal(expectedColumns.Count, deserialized.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], deserialized.Columns[i]);
        }
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Row
        {
            Columns = [new() { ColumnName = "columnName", Value = "string" }],
            EventID = "eventID",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Row
        {
            Columns = [new() { ColumnName = "columnName", Value = "string" }],
            EventID = "eventID",
        };

        Row copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ColumnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Column { ColumnName = "columnName", Value = "string" };

        string expectedColumnName = "columnName";
        ColumnValue expectedValue = "string";

        Assert.Equal(expectedColumnName, model.ColumnName);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Column { ColumnName = "columnName", Value = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Column>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Column { ColumnName = "columnName", Value = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Column>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedColumnName = "columnName";
        ColumnValue expectedValue = "string";

        Assert.Equal(expectedColumnName, deserialized.ColumnName);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Column { ColumnName = "columnName", Value = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Column { ColumnName = "columnName", Value = "string" };

        Column copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ColumnValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ColumnValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ColumnValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ColumnValue value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks()
    {
        ColumnValue value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void JsonElementValidationWorks1()
    {
        ColumnValue value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        ColumnValue value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ColumnValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ColumnValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ColumnValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ColumnValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ColumnValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ColumnValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        ColumnValue value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ColumnValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks1()
    {
        ColumnValue value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ColumnValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ColumnValue value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ColumnValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
