using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions.Copy;

/// <summary>
/// Request to copy an existing function with a new name and optional customizations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FunctionCopyRequest, FunctionCopyRequestFromRaw>))]
public sealed record class FunctionCopyRequest : JsonModel
{
    /// <summary>
    /// Name of the function to copy from. Must be a valid existing function name.
    /// </summary>
    public required string SourceFunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceFunctionName");
        }
        init { this._rawData.Set("sourceFunctionName", value); }
    }

    /// <summary>
    /// Name for the new copied function. Must be unique within the target environment.
    /// </summary>
    public required string TargetFunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("targetFunctionName");
        }
        init { this._rawData.Set("targetFunctionName", value); }
    }

    /// <summary>
    /// Optional array of tags for the copied function. If not provided, defaults
    /// to the source function's tags.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional display name for the copied function. If not provided, defaults to
    /// the source function's display name with " (Copy)" appended.
    /// </summary>
    public string? TargetDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("targetDisplayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("targetDisplayName", value);
        }
    }

    /// <summary>
    /// Optional environment name to copy the function to. If not provided, the function
    /// will be copied within the same environment.
    /// </summary>
    public string? TargetEnvironment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("targetEnvironment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("targetEnvironment", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SourceFunctionName;
        _ = this.TargetFunctionName;
        _ = this.Tags;
        _ = this.TargetDisplayName;
        _ = this.TargetEnvironment;
    }

    public FunctionCopyRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionCopyRequest(FunctionCopyRequest functionCopyRequest)
        : base(functionCopyRequest) { }
#pragma warning restore CS8618

    public FunctionCopyRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionCopyRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionCopyRequestFromRaw.FromRawUnchecked"/>
    public static FunctionCopyRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionCopyRequestFromRaw : IFromRawJson<FunctionCopyRequest>
{
    /// <inheritdoc/>
    public FunctionCopyRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionCopyRequest.FromRawUnchecked(rawData);
}
