using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Functions;

/// <summary>
/// Configuration for an enrich function.
///
/// <para>**How Enrich Functions Work:**</para>
///
/// <para>Enrich functions augment JSON input with data from external sources. They
/// take JSON input (typically from a previous function), extract specified fields,
/// fetch or search for matching data, and inject the results back into the JSON.</para>
///
/// <para>**Data Sources:** - **Collections** (`source: "collection"`): Vector/keyword
/// search against a BEM collection. Best for semantic matching against pre-indexed
/// documents. - **Endpoints** (`source: "endpoint"`): HTTP call to any user-provided
/// REST API. Best for looking up live data from CRMs, ERPs, or other external systems.
/// Optionally uses LLM agent reasoning to rank candidates returned by the endpoint.</para>
///
/// <para>**Input Requirements:** - Must receive JSON input (typically from a previous
/// function's output)</para>
///
/// <para>**Example Use Cases:** - Match product descriptions to SKU codes from a
/// product catalog collection - Enrich customer data with account details from a
/// CRM endpoint - Use LLM agent reasoning to fuzzy-match line item descriptions
/// to catalog products</para>
///
/// <para>**Configuration:** - Define named endpoints (for endpoint-source steps)
/// - Define one or more enrichment steps; steps are executed sequentially</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EnrichConfig, EnrichConfigFromRaw>))]
public sealed record class EnrichConfig : JsonModel
{
    /// <summary>
    /// Array of enrichment steps to execute sequentially.
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

    /// <summary>
    /// Named HTTP endpoints available to endpoint-source steps. Each endpoint must
    /// have a unique `name` referenced by the step's `endpointName`. Required when
    /// any step uses `source: "endpoint"`.
    /// </summary>
    public IReadOnlyList<Endpoint>? Endpoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Endpoint>>("endpoints");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Endpoint>?>(
                "endpoints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
        foreach (var item in this.Endpoints ?? [])
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

/// <summary>
/// A named HTTP endpoint that an enrich step can call to fetch enrichment data.
///
/// <para>The platform makes one request per extracted source value, substituting
/// the value as a query parameter or body template placeholder. The raw response
/// (or the sub-value selected by `responsePath`) is injected into the output, or
/// passed to LLM agent reasoning when `matchInstructions` is set.</para>
///
/// <para>**Request formats:** - `GET`: Appends `?{queryParam}={value}` to the URL.
/// - `POST`: Sends `bodyTemplate` as the request body, replacing `{value}` with
/// the extracted value.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Endpoint, EndpointFromRaw>))]
public sealed record class Endpoint : JsonModel
{
    /// <summary>
    /// HTTP method to use.
    /// </summary>
    public required ApiEnum<string, Method> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Method>>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// Unique name for this endpoint, referenced by enrichStep.endpointName.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Full URL of the endpoint (must be http:// or https://).
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// JSON body template for POST requests. **Required for POST endpoints.** Must
    /// contain the `{value}` placeholder, which is replaced with the extracted source
    /// value at runtime.
    ///
    /// <para>Example: `bodyTemplate: "{\"query\": \"{value}\", \"limit\": 10}"`</para>
    /// </summary>
    public string? BodyTemplate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bodyTemplate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bodyTemplate", value);
        }
    }

    /// <summary>
    /// Additional HTTP headers to include in every request (e.g. `Authorization:
    /// Bearer &lt;token&gt;`).
    /// </summary>
    public JsonElement? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("headers", value);
        }
    }

    /// <summary>
    /// Natural-language instructions for LLM agent reasoning.
    ///
    /// <para>When set, the candidates fetched from the endpoint are passed to an
    /// LLM with these instructions, which selects the best match(es) and returns
    /// them with confidence scores. Each injected result has the shape `{ data, confidence,
    /// reasoning? }`.</para>
    ///
    /// <para>When omitted, the raw fetched value is injected without any LLM involvement.</para>
    /// </summary>
    public string? MatchInstructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("matchInstructions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("matchInstructions", value);
        }
    }

    /// <summary>
    /// Maximum number of ranked matches to return per source value when `matchInstructions`
    /// is set (default: 1). Ignored when `matchInstructions` is empty.
    /// </summary>
    public long? MatchTopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("matchTopK");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("matchTopK", value);
        }
    }

    /// <summary>
    /// LLM batch size during agent reasoning (default: 50). All candidates — across
    /// all fetched pages — are scored in batches of this size. Smaller values reduce
    /// per-call token usage; larger values mean fewer LLM calls. Ignored when `matchInstructions`
    /// is empty.
    /// </summary>
    public long? MaxCandidates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxCandidates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxCandidates", value);
        }
    }

    /// <summary>
    /// Maximum number of pages to fetch (default: 10). Acts as a safety cap against
    /// infinite pagination loops when the server never returns an empty cursor.
    /// </summary>
    public long? MaxPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxPages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxPages", value);
        }
    }

    /// <summary>
    /// Query parameter name used to pass the cursor on subsequent GET requests,
    /// or the `{placeholder}` name used in the POST `bodyTemplate` (e.g. `"cursor"`,
    /// `"pageToken"`, `"offset"`).
    ///
    /// <para>Must be set together with `nextPagePath`.</para>
    /// </summary>
    public string? NextPageParam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextPageParam");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextPageParam", value);
        }
    }

    /// <summary>
    /// JMESPath expression applied to each raw response to extract the cursor or
    /// token for the next page (e.g. `"nextCursor"`, `"pagination.nextToken"`).
    /// An absent, null, or empty-string result stops pagination. Both string and
    /// numeric values are supported — numbers are converted to their decimal string
    /// representation before being forwarded as a query parameter.
    ///
    /// <para>Must be set together with `nextPageParam`.</para>
    ///
    /// <para>**Supported pagination styles:** - **Cursor/token-based** — server returns
    /// an opaque token in the response body (e.g. `{"nextCursor": "abc123"}`). Set
    /// `nextPagePath: "nextCursor"` and the platform forwards it verbatim on the
    /// next request. - **Server-computed offset/page** — server echoes back the next
    /// offset or page number in the response body (e.g. `{"nextOffset": 50}` or
    /// `{"nextPage": 2}`). Set `nextPagePath: "nextOffset"` and the platform forwards
    /// the value as-is.</para>
    ///
    /// <para>**Not supported:** - **Client-computed offset** — APIs where the client
    /// must compute `offset += limit` itself (e.g. `?offset=0&amp;limit=50` with
    /// no next-offset in the response). Workaround: ask the API provider to return
    /// the next offset in the response body, or bake a fixed page size into the
    /// URL and use a server-side cursor instead. - **Client-computed page number**
    /// — APIs where the client increments `?page=N` itself with no next-page value
    /// in the response. Same workaround applies. - **Link header** — `Link: &lt;url&gt;;
    /// rel="next"` in HTTP response headers. The platform only inspects the response body.</para>
    /// </summary>
    public string? NextPagePath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextPagePath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextPagePath", value);
        }
    }

    /// <summary>
    /// Query parameter name used to pass the extracted source value. **Required for
    /// GET endpoints.** The value is URL-encoded and appended as `?{queryParam}={sourceValue}`.
    ///
    /// <para>Example: `queryParam: "q"` → `GET /products?q=blue+widget`</para>
    /// </summary>
    public string? QueryParam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("queryParam");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("queryParam", value);
        }
    }

    /// <summary>
    /// JMESPath expression applied to the response body to extract the enrichment
    /// value. Omit to use the entire response body as the result.
    ///
    /// <para>**For agent reasoning:** use a wildcard projection (e.g. `items[*]`
    /// or `results[*].data`) so the endpoint's list of candidates is flattened into
    /// an array before being passed to the LLM. A non-wildcard path (e.g. `data.product`)
    /// extracts a single value treated as one candidate.</para>
    ///
    /// <para>**Response size:** the platform reads at most 50 MB of the response
    /// body before decoding, regardless of the Content-Length header.</para>
    /// </summary>
    public string? ResponsePath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("responsePath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("responsePath", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.Name;
        _ = this.Url;
        _ = this.BodyTemplate;
        _ = this.Headers;
        _ = this.MatchInstructions;
        _ = this.MatchTopK;
        _ = this.MaxCandidates;
        _ = this.MaxPages;
        _ = this.NextPageParam;
        _ = this.NextPagePath;
        _ = this.QueryParam;
        _ = this.ResponsePath;
    }

    public Endpoint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Endpoint(Endpoint endpoint)
        : base(endpoint) { }
#pragma warning restore CS8618

    public Endpoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Endpoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EndpointFromRaw.FromRawUnchecked"/>
    public static Endpoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EndpointFromRaw : IFromRawJson<Endpoint>
{
    /// <inheritdoc/>
    public Endpoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Endpoint.FromRawUnchecked(rawData);
}

/// <summary>
/// HTTP method to use.
/// </summary>
[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    Get,
    Post,
}

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET" => Method.Get,
            "POST" => Method.Post,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.Get => "GET",
                Method.Post => "POST",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
