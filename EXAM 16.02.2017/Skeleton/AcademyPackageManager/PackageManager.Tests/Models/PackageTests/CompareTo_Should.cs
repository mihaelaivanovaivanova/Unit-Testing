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
    class CompareTo_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_IfPassedOtherIsNull()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void ShouldThrowArgumentException_IfPassedOtherISWithTheSameName()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var otherMock = new Mock<IPackage>();
            otherMock.SetupGet(x => x.Name).Returns("otherPackageName");
            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(otherMock.Object));
        }

        [Test]
        public void ShouldReturnMinus1_IfPassedOtherIsHighterVersion()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(x => x.Major).Returns(10);
            versionMock.SetupGet(x => x.Minor).Returns(10);
            versionMock.SetupGet(x => x.Patch).Returns(10);
            versionMock.SetupGet(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var otherMock = new Mock<IPackage>();
            otherMock.SetupGet(x => x.Name).Returns("packageName");
            otherMock.SetupGet(x => x.Version.Major).Returns(30);
            otherMock.SetupGet(x => x.Version.Minor).Returns(30);
            otherMock.SetupGet(x => x.Version.Patch).Returns(30);
            otherMock.SetupGet(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package("packageName", versionMock.Object);

            //Act and Assert
            Assert.AreEqual(-1, package.CompareTo(otherMock.Object));
        }

        [Test]
        public void ShouldReturn0_IfPassedOtherIsSameVersion()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(x => x.Major).Returns(10);
            versionMock.SetupGet(x => x.Minor).Returns(10);
            versionMock.SetupGet(x => x.Patch).Returns(10);
            versionMock.SetupGet(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var otherMock = new Mock<IPackage>();
            otherMock.SetupGet(x => x.Name).Returns("packageName");
            otherMock.SetupGet(x => x.Version.Major).Returns(10);
            otherMock.SetupGet(x => x.Version.Minor).Returns(10);
            otherMock.SetupGet(x => x.Version.Patch).Returns(10);
            otherMock.SetupGet(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package("packageName", versionMock.Object);

            //Act and Assert
            Assert.AreEqual(0, package.CompareTo(otherMock.Object));
        }

        [Test]
        public void ShouldReturn1_IfPassedOtherIsLowerVersion()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(x => x.Major).Returns(30);
            versionMock.SetupGet(x => x.Minor).Returns(30);
            versionMock.SetupGet(x => x.Patch).Returns(30);
            versionMock.SetupGet(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var otherMock = new Mock<IPackage>();
            otherMock.SetupGet(x => x.Name).Returns("packageName");
            otherMock.SetupGet(x => x.Version.Major).Returns(10);
            otherMock.SetupGet(x => x.Version.Minor).Returns(10);
            otherMock.SetupGet(x => x.Version.Patch).Returns(10);
            otherMock.SetupGet(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package("packageName", versionMock.Object);

            //Act and Assert
            Assert.AreEqual(1, package.CompareTo(otherMock.Object));
        }


    }
}
