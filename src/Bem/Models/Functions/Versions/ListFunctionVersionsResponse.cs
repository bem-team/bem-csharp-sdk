using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions.Versions;

[JsonConverter(
    typeof(JsonModelConverter<ListFunctionVersionsResponse, ListFunctionVersionsResponseFromRaw>)
)]
public sealed record class ListFunctionVersionsResponse : JsonModel
{
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

    public IReadOnlyList<FunctionVersion>? Versions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FunctionVersion>>("versions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FunctionVersion>?>(
                "versions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TotalCount;
        foreach (var item in this.Versions ?? [])
        {
            item.Validate();
        }
    }

    public ListFunctionVersionsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListFunctionVersionsResponse(ListFunctionVersionsResponse listFunctionVersionsResponse)
        : base(listFunctionVersionsResponse) { }
#pragma warning restore CS8618

    public ListFunctionVersionsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListFunctionVersionsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListFunctionVersionsResponseFromRaw.FromRawUnchecked"/>
    public static ListFunctionVersionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListFunctionVersionsResponseFromRaw : IFromRawJson<ListFunctionVersionsResponse>
{
    /// <inheritdoc/>
    public ListFunctionVersionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListFunctionVersionsResponse.FromRawUnchecked(rawData);
}
