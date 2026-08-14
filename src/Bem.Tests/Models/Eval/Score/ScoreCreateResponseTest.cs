using System.Text.Json;
using Bem.Core;
using Bem.Models.Eval.Score;

namespace Bem.Tests.Models.Eval.Score;

public class ScoreCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScoreCreateResponse
        {
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
        };

        string expectedScoreRunID = "scoreRunID";
        ApiEnum<string, EvalScoreRunStatus> expectedStatus = EvalScoreRunStatus.Pending;

        Assert.Equal(expectedScoreRunID, model.ScoreRunID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ScoreCreateResponse
        {
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScoreCreateResponse
        {
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScoreCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedScoreRunID = "scoreRunID";
        ApiEnum<string, EvalScoreRunStatus> expectedStatus = EvalScoreRunStatus.Pending;

        Assert.Equal(expectedScoreRunID, deserialized.ScoreRunID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ScoreCreateResponse
        {
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ScoreCreateResponse
        {
            ScoreRunID = "scoreRunID",
            Status = EvalScoreRunStatus.Pending,
        };

        ScoreCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
