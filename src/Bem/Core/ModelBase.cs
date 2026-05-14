using System.Text.Json;
using Bem.Exceptions;
using Bem.Models.Collections.Items;
using Bem.Models.Connectors;
using Bem.Models.Fs;
using Bem.Models.Functions;
using Calls = Bem.Models.Calls;
using Errors = Bem.Models.Errors;
using Events = Bem.Models.Events;
using Outputs = Bem.Models.Outputs;
using Subscriptions = Bem.Models.Subscriptions;
using Versions = Bem.Models.Functions.Versions;
using Views = Bem.Models.Views;
using Webhooks = Bem.Models.Webhooks;
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
            new ApiEnumConverter<string, SplitType>(),
            new ApiEnumConverter<string, JoinType>(),
            new ApiEnumConverter<string, SearchMode>(),
            new ApiEnumConverter<string, FunctionSplitSplitType>(),
            new ApiEnumConverter<string, FunctionJoinJoinType>(),
            new ApiEnumConverter<string, FunctionType>(),
            new ApiEnumConverter<string, SendDestinationType>(),
            new ApiEnumConverter<string, UpdateFunctionSplitSplitType>(),
            new ApiEnumConverter<string, UpdateFunctionJoinJoinType>(),
            new ApiEnumConverter<string, SortOrder>(),
            new ApiEnumConverter<string, ConfidenceMethod>(),
            new ApiEnumConverter<string, EvaluationVersion>(),
            new ApiEnumConverter<string, FunctionGetMetricsParamsSortOrder>(),
            new ApiEnumConverter<string, Versions::SplitType>(),
            new ApiEnumConverter<string, Versions::JoinType>(),
            new ApiEnumConverter<string, Calls::CallStatus>(),
            new ApiEnumConverter<string, Calls::FunctionCallStatus>(),
            new ApiEnumConverter<string, Calls::ActivityStatus>(),
            new ApiEnumConverter<string, Calls::SortOrder>(),
            new ApiEnumConverter<string, Calls::Status>(),
            new ApiEnumConverter<string, Errors::EventType>(),
            new ApiEnumConverter<string, Errors::SortOrder>(),
            new ApiEnumConverter<string, Outputs::EventType>(),
            new ApiEnumConverter<string, Outputs::ExtractEventType>(),
            new ApiEnumConverter<string, Outputs::ParseEventType>(),
            new ApiEnumConverter<string, Outputs::AnalyzeEventType>(),
            new ApiEnumConverter<string, Outputs::RouteEventType>(),
            new ApiEnumConverter<string, Outputs::ClassifyEventType>(),
            new ApiEnumConverter<string, Outputs::OutputType>(),
            new ApiEnumConverter<string, Outputs::SplitCollectionEventType>(),
            new ApiEnumConverter<string, Outputs::SplitItemOutputType>(),
            new ApiEnumConverter<string, Outputs::SplitItemEventType>(),
            new ApiEnumConverter<string, Outputs::JoinType>(),
            new ApiEnumConverter<string, Outputs::JoinEventType>(),
            new ApiEnumConverter<string, Outputs::EnrichEventType>(),
            new ApiEnumConverter<string, Outputs::PayloadShapingEventType>(),
            new ApiEnumConverter<string, Outputs::Status>(),
            new ApiEnumConverter<string, Outputs::EvaluationEventType>(),
            new ApiEnumConverter<string, Outputs::Operation>(),
            new ApiEnumConverter<string, Outputs::CollectionProcessingStatus>(),
            new ApiEnumConverter<string, Outputs::CollectionProcessingEventType>(),
            new ApiEnumConverter<string, Outputs::DeliveryStatus>(),
            new ApiEnumConverter<string, Outputs::SendEventType>(),
            new ApiEnumConverter<string, Outputs::InputType>(),
            new ApiEnumConverter<string, Outputs::SortOrder>(),
            new ApiEnumConverter<string, Workflows::Operation>(),
            new ApiEnumConverter<string, Workflows::WorkflowConnectorType>(),
            new ApiEnumConverter<string, Workflows::SortOrder>(),
            new ApiEnumConverter<string, WorkflowsVersions::SortOrder>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, ItemAddResponseStatus>(),
            new ApiEnumConverter<string, Events::FunctionType>(),
            new ApiEnumConverter<string, Webhooks::EventType>(),
            new ApiEnumConverter<string, Webhooks::ClassifyWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::ParseWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::OutputType>(),
            new ApiEnumConverter<string, Webhooks::SplitCollectionWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::SplitItemWebhookEventOutputType>(),
            new ApiEnumConverter<string, Webhooks::SplitItemWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::JoinType>(),
            new ApiEnumConverter<string, Webhooks::JoinWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::EnrichWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::PayloadShapingWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::DeliveryStatus>(),
            new ApiEnumConverter<string, Webhooks::SendWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::Status>(),
            new ApiEnumConverter<string, Webhooks::EvaluationWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::Operation>(),
            new ApiEnumConverter<string, Webhooks::CollectionProcessingWebhookEventStatus>(),
            new ApiEnumConverter<string, Webhooks::CollectionProcessingWebhookEventEventType>(),
            new ApiEnumConverter<string, FsOp>(),
            new ApiEnumConverter<string, ConnectorType>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionV3Type>(),
            new ApiEnumConverter<string, Subscriptions::Type>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionUpdateParamsType>(),
            new ApiEnumConverter<string, Subscriptions::SortOrder>(),
            new ApiEnumConverter<string, Views::ViewCreateResponseAggregationFunction>(),
            new ApiEnumConverter<string, Views::ViewCreateResponseFilterFilterType>(),
            new ApiEnumConverter<string, Views::DisplayType>(),
            new ApiEnumConverter<string, Views::ViewRetrieveResponseAggregationFunction>(),
            new ApiEnumConverter<string, Views::ViewRetrieveResponseFilterFilterType>(),
            new ApiEnumConverter<string, Views::ViewRetrieveResponseDisplayType>(),
            new ApiEnumConverter<string, Views::ViewUpdateResponseAggregationFunction>(),
            new ApiEnumConverter<string, Views::ViewUpdateResponseFilterFilterType>(),
            new ApiEnumConverter<string, Views::ViewUpdateResponseDisplayType>(),
            new ApiEnumConverter<string, Views::ViewAggregationFunction>(),
            new ApiEnumConverter<string, Views::ViewFilterFilterType>(),
            new ApiEnumConverter<string, Views::ViewDisplayType>(),
            new ApiEnumConverter<string, Views::Function>(),
            new ApiEnumConverter<string, Views::FilterType>(),
            new ApiEnumConverter<string, Views::ViewUpdateParamsAggregationFunction>(),
            new ApiEnumConverter<string, Views::ViewUpdateParamsFilterFilterType>(),
            new ApiEnumConverter<string, Views::SortOrder>(),
            new ApiEnumConverter<
                string,
                Views::ViewGenerateAggregationDataParamsAggregationFunction
            >(),
            new ApiEnumConverter<
                string,
                Views::ViewGenerateAggregationDataParamsFilterFilterType
            >(),
            new ApiEnumConverter<string, Views::ViewGenerateTableDataParamsAggregationFunction>(),
            new ApiEnumConverter<string, Views::ViewGenerateTableDataParamsFilterFilterType>(),
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
