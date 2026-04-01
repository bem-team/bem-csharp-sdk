using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Workflows;

/// <summary>
/// **Invoke a workflow by submitting a multipart form request.**
///
/// <para>Workflows can only be called via multipart form in V3. Submit the input
/// file along with an optional reference ID for tracking.</para>
///
/// <para>## Synchronous vs Asynchronous</para>
///
/// <para>By default the call is created asynchronously and this endpoint returns
/// `202 Accepted` immediately with a `pending` call object. Set the `wait` field
/// to `true` to block until the call completes (up to 30 seconds):</para>
///
/// <para>- On success: returns `200 OK` with the completed call, `outputs` populated
/// - On failure: returns `500 Internal Server Error` with the call and an `error`
/// message - On timeout: returns `202 Accepted` with the still-running call</para>
///
/// <para>## Tracking</para>
///
/// <para>Poll `GET /v3/calls/{callID}` to check status, or configure a webhook subscription
/// to receive events when the call finishes.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkflowCallParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? WorkflowName { get; init; }

    /// <summary>
    /// Your reference ID for tracking this call.
    /// </summary>
    public string? CallReferenceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("callReferenceID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("callReferenceID", value);
        }
    }

    /// <summary>
    /// Single input file (for transform, analyze, route, and split functions).
    /// </summary>
    public JsonElement? File
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("file");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("file", value);
        }
    }

    /// <summary>
    /// Multiple input files (for join functions).
    /// </summary>
    public IReadOnlyList<string>? Files
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("files");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "files",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When `true`, the endpoint blocks until the call completes (up to 30 seconds)
    /// and returns the finished call object. Default: `false`.
    /// </summary>
    public string? Wait
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("wait");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("wait", value);
        }
    }

    public WorkflowCallParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCallParams(WorkflowCallParams workflowCallParams)
        : base(workflowCallParams)
    {
        this.WorkflowName = workflowCallParams.WorkflowName;

        this._rawBodyData = new(workflowCallParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WorkflowCallParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkflowCallParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData,
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
    public static WorkflowCallParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData,
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
                new Dictionary<string, MultipartJsonElement>()
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

    public virtual bool Equals(WorkflowCallParams? other)
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
                + string.Format("/v3/workflows/{0}/call", this.WorkflowName)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
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
