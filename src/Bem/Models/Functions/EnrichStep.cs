using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// Single enrichment step configuration.
///
/// <para>**Process Flow (collection source):** 1. Extract values from `sourceField`
/// using JMESPath 2. Perform search against the specified collection (semantic, exact,
/// or hybrid based on `searchMode`) 3. Return top K matches sorted by relevance (best
/// match first) 4. Inject results into `targetField`</para>
///
/// <para>**Process Flow (endpoint source):** 1. Extract values from `sourceField`
/// using JMESPath 2. Call the named endpoint once per extracted value, following
/// pagination if `nextPagePath`/`nextPageParam` are configured on the endpoint 3.
/// Optionally apply LLM agent reasoning to rank candidates (`matchInstructions`),
/// batching across all fetched pages in groups of `maxCandidates` 4. Inject results
/// into `targetField`</para>
///
/// <para>**Collection Search Modes** (`source: "collection"` only): - `semantic`
/// (default): Vector similarity search — best for natural language and conceptual
/// matching - `exact`: Exact keyword matching — best for SKU numbers, IDs, routing
/// numbers - `hybrid`: Combined semantic + keyword search — best for tags and categories</para>
///
/// <para>**Result Format (collection source):** - Always an array sorted by relevance
/// (best match first) - Each element: `{ data, cosineDistance? }` or `{ data, hybridScore? }`</para>
///
/// <para>**Result Format (endpoint source, no matchInstructions):** - Always an array;
/// the raw fetched value is the single element</para>
///
/// <para>**Result Format (endpoint source, with matchInstructions):** - Array of
/// LLM-ranked matches: `[{ data, confidence, reasoning? }, ...]` - Length capped
/// by `enrichEndpoint.matchTopK` (default 1)</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EnrichStep, EnrichStepFromRaw>))]
public sealed record class EnrichStep : JsonModel
{
    /// <summary>
    /// JMESPath expression to extract source data. Can extract a single value or
    /// an array. Each extracted value is looked up independently.
    /// </summary>
    public required string SourceField
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceField");
        }
        init { this._rawData.Set("sourceField", value); }
    }

    /// <summary>
    /// Field path where enriched results should be placed. Use simple field names
    /// (e.g., "enriched_products"). Results are always injected as an array (list),
    /// regardless of topK value.
    /// </summary>
    public required string TargetField
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("targetField");
        }
        init { this._rawData.Set("targetField", value); }
    }

    /// <summary>
    /// Name of the collection to search against. Required when `source` is `"collection"`.
    /// The collection must exist and contain items. Supports hierarchical paths
    /// when used with `includeSubcollections`.
    /// </summary>
    public string? CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("collectionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectionName", value);
        }
    }

    /// <summary>
    /// Name of an endpoint defined in `enrichConfig.endpoints`. Required when `source`
    /// is `"endpoint"`.
    /// </summary>
    public string? EndpointName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("endpointName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("endpointName", value);
        }
    }

    /// <summary>
    /// Whether to include cosine distance scores in results. Cosine distance ranges
    /// from 0.0 (perfect match) to 2.0 (completely dissimilar). Lower scores indicate
    /// better semantic similarity.
    ///
    /// <para>When enabled, each result includes a `cosine_distance` field (semantic
    /// mode) or a `hybrid_score` field (hybrid mode).</para>
    /// </summary>
    public bool? IncludeScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeScore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeScore", value);
        }
    }

    /// <summary>
    /// When true, searches all collections under the hierarchical path. For example,
    /// "customers" will match "customers", "customers.premium", etc.
    /// </summary>
    public bool? IncludeSubcollections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeSubcollections");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeSubcollections", value);
        }
    }

    /// <summary>
    /// Maximum cosine distance threshold for filtering results (default: 0.6). Results
    /// with cosine distance above this threshold are excluded.
    ///
    /// <para>**Only applies to `semantic` and `hybrid` search modes.** Exact search
    /// does not use cosine distance and ignores this setting.</para>
    ///
    /// <para>Cosine distance ranges from 0.0 (identical) to 2.0 (opposite): - 0.0
    /// - 0.3: Very similar (strict threshold, high-quality matches only) - 0.3 -
    /// 0.6: Reasonably similar (moderate threshold) - 0.6 - 1.0: Loosely related
    /// (lenient threshold) - &gt; 1.0: Rarely useful — allows nearly unrelated results</para>
    ///
    /// <para>For most semantic search use cases, good matches typically fall in the
    /// 0.2 - 0.5 range.</para>
    /// </summary>
    public double? ScoreThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("scoreThreshold");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scoreThreshold", value);
        }
    }

    /// <summary>
    /// Search mode to use for enrichment (default: "semantic").
    ///
    /// <para>**semantic**: Vector similarity search using dense embeddings. Best
    /// for finding conceptually similar items. - Use for: Product descriptions,
    /// natural language content - Example: "red sports car" matches "crimson convertible automobile"</para>
    ///
    /// <para>**exact**: Exact keyword matching using PostgreSQL text search. Best
    /// for exact identifiers. - Use for: SKU numbers, routing numbers, account IDs,
    /// exact tags - Example: "SKU-12345" only matches items containing that exact text</para>
    ///
    /// <para>**hybrid**: Combined search using 20% semantic + 80% sparse embeddings
    /// (keyword-based). - Use for: Tags, categories, partial identifiers - Example:
    /// Balances semantic meaning with exact keyword matching</para>
    /// </summary>
    public ApiEnum<string, SearchMode>? SearchMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SearchMode>>("searchMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("searchMode", value);
        }
    }

    /// <summary>
    /// Where to fetch enrichment data from (default: `"collection"`).
    ///
    /// <para>- `"collection"`: Vector/keyword search against a BEM collection. Requires
    /// `collectionName`. - `"endpoint"`: HTTP call to a named endpoint defined in
    /// `enrichConfig.endpoints`. Requires `endpointName`.</para>
    /// </summary>
    public ApiEnum<string, Source>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Number of top matching results to return per query (default: 1). Results
    /// are always returned as an array (list) and automatically sorted by cosine
    /// distance (best match = lowest distance first).
    ///
    /// <para>- 1: Returns array with single best match: `[{...}]` - &gt;1: Returns
    /// array with multiple matches: `[{...}, {...}, ...]`</para>
    /// </summary>
    public long? TopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("topK");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("topK", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SourceField;
        _ = this.TargetField;
        _ = this.CollectionName;
        _ = this.EndpointName;
        _ = this.IncludeScore;
        _ = this.IncludeSubcollections;
        _ = this.ScoreThreshold;
        this.SearchMode?.Validate();
        this.Source?.Validate();
        _ = this.TopK;
    }

    public EnrichStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnrichStep(EnrichStep enrichStep)
        : base(enrichStep) { }
#pragma warning restore CS8618

    public EnrichStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnrichStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnrichStepFromRaw.FromRawUnchecked"/>
    public static EnrichStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnrichStepFromRaw : IFromRawJson<EnrichStep>
{
    /// <inheritdoc/>
    public EnrichStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EnrichStep.FromRawUnchecked(rawData);
}

/// <summary>
/// Search mode to use for enrichment (default: "semantic").
///
/// <para>**semantic**: Vector similarity search using dense embeddings. Best for
/// finding conceptually similar items. - Use for: Product descriptions, natural language
/// content - Example: "red sports car" matches "crimson convertible automobile"</para>
///
/// <para>**exact**: Exact keyword matching using PostgreSQL text search. Best for
/// exact identifiers. - Use for: SKU numbers, routing numbers, account IDs, exact
/// tags - Example: "SKU-12345" only matches items containing that exact text</para>
///
/// <para>**hybrid**: Combined search using 20% semantic + 80% sparse embeddings
/// (keyword-based). - Use for: Tags, categories, partial identifiers - Example:
/// Balances semantic meaning with exact keyword matching</para>
/// </summary>
[JsonConverter(typeof(SearchModeConverter))]
public enum SearchMode
{
    Semantic,
    Exact,
    Hybrid,
}

sealed class SearchModeConverter : JsonConverter<SearchMode>
{
    public override SearchMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "semantic" => SearchMode.Semantic,
            "exact" => SearchMode.Exact,
            "hybrid" => SearchMode.Hybrid,
            _ => (SearchMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SearchMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SearchMode.Semantic => "semantic",
                SearchMode.Exact => "exact",
                SearchMode.Hybrid => "hybrid",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Where to fetch enrichment data from (default: `"collection"`).
///
/// <para>- `"collection"`: Vector/keyword search against a BEM collection. Requires
/// `collectionName`. - `"endpoint"`: HTTP call to a named endpoint defined in `enrichConfig.endpoints`.
/// Requires `endpointName`.</para>
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Collection,
    Endpoint,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "collection" => Source.Collection,
            "endpoint" => Source.Endpoint,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Collection => "collection",
                Source.Endpoint => "endpoint",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
