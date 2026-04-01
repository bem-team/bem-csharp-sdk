using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<CallGetResponse, CallGetResponseFromRaw>))]
public sealed record class CallGetResponse : JsonModel
{
    /// <summary>
    /// A workflow call returned by the V3 API.
    ///
    /// <para>Compared to the V2 `Call` model: - Terminal outputs are split into
    /// `outputs` (non-error events) and `errors` (error events) - `callType` and
    /// function-scoped fields are removed — V3 calls are always workflow calls -
    /// The deprecated `functionCalls` field is removed (use `GET /v3/calls/{callID}/trace`)
    /// - `url` and `traceUrl` hint fields are included for resource discovery</para>
    /// </summary>
    public Call? Call
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Call>("call");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("call", value);
        }
    }

    /// <summary>
    /// Error message if the call retrieval failed, or if the call itself failed when
    /// using `wait=true`.
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Call?.Validate();
        _ = this.Error;
    }

    public CallGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallGetResponse(CallGetResponse callGetResponse)
        : base(callGetResponse) { }
#pragma warning restore CS8618

    public CallGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallGetResponseFromRaw.FromRawUnchecked"/>
    public static CallGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallGetResponseFromRaw : IFromRawJson<CallGetResponse>
{
    /// <inheritdoc/>
    public CallGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallGetResponse.FromRawUnchecked(rawData);
}
