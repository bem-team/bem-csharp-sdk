using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;
using System = System;

namespace Bem.Models.Subscriptions;

/// <summary>
/// Creates a new subscription to listen to transform or error events.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of subscription.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Type of subscription.
    /// </summary>
    public required ApiEnum<string, global::Bem.Models.Subscriptions.Type> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, global::Bem.Models.Subscriptions.Type>
            >("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// Unique identifier of collection this subscription listens to (alternative
    /// to collectionName).
    /// </summary>
    public string? CollectionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("collectionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("collectionID", value);
        }
    }

    /// <summary>
    /// Name of collection this subscription listens to (required for collection-based subscriptions).
    /// </summary>
    public string? CollectionName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("collectionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("collectionName", value);
        }
    }

    /// <summary>
    /// Toggles whether subscription is active or not.
    /// </summary>
    public bool? Disabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("disabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("disabled", value);
        }
    }

    /// <summary>
    /// Unique identifier of function this subscription listens to (alternative to functionName).
    /// </summary>
    public string? FunctionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("functionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("functionID", value);
        }
    }

    /// <summary>
    /// Unique name of function this subscription listens to (required for function-based subscriptions).
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("functionName", value);
        }
    }

    /// <summary>
    /// Google Drive folder ID for syncing output data to Google Drive.
    /// </summary>
    public string? GoogleDriveFolderID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("googleDriveFolderID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("googleDriveFolderID", value);
        }
    }

    /// <summary>
    /// S3 bucket name for syncing output data to AWS S3.
    /// </summary>
    public string? S3Bucket
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("s3Bucket");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("s3Bucket", value);
        }
    }

    /// <summary>
    /// S3 file path for syncing output data to AWS S3.
    /// </summary>
    public string? S3FilePath
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("s3FilePath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("s3FilePath", value);
        }
    }

    /// <summary>
    /// URL bem will send webhook requests to.
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("webhookURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("webhookURL", value);
        }
    }

    public SubscriptionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionCreateParams(SubscriptionCreateParams subscriptionCreateParams)
        : base(subscriptionCreateParams)
    {
        this._rawBodyData = new(subscriptionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionCreateParams(
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
    SubscriptionCreateParams(
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
    public static SubscriptionCreateParams FromRawUnchecked(
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

    public virtual bool Equals(SubscriptionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/subscriptions")
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
/// Type of subscription.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Transform,
    Analyze,
    Route,
    Join,
    SplitCollection,
    SplitItem,
    Evaluation,
    Error,
    PayloadShaping,
    Enrich,
    CollectionProcessing,
}

sealed class TypeConverter : JsonConverter<global::Bem.Models.Subscriptions.Type>
{
    public override global::Bem.Models.Subscriptions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transform" => global::Bem.Models.Subscriptions.Type.Transform,
            "analyze" => global::Bem.Models.Subscriptions.Type.Analyze,
            "route" => global::Bem.Models.Subscriptions.Type.Route,
            "join" => global::Bem.Models.Subscriptions.Type.Join,
            "split_collection" => global::Bem.Models.Subscriptions.Type.SplitCollection,
            "split_item" => global::Bem.Models.Subscriptions.Type.SplitItem,
            "evaluation" => global::Bem.Models.Subscriptions.Type.Evaluation,
            "error" => global::Bem.Models.Subscriptions.Type.Error,
            "payload_shaping" => global::Bem.Models.Subscriptions.Type.PayloadShaping,
            "enrich" => global::Bem.Models.Subscriptions.Type.Enrich,
            "collection_processing" => global::Bem.Models.Subscriptions.Type.CollectionProcessing,
            _ => (global::Bem.Models.Subscriptions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Bem.Models.Subscriptions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Bem.Models.Subscriptions.Type.Transform => "transform",
                global::Bem.Models.Subscriptions.Type.Analyze => "analyze",
                global::Bem.Models.Subscriptions.Type.Route => "route",
                global::Bem.Models.Subscriptions.Type.Join => "join",
                global::Bem.Models.Subscriptions.Type.SplitCollection => "split_collection",
                global::Bem.Models.Subscriptions.Type.SplitItem => "split_item",
                global::Bem.Models.Subscriptions.Type.Evaluation => "evaluation",
                global::Bem.Models.Subscriptions.Type.Error => "error",
                global::Bem.Models.Subscriptions.Type.PayloadShaping => "payload_shaping",
                global::Bem.Models.Subscriptions.Type.Enrich => "enrich",
                global::Bem.Models.Subscriptions.Type.CollectionProcessing =>
                    "collection_processing",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
