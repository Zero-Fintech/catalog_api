using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Zero.Catalog.Api.ComponentTests;

public class ApiFixture : IClassFixture<TestWebApplicationFactory<Program>>
{
    protected readonly HttpClient Client;

    public ApiFixture(TestWebApplicationFactory<Program> factory)
    {
        Client = factory.CreateClient();
    }
}