using System;
using Bem.Models.Eval.Score;

namespace Bem.Tests.Models.Eval.Score;

public class ScoreRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ScoreRetrieveParams { ScoreRunID = "scoreRunID" };

        string expectedScoreRunID = "scoreRunID";

        Assert.Equal(expectedScoreRunID, parameters.ScoreRunID);
    }

    [Fact]
    public void Url_Works()
    {
        ScoreRetrieveParams parameters = new() { ScoreRunID = "scoreRunID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/eval/score/scoreRunID"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ScoreRetrieveParams { ScoreRunID = "scoreRunID" };

        ScoreRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
