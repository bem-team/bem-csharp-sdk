using System.Text.Json;
using Bem.Exceptions;
using Bem.Models.Collections.Items;
using Bem.Models.Functions;
using Calls = Bem.Models.Calls;
using Errors = Bem.Models.Errors;
using Events = Bem.Models.Events;
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
            new ApiEnumConverter<string, DestinationType>(),
            new ApiEnumConverter<string, SplitType>(),
            new ApiEnumConverter<string, JoinType>(),
            new ApiEnumConverter<string, SearchMode>(),
            new ApiEnumConverter<string, FunctionSendDestinationType>(),
            new ApiEnumConverter<string, FunctionSplitSplitType>(),
            new ApiEnumConverter<string, FunctionJoinJoinType>(),
            new ApiEnumConverter<string, FunctionType>(),
            new ApiEnumConverter<string, UpdateFunctionSendDestinationType>(),
            new ApiEnumConverter<string, UpdateFunctionSplitSplitType>(),
            new ApiEnumConverter<string, UpdateFunctionJoinJoinType>(),
            new ApiEnumConverter<string, SortOrder>(),
            new ApiEnumConverter<string, Versions::DestinationType>(),
            new ApiEnumConverter<string, Versions::SplitType>(),
            new ApiEnumConverter<string, Versions::JoinType>(),
            new ApiEnumConverter<string, Calls::EventType>(),
            new ApiEnumConverter<string, Calls::InputType>(),
            new ApiEnumConverter<string, Calls::ExtractEventType>(),
            new ApiEnumConverter<string, Calls::ExtractInputType>(),
            new ApiEnumConverter<string, Calls::RouteEventType>(),
            new ApiEnumConverter<string, Calls::ClassifyEventType>(),
            new ApiEnumConverter<string, Calls::OutputType>(),
            new ApiEnumConverter<string, Calls::SplitCollectionEventType>(),
            new ApiEnumConverter<string, Calls::SplitItemOutputType>(),
            new ApiEnumConverter<string, Calls::SplitItemEventType>(),
            new ApiEnumConverter<string, Calls::JoinType>(),
            new ApiEnumConverter<string, Calls::JoinEventType>(),
            new ApiEnumConverter<string, Calls::EnrichEventType>(),
            new ApiEnumConverter<string, Calls::Operation>(),
            new ApiEnumConverter<string, Calls::CollectionProcessingStatus>(),
            new ApiEnumConverter<string, Calls::CollectionProcessingEventType>(),
            new ApiEnumConverter<string, Calls::DeliveryStatus>(),
            new ApiEnumConverter<string, Calls::DestinationType>(),
            new ApiEnumConverter<string, Calls::SendEventType>(),
            new ApiEnumConverter<string, Calls::CallStatus>(),
            new ApiEnumConverter<string, Calls::FunctionCallStatus>(),
            new ApiEnumConverter<string, Calls::ActivityStatus>(),
            new ApiEnumConverter<string, Calls::SortOrder>(),
            new ApiEnumConverter<string, Calls::Status>(),
            new ApiEnumConverter<string, Errors::EventType>(),
            new ApiEnumConverter<string, Errors::SortOrder>(),
            new ApiEnumConverter<string, Outputs::EventType>(),
            new ApiEnumConverter<string, Outputs::InputType>(),
            new ApiEnumConverter<string, Outputs::ExtractEventType>(),
            new ApiEnumConverter<string, Outputs::ExtractInputType>(),
            new ApiEnumConverter<string, Outputs::RouteEventType>(),
            new ApiEnumConverter<string, Outputs::ClassifyEventType>(),
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
            new ApiEnumConverter<string, Outputs::OutputListResponseTransformEventType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseTransformInputType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseExtractEventType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseExtractInputType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseRouteEventType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseClassifyEventType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseSplitCollectionOutputType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseSplitCollectionEventType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseSplitItemOutputType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseSplitItemEventType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseJoinJoinType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseJoinEventType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseEnrichEventType>(),
            new ApiEnumConverter<
                string,
                Outputs::OutputListResponseCollectionProcessingOperation
            >(),
            new ApiEnumConverter<string, Outputs::OutputListResponseCollectionProcessingStatus>(),
            new ApiEnumConverter<
                string,
                Outputs::OutputListResponseCollectionProcessingEventType
            >(),
            new ApiEnumConverter<string, Outputs::OutputListResponseSendDeliveryStatus>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseSendDestinationType>(),
            new ApiEnumConverter<string, Outputs::OutputListResponseSendEventType>(),
            new ApiEnumConverter<string, Outputs::SortOrder>(),
            new ApiEnumConverter<string, Workflows::WorkflowConnectorType>(),
            new ApiEnumConverter<string, Workflows::Operation>(),
            new ApiEnumConverter<string, Workflows::Type>(),
            new ApiEnumConverter<string, Workflows::WorkflowUpdateParamsConnectorType>(),
            new ApiEnumConverter<string, Workflows::SortOrder>(),
            new ApiEnumConverter<string, Workflows::InputType>(),
            new ApiEnumConverter<string, Workflows::SingleFileInputType>(),
            new ApiEnumConverter<string, WorkflowsVersions::SortOrder>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, ItemAddResponseStatus>(),
            new ApiEnumConverter<string, Events::FunctionType>(),
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
