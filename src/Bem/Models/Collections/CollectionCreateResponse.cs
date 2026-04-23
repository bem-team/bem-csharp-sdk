using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Collections;

/// <summary>
/// Collection details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CollectionCreateResponse, CollectionCreateResponseFromRaw>)
)]
public sealed record class CollectionCreateResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the collection
    /// </summary>
    public required string CollectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collectionID");
        }
        init { this._rawData.Set("collectionID", value); }
    }

    /// <summary>
    /// The collection name/path. Only letters, digits, underscores, and dots are allowed.
    /// </summary>
    public required string CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collectionName");
        }
        init { this._rawData.Set("collectionName", value); }
    }

    /// <summary>
    /// When the collection was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Number of items in the collection
    /// </summary>
    public required long ItemCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("itemCount");
        }
        init { this._rawData.Set("itemCount", value); }
    }

    /// <summary>
    /// List of items in the collection (when fetching collection details)
    /// </summary>
    public IReadOnlyList<Item>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Item>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of items per page
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("limit", value);
        }
    }

    /// <summary>
    /// Current page number
    /// </summary>
    public long? Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// Total number of pages
    /// </summary>
    public long? TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalPages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalPages", value);
        }
    }

    /// <summary>
    /// When the collection was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CollectionID;
        _ = this.CollectionName;
        _ = this.CreatedAt;
        _ = this.ItemCount;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Limit;
        _ = this.Page;
        _ = this.TotalPages;
        _ = this.UpdatedAt;
    }

    public CollectionCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionCreateResponse(CollectionCreateResponse collectionCreateResponse)
        : base(collectionCreateResponse) { }
#pragma warning restore CS8618

    public CollectionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CollectionCreateResponseFromRaw.FromRawUnchecked"/>
    public static CollectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CollectionCreateResponseFromRaw : IFromRawJson<CollectionCreateResponse>
{
    /// <inheritdoc/>
    public CollectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CollectionCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A single item in a collection
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    /// <summary>
    /// Unique identifier for the item
    /// </summary>
    public required string CollectionItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collectionItemID");
        }
        init { this._rawData.Set("collectionItemID", value); }
    }

    /// <summary>
    /// When the item was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The data stored in this item
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// When the item was last updated
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CollectionItemID;
        _ = this.CreatedAt;
        this.Data.Validate();
        _ = this.UpdatedAt;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

/// <summary>
/// The data stored in this item
/// </summary>
[JsonConverter(typeof(DataConverter))]
public record class Data : ModelBase
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

    public Data(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(JsonElement element)
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
    ///     (JsonElement value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<JsonElement> jsonElement)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case JsonElement value:
                jsonElement(value);
                break;
            default:
                throw new BemInvalidDataException("Data did not match any variant of Data");
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
    ///     (JsonElement value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<JsonElement, T> jsonElement)
    {
        return this.Value switch
        {
            string value => @string(value),
            JsonElement value => jsonElement(value),
            _ => throw new BemInvalidDataException("Data did not match any variant of Data"),
        };
    }

    public static implicit operator Data(string value) => new(value);

    public static implicit operator Data(JsonElement value) => new(value);

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
            throw new BemInvalidDataException("Data did not match any variant of Data");
        }
    }

    public virtual bool Equals(Data? other) =>
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
            JsonElement _ => 1,
            _ => -1,
        };
    }
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
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
            return new(JsonSerializer.Deserialize<JsonElement>(element, options));
        }
        catch (Exception e) when (e is JsonException || e is BemInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
