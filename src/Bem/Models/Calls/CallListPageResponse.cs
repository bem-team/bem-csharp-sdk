using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<CallListPageResponse, CallListPageResponseFromRaw>))]
public sealed record class CallListPageResponse : JsonModel
{
    public IReadOnlyList<Call>? Calls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Call>>("calls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Call>?>(
                "calls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error message if the calls listing failed.
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

    /// <summary>
    /// The total number of results available.
    /// </summary>
    public long? TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Calls ?? [])
        {
            item.Validate();
        }
        _ = this.Error;
        _ = this.TotalCount;
    }

    public CallListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallListPageResponse(CallListPageResponse callListPageResponse)
        : base(callListPageResponse) { }
#pragma warning restore CS8618

    public CallListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallListPageResponseFromRaw.FromRawUnchecked"/>
    public static CallListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallListPageResponseFromRaw : IFromRawJson<CallListPageResponse>
{
    /// <inheritdoc/>
    public CallListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CallListPageResponse.FromRawUnchecked(rawData);
}
