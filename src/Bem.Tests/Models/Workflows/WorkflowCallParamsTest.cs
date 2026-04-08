using System;
using System.Collections.Generic;
using System.Text.Json;
using Bem.Core;
using Bem.Exceptions;
using Bem.Models.Workflows;

namespace Bem.Tests.Models.Workflows;

public class WorkflowCallParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkflowCallParams
        {
            WorkflowName = "workflowName",
            Input = new()
            {
                BatchFiles = new()
                {
                    Inputs =
                    [
                        new()
                        {
                            InputContent = "inputContent",
                            InputType = InputType.Csv,
                            ItemReferenceID = "itemReferenceID",
                        },
                    ],
                },
                SingleFile = new()
                {
                    InputContent = "inputContent",
                    InputType = SingleFileInputType.Csv,
                },
            },
            Wait = true,
            CallReferenceID = "callReferenceID",
        };

        string expectedWorkflowName = "workflowName";
        Input expectedInput = new()
        {
            BatchFiles = new()
            {
                Inputs =
                [
                    new()
                    {
                        InputContent = "inputContent",
                        InputType = InputType.Csv,
                        ItemReferenceID = "itemReferenceID",
                    },
                ],
            },
            SingleFile = new()
            {
                InputContent = "inputContent",
                InputType = SingleFileInputType.Csv,
            },
        };
        bool expectedWait = true;
        string expectedCallReferenceID = "callReferenceID";

        Assert.Equal(expectedWorkflowName, parameters.WorkflowName);
        Assert.Equal(expectedInput, parameters.Input);
        Assert.Equal(expectedWait, parameters.Wait);
        Assert.Equal(expectedCallReferenceID, parameters.CallReferenceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkflowCallParams
        {
            WorkflowName = "workflowName",
            Input = new()
            {
                BatchFiles = new()
                {
                    Inputs =
                    [
                        new()
                        {
                            InputContent = "inputContent",
                            InputType = InputType.Csv,
                            ItemReferenceID = "itemReferenceID",
                        },
                    ],
                },
                SingleFile = new()
                {
                    InputContent = "inputContent",
                    InputType = SingleFileInputType.Csv,
                },
            },
        };

        Assert.Null(parameters.Wait);
        Assert.False(parameters.RawQueryData.ContainsKey("wait"));
        Assert.Null(parameters.CallReferenceID);
        Assert.False(parameters.RawBodyData.ContainsKey("callReferenceID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkflowCallParams
        {
            WorkflowName = "workflowName",
            Input = new()
            {
                BatchFiles = new()
                {
                    Inputs =
                    [
                        new()
                        {
                            InputContent = "inputContent",
                            InputType = InputType.Csv,
                            ItemReferenceID = "itemReferenceID",
                        },
                    ],
                },
                SingleFile = new()
                {
                    InputContent = "inputContent",
                    InputType = SingleFileInputType.Csv,
                },
            },

            // Null should be interpreted as omitted for these properties
            Wait = null,
            CallReferenceID = null,
        };

        Assert.Null(parameters.Wait);
        Assert.False(parameters.RawQueryData.ContainsKey("wait"));
        Assert.Null(parameters.CallReferenceID);
        Assert.False(parameters.RawBodyData.ContainsKey("callReferenceID"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkflowCallParams parameters = new()
        {
            WorkflowName = "workflowName",
            Input = new()
            {
                BatchFiles = new()
                {
                    Inputs =
                    [
                        new()
                        {
                            InputContent = "inputContent",
                            InputType = InputType.Csv,
                            ItemReferenceID = "itemReferenceID",
                        },
                    ],
                },
                SingleFile = new()
                {
                    InputContent = "inputContent",
                    InputType = SingleFileInputType.Csv,
                },
            },
            Wait = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.bem.ai/v3/workflows/workflowName/call?wait=true"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkflowCallParams
        {
            WorkflowName = "workflowName",
            Input = new()
            {
                BatchFiles = new()
                {
                    Inputs =
                    [
                        new()
                        {
                            InputContent = "inputContent",
                            InputType = InputType.Csv,
                            ItemReferenceID = "itemReferenceID",
                        },
                    ],
                },
                SingleFile = new()
                {
                    InputContent = "inputContent",
                    InputType = SingleFileInputType.Csv,
                },
            },
            Wait = true,
            CallReferenceID = "callReferenceID",
        };

        WorkflowCallParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Input
        {
            BatchFiles = new()
            {
                Inputs =
                [
                    new()
                    {
                        InputContent = "inputContent",
                        InputType = InputType.Csv,
                        ItemReferenceID = "itemReferenceID",
                    },
                ],
            },
            SingleFile = new()
            {
                InputContent = "inputContent",
                InputType = SingleFileInputType.Csv,
            },
        };

        BatchFiles expectedBatchFiles = new()
        {
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = InputType.Csv,
                    ItemReferenceID = "itemReferenceID",
                },
            ],
        };
        SingleFile expectedSingleFile = new()
        {
            InputContent = "inputContent",
            InputType = SingleFileInputType.Csv,
        };

        Assert.Equal(expectedBatchFiles, model.BatchFiles);
        Assert.Equal(expectedSingleFile, model.SingleFile);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Input
        {
            BatchFiles = new()
            {
                Inputs =
                [
                    new()
                    {
                        InputContent = "inputContent",
                        InputType = InputType.Csv,
                        ItemReferenceID = "itemReferenceID",
                    },
                ],
            },
            SingleFile = new()
            {
                InputContent = "inputContent",
                InputType = SingleFileInputType.Csv,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Input
        {
            BatchFiles = new()
            {
                Inputs =
                [
                    new()
                    {
                        InputContent = "inputContent",
                        InputType = InputType.Csv,
                        ItemReferenceID = "itemReferenceID",
                    },
                ],
            },
            SingleFile = new()
            {
                InputContent = "inputContent",
                InputType = SingleFileInputType.Csv,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        BatchFiles expectedBatchFiles = new()
        {
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = InputType.Csv,
                    ItemReferenceID = "itemReferenceID",
                },
            ],
        };
        SingleFile expectedSingleFile = new()
        {
            InputContent = "inputContent",
            InputType = SingleFileInputType.Csv,
        };

        Assert.Equal(expectedBatchFiles, deserialized.BatchFiles);
        Assert.Equal(expectedSingleFile, deserialized.SingleFile);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Input
        {
            BatchFiles = new()
            {
                Inputs =
                [
                    new()
                    {
                        InputContent = "inputContent",
                        InputType = InputType.Csv,
                        ItemReferenceID = "itemReferenceID",
                    },
                ],
            },
            SingleFile = new()
            {
                InputContent = "inputContent",
                InputType = SingleFileInputType.Csv,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Input { };

        Assert.Null(model.BatchFiles);
        Assert.False(model.RawData.ContainsKey("batchFiles"));
        Assert.Null(model.SingleFile);
        Assert.False(model.RawData.ContainsKey("singleFile"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Input { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Input
        {
            // Null should be interpreted as omitted for these properties
            BatchFiles = null,
            SingleFile = null,
        };

        Assert.Null(model.BatchFiles);
        Assert.False(model.RawData.ContainsKey("batchFiles"));
        Assert.Null(model.SingleFile);
        Assert.False(model.RawData.ContainsKey("singleFile"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Input
        {
            // Null should be interpreted as omitted for these properties
            BatchFiles = null,
            SingleFile = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Input
        {
            BatchFiles = new()
            {
                Inputs =
                [
                    new()
                    {
                        InputContent = "inputContent",
                        InputType = InputType.Csv,
                        ItemReferenceID = "itemReferenceID",
                    },
                ],
            },
            SingleFile = new()
            {
                InputContent = "inputContent",
                InputType = SingleFileInputType.Csv,
            },
        };

        Input copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchFilesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchFiles
        {
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = InputType.Csv,
                    ItemReferenceID = "itemReferenceID",
                },
            ],
        };

        List<BatchFilesInput> expectedInputs =
        [
            new()
            {
                InputContent = "inputContent",
                InputType = InputType.Csv,
                ItemReferenceID = "itemReferenceID",
            },
        ];

        Assert.NotNull(model.Inputs);
        Assert.Equal(expectedInputs.Count, model.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], model.Inputs[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchFiles
        {
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = InputType.Csv,
                    ItemReferenceID = "itemReferenceID",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchFiles>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchFiles
        {
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = InputType.Csv,
                    ItemReferenceID = "itemReferenceID",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchFiles>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BatchFilesInput> expectedInputs =
        [
            new()
            {
                InputContent = "inputContent",
                InputType = InputType.Csv,
                ItemReferenceID = "itemReferenceID",
            },
        ];

        Assert.NotNull(deserialized.Inputs);
        Assert.Equal(expectedInputs.Count, deserialized.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], deserialized.Inputs[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchFiles
        {
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = InputType.Csv,
                    ItemReferenceID = "itemReferenceID",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchFiles { };

        Assert.Null(model.Inputs);
        Assert.False(model.RawData.ContainsKey("inputs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BatchFiles { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BatchFiles
        {
            // Null should be interpreted as omitted for these properties
            Inputs = null,
        };

        Assert.Null(model.Inputs);
        Assert.False(model.RawData.ContainsKey("inputs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BatchFiles
        {
            // Null should be interpreted as omitted for these properties
            Inputs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchFiles
        {
            Inputs =
            [
                new()
                {
                    InputContent = "inputContent",
                    InputType = InputType.Csv,
                    ItemReferenceID = "itemReferenceID",
                },
            ],
        };

        BatchFiles copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchFilesInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
            ItemReferenceID = "itemReferenceID",
        };

        string expectedInputContent = "inputContent";
        ApiEnum<string, InputType> expectedInputType = InputType.Csv;
        string expectedItemReferenceID = "itemReferenceID";

        Assert.Equal(expectedInputContent, model.InputContent);
        Assert.Equal(expectedInputType, model.InputType);
        Assert.Equal(expectedItemReferenceID, model.ItemReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
            ItemReferenceID = "itemReferenceID",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchFilesInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
            ItemReferenceID = "itemReferenceID",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchFilesInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInputContent = "inputContent";
        ApiEnum<string, InputType> expectedInputType = InputType.Csv;
        string expectedItemReferenceID = "itemReferenceID";

        Assert.Equal(expectedInputContent, deserialized.InputContent);
        Assert.Equal(expectedInputType, deserialized.InputType);
        Assert.Equal(expectedItemReferenceID, deserialized.ItemReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
            ItemReferenceID = "itemReferenceID",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
        };

        Assert.Null(model.ItemReferenceID);
        Assert.False(model.RawData.ContainsKey("itemReferenceID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,

            // Null should be interpreted as omitted for these properties
            ItemReferenceID = null,
        };

        Assert.Null(model.ItemReferenceID);
        Assert.False(model.RawData.ContainsKey("itemReferenceID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,

            // Null should be interpreted as omitted for these properties
            ItemReferenceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchFilesInput
        {
            InputContent = "inputContent",
            InputType = InputType.Csv,
            ItemReferenceID = "itemReferenceID",
        };

        BatchFilesInput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputTypeTest : TestBase
{
    [Theory]
    [InlineData(InputType.Csv)]
    [InlineData(InputType.Docx)]
    [InlineData(InputType.Email)]
    [InlineData(InputType.Heic)]
    [InlineData(InputType.Html)]
    [InlineData(InputType.Jpeg)]
    [InlineData(InputType.Json)]
    [InlineData(InputType.Heif)]
    [InlineData(InputType.M4a)]
    [InlineData(InputType.Mp3)]
    [InlineData(InputType.Pdf)]
    [InlineData(InputType.Png)]
    [InlineData(InputType.Text)]
    [InlineData(InputType.Wav)]
    [InlineData(InputType.Webp)]
    [InlineData(InputType.Xls)]
    [InlineData(InputType.Xlsx)]
    [InlineData(InputType.Xml)]
    public void Validation_Works(InputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InputType.Csv)]
    [InlineData(InputType.Docx)]
    [InlineData(InputType.Email)]
    [InlineData(InputType.Heic)]
    [InlineData(InputType.Html)]
    [InlineData(InputType.Jpeg)]
    [InlineData(InputType.Json)]
    [InlineData(InputType.Heif)]
    [InlineData(InputType.M4a)]
    [InlineData(InputType.Mp3)]
    [InlineData(InputType.Pdf)]
    [InlineData(InputType.Png)]
    [InlineData(InputType.Text)]
    [InlineData(InputType.Wav)]
    [InlineData(InputType.Webp)]
    [InlineData(InputType.Xls)]
    [InlineData(InputType.Xlsx)]
    [InlineData(InputType.Xml)]
    public void SerializationRoundtrip_Works(InputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SingleFileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SingleFile
        {
            InputContent = "inputContent",
            InputType = SingleFileInputType.Csv,
        };

        string expectedInputContent = "inputContent";
        ApiEnum<string, SingleFileInputType> expectedInputType = SingleFileInputType.Csv;

        Assert.Equal(expectedInputContent, model.InputContent);
        Assert.Equal(expectedInputType, model.InputType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SingleFile
        {
            InputContent = "inputContent",
            InputType = SingleFileInputType.Csv,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SingleFile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SingleFile
        {
            InputContent = "inputContent",
            InputType = SingleFileInputType.Csv,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SingleFile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInputContent = "inputContent";
        ApiEnum<string, SingleFileInputType> expectedInputType = SingleFileInputType.Csv;

        Assert.Equal(expectedInputContent, deserialized.InputContent);
        Assert.Equal(expectedInputType, deserialized.InputType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SingleFile
        {
            InputContent = "inputContent",
            InputType = SingleFileInputType.Csv,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SingleFile
        {
            InputContent = "inputContent",
            InputType = SingleFileInputType.Csv,
        };

        SingleFile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SingleFileInputTypeTest : TestBase
{
    [Theory]
    [InlineData(SingleFileInputType.Csv)]
    [InlineData(SingleFileInputType.Docx)]
    [InlineData(SingleFileInputType.Email)]
    [InlineData(SingleFileInputType.Heic)]
    [InlineData(SingleFileInputType.Html)]
    [InlineData(SingleFileInputType.Jpeg)]
    [InlineData(SingleFileInputType.Json)]
    [InlineData(SingleFileInputType.Heif)]
    [InlineData(SingleFileInputType.M4a)]
    [InlineData(SingleFileInputType.Mp3)]
    [InlineData(SingleFileInputType.Pdf)]
    [InlineData(SingleFileInputType.Png)]
    [InlineData(SingleFileInputType.Text)]
    [InlineData(SingleFileInputType.Wav)]
    [InlineData(SingleFileInputType.Webp)]
    [InlineData(SingleFileInputType.Xls)]
    [InlineData(SingleFileInputType.Xlsx)]
    [InlineData(SingleFileInputType.Xml)]
    public void Validation_Works(SingleFileInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SingleFileInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SingleFileInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BemInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SingleFileInputType.Csv)]
    [InlineData(SingleFileInputType.Docx)]
    [InlineData(SingleFileInputType.Email)]
    [InlineData(SingleFileInputType.Heic)]
    [InlineData(SingleFileInputType.Html)]
    [InlineData(SingleFileInputType.Jpeg)]
    [InlineData(SingleFileInputType.Json)]
    [InlineData(SingleFileInputType.Heif)]
    [InlineData(SingleFileInputType.M4a)]
    [InlineData(SingleFileInputType.Mp3)]
    [InlineData(SingleFileInputType.Pdf)]
    [InlineData(SingleFileInputType.Png)]
    [InlineData(SingleFileInputType.Text)]
    [InlineData(SingleFileInputType.Wav)]
    [InlineData(SingleFileInputType.Webp)]
    [InlineData(SingleFileInputType.Xls)]
    [InlineData(SingleFileInputType.Xlsx)]
    [InlineData(SingleFileInputType.Xml)]
    public void SerializationRoundtrip_Works(SingleFileInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SingleFileInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SingleFileInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SingleFileInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SingleFileInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
