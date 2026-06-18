using System;
using Bem.Models.Entities.Synonyms;

namespace Bem.Tests.Models.Entities.Synonyms;

public class SynonymRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SynonymRemoveParams
        {
            ID = "id",
            SynonymID = "synonymID",
            Bucket = "bucket",
        };

        string expectedID = "id";
        string expectedSynonymID = "synonymID";
        string expectedBucket = "bucket";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSynonymID, parameters.SynonymID);
        Assert.Equal(expectedBucket, parameters.Bucket);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SynonymRemoveParams { ID = "id", SynonymID = "synonymID" };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SynonymRemoveParams
        {
            ID = "id",
            SynonymID = "synonymID",

            // Null should be interpreted as omitted for these properties
            Bucket = null,
        };

        Assert.Null(parameters.Bucket);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket"));
    }

    [Fact]
    public void Url_Works()
    {
        SynonymRemoveParams parameters = new()
        {
            ID = "id",
            SynonymID = "synonymID",
            Bucket = "bucket",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.bem.ai/v3/entities/id/synonyms/synonymID?bucket=bucket"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SynonymRemoveParams
        {
            ID = "id",
            SynonymID = "synonymID",
            Bucket = "bucket",
        };

        SynonymRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
