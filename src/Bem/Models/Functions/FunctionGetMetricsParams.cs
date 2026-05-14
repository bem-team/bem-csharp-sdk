using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// **Retrieve performance metrics for functions based on labeled transformation data.**
///
/// <para>Calculates accuracy, precision, recall, F1, and the underlying confusion-matrix
/// counts for each matching function by comparing model outputs against user corrections.
/// Metrics are aggregated across every transformation the function has produced,
/// regardless of function type — `extract`, `transform`, `analyze`, and `join` all
/// populate the same `metrics` column on the transformation row, so v3 surfaces
/// all of them uniformly.</para>
///
/// <para>## Filtering</para>
///
/// <para>Combine `functionIDs` / `functionNames` / `types` to narrow the result
/// set. `types` accepts `extract` alongside the legacy `transform` / `analyze` types
/// (which remain readable). Pagination is cursor-based.</para>
///
/// <para>## Requirements</para>
///
/// <para>A function only shows non-zero metrics once at least one of its transformations
/// has been labeled — submit corrections via `POST /v3/events/{eventID}/feedback`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FunctionGetMetricsParams : ParamsBase
{
    /// <summary>
    /// Cursor — a `functionID` defining your place in the list.
    /// </summary>
    public string? EndingBefore
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("endingBefore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("endingBefore", value);
        }
    }

    public IReadOnlyList<string>? FunctionIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("functionIDs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "functionIDs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? FunctionNames
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("functionNames");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "functionNames",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Sort direction over the result set (default `asc`). Pagination works symmetrically
    /// in both directions via `startingAfter` / `endingBefore`.
    /// </summary>
    public ApiEnum<string, FunctionGetMetricsParamsSortOrder>? SortOrder
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, FunctionGetMetricsParamsSortOrder>
            >("sortOrder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sortOrder", value);
        }
    }

    /// <summary>
    /// Cursor — a `functionID` defining your place in the list.
    /// </summary>
    public string? StartingAfter
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("startingAfter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("startingAfter", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, FunctionType>>? Types
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, FunctionType>>
            >("types");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, FunctionType>>?>(
                "types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public FunctionGetMetricsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionGetMetricsParams(FunctionGetMetricsParams functionGetMetricsParams)
        : base(functionGetMetricsParams) { }
#pragma warning restore CS8618

    public FunctionGetMetricsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionGetMetricsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FunctionGetMetricsParams FromRawUnchecked(
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

    public virtual bool Equals(FunctionGetMetricsParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/functions/metrics")
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

/// <summary>
/// Sort direction over the result set (default `asc`). Pagination works symmetrically
/// in both directions via `startingAfter` / `endingBefore`.
/// </summary>
[JsonConverter(typeof(FunctionGetMetricsParamsSortOrderConverter))]
public enum FunctionGetMetricsParamsSortOrder
{
    Asc,
    Desc,
}

sealed class FunctionGetMetricsParamsSortOrderConverter
    : JsonConverter<FunctionGetMetricsParamsSortOrder>
{
    public override FunctionGetMetricsParamsSortOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => FunctionGetMetricsParamsSortOrder.Asc,
            "desc" => FunctionGetMetricsParamsSortOrder.Desc,
            _ => (FunctionGetMetricsParamsSortOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionGetMetricsParamsSortOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionGetMetricsParamsSortOrder.Asc => "asc",
                FunctionGetMetricsParamsSortOrder.Desc => "desc",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
