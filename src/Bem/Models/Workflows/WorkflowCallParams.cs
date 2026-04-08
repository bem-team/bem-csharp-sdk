using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Workflows;

/// <summary>
/// **Invoke a workflow.**
///
/// <para>Submit the input file as either a multipart form request or a JSON request
/// with base64-encoded file content. The workflow name is derived from the URL path.</para>
///
/// <para>## Input Formats</para>
///
/// <para>- **Multipart form** (`multipart/form-data`): attach the file directly
/// via the `file` or `files` fields. Set `wait` in the form body to control synchronous
/// behaviour. - **JSON** (`application/json`): base64-encode the file content and
/// set it in `input.singleFile.inputContent` or `input.batchFiles.inputs[*].inputContent`.
/// Pass `wait=true` as a query parameter to control synchronous behaviour.</para>
///
/// <para>## Synchronous vs Asynchronous</para>
///
/// <para>By default the call is created asynchronously and this endpoint returns
/// `202 Accepted` immediately with a `pending` call object. Set `wait` to `true`
/// to block until the call completes (up to 30 seconds):</para>
///
/// <para>- On success: returns `200 OK` with the completed call, `outputs` populated
/// - On failure: returns `500 Internal Server Error` with the call and an `error`
/// message - On timeout: returns `202 Accepted` with the still-running call</para>
///
/// <para>## Tracking</para>
///
/// <para>Poll `GET /v3/calls/{callID}` to check status, or configure a webhook subscription
/// to receive events when the call finishes.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkflowCallParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? WorkflowName { get; init; }

    /// <summary>
    /// Input to the workflow call. Provide exactly one of `singleFile` or `batchFiles`.
    /// </summary>
    public required Input Input
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Input>("input");
        }
        init { this._rawBodyData.Set("input", value); }
    }

    /// <summary>
    /// When `true`, the endpoint blocks until the call completes (up to 30 seconds)
    /// and returns the finished call object. Default: `false`.
    /// </summary>
    public bool? Wait
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("wait");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("wait", value);
        }
    }

    /// <summary>
    /// Your reference ID for tracking this call.
    /// </summary>
    public string? CallReferenceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("callReferenceID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("callReferenceID", value);
        }
    }

    public WorkflowCallParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkflowCallParams(WorkflowCallParams workflowCallParams)
        : base(workflowCallParams)
    {
        this.WorkflowName = workflowCallParams.WorkflowName;

        this._rawBodyData = new(workflowCallParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WorkflowCallParams(
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
    WorkflowCallParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData,
        string workflowName
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.WorkflowName = workflowName;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WorkflowCallParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData,
        string workflowName
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            workflowName
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, MultipartJsonElement>()
                {
                    ["WorkflowName"] = JsonSerializer.SerializeToElement(this.WorkflowName),
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

    public virtual bool Equals(WorkflowCallParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.WorkflowName?.Equals(other.WorkflowName) ?? other.WorkflowName == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/workflows/{0}/call", this.WorkflowName)
        )
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

/// <summary>
/// Input to the workflow call. Provide exactly one of `singleFile` or `batchFiles`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Input, InputFromRaw>))]
public sealed record class Input : JsonModel
{
    public BatchFiles? BatchFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchFiles>("batchFiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("batchFiles", value);
        }
    }

    public SingleFile? SingleFile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SingleFile>("singleFile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("singleFile", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BatchFiles?.Validate();
        this.SingleFile?.Validate();
    }

    public Input() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Input(Input input)
        : base(input) { }
#pragma warning restore CS8618

    public Input(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Input(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InputFromRaw.FromRawUnchecked"/>
    public static Input FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputFromRaw : IFromRawJson<Input>
{
    /// <inheritdoc/>
    public Input FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Input.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BatchFiles, BatchFilesFromRaw>))]
public sealed record class BatchFiles : JsonModel
{
    public IReadOnlyList<BatchFilesInput>? Inputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BatchFilesInput>>("inputs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BatchFilesInput>?>(
                "inputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Inputs ?? [])
        {
            item.Validate();
        }
    }

    public BatchFiles() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchFiles(BatchFiles batchFiles)
        : base(batchFiles) { }
#pragma warning restore CS8618

    public BatchFiles(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchFiles(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchFilesFromRaw.FromRawUnchecked"/>
    public static BatchFiles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchFilesFromRaw : IFromRawJson<BatchFiles>
{
    /// <inheritdoc/>
    public BatchFiles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchFiles.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BatchFilesInput, BatchFilesInputFromRaw>))]
public sealed record class BatchFilesInput : JsonModel
{
    /// <summary>
    /// Base64-encoded file content
    /// </summary>
    public required string InputContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inputContent");
        }
        init { this._rawData.Set("inputContent", value); }
    }

    /// <summary>
    /// The input type of the content you're sending for transformation.
    /// </summary>
    public required ApiEnum<string, InputType> InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InputType>>("inputType");
        }
        init { this._rawData.Set("inputType", value); }
    }

    public string? ItemReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("itemReferenceID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("itemReferenceID", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputContent;
        this.InputType.Validate();
        _ = this.ItemReferenceID;
    }

    public BatchFilesInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchFilesInput(BatchFilesInput batchFilesInput)
        : base(batchFilesInput) { }
#pragma warning restore CS8618

    public BatchFilesInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchFilesInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchFilesInputFromRaw.FromRawUnchecked"/>
    public static BatchFilesInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchFilesInputFromRaw : IFromRawJson<BatchFilesInput>
{
    /// <inheritdoc/>
    public BatchFilesInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchFilesInput.FromRawUnchecked(rawData);
}

/// <summary>
/// The input type of the content you're sending for transformation.
/// </summary>
[JsonConverter(typeof(InputTypeConverter))]
public enum InputType
{
    Csv,
    Docx,
    Email,
    Heic,
    Html,
    Jpeg,
    Json,
    Heif,
    M4a,
    Mp3,
    Pdf,
    Png,
    Text,
    Wav,
    Webp,
    Xls,
    Xlsx,
    Xml,
}

sealed class InputTypeConverter : JsonConverter<InputType>
{
    public override InputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => InputType.Csv,
            "docx" => InputType.Docx,
            "email" => InputType.Email,
            "heic" => InputType.Heic,
            "html" => InputType.Html,
            "jpeg" => InputType.Jpeg,
            "json" => InputType.Json,
            "heif" => InputType.Heif,
            "m4a" => InputType.M4a,
            "mp3" => InputType.Mp3,
            "pdf" => InputType.Pdf,
            "png" => InputType.Png,
            "text" => InputType.Text,
            "wav" => InputType.Wav,
            "webp" => InputType.Webp,
            "xls" => InputType.Xls,
            "xlsx" => InputType.Xlsx,
            "xml" => InputType.Xml,
            _ => (InputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InputType.Csv => "csv",
                InputType.Docx => "docx",
                InputType.Email => "email",
                InputType.Heic => "heic",
                InputType.Html => "html",
                InputType.Jpeg => "jpeg",
                InputType.Json => "json",
                InputType.Heif => "heif",
                InputType.M4a => "m4a",
                InputType.Mp3 => "mp3",
                InputType.Pdf => "pdf",
                InputType.Png => "png",
                InputType.Text => "text",
                InputType.Wav => "wav",
                InputType.Webp => "webp",
                InputType.Xls => "xls",
                InputType.Xlsx => "xlsx",
                InputType.Xml => "xml",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SingleFile, SingleFileFromRaw>))]
public sealed record class SingleFile : JsonModel
{
    /// <summary>
    /// Base64-encoded file content
    /// </summary>
    public required string InputContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inputContent");
        }
        init { this._rawData.Set("inputContent", value); }
    }

    /// <summary>
    /// The input type of the content you're sending for transformation.
    /// </summary>
    public required ApiEnum<string, SingleFileInputType> InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SingleFileInputType>>("inputType");
        }
        init { this._rawData.Set("inputType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputContent;
        this.InputType.Validate();
    }

    public SingleFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SingleFile(SingleFile singleFile)
        : base(singleFile) { }
#pragma warning restore CS8618

    public SingleFile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SingleFile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SingleFileFromRaw.FromRawUnchecked"/>
    public static SingleFile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SingleFileFromRaw : IFromRawJson<SingleFile>
{
    /// <inheritdoc/>
    public SingleFile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SingleFile.FromRawUnchecked(rawData);
}

/// <summary>
/// The input type of the content you're sending for transformation.
/// </summary>
[JsonConverter(typeof(SingleFileInputTypeConverter))]
public enum SingleFileInputType
{
    Csv,
    Docx,
    Email,
    Heic,
    Html,
    Jpeg,
    Json,
    Heif,
    M4a,
    Mp3,
    Pdf,
    Png,
    Text,
    Wav,
    Webp,
    Xls,
    Xlsx,
    Xml,
}

sealed class SingleFileInputTypeConverter : JsonConverter<SingleFileInputType>
{
    public override SingleFileInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => SingleFileInputType.Csv,
            "docx" => SingleFileInputType.Docx,
            "email" => SingleFileInputType.Email,
            "heic" => SingleFileInputType.Heic,
            "html" => SingleFileInputType.Html,
            "jpeg" => SingleFileInputType.Jpeg,
            "json" => SingleFileInputType.Json,
            "heif" => SingleFileInputType.Heif,
            "m4a" => SingleFileInputType.M4a,
            "mp3" => SingleFileInputType.Mp3,
            "pdf" => SingleFileInputType.Pdf,
            "png" => SingleFileInputType.Png,
            "text" => SingleFileInputType.Text,
            "wav" => SingleFileInputType.Wav,
            "webp" => SingleFileInputType.Webp,
            "xls" => SingleFileInputType.Xls,
            "xlsx" => SingleFileInputType.Xlsx,
            "xml" => SingleFileInputType.Xml,
            _ => (SingleFileInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SingleFileInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SingleFileInputType.Csv => "csv",
                SingleFileInputType.Docx => "docx",
                SingleFileInputType.Email => "email",
                SingleFileInputType.Heic => "heic",
                SingleFileInputType.Html => "html",
                SingleFileInputType.Jpeg => "jpeg",
                SingleFileInputType.Json => "json",
                SingleFileInputType.Heif => "heif",
                SingleFileInputType.M4a => "m4a",
                SingleFileInputType.Mp3 => "mp3",
                SingleFileInputType.Pdf => "pdf",
                SingleFileInputType.Png => "png",
                SingleFileInputType.Text => "text",
                SingleFileInputType.Wav => "wav",
                SingleFileInputType.Webp => "webp",
                SingleFileInputType.Xls => "xls",
                SingleFileInputType.Xlsx => "xlsx",
                SingleFileInputType.Xml => "xml",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
