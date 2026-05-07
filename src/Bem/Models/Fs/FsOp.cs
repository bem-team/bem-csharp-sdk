using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bem.Exceptions;

namespace Bem.Models.Fs;

/// <summary>
/// Operations exposed by `POST /v3/fs`.
///
/// <para>The verbs and their flag names mirror Unix tools so an LLM agent's existing
/// vocabulary maps directly:</para>
///
/// <para>- `ls` — list parsed documents - `cat` — read one parsed doc (optionally
/// sliced by range / projected by select) - `grep` — substring or regex search across
/// parse outputs - `head` — first N sections of one doc - `stat` — metadata only
/// (page count, section count, parsed at, ...) - `find` — list canonical entities
/// (cross-doc memory) - `open` — entity + mentions - `xref` — entity → sections
/// across docs that mention it</para>
///
/// <para>Doc-level ops (ls, cat, grep, head, stat) work on every parsed document,
/// regardless of how the parse function was configured.</para>
///
/// <para>Memory-level ops (find, open, xref) operate on the global entities table
/// which is only populated when the parse function had `linkAcrossDocuments: true`.
/// On environments with no memory-linked docs they return empty data with a hint
/// pointing at the toggle.</para>
/// </summary>
[JsonConverter(typeof(FsOpConverter))]
public enum FsOp
{
    Ls,
    Find,
    Open,
    Cat,
    Grep,
    Xref,
    Stat,
    Head,
}

sealed class FsOpConverter : JsonConverter<FsOp>
{
    public override FsOp Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ls" => FsOp.Ls,
            "find" => FsOp.Find,
            "open" => FsOp.Open,
            "cat" => FsOp.Cat,
            "grep" => FsOp.Grep,
            "xref" => FsOp.Xref,
            "stat" => FsOp.Stat,
            "head" => FsOp.Head,
            _ => (FsOp)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FsOp value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FsOp.Ls => "ls",
                FsOp.Find => "find",
                FsOp.Open => "open",
                FsOp.Cat => "cat",
                FsOp.Grep => "grep",
                FsOp.Xref => "xref",
                FsOp.Stat => "stat",
                FsOp.Head => "head",
                _ => throw new BemInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
