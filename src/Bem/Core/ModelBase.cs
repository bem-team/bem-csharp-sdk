using System.Text.Json;
using Bem.Exceptions;
using Bem.Models.Functions;
using Calls = Bem.Models.Calls;
using Errors = Bem.Models.Errors;
using Outputs = Bem.Models.Outputs;
using Versions = Bem.Models.Functions.Versions;
using Workflows = Bem.Models.Workflows;
using WorkflowsVersions = Bem.Models.Workflows.Versions;

namespace Bem.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, SearchMode>(),
            new ApiEnumConverter<string, FunctionSendDestinationType>(),
            new ApiEnumConverter<string, FunctionSplitSplitType>(),
            new ApiEnumConverter<string, FunctionJoinJoinType>(),
            new ApiEnumConverter<string, FunctionType>(),
            new ApiEnumConverter<string, FunctionListResponseSendDestinationType>(),
            new ApiEnumConverter<string, FunctionListResponseSplitSplitType>(),
            new ApiEnumConverter<string, FunctionListResponseJoinJoinType>(),
            new ApiEnumConverter<string, DestinationType>(),
            new ApiEnumConverter<string, SplitType>(),
            new ApiEnumConverter<string, JoinType>(),
            new ApiEnumConverter<string, FunctionUpdateParamsBodySendDestinationType>(),
            new ApiEnumConverter<string, FunctionUpdateParamsBodySplitSplitType>(),
            new ApiEnumConverter<string, FunctionUpdateParamsBodyJoinJoinType>(),
            new ApiEnumConverter<string, SortOrder>(),
            new ApiEnumConverter<string, Versions::DestinationType>(),
            new ApiEnumConverter<string, Versions::SplitType>(),
            new ApiEnumConverter<string, Versions::JoinType>(),
            new ApiEnumConverter<string, Versions::VersionSendDestinationType>(),
            new ApiEnumConverter<string, Versions::VersionSplitSplitType>(),
            new ApiEnumConverter<string, Versions::VersionJoinJoinType>(),
            new ApiEnumConverter<string, Calls::CallStatus>(),
            new ApiEnumConverter<string, Calls::SortOrder>(),
            new ApiEnumConverter<string, Calls::Status>(),
            new ApiEnumConverter<string, Errors::EventType>(),
            new ApiEnumConverter<string, Errors::SortOrder>(),
            new ApiEnumConverter<string, Outputs::EventType>(),
            new ApiEnumConverter<string, Outputs::InputType>(),
            new ApiEnumConverter<string, Outputs::RouteEventType>(),
            new ApiEnumConverter<string, Outputs::OutputType>(),
            new ApiEnumConverter<string, Outputs::SplitCollectionEventType>(),
            new ApiEnumConverter<string, Outputs::SplitItemOutputType>(),
            new ApiEnumConverter<string, Outputs::SplitItemEventType>(),
            new ApiEnumConverter<string, Outputs::JoinType>(),
            new ApiEnumConverter<string, Outputs::JoinEventType>(),
            new ApiEnumConverter<string, Outputs::EnrichEventType>(),
            new ApiEnumConverter<string, Outputs::Operation>(),
            new ApiEnumConverter<string, Outputs::Status>(),
            new ApiEnumConverter<string, Outputs::CollectionProcessingEventType>(),
            new ApiEnumConverter<string, Outputs::DeliveryStatus>(),
            new ApiEnumConverter<string, Outputs::DestinationType>(),
            new ApiEnumConverter<string, Outputs::SendEventType>(),
            new ApiEnumConverter<string, Outputs::SortOrder>(),
            new ApiEnumConverter<string, Workflows::WorkflowConnectorType>(),
            new ApiEnumConverter<string, Workflows::Operation>(),
            new ApiEnumConverter<
                string,
                Workflows::WorkflowUpdateResponseConnectorErrorOperation
            >(),
            new ApiEnumConverter<string, Workflows::Type>(),
            new ApiEnumConverter<string, Workflows::WorkflowUpdateParamsConnectorType>(),
            new ApiEnumConverter<string, Workflows::SortOrder>(),
            new ApiEnumConverter<string, Workflows::InputType>(),
            new ApiEnumConverter<string, Workflows::SingleFileInputType>(),
            new ApiEnumConverter<string, WorkflowsVersions::SortOrder>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="BemInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
