using System;
using Bem;

namespace Bem.Tests;

public class TestBase
{
    protected IBemClient client;

    public TestBase()
    {
        client = new BemClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
