using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Connectors;

/// <summary>
/// Create a Connector
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConnectorCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Human-friendly name for this connector.
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
    /// Connector type.
    /// </summary>
    public required ApiEnum<string, ConnectorType> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ConnectorType>>("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// Box client ID (from your Box application).
    /// </summary>
    public string? BoxClientID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("boxClientID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("boxClientID", value);
        }
    }

    /// <summary>
    /// Box client secret (from your Box application).
    /// </summary>
    public string? BoxClientSecret
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("boxClientSecret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("boxClientSecret", value);
        }
    }

    /// <summary>
    /// Box enterprise ID.
    /// </summary>
    public string? BoxEnterpriseID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("boxEnterpriseID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("boxEnterpriseID", value);
        }
    }

    /// <summary>
    /// Box folder ID to watch for new uploads.
    /// </summary>
    public string? BoxFolderID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("boxFolderID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("boxFolderID", value);
        }
    }

    /// <summary>
    /// Configuration specific to the type of integration.
    /// </summary>
    public JsonElement? ParagonConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("paragonConfiguration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("paragonConfiguration", value);
        }
    }

    /// <summary>
    /// Paragon integration, eg. "googledrive".
    /// </summary>
    public string? ParagonIntegration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("paragonIntegration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("paragonIntegration", value);
        }
    }

    /// <summary>
    /// One of `workflowID` or `workflowName` must be provided.
    ///
    /// <para>If both are provided, they must refer to the same workflow.</para>
    /// </summary>
    public string? WorkflowID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("workflowID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("workflowID", value);
        }
    }

    /// <summary>
    /// One of `workflowID` or `workflowName` must be provided.
    ///
    /// <para>If both are provided, they must refer to the same workflow.</para>
    /// </summary>
    public string? WorkflowName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("workflowName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("workflowName", value);
        }
    }

    public ConnectorCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectorCreateParams(ConnectorCreateParams connectorCreateParams)
        : base(connectorCreateParams)
    {
        this._rawBodyData = new(connectorCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ConnectorCreateParams(
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
    ConnectorCreateParams(
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
    public static ConnectorCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ConnectorCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/connectors")
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
