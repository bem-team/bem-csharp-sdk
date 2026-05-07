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
