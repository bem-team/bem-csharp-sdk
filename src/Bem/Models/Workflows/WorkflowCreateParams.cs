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
/// Create a Workflow
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkflowCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of the entry-point node. Must not be a destination of any edge.
    /// </summary>
    public required string MainNodeName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("mainNodeName");
        }
        init { this._rawBodyData.Set("mainNodeName", value); }
    }

    /// <summary>
    /// Unique name for the workflow. Must match `^[a-zA-Z0-9_-]{1,128}$`.
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
    /// Call-site nodes in the DAG. At least one is required.
    /// </summary>
    public required IReadOnlyList<Node> Nodes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Node>>("nodes");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Node>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Connectors to attach to the workflow at creation. If any entry fails to provision,
    /// the entire workflow creation is rolled back.
    /// </summary>
    public IReadOnlyList<Connector>? Connectors
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Connector>>("connectors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Connector>?>(
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

    /// <summary>
    /// Directed edges between nodes. Omit or leave empty for single-node workflows.
    /// </summary>
    public IReadOnlyList<Edge>? Edges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Edge>>("edges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Edge>?>(
                "edges",
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

    public WorkflowCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCreateParams(WorkflowCreateParams workflowCreateParams)
        : base(workflowCreateParams)
    {
        this._rawBodyData = new(workflowCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WorkflowCreateParams(
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
    WorkflowCreateParams(
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
    public static WorkflowCreateParams FromRawUnchecked(
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

    public virtual bool Equals(WorkflowCreateParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/workflows")
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
/// A single function call-site node in a workflow DAG.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Node, NodeFromRaw>))]
public sealed record class Node : JsonModel
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

    public Node() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Node(Node node)
        : base(node) { }
#pragma warning restore CS8618

    public Node(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Node(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NodeFromRaw.FromRawUnchecked"/>
    public static Node FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Node(FunctionVersionIdentifier function)
        : this()
    {
        this.Function = function;
    }
}

class NodeFromRaw : IFromRawJson<Node>
{
    /// <inheritdoc/>
    public Node FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Node.FromRawUnchecked(rawData);
}

/// <summary>
/// Create/update entry for a connector inline with the workflow.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Connector, ConnectorFromRaw>))]
public sealed record class Connector : JsonModel
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
    public required ApiEnum<string, global::Bem.Models.Workflows.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Bem.Models.Workflows.Type>
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
    public Paragon? Paragon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Paragon>("paragon");
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

/// <summary>
/// Discriminator for a workflow connector. V3 supports `paragon` only.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Paragon,
}

sealed class TypeConverter : JsonConverter<global::Bem.Models.Workflows.Type>
{
    public override global::Bem.Models.Workflows.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "paragon" => global::Bem.Models.Workflows.Type.Paragon,
            _ => (global::Bem.Models.Workflows.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Bem.Models.Workflows.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Bem.Models.Workflows.Type.Paragon => "paragon",
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
[JsonConverter(typeof(JsonModelConverter<Paragon, ParagonFromRaw>))]
public sealed record class Paragon : JsonModel
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

    public Paragon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Paragon(Paragon paragon)
        : base(paragon) { }
#pragma warning restore CS8618

    public Paragon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Paragon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParagonFromRaw.FromRawUnchecked"/>
    public static Paragon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParagonFromRaw : IFromRawJson<Paragon>
{
    /// <inheritdoc/>
    public Paragon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Paragon.FromRawUnchecked(rawData);
}

/// <summary>
/// A directed edge between two named call-site nodes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Edge, EdgeFromRaw>))]
public sealed record class Edge : JsonModel
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

    public Edge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Edge(Edge edge)
        : base(edge) { }
#pragma warning restore CS8618

    public Edge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Edge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EdgeFromRaw.FromRawUnchecked"/>
    public static Edge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EdgeFromRaw : IFromRawJson<Edge>
{
    /// <inheritdoc/>
    public Edge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Edge.FromRawUnchecked(rawData);
}
