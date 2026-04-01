using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Workflows.Versions;

[JsonConverter(typeof(JsonModelConverter<VersionListPageResponse, VersionListPageResponseFromRaw>))]
public sealed record class VersionListPageResponse : JsonModel
{
    /// <summary>
    /// Error message if the workflow versions listing failed.
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

    public IReadOnlyList<Workflow>? Versions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Workflow>>("versions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Workflow>?>(
                "versions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        _ = this.TotalCount;
        foreach (var item in this.Versions ?? [])
        {
            item.Validate();
        }
    }

    public VersionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionListPageResponse(VersionListPageResponse versionListPageResponse)
        : base(versionListPageResponse) { }
#pragma warning restore CS8618

    public VersionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionListPageResponseFromRaw.FromRawUnchecked"/>
    public static VersionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionListPageResponseFromRaw : IFromRawJson<VersionListPageResponse>
{
    /// <inheritdoc/>
    public VersionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionListPageResponse.FromRawUnchecked(rawData);
}
