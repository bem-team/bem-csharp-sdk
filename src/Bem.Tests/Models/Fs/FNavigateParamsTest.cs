using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Fs = Bem.Models.Fs;

namespace Bem.Tests.Models.Fs;

public class FNavigateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Fs::FNavigateParams
        {
            Op = Fs::Op.Ls,
            CountOnly = true,
            Cursor = "cursor",
            Filter = new()
            {
                FunctionName = "functionName",
                Search = "search",
                Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = "type",
            },
            IgnoreCase = true,
            Limit = 0,
            N = 0,
            Path = "path",
            Pattern = "pattern",
            Range = new()
            {
                Page = 0,
                PageRange = [0, 0],
                SectionTypes = ["string"],
            },
            Regex = true,
            Scope = "scope",
            Select = ["string"],
        };

        ApiEnum<string, Fs::Op> expectedOp = Fs::Op.Ls;
        bool expectedCountOnly = true;
        string expectedCursor = "cursor";
        Fs::Filter expectedFilter = new()
        {
            FunctionName = "functionName",
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = "type",
        };
        bool expectedIgnoreCase = true;
        long expectedLimit = 0;
        long expectedN = 0;
        string expectedPath = "path";
        string expectedPattern = "pattern";
        Fs::Range expectedRange = new()
        {
            Page = 0,
            PageRange = [0, 0],
            SectionTypes = ["string"],
        };
        bool expectedRegex = true;
        string expectedScope = "scope";
        List<string> expectedSelect = ["string"];

        Assert.Equal(expectedOp, parameters.Op);
        Assert.Equal(expectedCountOnly, parameters.CountOnly);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedFilter, parameters.Filter);
        Assert.Equal(expectedIgnoreCase, parameters.IgnoreCase);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedN, parameters.N);
        Assert.Equal(expectedPath, parameters.Path);
        Assert.Equal(expectedPattern, parameters.Pattern);
        Assert.Equal(expectedRange, parameters.Range);
        Assert.Equal(expectedRegex, parameters.Regex);
        Assert.Equal(expectedScope, parameters.Scope);
        Assert.NotNull(parameters.Select);
        Assert.Equal(expectedSelect.Count, parameters.Select.Count);
        for (int i = 0; i < expectedSelect.Count; i++)
        {
            Assert.Equal(expectedSelect[i], parameters.Select[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Fs::FNavigateParams { Op = Fs::Op.Ls };

        Assert.Null(parameters.CountOnly);
        Assert.False(parameters.RawBodyData.ContainsKey("countOnly"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawBodyData.ContainsKey("cursor"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.IgnoreCase);
        Assert.False(parameters.RawBodyData.ContainsKey("ignoreCase"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.N);
        Assert.False(parameters.RawBodyData.ContainsKey("n"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
        Assert.Null(parameters.Pattern);
        Assert.False(parameters.RawBodyData.ContainsKey("pattern"));
        Assert.Null(parameters.Range);
        Assert.False(parameters.RawBodyData.ContainsKey("range"));
        Assert.Null(parameters.Regex);
        Assert.False(parameters.RawBodyData.ContainsKey("regex"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawBodyData.ContainsKey("scope"));
        Assert.Null(parameters.Select);
        Assert.False(parameters.RawBodyData.ContainsKey("select"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Fs::FNavigateParams
        {
            Op = Fs::Op.Ls,

            // Null should be interpreted as omitted for these properties
            CountOnly = null,
            Cursor = null,
            Filter = null,
            IgnoreCase = null,
            Limit = null,
            N = null,
            Path = null,
            Pattern = null,
            Range = null,
            Regex = null,
            Scope = null,
            Select = null,
        };

        Assert.Null(parameters.CountOnly);
        Assert.False(parameters.RawBodyData.ContainsKey("countOnly"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawBodyData.ContainsKey("cursor"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.IgnoreCase);
        Assert.False(parameters.RawBodyData.ContainsKey("ignoreCase"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.N);
        Assert.False(parameters.RawBodyData.ContainsKey("n"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
        Assert.Null(parameters.Pattern);
        Assert.False(parameters.RawBodyData.ContainsKey("pattern"));
        Assert.Null(parameters.Range);
        Assert.False(parameters.RawBodyData.ContainsKey("range"));
        Assert.Null(parameters.Regex);
        Assert.False(parameters.RawBodyData.ContainsKey("regex"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawBodyData.ContainsKey("scope"));
        Assert.Null(parameters.Select);
        Assert.False(parameters.RawBodyData.ContainsKey("select"));
    }

    [Fact]
    public void Url_Works()
    {
        Fs::FNavigateParams parameters = new() { Op = Fs::Op.Ls };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.bem.ai/v3/fs"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Fs::FNavigateParams
        {
            Op = Fs::Op.Ls,
            CountOnly = true,
            Cursor = "cursor",
            Filter = new()
            {
                FunctionName = "functionName",
                Search = "search",
                Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = "type",
            },
            IgnoreCase = true,
            Limit = 0,
            N = 0,
            Path = "path",
            Pattern = "pattern",
            Range = new()
            {
                Page = 0,
                PageRange = [0, 0],
                SectionTypes = ["string"],
            },
            Regex = true,
            Scope = "scope",
            Select = ["string"],
        };

        Fs::FNavigateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class OpTest : TestBase
{
    [Theory]
    [InlineData(Fs::Op.Ls)]
    [InlineData(Fs::Op.Find)]
    [InlineData(Fs::Op.Open)]
    [InlineData(Fs::Op.Cat)]
    [InlineData(Fs::Op.Grep)]
    [InlineData(Fs::Op.Xref)]
    [InlineData(Fs::Op.Stat)]
    [InlineData(Fs::Op.Head)]
    public void Validation_Works(Fs::Op rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Fs::Op> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Fs::Op>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Fs::Op.Ls)]
    [InlineData(Fs::Op.Find)]
    [InlineData(Fs::Op.Open)]
    [InlineData(Fs::Op.Cat)]
    [InlineData(Fs::Op.Grep)]
    [InlineData(Fs::Op.Xref)]
    [InlineData(Fs::Op.Stat)]
    [InlineData(Fs::Op.Head)]
    public void SerializationRoundtrip_Works(Fs::Op rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Fs::Op> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Fs::Op>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Fs::Op>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Fs::Op>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Fs::Filter
        {
            FunctionName = "functionName",
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = "type",
        };

        string expectedFunctionName = "functionName";
        string expectedSearch = "search";
        DateTimeOffset expectedSince = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedType = "type";

        Assert.Equal(expectedFunctionName, model.FunctionName);
        Assert.Equal(expectedSearch, model.Search);
        Assert.Equal(expectedSince, model.Since);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Fs::Filter
        {
            FunctionName = "functionName",
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Fs::Filter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Fs::Filter
        {
            FunctionName = "functionName",
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Fs::Filter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFunctionName = "functionName";
        string expectedSearch = "search";
        DateTimeOffset expectedSince = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedType = "type";

        Assert.Equal(expectedFunctionName, deserialized.FunctionName);
        Assert.Equal(expectedSearch, deserialized.Search);
        Assert.Equal(expectedSince, deserialized.Since);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Fs::Filter
        {
            FunctionName = "functionName",
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Fs::Filter { };

        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.Search);
        Assert.False(model.RawData.ContainsKey("search"));
        Assert.Null(model.Since);
        Assert.False(model.RawData.ContainsKey("since"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Fs::Filter { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Fs::Filter
        {
            // Null should be interpreted as omitted for these properties
            FunctionName = null,
            Search = null,
            Since = null,
            Type = null,
        };

        Assert.Null(model.FunctionName);
        Assert.False(model.RawData.ContainsKey("functionName"));
        Assert.Null(model.Search);
        Assert.False(model.RawData.ContainsKey("search"));
        Assert.Null(model.Since);
        Assert.False(model.RawData.ContainsKey("since"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Fs::Filter
        {
            // Null should be interpreted as omitted for these properties
            FunctionName = null,
            Search = null,
            Since = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Fs::Filter
        {
            FunctionName = "functionName",
            Search = "search",
            Since = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = "type",
        };

        Fs::Filter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Fs::Range
        {
            Page = 0,
            PageRange = [0, 0],
            SectionTypes = ["string"],
        };

        long expectedPage = 0;
        List<long> expectedPageRange = [0, 0];
        List<string> expectedSectionTypes = ["string"];

        Assert.Equal(expectedPage, model.Page);
        Assert.NotNull(model.PageRange);
        Assert.Equal(expectedPageRange.Count, model.PageRange.Count);
        for (int i = 0; i < expectedPageRange.Count; i++)
        {
            Assert.Equal(expectedPageRange[i], model.PageRange[i]);
        }
        Assert.NotNull(model.SectionTypes);
        Assert.Equal(expectedSectionTypes.Count, model.SectionTypes.Count);
        for (int i = 0; i < expectedSectionTypes.Count; i++)
        {
            Assert.Equal(expectedSectionTypes[i], model.SectionTypes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Fs::Range
        {
            Page = 0,
            PageRange = [0, 0],
            SectionTypes = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Fs::Range>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Fs::Range
        {
            Page = 0,
            PageRange = [0, 0],
            SectionTypes = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Fs::Range>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPage = 0;
        List<long> expectedPageRange = [0, 0];
        List<string> expectedSectionTypes = ["string"];

        Assert.Equal(expectedPage, deserialized.Page);
        Assert.NotNull(deserialized.PageRange);
        Assert.Equal(expectedPageRange.Count, deserialized.PageRange.Count);
        for (int i = 0; i < expectedPageRange.Count; i++)
        {
            Assert.Equal(expectedPageRange[i], deserialized.PageRange[i]);
        }
        Assert.NotNull(deserialized.SectionTypes);
        Assert.Equal(expectedSectionTypes.Count, deserialized.SectionTypes.Count);
        for (int i = 0; i < expectedSectionTypes.Count; i++)
        {
            Assert.Equal(expectedSectionTypes[i], deserialized.SectionTypes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Fs::Range
        {
            Page = 0,
            PageRange = [0, 0],
            SectionTypes = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Fs::Range { };

        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageRange);
        Assert.False(model.RawData.ContainsKey("pageRange"));
        Assert.Null(model.SectionTypes);
        Assert.False(model.RawData.ContainsKey("sectionTypes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Fs::Range { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Fs::Range
        {
            // Null should be interpreted as omitted for these properties
            Page = null,
            PageRange = null,
            SectionTypes = null,
        };

        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageRange);
        Assert.False(model.RawData.ContainsKey("pageRange"));
        Assert.Null(model.SectionTypes);
        Assert.False(model.RawData.ContainsKey("sectionTypes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Fs::Range
        {
            // Null should be interpreted as omitted for these properties
            Page = null,
            PageRange = null,
            SectionTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Fs::Range
        {
            Page = 0,
            PageRange = [0, 0],
            SectionTypes = ["string"],
        };

        Fs::Range copied = new(model);

        Assert.Equal(model, copied);
    }
}
