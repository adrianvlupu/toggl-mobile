using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

namespace TogglAPI.Tests
{
    [TestClass]
    public class APITests
    {
        private TogglAPI togglAPI;
        [TestInitialize]
        public async Task InitAPI()
        {
            //arrange
            string username = "test";
            string password = "test";
            togglAPI = new TogglAPI();

            //act
            bool isAuthenticated = await togglAPI.AuthenticateAsync(username, password);

            //asssert
            Assert.IsTrue(isAuthenticated, "Username or password incorrect");
            Assert.IsNotNull(togglAPI.access_token, "Didn't obtain an access token");
        }

        [TestMethod]
        public async Task ShouldReturnWorkspace()
        {
            //arrange

            //act
            var workspace = await togglAPI.GetWorkspacesAsync();
            var me = await togglAPI.GetMeAsync();

            //assert
            Assert.IsNotNull(workspace);
        }
    }
}
