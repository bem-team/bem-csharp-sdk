using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Views;

/// <summary>
/// A view is a table visualization of transformations that allows customers to have
/// insight into their transformations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<View, ViewFromRaw>))]
public sealed record class View : JsonModel
{
    /// <summary>
    /// List of aggregations defined for the view
    /// </summary>
    public required IReadOnlyList<ViewAggregation> Aggregations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewAggregation>>("aggregations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewAggregation>>(
                "aggregations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of columns in the view
    /// </summary>
    public required IReadOnlyList<ViewColumn> Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewColumn>>("columns");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewColumn>>(
                "columns",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Current version number of the view
    /// </summary>
    public required long CurrentVersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("currentVersionNum");
        }
        init { this._rawData.Set("currentVersionNum", value); }
    }

    /// <summary>
    /// List of filters applied to the view
    /// </summary>
    public required IReadOnlyList<ViewFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ViewFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ViewFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of functions that this view queries transformations from
    /// </summary>
    public required IReadOnlyList<FunctionIdentifier> Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FunctionIdentifier>>("functions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FunctionIdentifier>>(
                "functions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Name of the view
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

    /// <summary>
    /// Unique identifier of the view
    /// </summary>
    public required string ViewID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("viewID");
        }
        init { this._rawData.Set("viewID", value); }
    }

    /// <summary>
    /// Description of the view
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Aggregations)
        {
            item.Validate();
        }
        foreach (var item in this.Columns)
        {
            item.Validate();
        }
        _ = this.CurrentVersionNum;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        foreach (var item in this.Functions)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.ViewID;
        _ = this.Description;
    }

    public View() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public View(View view)
        : base(view) { }
#pragma warning restore CS8618

    public View(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    View(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewFromRaw.FromRawUnchecked"/>
    public static View FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewFromRaw : IFromRawJson<View>
{
    /// <inheritdoc/>
    public View FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        View.FromRawUnchecked(rawData);
}
