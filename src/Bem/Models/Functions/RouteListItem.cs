using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<RouteListItem, RouteListItemFromRaw>))]
public sealed record class RouteListItem : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? FunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionID", value);
        }
    }

    public string? FunctionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("functionName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionName", value);
        }
    }

    public bool? IsErrorFallback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isErrorFallback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isErrorFallback", value);
        }
    }

    public Origin? Origin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Origin>("origin");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("origin", value);
        }
    }

    public Regex? Regex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Regex>("regex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("regex", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.IsErrorFallback;
        this.Origin?.Validate();
        this.Regex?.Validate();
    }

    public RouteListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RouteListItem(RouteListItem routeListItem)
        : base(routeListItem) { }
#pragma warning restore CS8618

    public RouteListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RouteListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RouteListItemFromRaw.FromRawUnchecked"/>
    public static RouteListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RouteListItem(string name)
        : this()
    {
        this.Name = name;
    }
}

class RouteListItemFromRaw : IFromRawJson<RouteListItem>
{
    /// <inheritdoc/>
    public RouteListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RouteListItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Origin, OriginFromRaw>))]
public sealed record class Origin : JsonModel
{
    public Email? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Email>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Email?.Validate();
    }

    public Origin() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Origin(Origin origin)
        : base(origin) { }
#pragma warning restore CS8618

    public Origin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Origin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginFromRaw.FromRawUnchecked"/>
    public static Origin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginFromRaw : IFromRawJson<Origin>
{
    /// <inheritdoc/>
    public Origin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Origin.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Email, EmailFromRaw>))]
public sealed record class Email : JsonModel
{
    public IReadOnlyList<string>? Patterns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("patterns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "patterns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Patterns;
    }

    public Email() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Email(Email email)
        : base(email) { }
#pragma warning restore CS8618

    public Email(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Email(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailFromRaw.FromRawUnchecked"/>
    public static Email FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailFromRaw : IFromRawJson<Email>
{
    /// <inheritdoc/>
    public Email FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Email.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Regex, RegexFromRaw>))]
public sealed record class Regex : JsonModel
{
    public IReadOnlyList<string>? Patterns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("patterns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "patterns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Patterns;
    }

    public Regex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Regex(Regex regex)
        : base(regex) { }
#pragma warning restore CS8618

    public Regex(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Regex(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegexFromRaw.FromRawUnchecked"/>
    public static Regex FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegexFromRaw : IFromRawJson<Regex>
{
    /// <inheritdoc/>
    public Regex FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Regex.FromRawUnchecked(rawData);
}
