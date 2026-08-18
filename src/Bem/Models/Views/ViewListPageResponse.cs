using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Views;

/// <summary>
/// Response containing a list of views
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ViewListPageResponse, ViewListPageResponseFromRaw>))]
public sealed record class ViewListPageResponse : JsonModel
{
    /// <summary>
    /// Total number of views matching the query
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalCount");
        }
        init { this._rawData.Set("totalCount", value); }
    }

    /// <summary>
    /// Array of views
    /// </summary>
    public required IReadOnlyList<View> Views
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<View>>("views");
        }
        init
        {
            this._rawData.Set<ImmutableArray<View>>(
                "views",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TotalCount;
        foreach (var item in this.Views)
        {
            item.Validate();
        }
    }

    public ViewListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewListPageResponse(ViewListPageResponse viewListPageResponse)
        : base(viewListPageResponse) { }
#pragma warning restore CS8618

    public ViewListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewListPageResponseFromRaw.FromRawUnchecked"/>
    public static ViewListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewListPageResponseFromRaw : IFromRawJson<ViewListPageResponse>
{
    /// <inheritdoc/>
    public ViewListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewListPageResponse.FromRawUnchecked(rawData);
}
