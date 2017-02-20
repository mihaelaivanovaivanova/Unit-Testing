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
    class Execute_Should
    {
        [Test]
        public void CallOperationFromInstaller()
        {
            //Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);
            //Act
            installerMock.Object.PerformOperation(installCommand.Package);
            //Assert
            installerMock.Verify(x => x.PerformOperation(installCommand.Package), Times.Once);
        }
    }
}
