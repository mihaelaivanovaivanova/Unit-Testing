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
    class Properties_Should
    {
        [Test]
        public void NotThrow_WhenValidMajorIsPassed()
        {
            //Arrange
            var packageVersion = new PackageVersion(20, 5, 3, Enums.VersionType.beta);
            //Act and Assert
            Assert.AreEqual(20, packageVersion.Major);
        }

        [Test]
        public void ThrowArgimentException_WhenInvalidMajorValueIsPassed()
        {
            
            //Arrange,Act and Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(-20, 5, 3, Enums.VersionType.beta));
        }

        [Test]
        public void NotThrow_WhenValidMinorIsPassed()
        {
            //Arrange
            var packageVersion = new PackageVersion(20, 5, 3, Enums.VersionType.beta);
            //Act and Assert
            Assert.AreEqual(5, packageVersion.Minor);
        }

        [Test]
        public void ThrowArgimentException_WhenInvalidMinorValueIsPassed()
        {

            //Arrange,Act and Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(20, -5, 3, Enums.VersionType.beta));
        }

        [Test]
        public void NotThrow_WhenValidPatchIsPassed()
        {
            //Arrange
            var packageVersion = new PackageVersion(20, 5, 3, Enums.VersionType.beta);
            //Act and Assert
            Assert.AreEqual(3, packageVersion.Patch);
        }

        [Test]
        public void ThrowArgimentException_WhenInvalidPatchValueIsPassed()
        {

            //Arrange,Act and Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(20, 5, -3, Enums.VersionType.beta));
        }

        [Test]
        public void NotThrow_WhenValidTypeIsPassed()
        {
            //Arrange
            var packageVersion = new PackageVersion(20, 5, 3, Enums.VersionType.beta);
            //Act and Assert
            Assert.AreEqual(Enums.VersionType.beta, packageVersion.VersionType);
        }

        [Test]
        public void ThrowArgimentException_WhenInvalidTypeValueIsPassed()
        {

            //Arrange,Act and Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(20, 5, 3, (Enums.VersionType)154));
        }
    }
}
