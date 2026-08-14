using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// **Estimate human review requirements for a function.**
///
/// <para>Combines confusion-matrix metrics with the per-transformation evaluation
/// scores (confidence / hallucination / relevance produced by the eval service)
/// to compute:</para>
///
/// <para>- A confidence-bucketed distribution of the function's outputs. - Sample-size
/// estimates at configurable margin-of-error and confidence levels (Wald or Wilson
/// intervals). - A precision-recall AUC and a per-threshold matrix you can use to
/// pick a review cutoff.</para>
///
/// <para>Supported for every function type that produces transformations and feeds
/// the auto-evaluation pipeline: `extract`, `transform`, `analyze`, `join`. Extract
/// works on both vision (PDF/PNG/JPEG/HEIC/HEIF/WebP) and OCR-routed inputs.</para>
///
/// <para>Pass `isRegression: true` to scope the review to transformations created
/// by a previous regression run (see `POST /v3/functions/regression`).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FunctionEstimateReviewRequirementsParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of the function to analyze
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
    /// Confidence levels for statistical analysis as integers representing percentages
    /// (e.g., [90, 95, 99] for 90%, 95%, 99%). IMPORTANT: Only integers are accepted,
    /// floats like 0.95 will be rejected.
    /// </summary>
    public IReadOnlyList<long>? ConfidenceLevels
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<long>>("confidenceLevels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<long>?>(
                "confidenceLevels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Confidence interval calculation method (default "wald").
    ///
    /// <para>- "wald": Normal approximation method (faster, standard) - "wilson":
    /// Wilson score interval (more robust for extreme rates)</para>
    /// </summary>
    public ApiEnum<string, ConfidenceMethod>? ConfidenceMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConfidenceMethod>>(
                "confidenceMethod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("confidenceMethod", value);
        }
    }

    /// <summary>
    /// Optional evaluation version to filter evaluations by. Must be one of the
    /// supported versions. If not provided, defaults to "0.1.0-gemini".
    /// </summary>
    public ApiEnum<string, EvaluationVersion>? EvaluationVersion
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, EvaluationVersion>>(
                "evaluationVersion"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("evaluationVersion", value);
        }
    }

    /// <summary>
    /// Optional function version number to analyze. If not provided, uses the latest/current
    /// version of the function.
    /// </summary>
    public long? FunctionVersionNum
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("functionVersionNum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("functionVersionNum", value);
        }
    }

    /// <summary>
    /// Internal flag indicating if the request is from a regression test
    /// </summary>
    public bool? IsRegression
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("isRegression");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("isRegression", value);
        }
    }

    /// <summary>
    /// Margin of error for statistical calculations
    /// </summary>
    public float? MarginOfError
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<float>("marginOfError");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("marginOfError", value);
        }
    }

    /// <summary>
    /// Maximum confidence threshold to analyze
    /// </summary>
    public float? ThresholdMax
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<float>("thresholdMax");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("thresholdMax", value);
        }
    }

    /// <summary>
    /// Minimum confidence threshold to analyze
    /// </summary>
    public float? ThresholdMin
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<float>("thresholdMin");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("thresholdMin", value);
        }
    }

    /// <summary>
    /// Step size for threshold analysis (smaller = more granular)
    /// </summary>
    public float? ThresholdStep
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<float>("thresholdStep");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("thresholdStep", value);
        }
    }

    public FunctionEstimateReviewRequirementsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionEstimateReviewRequirementsParams(
        FunctionEstimateReviewRequirementsParams functionEstimateReviewRequirementsParams
    )
        : base(functionEstimateReviewRequirementsParams)
    {
        this._rawBodyData = new(functionEstimateReviewRequirementsParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FunctionEstimateReviewRequirementsParams(
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
    FunctionEstimateReviewRequirementsParams(
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
    public static FunctionEstimateReviewRequirementsParams FromRawUnchecked(
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

    public virtual bool Equals(FunctionEstimateReviewRequirementsParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/functions/review")
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

/// <summary>
/// Confidence interval calculation method (default "wald").
///
/// <para>- "wald": Normal approximation method (faster, standard) - "wilson": Wilson
/// score interval (more robust for extreme rates)</para>
/// </summary>
[JsonConverter(typeof(ConfidenceMethodConverter))]
public enum ConfidenceMethod
{
    Wald,
    Wilson,
}

sealed class ConfidenceMethodConverter : JsonConverter<ConfidenceMethod>
{
    public override ConfidenceMethod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wald" => ConfidenceMethod.Wald,
            "wilson" => ConfidenceMethod.Wilson,
            _ => (ConfidenceMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConfidenceMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConfidenceMethod.Wald => "wald",
                ConfidenceMethod.Wilson => "wilson",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Optional evaluation version to filter evaluations by. Must be one of the supported
/// versions. If not provided, defaults to "0.1.0-gemini".
/// </summary>
[JsonConverter(typeof(EvaluationVersionConverter))]
public enum EvaluationVersion
{
    V0_1_0Gemini,
}

sealed class EvaluationVersionConverter : JsonConverter<EvaluationVersion>
{
    public override EvaluationVersion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "0.1.0-gemini" => EvaluationVersion.V0_1_0Gemini,
            _ => (EvaluationVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EvaluationVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EvaluationVersion.V0_1_0Gemini => "0.1.0-gemini",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
