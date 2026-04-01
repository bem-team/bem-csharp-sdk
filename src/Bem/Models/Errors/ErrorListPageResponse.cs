using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Errors;

[JsonConverter(typeof(JsonModelConverter<ErrorListPageResponse, ErrorListPageResponseFromRaw>))]
public sealed record class ErrorListPageResponse : JsonModel
{
    /// <summary>
    /// Array of terminal error events.
    /// </summary>
    public required IReadOnlyList<ErrorEvent> Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ErrorEvent>>("errors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ErrorEvent>>(
                "errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The total number of results available.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Errors)
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public ErrorListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ErrorListPageResponse(ErrorListPageResponse errorListPageResponse)
        : base(errorListPageResponse) { }
#pragma warning restore CS8618

    public ErrorListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorListPageResponseFromRaw.FromRawUnchecked"/>
    public static ErrorListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorListPageResponseFromRaw : IFromRawJson<ErrorListPageResponse>
{
    /// <inheritdoc/>
    public ErrorListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ErrorListPageResponse.FromRawUnchecked(rawData);
}
