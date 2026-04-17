using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.InferSchema;

/// <summary>
/// Response from the infer-schema endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InferSchemaCreateResponse, InferSchemaCreateResponseFromRaw>)
)]
public sealed record class InferSchemaCreateResponse : JsonModel
{
    /// <summary>
    /// Analysis result returned by the infer-schema endpoint.
    /// </summary>
    public required Analysis Analysis
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Analysis>("analysis");
        }
        init { this._rawData.Set("analysis", value); }
    }

    /// <summary>
    /// Original filename of the uploaded file.
    /// </summary>
    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Analysis.Validate();
        _ = this.Filename;
    }

    public InferSchemaCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InferSchemaCreateResponse(InferSchemaCreateResponse inferSchemaCreateResponse)
        : base(inferSchemaCreateResponse) { }
#pragma warning restore CS8618

    public InferSchemaCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InferSchemaCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InferSchemaCreateResponseFromRaw.FromRawUnchecked"/>
    public static InferSchemaCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InferSchemaCreateResponseFromRaw : IFromRawJson<InferSchemaCreateResponse>
{
    /// <inheritdoc/>
    public InferSchemaCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InferSchemaCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Analysis result returned by the infer-schema endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Analysis, AnalysisFromRaw>))]
public sealed record class Analysis : JsonModel
{
    /// <summary>
    /// Classification of the primary content. One of: `textual`, `visual`, `audio`,
    /// `video`, `mixed`.
    /// </summary>
    public required string ContentNature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contentNature");
        }
        init { this._rawData.Set("contentNature", value); }
    }

    /// <summary>
    /// MIME content type of the uploaded file.
    /// </summary>
    public required string ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contentType");
        }
        init { this._rawData.Set("contentType", value); }
    }

    /// <summary>
    /// 2-3 sentence description of what the file contains.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// List of distinct document types found in the file with counts.
    /// </summary>
    public required IReadOnlyList<DocumentType> DocumentTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DocumentType>>("documentTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DocumentType>>(
                "documentTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Original filename of the uploaded file.
    /// </summary>
    public required string FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fileName");
        }
        init { this._rawData.Set("fileName", value); }
    }

    /// <summary>
    /// High-level file category (e.g. "document", "image", "spreadsheet", "email").
    /// </summary>
    public required string FileType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fileType");
        }
        init { this._rawData.Set("fileType", value); }
    }

    /// <summary>
    /// Whether the file contains multiple separate documents bundled together.
    /// </summary>
    public required bool IsMultiDocument
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isMultiDocument");
        }
        init { this._rawData.Set("isMultiDocument", value); }
    }

    /// <summary>
    /// Size of the uploaded file in bytes.
    /// </summary>
    public required long SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sizeBytes");
        }
        init { this._rawData.Set("sizeBytes", value); }
    }

    /// <summary>
    /// Inferred JSON Schema representing all extractable data fields.
    /// </summary>
    public JsonElement? Schema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("schema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("schema", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ContentNature;
        _ = this.ContentType;
        _ = this.Description;
        foreach (var item in this.DocumentTypes)
        {
            item.Validate();
        }
        _ = this.FileName;
        _ = this.FileType;
        _ = this.IsMultiDocument;
        _ = this.SizeBytes;
        _ = this.Schema;
    }

    public Analysis() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Analysis(Analysis analysis)
        : base(analysis) { }
#pragma warning restore CS8618

    public Analysis(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Analysis(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisFromRaw.FromRawUnchecked"/>
    public static Analysis FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisFromRaw : IFromRawJson<Analysis>
{
    /// <inheritdoc/>
    public Analysis FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Analysis.FromRawUnchecked(rawData);
}

/// <summary>
/// Describes a distinct document type found in the file.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DocumentType, DocumentTypeFromRaw>))]
public sealed record class DocumentType : JsonModel
{
    /// <summary>
    /// Number of instances of this document type in the file.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Brief description of this document type.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Short snake_case name (e.g. "invoice", "receipt", "utility_bill").
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Description;
        _ = this.Name;
    }

    public DocumentType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentType(DocumentType documentType)
        : base(documentType) { }
#pragma warning restore CS8618

    public DocumentType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentTypeFromRaw.FromRawUnchecked"/>
    public static DocumentType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentTypeFromRaw : IFromRawJson<DocumentType>
{
    /// <inheritdoc/>
    public DocumentType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DocumentType.FromRawUnchecked(rawData);
}
