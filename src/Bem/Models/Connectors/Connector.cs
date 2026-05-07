using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Connectors;

/// <summary>
/// A Connector represents an integration that triggers a Bem workflow from an external system.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Connector, ConnectorFromRaw>))]
public sealed record class Connector : JsonModel
{
    /// <summary>
    /// Box client ID (from your Box application).
    /// </summary>
    public required string BoxClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("boxClientID");
        }
        init { this._rawData.Set("boxClientID", value); }
    }

    /// <summary>
    /// Box client secret (from your Box application).
    ///
    /// <para>Note: This value is sensitive and should be stored securely.</para>
    /// </summary>
    public required string BoxClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("boxClientSecret");
        }
        init { this._rawData.Set("boxClientSecret", value); }
    }

    /// <summary>
    /// Box enterprise ID.
    /// </summary>
    public required string BoxEnterpriseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("boxEnterpriseID");
        }
        init { this._rawData.Set("boxEnterpriseID", value); }
    }

    /// <summary>
    /// Box folder ID to watch for new uploads.
    /// </summary>
    public required string BoxFolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("boxFolderID");
        }
        init { this._rawData.Set("boxFolderID", value); }
    }

    /// <summary>
    /// Unique identifier for the connector.
    /// </summary>
    public required string ConnectorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("connectorID");
        }
        init { this._rawData.Set("connectorID", value); }
    }

    /// <summary>
    /// Human-friendly name for this connector.
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
    /// Configuration specific to the type of integration.
    /// </summary>
    public required JsonElement ParagonConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("paragonConfiguration");
        }
        init { this._rawData.Set("paragonConfiguration", value); }
    }

    /// <summary>
    /// Paragon integration, eg. "googledrive".
    /// </summary>
    public required string ParagonIntegration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("paragonIntegration");
        }
        init { this._rawData.Set("paragonIntegration", value); }
    }

    /// <summary>
    /// Paragon sync ID.
    /// </summary>
    public required string ParagonSyncID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("paragonSyncID");
        }
        init { this._rawData.Set("paragonSyncID", value); }
    }

    /// <summary>
    /// Connector type.
    /// </summary>
    public required ApiEnum<string, ConnectorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ConnectorType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Workflow API ID that will be triggered by this connector.
    /// </summary>
    public required string WorkflowID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workflowID");
        }
        init { this._rawData.Set("workflowID", value); }
    }

    /// <summary>
    /// Workflow name that will be triggered by this connector.
    /// </summary>
    public required string WorkflowName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workflowName");
        }
        init { this._rawData.Set("workflowName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BoxClientID;
        _ = this.BoxClientSecret;
        _ = this.BoxEnterpriseID;
        _ = this.BoxFolderID;
        _ = this.ConnectorID;
        _ = this.Name;
        _ = this.ParagonConfiguration;
        _ = this.ParagonIntegration;
        _ = this.ParagonSyncID;
        this.Type.Validate();
        _ = this.WorkflowID;
        _ = this.WorkflowName;
    }

    public Connector() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Connector(Connector connector)
        : base(connector) { }
#pragma warning restore CS8618

    public Connector(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Connector(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConnectorFromRaw.FromRawUnchecked"/>
    public static Connector FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConnectorFromRaw : IFromRawJson<Connector>
{
    /// <inheritdoc/>
    public Connector FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Connector.FromRawUnchecked(rawData);
}
