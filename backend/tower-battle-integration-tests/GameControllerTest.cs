using Microsoft.AspNetCore.Mvc.Testing;

namespace tower_battle_integration_tests
{
    public class GameControllerTest
    {
        [Fact]
        public async void Join_JoiningWithDifferentUserIds_CorrectUserRoleIsReturned()
        {
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();

            // Create a server instance
            var app = new WebApplicationFactory<Program>();
            using var client = app.CreateClient();

            var respose = await client.PostAsync($"/api/Game/Join?userId={userId1}", null);
            Assert.Equal("1", await respose.Content.ReadAsStringAsync());

            respose = await client.PostAsync($"/api/Game/Join?userId={userId2}", null);
            Assert.Equal("2", await respose.Content.ReadAsStringAsync());

            respose = await client.PostAsync($"/api/Game/Join?userId=AnyId", null);
            Assert.Equal("3", await respose.Content.ReadAsStringAsync());

            //Cleanup
            await app.DisposeAsync();
        }
    }
}