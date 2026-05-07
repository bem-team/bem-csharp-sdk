using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;
using System = System;

namespace Bem.Models.Subscriptions;

[JsonConverter(typeof(JsonModelConverter<SubscriptionV3, SubscriptionV3FromRaw>))]
public sealed record class SubscriptionV3 : JsonModel
{
    /// <summary>
    /// Name of subscription.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The unique identifier of the subscription.
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscriptionID");
        }
        init { this._rawData.Set("subscriptionID", value); }
    }

    /// <summary>
    /// Type of subscription.
    /// </summary>
    public required ApiEnum<string, SubscriptionV3Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionV3Type>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Unique identifier of collection this subscription listens to.
    /// </summary>
    public string? CollectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("collectionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectionID", value);
        }
    }

    /// <summary>
    /// Name of collection this subscription listens to.
    /// </summary>
    public string? CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("collectionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectionName", value);
        }
    }

    /// <summary>
    /// Toggles whether subscription is active or not.
    /// </summary>
    public bool? Disabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("disabled", value);
        }
    }

    /// <summary>
    /// Unique identifier of function this subscription listens to.
    /// </summary>
    public string? FunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionID", value);
        }
    }

    /// <summary>
    /// Unique name of function this subscription listens to.
    /// </summary>
    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    /// <summary>
    /// Google Drive folder ID for syncing output data to Google Drive.
    /// </summary>
    public string? GoogleDriveFolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("googleDriveFolderID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("googleDriveFolderID", value);
        }
    }

    /// <summary>
    /// S3 bucket name for syncing output data to AWS S3.
    /// </summary>
    public string? S3Bucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3Bucket");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3Bucket", value);
        }
    }

    /// <summary>
    /// S3 file path for syncing output data to AWS S3.
    /// </summary>
    public string? S3FilePath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3FilePath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3FilePath", value);
        }
    }

    /// <summary>
    /// URL bem will send webhook requests to.
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhookURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhookURL", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.SubscriptionID;
        this.Type.Validate();
        _ = this.CollectionID;
        _ = this.CollectionName;
        _ = this.Disabled;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.GoogleDriveFolderID;
        _ = this.S3Bucket;
        _ = this.S3FilePath;
        _ = this.WebhookUrl;
    }

    public SubscriptionV3() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionV3(SubscriptionV3 subscriptionV3)
        : base(subscriptionV3) { }
#pragma warning restore CS8618

    public SubscriptionV3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionV3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionV3FromRaw.FromRawUnchecked"/>
    public static SubscriptionV3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionV3FromRaw : IFromRawJson<SubscriptionV3>
{
    /// <inheritdoc/>
    public SubscriptionV3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubscriptionV3.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of subscription.
/// </summary>
[JsonConverter(typeof(SubscriptionV3TypeConverter))]
public enum SubscriptionV3Type
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

sealed class SubscriptionV3TypeConverter : JsonConverter<SubscriptionV3Type>
{
    public override SubscriptionV3Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transform" => SubscriptionV3Type.Transform,
            "analyze" => SubscriptionV3Type.Analyze,
            "route" => SubscriptionV3Type.Route,
            "join" => SubscriptionV3Type.Join,
            "split_collection" => SubscriptionV3Type.SplitCollection,
            "split_item" => SubscriptionV3Type.SplitItem,
            "evaluation" => SubscriptionV3Type.Evaluation,
            "error" => SubscriptionV3Type.Error,
            "payload_shaping" => SubscriptionV3Type.PayloadShaping,
            "enrich" => SubscriptionV3Type.Enrich,
            "collection_processing" => SubscriptionV3Type.CollectionProcessing,
            _ => (SubscriptionV3Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionV3Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionV3Type.Transform => "transform",
                SubscriptionV3Type.Analyze => "analyze",
                SubscriptionV3Type.Route => "route",
                SubscriptionV3Type.Join => "join",
                SubscriptionV3Type.SplitCollection => "split_collection",
                SubscriptionV3Type.SplitItem => "split_item",
                SubscriptionV3Type.Evaluation => "evaluation",
                SubscriptionV3Type.Error => "error",
                SubscriptionV3Type.PayloadShaping => "payload_shaping",
                SubscriptionV3Type.Enrich => "enrich",
                SubscriptionV3Type.CollectionProcessing => "collection_processing",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
