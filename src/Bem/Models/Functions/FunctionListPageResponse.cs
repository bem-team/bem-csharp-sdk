using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

[JsonConverter(
    typeof(JsonModelConverter<FunctionListPageResponse, FunctionListPageResponseFromRaw>)
)]
public sealed record class FunctionListPageResponse : JsonModel
{
    public IReadOnlyList<FunctionListResponse>? Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FunctionListResponse>>(
                "functions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FunctionListResponse>?>(
                "functions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        foreach (var item in this.Functions ?? [])
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public FunctionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListPageResponse(FunctionListPageResponse functionListPageResponse)
        : base(functionListPageResponse) { }
#pragma warning restore CS8618

    public FunctionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListPageResponseFromRaw.FromRawUnchecked"/>
    public static FunctionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListPageResponseFromRaw : IFromRawJson<FunctionListPageResponse>
{
    /// <inheritdoc/>
    public FunctionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListPageResponse.FromRawUnchecked(rawData);
}
