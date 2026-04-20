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
using System = System;

namespace Bem.Models.Workflows;

/// <summary>
/// Update a Workflow
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkflowUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? WorkflowName { get; init; }

    /// <summary>
    /// Declarative, full-desired-state array of connectors. If omitted, existing
    /// connectors are left unchanged. If provided, it replaces the current set: entries
    /// with `connectorID` are updates, entries without are creates, and existing
    /// connectors whose `connectorID` is absent are deleted.
    /// </summary>
    public IReadOnlyList<WorkflowUpdateParamsConnector>? Connectors
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<WorkflowUpdateParamsConnector>
            >("connectors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<WorkflowUpdateParamsConnector>?>(
                "connectors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Human-readable display name.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("displayName", value);
        }
    }

    public IReadOnlyList<WorkflowUpdateParamsEdge>? Edges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<WorkflowUpdateParamsEdge>>(
                "edges"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<WorkflowUpdateParamsEdge>?>(
                "edges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// `mainNodeName`, `nodes`, and `edges` must be provided together to update
    /// the DAG topology. If none are provided the topology is copied unchanged from
    /// the current version.
    /// </summary>
    public string? MainNodeName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("mainNodeName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("mainNodeName", value);
        }
    }

    /// <summary>
    /// New name for the workflow (renames it). Must match `^[a-zA-Z0-9_-]{1,128}$`.
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

    public IReadOnlyList<WorkflowUpdateParamsNode>? Nodes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<WorkflowUpdateParamsNode>>(
                "nodes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<WorkflowUpdateParamsNode>?>(
                "nodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tags to categorize and organize the workflow.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public WorkflowUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateParams(WorkflowUpdateParams workflowUpdateParams)
        : base(workflowUpdateParams)
    {
        this.WorkflowName = workflowUpdateParams.WorkflowName;

        this._rawBodyData = new(workflowUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WorkflowUpdateParams(
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
    WorkflowUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string workflowName
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.WorkflowName = workflowName;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WorkflowUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string workflowName
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            workflowName
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WorkflowName"] = JsonSerializer.SerializeToElement(this.WorkflowName),
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

    public virtual bool Equals(WorkflowUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.WorkflowName?.Equals(other.WorkflowName) ?? other.WorkflowName == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/workflows/{0}", this.WorkflowName)
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
/// Create/update entry for a connector inline with the workflow.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WorkflowUpdateParamsConnector, WorkflowUpdateParamsConnectorFromRaw>)
)]
public sealed record class WorkflowUpdateParamsConnector : JsonModel
{
    /// <summary>
    /// Human-friendly connector name.
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
    /// Discriminator for a workflow connector. V3 supports `paragon` only.
    /// </summary>
    public required ApiEnum<string, WorkflowUpdateParamsConnectorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, WorkflowUpdateParamsConnectorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Present → update. Absent → create.
    /// </summary>
    public string? ConnectorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connectorID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectorID", value);
        }
    }

    /// <summary>
    /// Request-side config block for a Paragon connector. Fields absent on update
    /// are unchanged.
    /// </summary>
    public WorkflowUpdateParamsConnectorParagon? Paragon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WorkflowUpdateParamsConnectorParagon>("paragon");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paragon", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Type.Validate();
        _ = this.ConnectorID;
        this.Paragon?.Validate();
    }

    public WorkflowUpdateParamsConnector() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateParamsConnector(
        WorkflowUpdateParamsConnector workflowUpdateParamsConnector
    )
        : base(workflowUpdateParamsConnector) { }
#pragma warning restore CS8618

    public WorkflowUpdateParamsConnector(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateParamsConnector(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateParamsConnectorFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateParamsConnector FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateParamsConnectorFromRaw : IFromRawJson<WorkflowUpdateParamsConnector>
{
    /// <inheritdoc/>
    public WorkflowUpdateParamsConnector FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateParamsConnector.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator for a workflow connector. V3 supports `paragon` only.
/// </summary>
[JsonConverter(typeof(WorkflowUpdateParamsConnectorTypeConverter))]
public enum WorkflowUpdateParamsConnectorType
{
    Paragon,
}

sealed class WorkflowUpdateParamsConnectorTypeConverter
    : JsonConverter<WorkflowUpdateParamsConnectorType>
{
    public override WorkflowUpdateParamsConnectorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "paragon" => WorkflowUpdateParamsConnectorType.Paragon,
            _ => (WorkflowUpdateParamsConnectorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkflowUpdateParamsConnectorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkflowUpdateParamsConnectorType.Paragon => "paragon",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Request-side config block for a Paragon connector. Fields absent on update are unchanged.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkflowUpdateParamsConnectorParagon,
        WorkflowUpdateParamsConnectorParagonFromRaw
    >)
)]
public sealed record class WorkflowUpdateParamsConnectorParagon : JsonModel
{
    /// <summary>
    /// Opaque per-integration configuration. Required on create.
    /// </summary>
    public JsonElement? Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("configuration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configuration", value);
        }
    }

    /// <summary>
    /// Paragon integration key. Required on create.
    /// </summary>
    public string? Integration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("integration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("integration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Configuration;
        _ = this.Integration;
    }

    public WorkflowUpdateParamsConnectorParagon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateParamsConnectorParagon(
        WorkflowUpdateParamsConnectorParagon workflowUpdateParamsConnectorParagon
    )
        : base(workflowUpdateParamsConnectorParagon) { }
#pragma warning restore CS8618

    public WorkflowUpdateParamsConnectorParagon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateParamsConnectorParagon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateParamsConnectorParagonFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateParamsConnectorParagon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateParamsConnectorParagonFromRaw
    : IFromRawJson<WorkflowUpdateParamsConnectorParagon>
{
    /// <inheritdoc/>
    public WorkflowUpdateParamsConnectorParagon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateParamsConnectorParagon.FromRawUnchecked(rawData);
}

/// <summary>
/// A directed edge between two named call-site nodes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WorkflowUpdateParamsEdge, WorkflowUpdateParamsEdgeFromRaw>)
)]
public sealed record class WorkflowUpdateParamsEdge : JsonModel
{
    /// <summary>
    /// Name of the destination node.
    /// </summary>
    public required string DestinationNodeName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destinationNodeName");
        }
        init { this._rawData.Set("destinationNodeName", value); }
    }

    /// <summary>
    /// Name of the source node.
    /// </summary>
    public required string SourceNodeName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceNodeName");
        }
        init { this._rawData.Set("sourceNodeName", value); }
    }

    /// <summary>
    /// Labelled outlet on the source node that activates this edge. Omit for the
    /// default (unlabelled) outlet.
    /// </summary>
    public string? DestinationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destinationName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destinationName", value);
        }
    }

    /// <summary>
    /// Opaque free-form JSON object attached to this edge. Stored and returned verbatim;
    /// the server does not interpret it.
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DestinationNodeName;
        _ = this.SourceNodeName;
        _ = this.DestinationName;
        _ = this.Metadata;
    }

    public WorkflowUpdateParamsEdge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateParamsEdge(WorkflowUpdateParamsEdge workflowUpdateParamsEdge)
        : base(workflowUpdateParamsEdge) { }
#pragma warning restore CS8618

    public WorkflowUpdateParamsEdge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateParamsEdge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateParamsEdgeFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateParamsEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowUpdateParamsEdgeFromRaw : IFromRawJson<WorkflowUpdateParamsEdge>
{
    /// <inheritdoc/>
    public WorkflowUpdateParamsEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateParamsEdge.FromRawUnchecked(rawData);
}

/// <summary>
/// A single function call-site node in a workflow DAG.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WorkflowUpdateParamsNode, WorkflowUpdateParamsNodeFromRaw>)
)]
public sealed record class WorkflowUpdateParamsNode : JsonModel
{
    /// <summary>
    /// The function (and version) to execute at this call site.
    /// </summary>
    public required FunctionVersionIdentifier Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionVersionIdentifier>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    /// <summary>
    /// Opaque free-form JSON object attached to this node. Stored and returned verbatim;
    /// the server does not interpret it. Intended for client-side concerns such as
    /// canvas display properties (position, color, collapsed state, etc.).
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Name for this call site. Must be unique within the workflow version. Defaults
    /// to the function's own name when omitted.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
        _ = this.Metadata;
        _ = this.Name;
    }

    public WorkflowUpdateParamsNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowUpdateParamsNode(WorkflowUpdateParamsNode workflowUpdateParamsNode)
        : base(workflowUpdateParamsNode) { }
#pragma warning restore CS8618

    public WorkflowUpdateParamsNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowUpdateParamsNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowUpdateParamsNodeFromRaw.FromRawUnchecked"/>
    public static WorkflowUpdateParamsNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WorkflowUpdateParamsNode(FunctionVersionIdentifier function)
        : this()
    {
        this.Function = function;
    }
}

class WorkflowUpdateParamsNodeFromRaw : IFromRawJson<WorkflowUpdateParamsNode>
{
    /// <inheritdoc/>
    public WorkflowUpdateParamsNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkflowUpdateParamsNode.FromRawUnchecked(rawData);
}
