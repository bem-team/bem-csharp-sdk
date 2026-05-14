using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Views;

/// <summary>
/// Response containing paginated view table data
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ViewGenerateTableDataResponse, ViewGenerateTableDataResponseFromRaw>)
)]
public sealed record class ViewGenerateTableDataResponse : JsonModel
{
    /// <summary>
    /// Array of rows matching the view configuration
    /// </summary>
    public required IReadOnlyList<Row> Rows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Row>>("rows");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Row>>("rows", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Total number of rows matching the view (before pagination)
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalCount");
        }
        init { this._rawData.Set("totalCount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Rows)
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public ViewGenerateTableDataResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateTableDataResponse(
        ViewGenerateTableDataResponse viewGenerateTableDataResponse
    )
        : base(viewGenerateTableDataResponse) { }
#pragma warning restore CS8618

    public ViewGenerateTableDataResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateTableDataResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateTableDataResponseFromRaw.FromRawUnchecked"/>
    public static ViewGenerateTableDataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewGenerateTableDataResponseFromRaw : IFromRawJson<ViewGenerateTableDataResponse>
{
    /// <inheritdoc/>
    public ViewGenerateTableDataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateTableDataResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A single row in the view table data response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Row, RowFromRaw>))]
public sealed record class Row : JsonModel
{
    /// <summary>
    /// Column entries for this row
    /// </summary>
    public required IReadOnlyList<RowColumn> Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RowColumn>>("columns");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RowColumn>>(
                "columns",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Externally-stable KSUID of the event whose underlying transformation produced
    /// this row.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventID");
        }
        init { this._rawData.Set("eventID", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Columns)
        {
            item.Validate();
        }
        _ = this.EventID;
    }

    public Row() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Row(Row row)
        : base(row) { }
#pragma warning restore CS8618

    public Row(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Row(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RowFromRaw.FromRawUnchecked"/>
    public static Row FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RowFromRaw : IFromRawJson<Row>
{
    /// <inheritdoc/>
    public Row FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Row.FromRawUnchecked(rawData);
}

/// <summary>
/// A single column entry in a view table data row
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RowColumn, RowColumnFromRaw>))]
public sealed record class RowColumn : JsonModel
{
    /// <summary>
    /// Name of the column
    /// </summary>
    public required string ColumnName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("columnName");
        }
        init { this._rawData.Set("columnName", value); }
    }

    /// <summary>
    /// Value of the column (can be any JSON type)
    /// </summary>
    public required RowColumnValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RowColumnValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ColumnName;
        this.Value.Validate();
    }

    public RowColumn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RowColumn(RowColumn rowColumn)
        : base(rowColumn) { }
#pragma warning restore CS8618

    public RowColumn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RowColumn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RowColumnFromRaw.FromRawUnchecked"/>
    public static RowColumn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RowColumnFromRaw : IFromRawJson<RowColumn>
{
    /// <inheritdoc/>
    public RowColumn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RowColumn.FromRawUnchecked(rawData);
}

/// <summary>
/// Value of the column (can be any JSON type)
/// </summary>
[JsonConverter(typeof(RowColumnValueConverter))]
public record class RowColumnValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RowColumnValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RowColumnValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RowColumnValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RowColumnValue(IReadOnlyList<JsonElement> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public RowColumnValue(JsonElement element)
    {
        this._element = element;
        this.Value = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JsonElement"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElement(out var value)) {
    ///     // `value` is of type `JsonElement`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElement([NotNullWhen(true)] out JsonElement? value)
    {
        value = this.Value as JsonElement?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JsonElement"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElement1(out var value)) {
    ///     // `value` is of type `JsonElement`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElement1([NotNullWhen(true)] out JsonElement? value)
    {
        value = this.Value as JsonElement?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements([NotNullWhen(true)] out IReadOnlyList<JsonElement>? value)
    {
        value = this.Value as IReadOnlyList<JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (JsonElement value) =&gt; {...},
    ///     (JsonElement value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<JsonElement> jsonElement,
        Action<JsonElement> jsonElement1,
        Action<IReadOnlyList<JsonElement>> jsonElements
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case JsonElement value:
                jsonElement(value);
                break;
            case JsonElement value:
                jsonElement1(value);
                break;
            case IReadOnlyList<JsonElement> value:
                jsonElements(value);
                break;
            default:
                throw new BemInvalidDataException(
                    "Data did not match any variant of RowColumnValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (JsonElement value) =&gt; {...},
    ///     (JsonElement value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<JsonElement, T> jsonElement,
        Func<JsonElement, T> jsonElement1,
        Func<IReadOnlyList<JsonElement>, T> jsonElements
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            JsonElement value => jsonElement(value),
            JsonElement value => jsonElement1(value),
            IReadOnlyList<JsonElement> value => jsonElements(value),
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of RowColumnValue"
            ),
        };
    }

    public static implicit operator RowColumnValue(string value) => new(value);

    public static implicit operator RowColumnValue(double value) => new(value);

    public static implicit operator RowColumnValue(bool value) => new(value);

    public static implicit operator RowColumnValue(JsonElement value) => new(value);

    public static implicit operator RowColumnValue(JsonElement value) => new(value);

    public static implicit operator RowColumnValue(List<JsonElement> value) =>
        new((IReadOnlyList<JsonElement>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new BemInvalidDataException("Data did not match any variant of RowColumnValue");
        }
    }

    public virtual bool Equals(RowColumnValue? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            JsonElement _ => 3,
            JsonElement _ => 4,
            IReadOnlyList<JsonElement> _ => 5,
            _ => -1,
        };
    }
}

sealed class RowColumnValueConverter : JsonConverter<RowColumnValue>
{
    public override RowColumnValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<JsonElement>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<JsonElement>(element, options));
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<JsonElement>(element, options));
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        RowColumnValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
