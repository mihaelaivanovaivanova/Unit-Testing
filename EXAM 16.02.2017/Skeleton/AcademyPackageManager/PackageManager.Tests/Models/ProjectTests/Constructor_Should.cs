using Castle.Core.Logging;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    class Constructor_Should
    {
        [Test]
        public void SetPackageCorrectly_WhenPackageIsNotPassed()
        {
            //Arrange
            var project = new Project("ProjectName", "Sofia");
            //Act and Assert
            Assert.IsInstanceOf<PackageRepository>(project.PackageRepository);
        }

        [Test]
        public void SetPackagesCorrectly_WhenPackageIsPassed()
        {
            //Arrange
            var packagesMock = new Mock<IRepository<IPackage>>();
            var project = new Project("ProjectName", "Sofia",packagesMock.Object);
            //Act and Assert
            Assert.AreEqual(packagesMock.Object,project.PackageRepository);
        }
    }
}
