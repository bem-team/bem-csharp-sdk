using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Exceptions;

namespace Bem.Models.Eval.Score;

/// <summary>
/// Comparator configuration. All fields optional; conservative defaults.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EvalMatchConfig, EvalMatchConfigFromRaw>))]
public sealed record class EvalMatchConfig : JsonModel
{
    /// <summary>
    /// P0 supports only `by-index`.
    /// </summary>
    public ApiEnum<string, ArrayMatch>? ArrayMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ArrayMatch>>("arrayMatch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("arrayMatch", value);
        }
    }

    /// <summary>
    /// Levenshtein-ratio threshold used when `stringMatch == "fuzzy"`. Range `[0,
    /// 1]`. Default `0.85`.
    /// </summary>
    public double? FuzzyThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fuzzyThreshold");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fuzzyThreshold", value);
        }
    }

    /// <summary>
    /// JSON Pointer paths to skip during comparison. The asterisk character matches
    /// arbitrary object keys / array indices.
    ///
    /// <para>Example values: /metadata, /lineItems with asterisk segment, etc.</para>
    /// </summary>
    public IReadOnlyList<string>? IgnorePaths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("ignorePaths");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "ignorePaths",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Relative tolerance for numeric fields. `0` (default) means exact equality;
    /// `0.01` means ±1%.
    /// </summary>
    public double? NumericTolerance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("numericTolerance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numericTolerance", value);
        }
    }

    /// <summary>
    /// `exact` (default) or `fuzzy`.
    /// </summary>
    public ApiEnum<string, StringMatch>? StringMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StringMatch>>("stringMatch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stringMatch", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ArrayMatch?.Validate();
        _ = this.FuzzyThreshold;
        _ = this.IgnorePaths;
        _ = this.NumericTolerance;
        this.StringMatch?.Validate();
    }

    public EvalMatchConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EvalMatchConfig(EvalMatchConfig evalMatchConfig)
        : base(evalMatchConfig) { }
#pragma warning restore CS8618

    public EvalMatchConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EvalMatchConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EvalMatchConfigFromRaw.FromRawUnchecked"/>
    public static EvalMatchConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EvalMatchConfigFromRaw : IFromRawJson<EvalMatchConfig>
{
    /// <inheritdoc/>
    public EvalMatchConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EvalMatchConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// P0 supports only `by-index`.
/// </summary>
[JsonConverter(typeof(ArrayMatchConverter))]
public enum ArrayMatch
{
    ByIndex,
}

sealed class ArrayMatchConverter : JsonConverter<ArrayMatch>
{
    public override ArrayMatch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "by-index" => ArrayMatch.ByIndex,
            _ => (ArrayMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ArrayMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ArrayMatch.ByIndex => "by-index",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// `exact` (default) or `fuzzy`.
/// </summary>
[JsonConverter(typeof(StringMatchConverter))]
public enum StringMatch
{
    Exact,
    Fuzzy,
}

sealed class StringMatchConverter : JsonConverter<StringMatch>
{
    public override StringMatch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "exact" => StringMatch.Exact,
            "fuzzy" => StringMatch.Fuzzy,
            _ => (StringMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StringMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StringMatch.Exact => "exact",
                StringMatch.Fuzzy => "fuzzy",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
