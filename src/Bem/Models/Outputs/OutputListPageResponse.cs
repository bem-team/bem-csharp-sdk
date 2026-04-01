using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Outputs;

[JsonConverter(typeof(JsonModelConverter<OutputListPageResponse, OutputListPageResponseFromRaw>))]
public sealed record class OutputListPageResponse : JsonModel
{
    /// <summary>
    /// Array of terminal non-error output events. Each element is polymorphic by
    /// `eventType`. Intermediate events (those that spawned a downstream function
    /// call) are excluded by default; pass `includeIntermediate=true` to include them.
    /// </summary>
    public required IReadOnlyList<Event> Outputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Event>>("outputs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Event>>(
                "outputs",
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
        foreach (var item in this.Outputs)
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public OutputListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListPageResponse(OutputListPageResponse outputListPageResponse)
        : base(outputListPageResponse) { }
#pragma warning restore CS8618

    public OutputListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputListPageResponseFromRaw.FromRawUnchecked"/>
    public static OutputListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputListPageResponseFromRaw : IFromRawJson<OutputListPageResponse>
{
    /// <inheritdoc/>
    public OutputListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputListPageResponse.FromRawUnchecked(rawData);
}
