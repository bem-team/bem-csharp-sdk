using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Single-function response wrapper used by V3 function endpoints. V3 wraps individual
/// function responses in a `{"function": ...}` envelope for consistency with other
/// V3 resource endpoints.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FunctionResponse, FunctionResponseFromRaw>))]
public sealed record class FunctionResponse : JsonModel
{
    /// <summary>
    /// A function that delivers workflow outputs to an external destination. Send
    /// functions receive the output of an upstream workflow node and forward it to
    /// a webhook, S3 bucket, or Google Drive folder.
    /// </summary>
    public required Function Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Function>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
    }

    public FunctionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionResponse(FunctionResponse functionResponse)
        : base(functionResponse) { }
#pragma warning restore CS8618

    public FunctionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionResponseFromRaw.FromRawUnchecked"/>
    public static FunctionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionResponse(Function function)
        : this()
    {
        this.Function = function;
    }
}

class FunctionResponseFromRaw : IFromRawJson<FunctionResponse>
{
    /// <inheritdoc/>
    public FunctionResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionResponse.FromRawUnchecked(rawData);
}
