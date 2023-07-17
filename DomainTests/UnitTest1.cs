using System.Net;

namespace DomainTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GET_Root_Responds_OK()
        {
            await using var application = new DomainApplication();

            using var client = application.CreateClient();
            using var response = await client.GetAsync("/api/posts");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}