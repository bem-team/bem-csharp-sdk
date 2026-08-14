using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Eval.Score;

namespace Bem.Tests.Models.Eval.Score;

public class EvalScoreRunStatusTest : TestBase
{
    [Theory]
    [InlineData(EvalScoreRunStatus.Pending)]
    [InlineData(EvalScoreRunStatus.Initializing)]
    [InlineData(EvalScoreRunStatus.Running)]
    [InlineData(EvalScoreRunStatus.Completed)]
    [InlineData(EvalScoreRunStatus.Error)]
    [InlineData(EvalScoreRunStatus.Cancelled)]
    public void Validation_Works(EvalScoreRunStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EvalScoreRunStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EvalScoreRunStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EvalScoreRunStatus.Pending)]
    [InlineData(EvalScoreRunStatus.Initializing)]
    [InlineData(EvalScoreRunStatus.Running)]
    [InlineData(EvalScoreRunStatus.Completed)]
    [InlineData(EvalScoreRunStatus.Error)]
    [InlineData(EvalScoreRunStatus.Cancelled)]
    public void SerializationRoundtrip_Works(EvalScoreRunStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EvalScoreRunStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EvalScoreRunStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EvalScoreRunStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EvalScoreRunStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
