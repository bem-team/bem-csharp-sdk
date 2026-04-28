using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Outputs;

[JsonConverter(typeof(JsonModelConverter<OutputRetrieveResponse, OutputRetrieveResponseFromRaw>))]
public sealed record class OutputRetrieveResponse : JsonModel
{
    /// <summary>
    /// V3 read-side event union. Superset of the shared `Event` union: it contains
    /// every shared variant verbatim (backward compatible) and adds the V3-only
    /// `extract` and `classify` variants.
    /// </summary>
    public required Event Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Event>("output");
        }
        init { this._rawData.Set("output", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Output.Validate();
    }

    public OutputRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputRetrieveResponse(OutputRetrieveResponse outputRetrieveResponse)
        : base(outputRetrieveResponse) { }
#pragma warning restore CS8618

    public OutputRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static OutputRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OutputRetrieveResponse(Event output)
        : this()
    {
        this.Output = output;
    }
}

class OutputRetrieveResponseFromRaw : IFromRawJson<OutputRetrieveResponse>
{
    /// <inheritdoc/>
    public OutputRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputRetrieveResponse.FromRawUnchecked(rawData);
}
