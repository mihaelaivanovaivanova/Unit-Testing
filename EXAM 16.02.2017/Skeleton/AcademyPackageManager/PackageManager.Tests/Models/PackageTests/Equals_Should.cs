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
    class Equals_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_IfPassedObjIsNull()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void ShouldThrowArgumentException_IfPassedObjIsNotOfTypeIPackage()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.Throws<ArgumentException>(() => package.Equals("someString"));
        }

        [Test]
        public void ShouldReturnTrue_WhenPassedPackageIsEqualToPackage()
        { 
            //Arrange
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(20);
            versionMock.Setup(x => x.Minor).Returns(20);
            versionMock.Setup(x => x.Patch).Returns(20);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var objMock = new Mock<IPackage>();
            objMock.SetupGet(x => x.Name).Returns("packageName");
            objMock.Setup(x => x.Version.Major).Returns(20);
            objMock.Setup(x => x.Version.Minor).Returns(20);
            objMock.Setup(x => x.Version.Patch).Returns(20);
            objMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.IsTrue(package.Equals(objMock.Object));
        }

        [Test]
        public void ShouldReturnFalse_WhenPassedPackageIsNotEqualToPackage()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(20);
            versionMock.Setup(x => x.Minor).Returns(20);
            versionMock.Setup(x => x.Patch).Returns(20);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var objMock = new Mock<IPackage>();
            objMock.SetupGet(x => x.Name).Returns("otherPackageName");
            objMock.Setup(x => x.Version.Major).Returns(10);
            objMock.Setup(x => x.Version.Minor).Returns(10);
            objMock.Setup(x => x.Version.Patch).Returns(10);
            objMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.IsFalse(package.Equals(objMock.Object));
        }
    }
}
