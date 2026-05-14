using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

[JsonConverter(
    typeof(JsonModelConverter<FunctionGetMetricsResponse, FunctionGetMetricsResponseFromRaw>)
)]
public sealed record class FunctionGetMetricsResponse : JsonModel
{
    public required IReadOnlyList<FunctionGetMetricsResponseFunction> Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FunctionGetMetricsResponseFunction>
            >("functions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FunctionGetMetricsResponseFunction>>(
                "functions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total number of functions
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalCount");
        }
        init { this._rawData.Set("totalCount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Functions)
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public FunctionGetMetricsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionGetMetricsResponse(FunctionGetMetricsResponse functionGetMetricsResponse)
        : base(functionGetMetricsResponse) { }
#pragma warning restore CS8618

    public FunctionGetMetricsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionGetMetricsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionGetMetricsResponseFromRaw.FromRawUnchecked"/>
    public static FunctionGetMetricsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionGetMetricsResponseFromRaw : IFromRawJson<FunctionGetMetricsResponse>
{
    /// <inheritdoc/>
    public FunctionGetMetricsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionGetMetricsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionGetMetricsResponseFunction,
        FunctionGetMetricsResponseFunctionFromRaw
    >)
)]
public sealed record class FunctionGetMetricsResponseFunction : JsonModel
{
    /// <summary>
    /// The function name
    /// </summary>
    public required string FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionName");
        }
        init { this._rawData.Set("functionName", value); }
    }

    public required FunctionGetMetricsResponseFunctionMetrics Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionGetMetricsResponseFunctionMetrics>(
                "metrics"
            );
        }
        init { this._rawData.Set("metrics", value); }
    }

    /// <summary>
    /// Number of transformations that have been labeled/evaluated for metrics calculation
    /// </summary>
    public required long TotalLabeledResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalLabeledResults");
        }
        init { this._rawData.Set("totalLabeledResults", value); }
    }

    /// <summary>
    /// Total number of results processed by the function
    /// </summary>
    public required long TotalResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalResults");
        }
        init { this._rawData.Set("totalResults", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionName;
        this.Metrics.Validate();
        _ = this.TotalLabeledResults;
        _ = this.TotalResults;
    }

    public FunctionGetMetricsResponseFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionGetMetricsResponseFunction(
        FunctionGetMetricsResponseFunction functionGetMetricsResponseFunction
    )
        : base(functionGetMetricsResponseFunction) { }
#pragma warning restore CS8618

    public FunctionGetMetricsResponseFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionGetMetricsResponseFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionGetMetricsResponseFunctionFromRaw.FromRawUnchecked"/>
    public static FunctionGetMetricsResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionGetMetricsResponseFunctionFromRaw : IFromRawJson<FunctionGetMetricsResponseFunction>
{
    /// <inheritdoc/>
    public FunctionGetMetricsResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionGetMetricsResponseFunction.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionGetMetricsResponseFunctionMetrics,
        FunctionGetMetricsResponseFunctionMetricsFromRaw
    >)
)]
public sealed record class FunctionGetMetricsResponseFunctionMetrics : JsonModel
{
    public required float? Accuracy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("accuracy");
        }
        init { this._rawData.Set("accuracy", value); }
    }

    public required float? F1Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("f1Score");
        }
        init { this._rawData.Set("f1Score", value); }
    }

    public required long Fn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fn");
        }
        init { this._rawData.Set("fn", value); }
    }

    public required long Fp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fp");
        }
        init { this._rawData.Set("fp", value); }
    }

    public required float? Precision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("precision");
        }
        init { this._rawData.Set("precision", value); }
    }

    public required float? Recall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("recall");
        }
        init { this._rawData.Set("recall", value); }
    }

    public required long Tn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tn");
        }
        init { this._rawData.Set("tn", value); }
    }

    public required long Tp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tp");
        }
        init { this._rawData.Set("tp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Accuracy;
        _ = this.F1Score;
        _ = this.Fn;
        _ = this.Fp;
        _ = this.Precision;
        _ = this.Recall;
        _ = this.Tn;
        _ = this.Tp;
    }

    public FunctionGetMetricsResponseFunctionMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionGetMetricsResponseFunctionMetrics(
        FunctionGetMetricsResponseFunctionMetrics functionGetMetricsResponseFunctionMetrics
    )
        : base(functionGetMetricsResponseFunctionMetrics) { }
#pragma warning restore CS8618

    public FunctionGetMetricsResponseFunctionMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionGetMetricsResponseFunctionMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionGetMetricsResponseFunctionMetricsFromRaw.FromRawUnchecked"/>
    public static FunctionGetMetricsResponseFunctionMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionGetMetricsResponseFunctionMetricsFromRaw
    : IFromRawJson<FunctionGetMetricsResponseFunctionMetrics>
{
    /// <inheritdoc/>
    public FunctionGetMetricsResponseFunctionMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionGetMetricsResponseFunctionMetrics.FromRawUnchecked(rawData);
}
