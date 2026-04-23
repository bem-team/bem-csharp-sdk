using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Collections.Items;

/// <summary>
/// Response after queuing items for async update
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ItemUpdateResponse, ItemUpdateResponseFromRaw>))]
public sealed record class ItemUpdateResponse : JsonModel
{
    /// <summary>
    /// Event ID for tracking this operation. Use this to correlate with webhook notifications.
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

    /// <summary>
    /// Status message
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Processing status
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Array of items that were updated (only present in synchronous mode, deprecated)
    /// </summary>
    public IReadOnlyList<ItemUpdateResponseItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ItemUpdateResponseItem>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ItemUpdateResponseItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of items updated (only present in synchronous mode, deprecated)
    /// </summary>
    public long? UpdatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("updatedCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedCount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventID;
        _ = this.Message;
        this.Status.Validate();
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedCount;
    }

    public ItemUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemUpdateResponse(ItemUpdateResponse itemUpdateResponse)
        : base(itemUpdateResponse) { }
#pragma warning restore CS8618

    public ItemUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ItemUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemUpdateResponseFromRaw : IFromRawJson<ItemUpdateResponse>
{
    /// <inheritdoc/>
    public ItemUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ItemUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Processing status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A single item in a collection
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ItemUpdateResponseItem, ItemUpdateResponseItemFromRaw>))]
public sealed record class ItemUpdateResponseItem : JsonModel
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
    public required ItemUpdateResponseItemData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ItemUpdateResponseItemData>("data");
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

    public ItemUpdateResponseItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemUpdateResponseItem(ItemUpdateResponseItem itemUpdateResponseItem)
        : base(itemUpdateResponseItem) { }
#pragma warning restore CS8618

    public ItemUpdateResponseItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemUpdateResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemUpdateResponseItemFromRaw.FromRawUnchecked"/>
    public static ItemUpdateResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemUpdateResponseItemFromRaw : IFromRawJson<ItemUpdateResponseItem>
{
    /// <inheritdoc/>
    public ItemUpdateResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ItemUpdateResponseItem.FromRawUnchecked(rawData);
}

/// <summary>
/// The data stored in this item
/// </summary>
[JsonConverter(typeof(ItemUpdateResponseItemDataConverter))]
public record class ItemUpdateResponseItemData : ModelBase
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

    public ItemUpdateResponseItemData(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ItemUpdateResponseItemData(JsonElement element)
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
                throw new BemInvalidDataException(
                    "Data did not match any variant of ItemUpdateResponseItemData"
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
            _ => throw new BemInvalidDataException(
                "Data did not match any variant of ItemUpdateResponseItemData"
            ),
        };
    }

    public static implicit operator ItemUpdateResponseItemData(string value) => new(value);

    public static implicit operator ItemUpdateResponseItemData(JsonElement value) => new(value);

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
            throw new BemInvalidDataException(
                "Data did not match any variant of ItemUpdateResponseItemData"
            );
        }
    }

    public virtual bool Equals(ItemUpdateResponseItemData? other) =>
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

sealed class ItemUpdateResponseItemDataConverter : JsonConverter<ItemUpdateResponseItemData>
{
    public override ItemUpdateResponseItemData? Read(
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

    public override void Write(
        Utf8JsonWriter writer,
        ItemUpdateResponseItemData value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
