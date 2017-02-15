using Academy.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Courses
{
    [TestFixture]
    class CourseNameTests
    {
       [TestCase ("Ma")]
       [TestCase("some very bery giga mega tetra super duper hiper long name")]
       [TestCase(null)]
       public void Name_WhenPassedValueIsNotValid_ShouldThrowArgumentException(string name)
        {
            //Arrange
            var startDate = new DateTime(2016, 05, 30);
            var endDate = new DateTime(2016, 06, 29);
            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Course(name, 5, startDate, endDate));
        }

        [Test]
        public void Name_WhenPassesValidValue_ShouldSetNameCorrectly()
        {
            //Arrange
            var startDate = new DateTime(2016, 05, 30);
            var endDate = new DateTime(2016, 06, 29);
            //Act
            var course= new Course("History", 5, startDate, endDate);
            course.Name = "Mathematics";
            //Assert
            Assert.AreEqual("Mathematics", course.Name);
        }
    }
}
