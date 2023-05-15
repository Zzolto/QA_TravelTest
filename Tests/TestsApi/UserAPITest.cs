using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace SeleniumWebDriverProjectt.TestsApi;

[TestFixture]
public class UsersAPITest
{
    private HttpClient _httpClient;

    [SetUp]
    public void SetUp()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://reqres.in/api/");
    }

    [Test]
    public async Task GetUsersTest()
    {
        var data = new {name = "Zolto", job = "Tester"};
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = _httpClient.PostAsync("users", content).Result;
        var responseContent = response.Content.ReadAsStringAsync().Result;

        JObject createdUser = JObject.Parse(responseContent);
        
        Assert.IsTrue(response.IsSuccessStatusCode, "POST request failed");
        
        Assert.AreEqual(201, (int)response.StatusCode);
        Assert.AreEqual("Zolto",(string)createdUser["name"],  "Unexpected created user name");
        Assert.AreEqual("Tester", (string)createdUser["job"],  "Unexpected created user job");
        
        Assert.IsNotNull((int)createdUser["id"], "Missing user ID");
    }
}