using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

namespace TogglAPI.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        public TogglAPI togglAPI;
        [TestMethod]
        public async Task ShouldAuthenticate()
        {
            //arrange
            string username = "adrian.lupu@fullscreendigital.ro";
            string password = "FacemMetal";
            togglAPI = new TogglAPI();

            //act
            bool isAuthenticated = await togglAPI.AuthenticateAsync(username, password);

            //asssert
            Assert.IsTrue(isAuthenticated, "Username or password incorrect");
            Assert.IsNotNull(togglAPI.access_token, "Didn't obtain an access token");
        }

        [TestMethod]
        public async Task ShouldReturnWorkspace(int a)
        {
            //arrange

            //act
            var workspace = await togglAPI.GetWorkspacesAsync();
            //assert
            Assert.IsNotNull(workspace);
        }
    }
}
