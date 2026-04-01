using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Calls;

/// <summary>
/// **Retrieve a workflow call by ID.**
///
/// <para>Returns the full call object including status, workflow details, terminal
/// outputs, and terminal errors. `outputs` and `errors` are both populated once the
/// call finishes — they are not mutually exclusive (a partially-completed workflow
/// may have both).</para>
///
/// <para>## Status</para>
///
/// <para>| Status | Description | |--------|-------------| | `pending` | Queued,
/// not yet started | | `running` | Currently executing | | `completed` | All enclosed
/// function calls finished without errors | | `failed` | One or more enclosed function
/// calls produced an error event |</para>
///
/// <para>Poll this endpoint or configure a webhook subscription to detect completion.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallRetrieveParams : ParamsBase
{
    public string? CallID { get; init; }

    public CallRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveParams(CallRetrieveParams callRetrieveParams)
        : base(callRetrieveParams)
    {
        this.CallID = callRetrieveParams.CallID;
    }
#pragma warning restore CS8618

    public CallRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveParams(
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
    public static CallRetrieveParams FromRawUnchecked(
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

    public virtual bool Equals(CallRetrieveParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v3/calls/{0}", this.CallID)
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
