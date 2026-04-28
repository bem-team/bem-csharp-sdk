using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Bem.Core;

namespace Bem.Models.Functions;

/// <summary>
/// **Update a function. Updates create a new version.**
///
/// <para>The previous version remains addressable and immutable. Workflow nodes that
/// pinned the function with a `versionNum` continue to use the pinned version; nodes
/// that reference the function by name with no version automatically pick up the
/// new version on their next call.</para>
///
/// <para>## What you can change</para>
///
/// <para>Any field allowed by the function's type. Most commonly: `outputSchema`
/// (for `extract`/`join`), `classifications` (for `classify`), `displayName`, and `tags`.</para>
///
/// <para>## Versioning behaviour</para>
///
/// <para>- Each successful update increments `currentVersionNum` by 1. - `displayName`,
/// `tags`, and `functionName` updates also create a new version, so the version
/// history is a complete record of every change. - To revert, fetch the previous
/// version and re-submit its configuration as a new update — versions themselves
/// are immutable.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FunctionUpdateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? PathFunctionName { get; init; }

    /// <summary>
    /// V3 create/update variants of the shared function payloads.
    ///
    /// <para>The V3 Functions API no longer accepts the legacy `transform` or `analyze`
    /// function types when creating new functions or updating existing ones — both
    /// have been unified under `extract`. Existing functions of those types remain
    /// readable and callable via V3, so the V3 read-side unions still include `transform`
    /// and `analyze` variants.</para>
    ///
    /// <para>The V3 API also exposes `classify` in place of the legacy `route` type
    /// on create/update, with `classifications` in place of `routes`. Read-side
    /// `ClassifyFunction` / `ClassifyFunctionVersion` / `ClassificationList` are
    /// defined in the shared functions models and used by both the V2 and V3 response
    /// unions (existing classify functions are returned from V2 GET endpoints verbatim).V3
    /// wire form of the classify function upsert payload.</para>
    /// </summary>
    public required UpdateFunction UpdateFunction
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClass<UpdateFunction>(
                this.RawBodyData,
                "RawBodyData"
            );
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public FunctionUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateParams(FunctionUpdateParams functionUpdateParams)
        : base(functionUpdateParams)
    {
        this.PathFunctionName = functionUpdateParams.PathFunctionName;

        this.RawBodyData = functionUpdateParams.RawBodyData;
    }
#pragma warning restore CS8618

    public FunctionUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string pathFunctionName
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.PathFunctionName = pathFunctionName;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FunctionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string pathFunctionName
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            pathFunctionName
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PathFunctionName"] = JsonSerializer.SerializeToElement(this.PathFunctionName),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FunctionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.PathFunctionName?.Equals(other.PathFunctionName)
                ?? other.PathFunctionName == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/functions/{0}", this.PathFunctionName)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
