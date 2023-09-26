using FluentAssertions;
using Hackadme.Csd.Authentication.Tokens;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace Hackadme.Csd.Authentication.Integration.Tests.Users
{
    public class CrudTests : IClassFixture<WebApplicationFactory<TokenController>>
    {
        private readonly WebApplicationFactory<TokenController> factory;

        public CrudTests(WebApplicationFactory<TokenController> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task CreateGetSuccess()
        {
            var id = await CreateTest();
            await GetTest(id);
        }

        private async Task<string> CreateTest()
        {
            var requestBody = @"{
                ""email"": ""foo@hackadme.test"",
                ""password"": ""bar123$""
            }";

            var http = factory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await http.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(body);

            json.Should().NotBeNull();
            var id = json["id"].Value<string>();
            id.Should().NotBeNullOrEmpty();

            return id;
        }

        private async Task GetTest(string id)
        {
            var requestBody = @"{
                ""email"": ""foo@hackadme.test"",
                ""password"": ""bar123$""
            }";

            var http = factory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/users/{id}");
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await http.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(body);

            json.Should().NotBeNull();
            json["id"].Value<string>().Should().NotBeNullOrEmpty();
            json["email"].Value<string>().Should().Be("foo@hackadme.test");
        }
    }
}