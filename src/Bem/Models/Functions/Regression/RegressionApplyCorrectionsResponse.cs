using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions.Regression;

/// <summary>
/// V3 response from applying baseline corrections to regression transformations.
/// Identifiers are surfaced as event KSUIDs — the externally-stable IDs used everywhere
/// else in V3 — in place of the internal transformation IDs returned by the V2 endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RegressionApplyCorrectionsResponse,
        RegressionApplyCorrectionsResponseFromRaw
    >)
)]
public sealed record class RegressionApplyCorrectionsResponse : JsonModel
{
    /// <summary>
    /// Number of corrections that were applied successfully.
    /// </summary>
    public required long Applied
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("applied");
        }
        init { this._rawData.Set("applied", value); }
    }

    /// <summary>
    /// Event KSUIDs whose underlying regression transformation had a baseline correction
    /// copied onto it.
    /// </summary>
    public required IReadOnlyList<string> AppliedEventIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("appliedEventIDs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "appliedEventIDs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Map of event KSUID to error message for any regression rows where the correction
    /// could not be applied (e.g. baseline transformation not found for the row's
    /// reference ID).
    /// </summary>
    public required JsonElement Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("errors");
        }
        init { this._rawData.Set("errors", value); }
    }

    /// <summary>
    /// Number of regression transformations that were skipped — typically because
    /// they already had a correction or did not have a usable reference ID.
    /// </summary>
    public required long Skipped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skipped");
        }
        init { this._rawData.Set("skipped", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Applied;
        _ = this.AppliedEventIds;
        _ = this.Errors;
        _ = this.Skipped;
    }

    public RegressionApplyCorrectionsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegressionApplyCorrectionsResponse(
        RegressionApplyCorrectionsResponse regressionApplyCorrectionsResponse
    )
        : base(regressionApplyCorrectionsResponse) { }
#pragma warning restore CS8618

    public RegressionApplyCorrectionsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegressionApplyCorrectionsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegressionApplyCorrectionsResponseFromRaw.FromRawUnchecked"/>
    public static RegressionApplyCorrectionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegressionApplyCorrectionsResponseFromRaw : IFromRawJson<RegressionApplyCorrectionsResponse>
{
    /// <inheritdoc/>
    public RegressionApplyCorrectionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RegressionApplyCorrectionsResponse.FromRawUnchecked(rawData);
}
