using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Functions.Regression;

/// <summary>
/// **Copy baseline corrections onto regression transformations.**
///
/// <para>Looks up regression transformations created against the comparison version
/// (`isRegression: true`, `correctedJSON IS NULL`), finds the matching baseline
/// transformation by `referenceID`, and copies the baseline's `correctedJSON` onto
/// the regression row via the same code path used by `POST /v3/events/{eventID}/feedback`.
/// The applied corrections are immediately scored against the regression output,
/// populating the confusion-matrix metrics used by `function-review` and `function-version-compare`.</para>
///
/// <para>Works for every function type that produces correctable transformations,
/// including `extract` on both the vision and OCR paths. (Previously the vision path
/// silently dropped `is_regression` during the original regression run, so no rows
/// matched the predicate — that has been fixed.)</para>
///
/// <para>Returns counts plus the list of **event KSUIDs** whose underlying regression
/// transformation received a correction. Errors (e.g. baseline transformation missing
/// for a given `referenceID`) are returned per-row in the `errors` map, keyed by
/// event KSUID, rather than aborting the whole call.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RegressionApplyCorrectionsParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// **Baseline version number (source of corrected data)**
    ///
    /// <para>The function version number that contains transformations with corrected
    /// JSON that should be copied to regression transformations.</para>
    /// </summary>
    public required long BaselineVersionNum
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("baselineVersionNum");
        }
        init { this._rawBodyData.Set("baselineVersionNum", value); }
    }

    /// <summary>
    /// **Comparison version number (target for applying corrections)**
    ///
    /// <para>The function version number of regression transformations that should
    /// receive the corrected JSON from the baseline version.</para>
    /// </summary>
    public required long ComparisonVersionNum
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("comparisonVersionNum");
        }
        init { this._rawBodyData.Set("comparisonVersionNum", value); }
    }

    /// <summary>
    /// **Name of the function to apply corrections for**
    ///
    /// <para>Must be an existing function with both baseline and regression transformation data.</para>
    /// </summary>
    public required string FunctionName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("functionName");
        }
        init { this._rawBodyData.Set("functionName", value); }
    }

    public RegressionApplyCorrectionsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegressionApplyCorrectionsParams(
        RegressionApplyCorrectionsParams regressionApplyCorrectionsParams
    )
        : base(regressionApplyCorrectionsParams)
    {
        this._rawBodyData = new(regressionApplyCorrectionsParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RegressionApplyCorrectionsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegressionApplyCorrectionsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RegressionApplyCorrectionsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(RegressionApplyCorrectionsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v3/functions/regression/corrections"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
