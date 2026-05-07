using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Connectors;

/// <summary>
/// Response body for listing connectors.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConnectorListResponse, ConnectorListResponseFromRaw>))]
public sealed record class ConnectorListResponse : JsonModel
{
    public required IReadOnlyList<Connector> Connectors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Connector>>("connectors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Connector>>(
                "connectors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Connectors)
        {
            item.Validate();
        }
    }

    public ConnectorListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectorListResponse(ConnectorListResponse connectorListResponse)
        : base(connectorListResponse) { }
#pragma warning restore CS8618

    public ConnectorListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectorListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConnectorListResponseFromRaw.FromRawUnchecked"/>
    public static ConnectorListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConnectorListResponse(IReadOnlyList<Connector> connectors)
        : this()
    {
        this.Connectors = connectors;
    }
}

class ConnectorListResponseFromRaw : IFromRawJson<ConnectorListResponse>
{
    /// <inheritdoc/>
    public ConnectorListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConnectorListResponse.FromRawUnchecked(rawData);
}
