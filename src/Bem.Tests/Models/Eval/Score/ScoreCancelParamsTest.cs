using System;
using Bem.Models.Eval.Score;

namespace Bem.Tests.Models.Eval.Score;

public class ScoreCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ScoreCancelParams { ScoreRunID = "scoreRunID" };

        string expectedScoreRunID = "scoreRunID";

        Assert.Equal(expectedScoreRunID, parameters.ScoreRunID);
    }

    [Fact]
    public void Url_Works()
    {
        ScoreCancelParams parameters = new() { ScoreRunID = "scoreRunID" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/eval/score/scoreRunID/cancel"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ScoreCancelParams { ScoreRunID = "scoreRunID" };

        ScoreCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
