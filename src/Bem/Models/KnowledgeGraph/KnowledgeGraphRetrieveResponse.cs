using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.KnowledgeGraph;

/// <summary>
/// Response body for `GET /v3/knowledge-graph`. Pagination is over edges; `nodes`
/// are the distinct endpoint entities of the returned edge page (both endpoints
/// of every edge are included).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        KnowledgeGraphRetrieveResponse,
        KnowledgeGraphRetrieveResponseFromRaw
    >)
)]
public sealed record class KnowledgeGraphRetrieveResponse : JsonModel
{
    /// <summary>
    /// The page of edges.
    /// </summary>
    public required IReadOnlyList<Edge> Edges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Edge>>("edges");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Edge>>(
                "edges",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Distinct endpoint entities of the returned edge page.
    /// </summary>
    public required IReadOnlyList<Node> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Node>>("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Node>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page of edges, or absent on the last page. Pass
    /// it back as `cursor`.
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Edges)
        {
            item.Validate();
        }
        foreach (var item in this.Nodes)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public KnowledgeGraphRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KnowledgeGraphRetrieveResponse(
        KnowledgeGraphRetrieveResponse knowledgeGraphRetrieveResponse
    )
        : base(knowledgeGraphRetrieveResponse) { }
#pragma warning restore CS8618

    public KnowledgeGraphRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KnowledgeGraphRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KnowledgeGraphRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static KnowledgeGraphRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KnowledgeGraphRetrieveResponseFromRaw : IFromRawJson<KnowledgeGraphRetrieveResponse>
{
    /// <inheritdoc/>
    public KnowledgeGraphRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KnowledgeGraphRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One directed edge between two entities, addressed by their public ids.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Edge, EdgeFromRaw>))]
public sealed record class Edge : JsonModel
{
    /// <summary>
    /// How many times this edge has been observed.
    /// </summary>
    public required int MentionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("mentionCount");
        }
        init { this._rawData.Set("mentionCount", value); }
    }

    /// <summary>
    /// Free-form relation label.
    /// </summary>
    public required string RelationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("relationType");
        }
        init { this._rawData.Set("relationType", value); }
    }

    /// <summary>
    /// Source entity public id (`ent_...`).
    /// </summary>
    public required string SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceId");
        }
        init { this._rawData.Set("sourceId", value); }
    }

    /// <summary>
    /// Target entity public id (`ent_...`).
    /// </summary>
    public required string TargetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("targetId");
        }
        init { this._rawData.Set("targetId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MentionCount;
        _ = this.RelationType;
        _ = this.SourceID;
        _ = this.TargetID;
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

/// <summary>
/// One entity node in the knowledge graph.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Node, NodeFromRaw>))]
public sealed record class Node : JsonModel
{
    /// <summary>
    /// Stable public identifier for the entity (`ent_...`).
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Canonical (most descriptive) surface form.
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
    /// Hops from the center node when the request centers the graph on one entity
    /// (`nodeID`). The center is depth 0. When the request is uncentered (no `nodeID`),
    /// this is 0 for every node.
    /// </summary>
    public required int Depth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("depth");
        }
        init { this._rawData.Set("depth", value); }
    }

    /// <summary>
    /// Total mentions of this entity across all parsed documents.
    /// </summary>
    public required int MentionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("mentionCount");
        }
        init { this._rawData.Set("mentionCount", value); }
    }

    /// <summary>
    /// Effective entity type.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Canonical;
        _ = this.Depth;
        _ = this.MentionCount;
        _ = this.Type;
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
}

class NodeFromRaw : IFromRawJson<Node>
{
    /// <inheritdoc/>
    public Node FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Node.FromRawUnchecked(rawData);
}
