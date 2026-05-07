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
/// **Update a workflow. Updates create a new version.**
///
/// <para>The previous version remains addressable and immutable. Pending and running
/// calls captured at the old version continue against it; new calls run against the
/// new version.</para>
///
/// <para>## Topology updates</para>
///
/// <para>To change the graph you must provide `mainNodeName`, `nodes`, AND `edges`
/// together — partial topology updates are rejected. The full graph is replaced atomically.</para>
///
/// <para>## Metadata-only updates</para>
///
/// <para>Omit all three fields to update only `displayName`, `tags`, or `name` while
/// keeping the topology of the current version.</para>
///
/// <para>## Reverting</para>
///
/// <para>To roll back, fetch the desired prior version and resubmit its `mainNodeName`/`nodes`/`edges`
/// as a new update. Versions themselves are immutable — there is no "pin to version
/// N" operation at the workflow level (use `nodes[].function.versionNum` to pin individual functions).</para>
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

    public IReadOnlyList<WorkflowNode>? Nodes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<WorkflowNode>>("nodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<WorkflowNode>?>(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
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
