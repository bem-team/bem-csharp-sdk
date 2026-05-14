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
/// **Kick off a regression run between two versions of a function.**
///
/// <para>Replays a sample of corrected historical inputs against the comparison
/// version, producing fresh transformations marked `isRegression: true`. Each new
/// run returns the workflow `callID`s you can monitor via `GET /v3/calls/{callID}`.</para>
///
/// <para>Supported for every function type that produces correctable transformations:
/// `extract`, `transform`, `analyze`, `join`. For `extract` specifically, the regression
/// sample is dispatched through the same OCR vs. vision path used at original call
/// time (PDF, PNG, JPEG, HEIC, HEIF, WebP go through the vision worker; everything
/// else goes through OCR → transform).</para>
///
/// <para>The comparison version must share a schema-compatible output shape with
/// the baseline; structural differences are reported as a 400 with the offending
/// field-level diffs.</para>
///
/// <para>## Typical flow</para>
///
/// <para>1. `POST /v3/functions/regression` — queues calls, returns `{ originalReferenceID,
/// callID }` per sample. 2. Wait (poll `GET /v3/calls/{callID}` or subscribe to webhooks).
/// 3. `POST /v3/functions/regression/corrections` to copy baseline corrections onto
/// the new regression transformations. 4. `POST /v3/functions/compare` to compare
/// baseline vs comparison metrics for the regression dataset.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RegressionRunParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// **Name of the function to test for regressions**
    ///
    /// <para>Must be an existing function with historical transformation data containing
    /// user corrections. The function must be currently active and callable.</para>
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

    /// <summary>
    /// **Function version number to use as baseline for comparison**
    ///
    /// <para>- Defaults to `currentVersionNum - 1` (previous version) - Must be a
    /// valid, existing version number for the function - Used to retrieve historical
    /// transformation data for comparison - Cannot be the same as `comparisonVersionNum`</para>
    /// </summary>
    public long? BaselineVersionNum
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("baselineVersionNum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("baselineVersionNum", value);
        }
    }

    /// <summary>
    /// **Function version number to test against the baseline**
    ///
    /// <para>- Defaults to current version number (latest version) - Must be a valid,
    /// existing version number for the function - This version will be used to create
    /// new function calls for testing - Cannot be the same as `baselineVersionNum`</para>
    /// </summary>
    public long? ComparisonVersionNum
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("comparisonVersionNum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("comparisonVersionNum", value);
        }
    }

    /// <summary>
    /// **Whether to only test transformations with user corrections**
    ///
    /// <para>- Defaults to `true` (recommended) - When `true`: Only uses transformations
    /// with `correctedJSON` as ground truth - When `false`: May include transformations
    /// without corrections (less reliable) - Corrected data provides the most accurate
    /// regression testing results</para>
    /// </summary>
    public bool? OnlyCorrectedData
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("onlyCorrectedData");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("onlyCorrectedData", value);
        }
    }

    /// <summary>
    /// **Number of historical samples to test**
    ///
    /// <para>- Defaults to 50 samples - Minimum: 1, Maximum: 1000 - Only transformations
    /// with `correctedJSON` (user corrections) are eligible - Actual sample size
    /// may be smaller if insufficient corrected data exists - Larger samples provide
    /// more statistical confidence but take longer to process</para>
    /// </summary>
    public long? SampleSize
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("sampleSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sampleSize", value);
        }
    }

    public RegressionRunParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegressionRunParams(RegressionRunParams regressionRunParams)
        : base(regressionRunParams)
    {
        this._rawBodyData = new(regressionRunParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RegressionRunParams(
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
    RegressionRunParams(
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
    public static RegressionRunParams FromRawUnchecked(
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

    public virtual bool Equals(RegressionRunParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/functions/regression")
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
