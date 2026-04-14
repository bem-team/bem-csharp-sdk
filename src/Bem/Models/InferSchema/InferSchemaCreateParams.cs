using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.InferSchema;

/// <summary>
/// **Analyze a file and infer a JSON Schema from its contents.**
///
/// <para>Accepts a file via multipart form upload and uses Gemini to analyze the
/// document, returning a description of its contents, an inferred JSON Schema capturing
/// all extractable fields, and document classification metadata.</para>
///
/// <para>The returned schema is designed to be reusable across many similar documents
/// of the same type, not just the specific file uploaded. It can be used directly
/// as the `outputSchema` when creating a Transform function.</para>
///
/// <para>The endpoint also detects whether the file contains multiple bundled documents
/// and classifies the content nature (textual, visual, audio, video, or mixed).</para>
///
/// <para>## Supported file types</para>
///
/// <para>PDF, PNG, JPEG, HEIC, HEIF, WebP, CSV, XLS, XLSX, DOCX, JSON, HTML, XML,
/// EML, plain text, WAV, MP3, M4A, MP4.</para>
///
/// <para>## File size limit</para>
///
/// <para>Maximum file size is **20 MB**.</para>
///
/// <para>## Examples</para>
///
/// <para>Using curl: ```bash curl -X POST https://api.bem.ai/v3/infer-schema \
///  -H "x-api-key: YOUR_API_KEY" \   -F "file=@invoice.pdf" ```</para>
///
/// <para>Using the Bem CLI: ```bash bem infer-schema create --file @invoice.pdf ```</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InferSchemaCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The file to analyze and infer a JSON schema from.
    /// </summary>
    public required JsonElement File
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<JsonElement>("file");
        }
        init { this._rawBodyData.Set("file", value); }
    }

    public InferSchemaCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InferSchemaCreateParams(InferSchemaCreateParams inferSchemaCreateParams)
        : base(inferSchemaCreateParams)
    {
        this._rawBodyData = new(inferSchemaCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InferSchemaCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InferSchemaCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InferSchemaCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, MultipartJsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InferSchemaCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/infer-schema")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
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
