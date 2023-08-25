using JRChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;

namespace JRChallenge.Test
{
    [TestFixture]
    public class PermissionIntegratedTest
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _httpClient = _factory.CreateClient();
        }

        [TearDown]
        public void Teardown()
        {
            _httpClient.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetPermissionById_ReturnsExpectedPermission()
        {
            // Arrange
            var permissionId = 2;       

            // Act
            var response = await _httpClient.GetAsync($"permission/{permissionId}");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var actualPermission = JsonSerializer.Deserialize<Permissions>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            });

            Assert.IsNotNull(actualPermission);
            Assert.AreEqual(permissionId, actualPermission.Id);
        }

    }
}
