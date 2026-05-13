using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Eval.Results;

/// <summary>
/// **Fetch evaluation results for a batch of events.**
///
/// <para>Pass either `eventIDs` (preferred — the externally-stable V3 identifier)
/// or `transformationIDs` as a comma-separated query parameter. Exactly one of the
/// two must be provided. Up to 100 IDs per request.</para>
///
/// <para>For each requested ID the response reports one of three states: a completed
/// `result`, still-`pending`, or `failed`. Results, pending, and failed entries
/// are all keyed by event KSUID regardless of which input form was used.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ResultRetrieveResultsParams : ParamsBase
{
    /// <summary>
    /// Optional evaluation version filter.
    /// </summary>
    public string? EvaluationVersion
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("evaluationVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("evaluationVersion", value);
        }
    }

    /// <summary>
    /// Comma-separated list of event KSUIDs to fetch results for. Between 1 and
    /// 100 IDs per request. Mutually exclusive with `transformationIDs`.
    /// </summary>
    public string? EventIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("eventIDs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("eventIDs", value);
        }
    }

    /// <summary>
    /// Comma-separated list of transformation IDs to fetch results for. Between
    /// 1 and 100 IDs per request. Mutually exclusive with `eventIDs`. Prefer `eventIDs`
    /// for new integrations.
    /// </summary>
    public string? TransformationIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("transformationIDs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("transformationIDs", value);
        }
    }

    public ResultRetrieveResultsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResultRetrieveResultsParams(ResultRetrieveResultsParams resultRetrieveResultsParams)
        : base(resultRetrieveResultsParams) { }
#pragma warning restore CS8618

    public ResultRetrieveResultsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultRetrieveResultsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ResultRetrieveResultsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ResultRetrieveResultsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/eval/results")
        {
            Query = this.QueryString(options),
        }.Uri;
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
