using System;
using Bem.Models.Eval.Results;

namespace Bem.Tests.Models.Eval.Results;

public class ResultRetrieveResultsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ResultRetrieveResultsParams
        {
            EvaluationVersion = "evaluationVersion",
            EventIds = "eventIDs",
            TransformationIds = "transformationIDs",
        };

        string expectedEvaluationVersion = "evaluationVersion";
        string expectedEventIds = "eventIDs";
        string expectedTransformationIds = "transformationIDs";

        Assert.Equal(expectedEvaluationVersion, parameters.EvaluationVersion);
        Assert.Equal(expectedEventIds, parameters.EventIds);
        Assert.Equal(expectedTransformationIds, parameters.TransformationIds);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ResultRetrieveResultsParams { };

        Assert.Null(parameters.EvaluationVersion);
        Assert.False(parameters.RawQueryData.ContainsKey("evaluationVersion"));
        Assert.Null(parameters.EventIds);
        Assert.False(parameters.RawQueryData.ContainsKey("eventIDs"));
        Assert.Null(parameters.TransformationIds);
        Assert.False(parameters.RawQueryData.ContainsKey("transformationIDs"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ResultRetrieveResultsParams
        {
            // Null should be interpreted as omitted for these properties
            EvaluationVersion = null,
            EventIds = null,
            TransformationIds = null,
        };

        Assert.Null(parameters.EvaluationVersion);
        Assert.False(parameters.RawQueryData.ContainsKey("evaluationVersion"));
        Assert.Null(parameters.EventIds);
        Assert.False(parameters.RawQueryData.ContainsKey("eventIDs"));
        Assert.Null(parameters.TransformationIds);
        Assert.False(parameters.RawQueryData.ContainsKey("transformationIDs"));
    }

    [Fact]
    public void Url_Works()
    {
        ResultRetrieveResultsParams parameters = new()
        {
            EvaluationVersion = "evaluationVersion",
            EventIds = "eventIDs",
            TransformationIds = "transformationIDs",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/eval/results?evaluationVersion=evaluationVersion&eventIDs=eventIDs&transformationIDs=transformationIDs"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ResultRetrieveResultsParams
        {
            EvaluationVersion = "evaluationVersion",
            EventIds = "eventIDs",
            TransformationIds = "transformationIDs",
        };

        ResultRetrieveResultsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
