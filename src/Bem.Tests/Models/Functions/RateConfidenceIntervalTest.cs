using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class RateConfidenceIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateConfidenceInterval
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        long expectedCurrentSample = 0;
        long expectedSampleNeeded = 0;
        float expectedCiLower = 0;
        float expectedCiUpper = 0;
        float expectedMid = 0;

        Assert.Equal(expectedCurrentSample, model.CurrentSample);
        Assert.Equal(expectedSampleNeeded, model.SampleNeeded);
        Assert.Equal(expectedCiLower, model.CiLower);
        Assert.Equal(expectedCiUpper, model.CiUpper);
        Assert.Equal(expectedMid, model.Mid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RateConfidenceInterval
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateConfidenceInterval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RateConfidenceInterval
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateConfidenceInterval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCurrentSample = 0;
        long expectedSampleNeeded = 0;
        float expectedCiLower = 0;
        float expectedCiUpper = 0;
        float expectedMid = 0;

        Assert.Equal(expectedCurrentSample, deserialized.CurrentSample);
        Assert.Equal(expectedSampleNeeded, deserialized.SampleNeeded);
        Assert.Equal(expectedCiLower, deserialized.CiLower);
        Assert.Equal(expectedCiUpper, deserialized.CiUpper);
        Assert.Equal(expectedMid, deserialized.Mid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RateConfidenceInterval
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RateConfidenceInterval { CurrentSample = 0, SampleNeeded = 0 };

        Assert.Null(model.CiLower);
        Assert.False(model.RawData.ContainsKey("ciLower"));
        Assert.Null(model.CiUpper);
        Assert.False(model.RawData.ContainsKey("ciUpper"));
        Assert.Null(model.Mid);
        Assert.False(model.RawData.ContainsKey("mid"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RateConfidenceInterval { CurrentSample = 0, SampleNeeded = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RateConfidenceInterval
        {
            CurrentSample = 0,
            SampleNeeded = 0,

            CiLower = null,
            CiUpper = null,
            Mid = null,
        };

        Assert.Null(model.CiLower);
        Assert.True(model.RawData.ContainsKey("ciLower"));
        Assert.Null(model.CiUpper);
        Assert.True(model.RawData.ContainsKey("ciUpper"));
        Assert.Null(model.Mid);
        Assert.True(model.RawData.ContainsKey("mid"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RateConfidenceInterval
        {
            CurrentSample = 0,
            SampleNeeded = 0,

            CiLower = null,
            CiUpper = null,
            Mid = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RateConfidenceInterval
        {
            CurrentSample = 0,
            SampleNeeded = 0,
            CiLower = 0,
            CiUpper = 0,
            Mid = 0,
        };

        RateConfidenceInterval copied = new(model);

        Assert.Equal(model, copied);
    }
}
