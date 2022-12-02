using System.Diagnostics;
using tower_battle.Models;
using tower_battle.Models.Flyweight;
using Xunit.Abstractions;

namespace tower_battle_integration_tests
{
    public class GameControllerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public GameControllerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        //[Fact]
        //public async void Join_JoiningWithDifferentUserIds_CorrectUserRoleIsReturned()
        //{
        //    var userId1 = Guid.NewGuid();
        //    var userId2 = Guid.NewGuid();

        //    // Create a server instance
        //    var app = new WebApplicationFactory<Program>();
        //    using var client = app.CreateClient();

        //    var respose = await client.PostAsync($"/api/Game/Join?userId={userId1}", null);
        //    Assert.Equal("1", await respose.Content.ReadAsStringAsync());

        //    respose = await client.PostAsync($"/api/Game/Join?userId={userId2}", null);
        //    Assert.Equal("2", await respose.Content.ReadAsStringAsync());

        //    respose = await client.PostAsync($"/api/Game/Join?userId=AnyId", null);
        //    Assert.Equal("3", await respose.Content.ReadAsStringAsync());

        //    //Cleanup
        //    await app.DisposeAsync();
        //}
        [Fact]
        public void LegionPerformanceTest()
        {
            Stopwatch stopwatch = new Stopwatch();

            var m_baseLegions = new List<string>() {"Soldier Legion", "Scout Legion", "Tank Legion"};
            var armyList = new List<Army>();
            var testBatchSize = 1000;

            _testOutputHelper.WriteLine($"{testBatchSize} armies and legions created:");
            _testOutputHelper.WriteLine("");

            //Print mem usage
            stopwatch.Start();
            _testOutputHelper.WriteLine("Starting mem:");
            _testOutputHelper.WriteLine((Process.GetCurrentProcess().PrivateMemorySize64/1000).ToString() + " kB.");
            _testOutputHelper.WriteLine("");

            for (int i = 0; i < testBatchSize; i++)
            {
                var army = new Army();
                for (int j = 0; j < testBatchSize; j++)
                {
                    foreach (var legion in m_baseLegions)
                    {
                        army.AddChild(new Legion(FlyweightFactory.GetLegion(legion)));
                    }
                }
                armyList.Add(army);
            }
            stopwatch.Stop();

            //Print mem usage
            _testOutputHelper.WriteLine("After class creation mem:");
            _testOutputHelper.WriteLine((Process.GetCurrentProcess().PrivateMemorySize64 / 1000).ToString() + " kB.");
            _testOutputHelper.WriteLine("");

            _testOutputHelper.WriteLine("Time elapsed: " + stopwatch.ElapsedMilliseconds + " ms.");

            Assert.Equal(testBatchSize, armyList.Count);
        }
    }
}