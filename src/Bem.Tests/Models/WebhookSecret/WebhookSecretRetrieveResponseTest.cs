using System.Text.Json;
using Bem.Core;
using Bem.Models.WebhookSecret;

namespace Bem.Tests.Models.WebhookSecret;

public class WebhookSecretRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookSecretRetrieveResponse { Secret = "secret" };

        string expectedSecret = "secret";

        Assert.Equal(expectedSecret, model.Secret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookSecretRetrieveResponse { Secret = "secret" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSecretRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookSecretRetrieveResponse { Secret = "secret" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSecretRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSecret = "secret";

        Assert.Equal(expectedSecret, deserialized.Secret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookSecretRetrieveResponse { Secret = "secret" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookSecretRetrieveResponse { Secret = "secret" };

        WebhookSecretRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
