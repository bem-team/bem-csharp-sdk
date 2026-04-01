using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Models.Workflows;

[JsonConverter(typeof(JsonModelConverter<Workflow, WorkflowFromRaw>))]
public sealed record class Workflow : JsonModel
{
    /// <summary>
    /// Unique identifier of workflow.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required FunctionVersionIdentifier MainFunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionVersionIdentifier>("mainFunction");
        }
        init { this._rawData.Set("mainFunction", value); }
    }

    /// <summary>
    /// Unique name of workflow. Must be UNIQUE on a per-environment basis.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Version number of workflow version.
    /// </summary>
    public required long VersionNum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNum");
        }
        init { this._rawData.Set("versionNum", value); }
    }

    /// <summary>
    /// Audit trail information for the workflow.
    /// </summary>
    public Audit? Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Audit>("audit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audit", value);
        }
    }

    /// <summary>
    /// The date and time the workflow was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Display name of workflow.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Email address of workflow.
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

    public IReadOnlyList<Relationship>? Relationships
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Relationship>>("relationships");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Relationship>?>(
                "relationships",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of tags to categorize and organize workflows.
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
    /// The date and time the workflow was last updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.MainFunction.Validate();
        _ = this.Name;
        _ = this.VersionNum;
        this.Audit?.Validate();
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.EmailAddress;
        foreach (var item in this.Relationships ?? [])
        {
            item.Validate();
        }
        _ = this.Tags;
        _ = this.UpdatedAt;
    }

    public Workflow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Workflow(Workflow workflow)
        : base(workflow) { }
#pragma warning restore CS8618

    public Workflow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Workflow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkflowFromRaw.FromRawUnchecked"/>
    public static Workflow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkflowFromRaw : IFromRawJson<Workflow>
{
    /// <inheritdoc/>
    public Workflow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Workflow.FromRawUnchecked(rawData);
}

/// <summary>
/// Audit trail information for the workflow.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Audit, AuditFromRaw>))]
public sealed record class Audit : JsonModel
{
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

    /// <summary>
    /// Information about who created the workflow.
    /// </summary>
    public UserActionSummary? WorkflowCreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserActionSummary>("workflowCreatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowCreatedBy", value);
        }
    }

    /// <summary>
    /// Information about who last updated the workflow.
    /// </summary>
    public UserActionSummary? WorkflowLastUpdatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserActionSummary>("workflowLastUpdatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowLastUpdatedBy", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.VersionCreatedBy?.Validate();
        this.WorkflowCreatedBy?.Validate();
        this.WorkflowLastUpdatedBy?.Validate();
    }

    public Audit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Audit(Audit audit)
        : base(audit) { }
#pragma warning restore CS8618

    public Audit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Audit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuditFromRaw.FromRawUnchecked"/>
    public static Audit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuditFromRaw : IFromRawJson<Audit>
{
    /// <inheritdoc/>
    public Audit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Audit.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Relationship, RelationshipFromRaw>))]
public sealed record class Relationship : JsonModel
{
    public required FunctionVersionIdentifier DestinationFunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionVersionIdentifier>("destinationFunction");
        }
        init { this._rawData.Set("destinationFunction", value); }
    }

    public required FunctionVersionIdentifier SourceFunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionVersionIdentifier>("sourceFunction");
        }
        init { this._rawData.Set("sourceFunction", value); }
    }

    /// <summary>
    /// Name of destination.
    /// </summary>
    public string? DestinationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destinationName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destinationName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DestinationFunction.Validate();
        this.SourceFunction.Validate();
        _ = this.DestinationName;
    }

    public Relationship() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Relationship(Relationship relationship)
        : base(relationship) { }
#pragma warning restore CS8618

    public Relationship(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Relationship(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RelationshipFromRaw.FromRawUnchecked"/>
    public static Relationship FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RelationshipFromRaw : IFromRawJson<Relationship>
{
    /// <inheritdoc/>
    public Relationship FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Relationship.FromRawUnchecked(rawData);
}
