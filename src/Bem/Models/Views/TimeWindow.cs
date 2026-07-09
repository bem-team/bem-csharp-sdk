using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Views;

/// <summary>
/// Time window for filtering transformations in a view
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TimeWindow, TimeWindowFromRaw>))]
public sealed record class TimeWindow : JsonModel
{
    /// <summary>
    /// End of the time window in ISO 8601 (RFC 3339) format in UTC
    /// </summary>
    public required DateTimeOffset End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("end");
        }
        init { this._rawData.Set("end", value); }
    }

    /// <summary>
    /// Start of the time window in ISO 8601 (RFC 3339) format in UTC
    /// </summary>
    public required DateTimeOffset Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
    }

    public TimeWindow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TimeWindow(TimeWindow timeWindow)
        : base(timeWindow) { }
#pragma warning restore CS8618

    public TimeWindow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeWindow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeWindowFromRaw.FromRawUnchecked"/>
    public static TimeWindow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeWindowFromRaw : IFromRawJson<TimeWindow>
{
    /// <inheritdoc/>
    public TimeWindow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TimeWindow.FromRawUnchecked(rawData);
}
