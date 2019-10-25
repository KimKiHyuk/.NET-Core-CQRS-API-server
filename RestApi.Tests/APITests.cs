using System;
using Xunit;
using RestApi.Controllers;
using RestApi;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Tests // project hierchy is bad. move this folder to outside of RestApi
{
    public class APITests
    {
        HttpClient client;
        TestServer testServer;

        public APITests()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("/home/key/repository/dotnet-project/RestApi/appsettings.json")
            .Build();
            
            testServer = new TestServer(new WebHostBuilder()
            .UseConfiguration(configuration)
            .UseStartup<Startup>()
            );

            client = testServer.CreateClient();
        }

        [Fact]
        public async Task Inspect_Status_Get()
        {
            // Arrange
            HttpResponseMessage response = null;

            // Act
            response = await client.GetAsync("/resume/aboutme");
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
