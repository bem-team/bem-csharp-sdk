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
/// Updates an existing subscription. Follow conventional PATCH behavior, so only
/// included fields will be updated.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

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
    /// Unique name of function this subscription listens to.
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
    /// Name of subscription.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
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
    /// Type of subscription.
    /// </summary>
    public ApiEnum<string, SubscriptionUpdateParamsType>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, SubscriptionUpdateParamsType>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("type", value);
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

    public SubscriptionUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionUpdateParams(SubscriptionUpdateParams subscriptionUpdateParams)
        : base(subscriptionUpdateParams)
    {
        this.SubscriptionID = subscriptionUpdateParams.SubscriptionID;

        this._rawBodyData = new(subscriptionUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionUpdateParams(
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
    SubscriptionUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string subscriptionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SubscriptionID = subscriptionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubscriptionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string subscriptionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            subscriptionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SubscriptionID"] = JsonSerializer.SerializeToElement(this.SubscriptionID),
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

    public virtual bool Equals(SubscriptionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SubscriptionID?.Equals(other.SubscriptionID) ?? other.SubscriptionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/subscriptions/{0}", this.SubscriptionID)
        )
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
[JsonConverter(typeof(SubscriptionUpdateParamsTypeConverter))]
public enum SubscriptionUpdateParamsType
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

sealed class SubscriptionUpdateParamsTypeConverter : JsonConverter<SubscriptionUpdateParamsType>
{
    public override SubscriptionUpdateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transform" => SubscriptionUpdateParamsType.Transform,
            "analyze" => SubscriptionUpdateParamsType.Analyze,
            "route" => SubscriptionUpdateParamsType.Route,
            "join" => SubscriptionUpdateParamsType.Join,
            "split_collection" => SubscriptionUpdateParamsType.SplitCollection,
            "split_item" => SubscriptionUpdateParamsType.SplitItem,
            "evaluation" => SubscriptionUpdateParamsType.Evaluation,
            "error" => SubscriptionUpdateParamsType.Error,
            "payload_shaping" => SubscriptionUpdateParamsType.PayloadShaping,
            "enrich" => SubscriptionUpdateParamsType.Enrich,
            "collection_processing" => SubscriptionUpdateParamsType.CollectionProcessing,
            _ => (SubscriptionUpdateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionUpdateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionUpdateParamsType.Transform => "transform",
                SubscriptionUpdateParamsType.Analyze => "analyze",
                SubscriptionUpdateParamsType.Route => "route",
                SubscriptionUpdateParamsType.Join => "join",
                SubscriptionUpdateParamsType.SplitCollection => "split_collection",
                SubscriptionUpdateParamsType.SplitItem => "split_item",
                SubscriptionUpdateParamsType.Evaluation => "evaluation",
                SubscriptionUpdateParamsType.Error => "error",
                SubscriptionUpdateParamsType.PayloadShaping => "payload_shaping",
                SubscriptionUpdateParamsType.Enrich => "enrich",
                SubscriptionUpdateParamsType.CollectionProcessing => "collection_processing",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
