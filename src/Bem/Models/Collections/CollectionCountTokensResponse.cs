using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Collections;

/// <summary>
/// Response for the token count endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CollectionCountTokensResponse, CollectionCountTokensResponseFromRaw>)
)]
public sealed record class CollectionCountTokensResponse : JsonModel
{
    /// <summary>
    /// Maximum tokens allowed per text by the embedding model.
    /// </summary>
    public long? MaxTokenLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_token_limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_token_limit", value);
        }
    }

    /// <summary>
    /// Number of input texts that exceed `max_token_limit`.
    /// </summary>
    public long? TextsExceedingLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("texts_exceeding_limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("texts_exceeding_limit", value);
        }
    }

    /// <summary>
    /// Per-text tokenization results in the same order as the request.
    /// </summary>
    public IReadOnlyList<TokenCount>? TokenCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TokenCount>>("token_counts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TokenCount>?>(
                "token_counts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Sum of `token_count` across all texts.
    /// </summary>
    public long? TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxTokenLimit;
        _ = this.TextsExceedingLimit;
        foreach (var item in this.TokenCounts ?? [])
        {
            item.Validate();
        }
        _ = this.TotalTokens;
    }

    public CollectionCountTokensResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionCountTokensResponse(
        CollectionCountTokensResponse collectionCountTokensResponse
    )
        : base(collectionCountTokensResponse) { }
#pragma warning restore CS8618

    public CollectionCountTokensResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionCountTokensResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CollectionCountTokensResponseFromRaw.FromRawUnchecked"/>
    public static CollectionCountTokensResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CollectionCountTokensResponseFromRaw : IFromRawJson<CollectionCountTokensResponse>
{
    /// <inheritdoc/>
    public CollectionCountTokensResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CollectionCountTokensResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-text token count result.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TokenCount, TokenCountFromRaw>))]
public sealed record class TokenCount : JsonModel
{
    /// <summary>
    /// Character count of the input text.
    /// </summary>
    public long? CharCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("char_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("char_count", value);
        }
    }

    /// <summary>
    /// True if `token_count` exceeds the embedding model's per-text limit.
    /// </summary>
    public bool? ExceedsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("exceeds_limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exceeds_limit", value);
        }
    }

    /// <summary>
    /// Zero-based position of this entry in the request `texts` array.
    /// </summary>
    public long? Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("index", value);
        }
    }

    /// <summary>
    /// Number of tokens produced by the tokenizer.
    /// </summary>
    public long? TokenCountValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("token_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("token_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CharCount;
        _ = this.ExceedsLimit;
        _ = this.Index;
        _ = this.TokenCountValue;
    }

    public TokenCount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TokenCount(TokenCount tokenCount)
        : base(tokenCount) { }
#pragma warning restore CS8618

    public TokenCount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenCount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TokenCountFromRaw.FromRawUnchecked"/>
    public static TokenCount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TokenCountFromRaw : IFromRawJson<TokenCount>
{
    /// <inheritdoc/>
    public TokenCount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TokenCount.FromRawUnchecked(rawData);
}
