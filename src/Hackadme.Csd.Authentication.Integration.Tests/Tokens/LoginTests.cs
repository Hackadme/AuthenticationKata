using FluentAssertions;
using Hackadme.Csd.Authentication.Tokens;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace Hackadme.Csd.Authentication.Integration.Tests.Tokens
{
    public class LoginTests : IClassFixture<WebApplicationFactory<TokenController>>
    {
        private readonly WebApplicationFactory<TokenController> factory;

        public LoginTests(WebApplicationFactory<TokenController> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Success()
        {
            var requestBody = @"{
                ""email"": ""test@hackadme.test"",
                ""password"": ""test123$""
            }";

            var http = factory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/tokens/login");
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await http.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(body);

            json.Should().NotBeNull();
            json["accessToken"].Value<string>().Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task BadEmail()
        {
            var requestBody = @"{
                ""email"": ""INVALID"",
                ""password"": ""test123$""
            }";

            var http = factory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/tokens/login");
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await http.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task BadPassword()
        {
            var requestBody = @"{
                ""email"": ""test@hackadme.test"",
                ""password"": ""INVALID""
            }";

            var http = factory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/tokens/login");
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await http.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task NoBody()
        {
            var http = factory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/tokens/login");
            request.Content = new StringContent(@"", Encoding.UTF8, "application/json");
            var response = await http.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}