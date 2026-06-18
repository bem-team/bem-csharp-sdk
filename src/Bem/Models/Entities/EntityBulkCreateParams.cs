using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Entities;

/// <summary>
/// Bulk Seed Entities
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntityBulkCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The entities to seed. Must be non-empty.
    /// </summary>
    public required IReadOnlyList<Entity> Entities
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Entity>>("entities");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Entity>>(
                "entities",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional bucket public ID (`bkt_...`) to seed into. Omit to use the account+environment
    /// default bucket.
    /// </summary>
    public string? Bucket
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("bucket");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("bucket", value);
        }
    }

    /// <summary>
    /// Conflict strategy for an entity that already exists. Only `merge` is supported
    /// and it is the default: synonyms are added additively, a longer description
    /// replaces the old one, and attributes are merged with new keys winning.
    /// </summary>
    public ApiEnum<string, OnConflict>? OnConflict
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, OnConflict>>("onConflict");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("onConflict", value);
        }
    }

    public EntityBulkCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBulkCreateParams(EntityBulkCreateParams entityBulkCreateParams)
        : base(entityBulkCreateParams)
    {
        this._rawBodyData = new(entityBulkCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EntityBulkCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBulkCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntityBulkCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EntityBulkCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/entities/bulk")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// One entity to seed in a `POST /v3/entities/bulk` batch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Entity, EntityFromRaw>))]
public sealed record class Entity : JsonModel
{
    /// <summary>
    /// The canonical (longest / most descriptive) surface form for the entity, e.g.
    /// `Acme Corporation`. Required. Normalized (lowercased, whitespace-folded)
    /// for the uniqueness key.
    /// </summary>
    public required string Canonical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("canonical");
        }
        init { this._rawData.Set("canonical", value); }
    }

    /// <summary>
    /// The entity type name, e.g. `instrument` or `organization`. Required. Resolved
    /// against your taxonomy and created if it does not yet exist.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional per-entity structured attribute values, e.g. `{ "manufacturer":
    /// "Acme", "dosageMg": 50 }`. When the entity's type declares an attribute schema,
    /// keys not present in that schema cause the row to be rejected.
    /// </summary>
    public JsonElement? Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("attributes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("attributes", value);
        }
    }

    /// <summary>
    /// Optional free-form description of the entity.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Optional additional surface forms to attach as `customer_defined` synonyms.
    /// </summary>
    public IReadOnlyList<string>? Synonyms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("synonyms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "synonyms",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Canonical;
        _ = this.Type;
        _ = this.Attributes;
        _ = this.Description;
        _ = this.Synonyms;
    }

    public Entity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entity(Entity entity)
        : base(entity) { }
#pragma warning restore CS8618

    public Entity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityFromRaw.FromRawUnchecked"/>
    public static Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityFromRaw : IFromRawJson<Entity>
{
    /// <inheritdoc/>
    public Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entity.FromRawUnchecked(rawData);
}

/// <summary>
/// Conflict strategy for an entity that already exists. Only `merge` is supported
/// and it is the default: synonyms are added additively, a longer description replaces
/// the old one, and attributes are merged with new keys winning.
/// </summary>
[JsonConverter(typeof(OnConflictConverter))]
public enum OnConflict
{
    Merge,
}

sealed class OnConflictConverter : JsonConverter<OnConflict>
{
    public override OnConflict Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "merge" => OnConflict.Merge,
            _ => (OnConflict)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OnConflict value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OnConflict.Merge => "merge",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
