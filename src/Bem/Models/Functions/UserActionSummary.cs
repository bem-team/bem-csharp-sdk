using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<UserActionSummary, UserActionSummaryFromRaw>))]
public sealed record class UserActionSummary : JsonModel
{
    /// <summary>
    /// The date and time the action was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Unique identifier of the user action.
    /// </summary>
    public required string UserActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userActionID");
        }
        init { this._rawData.Set("userActionID", value); }
    }

    /// <summary>
    /// API key name. Present for API key-initiated actions.
    /// </summary>
    public string? ApiKeyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiKeyName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiKeyName", value);
        }
    }

    /// <summary>
    /// Email address. Present for email-initiated actions.
    /// </summary>
    public string? EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("emailAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("emailAddress", value);
        }
    }

    /// <summary>
    /// User's email address. Present for user-initiated actions.
    /// </summary>
    public string? UserEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userEmail", value);
        }
    }

    /// <summary>
    /// User's ID. Present for user-initiated actions.
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userID", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.UserActionID;
        _ = this.ApiKeyName;
        _ = this.EmailAddress;
        _ = this.UserEmail;
        _ = this.UserID;
    }

    public UserActionSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserActionSummary(UserActionSummary userActionSummary)
        : base(userActionSummary) { }
#pragma warning restore CS8618

    public UserActionSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserActionSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserActionSummaryFromRaw.FromRawUnchecked"/>
    public static UserActionSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserActionSummaryFromRaw : IFromRawJson<UserActionSummary>
{
    /// <inheritdoc/>
    public UserActionSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserActionSummary.FromRawUnchecked(rawData);
}
