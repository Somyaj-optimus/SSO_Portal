using Moq;
using NUnit.Framework;
using SSO.DataAccessLayer.Interfaces;

namespace Tests
{
    public class UserServiceTest
    {
        private static readonly Mock<IHttpHandler> _moqHandler = new Mock<IHttpHandler>();

        #region Mock data

        #endregion
        [SetUp]
        public void Setup()
        {
            _moqHandler.Setup(x => x.AddHeader(It.IsAny<string>(), It.IsAny<string>()));
            _moqHandler.Setup(x => x.GetAsync(It.IsAny<string>())).Returns();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}