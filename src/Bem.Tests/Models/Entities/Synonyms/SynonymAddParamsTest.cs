using System;
using Bem.Models.Entities.Synonyms;

namespace Bem.Tests.Models.Entities.Synonyms;

public class SynonymAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SynonymAddParams
        {
            ID = "id",
            Text = "ACME Corporation",
            Bucket = "bucket",
            Locale = "en-US",
        };

        string expectedID = "id";
        string expectedText = "ACME Corporation";
        string expectedBucket = "bucket";
        string expectedLocale = "en-US";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedBucket, parameters.Bucket);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SynonymAddParams { ID = "id", Text = "ACME Corporation" };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SynonymAddParams
        {
            ID = "id",
            Text = "ACME Corporation",

            // Null should be interpreted as omitted for these properties
            Bucket = null,
            Locale = null,
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        SynonymAddParams parameters = new()
        {
            ID = "id",
            Text = "ACME Corporation",
            Bucket = "bucket",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.bem.ai/v3/entities/id/synonyms?bucket=bucket"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SynonymAddParams
        {
            ID = "id",
            Text = "ACME Corporation",
            Bucket = "bucket",
            Locale = "en-US",
        };

        SynonymAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
