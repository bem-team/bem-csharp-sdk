using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// Configuration for enrich function with semantic search steps.
///
/// <para>**How Enrich Functions Work:**</para>
///
/// <para>Enrich functions use semantic search to augment JSON data with relevant
/// information from collections. They take JSON input (typically from a transform
/// function), extract specified fields, perform vector-based semantic search against
/// collections, and inject the results back into the data.</para>
///
/// <para>**Input Requirements:** - Must receive JSON input (typically uploaded to
/// S3 from a previous function) - Can be chained after transform or other functions
/// that produce JSON output</para>
///
/// <para>**Example Use Cases:** - Match product descriptions to SKU codes from a
/// product catalog - Enrich customer data with account information - Link order
/// line items to inventory records</para>
///
/// <para>**Configuration:** - Define one or more enrichment steps - Each step extracts
/// values, searches a collection, and injects results - Steps are executed sequentially</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EnrichConfig, EnrichConfigFromRaw>))]
public sealed record class EnrichConfig : JsonModel
{
    /// <summary>
    /// Array of enrichment steps to execute sequentially
    /// </summary>
    public required IReadOnlyList<EnrichStep> Steps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EnrichStep>>("steps");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EnrichStep>>(
                "steps",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Steps)
        {
            item.Validate();
        }
    }

    public EnrichConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnrichConfig(EnrichConfig enrichConfig)
        : base(enrichConfig) { }
#pragma warning restore CS8618

    public EnrichConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnrichConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnrichConfigFromRaw.FromRawUnchecked"/>
    public static EnrichConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EnrichConfig(IReadOnlyList<EnrichStep> steps)
        : this()
    {
        this.Steps = steps;
    }
}

class EnrichConfigFromRaw : IFromRawJson<EnrichConfig>
{
    /// <inheritdoc/>
    public EnrichConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EnrichConfig.FromRawUnchecked(rawData);
}
