using Moq;
using NUnit.Framework;
using SSO.DataAccessLayer.Implementations;
using SSO.DataAccessLayer.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class UserServiceTest
    {
        private static readonly Mock<IHttpHandler> _moqHandler = new Mock<IHttpHandler>();
        private  IUserService _userService;

        #region Mock data
       readonly HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound)
        { Content = new StringContent("{\"id\":\"00u8cd34fdh\" }", System.Text.Encoding.UTF8, "application/json") };

        string accessToken = "ejydufjcndlfsfj6clmcw246vdhsofnsf632dfsdfsdgsfasf";
        #endregion
        [SetUp]
        public void Setup()
        {
            _moqHandler.Setup(x => x.AddHeader(It.IsAny<string>(), It.IsAny<string>()));
            _moqHandler.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(response));
            
            _userService = new UserService(_moqHandler.Object);
        }

        [Test]
        public void GetUserIdTest()
        {
            try
            {
                string userId = _userService.GetUserId(accessToken);
                Assert.AreEqual("00u8cd34fdh", userId);

            }
            catch (Exception e)
            {

            }
        }
    }
}