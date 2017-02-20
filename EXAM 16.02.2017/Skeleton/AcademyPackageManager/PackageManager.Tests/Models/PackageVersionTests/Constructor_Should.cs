using NUnit.Framework;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    class Constructor_Should
    {
        [Test]
        public void SetMajorCorrecly_WhenValidArgumentsPassed()
        {
            //Arrange
            var packageVersion = new PackageVersion(20, 5, 3, Enums.VersionType.beta);
            //Act and Assert
            Assert.AreEqual(20, packageVersion.Major);
        }

        [Test]
        public void SetMinorCorrecly_WhenValidArgumentsPassed()
        {
            //Arrange
            var packageVersion = new PackageVersion(20, 5, 3, Enums.VersionType.beta);
            //Act and Assert
            Assert.AreEqual(5, packageVersion.Minor);
        }

        [Test]
        public void SetPatchCorrecly_WhenValidArgumentsPassed()
        {
            //Arrange
            var packageVersion = new PackageVersion(20, 5, 3, Enums.VersionType.beta);
            //Act and Assert
            Assert.AreEqual(3, packageVersion.Patch);
        }

        [Test]
        public void SetVersionTypeCorrecly_WhenValidArgumentsPassed()
        {
            //Arrange
            var packageVersion = new PackageVersion(20, 5, 3, Enums.VersionType.beta);
            //Act and Assert
            Assert.AreEqual(Enums.VersionType.beta, packageVersion.VersionType);
        }
    }
}
