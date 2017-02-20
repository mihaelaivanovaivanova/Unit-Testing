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
    class Constructor_Should
    {
        [Test]
        public void SetDependenciesCorrectly_WhenDependenciesIsNotPassed()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("packageName", versionMock.Object);
            //Act and Assert
            Assert.IsInstanceOf<System.Collections.Generic.HashSet<IPackage>>(package.Dependencies);
        }

        [Test]
        public void SetDependenciesCorrectly_WhenDependenciesIsPassed()
        {
            //Arrange
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();
            var package = new Package("packageName", versionMock.Object,dependenciesMock.Object);
            //Act and Assert
            Assert.AreEqual(dependenciesMock.Object, package.Dependencies);
        }
    }
}
