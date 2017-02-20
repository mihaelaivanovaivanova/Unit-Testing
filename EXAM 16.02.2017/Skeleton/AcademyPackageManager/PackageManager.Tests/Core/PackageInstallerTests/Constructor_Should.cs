using Castle.Core.Logging;
using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    class Constructor_ShouldR
    {
        [Test]
        public void RestorePackages_WhenObjectIsConstructed()
        {
            //Arrange
            var firstDependencyMock = new Mock<IPackage>();
            var secondDependencyMock = new Mock<IPackage>();
            var dependencies = new Collection<IPackage>();
            dependencies.Add(firstDependencyMock.Object);
            dependencies.Add(secondDependencyMock.Object);
            var packageVersionMock = new Mock<IVersion>();
            var package = new Package("packageName", packageVersionMock.Object, dependencies);

            var packagesCollection = new Collection<IPackage>();
            packagesCollection.Add(package);
            var logger = new Mock<PackageManager.Info.Contracts.ILogger>();
            var packageRepositry = new PackageRepository(logger.Object, packagesCollection);
            var project = new Project("projectName", "Sofia", packageRepositry);
            var downloaderMock = new Mock<IDownloader>();
            var packageInstaller = new PackageInstaller(downloaderMock.Object, project);
            //Act and Assert
        }
        
    }
}
