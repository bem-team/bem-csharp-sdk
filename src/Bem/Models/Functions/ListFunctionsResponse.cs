using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<ListFunctionsResponse, ListFunctionsResponseFromRaw>))]
public sealed record class ListFunctionsResponse : JsonModel
{
    public IReadOnlyList<Function>? Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Function>>("functions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Function>?>(
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

    public ListFunctionsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListFunctionsResponse(ListFunctionsResponse listFunctionsResponse)
        : base(listFunctionsResponse) { }
#pragma warning restore CS8618

    public ListFunctionsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListFunctionsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListFunctionsResponseFromRaw.FromRawUnchecked"/>
    public static ListFunctionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListFunctionsResponseFromRaw : IFromRawJson<ListFunctionsResponse>
{
    /// <inheritdoc/>
    public ListFunctionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListFunctionsResponse.FromRawUnchecked(rawData);
}
