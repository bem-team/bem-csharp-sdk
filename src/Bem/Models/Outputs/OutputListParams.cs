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

namespace Bem.Models.Outputs;

/// <summary>
/// **List terminal non-error output events.**
///
/// <para>Returns events that represent successful terminal outputs — primary events
/// (non-split-collection) that did not trigger any downstream function calls. Error
/// events are excluded; use `GET /v3/errors` to retrieve those.</para>
///
/// <para>## Intermediate Events</para>
///
/// <para>By default, intermediate events (those that spawned a downstream function
/// call in a multi-step workflow) are excluded. Pass `includeIntermediate=true` to
/// include them.</para>
///
/// <para>## Filtering</para>
///
/// <para>Filter by call, workflow, function, or reference ID. Multiple filters are
/// ANDed together.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OutputListParams : ParamsBase
{
    /// <summary>
    /// Filter to outputs from specific calls.
    /// </summary>
    public IReadOnlyList<string>? CallIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("callIDs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "callIDs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? EndingBefore
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("endingBefore");
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

    public IReadOnlyList<string>? FunctionIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("functionIDs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "functionIDs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? FunctionNames
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("functionNames");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "functionNames",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When `true`, includes intermediate events (those that spawned a downstream
    /// function call). Default: `false`.
    /// </summary>
    public bool? IncludeIntermediate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("includeIntermediate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("includeIntermediate", value);
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

    public IReadOnlyList<string>? ReferenceIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("referenceIDs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "referenceIDs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Case-insensitive substring match against `referenceID`.
    /// </summary>
    public string? ReferenceIDSubstring
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("referenceIDSubstring");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("referenceIDSubstring", value);
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

    public string? StartingAfter
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("startingAfter");
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

    public IReadOnlyList<string>? WorkflowIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("workflowIDs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "workflowIDs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? WorkflowNames
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("workflowNames");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "workflowNames",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public OutputListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputListParams(OutputListParams outputListParams)
        : base(outputListParams) { }
#pragma warning restore CS8618

    public OutputListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static OutputListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(OutputListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/outputs")
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
        Type typeToConvert,
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
