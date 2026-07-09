using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Views;

/// <summary>
/// Response containing aggregation data for a view
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ViewGenerateAggregationDataResponse,
        ViewGenerateAggregationDataResponseFromRaw
    >)
)]
public sealed record class ViewGenerateAggregationDataResponse : JsonModel
{
    /// <summary>
    /// Array of aggregation results
    /// </summary>
    public required IReadOnlyList<Aggregation> Aggregations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Aggregation>>("aggregations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Aggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Aggregations)
        {
            item.Validate();
        }
    }

    public ViewGenerateAggregationDataResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewGenerateAggregationDataResponse(
        ViewGenerateAggregationDataResponse viewGenerateAggregationDataResponse
    )
        : base(viewGenerateAggregationDataResponse) { }
#pragma warning restore CS8618

    public ViewGenerateAggregationDataResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewGenerateAggregationDataResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewGenerateAggregationDataResponseFromRaw.FromRawUnchecked"/>
    public static ViewGenerateAggregationDataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ViewGenerateAggregationDataResponse(IReadOnlyList<Aggregation> aggregations)
        : this()
    {
        this.Aggregations = aggregations;
    }
}

class ViewGenerateAggregationDataResponseFromRaw : IFromRawJson<ViewGenerateAggregationDataResponse>
{
    /// <inheritdoc/>
    public ViewGenerateAggregationDataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewGenerateAggregationDataResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation result for a single aggregation definition
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Aggregation, AggregationFromRaw>))]
public sealed record class Aggregation : JsonModel
{
    /// <summary>
    /// Array of group results (single group for non-grouped aggregations)
    /// </summary>
    public required IReadOnlyList<Group> Groups
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Group>>("groups");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Group>>(
                "groups",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Name of the aggregation
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Groups)
        {
            item.Validate();
        }
        _ = this.Name;
    }

    public Aggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Aggregation(Aggregation aggregation)
        : base(aggregation) { }
#pragma warning restore CS8618

    public Aggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Aggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AggregationFromRaw.FromRawUnchecked"/>
    public static Aggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AggregationFromRaw : IFromRawJson<Aggregation>
{
    /// <inheritdoc/>
    public Aggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Aggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// A single group result in an aggregation response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Group, GroupFromRaw>))]
public sealed record class Group : JsonModel
{
    /// <summary>
    /// Name of the group (empty string for non-grouped aggregations)
    /// </summary>
    public required string GroupName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("groupName");
        }
        init { this._rawData.Set("groupName", value); }
    }

    /// <summary>
    /// Aggregated value for this group
    /// </summary>
    public required float Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupName;
        _ = this.Value;
    }

    public Group() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Group(Group group)
        : base(group) { }
#pragma warning restore CS8618

    public Group(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Group(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupFromRaw.FromRawUnchecked"/>
    public static Group FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupFromRaw : IFromRawJson<Group>
{
    /// <inheritdoc/>
    public Group FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Group.FromRawUnchecked(rawData);
}
