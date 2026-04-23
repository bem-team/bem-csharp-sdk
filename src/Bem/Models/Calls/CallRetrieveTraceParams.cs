using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Calls;

/// <summary>
/// **Retrieve the full execution trace of a workflow call.**
///
/// <para>Returns all function calls and events emitted during the call as flat arrays.
/// The DAG can be reconstructed using `FunctionCallResponseBase.sourceEventID` (the
/// event that spawned each function call) and each event's `functionCallID` (the
/// function call that emitted it).</para>
///
/// <para>## Graph structure</para>
///
/// <para>- A function call with no `sourceEventID` is the root. - An event's `functionCallID`
/// points to the function call that emitted it. - A function call's `sourceEventID`
/// points to the event that triggered it. - `workflowNodeName` identifies the DAG
/// node; `incomingDestinationName` identifies the labelled outlet used to reach
/// this call (absent for unlabelled edges and root calls).</para>
///
/// <para>The trace is available as soon as the call exists and grows as execution proceeds.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallRetrieveTraceParams : ParamsBase
{
    public string? CallID { get; init; }

    public CallRetrieveTraceParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveTraceParams(CallRetrieveTraceParams callRetrieveTraceParams)
        : base(callRetrieveTraceParams)
    {
        this.CallID = callRetrieveTraceParams.CallID;
    }
#pragma warning restore CS8618

    public CallRetrieveTraceParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveTraceParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string callID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CallID = callID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CallRetrieveTraceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string callID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            callID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CallID"] = JsonSerializer.SerializeToElement(this.CallID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CallRetrieveTraceParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallID?.Equals(other.CallID) ?? other.CallID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/calls/{0}/trace", this.CallID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
