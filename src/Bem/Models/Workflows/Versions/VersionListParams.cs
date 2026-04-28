using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;
using System = System;

namespace Bem.Models.Workflows.Versions;

/// <summary>
/// **List every version of a workflow.**
///
/// <para>Versions are immutable. Each row captures what the workflow looked like
/// between updates: graph topology, metadata, and timestamps. Returns newest-first
/// by default. Cursor pagination via `startingAfter` / `endingBefore` over `versionNum`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VersionListParams : ParamsBase
{
    public string? WorkflowName { get; init; }

    public long? EndingBefore
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("endingBefore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("endingBefore", value);
        }
    }

    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public ApiEnum<string, SortOrder>? SortOrder
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortOrder>>("sortOrder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sortOrder", value);
        }
    }

    public long? StartingAfter
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("startingAfter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("startingAfter", value);
        }
    }

    public VersionListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionListParams(VersionListParams versionListParams)
        : base(versionListParams)
    {
        this.WorkflowName = versionListParams.WorkflowName;
    }
#pragma warning restore CS8618

    public VersionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string workflowName
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.WorkflowName = workflowName;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VersionListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string workflowName
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            workflowName
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WorkflowName"] = JsonSerializer.SerializeToElement(this.WorkflowName),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(VersionListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.WorkflowName?.Equals(other.WorkflowName) ?? other.WorkflowName == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/workflows/{0}/versions", this.WorkflowName)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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

[JsonConverter(typeof(SortOrderConverter))]
public enum SortOrder
{
    Asc,
    Desc,
}

sealed class SortOrderConverter : JsonConverter<SortOrder>
{
    public override SortOrder Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => SortOrder.Asc,
            "desc" => SortOrder.Desc,
            _ => (SortOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SortOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortOrder.Asc => "asc",
                SortOrder.Desc => "desc",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
