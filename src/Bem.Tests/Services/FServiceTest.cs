using System.Threading.Tasks;
using Bem.Models.Fs;

namespace Bem.Tests.Services;

public class FServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Navigate_Works()
    {
        var response = await this.client.Fs.Navigate(
            new() { Op = Op.Ls },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
