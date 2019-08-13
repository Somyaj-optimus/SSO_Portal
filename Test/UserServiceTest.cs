using Moq;
using NUnit.Framework;
using SSO.DataAccessLayer.Implementations;
using SSO.DataAccessLayer.Interfaces;
using SSO.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Tests
{
    public class UserServiceTest
    {
        #region Private Fields

        private static readonly Mock<IHttpHandler> _moqHandler = new Mock<IHttpHandler>();
        private IUserService _userService;
        #endregion

        #region Mock data

        readonly HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
        { Content = new StringContent("{\"sub\":\"00u8cd34fdh\" }", System.Text.Encoding.UTF8, "application/json") };

        readonly HttpResponseMessage response1 = new HttpResponseMessage(HttpStatusCode.OK)
        { Content = new StringContent("[{\"id\":\"aaa\",\"label\":\"aaa\",\"linkUrl\":\"aaa\",\"logoUrl\":\"aaa\",\"appName\":\"aaa\"}]", System.Text.Encoding.UTF8, "application/json") };

        string accessToken = "ejydufjcndlfsfj6clmcw246vdhsofnsf632dfsdfsdgsfasf";

        string userId = "00aV-lNOo6y5DkdFfBH7CDuNKxj5OIc4Mw-PM_D_VV";

        private List<Application> _listOfApplication = new List<Application>()
        {
            new Application()
            {
                ApplicationId="aaa",
                AppName="aaa",
                Label="aaa",
                LinkUrl="aaa",
                LogoUrl="aaa"
            }
        };

        List<Application> _EmptylistOfApplication = null;

        #endregion

        #region Setup method to initialize mock results
        [SetUp]
        public void Setup()
        {
            _moqHandler.Setup(x => x.AddHeader(It.IsAny<string>(), It.IsAny<string>()));
            // Arrange 
            _userService = new UserService(_moqHandler.Object);
        }

        #endregion

        #region Public Test Methods
        [Test]
        public void GetUserIdTest()
        {
            // Arrange 
            _moqHandler.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(response);
            //Act
            string userId = _userService.GetUserId(accessToken);
            //Assert
            Assert.AreEqual("00u8cd34fdh", userId);
            //Assert.Throws<NullReferenceException>(() => _userService.GetUserId(null));
        }

        [Test]
        public void GetApplications()
        {
            // Arrange 
            _moqHandler.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(response1);
            //Act
            var actual = _userService.GetApplications(userId);
            //Assert
            Assert.AreEqual(actual.Count, _listOfApplication.Count);
            Assert.AreEqual(actual[0].ApplicationId, _listOfApplication[0].ApplicationId);
            Assert.AreEqual(actual[0].AppName, _listOfApplication[0].AppName);
            Assert.AreEqual(actual[0].LogoUrl, _listOfApplication[0].LogoUrl);
            Assert.AreEqual(actual[0].Label, _listOfApplication[0].Label);
        }
        #endregion
    }
}