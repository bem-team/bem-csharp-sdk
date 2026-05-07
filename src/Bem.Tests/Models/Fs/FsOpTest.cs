using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Fs;

namespace Bem.Tests.Models.Fs;

public class FsOpTest : TestBase
{
    [Theory]
    [InlineData(FsOp.Ls)]
    [InlineData(FsOp.Find)]
    [InlineData(FsOp.Open)]
    [InlineData(FsOp.Cat)]
    [InlineData(FsOp.Grep)]
    [InlineData(FsOp.Xref)]
    [InlineData(FsOp.Stat)]
    [InlineData(FsOp.Head)]
    public void Validation_Works(FsOp rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FsOp> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FsOp>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FsOp.Ls)]
    [InlineData(FsOp.Find)]
    [InlineData(FsOp.Open)]
    [InlineData(FsOp.Cat)]
    [InlineData(FsOp.Grep)]
    [InlineData(FsOp.Xref)]
    [InlineData(FsOp.Stat)]
    [InlineData(FsOp.Head)]
    public void SerializationRoundtrip_Works(FsOp rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FsOp> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FsOp>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FsOp>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FsOp>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
