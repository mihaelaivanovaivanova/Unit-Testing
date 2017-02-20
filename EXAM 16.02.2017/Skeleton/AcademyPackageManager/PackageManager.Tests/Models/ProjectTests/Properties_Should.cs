using NUnit.Framework;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    class Properties_Should
    {
        [Test]
        public void SetNameCorrectly_WhenValidPassedValues()
        {
            //Arrange
            var project = new Project("ProjectName", "Sofia");
            //Act and Assert
            Assert.AreEqual("ProjectName", project.Name);
        }

        [Test]
        public void ThrowArgumentNullException_WhenNameIsNull()
        {
            //Arrange, Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Project(null, "Sofia"));
        }

        [Test]
        public void SetLocationCorrectly_WhenValidPassedValues()
        {
            //Arrange
            var project = new Project("ProjectName", "Sofia");
            //Act and Assert
            Assert.AreEqual("Sofia", project.Location);
        }

        [Test]
        public void ThrowArgumentNullException_WhenLocationIsNull()
        {
            //Arrange, Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Project("ProjectName", null));
        }
    }
}
