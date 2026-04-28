using System;
using System.Collections.Generic;
using Bem.Models.Eval.Results;

namespace Bem.Tests.Models.Eval.Results;

public class ResultFetchResultsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ResultFetchResultsParams
        {
            TransformationIds = ["tr_01HXAB...", "tr_01HXCD..."],
            EvaluationVersion = "0.1.0-gemini",
        };

        List<string> expectedTransformationIds = ["tr_01HXAB...", "tr_01HXCD..."];
        string expectedEvaluationVersion = "0.1.0-gemini";

        Assert.Equal(expectedTransformationIds.Count, parameters.TransformationIds.Count);
        for (int i = 0; i < expectedTransformationIds.Count; i++)
        {
            Assert.Equal(expectedTransformationIds[i], parameters.TransformationIds[i]);
        }
        Assert.Equal(expectedEvaluationVersion, parameters.EvaluationVersion);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ResultFetchResultsParams
        {
            TransformationIds = ["tr_01HXAB...", "tr_01HXCD..."],
        };

        Assert.Null(parameters.EvaluationVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("evaluationVersion"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ResultFetchResultsParams
        {
            TransformationIds = ["tr_01HXAB...", "tr_01HXCD..."],

            // Null should be interpreted as omitted for these properties
            EvaluationVersion = null,
        };

        Assert.Null(parameters.EvaluationVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("evaluationVersion"));
    }

    [Fact]
    public void Url_Works()
    {
        ResultFetchResultsParams parameters = new()
        {
            TransformationIds = ["tr_01HXAB...", "tr_01HXCD..."],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/eval/results"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ResultFetchResultsParams
        {
            TransformationIds = ["tr_01HXAB...", "tr_01HXCD..."],
            EvaluationVersion = "0.1.0-gemini",
        };

        ResultFetchResultsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
