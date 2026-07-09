using System.Text.Json;
using Bem.Core;
using Bem.Models.Functions;

namespace Bem.Tests.Models.Functions;

public class MetricComparisonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetricComparison
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, model.BaselineValue);
        Assert.Equal(expectedComparisonValue, model.ComparisonValue);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedLiftPercent, model.LiftPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MetricComparison
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetricComparison>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MetricComparison
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetricComparison>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBaselineValue = 0;
        double expectedComparisonValue = 0;
        double expectedDifference = 0;
        double expectedLiftPercent = 0;

        Assert.Equal(expectedBaselineValue, deserialized.BaselineValue);
        Assert.Equal(expectedComparisonValue, deserialized.ComparisonValue);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedLiftPercent, deserialized.LiftPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MetricComparison
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MetricComparison { };

        Assert.Null(model.BaselineValue);
        Assert.False(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.False(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.False(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MetricComparison { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MetricComparison
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        Assert.Null(model.BaselineValue);
        Assert.True(model.RawData.ContainsKey("baselineValue"));
        Assert.Null(model.ComparisonValue);
        Assert.True(model.RawData.ContainsKey("comparisonValue"));
        Assert.Null(model.Difference);
        Assert.True(model.RawData.ContainsKey("difference"));
        Assert.Null(model.LiftPercent);
        Assert.True(model.RawData.ContainsKey("liftPercent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MetricComparison
        {
            BaselineValue = null,
            ComparisonValue = null,
            Difference = null,
            LiftPercent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MetricComparison
        {
            BaselineValue = 0,
            ComparisonValue = 0,
            Difference = 0,
            LiftPercent = 0,
        };

        MetricComparison copied = new(model);

        Assert.Equal(model, copied);
    }
}
