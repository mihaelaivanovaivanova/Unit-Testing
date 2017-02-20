using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    class Properties_Should
    {
        [Test]
        public void SetNameCorrectly_WhenValidPassedValues()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.AreEqual("packageName", package.Name);
        }

        [Test]
        public void ThrowArgumentNullException_WhenNameIsNull()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Package(null, versionMock.Object));
        }

        [Test]
        public void SetVersionCorrectly_WhenValidPassedValues()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.AreEqual(versionMock.Object, package.Version);
        }

        public void ThrowArgumentNullException_WhenVersionIsNull()
        {
            //Arrange,Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Package("packageName", null));
        }
        [Test]

        public void SetUrlCorrectly_WhenValidPassedValues()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(x => x.Major).Returns(20);
            versionMock.SetupGet(x => x.Minor).Returns(10);
            versionMock.SetupGet(x => x.Patch).Returns(3);
            versionMock.SetupGet(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package("packageName", versionMock.Object);
            var expectedUrl = string.Format("{0}.{1}.{2}-{3}", versionMock.Object.Major, versionMock.Object.Minor, versionMock.Object.Patch, versionMock.Object.VersionType);
            //Act and Assert
            Assert.AreEqual(expectedUrl, package.Url);
        }
    }
}
