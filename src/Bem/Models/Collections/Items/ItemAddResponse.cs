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
/// Response after queuing items for async processing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ItemAddResponse, ItemAddResponseFromRaw>))]
public sealed record class ItemAddResponse : JsonModel
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
    public required ApiEnum<string, ItemAddResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ItemAddResponseStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Number of new items added (only present in synchronous mode, deprecated)
    /// </summary>
    public long? AddedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("addedCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("addedCount", value);
        }
    }

    /// <summary>
    /// Array of items that were added (only present in synchronous mode, deprecated)
    /// </summary>
    public IReadOnlyList<CollectionItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CollectionItem>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CollectionItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventID;
        _ = this.Message;
        this.Status.Validate();
        _ = this.AddedCount;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
    }

    public ItemAddResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemAddResponse(ItemAddResponse itemAddResponse)
        : base(itemAddResponse) { }
#pragma warning restore CS8618

    public ItemAddResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemAddResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemAddResponseFromRaw.FromRawUnchecked"/>
    public static ItemAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemAddResponseFromRaw : IFromRawJson<ItemAddResponse>
{
    /// <inheritdoc/>
    public ItemAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ItemAddResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Processing status
/// </summary>
[JsonConverter(typeof(ItemAddResponseStatusConverter))]
public enum ItemAddResponseStatus
{
    Pending,
}

sealed class ItemAddResponseStatusConverter : JsonConverter<ItemAddResponseStatus>
{
    public override ItemAddResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => ItemAddResponseStatus.Pending,
            _ => (ItemAddResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ItemAddResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ItemAddResponseStatus.Pending => "pending",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
