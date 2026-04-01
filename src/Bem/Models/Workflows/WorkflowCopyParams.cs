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
/// Copy a Workflow
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkflowCopyParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of the source workflow to copy from.
    /// </summary>
    public required string SourceWorkflowName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("sourceWorkflowName");
        }
        init { this._rawBodyData.Set("sourceWorkflowName", value); }
    }

    /// <summary>
    /// Name for the new copied workflow. Must be unique within the target environment.
    /// </summary>
    public required string TargetWorkflowName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("targetWorkflowName");
        }
        init { this._rawBodyData.Set("targetWorkflowName", value); }
    }

    /// <summary>
    /// Optional version number of the source workflow to copy. If not provided,
    /// copies the current version.
    /// </summary>
    public long? SourceWorkflowVersionNum
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("sourceWorkflowVersionNum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sourceWorkflowVersionNum", value);
        }
    }

    /// <summary>
    /// Optional tags for the copied workflow. If not provided, uses the source workflow's tags.
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

    /// <summary>
    /// Optional display name for the copied workflow. If not provided, uses the
    /// source workflow's display name with " (Copy)" appended.
    /// </summary>
    public string? TargetDisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("targetDisplayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("targetDisplayName", value);
        }
    }

    /// <summary>
    /// Optional target environment name. If provided, copies the workflow to a different
    /// environment. When copying to a different environment, all functions used
    /// in the workflow will also be copied.
    /// </summary>
    public string? TargetEnvironment
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("targetEnvironment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("targetEnvironment", value);
        }
    }

    public WorkflowCopyParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCopyParams(WorkflowCopyParams workflowCopyParams)
        : base(workflowCopyParams)
    {
        this._rawBodyData = new(workflowCopyParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WorkflowCopyParams(
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
    WorkflowCopyParams(
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
    public static WorkflowCopyParams FromRawUnchecked(
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

    public virtual bool Equals(WorkflowCopyParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/workflows/copy")
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
