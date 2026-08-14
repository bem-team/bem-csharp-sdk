using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Exceptions;

namespace Bem.Models.Eval.Score;

/// <summary>
/// Status values for an eval-score run.
/// </summary>
[JsonConverter(typeof(EvalScoreRunStatusConverter))]
public enum EvalScoreRunStatus
{
    Pending,
    Initializing,
    Running,
    Completed,
    Error,
    Cancelled,
}

sealed class EvalScoreRunStatusConverter : JsonConverter<EvalScoreRunStatus>
{
    public override EvalScoreRunStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => EvalScoreRunStatus.Pending,
            "initializing" => EvalScoreRunStatus.Initializing,
            "running" => EvalScoreRunStatus.Running,
            "completed" => EvalScoreRunStatus.Completed,
            "error" => EvalScoreRunStatus.Error,
            "cancelled" => EvalScoreRunStatus.Cancelled,
            _ => (EvalScoreRunStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EvalScoreRunStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EvalScoreRunStatus.Pending => "pending",
                EvalScoreRunStatus.Initializing => "initializing",
                EvalScoreRunStatus.Running => "running",
                EvalScoreRunStatus.Completed => "completed",
                EvalScoreRunStatus.Error => "error",
                EvalScoreRunStatus.Cancelled => "cancelled",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
