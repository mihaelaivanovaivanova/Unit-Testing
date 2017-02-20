using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    class Properties_should
    {
        [Test]
        public void SetOperationToInstaller_WhenValidInstallCommandISInitialised()
        {
            //Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            //Act
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);
            //Assert
            Assert.IsInstanceOf<InstallerOperation>(installCommand.Installer.Operation);
        }
    }
}
