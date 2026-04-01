using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;

namespace Bem.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<FunctionAudit, FunctionAuditFromRaw>))]
public sealed record class FunctionAudit : JsonModel
{
    /// <summary>
    /// Information about who created the function.
    /// </summary>
    public UserActionSummary? FunctionCreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserActionSummary>("functionCreatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionCreatedBy", value);
        }
    }

    /// <summary>
    /// Information about who last updated the function.
    /// </summary>
    public UserActionSummary? FunctionLastUpdatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserActionSummary>("functionLastUpdatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("functionLastUpdatedBy", value);
        }
    }

    /// <summary>
    /// Information about who created the current version.
    /// </summary>
    public UserActionSummary? VersionCreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserActionSummary>("versionCreatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("versionCreatedBy", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FunctionCreatedBy?.Validate();
        this.FunctionLastUpdatedBy?.Validate();
        this.VersionCreatedBy?.Validate();
    }

    public FunctionAudit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionAudit(FunctionAudit functionAudit)
        : base(functionAudit) { }
#pragma warning restore CS8618

    public FunctionAudit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionAudit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionAuditFromRaw.FromRawUnchecked"/>
    public static FunctionAudit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionAuditFromRaw : IFromRawJson<FunctionAudit>
{
    /// <inheritdoc/>
    public FunctionAudit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionAudit.FromRawUnchecked(rawData);
}
