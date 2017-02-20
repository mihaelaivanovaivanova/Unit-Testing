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
    class Fields_Should
    {
        [Test]
        public void PackageBeSetCorrectly_WhenPackageIsValidValue()
        {
            //Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            //Act
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);
            //Assert
            Assert.AreEqual(packageMock.Object, installCommand.Package);
        }

        [Test]
        public void InstallerBeSetCorrectly_WhenInstallerIsValidValue()
        {
            //Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            //Act
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);
            //Assert
            Assert.AreEqual(installerMock.Object, installCommand.Installer);
        }

    }
}
