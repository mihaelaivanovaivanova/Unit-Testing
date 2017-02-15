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
    class CourseStartingDateTests
    {
        [Test]
        public void StartingDate_WhenPassedNull_ShouldThrowArgumentException()
        {
            //Arrange
            var startDate = new DateTime(2016, 05, 30);
            var endDate = new DateTime(2016, 06, 29);
            var course= new Course("History", 5, startDate, endDate);
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => course.StartingDate=null);
        }

        [Test]
        public void StartingDate_WhenPassesValidValue_ShouldSetStartingDateCorrectly()
        {
            //Arrange
            var startDate = new DateTime(2016, 05, 30);
            var newStartDate = new DateTime(2016, 05, 25);
            var endDate = new DateTime(2016, 06, 29);
            var course = new Course("History", 5, startDate, endDate);
            //Act
            course.StartingDate = newStartDate;
            //Assert
            Assert.AreEqual(newStartDate, course.StartingDate);
        }
    }
}
