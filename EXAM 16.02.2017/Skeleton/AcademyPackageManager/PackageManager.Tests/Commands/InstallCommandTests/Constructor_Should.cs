using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenInstallerIsNull()
        {
            //Arrange
            var packageMock = new Mock<IPackage>();
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(null, packageMock.Object));
        }

        [Test]
        public void ShouldSetInstallerCorrectly_WhenInstallerIsValidValue()
        {
            //Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            //Act
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);
            //Assert
            Assert.AreEqual(installerMock.Object, installCommand.Installer);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNull()
        {
            //Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(installerMock.Object, null));
        }

        [Test]
        public void ShouldSetPackageCorrectly_WhenPackageIsValidValue()
        {
            //Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            //Act
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);
            //Assert
            Assert.AreEqual(packageMock.Object, installCommand.Package);
        }
   
    }
}
