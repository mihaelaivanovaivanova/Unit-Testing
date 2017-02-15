using Academy.Tests.Models.Abstraction.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Abstraction.Users
{
    [TestFixture]
    class UserConstructorTests
    {
        [Test]
        public void Constructor_WhenNameIsValid_ShouldAssignNameCorrectly()
        {
            //Arrange
            var user = new UserMock("pesho");
            //Act and Assert
            Assert.AreEqual("pesho", user.Username);
        }

        [TestCase("us")]
        [TestCase("very very very very long user name")]

        public void Constructor_WhenNameIsNotValid_ShouldThrowArgumentException(string username)
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => new UserMock(username));
        }
    }
}
