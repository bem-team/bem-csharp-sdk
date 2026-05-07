using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Workflows;

/// <summary>
/// **Create a workflow.**
///
/// <para>A workflow is a directed acyclic graph of nodes (each pointing at a function)
/// with one entry point (`mainNodeName`). The graph runs end-to-end on every call.</para>
///
/// <para>## Required structure</para>
///
/// <para>- `name`: unique within the environment, alphanumeric plus hyphens and
/// underscores. - `mainNodeName`: must match one of the `nodes[].name` values, and
/// must not be the destination of any edge. - `nodes`: at least one. Each node has
/// a unique `name` and a `function` reference (by `functionName` or `functionID`,
/// optionally pinned to a `versionNum`). - `edges`: optional for single-node workflows.
/// For branching sources (Classify, semantic Split), each edge carries a `destinationName`
/// matching a `classifications[].name` or `itemClasses[].name` on the source function.</para>
///
/// <para>The created workflow is at `versionNum: 1`. Subsequent `PATCH /v3/workflows/{workflowName}`
/// calls produce new versions.</para>
///
/// <para>## Common patterns</para>
///
/// <para>- **Single-node**: one extract/classify function, no edges. - **Sequential**:
/// extract → enrich → payload_shaping (linear edges). - **Branching**: classify →
/// multiple extracts (one edge per classification name). - **Split-then-process**:
/// split → multiple extracts (one edge per item class).</para>
///
/// <para>See [Workflows explained](/guide/workflows-explained) for end-to-end examples
/// of each pattern.</para>
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
    public required IReadOnlyList<WorkflowNode> Nodes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<WorkflowNode>>("nodes");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<WorkflowNode>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Connectors to attach to the workflow at creation. If any entry fails to provision,
    /// the entire workflow creation is rolled back.
    /// </summary>
    public IReadOnlyList<WorkflowConnector>? Connectors
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<WorkflowConnector>>(
                "connectors"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<WorkflowConnector>?>(
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
    public IReadOnlyList<WorkflowEdge>? Edges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<WorkflowEdge>>("edges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<WorkflowEdge>?>(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/workflows")
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
