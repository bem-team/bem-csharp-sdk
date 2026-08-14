using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions.Regression;

/// <summary>
/// **Response from initiating a regression test**
///
/// <para>Contains the function call IDs created for async processing and tracking
/// information. Use the returned function call IDs to monitor progress and retrieve results.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RegressionRunResponse, RegressionRunResponseFromRaw>))]
public sealed record class RegressionRunResponse : JsonModel
{
    /// <summary>
    /// **Name of the function being tested**
    ///
    /// <para>Echoes back the function name from the request for confirmation.</para>
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

    /// <summary>
    /// **Detailed regression test results and tracking information**
    ///
    /// <para>Contains function call IDs for monitoring progress. When all function
    /// calls complete, use the transformation endpoints to retrieve and analyze
    /// the actual results.</para>
    /// </summary>
    public required Result Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Result>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionName;
        this.Result.Validate();
    }

    public RegressionRunResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegressionRunResponse(RegressionRunResponse regressionRunResponse)
        : base(regressionRunResponse) { }
#pragma warning restore CS8618

    public RegressionRunResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegressionRunResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegressionRunResponseFromRaw.FromRawUnchecked"/>
    public static RegressionRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegressionRunResponseFromRaw : IFromRawJson<RegressionRunResponse>
{
    /// <inheritdoc/>
    public RegressionRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RegressionRunResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// **Detailed regression test results and tracking information**
///
/// <para>Contains function call IDs for monitoring progress. When all function calls
/// complete, use the transformation endpoints to retrieve and analyze the actual results.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// **Name of the function being tested**
    ///
    /// <para>The function for which regression testing was initiated.</para>
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

    /// <summary>
    /// **Total number of samples being tested**
    ///
    /// <para>This represents the number of historical transformations found with
    /// corrections that will be retested with the latest function version.</para>
    /// </summary>
    public required long TotalSamples
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalSamples");
        }
        init { this._rawData.Set("totalSamples", value); }
    }

    /// <summary>
    /// **Calls created for regression testing**
    ///
    /// <para>Each object contains the original reference ID and the new call ID
    /// created for testing. Use these call IDs with standard call endpoints to monitor progress:</para>
    ///
    /// <para>- `GET /v2/calls/{callID}` - Check individual status - `GET /v2/calls?referenceIDs=regression-*`
    /// - List all regression calls</para>
    /// </summary>
    public IReadOnlyList<Call>? Calls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Call>>("calls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Call>?>(
                "calls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FunctionName;
        _ = this.TotalSamples;
        foreach (var item in this.Calls ?? [])
        {
            item.Validate();
        }
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// **Call created for regression testing**
///
/// <para>Links the original historical reference ID to the new call ID created for
/// testing. Use the call ID with standard call endpoints to monitor progress and
/// retrieve results.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Call, CallFromRaw>))]
public sealed record class Call : JsonModel
{
    /// <summary>
    /// **New call ID created for regression testing**
    ///
    /// <para>Use this ID with standard call endpoints: - `GET /v2/calls/{callID}`
    /// - Check status and retrieve results - The call will have reference ID matching
    /// the original transformation</para>
    /// </summary>
    public required string CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("callID");
        }
        init { this._rawData.Set("callID", value); }
    }

    /// <summary>
    /// **Original reference ID from historical transformation data**
    ///
    /// <para>This is the reference ID that was used when the historical transformation
    /// was originally created. It provides traceability back to the original business
    /// context (e.g., invoice number, document ID).</para>
    /// </summary>
    public required string OriginalReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("originalReferenceID");
        }
        init { this._rawData.Set("originalReferenceID", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallID;
        _ = this.OriginalReferenceID;
    }

    public Call() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Call(Call call)
        : base(call) { }
#pragma warning restore CS8618

    public Call(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Call(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallFromRaw.FromRawUnchecked"/>
    public static Call FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallFromRaw : IFromRawJson<Call>
{
    /// <inheritdoc/>
    public Call FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Call.FromRawUnchecked(rawData);
}
