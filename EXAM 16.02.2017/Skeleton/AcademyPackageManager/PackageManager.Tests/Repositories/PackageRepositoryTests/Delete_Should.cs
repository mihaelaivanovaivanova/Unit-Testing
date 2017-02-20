using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    class Delete_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenNullIsPassed()
        {
            //Arrange
            var loggerMock = new Mock<PackageManager.Info.Contracts.ILogger>();
            var packageRepository = new PackageRepository(loggerMock.Object);
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Add(null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageDoesNotExist()
        {
            //Arrange
            var loggerMock = new Mock<PackageManager.Info.Contracts.ILogger>();
            var packageVersionMock = new Mock<IVersion>();
            var packageVersionToAddMock = new Mock<IVersion>();
            var package = new Package("packageName", packageVersionMock.Object);
            var packageToDelete = new Package("otherPackageName", packageVersionToAddMock.Object);

            var packagesCollection = new Collection<IPackage>();
            packagesCollection.Add(package);
            var packageRepository = new PackageRepository(loggerMock.Object, packagesCollection);
            var packageMock = new Mock<ICollection<IPackage>>();
            //packageRepository.Delete(packageToDelete);
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Delete(packageToDelete));
            //loggerMock.Verify(x => x.Log(string.Format("{0}: The package does not exist!", packageToDelete.Name)), Times.Once);
        }
    }
}
