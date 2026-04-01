using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Errors;

[JsonConverter(typeof(JsonModelConverter<ErrorRetrieveResponse, ErrorRetrieveResponseFromRaw>))]
public sealed record class ErrorRetrieveResponse : JsonModel
{
    /// <summary>
    /// The error event.
    /// </summary>
    public required ErrorEvent Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ErrorEvent>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
    }

    public ErrorRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ErrorRetrieveResponse(ErrorRetrieveResponse errorRetrieveResponse)
        : base(errorRetrieveResponse) { }
#pragma warning restore CS8618

    public ErrorRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ErrorRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ErrorRetrieveResponse(ErrorEvent error)
        : this()
    {
        this.Error = error;
    }
}

class ErrorRetrieveResponseFromRaw : IFromRawJson<ErrorRetrieveResponse>
{
    /// <inheritdoc/>
    public ErrorRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ErrorRetrieveResponse.FromRawUnchecked(rawData);
}
