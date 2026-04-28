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
            TransformationIds = "transformationIDs",
            EvaluationVersion = "evaluationVersion",
        };

        string expectedTransformationIds = "transformationIDs";
        string expectedEvaluationVersion = "evaluationVersion";

        Assert.Equal(expectedTransformationIds, parameters.TransformationIds);
        Assert.Equal(expectedEvaluationVersion, parameters.EvaluationVersion);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ResultRetrieveResultsParams
        {
            TransformationIds = "transformationIDs",
        };

        Assert.Null(parameters.EvaluationVersion);
        Assert.False(parameters.RawQueryData.ContainsKey("evaluationVersion"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ResultRetrieveResultsParams
        {
            TransformationIds = "transformationIDs",

            // Null should be interpreted as omitted for these properties
            EvaluationVersion = null,
        };

        Assert.Null(parameters.EvaluationVersion);
        Assert.False(parameters.RawQueryData.ContainsKey("evaluationVersion"));
    }

    [Fact]
    public void Url_Works()
    {
        ResultRetrieveResultsParams parameters = new()
        {
            TransformationIds = "transformationIDs",
            EvaluationVersion = "evaluationVersion",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.bem.ai/v3/eval/results?transformationIDs=transformationIDs&evaluationVersion=evaluationVersion"
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
            TransformationIds = "transformationIDs",
            EvaluationVersion = "evaluationVersion",
        };

        ResultRetrieveResultsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
