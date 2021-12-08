using System.Net;
using System.Net.Http;
using B_Shop;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTest
{
    [TestClass]
    public class CustomerTests
    {
        private readonly HttpClient _client;

        public CustomerTests()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [TestMethod]
        public void GetAllCustomerTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), "/api/Customers");
            var response = _client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK,response.Result.StatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public void CustomerGetOneTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), $"/Api/Customers/{id}");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void CustomerPostTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), $"/Api/Customers");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
